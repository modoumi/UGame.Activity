using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Redpack.Caching;
using UGame.Activity.Redpack.Models.Enums;
using UGame.Activity.Redpack.Repositories.sa;
using UGame.Activity.Redpack.Utilities;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Redpack.Consumers;

/// <summary>
/// 新用户注册
/// </summary>
public class UserRegisterConsumer : MQBizSubConsumer<UserRegisterMsg>
{
    /// <summary>
    /// 用户注册
    /// </summary>
    public UserRegisterConsumer()
    {
        AddHandler(UserRedpackRegisterHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserRegisterMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 有效新用户注册增加红包
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task UserRedpackRegisterHandle(UserRegisterMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;

        // 非红包分享
        if (message.FromMode != 3) return;

        var user = await GlobalUserDCache.Create(message.UserId);
        var pUserId = await user.GetPUserID1Async();
        // 不存在上级
        if (string.IsNullOrWhiteSpace(pUserId)) return;

        // 有效红包
        var redpack = await new EffectiveDCache(pUserId).GetFromRedisAsync();
        if (redpack == null) return;

        using var redlock = await RedisUtil.LockAsync($"lobby:Redpack:Register:{redpack.PackID}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            LogUtil.Error(CommonCodes.UserConcurrent, $"redpack register for lock failed.userId:{message.UserId}");
        }

        // 是否还有抽奖机会
        var task = await new Sa_redpack_user_taskMO().GetAsync("PackID=@PackID AND GroupId=@GroupId AND RemainCount>0", redpack.PackID, (int)TaskCategoryEnums.NewUser);
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
                UserID = pUserId,
                PUserID = message.UserId,
                GroupId = (int)TaskCategoryEnums.NewUser,
                Amount = amount,
                Bonus = 0,
                Status = (int)PackUseStatusEnums.UnUsed,
                RecDate = DateTime.UtcNow
            }, tm);
            tm.Commit();
            await new EffectiveDCache(pUserId).RemainCountIncrementAsync(1);
        }
        catch (Exception ex)
        {
            tm.Rollback();
            LogUtil.Error($"redpack register error:{ex.Message}");
        }
    }
}
