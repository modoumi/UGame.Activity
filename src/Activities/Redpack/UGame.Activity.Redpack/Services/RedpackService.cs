using UGame.Activity.Redpack.Extensions;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Org.BouncyCastle.Utilities;
using UGame.Activity.Redpack.Caching;
using UGame.Activity.Redpack.Models;
using UGame.Activity.Redpack.Models.Dtos;
using UGame.Activity.Redpack.Models.Enums;
using UGame.Activity.Redpack.Models.Ipos;
using UGame.Activity.Redpack.Repositories.sa;
using UGame.Activity.Redpack.Utilities;

namespace UGame.Activity.Redpack.Services;

/// <summary>
/// 红包服务
/// </summary>
public class RedpackService
{
    /// <summary>
    /// 红包信息
    /// </summary> 
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> PackInfo(string userId)
    {
        // 是否存在有效红包
        var redpack = await new EffectiveDCache(userId).GetFromRedisOrDBAsync();
        var user = await GlobalUserDCache.Create(userId);
        var currencyId = await user.GetCurrencyIdAsync();
        var operatorId = await user.GetOperatorIdAsync();

        if (redpack == null) // 首开
        {
            var packConfig = RedpackDbCacheUtil.GetRedpackConfig(operatorId);
            return new RedpackRaffleDto
            {
                Amount = 0,
                PrizeAmount = 0,
                PackAmount = packConfig.PackAmount.AToM(currencyId),
                RemainingNum = 1,
            };
        }

        var localTime = DateTime.UtcNow.ToLocalTime(operatorId);
        await new PackPoolDetailDCache(operatorId, localTime).CreateAsync();
        await new BonusPoolDetailDCache(operatorId, localTime).CreateAsync();

        var pack = await new Sa_redpack_user_packMO().GetSingleAsync("PackID=@PackID ", redpack.PackID);
        return new RedpackRaffleDto
        {
            Amount = pack.CurrAmount >= pack.PackAmount ? pack.PackAmount.AToM(currencyId).MathTruncate() : pack.CurrAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = 0,
            PackAmount = pack.PackAmount.AToM(currencyId),
            RemainingNum = pack.RemainCount,
            PackFlag = pack.PackFlag,
            LastTime = (pack.RecDate.AddHours(pack.Expire) - DateTime.UtcNow).TotalSeconds,
        };
    }

    /// <summary>
    /// 用户抽奖
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<RedpackRaffleDto> Raffle(ClientBaseIpo ipo, string userId)
    {

        var redpack = await new EffectiveDCache(ipo.UserId).GetFromRedisOrDBAsync(); // 是否存在有效红包
        if (redpack == null) // 首开抽奖
        {
            return await new RaffleService().FirstRaffle(ipo, userId);
        }

        var user = await GlobalUserDCache.Create(userId);
        var currencyId = await user.GetCurrencyIdAsync();
        var operatorId = await user.GetOperatorIdAsync();

        var localTime = DateTime.UtcNow.ToLocalTime(operatorId);
        await new PackPoolDetailDCache(operatorId, localTime).CreateAsync();
        await new BonusPoolDetailDCache(operatorId, localTime).CreateAsync();

        var detailMo = new Sa_redpack_user_pack_detailMO();
        var detail = (await detailMo.GetTopSortAsync("PackID=@PackID AND Status=@Status", 1, "RAND()", redpack.PackID, (int)PackUseStatusEnums.UnUsed)).FirstOrDefault();

        var packNum = await new PackPoolDetailDCache(operatorId, localTime).GetPackNum();
        var bonusNum = await new BonusPoolDetailDCache(operatorId, localTime).GetBonusNum();

        if (redpack.CurrAmount >= redpack.PackAmount) //已经满足提现额度,直接返回对象
        {
            return await new RaffleService().SatisfyWithdraw(redpack, currencyId);
        }

        if (packNum == 0 && bonusNum == 0) // 红包数量和bonus数量为0,扣减次数,谢谢惠顾,
        {
            return await new RaffleService().NotDrawn(redpack, detail, currencyId);
        }

        if (packNum != 0 && detail != null) // 存在红包
        {
            return await new RaffleService().PacketRaffle(redpack, detail, operatorId, currencyId, userId, localTime);
        }

        if (bonusNum != 0 && detail != null) // 没有红包，只剩下存在bonus
        {
            return await new RaffleService().BonusRaffle(ipo, redpack, detail, operatorId, currencyId, userId, localTime);
        }

        var pack = await new Sa_redpack_user_packMO().GetSingleAsync("PackID=@PackID", redpack.PackID);
        return new RedpackRaffleDto
        {
            Amount = pack.CurrAmount.AToM(currencyId).MathTruncate(),
            PrizeAmount = detail == null ? 0 : detail.Amount.AToM(currencyId),
            PackAmount = pack.PackAmount.AToM(currencyId),
            RemainingNum = pack.RemainCount,
            PackFlag = pack.PackFlag,
        };
    }

