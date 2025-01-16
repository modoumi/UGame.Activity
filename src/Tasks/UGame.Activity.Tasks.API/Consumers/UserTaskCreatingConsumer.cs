using EasyNetQ;
using Newtonsoft.Json;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.Common;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.Activity.Tasks.API.Consumers;

public class UserTaskCreatingConsumer : MQBizSubConsumer<UserTaskCreatingMsg>
{

    public UserTaskCreatingConsumer()
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
    public async Task Handle(UserTaskCreatingMsg message, CancellationToken cancellationToken)
    {
        if (message == null)
            return;

        var myTask = await DbUtil.GetRepository<Sat_item_operatorPO>().AsQueryable()
            .InnerJoin<Sat_taskPO>((a, b) => a.ItemID == b.ItemID)
            .InnerJoin<Sat_itemPO>((a, b, c) => a.ItemID == c.ItemID)
            .Where((a, b, c) => a.Status == 1 && b.Status == 1 && c.Status == 1 &&
                a.OperatorID == message.OperatorId && a.ItemID == message.ItemId)
            .Select((a, b, c) => b)
            .FirstAsync();
        if (myTask == null) return;
        Console.WriteLine($"Recieved UserTaskCreatingMsg:{JsonConvert.SerializeObject(message)}");

        var dayId = DateTime.Parse("1900-01-01");
        if (message.DayId.HasValue)
            dayId = message.DayId.Value;
        else
        {
            var today = DateTime.UtcNow.ToLocalTime(message.OperatorId).Date;
            switch (myTask.Frequency)
            {
                case 0: dayId = DateTime.MaxValue.AddDays(-1); break;
                case 1: dayId = today; break;
                case 2: dayId = DateTimeUtil.BeginDayOfWeek(today); break;
                case 3: dayId = DateTimeUtil.LastDayOfPrdviousMonth(today).AddDays(1); break;
            }
        }
        DateTime deadline = dayId.AddDays(1);
        if (message.Deadline.HasValue)
            deadline = message.Deadline.Value;
        else
        {
            switch (myTask.Frequency)
            {
                case 0: deadline = DateTime.MaxValue.AddDays(-1); break;
                case 1: deadline = dayId.AddDays(1); break;
                case 2: deadline = dayId.AddDays(7); break;
                case 3: deadline = dayId.AddMonths(1); break;
            }
        }

        Sat_user_itemPO myUserItem = null;
        if (myTask.Frequency > 0)
        {
            myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
                .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == message.ItemId && f.DayID == dayId);
        }
        else
        {
            myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
                .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == message.ItemId);
        }
        if (myUserItem != null)
        {
            if (myTask.Frequency > 0)
            {
                //更新状态
                if (string.IsNullOrEmpty(myUserItem.RewardID) && myUserItem.Status == 0
                    && message.DayId.HasValue && message.DayId.Value == myUserItem.DayID)
                {
                    myUserItem.RewardID = message.DetailId;
                    myUserItem.Status = message.Status;
                    myUserItem.UpdateTime = DateTime.UtcNow;
                    await DbUtil.GetRepository<Sat_user_itemPO>()
                        .UpdateAsync(myUserItem);
                }
                //更新状态
                else if (!string.IsNullOrEmpty(myUserItem.RewardID) && message.DetailId == myUserItem.RewardID
                    && message.DayId.HasValue && message.DayId.Value == myUserItem.DayID && message.Status > myUserItem.Status)
                {
                    if (message.Status == 2)
                    {
                        //外部活动完成，由外部活动自己控制Bonus的处理，任务本身不处理
                        await DbUtil.GetRepository<Sat_task_detailPO>()
                            .InsertAsync(new Sat_task_detailPO
                            {
                                DetailID = myUserItem.DetailID,
                                RewardID = myUserItem.RewardID,
                                UserID = myUserItem.UserID,
                                DayID = myUserItem.DayID,
                                ItemID = myUserItem.ItemID,
                                Deadline = myUserItem.Deadline,
                                //外部的活动，通常都没有等级
                                Level = 0,
                                //外部的活动，通常都没有条件，都是外部自己控制的
                                //ConditionExpr=null,
                                RewardType = message.IsBonus ? 1 : 2,
                                RewardAmount = message.RewardAmount,
                                FlowMultip = (int)message.FlowMultip,
                                IssueRule = 0,
                                RecDate = DateTime.UtcNow
                            });
                        if (myTask.IsResident)
                        {
                            myUserItem.RewardID = null;
                            myUserItem.Status = message.Status;
                            myUserItem.UpdateTime = DateTime.UtcNow;
                            await DbUtil.GetRepository<Sat_user_itemPO>()
                                .UpdateAsync(myUserItem);
                        }
                        else
                        {
                            await DbUtil.GetRepository<Sat_user_itemPO>()
                                .DeleteAsync(f => f.DetailID == myUserItem.DetailID);
                        }
                    }
                    else
                    {
                        myUserItem.Status = message.Status;
                        myUserItem.UpdateTime = DateTime.UtcNow;
                        await DbUtil.GetRepository<Sat_user_itemPO>()
                            .UpdateAsync(myUserItem);
                    }
                }
            }
            else
            {
                if (myUserItem.RewardID != message.DetailId && myUserItem.Status != message.Status)
                {
                    myUserItem.RewardID = message.DetailId;
                    myUserItem.Status = message.Status;
                    myUserItem.UpdateTime = DateTime.UtcNow;
                    await DbUtil.GetRepository<Sat_user_itemPO>()
                        .UpdateAsync(myUserItem);
                }
            }
        }
        else
        {
            var myTaskDetail = await DbUtil.GetRepository<Sat_task_detailPO>()
                .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == message.ItemId && f.DayID == dayId);
            if (myTaskDetail != null)
                return;

            var process = message.Status > 0 ? "1" : "0";
            await DbUtil.GetRepository<Sat_user_itemPO>()
                .InsertAsync(new Sat_user_itemPO
                {
                    DetailID = message.DetailId,
                    RewardID = message.DetailId,
                    UserID = message.UserId,
                    DayID = dayId,
                    ItemID = message.ItemId,
                    IsResident = myTask.IsResident,
                    Deadline = deadline,
                    //外部的活动，通常都没有等级
                    Level = 0,
                    RewardAmount = 0,
                    //外部的活动，通常都没有进度，默认设置为1
                    Value1 = process,
                    Status = message.Status,
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                });
            //在插入新的任务时，再删除原任务
            if (myTask.Frequency > 0)
            {
                await DbUtil.GetRepository<Sat_user_itemPO>()
                    .DeleteAsync(f => f.UserID == message.UserId && f.DayID < dayId && f.ItemID == message.ItemId);
            }
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserTaskCreatingMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
