using Newtonsoft.Json;
using SActivity.Common.Enums;
using TinyFx;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using UGame.Activity.CoinSignin.Caching;
using UGame.Activity.CoinSignin.Common;
using UGame.Activity.CoinSignin.Model;
using UGame.Activity.CoinSignin.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.CoinSignin.Service;

/// <summary>
/// 积分签到服务
/// </summary>
public class CoinSigninService
{
    private readonly Repository<Sa_coin_signin_detailPO> _signinDetailRep;

    public CoinSigninService()
    {
        _signinDetailRep=DbUtil.GetRepository<Sa_coin_signin_detailPO>();
    }

    /// <summary>
    /// 加载签到
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<CoinSigninLoadDto> LoadAsync(CoinSigninIpo ipo)
    {
        if (!await IsValidActivity(ipo.OperatorId, ipo.CurrencyId)) throw new CustomException("Invalid activity");

        //初始化ProcessData
        ipo.ProcessData = await GetProcessData(ipo.UserId);

        //重新计算周期
        if (await IsReset(ipo)) return ResetExcute(ipo);

        return CoinSigninLoad(ipo);
    }

    /// <summary>
    /// 签到
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<CoinSigninDto> ExecuteAsync(CoinSigninIpo ipo)
    {
        if (!await IsValidActivity(ipo.OperatorId, ipo.CurrencyId)) throw new CustomException("Invalid activity.");

        var globalUserDCache = await GlobalUserDCache.Create(ipo.UserId);
        var operatorId = await globalUserDCache.GetOperatorIdAsync();
        var currencyId = await globalUserDCache.GetCurrencyIdAsync();

        //签到过程中的数据
        ipo.ProcessData = await GetProcessData(ipo.UserId, true);

        var ret = new CoinSigninDto();        

        if (ipo.DateNumber > ipo.ProcessData.SigninCycle) return ret;

        //签到日期
        var signinDate = ipo.ProcessData.SigninCycleStartDate;

        for (int i = 0; i < ipo.ProcessData.SigninCycle; i++)
        {
            if (ipo.DateNumber == i + 1) break;

            signinDate = signinDate.AddDays(1).Date;
        }

        //签到日期签到明细
        var rewardDetailEo = ipo.ProcessData.UserLastDetailEoList.Where(d => d.DayId == signinDate).FirstOrDefault();

        //签到状态
        var signinStatus = SigninStatus.None;

        if (rewardDetailEo ==null)
        {
            if (signinDate > ipo.ProcessData.CurrentDate)
            {
                signinStatus = SigninStatus.NoAllow;
                ret.StatusDesc = signinStatus.ToString();
                return ret;
            }
            else if (signinDate == ipo.ProcessData.CurrentDate)
            {
                signinStatus = SigninStatus.Allow;
                ret.StatusDesc = signinStatus.ToString();
                ipo.ProcessData.IsSignin=true;
            }
        }
        else
        {
            signinStatus = SigninStatus.Signined;
            ret.StatusDesc = signinStatus.ToString();
            return ret;
        }

        //当天不允许签到
        if (!ipo.ProcessData.IsSignin) return ret;

        var tm = new DbTransactionManager();
        try
        {
            tm.Begin();
            //签到日对应的配置
            var signinConfigEo = ipo.ProcessData.SigninConfigEoList.Where(_ => _.DateNumber==ipo.DateNumber).FirstOrDefault();

            //配置异常，奖励金额为0或者为负数
            if (signinConfigEo==null|| signinConfigEo?.Reward == 0||signinConfigEo?.Reward<0)
                throw new CustomException("sa_coin_signin_config Configuration exception or reward are 0");

            await tm.GetRepository<Sa_coin_signin_detailPO>().InsertAsync(new Sa_coin_signin_detailPO()
            {
                DayId = signinDate,
                UserID = ipo.UserId,
                OperatorID = ipo.ProcessData.OperatorId,
                CurrencyID = ipo.ProcessData.CurrencyId,
                UserKind = 1,
                CurrentCycleNumber = ipo.DateNumber,
                Reward = signinConfigEo.Reward,
                FlowMultip = signinConfigEo.FlowMultip,
                RewardType = 1,
                SigninCycleStartDate = ipo.ProcessData.SigninCycleStartDate,
                SigninCycleEndDate = ipo.ProcessData.SigninCycleEndDate,
                RecDate = DateTime.UtcNow
            });

            var currencyChangeReq = new CurrencyChangeReq()
            {
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                OperatorId = ipo.OperatorId,
                CurrencyId = "COIN",
                Reason = "2.0签到",
                Amount =signinConfigEo.Reward,
                SourceType = (int)ActivityType.CoinSignin,
                SourceTable = "sa_coin_signin_detail",
                SourceId = $"{signinDate}|{ipo.UserId}",
                ChangeTime = DateTime.UtcNow,
                ChangeBalance = CurrencyChangeBalance.None,
                FlowMultip = signinConfigEo.FlowMultip,
                DbTM = tm
            };

            //5、写s_currency_change
            var currencyChangeService = new CurrencyChange2Service(ipo.UserId);
            var changeMsg = await currencyChangeService.Add(currencyChangeReq)??throw new Exception("写入s_currency_change失败");

            tm.Commit();
            await MQUtil.PublishAsync(changeMsg);
            await MQUtil.PublishAsync(new UserActivityMsg()
            {
                UserId = ipo.UserId,
                ActivityType = (int)ActivityType.CoinSignin
            });

            ret.Status = true;
            ret.Reward=signinConfigEo.Reward;
            return ret;
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.GetContextLogger().AddException(ex).AddMessage($"SignInController.Execute.ipo:{JsonConvert.SerializeObject(ipo)}");
            return ret;
        }
    }

