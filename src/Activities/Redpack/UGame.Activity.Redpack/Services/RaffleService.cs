using UGame.Activity.Redpack.Extensions;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Redpack.Caching;
using UGame.Activity.Redpack.Models.Dtos;
using UGame.Activity.Redpack.Models.Ipos;
using UGame.Activity.Redpack.Repositories.sa;
using UGame.Activity.Redpack.Utilities;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Redpack.Services;

/// <summary>
/// 抽奖方法
/// </summary>
public class RaffleService
{
    /// <summary>
    /// 首开方法
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> FirstRaffle(ClientBaseIpo ipo, string userId)
    {
        var user = await GlobalUserDCache.Create(ipo.UserId);
        var currencyId = await user.GetCurrencyIdAsync();
        var fromId = await user.GetFromIdAsync();
        var fromMode = await user.GetFromModeAsync();
        var app = DbCacheUtil.GetApp(ipo.AppId, true, "");

        var taskConfigs = RedpackDbCacheUtil.GetAllRedpackTaskConfig(ipo.OperatorId);
        var config = RedpackDbCacheUtil.GetRedpackConfig(ipo.OperatorId);
        var ratio = RandomUtil.NextFloat(config.MinRatio, config.MaxRatio);
        var raffleAmount = (long)(config.PackAmount * ratio * 0.01);
        var nowTime = DateTime.UtcNow;
        var userPack = new Sa_redpack_user_packEO
        {
            PackID = ObjectId.NewId(),
            UserID = userId,
            ProviderID = app.ProviderID,
            AppID = ipo.AppId,
            OperatorID = ipo.OperatorId,
            FromMode = fromMode,
            FromId = fromId,
            UserKind = (int)UserKind.User,
            CountryID = ipo.CountryId,
            CurrencyID = currencyId,
            Expire = config.Expire,
            PackAmount = config.PackAmount,
            CurrAmount = raffleAmount,
            PackFlag = Random.Shared.Next(1, 4),
            RemainCount = 0,
            BetAmount = 0,
            RecDate = nowTime
        };
        var packNum = await new UserDCache(userId).GetUserPackNumAsync() + 1;
        var packNumList = taskConfigs.Select(w => w.PackNum).Distinct().OrderBy(num => num).ToList();
        var index = (int)Math.Min(packNum - 1, packNumList.Count - 1);
        int currPackNum = packNumList[index];
        var userTask = taskConfigs.Where(w => w.PackNum == currPackNum).Select(w => new Sa_redpack_user_taskEO
        {
            ConfigID = w.ConfigID,
            UserID = ipo.UserId,
            PackID = userPack.PackID,
            GroupId = w.GroupId,
            Ratio = w.Ratio,
            RemainAmount = w.TotalAmount,
            RemainCount = w.TotalCount,
            PayAmount = w.PayAmount,
            BetAmount = w.BetAmount,
            RecDate = nowTime
        });
        var tm = new TransactionManager();
        try
        {
            await new Sa_redpack_user_packMO().AddAsync(userPack, tm); // 抽次入库
            await new Sa_redpack_user_taskMO().AddByBatchAsync(userTask, 500, tm); // 首次入库用户任务表 
            tm.Commit();
            await new UserDCache(userId).Create(); // 初始化redis用户红包信息
            await new EffectiveDCache(ipo.UserId).SetAsync(userPack, true); // 初始化redis红包信息
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error("redpack first raffle error:{0}", ex.Message);
            return new RedpackRaffleDto
            {
                Amount = 0,
                PrizeAmount = 0,
                PackAmount = config.PackAmount.AToM(currencyId),
                RemainingNum = 0,
                PackFlag = userPack.PackFlag
            };
        }

        return new RedpackRaffleDto
        {
            Amount = raffleAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = raffleAmount.AToM(currencyId).MathTruncate(),
            PackAmount = config.PackAmount.AToM(currencyId),
            RemainingNum = 0,
            PackFlag = userPack.PackFlag
        };
    }

