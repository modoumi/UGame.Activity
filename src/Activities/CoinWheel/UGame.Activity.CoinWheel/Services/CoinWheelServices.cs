using SActivity.Common.Enums;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Randoms;
using TinyFx.Text;
using UGame.Activity.CoinWheel.Caching;
using UGame.Activity.CoinWheel.Models;
using UGame.Activity.CoinWheel.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.DAL;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.CoinWheel.Services;

/// <summary>
/// 积分转盘服务
/// </summary>
public class CoinWheelServices
{
    private readonly Repository<L_activity_operatorPO> _activityRepository;

    private readonly Repository<Sa_coinwheel_userPO> _wheelUserRepository;
    private readonly Repository<Sa_coinwheel_detailPO> _wheelDetailRepository;

    private readonly WeightRandomProvider<Sa_coinwheel_weightPO> _weightProvider;

    private readonly object _sync;

    /// <summary>
    /// 
    /// </summary>
    public CoinWheelServices()
    {
        _activityRepository = DbUtil.GetRepository<L_activity_operatorPO>();

        _wheelUserRepository = DbUtil.GetRepository<Sa_coinwheel_userPO>();
        _wheelDetailRepository = DbUtil.GetRepository<Sa_coinwheel_detailPO>();

        _weightProvider = new WeightRandomProvider<Sa_coinwheel_weightPO>();
        _sync = new();
    }

    /// <summary>
    /// 加载抽奖活动状态
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<CoinWheelLoadDto> LoadAsync(CoinWheelIpo ipo)
    {
        var result = new CoinWheelLoadDto();

        var wheelConfigDCache = new CoinWheelConfigDCache(ipo.OperatorId);
        var wheelConfig = await wheelConfigDCache.GetAsync();
        if (wheelConfig == default)
        {
            throw new CustomException($"coinwheel_Config  not allow null!");
        }

        var wheelUser = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == ipo.UserId).FirstAsync();

        var userDCache = await GlobalUserDCache.Create(ipo.UserId);

        var localCurrentDate = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;

        var lastDateTime = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;

        if (wheelUser == default && wheelConfig != null)
        {
            await InitUserReward(ipo, 0);
        }
        await ResetPlayNumbers(ipo.UserId, ipo.OperatorId);

        //后续从缓存取值
        var userInfo = await DbUtil.GetRepository<S_userPO>().AsQueryable()
            .Where(_ => _.UserID == ipo.UserId).FirstAsync();