    /// <summary>
    /// 真金申请退款
    /// </summary>
    /// <param name="ipo">前端公共参数</param>
    /// <param name="userId">当前用户主键</param>
    /// <returns></returns>
    public async Task<bool> CashWithdraw(ClientBaseIpo ipo, string userId)
    {
        // 有效红包
        var cachePack = await new EffectiveDCache(userId).GetFromRedisOrDBAsync();
        if (cachePack == null)
        {
            throw new CustomException(RedpackCodes.RS_NO_EFFECTIVE_PACK, "RS_NO_EFFECTIVE_PACK");
        }

        using var redlock = await RedisUtil.LockAsync($"lobby:Redpack:Withdraw:{userId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"redpack withdraw for lock failed.userId:{ipo.UserId}");
        }

        // 校验是否提现
        var redpack = await new Sa_redpack_user_packMO().GetSingleAsync("PackID=@PackID", cachePack.PackID);
        if (redpack.IsWidthdraw == 1)
        {
            throw new CustomException(RedpackCodes.RS_ALREADY_WITHDRAW, "RS_ALREADY_WITHDRAW");
        }

        // 未满足提现额度
        if (redpack.PackAmount > redpack.CurrAmount)
        {
            throw new CustomException(RedpackCodes.RS_MEET_REQUIREMENTS_WITHDRAW, "RS_MEET_REQUIREMENTS_WITHDRAW");
        }

        var user = await GlobalUserDCache.Create(userId);
        var operatorId = await user.GetOperatorIdAsync();
        var currencyId = await user.GetCurrencyIdAsync();
        var config = RedpackDbCacheUtil.GetRedpackConfig(ipo.OperatorId);
        var tm = new TransactionManager();
        try
        {
            var currencyService = new CurrencyChangeService(ipo.UserId);
            var currencyChangeReq = new CurrencyChangeReq
            {
                UserId = userId,
                AppId = ipo.AppId,
                OperatorId = operatorId,
                CurrencyId = currencyId,
                UserIp = AspNetUtil.GetRemoteIpString(),
                Reason = $"抽取红包送真金",
                Amount = redpack.PackAmount,
                SourceType = 800000,
                SourceTable = "sa_redpack_user_pack",
                SourceId = redpack.PackID,
                ChangeTime = DateTime.UtcNow,
                ChangeBalance = CurrencyChangeBalance.Cash,
                FlowMultip = config.CashFlowMultip,
                TM = tm
            };
            await new Sa_redpack_user_packMO().PutByPKAsync(redpack.PackID, "IsWidthdraw=1", tm); // 更新提现状态 
            //写入账号金额变化
            var changeMsg = await currencyService.Add(currencyChangeReq);
            tm.Commit();
            if (changeMsg != null)
            {
                await MQUtil.PublishAsync(changeMsg);
            }
            await new UserDCache(userId).UserPackNumIncrementAsync();
            await new EffectiveDCache(userId).KeyDeleteAsync(); // 红包过期，删除
            return true;
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack withdraw:{0}", ex.Message);
            return false;
        }
    }

    /// <summary>
    /// 获得红包的历史记录
    /// </summary>
    /// <returns></returns>
    public async Task<List<WithdrawRecordDto>> RedpackRecord(string userId)
    {
        var user = await GlobalUserDCache.Create(userId);
        var operatorId = await user.GetOperatorIdAsync();
        return await new PackRecordDCache(operatorId).GetFromRedisAsync();
    }

    /// <summary>
    /// 抽奖任务完成记录 - 当前红包的完成记录
    /// </summary>
    /// <returns></returns>
    public async Task<List<TaskRecordDto>> TaskRecord(string userId)
    {
        // 校验有效红包 
        var redpack = await new EffectiveDCache(userId).GetFromRedisOrDBAsync();

        if (redpack == null) return new List<TaskRecordDto>();

        // 获取任务完成记录
        var packID = redpack.PackID;
        var tasks = await new Sa_redpack_user_pack_detailMO().GetAsync("PackID=@PackID AND Status=@Status AND (Bonus!=0 || Amount!=0)", packID, (int)PackUseStatusEnums.Used);

        var user = await GlobalUserDCache.Create(userId);
        var currencyId = await user.GetCurrencyIdAsync();
        var operatorId = await user.GetOperatorIdAsync();

        var ret = new List<TaskRecordDto>();
        foreach (var task in tasks)
        {
            var taskRecord = new TaskRecordDto
            {
                TaskCategory = task.GroupId.ToEnum<TaskCategoryEnums>(),
                Bonus = task.Bonus.AToM(currencyId),
                Amount = task.Amount.AToM(currencyId),
                RecDate = task.RecDate.ToLocalTime(operatorId),
                PUserId = task.PUserID,
                PUserName = null,
                PNickName = null,
                PMobile = null,
            };

            if (!string.IsNullOrEmpty(task.PUserID))
            {
                var userInfo = await GlobalUserDCache.Create(task.PUserID);
                taskRecord.PUserName = await userInfo.GetUsernameAsync();
                taskRecord.PNickName = await userInfo.GetNicknameAsync();
                taskRecord.PMobile = await userInfo.GetMobileAsync();
            }
            ret.Add(taskRecord);
        }
        return ret.OrderByDescending(_ => _.RecDate).ToList();
    }

