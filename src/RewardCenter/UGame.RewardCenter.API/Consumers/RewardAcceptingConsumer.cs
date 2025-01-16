using EasyNetQ;
using System;
using System.Threading;
using System.Threading.Tasks;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using UGame.RewardCenter.API.Repositories;
using UGame.RewardCenter.API.Services;
using Xxyy.Common;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.RewardCenter.API.Consumers;

public class RewardAcceptingConsumer : MQBizSubConsumer<UserItemRewardMsg>
{
    private readonly RewardCalendarService rewardCalendarService = new();
    
    public RewardAcceptingConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(UserItemRewardMsg message, CancellationToken cancellationToken)
    {
        if (message == null)
            return;

        //不是长线版本不做处理
        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, message.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1) return;

        //目前只有兑换码，使用这个消费者 ItemId=100035
        //如果该活动还有延迟奖金，则往奖励日历中添加延迟奖金日历，此处的message.ItemId是延迟活动ID
        var calendarSetting = await DbUtil.GetRepository<Sat_reward_calendar_itemPO>()
            .GetFirstAsync(f => f.OperatorID == message.OperatorId && f.ItemID == message.ItemId);
        if (calendarSetting != null && calendarSetting.Status == 1 && message.DelayDays > 0)
        {
            var beingDate = DateTime.UtcNow.ToLocalTime(message.OperatorId).Date.AddDays(1);
            await this.rewardCalendarService.CreateCalendarDelayReward(message.UserId, beingDate, message.ItemId, message.CurrencyId,
                message.OperatorId, message.DetailId, message.DelayDays, message.IsBonus, message.DelayRewardAmount, message.FlowMultip, message.Reason);
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserItemRewardMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