        result.PlayNumbers = await GetPlayNumbers(ipo.UserId);
        result.ExtraCoin = wheelConfig.ExtraCoin.Value;
        result.TotalCoin = userInfo.Coin;
        return result;
    }

    /// <summary>
    /// 抽奖
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<CoinWheelResultDto> RaffleAsync(CoinWheelIpo ipo)
    {
        using var lockObj = await RedisUtil.LockAsync($"CoinWheel.{ipo.UserId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"activity:RaffleAsync:Request for lock failed.Key:CoinWheel.{ipo.UserId}");
        }

        var activity = await _activityRepository.AsQueryable()
            .Where(_ => _.OperatorID == ipo.OperatorId && _.CurrencyID == ipo.CurrencyId && _.ActivityID == (int)ActivityType.CoinWheel)
            .FirstAsync();

        var userDCache = await GlobalUserDCache.Create(ipo.UserId);
        ipo.CountryId = await userDCache.GetCountryIdAsync();
        ipo.CurrencyId = await userDCache.GetCurrencyIdAsync();
        ipo.OperatorId = await userDCache.GetOperatorIdAsync();

        var result = new CoinWheelResultDto();

        //获取每日轮盘配置            
        var wheelConfigDCache = new CoinWheelConfigDCache(ipo.OperatorId);
        var wheelConfig = await wheelConfigDCache.GetAsync();

        //活动已下架或过期
        if (activity == null || !activity.Status || wheelConfig == null || wheelConfig.Status == (int)WheelStatus.Invalid)
            throw new CustomException(ActivityCodes.RS_ACTIVITY_EXPIRED);

        //获取每日轮盘权重
        var weightDCache = new CoinWheelWeightDCache(ipo.OperatorId);
        var wheelWeight = await weightDCache.GetAsync();

        //用户奖池 
        var userPotInfo = await _wheelUserRepository.AsQueryable().Where(_ => _.UserID == ipo.UserId).FirstAsync();
        var defaultPlayNum = userPotInfo.PlayNums;
        //后续从缓存取值
        var userInfo = await DbUtil.GetRepository<S_userPO>().AsQueryable()
            .Where(_ => _.UserID == ipo.UserId && _.OperatorID == ipo.OperatorId).FirstAsync();

        if (userPotInfo == default)
            throw new CustomException($"user is not init!");

        if (userPotInfo.PlayNums == 0 && userInfo.Coin < wheelConfig.ExtraCoin)
        {
            throw new CustomException($"coin is not enough!");
        }

        //奖池为0，只进行积分抽奖
        //奖池不为0时，只进行积分和奖励小于奖池的抽奖        
        wheelWeight = userPotInfo.PotAmount == 0 ? wheelWeight.Where(_ => _.RewardCurrency == 2).ToList()
            : wheelWeight.Where(_ => _.Reward <= userPotInfo.PotAmount || _.RewardCurrency == 2).ToList();

        //计算权重及奖励
        var weightInfo = GetWheelWeight(wheelWeight);

        //计算转盘区间及位置,如果不存在，则给默认值
        var (position, reward) = await GetWeightPositionAsync(ipo.OperatorId, weightInfo.Reward, 0);

        var currencyChangeReq2 = new CurrencyChangeReq();
        //发起抽奖奖励
        DbTransactionManager tm = new();
        try
        {
            tm.Begin();
            var userDetailInfo = new Sa_coinwheel_detailPO
            {
                DetailID = ObjectId.NewId(),
                UserID = ipo.UserId,
                OperatorID = ipo.OperatorId,
                Position = position,
                PlanReward = weightInfo.Reward,
                RewardAmount = reward,
                RewardCurrency = weightInfo.RewardCurrency,
                BeforePot = userPotInfo.PotAmount,
                AfterPot = weightInfo.RewardCurrency == (int)WheelEnums.Coin ? userPotInfo.PotAmount : (userPotInfo.PotAmount - weightInfo.Reward) <= 0 ? 0 : userPotInfo.PotAmount - reward,
                IP = AspNetUtil.GetRemoteIpString(),
                RecDate = DateTime.UtcNow
            };
            //如何是Bonus,需要扣奖池金额
            if (weightInfo.RewardCurrency == (int)WheelEnums.Bonus)
            {
                userDetailInfo.RewardAmount = Math.Round(userDetailInfo.RewardAmount.AToM(ipo.CurrencyId), 2, MidpointRounding.ToZero).MToA(ipo.CurrencyId);
                userPotInfo.PotAmount = (userPotInfo.PotAmount - weightInfo.Reward) > 0 ? userPotInfo.PotAmount - weightInfo.Reward : 0;
            }
            //如何是Cash,需要扣奖池金额
            else if (weightInfo.RewardCurrency == (int)WheelEnums.Cash)
            {
                userDetailInfo.RewardAmount = Math.Round(userDetailInfo.RewardAmount.AToM(ipo.CurrencyId), 2, MidpointRounding.ToZero).MToA(ipo.CurrencyId);
                userPotInfo.PotAmount = (userPotInfo.PotAmount - weightInfo.Reward) > 0 ? userPotInfo.PotAmount - weightInfo.Reward : 0;
            }

            await tm.GetRepository<Sa_coinwheel_detailPO>().InsertAsync(userDetailInfo);

            userPotInfo.PlayNums = userPotInfo.PlayNums == 0 ? 0 : userPotInfo.PlayNums - 1;
            await tm.GetRepository<Sa_coinwheel_userPO>().UpdateAsync(userPotInfo);

            result.Position = position;
            result.Reward = weightInfo.RewardCurrency == (int)WheelEnums.Coin ? userDetailInfo.RewardAmount : userDetailInfo.RewardAmount.AToM(ipo.CurrencyId);
            result.RewardType = weightInfo.RewardCurrency;
            result.PlayNumbers = userPotInfo.PlayNums;
            result.TotalCoin = userInfo.Coin;
            result.ExtraCoin = wheelConfig.ExtraCoin.Value;

            var currencyChangeService = new CurrencyChange2Service(ipo.UserId);

            var rewardAmount = 0L;
            if (weightInfo.RewardCurrency == (int)WheelEnums.Coin)
            {
                rewardAmount = defaultPlayNum > 0 ? userDetailInfo.RewardAmount : userDetailInfo.RewardAmount - wheelConfig.ExtraCoin.Value;
            }

            //2、写入货币变化
            var currencyChangeReq = new CurrencyChangeReq()
            {
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                OperatorId = ipo.OperatorId,
                CurrencyId = weightInfo.RewardCurrency == (int)WheelEnums.Coin ? "COIN" : ipo.CurrencyId,
                Reason = "2.0版本积分抽奖",
                Amount = weightInfo.RewardCurrency == (int)WheelEnums.Coin ? rewardAmount : Math.Abs(userDetailInfo.RewardAmount),
                SourceType = (int)ActivityType.CoinWheel,
                SourceTable = "sa_coinwheel_detail",
                SourceId = ipo.UserId,
                ChangeTime = DateTime.UtcNow,
                ChangeBalance = weightInfo.RewardCurrency == (int)WheelEnums.Coin ? CurrencyChangeBalance.None : weightInfo.RewardCurrency == (int)WheelEnums.Cash ? CurrencyChangeBalance.Cash : CurrencyChangeBalance.Bonus,
                FlowMultip = wheelConfig.FlowMultip,
                DbTM = tm
            };

            //3、写s_currency_change
            var changeMsg = await currencyChangeService.Add(currencyChangeReq);

            tm.Commit();
            currencyChangeReq2 = currencyChangeReq;
            var positionDCache = new CoinWheelPositionDCache(ipo.OperatorId);
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
                ActivityType = (int)ActivityType.CoinWheel
            });
        }
        catch (Exception ex)
        {
            tm.Rollback();
            throw new CustomException(ex.ToString());
        }

        //免费抽奖次数用完，如果用积分抽中bonus或者cash则需要扣积分
        if (weightInfo.RewardCurrency != (int)WheelEnums.Coin && defaultPlayNum <= 0)
        {
            await SubductsCoinOnBonus(ipo, currencyChangeReq2, wheelConfig.ExtraCoin.Value);
        }

        //后续从缓存取值
        var userInfoAfter = await DbUtil.GetRepository<S_userPO>().AsQueryable()
            .Where(_ => _.UserID == ipo.UserId && _.OperatorID == ipo.OperatorId).FirstAsync();
        result.TotalCoin = userInfoAfter.Coin;

        return result;
    }

    /// <summary>
    /// 扣除积分，当免费用完，用积分抽中Bonus时
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private async Task<int> SubductsCoinOnBonus(CoinWheelIpo ipo, CurrencyChangeReq currencyChangeReq, int extraCoin)
    {
        //发起抽奖奖励
        DbTransactionManager tm = new();
        try
        {
            tm.Begin();
            var currencyChangeService = new CurrencyChange2Service(ipo.UserId);

            //2、写入货币变化
            currencyChangeReq.CurrencyId = "COIN";
            currencyChangeReq.ChangeTime = DateTime.UtcNow;
            currencyChangeReq.Amount = -extraCoin;
            currencyChangeReq.ChangeBalance = CurrencyChangeBalance.None;
            currencyChangeReq.DbTM = tm;

            //3、写s_currency_change
            var changeMsg = await currencyChangeService.Add(currencyChangeReq);

            tm.Commit();

            var positionDCache = new CoinWheelPositionDCache(ipo.OperatorId);
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
                ActivityType = (int)ActivityType.CoinWheel
            });
        }
        catch (Exception ex)
        {
            tm.Rollback();
            throw new CustomException(ex.ToString());
        }
        return 1;
    }

    /// <summary>
    /// 初始化用户奖池
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="defaultValue">默认值</param>
    /// <param name="addAmount">累计金额</param>
    /// <returns></returns>
    private async Task<bool> InitUserReward(CoinWheelIpo ipo, long defaultValue)
    {
        var dailyWheelUser = new Sa_coinwheel_userPO
        {
            UserID = ipo.UserId,
            OperatorID = ipo.OperatorId,
            PotAmount = defaultValue,//累计金额大于0则累计，否则默认值
            PlayNums = 0,
            RecDate = DateTime.UtcNow,
        };
        return await _wheelUserRepository.InsertAsync(dailyWheelUser);
    }

    /// <summary>
    /// 获取用户抽奖剩余次数
    /// </summary>
    /// <returns></returns>
    private async Task<int> GetPlayNumbers(string userId)
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

        var wheelConfigDCache = new CoinWheelConfigDCache(operatorId);
        var wheelConfig = await wheelConfigDCache.GetAsync();

        var userDetail = await _wheelDetailRepository.AsQueryable()
            .Where(_ => _.UserID == userId && _.OperatorID == operatorId && _.RecDate >= DateTime.UtcNow.Date)
            .ToListAsync();

        if (wheelConfig.ResetTime == default || wheelConfig.OperatorID == null)
            throw new CustomException($"coinwheel_Config  not allow null");

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
            var isExistCount = userDetail.Where(_ => _.RecDate >= item).Count();
            if (isExistCount > 0 && wheelUser.PlayNums == 0)
            {
                if (isExistCount < wheelConfig.DailyFree)
                {
                    wheelUser.PlayNums = wheelConfig.DailyFree.Value - isExistCount;
                    await _wheelUserRepository.UpdateAsync(wheelUser);
                }
            }
            else if (DateTime.UtcNow > item)
            {
                wheelUser.PlayNums = wheelConfig.DailyFree.Value - isExistCount;
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
        var positionDCache = new CoinWheelPositionDCache(operatorId);
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
    /// 计算权重及奖励
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    private WeightRandomProvider<Sa_coinwheel_weightPO> GetWeight(List<Sa_coinwheel_weightPO> weight)
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
    private Sa_coinwheel_weightPO GetWheelWeight(List<Sa_coinwheel_weightPO> list)
    {
        return GetWeight(list).Next();
    }

}
