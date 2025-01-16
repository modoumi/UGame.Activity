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
using Xxyy.MQ.Bank;

namespace UGame.Activity.Redpack.Consumers;

/// <summary>
/// 充值消息
/// </summary>
public class UserPayConsumer : MQBizSubConsumer<UserPayMsg>
{
    /// <summary>
    /// 构造
    /// </summary>
    public UserPayConsumer()
    {
        AddHandler(UserPayHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserPayMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 计算用户充值额度增加红包抽奖次数
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task UserPayHandle(UserPayMsg message, CancellationToken cancellationToken)
    {
        if (message == null || message.PayAmount == 0) return;

        var user = await GlobalUserDCache.Create(message.UserId);
        var pUserId = await user.GetPUserID1Async();
        // 不存在上级
        if (string.IsNullOrWhiteSpace(pUserId)) return;

        // 有效红包
        var redpack = await new EffectiveDCache(pUserId).GetFromRedisAsync();
        if (redpack == null) return;

        using var redlock = await RedisUtil.LockAsync($"lobby:Redpack:UserPay:{redpack.PackID}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            LogUtil.Error(CommonCodes.UserConcurrent, $"repack user pay for lock failed packId:{redpack.PackID}");
        }

        // 是否还有抽奖机会
        var task = await new Sa_redpack_user_taskMO().GetAsync("PackID=@PackID AND GroupId=@GroupId AND RemainCount>0", redpack.PackID, (int)TaskCategoryEnums.Pay);
        var remainCount = task.Sum(w => w.RemainCount);
        if (remainCount == 0) return;

        var weight = RedpackDbCacheUtil.GetUserTaskRatio(task);
        var amount = RandomUtil.NextAmount(0.01, weight.RemainAmount, weight.RemainCount, redpack.CurrencyID);
        var currentPayAmount = redpack.PayAmount + message.PayAmount;

        var inPayAmount = await new EffectiveDCache(pUserId).IncrementPayAmount(message.PayAmount);
        if (inPayAmount >= weight.PayAmount)
        {
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
                    GroupId = (int)TaskCategoryEnums.Pay,
                    Amount = amount,
                    Bonus = 0,
                    Status = (int)PackUseStatusEnums.UnUsed,
                    RecDate = DateTime.UtcNow
                }, tm);
                tm.Commit();
                await new EffectiveDCache(pUserId).ResetPayAmount();
                await new EffectiveDCache(pUserId).RemainCountIncrementAsync(1);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error($"redpack bet error:{ex.Message}");
            }
        }


    }
}
