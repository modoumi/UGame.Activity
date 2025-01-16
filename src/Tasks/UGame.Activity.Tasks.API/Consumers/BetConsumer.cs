using EasyNetQ;
using Newtonsoft.Json;
using SqlSugar;
using System.Text;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Tasks.API.Domain.Services;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.Common;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Tasks.API.Consumers;

public class BetConsumer : MQBizSubConsumer<UserBetMsg>
{
    public BetConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public async Task Handle(UserBetMsg message, CancellationToken cancellationToken)
    {
        //兼容系统发送的下注金额为0，订单ID为null消息
        if (string.IsNullOrEmpty(message.OrderId) && message.BetAmount == 0)
            return;

        Console.WriteLine($"BetConsumer.Handle, OrderId:{message.OrderId},Message:{JsonConvert.SerializeObject(message)} Begin");

        //累计日下注、周下注、月下注任务
        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItems = allOperatorItems.FindAll(f => f.Status == 1);
        if (myOperatorItems == null || myOperatorItems.Count == 0) return;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItems = allItems.FindAll(f => f.Status == 1);
        if (myItems == null || myItems.Count == 0) return;

        var betItemIds = new int[] { 100027, 100028, 100029 };
        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTasks = allTasks.FindAll(f => f.Status == 1 && myItems.Exists(t => t.ItemID == f.ItemID)
            && myOperatorItems.Exists(t => t.ItemID == f.ItemID) && betItemIds.Contains(f.ItemID));
        if (myTasks == null || myTasks.Count == 0) return;

        if (message.BetTime.Kind == DateTimeKind.Local)
            message.BetTime = message.BetTime.ToUniversalTime();
        var dayId = message.BetTime.ToLocalTime(message.OperatorId).Date;
        var weeklyDayId = DateTimeUtil.BeginDayOfWeek(dayId);
        var monthlyDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);

        var ado = DbUtil.GetRepository<Sat_bet_dayPO>().AsSugarClient().Ado;
        foreach (var myTask in myTasks)
        {
            var itemId = myTask.ItemID;
            DateTime taskDayId = dayId;
            switch (myTask.ItemID)
            {
                case 100027: taskDayId = dayId; break;
                case 100028: taskDayId = weeklyDayId; break;
                case 100029: taskDayId = monthlyDayId; break;
            }

            try
            {
                var count = await DbUtil.GetRepository<Sat_bet_dayPO>()
                    .CountAsync(f => f.UserID == message.UserId && f.ItemID == itemId && f.DayID == taskDayId);
                if (count > 0)
                {
                    await DbUtil.GetRepository<Sat_bet_dayPO>().AsUpdateable()
                    .SetColumns(f => new Sat_bet_dayPO
                    {
                        BetAmount = f.BetAmount + message.BetAmount,
                        UpdateTime = DateTime.UtcNow
                    })
                    .Where(f => f.UserID == message.UserId && f.ItemID == itemId && f.DayID == taskDayId)
                    .ExecuteCommandAsync();
                }
                else
                {
                    var builder = new StringBuilder();
                    builder.Append("INSERT INTO `sat_bet_day` (`UserID`, `DayID`, `ItemID`, `OperatorID`, `CurrencyID`, `BetAmount`, `RecDate`, `UpdateTime`) VALUES ");
                    builder.Append($"('{message.UserId}', '{taskDayId:yyyy-MM-dd}', {itemId}, '{message.OperatorId}', '{message.CurrencyId}', {message.BetAmount}, '{message.BetTime.ToUniversalTime():yyyy-MM-dd HH:mm:ss}', '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}')");
                    builder.Append($" on duplicate key update `BetAmount`=`BetAmount`+{message.BetAmount},`UpdateTime`='{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}';");
                    var sql = builder.ToString();
                    await ado.ExecuteCommandAsync(sql);
                }
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger()
                    .AddException(ex)
                    .AddMessage(message.ToJson())
                    .AddField("BetConsumer.Source", "Handle")
                    .AddMessage("User Bet Message process fail.");
            }
        }

