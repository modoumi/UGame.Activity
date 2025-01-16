using EasyNetQ;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
using Xxyy.Common.Caching;
using Xxyy.DAL;
using Xxyy.MQ.Xxyy;
using Xxyy.SMS;

namespace UGame.Activity.Tasks.API.Consumers;

public class BindingMobileConsumer : MQBizSubConsumer<ChangeMobileMsg>
{
    public BindingMobileConsumer()
    {
        AddHandler(CreateTask);
        AddHandler(SendSmsMessage);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public async Task CreateTask(ChangeMobileMsg message, CancellationToken cancellationToken)
    {
        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItem = allOperatorItems.Find(f => f.ItemID == 100019 && f.Status == 1);
        if (myOperatorItem == null)
            return;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItem = allItems.Find(f => f.ItemID == 100019 && f.Status == 1);
        if (myItem == null) return;

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTask = allTasks.Find(f => f.ItemID == 100019 && f.Status == 1);
        if (myTask == null) return;

        S_userPO userInfo = null;
        var userCache = await GlobalUserDCache.Create(message.UserId);
        var registerTime = await userCache.GetRegistDateAsync();
        if (!myTask.EffectiveTime.HasValue)
            throw new CustomException("100019任务配置错误，未配置EffectiveTime");
        var mobile = await userCache.GetMobileAsync();
        if (string.IsNullOrEmpty(mobile))
            return;

        //以前注册的，绑定手机号的用户，不生成任务                      
        if (!registerTime.HasValue)
        {
            userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
            if (userInfo == null) return;

            registerTime = userInfo.RegistDate ?? userInfo.RecDate;
        }
        if (registerTime < myTask.EffectiveTime)
            return;

        //用户未注册
        userInfo ??= await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
        if (userInfo.UserMode != (int)UserMode.Register)
            return;
        //手机号为空
        if (string.IsNullOrWhiteSpace(userInfo.Mobile))
            return;

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, message.OperatorId);
        var myTaskReward = allTaskRewards.Find(f => f.ItemID == 100019);
        if (myTaskReward == null) return;

        int count = await DbUtil.GetRepository<Sat_task_detailPO>()
            .CountAsync(f => f.UserID == message.UserId && f.ItemID == 100019);
        if (count > 0) return;

        if (myTaskReward.IsNeedReceive)
        {
            var myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
                .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == myTaskReward.ItemID);
            if (myUserItem != null)
            {
                await DbUtil.GetRepository<Sat_user_itemPO>().AsUpdateable()
                    .SetColumns(f => new Sat_user_itemPO
                    {
                        Value1 = myTaskReward.MaxValue.ToString(),
                        Status = 1,
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
                        ItemID = 100019,
                        DayID = DateTime.Parse("1900-01-01"),
                        OperatorID = message.OperatorId,
                        IsResident = myTask.IsResident,
                        Level = myTaskReward.Level,
                        Deadline = DateTime.Parse("9999-12-31"),
                        //绑定手机号是任务，领奖时会自动按照任务来确定金额，无需设置
                        RewardAmount = 0,
                        Status = 1,
                        RecDate = DateTime.UtcNow,
                        UpdateTime = DateTime.UtcNow,
                        Value1 = myTaskReward.MaxValue.ToString()
                    });
            }
        }
        else
        {
            //不需要领取，直接发放
            long rewardAmount = 0;
            string rewardLinesJson = null;
            if (myTaskReward == null) return;
            if (myTaskReward.IssueRule > 1)
            {
                var allTaskRewardLines = DbCachingUtil.GetList<Sat_task_reward_linePO>(f => f.OperatorID, message.OperatorId);
                var myTaskRewardLines = allTaskRewardLines.FindAll(f => f.ItemID == 100019);
                if (allTaskRewardLines == null)
                    throw new CustomException($"任务100019配置为{myTaskReward.IssueRule},但未配置sat_task_reward_line表数据");
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
                ItemID = 100019,
                DayID = DateTime.Parse("1900-01-01"),
                OperatorID = message.OperatorId,
                Level = myTaskReward.Level,
                Deadline = DateTime.Parse("9999-12-31"),
                RewardType = myTaskReward.RewardType,
                CurrencyID = myTaskReward.CurrencyID,
                FlowMultip = myTaskReward.FlowMultip,
                IssueRule = myTaskReward.IssueRule,
                RewardAmount = myTaskReward.RewardAmount,
                RewardLines = rewardLinesJson,
                RecDate = DateTime.UtcNow
            }, message.AppId, message.CountryId);
        }
    }
    public async Task SendSmsMessage(ChangeMobileMsg message, CancellationToken cancellationToken)
    {
        try
        {
            var userCache = await GlobalUserDCache.Create(message.UserId);
            var url = await userCache.GetRegistClientUrlAsync();
            if (!string.IsNullOrEmpty(url))
            {
                var index = url.IndexOf('/');
                url = url.Substring(0, index);
            }
            var langId = await userCache.GetClientLangId();
            await XxyySmsUtil.SendTemplateAsync(new XxyySmsTemplateIpo
            {
                Mobile = message.Mobile,
                TemplateId = 4,
                //langId暂时先用默认值
                //LangId = langId,
                ContentArgs = new List<object> { url, message.Mobile },
                OperatorId = message.OperatorId
            });
        }
        catch (Exception ex)
        {
            var builder = new LogBuilder(LogLevel.Error, "BindingMobileSendSms");
            builder.AddException(ex).AddField("Source", "BindingMobileConsumer")
                .AddField("Message", JsonConvert.SerializeObject(message));
        }
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(ChangeMobileMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