    /// <summary>
    /// 是否重置签到周期
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    private static async Task<bool> IsReset(CoinSigninIpo ipo)
    {
        //1、用户没有签到数据
        if (ipo.ProcessData?.UserLastDetailEo == null) return true;

        //2、不包含昨天、今天签到记录
        var lastDetailList = ipo.ProcessData?.UserLastDetailEoList?
            .Where(_ => _.DayId==ipo.ProcessData.CurrentDate||_.DayId==ipo.ProcessData.CurrentDate.AddDays(-1)).ToList();

        if (lastDetailList.Any())
        {
            //计算当日是否被重置
            var signinDayResetRecordDCache = new CoinSigninResetRecordDCache(ipo.ProcessData.CurrentDate, ipo.UserId);
            if (!await signinDayResetRecordDCache.GetAsync())
            {
                await signinDayResetRecordDCache.SetAsync();
            }
        }
        return !lastDetailList.Any();
    }

    /// <summary>
    /// 满足条件时重置
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    private static CoinSigninLoadDto ResetExcute(CoinSigninIpo ipo)
    {
        var ret = new CoinSigninLoadDto { 
            IsSignin = ipo.ProcessData.IsSignin=true, 
        };

        var signinConfigEoList = ipo.ProcessData.SigninConfigEoList.OrderBy(d => d.DateNumber).GroupBy(d => d.DateNumber)
            .ToDictionary(d => d.Key, d => d.OrderByDescending(d => d.Reward).FirstOrDefault());

        var timeNow = ipo.ProcessData.CurrentDate.Date;

        var index = 1;
        foreach (var item in signinConfigEoList)
        {
            ret.Items.Add(new CoinSignDetails()
            {
                UserId = ipo.UserId,
                IsSelected = timeNow == ipo.ProcessData.CurrentDate,
                DayId = timeNow.ToString("yyyy-MM-dd"),
                Reward = item.Value.Reward,
                Status = item.Value.IsStartDay ? (int)SigninStatus.Allow : (int)SigninStatus.NoAllow,
                DateNumber = index
            });
            timeNow = timeNow.AddDays(1);
            index++;
        }
        return ret;
    }

    /// <summary>
    /// 签到列表数据组装
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    private static CoinSigninLoadDto CoinSigninLoad(CoinSigninIpo ipo)
    {
        //当前周期内可签到日期
        var timeNow = ipo.ProcessData.SigninCycleStartDate.Date;
        //签到状态
        var signinStatus = SigninStatus.None;

        var ret = new CoinSigninLoadDto
        {
            IsSignin = ipo.ProcessData.IsSignin,
            SigninTimes = ipo.ProcessData.UserLastDetailEoList.Count,
            PreSigninDate = ipo.ProcessData.UserLastDetailEo?.DayId.ToString("yyyy-MM-dd"),
        };

        for (int i = 0; i < ipo.ProcessData.SigninCycle; i++)
        {
            //当前周期签到明细
            var rewardDetail = ipo.ProcessData.UserLastDetailEoList.FirstOrDefault(d => d.DayId == timeNow);

            if (timeNow > ipo.ProcessData.CurrentDate.Date)
                signinStatus = SigninStatus.NoAllow;
            else if (timeNow == ipo.ProcessData.CurrentDate.Date)
                signinStatus = rewardDetail == null ? SigninStatus.Allow : SigninStatus.Signined;
            else
                signinStatus = rewardDetail == null ? SigninStatus.MissSignin : SigninStatus.Signined;

            //当前周期签到日期对应的奖励配置
            ipo.ProcessData.SigninConfigEoList = ipo.ProcessData.SigninConfigEoList.OrderBy(_ => _.DateNumber).ToList();
            var signinConfigEo = ipo.ProcessData.SigninConfigEoList.ElementAt(i);
            ret.Items.Add(new CoinSignDetails()
            {
                UserId = ipo.UserId,
                IsSelected = timeNow == ipo.ProcessData.CurrentDate,
                DayId = timeNow.ToString("yyyy-MM-dd"),
                DateNumber = i + 1,
                Reward = signinConfigEo.Reward,
                RecDate = rewardDetail != null ? new DateTime(rewardDetail.RecDate.Ticks, DateTimeKind.Utc) : null,
                Status = (int)signinStatus
            });
            //可签到日期 + 1
            timeNow = timeNow.AddDays(1);
        }

        if (ret.Items != null && ret.Items.Any(d => d.Status == (int)SigninStatus.MissSignin))
            ret.MissSigninDays=ret.Items.Where(d => d.Status == (int)SigninStatus.MissSignin).Select(_ => _.DayId).ToList();

        if (ret.Items != null) ret.IsSignin=ret.Items.Any(_ => _.Status==(int)SigninStatus.Allow);

        return ret;
    }

