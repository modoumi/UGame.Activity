using EasyNetQ;
using Newtonsoft.Json;
using SqlSugar;
using System.Text;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Collections;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Tasks.API.Domain.Services;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Bank;

namespace UGame.Activity.Tasks.API.Consumers;

public class DepositConsumer :MQBizSubConsumer<UserPayMsg>
{
    public DepositConsumer()
    {
        AddHandler(HandleDepositTask);
        AddHandler(HandleFriendInvitationTask);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public async Task HandleDepositTask(UserPayMsg message, CancellationToken cancellationToken)
    {
        Console.WriteLine($"DepositConsumer.Handle, OrderId:{message.OrderID},Message:{JsonConvert.SerializeObject(message)} Begin");

        //累计日充值、周充值、月充值、当日有充值任务
        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItems = allOperatorItems.FindAll(f => f.Status == 1);
        if (myOperatorItems == null || myOperatorItems.Count == 0) return;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItems = allItems.FindAll(f => f.Status == 1);
        if (myItems == null || myItems.Count == 0) return;

        var depositItemIds = new int[] { 100023, 100024, 100025, 100026 };
        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTasks = allTasks.FindAll(f => f.Status == 1 && myItems.Exists(t => t.ItemID == f.ItemID)
            && myOperatorItems.Exists(t => t.ItemID == f.ItemID) && depositItemIds.Contains(f.ItemID));
        if (myTasks == null || myTasks.Count == 0) return;

        if (message.PayTime.Kind == DateTimeKind.Local)
            message.PayTime = message.PayTime.ToUniversalTime();
        var dayId = message.PayTime.ToLocalTime(message.OperatorId).Date;
        var weeklyDayId = DateTimeUtil.BeginDayOfWeek(dayId);
        var monthlyDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);

        bool isFirstDepositCompleted = false;
        var ado = DbUtil.GetRepository<Sat_deposit_dayPO>().AsSugarClient().Ado;
        foreach (var myTask in myTasks)
        {
            var itemId = myTask.ItemID;
            DateTime taskDayId = dayId;
            switch (myTask.ItemID)
            {
                case 100023:
                case 100026:
                    //今日首充和今日累计充值，只累加一次充值金额
                    itemId = 100023;
                    taskDayId = dayId;
                    if (isFirstDepositCompleted) continue;
                    isFirstDepositCompleted = true;
                    break;
                case 100024: taskDayId = weeklyDayId; break;
                case 100025: taskDayId = monthlyDayId; break;
            }

            try
            {
                var count = await DbUtil.GetRepository<Sat_deposit_dayPO>()
                    .CountAsync(f => f.UserID == message.UserId && f.ItemID == itemId && f.DayID == taskDayId);
                if (count > 0)
                {
                    await DbUtil.GetRepository<Sat_deposit_dayPO>().AsUpdateable()
                    .SetColumns(f => new Sat_deposit_dayPO
                    {
                        DepositAmount = f.DepositAmount + message.PayAmount,
                        UpdateTime = DateTime.UtcNow
                    })
                    .Where(f => f.UserID == message.UserId && f.ItemID == itemId && f.DayID == taskDayId)
                    .ExecuteCommandAsync();
                }
                else
                {
                    var builder = new StringBuilder();
                    builder.Append("INSERT INTO `sat_deposit_day` (`UserID`, `DayID`, `ItemID`, `OperatorID`, `CurrencyID`, `DepositAmount`, `RecDate`, `UpdateTime`) VALUES ");
                    builder.Append($"('{message.UserId}', '{taskDayId:yyyy-MM-dd}', {itemId}, '{message.OperatorId}', '{message.CurrencyId}', {message.PayAmount}, '{message.PayTime.ToUniversalTime():yyyy-MM-dd HH:mm:ss}', '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}')");
                    builder.Append($" on duplicate key update `DepositAmount`=`DepositAmount`+{message.PayAmount},`UpdateTime`='{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}';");
                    var sql = builder.ToString();
                    await ado.ExecuteCommandAsync(sql);
                }
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger()
                    .AddException(ex)
                    .AddMessage(message.ToJson())
                    .AddField("DepositConsumer.Source", "HandleDepositTask")
                    .AddMessage("User Pay Message process fail.");
            }
        }

        var itemIds = myTasks.Select(f => f.ItemID).ToList();
        var dailyItemIds = myTasks.Where(f => f.ItemID == 100023 || f.ItemID == 100026).Select(f => f.ItemID).ToList();
        var depositDailyCondition = Expressionable.Create<Sat_deposit_dayPO>()
            .OrIF(dailyItemIds.Count > 0, f => dailyItemIds.Contains(f.ItemID) && f.DayID == dayId)
            .OrIF(itemIds.Contains(100024), f => f.ItemID == 100024 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100025), f => f.ItemID == 100025 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var userItemCondition = Expressionable.Create<Sat_user_itemPO>()
            .OrIF(dailyItemIds.Count > 0, f => dailyItemIds.Contains(f.ItemID) && f.DayID == dayId)
            .OrIF(itemIds.Contains(100024), f => f.ItemID == 100024 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100025), f => f.ItemID == 100025 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var taskDetailCondition = Expressionable.Create<Sat_task_detailPO>()
            .OrIF(dailyItemIds.Count > 0, f => dailyItemIds.Contains(f.ItemID) && f.DayID == dayId)
            .OrIF(itemIds.Contains(100024), f => f.ItemID == 100024 && f.DayID == weeklyDayId)
            .OrIF(itemIds.Contains(100025), f => f.ItemID == 100025 && f.DayID == monthlyDayId)
            .And(f => f.UserID == message.UserId)
            .ToExpression();

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, message.OperatorId);
        var myDepositDailyInfos = await DbUtil.GetRepository<Sat_deposit_dayPO>().GetListAsync(depositDailyCondition);
        var myUserItems = await DbUtil.GetRepository<Sat_user_itemPO>().GetListAsync(userItemCondition);
        var myTaskDetails = await DbUtil.GetRepository<Sat_task_detailPO>().GetListAsync(taskDetailCondition);

