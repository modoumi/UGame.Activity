using SActivity.Common.Enums;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Collections;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Randoms;
using TinyFx.Text;
using UGame.Activity.DailyWheel.Caching;
using UGame.Activity.DailyWheel.Models;
using UGame.Activity.DailyWheel.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.DailyWheel.Services
{
    /// <summary>
    /// 每日转盘服务
    /// </summary>
    public class DailyWheelServices
    {
        private readonly Repository<L_activity_operatorPO> _activityRepository;

        private readonly Repository<Sa_dailywheel_userPO> _wheelUserRepository;
        private readonly Repository<Sa_dailywheel_detailPO> _wheelDetailRepository;

        private readonly WeightRandomProvider<Sa_dailywheel_weightPO> _weightProvider;

        private readonly object _sync;

        /// <summary>
        /// 
        /// </summary>
        public DailyWheelServices()
        {
            _activityRepository = DbUtil.GetRepository<L_activity_operatorPO>();

            _wheelUserRepository = DbUtil.GetRepository<Sa_dailywheel_userPO>();
            _wheelDetailRepository = DbUtil.GetRepository<Sa_dailywheel_detailPO>();

            _weightProvider = new WeightRandomProvider<Sa_dailywheel_weightPO>();
            _sync = new();
        }

        /// <summary>
        /// 加载抽奖活动状态
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<DailyWheelLoadDto> LoadAsync(DailyWheelIpo ipo)
        {
            using var lockObj = await RedisUtil.LockAsync($"DailyWheel.Load.{ipo.UserId}", 20);
            if (!lockObj.IsLocked)
            {
                lockObj.Release();
                throw new CustomException(CommonCodes.UserConcurrent, $"activity:LoadAsync:Request for lock failed.Key:DailyWheel.Load.{ipo.UserId}");
            }

            var wheelConfigDCache = new DailywheelConfigDCache(ipo.OperatorId);
            var wheelConfig = await wheelConfigDCache.GetAsync();
            if (wheelConfig == default || wheelConfig.StatisticsDate.Date == default || wheelConfig.ResetTime == default)
            {
                return new DailyWheelLoadDto();
                //throw new CustomException($"wheel_Config or statisticsDate or resetTime not allow null!");
            }

            var wheelUser = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == ipo.UserId).FirstAsync();

            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            var hasPay = await userDCache.GetHasPayAsync();

            var localCurrentDate = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
            var statisticsDate = wheelConfig.StatisticsDate.Date;
            if (hasPay && localCurrentDate > statisticsDate)
            {
                var addAmount = 0f;
                var lastDateTime = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
                for (int i = 1; i <= 15; i++)
                {
                    lastDateTime = lastDateTime.AddDays(-1);
                    var dayUserDCache = await DayUserDCache.Create(lastDateTime, ipo.UserId);
                    var keyIsExist = await dayUserDCache.KeyExistsAsync();
                    if (lastDateTime < statisticsDate) break;

                    if (keyIsExist)
                    {
                        var (payAmount, loseAmount) = await GetUserLoseAmount(lastDateTime, ipo.UserId);
                        addAmount = Math.Abs(loseAmount) > 0 ? Math.Abs(loseAmount) * wheelConfig.PotRate : 0;
                        break;
                    }
                }

                if (wheelUser == default && wheelConfig != null)
                {
                    await InitUserReward(ipo, wheelConfig.DefaultPot, wheelConfig.MaxPot, (long)addAmount);
                }
                else if (addAmount > 0 && (lastDateTime > wheelUser?.LastPlayDate) || wheelUser?.LastPlayDate is null)
                {
                    var totalAmount = (wheelUser?.PotAmount + addAmount) > wheelConfig.MaxPot ? wheelConfig.MaxPot : wheelUser.PotAmount + addAmount;
                    wheelUser.LastPlayDate = lastDateTime;
                    wheelUser.PotAmount = (long)totalAmount;
                    _wheelUserRepository.Update(wheelUser);
                }
            }
            else
            {
                if (wheelUser == default && wheelConfig != null)
                    await InitUserReward(ipo, wheelConfig.DefaultPot, wheelConfig.MaxPot, 0);
            }

            var result = new DailyWheelLoadDto();
            await ResetPlayNumbers(ipo.UserId, ipo.OperatorId);
            result.NextBeginTime = await NextBeginTime(ipo.OperatorId);
            result.LotteryNumbers = await GetLotteryNumbers(ipo.UserId);
            return result;
        }

        /// <summary>
        /// 抽奖
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<DailyWheelResultDto> RaffleAsync(DailyWheelIpo ipo)
        {
            using var lockObj = await RedisUtil.LockAsync($"DailyWheel.{ipo.UserId}", 20);
            if (!lockObj.IsLocked)
            {
                lockObj.Release();
                throw new CustomException(CommonCodes.UserConcurrent, $"activity:RaffleAsync:Request for lock failed.Key:DailyWheel.{ipo.UserId}");
            }

            var activity = await _activityRepository.AsQueryable()
                .Where(_ => _.OperatorID == ipo.OperatorId && _.CurrencyID == ipo.CurrencyId && _.ActivityID == (int)ActivityType.DailyWheel)
                .FirstAsync();

            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            ipo.CountryId = await userDCache.GetCountryIdAsync();
            ipo.CurrencyId = await userDCache.GetCurrencyIdAsync();
            ipo.OperatorId = await userDCache.GetOperatorIdAsync();

            var hasPay = await userDCache.GetHasPayAsync();

            var result = new DailyWheelResultDto();

            //获取每日轮盘配置            
            var wheelConfigDCache = new DailywheelConfigDCache(ipo.OperatorId);
            var wheelConfig = await wheelConfigDCache.GetAsync();

            //活动已下架或过期
            if (activity == null || !activity.Status || wheelConfig.Status == 0)
                throw new CustomException(ActivityCodes.RS_ACTIVITY_EXPIRED);


            //检查防刷规则
            await AntiCheating(ipo, wheelConfig.IPLimit, wheelConfig.DeviceIdLimit);

            //获取每日轮盘权重
            var weightDCache = new DailywheelWeightDCache(ipo.OperatorId);
            var dailWheelWeight = await weightDCache.GetAsync();

            //用户奖池 
            var userPotInfo = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == ipo.UserId).FirstAsync();

            if (userPotInfo.PlayNums <= 0)
                throw new CustomException($"no play number");

            var isHasPay = hasPay ? 1 : 0;
            var weightGroup = dailWheelWeight.Where(_ => _.WeightGroup == isHasPay).ToList();
            //计算权重及奖励
            var weightInfo = GetWheelWeight(weightGroup);

            //计算转盘区间及位置,如果不存在，则给默认值
            var (position, reward) = await GetWeightPositionAsync(ipo.OperatorId, weightInfo.Reward, wheelConfig.MinReward);

            //发起抽奖奖励
            DbTransactionManager tm = new();
            try
            {
                tm.Begin();
                var userDetailInfo = new Sa_dailywheel_detailPO
                {
                    DetailID = ObjectId.NewId(),
                    UserID = ipo.UserId,
                    OperatorID = ipo.OperatorId,
                    Position = position,
                    PlanReward = weightInfo.Reward,
                    RewardAmount = userPotInfo.PotAmount == 0 ? wheelConfig.MinReward : userPotInfo.PotAmount - reward <= 0 ? userPotInfo.PotAmount : reward,
                    BeforePot = userPotInfo.PotAmount,
                    AfterPot = (userPotInfo.PotAmount - weightInfo.Reward) <= 0 ? 0 : userPotInfo.PotAmount - reward,
                    IP = AspNetUtil.GetRemoteIpString(),
                    DeviceId = ipo?.DeviceId,
                    RecDate = DateTime.UtcNow
                };
                userDetailInfo.RewardAmount = Math.Round(userDetailInfo.RewardAmount.AToM(ipo.CurrencyId), 2, MidpointRounding.ToZero).MToA(ipo.CurrencyId);
                await tm.GetRepository<Sa_dailywheel_detailPO>().InsertAsync(userDetailInfo);

                userPotInfo.PotAmount = (userPotInfo.PotAmount - weightInfo.Reward) > 0 ? userPotInfo.PotAmount - weightInfo.Reward : 0;

                userPotInfo.PlayNums -= 1;
                await tm.GetRepository<Sa_dailywheel_userPO>().UpdateAsync(userPotInfo);

                result.NextBeginTime = await NextBeginTime(ipo.OperatorId);
                result.Position = position;
                result.Bonus = userDetailInfo.RewardAmount.AToM(ipo.CurrencyId);
                result.LotteryNumbers = userPotInfo.PlayNums;

                var currencyChangeService = new CurrencyChange2Service(ipo.UserId);

                //2、写入货币变化
                var currencyChangeReq = new CurrencyChangeReq()
                {
                    UserId = ipo.UserId,
                    AppId = ipo.AppId,
                    OperatorId = ipo.OperatorId,
                    CurrencyId = ipo.CurrencyId,
                    Reason = "1.9版本每日抽奖",
                    Amount = Math.Abs(userDetailInfo.RewardAmount),
                    SourceType = (int)ActivityType.DailyWheel,
                    SourceTable = "sa_dailywheel_detail",
                    SourceId = ipo.UserId,
                    ChangeTime = DateTime.UtcNow,
                    ChangeBalance = CurrencyChangeBalance.Bonus,
                    FlowMultip = wheelConfig.FlowMultip,
                    DbTM = tm
                };

                //3、写s_currency_change
                var changeMsg = await currencyChangeService.Add(currencyChangeReq);

                tm.Commit();

                var positionDCache = new DailywheelPositionDCache(ipo.OperatorId);
                var positionInfoList = await positionDCache.GetAsync();
                if (positionInfoList.Any())
                {
                    positionInfoList.Reverse();
                    await positionDCache.SetAsync(positionInfoList);
                }

                await MQUtil.PublishAsync(changeMsg);

                await MQUtil.PublishAsync(new UserActivityMsg()
                {
                    UserId = ipo.UserId,
                    ActivityType = (int)ActivityType.DailyWheel
                });
            }
            catch (Exception ex)
            {
                tm.Rollback();
                throw new CustomException(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 初始化用户奖池
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="addAmount">累计金额</param>
        /// <returns></returns>
        private async Task<bool> InitUserReward(DailyWheelIpo ipo, long defaultValue, long maxValue, long addAmount)
        {
            //判断累计金额是否超过最大值
            //超过最大值则给最大值
            var totalAmount = (defaultValue + addAmount) > maxValue ? maxValue : defaultValue + addAmount;

            var dailyWheelUser = new Sa_dailywheel_userPO
            {
                UserID = ipo.UserId,
                OperatorID = ipo.OperatorId,
                PotAmount = addAmount > 0 ? totalAmount : defaultValue,//累计金额大于0则累计，否则默认值
                PlayNums = 0,
                RecDate = DateTime.UtcNow,
            };
            return await _wheelUserRepository.InsertAsync(dailyWheelUser);
        }

        /// <summary>
        /// 获取用户抽奖剩余次数
        /// </summary>
        /// <returns></returns>
        private async Task<int> GetLotteryNumbers(string userId)
        {
            var wheel_user = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == userId).FirstAsync();
            return wheel_user.PlayNums;
        }

        /// <summary>
        /// 时间段内,重置抽奖次数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task ResetPlayNumbers(string userId, string operatorId)
        {
            var wheelUser = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == userId).FirstAsync();

            var userDCache = await GlobalUserDCache.Create(userId);
            var registerDate = await userDCache.GetRegistDateAsync();

            var wheelConfigDCache = new DailywheelConfigDCache(operatorId);
            var wheelConfig = await wheelConfigDCache.GetAsync();

            var userDetail = await _wheelDetailRepository.AsQueryable()
                .Where(_ => _.UserID == userId && _.OperatorID == operatorId && _.RecDate >= DateTime.UtcNow.Date)
                .ToListAsync();

            if (wheelConfig.ResetTime == default)
                throw new CustomException($"reset time is not null");

            var resetTime = wheelConfig.ResetTime.Split("|").ToList();
            var resetTimeList = new List<DateTime>();
            foreach (var item in resetTime)
            {
                if (string.IsNullOrEmpty(item)) throw new CustomException("reset time is not allow null");
                resetTimeList.Add(DateTime.UtcNow.Date.AddHours(int.Parse(item)));
            }
            resetTimeList.Sort();
            foreach (var item in resetTimeList)
            {
                var isExist = userDetail.Where(_ => _.RecDate >= item).Count();
                if (isExist > 0)
                    continue;
                else if (DateTime.UtcNow > item)
                {
                    wheelUser.PlayNums = 1;
                    await _wheelUserRepository.UpdateAsync(wheelUser);
                    break;
                }
            }
            if (registerDate == null) throw new CustomException($"user is not  register");

            if (registerDate.Value.Date == DateTime.UtcNow.Date && wheelUser.PlayNums == 0 && userDetail.Count == 0)
            {
                wheelUser.PlayNums = 1;
                await _wheelUserRepository.UpdateAsync(wheelUser);
            }
        }

        /// <summary>
        /// 检查防刷机制
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task AntiCheating(DailyWheelIpo ipo, int ipLimit, int deviceIdLimit)
        {
            var detail = await _wheelDetailRepository.AsQueryable()
                .Where(_ => _.RecDate >= DateTime.UtcNow.Date).ToListAsync();
            if (detail != default)
            {
                if (!string.IsNullOrEmpty(ipo.DeviceId))
                {
                    var deviceIdNumbers = detail.Where(_ => _.DeviceId == ipo.DeviceId).Count();
                    if (deviceIdNumbers >= deviceIdLimit)
                        throw new CustomException($"this deviceId is more then {deviceIdLimit}");
                }

                var ipNumbers = detail.Where(_ => _.IP == AspNetUtil.GetRemoteIpString()).Count();
                if (ipNumbers >= ipLimit)
                    throw new CustomException($"this ip is more then {deviceIdLimit}");
            }
        }

        /// <summary>
        /// 找奖励所在区间
        /// </summary>
        /// <param name="operatorId"></param>
        /// <param name="reward"></param>
        /// <param name="defaultMinReward"></param>
        /// <returns></returns>
        private async Task<(int position, long reward)> GetWeightPositionAsync(string operatorId, long reward, long defaultMinReward)
        {
            (int position, long reward) result = (0, 0);
            //判断权重值，所在区间
            var positionDCache = new DailywheelPositionDCache(operatorId);
            var positionInfo = await positionDCache.GetAsync();
            var rewardInfo = positionInfo.Where(_ => _.OperatorID == operatorId && reward >= _.MinReward && reward <= _.MaxReward).FirstOrDefault();
            if (rewardInfo != default)
            {
                result.position = rewardInfo.Position;
                result.reward = reward;
            }
            else //如果不存在则给默认最小值
            {
                var defaultRewardInfo = positionInfo
                        .Where(_ => _.OperatorID == operatorId && defaultMinReward >= _.MinReward && defaultMinReward <= _.MaxReward)
                        .FirstOrDefault();

                if (defaultRewardInfo == default)
                    throw new CustomException($"weight value is not exist config!");

                result.position = defaultRewardInfo.Position;
                result.reward = defaultMinReward;
            }

            return result;

        }

        /// <summary>
        /// 获取用户某一天充值真金、亏损真金
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<(long payAmount, long loseAmount)> GetUserLoseAmount(DateTime date, string userId)
        {
            (long payAmount, long loseAmount) result = (0, 0);

            var dayUserDCache = await DayUserDCache.Create(date, userId);
            result.payAmount = await dayUserDCache.GetPayAmount();

            //下注（真金+bonus）
            var betAmount = await dayUserDCache.GetBetAmount();
            //返奖（真金+bonus）
            var winAmount = await dayUserDCache.GetWinAmount();
            //bonus下注
            var winBonus = await dayUserDCache.GetWinBonus();
            //bonus返奖
            var betBonus = await dayUserDCache.GetBetBonus();
            //真金亏损金额
            var loseCashAmount = (winAmount - betAmount) - (winBonus - betBonus);

            if ((winAmount - betAmount) >= 0 && winBonus == 0 && betBonus == 0)
                result.loseAmount = 0;//没有损失真金    
            else if (loseCashAmount >= 0)
                result.loseAmount = 0;//没有损失真金    
            else
                result.loseAmount = loseCashAmount;//损失的真金
            return result;
        }

        /// <summary>
        /// 抽奖下次开始时间
        /// </summary>
        public async Task<DateTime> NextBeginTime(string operatorId)
        {
            var nextBeginTime = DateTime.UtcNow;
            var configDCache = new DailywheelConfigDCache(operatorId);
            var configInfo = await configDCache.GetAsync();

            var resetTime = configInfo.ResetTime?.Split("|").ToList();
            var resetTimeList = new List<DateTime>();
            foreach (var item in resetTime)
            {
                if (string.IsNullOrEmpty(item))
                    throw new CustomException($"reset time not allow null");

                resetTimeList.Add(DateTime.UtcNow.Date.AddHours(int.Parse(item.Trim())));
            }

            if (DateTime.UtcNow < resetTimeList.Min())
                return resetTimeList.Min();

            if (DateTime.UtcNow > resetTimeList.Max())
                return resetTimeList.Min().AddDays(1);

            while (DateTime.UtcNow < resetTimeList.Max())
            {
                nextBeginTime = resetTimeList.Max();
                resetTimeList.Remove(resetTimeList.Max());
            }
            return nextBeginTime;
        }

        /// <summary>
        /// 计算权重及奖励
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        private WeightRandomProvider<Sa_dailywheel_weightPO> GetWeight(List<Sa_dailywheel_weightPO> weight)
        {
            lock (_sync)
            {
                weight.ForEach(x => _weightProvider.AddItem(x.Weight, x));
            }
            return _weightProvider;
        }

        /// <summary>
        /// 计算权重及奖励
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private Sa_dailywheel_weightPO GetWheelWeight(List<Sa_dailywheel_weightPO> list)
        {
            return GetWeight(list).Next();
        }

    }
}