        var itemIds = myTasks.Select(f => f.ItemID).ToList();
        var betDailyCondition = Expressionable.Create<Sat_bet_dayPO>()
            .OrIF(itemIds.Contains(100027), f => f.ItemID == 100027 && f.DayID == dayId)
            .OrIF(itemIds.Contains(100028), f => f.ItemID == 100028 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100029), f => f.ItemID == 100029 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var userItemCondition = Expressionable.Create<Sat_user_itemPO>()
            .OrIF(itemIds.Contains(100027), f => f.ItemID == 100027 && f.DayID == dayId)
            .OrIF(itemIds.Contains(100028), f => f.ItemID == 100028 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100029), f => f.ItemID == 100029 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var taskDetailCondition = Expressionable.Create<Sat_task_detailPO>()
            .OrIF(itemIds.Contains(100027), f => f.ItemID == 100027 && f.DayID == dayId)
            .OrIF(itemIds.Contains(100028), f => f.ItemID == 100028 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100029), f => f.ItemID == 100029 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, message.OperatorId);
        var myBetDailyInfos = await DbUtil.GetRepository<Sat_bet_dayPO>().GetListAsync(betDailyCondition);
        var myUserItems = await DbUtil.GetRepository<Sat_user_itemPO>().GetListAsync(userItemCondition);
        var myTaskDetails = await DbUtil.GetRepository<Sat_task_detailPO>().GetListAsync(taskDetailCondition);

        //生成充值任务数据
        foreach (var myTask in myTasks)
        {
            var myBeitInfo = myBetDailyInfos.Find(f => f.ItemID == myTask.ItemID);
            var myTaskRewards = allTaskRewards.FindAll(f => f.ItemID == myTask.ItemID);
            if (myTaskRewards.Count > 1)
                myTaskRewards.Sort((x, y) => x.Level.CompareTo(y.Level));

            foreach (var myTaskReward in myTaskRewards)
            {
                if (myTaskDetails.Exists(f => f.ItemID == myTaskReward.ItemID && f.Level == myTaskReward.Level))
                    continue;

                var status = 0;
                var currentValue = 0;
                if (myTaskReward.MinRequiredAmount.HasValue && myBeitInfo.BetAmount >= myTaskReward.MinRequiredAmount.Value)
                {
                    status = 1;
                    currentValue = myTaskReward.MaxValue;
                }
                else
                {
                    status = 0;
                    currentValue = (int)myBeitInfo.BetAmount.AToM(myBeitInfo.CurrencyID);
                }
                if (currentValue > myTaskReward.MaxValue)
                    currentValue = myTaskReward.MaxValue;

                DateTime taskDayId = dayId;
                DateTime deadline = DateTime.Now;
                switch (myTask.ItemID)
                {
                    case 100027: taskDayId = dayId; deadline = dayId.AddDays(1); break;
                    case 100028: taskDayId = weeklyDayId; deadline = weeklyDayId.AddDays(7); break;
                    case 100029: taskDayId = monthlyDayId; deadline = monthlyDayId.AddMonths(1); break;
                }

                try
                {
                    var myUserItem = myUserItems.Find(f => f.ItemID == myTaskReward.ItemID && f.Level == myTaskReward.Level);
                    if (myTaskReward.IsNeedReceive)
                    {
                        if (myUserItem != null)
                        {
                            await DbUtil.GetRepository<Sat_user_itemPO>().AsUpdateable()
                                .SetColumns(f => new Sat_user_itemPO
                                {
                                    Value1 = currentValue.ToString(),
                                    Status = status,
                                    UpdateTime = DateTime.UtcNow
                                })
                                .Where(f => f.DetailID == myUserItem.DetailID)
                                .ExecuteCommandAsync();
                        }
                        else
                        {
                            await DbUtil.GetRepository<Sat_user_itemPO>()
                                .InsertAsync(new Sat_user_itemPO
                                {
                                    DetailID = ObjectId.NewId(),
                                    UserID = message.UserId,
                                    ItemID = myTaskReward.ItemID,
                                    DayID = taskDayId,
                                    Level = myTaskReward.Level,
                                    Deadline = deadline,
                                    IsResident = myTask.IsResident,
                                    RewardAmount = myTaskReward.RewardAmount,
                                    Status = status,
                                    Value1 = currentValue.ToString(),
                                    RecDate = DateTime.UtcNow,
                                    UpdateTime = DateTime.UtcNow
                                });
                        }
                    }
                    else
                    {
                        if (status == 0)
                        {
                            if (myUserItem != null)
                            {
                                await DbUtil.GetRepository<Sat_user_itemPO>().AsUpdateable()
                                    .SetColumns(f => new Sat_user_itemPO
                                    {
                                        Value1 = currentValue.ToString(),
                                        Status = status,
                                        UpdateTime = DateTime.UtcNow
                                    })
                                    .Where(f => f.DetailID == myUserItem.DetailID)
                                    .ExecuteCommandAsync();
                            }
                            else
                            {
                                await DbUtil.GetRepository<Sat_user_itemPO>()
                                    .InsertAsync(new Sat_user_itemPO
                                    {
                                        DetailID = ObjectId.NewId(),
                                        UserID = message.UserId,
                                        ItemID = myTaskReward.ItemID,
                                        DayID = taskDayId,
                                        Level = myTaskReward.Level,
                                        Deadline = deadline,
                                        IsResident = myTask.IsResident,
                                        RewardAmount = myTaskReward.RewardAmount,
                                        Status = status,
                                        Value1 = currentValue.ToString(),
                                        RecDate = DateTime.UtcNow,
                                        UpdateTime = DateTime.UtcNow
                                    });
                            }
                            continue;
                        }
                        //不需要领取，直接发放
                        long rewardAmount = 0;
                        string rewardLinesJson = null;
                        if (myTaskReward.IssueRule > 1)
                        {
                            var allTaskRewardLines = DbCachingUtil.GetList<Sat_task_reward_linePO>(f => f.OperatorID, message.OperatorId);
                            var myTaskRewardLines = allTaskRewardLines.FindAll(f => f.ItemID == myTask.ItemID);
                            if (allTaskRewardLines == null)
                                throw new CustomException($"任务{myTask.ItemID}配置为{myTaskReward.IssueRule},但未配置sat_task_reward_line表数据");
                            switch (myTaskReward.IssueRule)
                            {
                                case 2:
                                    //权重，使用alias抽样算法                       
                                    var totalWeight = myTaskRewardLines.Sum(f => f.Weight);
                                    var probPrizes = myTaskRewardLines.Select(f => new ProbabilityPrize
                                    {
                                        Probability = (double)f.Weight / totalWeight,
                                        Prize = f.RewardAmount
                                    }).ToList();
                                    var alaisMethodService = new AliasMethodService(probPrizes);
                                    rewardAmount = alaisMethodService.Next<long>();

                                    var rewardLines2 = myTaskRewardLines.Select(f => new { f.Weight, f.RewardAmount }).ToList();
                                    if (rewardLines2 != null && rewardLines2.Count > 0)
                                        rewardLinesJson = rewardLines2.ToJson();
                                    break;
                                case 3:
                                    var index = new Random().Next(0, myTaskRewardLines.Count - 1);
                                    rewardAmount = myTaskRewardLines[index].RewardAmount;

                                    var rewardLines3 = myTaskRewardLines.Select(f => new { f.Weight, f.RewardAmount }).ToList();
                                    if (rewardLines3 != null && rewardLines3.Count > 0)
                                        rewardLinesJson = rewardLines3.ToJson();
                                    break;
                            }
                        }

                        var taskService = new TaskService();
                        await taskService.DirectReceiveReward(new Sat_task_detailPO
                        {
                            DetailID = ObjectId.NewId(),
                            UserID = message.UserId,
                            ItemID = myTask.ItemID,
                            DayID = taskDayId,
                            OperatorID = message.OperatorId,
                            Level = myTaskReward.Level,
                            Deadline = deadline,
                            RewardType = myTaskReward.RewardType,
                            CurrencyID = myTaskReward.CurrencyID,
                            FlowMultip = myTaskReward.FlowMultip,
                            IssueRule = myTaskReward.IssueRule,
                            RewardAmount = myTaskReward.RewardAmount,
                            RewardLines = rewardLinesJson,
                            RecDate = DateTime.UtcNow
                        }, message.AppId, message.CountryId);

                        if (myUserItem != null)
                        {
                            await DbUtil.GetRepository<Sat_user_itemPO>()
                                .DeleteAsync(f => f.DetailID == myUserItem.DetailID);
                        }
                    }
                }
                catch
                {
                    //并发插入，忽略
                }
            }
        }
        Console.WriteLine($"BetConsumer.Handle, OrderId:{message.OrderId},Message:{JsonConvert.SerializeObject(message)} End");
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserBetMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
