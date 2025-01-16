using EasyNetQ;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using UGame.Activity.CoinWheel.Repositories;
using Xxyy.MQ.Bank;

namespace UGame.Activity.CoinWheel.Consumers;

/// <summary>
/// 消费充值消息
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
    /// 充值送积分抽奖奖池金额
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task Handle(UserPayMsg message, CancellationToken cancellationToken)
    {
        try
        {
            var wheelConfig = await DbUtil.GetRepository<Sa_coinwheel_configPO>().AsQueryable()
                .Where(_ => _.Status == 1 && _.OperatorID == message.OperatorId).FirstAsync(cancellationToken);

            if (wheelConfig == default) return;

            var wheelUser = await DbUtil.GetRepository<Sa_coinwheel_userPO>().AsQueryable()
                .Where(_ => _.UserID == message.UserId).FirstAsync(cancellationToken);

            if (wheelUser == null)
            {
                await InitUserReward(message, 0, wheelConfig);
            }
            else
            {
                var addAmount = message.PayAmount * wheelConfig.PotRate;
                wheelUser.PotAmount = wheelUser.PotAmount + addAmount >= wheelConfig.MaxPot ? wheelConfig.MaxPot : wheelUser.PotAmount + (long)addAmount;
                await DbUtil.GetRepository<Sa_coinwheel_userPO>().UpdateAsync(wheelUser);
            }
        }
        catch (Exception ex)
        {
            throw new CustomException($"UserPayConsumer_Handle_Exception Message:{ex}");
        }
    }

    /// <summary>
    /// 初始化用户奖池
    /// </summary>
    /// <param name="message"></param>
    /// <param name="defaultValue"></param>
    /// <param name="wheelConfig"></param>
    /// <returns></returns>
    private async Task<bool> InitUserReward(UserPayMsg message, long defaultValue, Sa_coinwheel_configPO wheelConfig)
    {
        var addAmount = message.PayAmount * wheelConfig.PotRate;
        defaultValue = addAmount >= wheelConfig.MaxPot ? wheelConfig.MaxPot : (long)addAmount;
        var dailyWheelUser = new Sa_coinwheel_userPO
        {
            UserID = message.UserId,
            OperatorID = message.OperatorId,
            PotAmount = defaultValue,//累计金额大于0则累计，否则默认值
            PlayNums = 0,
            RecDate = DateTime.UtcNow,
        };
        return await DbUtil.GetRepository<Sa_coinwheel_userPO>().InsertAsync(dailyWheelUser);
    }
}
