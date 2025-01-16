using EasyNetQ;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using UGame.Activity.Banky.Caching;
using UGame.Activity.Banky.Modelsp;
using UGame.Activity.Banky.Repositories;
using Xxyy.MQ.Bank;

namespace UGame.Activity.Banky.Consumers;

/// <summary>
/// 用户充值消费者
/// </summary>
public class UserPayConsumer : MQBizSubConsumer<UserPayMsg>
{
    public UserPayConsumer()
    {
        AddHandler(Handle);
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
    /// 用户充值-破产保护返还金额池
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task Handle(UserPayMsg message, CancellationToken cancellationToken)
    {
        try
        {
            var bankyConfigDCache = new BankyConfigDCache(message.OperatorId);
            var bankyConfig = await bankyConfigDCache.GetAsync();

            if (bankyConfig == default || bankyConfig.OperatorID == null) return;

            var bankyUser = await DbUtil.GetRepository<Sa_banky_userPO>().AsQueryable()
                .Where(_ => _.UserID == message.UserId && _.OperatorID == message.OperatorId)
                .FirstAsync(cancellationToken);

            if (bankyUser == null)
            {
                await DbUtil.GetRepository<Sa_banky_userPO>().InsertAsync(new Sa_banky_userPO
                {
                    UserID = message.UserId,
                    OperatorID = message.OperatorId,
                    TotalAmount = (long)(message.PayAmount * bankyConfig.Rate) * bankyConfig.Times,
                    RefundType = bankyConfig.RefundType,
                    Times = bankyConfig.Times,
                    Status = (int)BankyStatusEnum.Initial,
                    RecDate = DateTime.UtcNow,
                });
                return;
            }

            var totalAmount = bankyUser.TotalAmount + (long)(message.PayAmount * bankyConfig.Rate) * bankyConfig.Times;
            await DbUtil.GetRepository<Sa_banky_userPO>().AsUpdateable()
               .SetColumns(it => new Sa_banky_userPO
               {
                   Times = bankyConfig.Times,
                   TotalAmount = totalAmount,
                   Status = (int)BankyStatusEnum.Initial,
                   UpdateDate = DateTime.UtcNow
               })
            .Where(_ => _.UserID == message.UserId && _.OperatorID == message.OperatorId)
            .ExecuteCommandAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            throw new CustomException($"UserPayConsumer_Handle_Exception Message:{ex}");
        }
    }
}