    /// <summary>
    /// 存在红包的情况下抽奖
    /// </summary>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> PacketRaffle(Sa_redpack_user_packEO redpack, Sa_redpack_user_pack_detailEO detail, string operatorId, string currencyId, string userId, DateTime localTime)
    {
        var tm = new TransactionManager();
        try
        {
            await new Sa_redpack_user_packMO().PutAsync($"CurrAmount=CurrAmount+{detail.Amount},RemainCount=RemainCount-1", $"PackID=@PackID", tm, redpack.PackID);
            await new Sa_redpack_user_pack_detailMO().PutAsync($"Status=1", $"DetailID=@DetailID", tm, detail.DetailID);
            await new EffectiveDCache(userId).RemainCountDecrementAsync(1);

            var currAmount = await new EffectiveDCache(userId).CurrAmountIncrementAsync(detail.Amount);
            var pack = await new EffectiveDCache(userId).GetFromRedisAsync();
            // 抽奖后的金额满足提现金额吗
            if (currAmount < pack.PackAmount)
            {
                tm.Commit();
                // 满足提现要求
                return new RedpackRaffleDto
                {
                    Amount = pack.CurrAmount.AToM(currencyId).MathTruncate(),
                    PrizeAmount = detail.Amount.AToM(currencyId).MathTruncate(),
                    PackAmount = pack.PackAmount.AToM(currencyId),
                    RemainingNum = pack.RemainCount,
                    PackFlag = pack.PackFlag,
                };
            }

            // 查看剩余红包
            var packPoolBo = await new PackPoolDetailDCache(operatorId, localTime).PackNumDecrementAsync(1);
            if (packPoolBo.packNum >= 0)
            {
                if (packPoolBo.bo != null)
                {
                    await new Sa_redpack_pack_pool_detailMO().PutAsync($"RemainPack=RemainPack-1", "OperatorID=@OperatorID AND StartTime=@StartTime AND RemainPack>0", redpack.OperatorID, packPoolBo.bo.StarTime);
                }

                tm.Commit();
                return new RedpackRaffleDto
                {
                    Amount = pack.PackAmount.AToM(currencyId).MathTruncate(),
                    PrizeAmount = detail.Amount.AToM(currencyId).MathTruncate(),
                    PackAmount = pack.PackAmount.AToM(currencyId),
                    RemainingNum = 0,
                    PackFlag = pack.PackFlag,
                };
            }

            tm.Commit();
            return new RedpackRaffleDto
            {
                Amount = pack.CurrAmount.AToM(currencyId).MathTruncate(),
                PrizeAmount = 0,
                PackAmount = pack.PackAmount.AToM(currencyId),
                RemainingNum = 0,
                PackFlag = pack.PackFlag,
            };
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack packet raffle:{ex.Message}");
            var pack = await new EffectiveDCache(userId).GetFromRedisAsync();
            return new RedpackRaffleDto
            {
                Amount = pack.CurrAmount.AToM(currencyId).MathTruncate(),
                PrizeAmount = 0,
                PackAmount = pack.PackAmount.AToM(currencyId),
                RemainingNum = 0,
                PackFlag = pack.PackFlag,
            };
        }
    }

