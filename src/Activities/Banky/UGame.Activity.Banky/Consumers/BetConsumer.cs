using EasyNetQ;
using SActivity.Common.Enums;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.Banky.Caching;
using UGame.Activity.Banky.Modelsp;
using UGame.Activity.Banky.Repositories;
using Xxyy.Common;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Banky.Consumers;

/// <summary>
/// 下注结算-消费者
/// </summary>
public class BetConsumer : MQBizSubConsumer<UserBetMsg>
{
    public BetConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserBetMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 处理下注消费者
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    private async Task Handle(UserBetMsg message, CancellationToken cancellationToken)
    {
        try
        {
            var bankyConfigDCache = new BankyConfigDCache(message.OperatorId);
            var bankyConfig = await bankyConfigDCache.GetAsync();
            if (bankyConfig == default || bankyConfig.OperatorID == null) return;

            var userSvc = new User2Service(message.UserId);
            var userBalance = await userSvc.GetBalance();

            //发起破产保护
            if (userBalance < bankyConfig.MinLimit)
            {
                var bankyUser = await DbUtil.GetRepository<Sa_banky_userPO>().AsQueryable()
                    .Where(_ => _.UserID == message.UserId && _.OperatorID == message.OperatorId && _.Times > 0)
                    .FirstAsync();

                if (bankyUser == null || bankyUser.Times - 1 < 0) return;

                DbTransactionManager tm = new();
                try
                {
                    tm.Begin();
                    var refundAmount = Math.Floor(bankyUser.TotalAmount.AToM(message.CurrencyId) / bankyUser.Times).MToA(message.CurrencyId);
                    await DbUtil.UpdateAsync<Sa_banky_userPO>(it => new Sa_banky_userPO
                    {
                        Times = bankyUser.Times - 1,
                        TotalAmount = bankyUser.TotalAmount - refundAmount,
                        Status = bankyUser.Times - 1 == 0 ? (int)BankyStatusEnum.Completed : (int)BankyStatusEnum.InProgress,
                        UpdateDate = DateTime.UtcNow
                    }, it => it.UserID == message.UserId && it.OperatorID == message.OperatorId);

                    var objectId = ObjectId.NewId();
                    await DbUtil.GetRepository<Sa_banky_detailPO>().InsertAsync(new Sa_banky_detailPO
                    {
                        DetailID = objectId,
                        UserID = message.UserId,
                        OperatorID = message.OperatorId,
                        RefundType = bankyConfig.RefundType,
                        RefundAmount = (long)refundAmount,
                        FlowMultip = bankyConfig.FlowMultip,
                        RecDate = DateTime.UtcNow
                    });

                    //2、写入货币变化
                    var currencyChangeReq = new CurrencyChangeReq()
                    {
                        UserId = message.UserId,
                        AppId = message.AppId,
                        OperatorId = message.OperatorId,
                        CurrencyId = message.CurrencyId,
                        Reason = "2.1破产保护功能",
                        Amount = Math.Abs((long)refundAmount),
                        SourceType = (int)ActivityType.Banky,
                        SourceTable = "sa_banky_detail",
                        SourceId = objectId,
                        ChangeTime = DateTime.UtcNow,
                        ChangeBalance = bankyConfig.RefundType == 1 ? CurrencyChangeBalance.Cash : CurrencyChangeBalance.Bonus,
                        FlowMultip = bankyConfig.FlowMultip,
                        DbTM = tm
                    };

                    //3、写s_currency_change
                    var currencyChangeService = new CurrencyChange2Service(message.UserId);
                    var changeMsg = await currencyChangeService.Add(currencyChangeReq);

                    tm.Commit();

                    await MQUtil.PublishAsync(changeMsg);

                    await MQUtil.PublishAsync(new UserActivityMsg()
                    {
                        UserId = message.UserId,
                        ActivityType = (int)ActivityType.Banky
                    });
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    throw new CustomException(ex.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw new CustomException($"UserBetMsgConsumer_Handle_Exception Message:{ex}");
        }
    }
}