using EasyNetQ;
using Newtonsoft.Json;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.Tasks.API.Consumers;

public class CheckinConsumer : MQBizSubConsumer<UserCheckinMsg>
{
    public CheckinConsumer()
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
    public async Task Handle(UserCheckinMsg message, CancellationToken cancellationToken)
    {
        if (message == null)
            return;

        var taskReward = await DbUtil.GetRepository<Sat_item_operatorPO>().AsQueryable()
            .InnerJoin<Sat_taskPO>((a, b) => a.ItemID == b.ItemID)
            .InnerJoin<Sat_task_rewardPO>((a, b, c) => a.ItemID == b.ItemID)
            .Where((a, b, c) => a.Status == 1 && b.Status == 1
                && a.OperatorID == message.OperatorId && a.ItemID == message.ItemId)
            .Select((a, b, c) => c)
            .FirstAsync();
        if (taskReward == null) return;

        try
        {
            await DbUtil.GetRepository<Sat_task_detailPO>()
                .InsertAsync(new Sat_task_detailPO
                {
                    DetailID = ObjectId.NewId(),
                    UserID = message.UserId,
                    DayID = message.DayId,
                    ItemID = message.ItemId,
                    OperatorID = message.OperatorId,
                    Deadline = message.DayId.AddDays(1),
                    CurrencyID = message.CurrencyId,
                    FlowMultip = (int)message.FlowMultip,
                    Level = 0,
                    RecDate = DateTime.UtcNow,
                    RewardAmount = message.RewardAmount,
                    IssueRule = taskReward.IssueRule,
                    RewardType = message.IsBonus ? 1 : 2
                });
            await DbUtil.GetRepository<Sat_user_itemPO>()
                .DeleteAsync(f => f.UserID == message.UserId && f.DayID == message.DayId && f.ItemID == message.ItemId);
        }
        catch
        {
            //插入重复，忽略
            LogUtil.GetContextLogger()
                .AddException(new Exception("签到重复消息"))
                .AddField("CheckinConsumer.Source", "CheckinConsumer.Handle")
                .AddField("CheckinConsumer.Message", JsonConvert.SerializeObject(message));
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserCheckinMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
