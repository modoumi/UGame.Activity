using EasyNetQ;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial.Arenas;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using UGame.RewardCenter.API.Repositories;
using UGame.RewardCenter.API.Services;
using Xxyy.Common;
using Xxyy.MQ.Quartz;

namespace UGame.RewardCenter.API.Consumers;

public class SrUserDayChangedConsumer : MQBizSubConsumer<SRPerDayMsg>
{
    private readonly RebateBoxService rebateBoxService = new();

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public SrUserDayChangedConsumer()
    {
        AddHandler(Handle);
    }

    public async Task Handle(SRPerDayMsg message, CancellationToken cancellationToken)
    {
        if (message == null || message.Type != SRPerDayType.SrUserDay)
            return;

        //需要增加生成任务的判断和逻辑
        LogUtil.GetContextLogger()
            .AddField("SrUserDayChangedConsumer.Status", "Start")
            .AddField("SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
            .AddField("SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));

        Console.WriteLine($"SRPerDayMsg:{JsonConvert.SerializeObject(message)},Start");

        if (string.IsNullOrEmpty(message.OperatorId))
        {
            LogUtil.GetContextLogger()
                .AddException(new ArgumentNullException(nameof(message.OperatorId)))
                .AddField("SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
                .AddField("SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));
            return;
        }

        //目前只有三个奖励中心返奖活动，使用这个消费者
        //如果该活动还有延迟奖金，则往奖励日历中添加延迟奖金日历
        var items = await DbUtil.GetRepository<Sat_reward_center_itemPO>().GetListAsync(f => f.Status == 1);
        var boxSettings = await DbUtil.GetRepository<Sat_rebate_box_configPO>().GetListAsync(f =>
            f.OperatorID == message.OperatorId && f.Status == 1);
        var conditions = await DbUtil.GetRepository<Sat_rebate_box_config_linePO>().GetListAsync();
        var vipSettings = await DbUtil.GetRepository<Sat_rebate_box_vipPO>().GetListAsync(f =>
            f.OperatorID == message.OperatorId);
        //消息传过来的日期是当天的本地时间，统计的数据也是当天的数据，所以，用这个数据来生成明天的数据
        //message.DayId有时候会补发昨天以前日期的数据
        var today = DateTime.UtcNow.ToLocalTime(message.OperatorId).Date;
        var monthldyStartDate = DateTimeUtil.LastDayOfPrdviousMonth(today).AddDays(1).AddMonths(-1);
        if (message.DayId < monthldyStartDate)
        {
            LogUtil.GetContextLogger()
               .AddException(new CustomException($"数据早于一个月之前，忽略，OperatorId:{message.OperatorId},Today:{today:yyyy-MM-dd}, DayId:{message.DayId:yyyy-MM-dd}"))
               .AddField("SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
               .AddField("SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));
            Console.WriteLine($"ignore message, SRPerDayMsg:{JsonConvert.SerializeObject(message)}");
            return;
        }

        var myItemIds = boxSettings.Select(f => f.ItemID).Distinct().ToList();
        if (items.Count == 0) return;

        //获取当前可以领奖的活动ID，去掉不满足日期的活动ID，取奖励中心和日周月返奖活动的最小活动集合
        myItemIds = items.FindAll(f => myItemIds.Contains(f.ItemID)).Select(f => f.ItemID).ToList();

        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, message.OperatorId);
        var currencyId = sOperatorInfo.CurrencyID;
        //获取当前operatorId下的所有用户ID
        var userIds = await DbUtil.GetRepository<S_userPO>().AsQueryable()
            .Where(f => f.OperatorID == message.OperatorId && f.Status == 1)
            .Select(f => f.UserID).ToListAsync();
        await this.CreateBulkRebateBoxs(message.DayId, myItemIds, userIds, message.OperatorId, currencyId, boxSettings, conditions, vipSettings);

        Console.WriteLine($"SRPerDayMsg:{JsonConvert.SerializeObject(message)},End");
        LogUtil.GetContextLogger()
            .AddField("SrUserDayChangedConsumer.Status", "End")
            .AddField("SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
            .AddField("SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));
    }
    private async Task CreateBulkRebateBoxs(DateTime dayId, List<int> myItemIds, List<string> userIds, string operatorId, string currencyId, List<Sat_rebate_box_configPO> boxSettings, List<Sat_rebate_box_config_linePO> conditions, List<Sat_rebate_box_vipPO> vipSettings)
    {
        var taskDayId = dayId;
        DateTime beginDate = default;
        DateTime endDate = default;
        foreach (var itemId in myItemIds)
        {
            int bulkCount = 1000;
            switch (itemId)
            {
                case 100030:
                    //计算昨天的数据
                    taskDayId = dayId.AddDays(1);
                    beginDate = dayId;
                    endDate = beginDate.AddDays(1);
                    bulkCount = 1000;
                    break;
                case 100031:
                    //计算本周的数据
                    taskDayId = DateTimeUtil.BeginDayOfWeek(dayId).AddDays(7);
                    beginDate = taskDayId.AddDays(-7);
                    endDate = taskDayId;
                    bulkCount = 1000 / 7;
                    break;
                case 100032:
                    //计算本月的数据
                    taskDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);
                    beginDate = taskDayId.AddMonths(-1);
                    endDate = taskDayId;
                    bulkCount = 1000 / 30;
                    break;
            }
            int index = 0;
            var currentUserIds = new List<string>();
            foreach (var userId in userIds)
            {
                //每1000条一个批次，查询用户数据
                if (index < bulkCount)
                {
                    currentUserIds.Add(userId);
                    index++;
                    continue;
                }
                //处理1000条用户返奖宝箱数据
                await this.CreateBulkRebateBoxs(itemId, taskDayId, beginDate, endDate, operatorId, currencyId, currentUserIds, boxSettings, conditions, vipSettings);
                currentUserIds.Clear();
                index = 0;
            }
            //处理不足1000条剩余用户返奖宝箱数据
            if (index > 0)
            {
                await this.CreateBulkRebateBoxs(itemId, taskDayId, beginDate, endDate, operatorId, currencyId, currentUserIds, boxSettings, conditions, vipSettings);
                currentUserIds.Clear();
                index = 0;
            }
        }
    }
    private async Task CreateBulkRebateBoxs(int itemId, DateTime taskDayId, DateTime beginDate, DateTime endDate, string operatorId, string currencyId, List<string> currentUserIds,
         List<Sat_rebate_box_configPO> boxSettings, List<Sat_rebate_box_config_linePO> conditions, List<Sat_rebate_box_vipPO> vipSettings)
    {
        //优先处理上周、上个月的数据，本周、本月的数据，要在上周、上个月的基础上再进行扣减后，计算发放金额
        //日返，就是当天，周月返就是下个周月        
        if (itemId == 100031)
            await this.CreateBulkRebateBox(itemId, taskDayId, operatorId, currencyId, beginDate, endDate, boxSettings, conditions, vipSettings, currentUserIds);
        //如果是每月1号，还要执行上个月的数据
        if (itemId == 100032)
            await this.CreateBulkRebateBox(itemId, taskDayId, operatorId, currencyId, beginDate, endDate, boxSettings, conditions, vipSettings, currentUserIds);

        //处理1000条用户返奖宝箱数据
        DateTime nextTaskDayId = default;
        switch (itemId)
        {
            case 100030:
                //计算昨日的数据
                nextTaskDayId = taskDayId;
                break;
            case 100031:
                //计算本周的数据
                nextTaskDayId = taskDayId.AddDays(7);
                beginDate = taskDayId;
                endDate = beginDate.AddDays(7);
                break;
            case 100032:
                //计算本月的数据
                nextTaskDayId = taskDayId.AddMonths(1);
                beginDate = taskDayId;
                endDate = beginDate.AddMonths(1);
                break;
        }
        await this.CreateBulkRebateBox(itemId, nextTaskDayId, operatorId, currencyId, beginDate, endDate, boxSettings, conditions, vipSettings, currentUserIds);
    }
    private async Task CreateBulkRebateBox(int itemId, DateTime dayId, string operatorId, string currencyId, DateTime beginDate, DateTime endDate,
        List<Sat_rebate_box_configPO> myBoxSettings, List<Sat_rebate_box_config_linePO> conditions, List<Sat_rebate_box_vipPO> vipSettings, List<string> currentUserIds)
    {
        //dayId是数据本身的日期，传过来的日期，作为通知，再根据就那天
        var conditonExpr = Expressionable.Create<Sr_user_dayPO>()
            .And(f => f.OperatorID == operatorId && currentUserIds.Contains(f.UserID))
            .And(f => f.DayID >= beginDate && f.DayID < endDate)
            .ToExpression();
        var userDailyDatas = await DbUtil.GetRepository<Sr_user_dayPO>().AsQueryable()
            .Where(conditonExpr)
            .Select(f => new Sr_user_dayPO
            {
                UserID = f.UserID,
                DayID = f.DayID,
                CurrencyID = f.CurrencyID,
                HasBet = f.HasBet,
                HasPay = f.HasPay,
                HasCash = f.HasCash,
                BetAmount = f.BetAmount,
                BetBonus = f.BetBonus,
                BetCount = f.BetCount,
                WinAmount = f.WinAmount,
                WinBonus = f.WinBonus,
                WinCount = f.WinCount,
                PayAmount = f.PayAmount,
                PayCount = f.PayCount,
                CashAmount = f.CashAmount,
                CashCount = f.CashCount
            })
           .ToListAsync();
        //需要更新下周的最大返奖金额
        var today = DateTime.UtcNow.ToLocalTime(operatorId).Date;
        var yesterday = today.AddDays(-1);
        var weeklyStartDate = DateTimeUtil.BeginDayOfWeek(yesterday);
        var lastMonthlyStartDate = DateTimeUtil.FirstDayOfPreviousMonth(today);
        foreach (var myUserId in currentUserIds)
        {
            var myUserDailyDatas = userDailyDatas.FindAll(f => f.UserID == myUserId);
            //需要更新下周的最大返奖金额
            //过期的数据就不要了，因为已经都发给玩家了，补发会多发之前发的奖励
            if (itemId == 100030 && dayId < yesterday) continue;
            if (itemId == 100031 && dayId < weeklyStartDate) continue;
            if (itemId == 100032 && dayId < lastMonthlyStartDate) continue;

            var myBoxSetting = myBoxSettings.Find(f => f.ItemID == itemId);
            var myConditons = conditions.FindAll(f => f.OperatorID == operatorId && f.ItemID == itemId);
            await this.rebateBoxService.CreateRebateBox(myUserId, itemId, dayId, beginDate, endDate,
                operatorId, currencyId, myBoxSetting, myConditons, vipSettings, myUserDailyDatas);
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
        config.WithPrefetchCount(1);
    }

    protected override Task OnMessage(SRPerDayMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
