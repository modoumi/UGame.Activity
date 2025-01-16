using EasyNetQ;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using UGame.Activity.Banky.Modelsp;
using UGame.Activity.Banky.Repositories;
using Xxyy.MQ.Bank;

namespace UGame.Activity.Banky.Consumers;

/// <summary>
/// 用户提现消费者
/// </summary>
public class UserCashConsumer : MQBizSubConsumer<UserCashMsg>
{
    public UserCashConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserCashMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 用户提现清零，破产保护金额和次数
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task Handle(UserCashMsg message, CancellationToken cancellationToken)
    {
        try
        {
            var bankyUser = await DbUtil.GetRepository<Sa_banky_userPO>().AsQueryable()
                .Where(_ => _.UserID == message.UserId && _.OperatorID == message.OperatorId)
                .FirstAsync(cancellationToken);

            if (bankyUser == null) return;

            await DbUtil.UpdateAsync<Sa_banky_userPO>(it => new Sa_banky_userPO
            {
                Status = (int)BankyStatusEnum.ReSet,
                Times = 0,
                TotalAmount = 0,
                UpdateDate = DateTime.UtcNow
            }, it => it.UserID == message.UserId && it.OperatorID == message.OperatorId);

        }
        catch (Exception ex)
        {
            throw new CustomException($"UserCashConsumer_Handle_Exception Message:{ex}");
        }
    }
}