    /// <summary>
    /// 抽bonus
    /// </summary>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> BonusRaffle(ClientBaseIpo ipo, Sa_redpack_user_packEO redpack, Sa_redpack_user_pack_detailEO detail, string operatorId, string currencyId, string userId, DateTime localTime)
    {
        var bonusWeights = RedpackDbCacheUtil.GetAllRedpackBonusWeightConfig(operatorId);
        var bonus = RedpackDbCacheUtil.GetBonusNextWeight(bonusWeights);

        var bonusCount = await DbSink.MainDb.ExecSqlScalarAsync<int>("SELECT IFNULL(SUM(Bonus),0) FROM sa_redpack_user_pack_detail WHERE PackID=@PackID AND Status=1", redpack.PackID);

        // 判断bonus不能大于配置的值,否则返回0
        var packConfig = RedpackDbCacheUtil.GetRedpackConfig(operatorId);
        var userBonus = bonusCount >= packConfig.PerIDMaxBonus ? 0 : bonus.Amount;

        if (userBonus == 0)
        {
            await new Sa_redpack_user_pack_detailMO().PutAsync($"Status=1,Amount=0,Bonus=0", $"DetailID=@DetailID", detail.DetailID);
            await new Sa_redpack_user_packMO().PutAsync($"RemainCount=RemainCount-1", $"PackID=@PackID", redpack.PackID);
            var remainCount = await new EffectiveDCache(userId).RemainCountDecrementAsync(1);
            return new RedpackRaffleDto
            {
                Amount = redpack.CurrAmount.AToM(currencyId).MathTruncate(),
                PrizeAmount = 0,
                PackAmount = redpack.PackAmount.AToM(currencyId),
                RemainingNum = (int)remainCount,
                PackFlag = redpack.PackFlag,
            };
        }

        var tm = new TransactionManager();
        try
        {
            var bonusBo = await new BonusPoolDetailDCache(operatorId, localTime).BonusDecrementAsync(userBonus);
            if (bonusBo.bonusNum == 0)
            {
                userBonus = 0;
            }
            await new Sa_redpack_user_pack_detailMO().PutAsync($"Status=1,Amount=0,Bonus={userBonus}", $"DetailID=@DetailID", tm, detail.DetailID);
            await new Sa_redpack_user_packMO().PutAsync($"RemainCount=RemainCount-1", $"PackID=@PackID", tm, redpack.PackID);
            CurrencyChangeMsg changeMsg = null;
            if (userBonus > 0)
            {
                if (bonusBo.bo != null)
                {
                    await new Sa_redpack_bonus_pool_detailMO().PutAsync($"RemainBonus=RemainBonus-{userBonus}", "OperatorID=@OperatorID AND StartTime=@StartTime", tm, redpack.OperatorID, bonusBo.bo.StarTime);
                }
                var config = RedpackDbCacheUtil.GetRedpackConfig(ipo.OperatorId);
                var currencyChangeSvc = new CurrencyChangeService(userId);

                changeMsg = await currencyChangeSvc.Add(new CurrencyChangeReq
                {
                    UserId = userId,
                    AppId = ipo.AppId,
                    UserIp = AspNetUtil.GetRemoteIpString(),
                    Amount = userBonus,

                    OperatorId = ipo.OperatorId,
                    ChangeTime = DateTime.UtcNow,
                    CurrencyId = ipo.CurrencyId,
                    FlowMultip = config.BonusFlowMultip,
                    ChangeBalance = CurrencyChangeBalance.Bonus,
                    Reason = "红包获取bonus",
                    SourceType = 800001,
                    SourceId = redpack.PackID,
                    SourceTable = "sa_redpack_user_pack_detail",
                    TM = tm
                });
            }

            tm.Commit();
            if (userBonus > 0 && changeMsg != null)
            {
                await MQUtil.PublishAsync(changeMsg);
            }

            await new EffectiveDCache(userId).RemainCountDecrementAsync(1);
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack bonus raffle:{ex.Message}");
        }

        var pack = await new EffectiveDCache(userId).GetFromRedisOrDBAsync();
        return new RedpackRaffleDto
        {
            Amount = pack.CurrAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = userBonus.AToM(currencyId).MathTruncate(),
            PackAmount = pack.PackAmount.AToM(currencyId),
            RemainingNum = pack.RemainCount,
            PackFlag = pack.PackFlag,
        };
    }

    /// <summary>
    /// 满足提现额度
    /// </summary>
    /// <param name="redpack"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> SatisfyWithdraw(Sa_redpack_user_packEO redpack, string currencyId)
    {
        return await Task.FromResult(new RedpackRaffleDto
        {
            Amount = redpack.PackAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = 0,
            PackAmount = redpack.PackAmount.AToM(currencyId),
            RemainingNum = 0,
            PackFlag = redpack.PackFlag,
        });
    }

    /// <summary>
    /// 没有中奖:没有红包，没有bonus
    /// </summary>
    /// <param name="redpack"></param>
    /// <param name="detail"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> NotDrawn(Sa_redpack_user_packEO redpack, Sa_redpack_user_pack_detailEO detail, string currencyId)
    {
        if (detail != null)
        {
            var tm = new TransactionManager();
            try
            {
                await new Sa_redpack_user_packMO().PutAsync($"RemainCount=RemainCount-1", $"PackID=@PackID", redpack.PackID);
                await new Sa_redpack_user_pack_detailMO().PutAsync($"Status=1,Bonus=0,Amount=0", $"DetailID=@DetailID", detail.DetailID);
                tm.Commit();
                await new EffectiveDCache(redpack.UserID).RemainCountDecrementAsync(1);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error("redpack not drawn:{0}", ex.Message);
            }
        }

        var packInfo = await new EffectiveDCache(redpack.UserID).GetFromRedisOrDBAsync();
        return new RedpackRaffleDto
        {
            Amount = packInfo.CurrAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = 0,
            PackAmount = packInfo.PackAmount.AToM(currencyId),
            RemainingNum = packInfo.RemainCount,
            PackFlag = packInfo.PackFlag,
        };
    }
}