    /// <summary>
    /// 下载客户端
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <returns></returns> 
    public async Task DownApp(string userId)
    {
        // 是否存在有效红包 
        var redpack = await new EffectiveDCache(userId).GetFromRedisAsync();
        if (redpack == null) return;

        using var redlock = await RedisUtil.LockAsync($"lobby:Redpack:DownloadApp:{userId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"redpack download app for lock failed userId:{userId}");
        }

        // 是否还有抽奖机会
        var task = await new Sa_redpack_user_taskMO().GetAsync("PackID=@PackID AND GroupId=@GroupId AND RemainCount>0", redpack.PackID, (int)TaskCategoryEnums.DownloadApp);
        var remainCount = task.Sum(w => w.RemainCount);
        if (remainCount == 0) return;

        // 随机概率取 
        var weight = RedpackDbCacheUtil.GetUserTaskRatio(task);
        var amount = RandomUtil.NextAmount(0.01, weight.RemainAmount, weight.RemainCount, redpack.CurrencyID);

        var tm = new TransactionManager();
        try
        {
            await new Sa_redpack_user_taskMO().PutAsync($"RemainCount=RemainCount-1,RemainAmount=RemainAmount-{amount}", "PackId=@PackId AND ConfigID=@ConfigID", tm, redpack.PackID, weight.ConfigID);
            await new Sa_redpack_user_packMO().PutAsync($"RemainCount=RemainCount+1", "PackId=@PackId", tm, redpack.PackID);
            await new Sa_redpack_user_pack_detailMO().AddAsync(new Sa_redpack_user_pack_detailEO
            {
                DetailID = ObjectId.NewId(),
                PackID = redpack.PackID,
                UserID = userId,
                PUserID = string.Empty,
                GroupId = (int)TaskCategoryEnums.DownloadApp,
                Amount = amount,
                Bonus = 0,
                Status = (int)PackUseStatusEnums.UnUsed,
                RecDate = DateTime.UtcNow
            }, tm);
            tm.Commit();
            await new EffectiveDCache(userId).RemainCountIncrementAsync(1);
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack download app error:{ex.Message}");
        }
    }

    /// <summary>
    /// 分享
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <returns></returns>
    public async Task Share(string userId)
    {
        // 是否存在有效红包 
        var redpack = await new EffectiveDCache(userId).GetFromRedisAsync();
        if (redpack == null) return;

        using var redlock = await RedisUtil.LockAsync($"lobby:Redpack:Share:{userId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"redpack share for lock failed userId:{userId}");
        }

        // 是否还有抽奖机会
        var task = await new Sa_redpack_user_taskMO().GetAsync("PackID=@PackID AND GroupId=@GroupId AND RemainCount>0", redpack.PackID, (int)TaskCategoryEnums.Shared);
        var remainCount = task.Sum(w => w.RemainCount);
        if (remainCount == 0) return;

        // 随机概率取 
        var weight = RedpackDbCacheUtil.GetUserTaskRatio(task);
        var amount = RandomUtil.NextAmount(0.01, weight.RemainAmount, weight.RemainCount, redpack.CurrencyID);
        var tm = new TransactionManager();
        try
        {
            await new Sa_redpack_user_taskMO().PutAsync($"RemainCount=RemainCount-1,RemainAmount=RemainAmount-{amount}", "PackId=@PackId AND ConfigID=@ConfigID", tm, redpack.PackID, weight.ConfigID);
            await new Sa_redpack_user_packMO().PutAsync($"RemainCount=RemainCount+1", "PackId=@PackId", tm, redpack.PackID);
            await new Sa_redpack_user_pack_detailMO().AddAsync(new Sa_redpack_user_pack_detailEO
            {
                DetailID = ObjectId.NewId(),
                PackID = redpack.PackID,
                UserID = userId,
                PUserID = string.Empty,
                GroupId = (int)TaskCategoryEnums.Shared,
                Amount = amount,
                Bonus = 0,
                Status = (int)PackUseStatusEnums.UnUsed,
                RecDate = DateTime.UtcNow
            }, tm);
            tm.Commit();
            await new EffectiveDCache(userId).RemainCountIncrementAsync(1);
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack share error:{ex.Message}");
        }
    }
}