        //生成充值任务数据
        foreach (var myTask in myTasks)
        {
            var myDepositInfo = myDepositDailyInfos.Find(f => f.ItemID == myTask.ItemID);
            var myTaskRewards = allTaskRewards.FindAll(f => f.ItemID == myTask.ItemID);
            if (myTaskRewards.Count > 1)
                myTaskRewards.Sort((x, y) => x.Level.CompareTo(y.Level));

            foreach (var myTaskReward in myTaskRewards)
            {
                if (myTaskDetails.Exists(f => f.ItemID == myTaskReward.ItemID && f.Level == myTaskReward.Level))
                    continue;

                var status = 0;
                var currentValue = 0;
                //100026，消息进来，说明已经完成今日充值
                if (myTaskReward.ItemID == 100026)
                {
                    status = 1;
                    currentValue = myTaskReward.MaxValue;
                }
                else
                {
                    if (myTaskReward.MinRequiredAmount.HasValue && myDepositInfo.DepositAmount >= myTaskReward.MinRequiredAmount.Value)
                    {
                        status = 1;
                        currentValue = myTaskReward.MaxValue;
                    }
                    else
                    {
                        status = 0;
                        currentValue = (int)myDepositInfo.DepositAmount.AToM(myDepositInfo.CurrencyID);
                    }
                    if (currentValue > myTaskReward.MaxValue)
                        currentValue = myTaskReward.MaxValue;
                }
                DateTime taskDayId = dayId;
                DateTime deadline = DateTime.Now;
                switch (myTask.ItemID)
                {
                    case 100023:
                    case 100026: taskDayId = dayId; deadline = dayId.AddDays(1); break;
                    case 100024: taskDayId = weeklyDayId; deadline = weeklyDayId.AddDays(7); break;
                    case 100025: taskDayId = monthlyDayId; deadline = monthlyDayId.AddMonths(1); break;
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
        Console.WriteLine($"DepositConsumer.Handle, OrderId:{message.OrderID},Message:{JsonConvert.SerializeObject(message)} End");
    }
    public async Task HandleFriendInvitationTask(UserPayMsg message, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(message.UserId))
            return;

        var itemId = 100022;
        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItem = allOperatorItems.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myOperatorItem == null) return;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItem = allItems.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myItem == null) return;

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTask = allTasks.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myTask == null) return;

        //查询当前用户是否通过推广员注册 
        var userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
        if (string.IsNullOrEmpty(userInfo.PUserID1))
            return;

        //2、获取PUser
        var referrerInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == userInfo.PUserID1);
        if (referrerInfo == null)
            return;

        var myTaskDetail = await DbUtil.GetRepository<Sat_task_detailPO>()
            .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == itemId);
        if (myTaskDetail != null) return;

        var myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
            .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == itemId);
        if (myUserItem != null) return;

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, message.OperatorId);
        var myTaskReward = allTaskRewards.Find(f => f.ItemID == itemId);

        try
        {
            await DbUtil.GetRepository<Sat_user_itemPO>()
                .InsertAsync(new Sat_user_itemPO
                {
                    DetailID = ObjectId.NewId(),
                    UserID = message.UserId,
                    ItemID = myTaskReward.ItemID,
                    DayID = DateTime.Parse("1900-01-01"),
                    Level = myTaskReward.Level,
                    Deadline = DateTime.MaxValue.AddDays(-1),
                    IsResident = myTask.IsResident,
                    RewardAmount = myTaskReward.RewardAmount,
                    Status = 1,
                    Value1 = myTaskReward.MaxValue.ToString(),
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                });
        }
        catch
        {
            //并发插入，忽略
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserPayMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