    /// <summary>
    /// 签到过程中的数据
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="isSignin">签到、加载</param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    private async Task<CoinSigninProcessData> GetProcessData(string userId, bool isSignin = false)
    {
        var globalUserDCache = await GlobalUserDCache.Create(userId);
        var processData = new CoinSigninProcessData
        {
            OperatorId = await globalUserDCache.GetOperatorIdAsync(),
            CurrencyId = await globalUserDCache.GetCurrencyIdAsync()
        };

        //签到配置
        processData.SigninConfigEoList =await DbUtil.GetRepository<Sa_coin_signin_configPO>().AsQueryable()
            .Where(_=>_.OperatorID== processData.OperatorId&&_.CurrencyID== processData.CurrencyId)
            .ToListAsync();

        if (!processData.SigninConfigEoList.Any())
            throw new CustomException($"config is missing configuration.{processData.OperatorId}|{processData.CurrencyId}");

        //签到周期
        processData.SigninCycle = processData.SigninConfigEoList.GroupBy(d => d.DateNumber).Count();

        //当前utc时间
        processData.UtcTime = DateTime.UtcNow;

        //当前日期
        processData.CurrentDate = processData.UtcTime.ToLocalTime(processData.OperatorId).Date;

        //当前周期起始日期
        processData.SigninCycleStartDate = processData.CurrentDate;

        //当前周期截止日期
        processData.SigninCycleEndDate = processData.CurrentDate.AddDays(processData.SigninCycle - 1).Date;

        //用户最后一次签到明细
        processData.UserLastDetailEo = await _signinDetailRep.AsQueryable()
            .Where(d => d.UserID.Equals(userId)).OrderByDescending(d => d.DayId)
            .FirstAsync();

        if (processData.UserLastDetailEo != null)
        {
            if (processData.UserLastDetailEo.DayId != processData.CurrentDate && processData.UserLastDetailEo.DayId != processData.CurrentDate.AddDays(-1))
            {
                //计算当日是否被重置
                var signinDayResetRecordDCache = new CoinSigninResetRecordDCache(processData.CurrentDate, userId);
                if (!await signinDayResetRecordDCache.GetAsync() && !isSignin)
                {
                    processData.SigninCycleStartDate = processData.UserLastDetailEo.SigninCycleStartDate;
                    processData.SigninCycleEndDate = processData.UserLastDetailEo.SigninCycleEndDate;
                }
            }
            else
            {
                if (processData.CurrentDate <= processData.UserLastDetailEo.SigninCycleEndDate)
                {
                    processData.SigninCycleStartDate = processData.UserLastDetailEo.SigninCycleStartDate;
                    processData.SigninCycleEndDate = processData.UserLastDetailEo.SigninCycleEndDate;
                }
            }
        }

        //用户最近一个签到周期明细
        processData.UserLastDetailEoList =await _signinDetailRep.AsQueryable()
            .Where(d => d.UserID.Equals(userId) && d.DayId >= processData.SigninCycleStartDate && d.DayId <= processData.SigninCycleEndDate)
            .ToListAsync();

        if (!processData.UserLastDetailEoList.Any()) processData.IsSignin = true;

        return processData;
    }

    /// <summary>
    /// 验证活动是否有效
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    private async Task<bool> IsValidActivity(string operatorId, string currencyId)
    {
        var activityOperator = await DbUtil.GetRepository<L_activity_operatorPO>().AsQueryable()
            .Where(_ => _.OperatorID==operatorId&&_.CurrencyID==currencyId)
            .ToListAsync();

        if (activityOperator!=null&& activityOperator.Any(d => d.Status && d.ActivityID == (int)ActivityType.CoinSignin))
        {
            return true;
        }

        return false;
    }
}
