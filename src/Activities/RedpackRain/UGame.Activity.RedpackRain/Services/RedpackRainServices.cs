using SActivity.Cupon.API.Models.Ipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Common.Caching;
using Xxyy.Common;
using TinyFx.DbCaching;
using TinyFx;
using TinyFx.Extensions.AutoMapper;
using TinyFx.AspNet;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Logging;
using TinyFx.Randoms;
using TinyFx.Text;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;
using Xxyy.DAL;
using UGame.Activity.RedpackRain.Caching;
using UGame.Activity.RedpackRain.Models.Ipos;
using UGame.Activity.RedpackRain.Repositories;

namespace UGame.Activity.RedpackRain.Services
{
    public class RedpackRainServices
    {
        /// <summary>
        /// 加载红包雨基础信息
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<LoadResponseDto> LoadAsync(LoadRequestIpo ipo)
        {
            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            string countryId = await userDCache.GetCountryIdAsync();
            string currencyId = await userDCache.GetCurrencyIdAsync();
            string operatorId = await userDCache.GetOperatorIdAsync();


            var configBasic = DbCachingUtil.GetSingle<Sa_redpackrain_configPO>(it => it.OperatorID, operatorId);
            var configTime = DbCachingUtil.GetList<Sa_redpackrain_timePO>(it => it.OperatorID, operatorId)
                .OrderBy(c => c.StartTime).ToList();

            //红包雨活动已经关闭或者未配置
            if (configBasic == null || configBasic.Status == 0 || configTime.Count() == 0)
            {
                // throw new CustomException("RS_REDPACKRAIN_CONFIG", $"Invalid status");
                return new LoadResponseDto() { Status = -2 };
            }

            var braDate = DateTime.UtcNow.ToLocalTimeByCountryId(countryId);
            //活动未到开启时间段
            var dtime = braDate.TimeOfDay;

            LoadResponseDto loadResponse = new LoadResponseDto();
            loadResponse.ListDate = configTime.Map<List<RedpackrainTimeBo>>();
            loadResponse.UserId = ipo.UserId;
            loadResponse.CountryId = countryId;
            loadResponse.OperatorId = operatorId;
            loadResponse.CurrencyId = currencyId;
            loadResponse.Status = 1;
            loadResponse.TIMESTAMP = (braDate).ToTimestamp(false, false);

            if (braDate.Day <= 7 || braDate.DayOfWeek == DayOfWeek.Friday || braDate.DayOfWeek == DayOfWeek.Saturday ||
                braDate.DayOfWeek == DayOfWeek.Sunday)
            {
                //通天的当前时间有没有
                if (configTime.Count(c => c.StartTime <= dtime && c.EndTime >= dtime && c.ModelID == 1) == 0)
                {
                    //同天的下一个时段
                    var nextTime = configTime.OrderBy(a => a.StartTime)
                        .FirstOrDefault(a => dtime < a.StartTime && a.ModelID == 1)?.StartTime;
                    if (nextTime == null)
                    {
                        //判断第二天是不是热门时间
                        if (braDate.AddDays(1).Day <= 7 || braDate.AddDays(1).DayOfWeek == DayOfWeek.Friday || braDate.AddDays(1).DayOfWeek == DayOfWeek.Saturday ||
                braDate.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                        {
                            nextTime = configTime.OrderBy(a => a.StartTime)
                                                   .FirstOrDefault(a => a.ModelID == 1)?.StartTime;
                        }
                        else
                        {
                            nextTime = configTime.OrderBy(a => a.StartTime)
                                                       .FirstOrDefault(a => a.ModelID == 2)?.StartTime;
                        }
                    }

                    loadResponse.NextStartTime = nextTime;
                    //throw new CustomException("RS_REDPACKRAIN_CONFIG", $"The activity has not reached the start time",
                    //    null, loadResponse);

                    loadResponse.Status = -3;
                }
                else
                {
                    loadResponse.CurrentTime = configTime.FirstOrDefault(c =>
                        c.StartTime <= dtime && c.EndTime >= dtime && c.ModelID == 1).Map<RedpackrainTimeBo>();
                }
                //loadResponse= configTime.FirstOrDefault(c => c.ModelID==1&& dtime>);
            }
            else
            {
                if (configTime.Count(c => c.StartTime <= dtime && c.EndTime >= dtime && c.ModelID == 2) == 0)
                {
                    var nextTime = configTime.OrderBy(a => a.StartTime)
                        .FirstOrDefault(a => dtime < a.StartTime && a.ModelID == 2)?.StartTime;
                    if (nextTime == null)
                    {
                        //常规时间
                        if (!(braDate.AddDays(1).Day <= 7 || braDate.AddDays(1).DayOfWeek == DayOfWeek.Friday || braDate.AddDays(1).DayOfWeek == DayOfWeek.Saturday ||
           braDate.AddDays(1).DayOfWeek == DayOfWeek.Sunday))
                        {
                            nextTime = configTime.OrderBy(a => a.StartTime)
                                                   .FirstOrDefault(a => a.ModelID == 2)?.StartTime;
                        }
                        else
                        {
                            nextTime = configTime.OrderBy(a => a.StartTime).FirstOrDefault(a => a.ModelID == 1)?.StartTime;
                        }

                    }

                    loadResponse.NextStartTime = nextTime;
                    //throw new CustomException("RS_REDPACKRAIN_CONFIG", $"The activity has not reached the start time",
                    //    null, loadResponse);
                    loadResponse.Status = -3;
                }
                else
                {
                    loadResponse.CurrentTime = configTime.FirstOrDefault(c =>
                        c.StartTime <= dtime && c.EndTime >= dtime && c.ModelID == 2).Map<RedpackrainTimeBo>();
                }
            }

            //用户未充值不能玩
            if (DbUtil.GetRepository<Sa_redpackrain_userPO>().Count(a => a.UserID == ipo.UserId) == 0)
            {
                loadResponse.HasPay = 0;
            }
            else
            {
                loadResponse.HasPay = 1;
            }
            if (loadResponse.Status == 1)
            {
                var recDate = DateTime.UtcNow;

                RedpackRainUserDCache redpackRainUserDCache = new RedpackRainUserDCache(ipo.UserId,
            recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date);

                var repackHistory = (await redpackRainUserDCache.GetOrLoadAsync(redpackRainUserDCache.GetField(loadResponse.OperatorId, 3,
                        loadResponse.CurrentTime.ModelID, loadResponse.CurrentTime.StartTime,
                        recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date)));
                if (repackHistory.HasValue)
                {
                    //同时段内领取过奖励
                    //throw new CustomException("RS_REDPACKRAIN_RECEIVE",
                    //    "You have already claimed the reward during this period");
                    loadResponse.Status = -4;
                    loadResponse.Amount = repackHistory.Value.Amount.AToM(loadResponse.CurrencyId).ToString("0.00");
                }

                if (redpackRainUserDCache.GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult().Count >=
            configBasic.MaxClaim && configBasic.MaxClaim != 0)
                {
                    //想同时段内领取过奖励
                    //throw new CustomException("RS_REDPACKRAIN_LIMIT",
                    //    "You can only claim it twice a day");
                    loadResponse.Status = -5;
                    loadResponse.Amount = "";
                }
            }

            return loadResponse;
        }

        /// <summary>
        /// 抽奖
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<RaffleResponseDto> RaffleAsync(RaffleRequestIpo ipo)
        {

            using var lockObj = await RedisUtil.LockAsync($"Activity:RedpackRain:Open:{ipo.UserId}", 30);
            if (!lockObj.IsLocked)
            {
                lockObj.Release();
                throw new CustomException(CommonCodes.UserConcurrent,
                    $"activity:RaffleAsync:Request for lock failed.Key:RedpackRain.{ipo.UserId}");
            }

            LoadResponseDto loadResponse = await LoadAsync(ipo.Map<LoadRequestIpo>());
            if (loadResponse.Status != 1 || loadResponse.HasPay == 0)
            {
                return new RaffleResponseDto() { Status = loadResponse.Status, HasPay = loadResponse.HasPay };
            }

            var recDate = DateTime.UtcNow;

            RedpackRainUserDCache redpackRainUserDCache = new RedpackRainUserDCache(ipo.UserId,
                recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date);

            //if ((await redpackRainUserDCache.GetOrLoadAsync(redpackRainUserDCache.GetField(loadResponse.OperatorId, 3,
            //        loadResponse.CurrentTime.ModelID, loadResponse.CurrentTime.StartTime,
            //        recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date))).HasValue)
            //{
            //    //同时段内领取过奖励
            //    //throw new CustomException("RS_REDPACKRAIN_RECEIVE",
            //    //    "You have already claimed the reward during this period");
            //    return new RaffleResponseDto() { Status = -4 };
            //}
            var redpackrainUser = DbUtil.GetRepository<Sa_redpackrain_userPO>().AsQueryable()
                .First(a => a.UserID == ipo.UserId);

            var configWeightList =
                DbCachingUtil.GetList<Sa_redpackrain_weightPO>(it => it.OperatorID, loadResponse.OperatorId);

            var configBasic =
                DbCachingUtil.GetSingle<Sa_redpackrain_configPO>(it => it.OperatorID, loadResponse.OperatorId);

            var configWeight = RedpackRainUtil.GetRedpackRainWeight(configWeightList);

            //if (redpackRainUserDCache.GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult().Count >=
            //    configBasic.MaxClaim && configBasic.MaxClaim != 0)
            //{
            //    //想同时段内领取过奖励
            //    //throw new CustomException("RS_REDPACKRAIN_LIMIT",
            //    //    "You can only claim it twice a day");
            //    return new RaffleResponseDto() { Status = -5 };
            //}

            //中奖金额
            var amount = Random.Shared.NextInt64(configWeight.MinAmount, configWeight.MaxAmount);

            if (amount > (configBasic.PersonalMaxReward * redpackrainUser.PotAmount))
            {
                amount = Convert.ToInt64(configBasic.PersonalMaxReward * redpackrainUser.PotAmount);
            }

            decimal realAmount =
                Math.Floor((decimal)amount.AToMByCountryId(loadResponse.CountryId) * 100) / 100; // 保留两位小数
            if (realAmount == 0)
            {
                realAmount = configBasic.PersonalMinReward.AToM(loadResponse.CurrencyId);
            }

            long realAmountLong = realAmount.MToA(loadResponse.CurrencyId);

            var tm = new DbTransactionManager();
            try
            {

                string detailId = ObjectId.NewId();
                await tm.BeginAsync();
                var redpackDetailRepository = tm.GetRepository<Sa_redpackrain_detailPO>();

                string ip = AspNetUtil.GetRemoteIpString();

                var redpackrainDetail = new Sa_redpackrain_detailPO()
                {
                    DetailID = detailId,
                    CountryID = loadResponse.CountryId,
                    CurrencyID = loadResponse.CurrencyId,
                    OperatorID = loadResponse.OperatorId,
                    BusCode = 3,
                    RecDate = recDate,
                    ThridId = detailId,
                    UserID = ipo.UserId,
                    Amount = realAmountLong,
                    IP = ip,
                    StartTime = loadResponse.CurrentTime.StartTime,
                    EndTime = loadResponse.CurrentTime.EndTime,
                    ModelID = loadResponse.CurrentTime.ModelID,
                    DayId = recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date,
                    Weight = configWeight.Weight,
                    MinAmount = configWeight.MinAmount,
                    MaxAmount = configWeight.MaxAmount,
                    FlowMultip = configBasic.FlowMultip,
                    IsBonus = configBasic.IsBonus
                };

                bool res1 = await redpackDetailRepository.InsertAsync(redpackrainDetail);

                var potAmount = DbUtil.GetRepository<Sa_redpackrain_userPO>().GetFirst(c =>
                          c.UserID == ipo.UserId && c.OperatorID == loadResponse.OperatorId).PotAmount;
                int res2 = 0;
                if (potAmount > 0)
                {

                    res2 = await tm.GetRepository<Sa_redpackrain_userPO>().AsUpdateable()
                       .SetColumns(it => it.PotAmount == it.PotAmount - realAmountLong)
                       .SetColumns(c => c.LastUpdateDate == recDate)
                       .Where(c =>
                           c.UserID == ipo.UserId && c.OperatorID == loadResponse.OperatorId &&
                           c.PotAmount >= realAmountLong)
                       .ExecuteCommandAsync();
                }
                else
                {
                    res2 = 1;
                }

                if (res1 && res2 > 0)
                {
                    var currencyService = new CurrencyChange2Service(ipo.UserId);
                    var currencyChangeReq = new CurrencyChangeReq();
                    currencyChangeReq.UserId = ipo.UserId;
                    currencyChangeReq.AppId = "lobby";
                    currencyChangeReq.OperatorId = loadResponse.OperatorId;
                    currencyChangeReq.CurrencyId = loadResponse.CurrencyId;
                    currencyChangeReq.UserIp = ip;
                    currencyChangeReq.Reason = $"红包雨活动";
                    currencyChangeReq.Amount = realAmountLong;
                    currencyChangeReq.SourceType = 101008;
                    currencyChangeReq.SourceTable = "sa_redpackrain_user";
                    currencyChangeReq.SourceId = detailId;
                    currencyChangeReq.ChangeTime = recDate;
                    currencyChangeReq.ChangeBalance = configBasic.IsBonus == 0
                        ? CurrencyChangeBalance.Cash
                        : CurrencyChangeBalance.Bonus;
                    currencyChangeReq.FlowMultip = configBasic.FlowMultip;
                    currencyChangeReq.DbTM = tm;

                    var changeMsg = await currencyService.Add(currencyChangeReq);

                    await tm.CommitAsync();

                    if (changeMsg != null)
                    {
                        await MQUtil.PublishAsync(changeMsg);
                    }

                    await redpackRainUserDCache.SetAsync(
                        redpackRainUserDCache.GetField(loadResponse.OperatorId, 3, loadResponse.CurrentTime.ModelID,
                            loadResponse.CurrentTime.StartTime,
                            recDate.ToLocalTimeByCountryId(loadResponse.CountryId).Date), redpackrainDetail);
                }
                else
                {
                    await tm.RollbackAsync();
                    throw new CustomException("RS_REDPACKRAIN_ERROR", $"try again");
                }

            }
            catch (Exception e)
            {
                await tm.RollbackAsync();
                LogUtil.Error(e, "RaffleAsync: " + e.Message);
                throw new CustomException("RS_REDPACKRAIN_ERROR", $"try again");
            }

            return new RaffleResponseDto() { Amount = realAmount.ToString("0.00"), Status = 1, HasPay = 1 };
        }
    }
}


/// <summary>
/// 
/// </summary>
public class RedpackRainUtil
{
    private static object _sync = new object();

    private static WeightRandomProvider<Sa_redpackrain_weightPO> _configWeight;
    private static WeightRandomProvider<Sa_redpackrain_weightPO> GetWeight(List<Sa_redpackrain_weightPO> bonus)
    {
        lock (_sync)
        {
            _configWeight = new WeightRandomProvider<Sa_redpackrain_weightPO>();
            bonus.ForEach(x => _configWeight.AddItem(x.Weight, x));
        }
        return _configWeight;
    }

    /// <summary>
    ///兑换码权重
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Sa_redpackrain_weightPO GetRedpackRainWeight(List<Sa_redpackrain_weightPO> list)
    {
        return GetWeight(list).Next();
    }
}
