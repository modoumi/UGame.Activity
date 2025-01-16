using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using SActivity.Common.Domain.Services;
using SActivity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Randoms;
using UGame.Activity.Signin.Caching;
using UGame.Activity.Signin.Common;
using UGame.Activity.Signin.Model;
using UGame.Activity.Signin.SqlSugar;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.Signin.Services
{
    public class SigninService
    {

        /// <summary>
        /// 加载签到
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<SigninLoadDto> LoadAsync(SigninLoadIpo ipo)
        {
            if (!await IsValidActivity(ipo.OperatorId, ipo.CurrencyId))
                throw new CustomException("Invalid activity.");

            //初始化ProcessData
            ipo.ProcessData = await GetProcessData(ipo.UserId);

            //重新计算周期
            if (await IsReset(ipo))
                return await ResetExcute(ipo);

            return await MainExcute(ipo);
        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<SigninDto> ExecuteAsync(SigninIpo ipo)
        {
            if (!await IsValidActivity(ipo.OperatorId, ipo.CurrencyId))
                throw new CustomException("Invalid activity.");

            var ret = new SigninDto();

            var globalUserDCache = await GlobalUserDCache.Create(ipo.UserId);
            var operatorId = await globalUserDCache.GetOperatorIdAsync();
            var currencyId = await globalUserDCache.GetCurrencyIdAsync();

            //签到过程中的数据
            ipo.ProcessData = await GetProcessData(ipo.UserId, true);
            ret.ServerTime = $"服务器时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.UtcTime = $"UTC时间：{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.LocalTime = $"运营商当地时间：{ipo.ProcessData.UtcTime.ToLocalTime(operatorId).ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.SigninCycleStartDate = $"本次签到周期起始日期：{ipo.ProcessData.SigninCycleStartDate.ToString("yyyy-MM-dd")}";
            ret.SigninCycleEndDate = $"本次签到周期截止日期：{ipo.ProcessData.SigninCycleEndDate.ToString("yyyy-MM-dd")}";

            if (ipo.DateNumber > ipo.ProcessData.SigninCycle)
                return ret;

            //签到日期
            var signinDate = ipo.ProcessData.SigninCycleStartDate;

            for (int i = 0; i < ipo.ProcessData.SigninCycle; i++)
            {
                if (ipo.DateNumber == i + 1)
                    break;

                signinDate = signinDate.AddDays(1).Date;
            }

            //签到日期签到明细
            var rewardDetailEo = ipo.ProcessData.UserLastDetailEoList.Where(d => d.DayId == signinDate).FirstOrDefault();

            //签到状态
            var signinStatus = SigninStatus.None;

            if (rewardDetailEo != null)
            {
                signinStatus = SigninStatus.Signined;
                ret.StatusDesc = signinStatus.ToString();
                return ret;
            }
            else
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
                    if (!ipo.ProcessData.IsSignin)
                    {
                        //不满足签到需要的充值金额
                        throw new CustomException(ActivityCodes.RS_NOT_PAYLIMIT, "Not meeting the recharge amount.", result: ipo.ProcessData.SigninConfigEo.SigninPayAmount.AToM(ipo.ProcessData.CurrencyId));
                    }
                }
                else
                {
                    return ret;
                }
            }


            //当天不允许签到
            if (!ipo.ProcessData.IsSignin)
            {
                return ret;
            }


            //签到周期内每一天对应的配置 key=签到序号 value=签到奖励+签到配置
            var signinOddsEoListDic = ipo.ProcessData.SigninOddsEoList
                                            .OrderBy(d => d.DateNumber)
                                            .GroupBy(d => d.DateNumber)
                                            .ToDictionary(
                                                            d => d.Key,
                                                            d => d.OrderByDescending(d => d.Bonus).ToList()
                                            );

            var tm = new DbTransactionManager();

            var currencyChangeService = new CurrencyChange2Service(ipo.UserId);

            try
            {
                tm.Begin();

                //签到日对应的配置
                var signinOddsEoList = signinOddsEoListDic.ElementAt(ipo.DateNumber - 1).Value;

                if (!signinOddsEoList.Any(d => d.Odds > 0))
                    throw new Exception("Configuration exception, unable to sign in, all weights are 0");

                //流水倍数
                var flowMultip = 0F;
                //中奖几率随机数
                var random = RandomUtil.NextInt(1, signinOddsEoList.Sum(d => d.Odds) + 1);
                var startNum = 1;
                foreach (var item in signinOddsEoList)
                {
                    if (item.Odds == 0)
                        continue;
                    if (random >= startNum && random <= (item.Odds + startNum - 1))
                    {
                        ret.RewardAmount = item.Bonus.AToM(item.CurrencyID);
                        flowMultip = item.FlowMultip;
                        break;
                    }
                    startNum += item.Odds;
                }

                //配置异常，奖励金额为0
                if (ret.RewardAmount == 0)
                    throw new CustomException("sa_signin100012_config Configuration exception.");

                await tm.GetRepository<Sa_signin101004_detailPO>().InsertAsync(new Sa_signin101004_detailPO()
                {
                    DayId = signinDate,
                    UserID = ipo.UserId,
                    OperatorID = ipo.ProcessData.OperatorId,
                    CurrencyID = ipo.ProcessData.CurrencyId,
                    UserKind = 1,
                    CurrentCycleNumber = ipo.DateNumber,
                    Bonus = ret.RewardAmount.MToA(ipo.CurrencyId),
                    FlowMultip = flowMultip,
                    SigninCycleStartDate = ipo.ProcessData.SigninCycleStartDate,
                    SigninCycleEndDate = ipo.ProcessData.SigninCycleEndDate,
                    RecDate = DateTime.UtcNow
                });

                var currencyChangeReq = new CurrencyChangeReq()
                {
                    UserId = ipo.UserId,
                    AppId = ipo.AppId,
                    OperatorId = ipo.OperatorId,
                    CurrencyId = ipo.CurrencyId,
                    Reason = "1.8签到",
                    Amount = ret.RewardAmount.MToA(ipo.CurrencyId),
                    SourceType = (int)ActivityType.Signin101004,
                    SourceTable = "signin_reward_detail",
                    SourceId = $"{signinDate}|{ipo.UserId}",
                    ChangeTime = DateTime.UtcNow,
                    ChangeBalance = CurrencyChangeBalance.Bonus,
                    FlowMultip = flowMultip,
                    DbTM = tm
                };

                //5、写s_currency_change
                var changeMsg = await currencyChangeService.Add(currencyChangeReq);
                if (changeMsg == null)
                    throw new Exception("写入s_currency_change失败");

                tm.Commit();
                ret.Status = true;

                await MQUtil.PublishAsync(changeMsg);

                await MQUtil.PublishAsync(new UserActivityMsg()
                {
                    UserId = ipo.UserId,
                    ActivityType = (int)ActivityType.Signin101004
                });

                return ret;
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.GetContextLogger().AddException(ex).AddMessage($"SignInController.Execute.ipo:{JsonConvert.SerializeObject(ipo)}");
                ret.RewardAmount = 0;
                return ret;
            }
        }

        /// <summary>
        /// 是否充值签到周期
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<bool> IsReset(SigninLoadIpo ipo)
        {
            var ret = false;
            //1、用户没有签到数据
            if (ipo.ProcessData.UserLastDetailEo == null)
                return true;

            //2、不包含昨天、今天签到记录
            if (!ipo.ProcessData.UserLastDetailEoList.Any(d => d.DayId == ipo.ProcessData.CurrentDate.AddDays(-1))
                && !ipo.ProcessData.UserLastDetailEoList.Any(d => d.DayId == ipo.ProcessData.CurrentDate)
                )
                ret = true;

            if (ret)
            {
                //计算当日是否被重置
                var signinDayResetRecordDCache = new SigninDayResetRecordDCache(ipo.ProcessData.CurrentDate, ipo.UserId);
                if (!await signinDayResetRecordDCache.GetAsync())
                {
                    ret = false;
                    await signinDayResetRecordDCache.SetAsync();
                }
            }

            return ret;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<SigninLoadDto> ResetExcute(SigninLoadIpo ipo)
        {
            var ret = new SigninLoadDto();
            ret.IsSignin = ipo.ProcessData.IsSignin;
            ret.SigninPayAmount = ipo.ProcessData.SigninConfigEo.SigninPayAmount.AToM(ipo.CurrencyId);
            ret.SumBonus = ipo.ProcessData.SumBonus;
            ret.AllowSumBonus = ipo.ProcessData.SumBonus - ipo.ProcessData.UserLastDetailEoList.Sum(d => d.Bonus).AToM(ipo.CurrencyId);
            ret.ServerTime = $"服务器时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.UtcTime = $"UTC时间：{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.LocalTime = $"运营商当地时间：{ipo.ProcessData.UtcTime.ToLocalTime(ipo.OperatorId).ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.SigninCycleStartDate = $"本次签到周期起始日期：{ipo.ProcessData.SigninCycleStartDate.ToString("yyyy-MM-dd")}";
            ret.SigninCycleEndDate = $"本次签到周期截止日期：{ipo.ProcessData.SigninCycleEndDate.ToString("yyyy-MM-dd")}";

            var signinConfigEoList = ipo.ProcessData.SigninOddsEoList
                                                .OrderBy(d => d.DateNumber)
                                                .GroupBy(d => d.DateNumber)
                                                .ToDictionary(
                                                                d => d.Key,
                                                                d => d.OrderByDescending(d => d.Bonus).FirstOrDefault()
                                                );

            var timeNow = ipo.ProcessData.CurrentDate.Date;

            var index = 1;
            foreach (var item in signinConfigEoList)
            {
                ret.Items.Add(new UserSignDetails()
                {
                    UserId = ipo.UserId,
                    IsSelected = timeNow == ipo.ProcessData.CurrentDate,
                    DayId = timeNow.ToString("yyyy-MM-dd"),
                    Reward = item.Value.Bonus.AToM(item.Value.CurrencyID),
                    RewardShowType = item.Value.BonusShowType,
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
        public async Task<SigninLoadDto> MainExcute(SigninLoadIpo ipo)
        {
            var ret = new SigninLoadDto();
            ret.IsSignin = ipo.ProcessData.IsSignin;
            ret.SigninPayAmount = ipo.ProcessData.SigninConfigEo.SigninPayAmount.AToM(ipo.CurrencyId);
            ret.SigninTimes = ipo.ProcessData.UserLastDetailEoList.Count();
            ret.PreSigninDate = ipo.ProcessData.UserLastDetailEo?.DayId.ToString("yyyy-MM-dd");
            ret.SumBonus = ipo.ProcessData.SumBonus;
            ret.AllowSumBonus = ipo.ProcessData.SumBonus - ipo.ProcessData.UserLastDetailEoList.Sum(d => d.Bonus).AToM(ipo.CurrencyId);
            ret.ServerTime = $"服务器时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.UtcTime = $"UTC时间：{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.LocalTime = $"运营商当地时间：{ipo.ProcessData.UtcTime.ToLocalTime(ipo.OperatorId).ToString("yyyy-MM-dd HH:mm:ss")}";
            ret.SigninCycleStartDate = $"本次签到周期起始日期：{ipo.ProcessData.SigninCycleStartDate.ToString("yyyy-MM-dd")}";
            ret.SigninCycleEndDate = $"本次签到周期截止日期：{ipo.ProcessData.SigninCycleEndDate.ToString("yyyy-MM-dd")}";

            //获取签到周期内，每一天奖励值最高的配置数据集合
            var signinOddsEoList = ipo.ProcessData.SigninOddsEoList
                                                .OrderBy(d => d.DateNumber)
                                                .GroupBy(d => d.DateNumber)
                                                .ToDictionary(
                                                                d => d.Key,
                                                                d => d.OrderByDescending(d => d.Bonus).ToList().FirstOrDefault()
                                                );
            //签到状态
            var signinStatus = SigninStatus.None;
            //当前周期内可签到日期
            var timeNow = ipo.ProcessData.SigninCycleStartDate.Date;
            //当前周期签到明细
            Sa_signin101004_detailPO rewardDetail = null;
            //当前周期签到日期对应的奖励配置
            Sa_signin101004_oddsPO signinConfigEo = null;
            for (int i = 0; i < ipo.ProcessData.SigninCycle; i++)
            {
                //当前周期签到明细
                rewardDetail = ipo.ProcessData.UserLastDetailEoList.Where(d => d.DayId == timeNow).FirstOrDefault();

                if (timeNow > ipo.ProcessData.CurrentDate.Date)
                    signinStatus = SigninStatus.NoAllow;
                else if (timeNow == ipo.ProcessData.CurrentDate.Date)
                    signinStatus = rewardDetail == null ? SigninStatus.Allow : SigninStatus.Signined;
                else
                    signinStatus = rewardDetail == null ? SigninStatus.MissSignin : SigninStatus.Signined;

                //当前周期签到日期对应的奖励配置
                signinConfigEo = signinOddsEoList.ElementAt(i).Value;
                ret.Items.Add(new UserSignDetails()
                {
                    UserId = ipo.UserId,
                    IsSelected = timeNow == ipo.ProcessData.CurrentDate,
                    DayId = timeNow.ToString("yyyy-MM-dd"),
                    DateNumber = i + 1,
                    Reward = rewardDetail != null ? rewardDetail.Bonus.AToM(ipo.CurrencyId) : signinConfigEo.Bonus.AToM(signinConfigEo.CurrencyID),
                    RewardShowType = signinConfigEo.BonusShowType,
                    RecDate = rewardDetail != null ? new DateTime(rewardDetail.RecDate.Ticks, DateTimeKind.Utc) : null,
                    Status = (int)signinStatus
                });
                //可签到日期 + 1
                timeNow = timeNow.AddDays(1);
            }

            if (ret.Items != null && ret.Items.Any(d => d.Status == (int)SigninStatus.MissSignin))
                ret.IsTipReset = true;

            if (ret.IsTipReset)
            {
                foreach (var item in ret.Items.Where(d => d.Status == (int)SigninStatus.MissSignin).ToList())
                {
                    ret.MissSigninDays.Add(item.DayId);
                }
            }

            return ret;
        }


        /// <summary>
        /// 签到过程中的数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isSignin">签到、加载</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task<SigninProcessData> GetProcessData(string userId, bool isSignin = false)
        {
            var globalUserDCache = await GlobalUserDCache.Create(userId);
            var processData = new SigninProcessData();
            //运营商编码
            processData.OperatorId = await globalUserDCache.GetOperatorIdAsync();
            //货币编码
            processData.CurrencyId = await globalUserDCache.GetCurrencyIdAsync();
            //签到概率配置List
            processData.SigninOddsEoList = SigninDbCachingUtil.GetSignin101004OddsList(processData.OperatorId, processData.CurrencyId);

            if (processData.SigninOddsEoList == null || !processData.SigninOddsEoList.Any())
                throw new CustomException($"odds is missing configuration.{processData.OperatorId}|{processData.CurrencyId}");

            var everyDayMaxBonusDic = processData.SigninOddsEoList.GroupBy(d => d.DateNumber).ToDictionary(d => d.Key, d => d.Max(d => d.Bonus));

            processData.SumBonus = everyDayMaxBonusDic.Values.Sum().AToM(processData.CurrencyId);
            //签到配置
            processData.SigninConfigEo = SigninDbCachingUtil.GetSignin101004ConfigSignle(processData.OperatorId, processData.CurrencyId);

            if (processData.SigninConfigEo == null)
                throw new CustomException($"config is missing configuration.{processData.OperatorId}|{processData.CurrencyId}");
            //签到周期
            processData.SigninCycle = processData.SigninOddsEoList.GroupBy(d => d.DateNumber).ToList().Count();
            //当前utc时间
            processData.UtcTime = DateTime.UtcNow;
            //当前日期
            processData.CurrentDate = processData.UtcTime.ToLocalTime(processData.OperatorId).Date;
            //当前周期起始日期
            processData.SigninCycleStartDate = processData.CurrentDate;
            //当前周期截止日期
            processData.SigninCycleEndDate = processData.CurrentDate.AddDays(processData.SigninCycle - 1).Date;
            //用户最后一次签到明细
            processData.UserLastDetailEo = await DbUtil.GetRepository<Sa_signin101004_detailPO>().AsQueryable()
                .Where(d => d.UserID.Equals(userId))
                .OrderByDescending(d => d.DayId)
                .FirstAsync();

            if (processData.UserLastDetailEo != null)
            {
                if (processData.UserLastDetailEo.DayId != processData.CurrentDate
                    && processData.UserLastDetailEo.DayId != processData.CurrentDate.AddDays(-1)
                    )
                {
                    //计算当日是否被重置
                    var signinDayResetRecordDCache = new SigninDayResetRecordDCache(processData.CurrentDate, userId);
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
            processData.UserLastDetailEoList = DbUtil.GetRepository<Sa_signin101004_detailPO>().AsQueryable()
                .Where(d => d.UserID.Equals(userId) && d.DayId >= processData.SigninCycleStartDate && d.DayId <= processData.SigninCycleEndDate)
                .ToList();

            //用户当天充值总金额
            processData.UserDaySumPayAmount = await SigninUtil.UserCurrentDaySumPay(userId, processData.OperatorId);
            //当天是否允许签到 = 当天充值总额 > 签到需要的充值金额
            processData.IsSignin = processData.UserDaySumPayAmount >= processData.SigninConfigEo.SigninPayAmount;

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
            var allActivityOperator = SigninDbCachingUtil.GetAllActivityOperator(operatorId, currencyId);

            if (allActivityOperator != null
                && allActivityOperator.Any()
                && allActivityOperator.Any(d => d.Status && d.ActivityID == (int)ActivityTypeEnum.Signin101004))
            {
                return true;
            }

            return false;
        }

    }
}
