using SActivity.Common.Core;
using SqlSugar;
using System.Text.RegularExpressions;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Tasks.API.Caching;
using UGame.Activity.Tasks.API.Dtos.Requests;
using UGame.Activity.Tasks.API.Dtos.Responses;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.DAL;

namespace UGame.Activity.Tasks.API.Domain.Services;

public class TaskService
{
    public async Task<List<TaskDetailDto>> GetTaskList(string userId, string langId)
        => await this.GenerateTask(userId, langId);
    public async Task<List<TaskTipsResponse>> GetTaskTips(string userId, string operatorId, string currencyId, string langId)
    {
        var myTaskDtos = await this.GenerateTask(userId, langId);
        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();

        //已完成待领取任务的汇总奖金
        decimal drawableTotalAmount = 0, depositTotalAmount = 0, betTotalAmount = 0;
        foreach (var myTaskDto in myTaskDtos)
        {
            if (myTaskDto.Status == 2) continue;
            drawableTotalAmount += myTaskDto.RewardAmount;
            var myTask = allTasks.Find(f => f.ItemID == myTaskDto.ItemID);
            //计算所有充值、存款任务奖励总金额
            switch (myTask.Category)
            {
                case 1: depositTotalAmount += myTaskDto.RewardAmount; break;
                case 2: betTotalAmount += myTaskDto.RewardAmount; break;
            }
        }
        var result = new List<TaskTipsResponse>();
        var myTips = DbCachingUtil.GetList<Sat_tipsPO>(f => f.OperatorID, operatorId);
        myTips = myTips.FindAll(f => f.Status == 1);
        if (myTips == null || myTips.Count == 0) return result;

        var myTipsLangs = DbCachingUtil.GetList<Sat_tips_langPO>(f => new { f.OperatorID, f.LangID }, new Sat_task_langPO
        {
            OperatorID = operatorId,
            LangID = langId
        });
        if (myTipsLangs == null || myTipsLangs.Count == 0) return result;

        var pattern = @"(\{\{(\w+)\}\})";
        if (drawableTotalAmount > 0)
        {
            var myTips1 = myTips.Find(f => f.TipsID == 1);
            var myLangTips1 = myTipsLangs.Find(f => f.TipsID == 1);
            if (myTips1 != null && myLangTips1 != null)
            {
                var template = myLangTips1.Template;
                if (!string.IsNullOrEmpty(template))
                {
                    template = Regex.Replace(template, pattern, match => drawableTotalAmount.ToMoneyString(currencyId));
                    result.Add(new TaskTipsResponse
                    {
                        TipsId = 1,
                        RewardAmount = drawableTotalAmount,
                        Template = template
                    });
                }
            }
        }
        if (depositTotalAmount > 0)
        {
            var myTips2 = myTips.Find(f => f.TipsID == 2);
            var myLangTips2 = myTipsLangs.Find(f => f.TipsID == 2);
            if (myTips2 != null && myLangTips2 != null)
            {
                var template2 = myLangTips2.Template;
                if (!string.IsNullOrEmpty(template2))
                {
                    template2 = Regex.Replace(template2, pattern, match => depositTotalAmount.ToMoneyString(currencyId));
                    result.Add(new TaskTipsResponse
                    {
                        TipsId = 2,
                        RewardAmount = depositTotalAmount,
                        Template = template2
                    });
                }
            }

            var myTips4 = myTips.Find(f => f.TipsID == 4);
            var myLangTips4 = myTipsLangs.Find(f => f.TipsID == 4);
            if (myTips4 != null && myLangTips4 != null)
            {
                var template4 = myLangTips4.Template;
                if (!string.IsNullOrEmpty(template4))
                {
                    template4 = Regex.Replace(template4, pattern, match => depositTotalAmount.ToMoneyString(currencyId));
                    result.Add(new TaskTipsResponse
                    {
                        TipsId = 4,
                        RewardAmount = depositTotalAmount,
                        Template = template4
                    });
                }
            }
        }
        if (betTotalAmount > 0)
        {
            var myTips3 = myTips.Find(f => f.TipsID == 3);
            var myLangTips3 = myTipsLangs.Find(f => f.TipsID == 3);
            if (myTips3 != null && myLangTips3 != null)
            {
                var template3 = myLangTips3.Template;
                if (!string.IsNullOrEmpty(template3))
                {
                    template3 = Regex.Replace(template3, pattern, match => betTotalAmount.ToMoneyString(currencyId));
                    result.Add(new TaskTipsResponse
                    {
                        TipsId = 3,
                        RewardAmount = betTotalAmount,
                        Template = template3
                    });
                }
            }
        }
        return result;
    }
    public async Task<DrawableAmountDto> GetDrawableAmount(string userId, string langId)
    {
        var myTaskDtos = await this.GenerateTask(userId, langId);
        //已完成待领取任务的汇总奖金
        decimal drawableTotalAmount = 0;
        foreach (var myTaskDto in myTaskDtos)
        {
            if (myTaskDto.Status == 2) continue;
            drawableTotalAmount += myTaskDto.RewardAmount;
        }
        var result = new DrawableAmountDto { TotalAmount = drawableTotalAmount };
        //注册送奖励任务是否已领取
        var registerTask = myTaskDtos.Find(f => f.ItemID == 100039);
        //与前端协商，默认给true，没有开启这个任务默认已领
        result.IsRegisterReceived = true;
        if (registerTask != null)
        {
            result.RegisterAmount = registerTask.RewardAmount;
            result.IsRegisterReceived = registerTask.Status == 2;
        }
        return result;
    }
    public async Task ReceiveReward(string userId, string detailId, string appId, string countryId)
    {
        using var lockObj = await RedisUtil.LockAsync($"ReceiveTaskReward.{userId}.{detailId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"lobby:TaskService.ReceiveReward:Request for lock failed.Key:ReceiveTaskReward.{userId}.{detailId}");
        }

        var userItem = await DbUtil.GetRepository<Sat_user_itemPO>().GetFirstAsync(f => f.DetailID == detailId);
        if (userItem == null || userItem.Status != 1)
            throw new CustomException($"领取失败,Status={userItem?.Status}");

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTask = allTasks.Find(f => f.ItemID == userItem.ItemID);
        if (!myTask.IsTask)
            throw new CustomException($"任务{userItem.ItemID}配置为IsTask={myTask.IsTask},不应该调用此接口领奖");

        var userCache = await GlobalUserDCache.Create(userId);
        var operatorId = await userCache.GetOperatorIdAsync();

        int rewardType = 1;
        long rewardAmount = 0;
        string rewardLinesJson = null;
        int flowMultip = 0;
        int issueRule = 0;

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, operatorId);
        var allTaskRewardLines = DbCachingUtil.GetList<Sat_task_reward_linePO>(f => f.OperatorID, operatorId);
        var myTaskReward = allTaskRewards.Find(f => f.ItemID == userItem.ItemID && f.Level == userItem.Level);

        rewardType = myTaskReward.RewardType;
        rewardAmount = myTaskReward.RewardAmount;
        flowMultip = myTaskReward.FlowMultip;
        issueRule = myTaskReward.IssueRule;

        //根据奖励设置，获取奖励金额
        switch (myTaskReward.IssueRule)
        {
            case 1: rewardAmount = myTaskReward.RewardAmount; break;
            case 2:
                //权重，使用alias抽样算法
                if (allTaskRewardLines != null)
                {
                    var myTaskRewardLines = allTaskRewardLines.FindAll(f => f.ItemID == userItem.ItemID && f.Level == userItem.Level);
                    var totalWeight = myTaskRewardLines.Sum(f => f.Weight);
                    var probPrizes = myTaskRewardLines.Select(f => new ProbabilityPrize
                    {
                        Probability = (double)f.Weight / totalWeight,
                        Prize = f.RewardAmount
                    }).ToList();
                    var alaisMethodService = new AliasMethodService(probPrizes);
                    rewardAmount = alaisMethodService.Next<long>();

                    var rewardLines = myTaskRewardLines.Select(f => new { f.Weight, f.RewardAmount }).ToList();
                    if (rewardLines != null && rewardLines.Count > 0)
                        rewardLinesJson = rewardLines.ToJson();
                }
                break;
            case 3:
                if (allTaskRewardLines != null)
                {
                    var myTaskRewardLines = allTaskRewardLines.FindAll(f => f.ItemID == userItem.ItemID && f.Level == userItem.Level);
                    var index = new Random().Next(0, myTaskRewardLines.Count - 1);
                    rewardAmount = myTaskRewardLines[index].RewardAmount;

                    var rewardLines = myTaskRewardLines.Select(f => new { f.Weight, f.RewardAmount }).ToList();
                    if (rewardLines != null && rewardLines.Count > 0)
                        rewardLinesJson = rewardLines.ToJson();
                }
                break;
        }

        var tm = new DbTransactionManager();
        try
        {
            await tm.BeginAsync();
            await tm.GetRepository<Sat_task_detailPO>()
                   .InsertAsync(new Sat_task_detailPO
                   {
                       DetailID = userItem.DetailID,
                       UserID = userItem.UserID,
                       ItemID = userItem.ItemID,
                       DayID = userItem.DayID,
                       OperatorID = operatorId,
                       Level = userItem.Level,
                       Deadline = userItem.Deadline,
                       RewardType = rewardType,
                       CurrencyID = myTaskReward.CurrencyID,
                       FlowMultip = flowMultip,
                       IssueRule = issueRule,
                       RewardAmount = rewardAmount,
                       RewardLines = rewardLinesJson,
                       RecDate = DateTime.UtcNow
                   });

            //非常驻任务，完成后删除,常驻任务，要清空现有任务的状态，奖励ID
            if (myTask.IsResident && myTask.Frequency > 0)
            {
                await tm.GetRepository<Sat_user_itemPO>().AsUpdateable()
                   .SetColumns(f => new Sat_user_itemPO
                   {
                       RewardID = null,
                       Status = 0,
                       Value1 = null,
                       Value2 = null,
                       Value3 = null
                   })
                   .Where(f => f.DetailID == userItem.DetailID)
                   .ExecuteCommandAsync();
            }
            else
            {
                await tm.GetRepository<Sat_user_itemPO>()
                    .DeleteAsync(f => f.DetailID == userItem.DetailID);
            }
            var currencyChangeReq = new CurrencyChangeReq()
            {
                UserId = userId,
                Amount = rewardAmount,
                AppId = appId,
                ChangeTime = DateTime.UtcNow,
                CurrencyId = myTaskReward.CurrencyID,
                OperatorId = operatorId,
                ChangeBalance = rewardType switch
                {
                    1 => CurrencyChangeBalance.Bonus,
                    2 => CurrencyChangeBalance.Cash,
                    //积分
                    _ => CurrencyChangeBalance.None
                },
                FlowMultip = flowMultip,
                DbTM = tm,
                Reason = $"任务{userItem.ItemID}奖励",
                SourceType = userItem.ItemID,
                SourceTable = "sat_task_detail",
                SourceId = detailId
            };
            var currencyChangeService = new CurrencyChange2Service(userId);
            var changedMsg = await currencyChangeService.Add(currencyChangeReq);
            if (changedMsg == null)
                throw new CustomException("写入s_currency_change失败");
            await tm.CommitAsync();
            if (changedMsg != null)
                await MQUtil.PublishAsync(changedMsg);

            //注册类活动，记录IP地址
            if (myTask.Category == 3 || userItem.ItemID == 100039)
            {
                try
                {
                    var userIp = AspNetUtil.GetRemoteIpString();
                    await DbUtil.GetRepository<Sa_ip_recordPO>()
                        .InsertAsync(new Sa_ip_recordPO
                        {
                            ID = ObjectId.NewId(),
                            UserID = userId,
                            ActivityID = userItem.ItemID,
                            CurrencyID = myTaskReward.CurrencyID,
                            Bonus = rewardAmount,
                            CountryId = countryId,
                            FlowMultip = flowMultip,
                            IpAddress = userIp,
                            OperatorID = operatorId,
                            RecDate = DateTime.UtcNow
                        });
                }
                catch
                {
                    //插入重复忽略
                }
            }
        }
        catch (Exception ex)
        {
            await tm.RollbackAsync();
            LogUtil.GetContextLogger().AddException(ex)
                 .AddMessage("ReceiveReward, UserId:{userId},DetailId:{detailId}");
        }
    }
    public async Task DirectReceiveReward(Sat_task_detailPO myTaskDetail, string appId, string countryId)
    {
        using var lockObj = await RedisUtil.LockAsync($"DirectReceiveTaskReward.{myTaskDetail.UserID}.{myTaskDetail.ItemID}.{myTaskDetail.DayID}.{myTaskDetail.Level}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"lobby:TaskService.ReceiveReward:Request for lock failed.Key:DirectReceiveTaskReward.{myTaskDetail.UserID}.{myTaskDetail.ItemID}.{myTaskDetail.DayID}.{myTaskDetail.Level}");
        }

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTask = allTasks.Find(f => f.ItemID == myTaskDetail.ItemID);
        if (!myTask.IsTask)
            throw new CustomException($"任务{myTaskDetail.ItemID}配置为IsTask={myTask.IsTask},不应该调用此接口领奖");

        var userCache = await GlobalUserDCache.Create(myTaskDetail.UserID);
        var operatorId = await userCache.GetOperatorIdAsync();

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, operatorId);
        var allTaskRewardLines = DbCachingUtil.GetList<Sat_task_reward_linePO>(f => f.OperatorID, operatorId);

        var tm = new DbTransactionManager();
        try
        {
            await tm.BeginAsync();
            await tm.GetRepository<Sat_task_detailPO>()
                   .InsertAsync(myTaskDetail);
            var currencyChangeReq = new CurrencyChangeReq()
            {
                UserId = myTaskDetail.UserID,
                Amount = myTaskDetail.RewardAmount,
                AppId = appId,
                ChangeTime = DateTime.UtcNow,
                CurrencyId = myTaskDetail.CurrencyID,
                OperatorId = operatorId,
                ChangeBalance = myTaskDetail.RewardType switch
                {
                    1 => CurrencyChangeBalance.Bonus,
                    2 => CurrencyChangeBalance.Cash,
                    //积分
                    _ => CurrencyChangeBalance.None
                },
                FlowMultip = myTaskDetail.FlowMultip,
                DbTM = tm,
                Reason = $"任务{myTaskDetail.ItemID}奖励",
                SourceType = myTaskDetail.ItemID,
                SourceTable = "sat_task_detail",
                SourceId = myTaskDetail.DetailID
            };
            var currencyChangeService = new CurrencyChange2Service(myTaskDetail.UserID);
            var changedMsg = await currencyChangeService.Add(currencyChangeReq);
            if (changedMsg == null)
                throw new CustomException("写入s_currency_change失败");
            await tm.CommitAsync();
            if (changedMsg != null)
                await MQUtil.PublishAsync(changedMsg);

            //注册类活动，记录IP地址
            if (myTask.Category == 3 || myTaskDetail.ItemID == 100039)
            {
                try
                {
                    var userIp = AspNetUtil.GetRemoteIpString();
                    await DbUtil.GetRepository<Sa_ip_recordPO>()
                        .InsertAsync(new Sa_ip_recordPO
                        {
                            ID = ObjectId.NewId(),
                            UserID = myTaskDetail.UserID,
                            ActivityID = myTaskDetail.ItemID,
                            CurrencyID = myTaskDetail.CurrencyID,
                            Bonus = myTaskDetail.RewardAmount,
                            CountryId = countryId,
                            FlowMultip = myTaskDetail.FlowMultip,
                            IpAddress = userIp,
                            OperatorID = operatorId,
                            RecDate = DateTime.UtcNow
                        });
                }
                catch
                {
                    //插入重复忽略
                }
            }
        }
        catch (Exception ex)
        {
            await tm.RollbackAsync();
            LogUtil.GetContextLogger().AddException(ex)
                 .AddMessage("ReceiveReward, UserId:{userId},DetailId:{detailId}");
        }
    }
    public async Task<List<TaskDetailDto>> GenerateTask(string userId, string langId)
    {

        var result = new List<TaskDetailDto>();

        var userCache = await GlobalUserDCache.Create(userId);
        var operatorId = await userCache.GetOperatorIdAsync();
        var currencyId = await userCache.GetCurrencyIdAsync();
        var dayId = DateTime.UtcNow.ToLocalTime(operatorId).Date;
        var weeklyDayId = DateTimeUtil.BeginDayOfWeek(dayId);
        var monthlyDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);

        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, operatorId);
        var myOperatorItems = allOperatorItems.FindAll(f => f.Status == 1);
        if (myOperatorItems == null || myOperatorItems.Count == 0) return result;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItems = allItems.FindAll(f => f.Status == 1);
        if (myItems == null || myItems.Count == 0) return result;

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTasks = allTasks.FindAll(f => f.Status == 1 && myItems.Exists(t => t.ItemID == f.ItemID)
            && myOperatorItems.Exists(t => t.ItemID == f.ItemID));
        if (myTasks == null || myTasks.Count == 0) return result;

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, operatorId);
        var allTaskRewardLines = DbCachingUtil.GetList<Sat_task_reward_linePO>(f => f.OperatorID, operatorId);
        var myTaskLangs = DbCachingUtil.GetList<Sat_task_langPO>(f => new { f.OperatorID, f.LangID }, new Sat_task_langPO
        {
            OperatorID = operatorId,
            LangID = langId
        });

        var onceItemIds = myTasks.FindAll(f => f.Frequency == 0).Select(f => f.ItemID).ToList();
        var dailyItemIds = myTasks.FindAll(f => f.Frequency == 1).Select(f => f.ItemID).ToList();
        var weeklyItemIds = myTasks.FindAll(f => f.Frequency == 2).Select(f => f.ItemID).ToList();
        var monthlyItemIds = myTasks.FindAll(f => f.Frequency == 3).Select(f => f.ItemID).ToList();

        var taskCondition = Expressionable.Create<Sat_user_itemPO>()
            .OrIF(onceItemIds.Count > 0, f => onceItemIds.Contains(f.ItemID))
            .OrIF(dailyItemIds.Count > 0, f => dailyItemIds.Contains(f.ItemID) && f.DayID == dayId)
            .OrIF(weeklyItemIds.Count > 0, f => weeklyItemIds.Contains(f.ItemID) && f.DayID == weeklyDayId)
            .OrIF(monthlyItemIds.Count > 0, f => monthlyItemIds.Contains(f.ItemID) && f.DayID == monthlyDayId)
            .And(f => f.UserID == userId)
            .ToExpression();
        var myUserItems = await DbUtil.GetRepository<Sat_user_itemPO>()
            .GetListAsync(taskCondition);

        var taskDetailCondition = Expressionable.Create<Sat_task_detailPO>()
            .OrIF(onceItemIds.Count > 0, f => onceItemIds.Contains(f.ItemID))
            .OrIF(dailyItemIds.Count > 0, f => dailyItemIds.Contains(f.ItemID) && f.DayID == dayId)
            .OrIF(weeklyItemIds.Count > 0, f => weeklyItemIds.Contains(f.ItemID) && f.DayID == weeklyDayId)
            .OrIF(monthlyItemIds.Count > 0, f => monthlyItemIds.Contains(f.ItemID) && f.DayID == monthlyDayId)
            .And(f => f.UserID == userId)
            .ToExpression();
        var completedTaskDetails = await DbUtil.GetRepository<Sat_task_detailPO>().AsQueryable()
            .Where(taskDetailCondition).ToListAsync();

        foreach (var myTask in myTasks)
        {
            var myItem = myItems.Find(f => f.ItemID == myTask.ItemID);
            if (myItem == null) continue;
            var myOperatorItem = myOperatorItems.Find(f => f.ItemID == myTask.ItemID);
            if (myOperatorItem == null) continue;

            var minDate = DateTime.Parse("1900-01-01");
            var taskDayId = minDate;
            var deadline = DateTime.MaxValue.AddDays(-1);

            switch (myTask.Frequency)
            {
                case 0:
                    taskDayId = minDate;
                    deadline = DateTime.MaxValue.AddDays(-1);
                    break;
                case 1:
                    taskDayId = dayId;
                    deadline = taskDayId.AddDays(1);
                    break;
                case 2:
                    taskDayId = weeklyDayId;
                    deadline = taskDayId.AddDays(7);
                    break;
                case 3:
                    taskDayId = monthlyDayId;
                    deadline = taskDayId.AddMonths(1);
                    break;
            }
            if (myTask.IsTask)
            {
                var myTaskRewards = allTaskRewards.FindAll(f => f.ItemID == myTask.ItemID);
                //没配置奖励，不生成任务
                if (myTaskRewards == null || myTaskRewards.Count == 0)
                    continue;
                if (myTaskRewards.Count > 1)
                    myTaskRewards.Sort((x, y) => x.Level.CompareTo(y.Level));

                foreach (var myTaskReward in myTaskRewards)
                {
                    string title = null, template = null;
                    long rewardAmount = 0;

                    var myTaskLang = myTaskLangs.Find(f => f.ItemID == myItem.ItemID);
                    if (myTaskLang != null)
                    {
                        title = myTaskLang.Title;
                        template = myTaskLang.Template;
                    }
                    switch (myTaskReward.IssueRule)
                    {
                        case 1:
                            //积分值原值
                            if (myTaskReward.RewardType == 3)
                                rewardAmount = myTaskReward.RewardAmount;
                            else rewardAmount = (long)myTaskReward.RewardAmount.AToM(currencyId);
                            break;
                        case 2:
                        case 3:
                            if (allTaskRewardLines != null)
                            {
                                var myTaskRewardLines = allTaskRewardLines.FindAll(f => f.ItemID == myTask.ItemID && f.Level == myTaskReward.Level);
                                if (myTaskRewardLines == null || myTaskRewardLines.Count == 0)
                                    throw new CustomException($"奖励金额配置错误,ItemId:{myTask.ItemID},IssueRule:{myTaskReward.IssueRule}");
                                //积分值原值
                                if (myTaskReward.RewardType == 3)
                                    rewardAmount = myTaskReward.RewardAmount;
                                else rewardAmount = (long)myTaskRewardLines.Max(f => f.RewardAmount).AToM(currencyId);
                            }
                            break;
                    }
                    var pattern = @"(\{\{(\w+)\}\})";
                    if (!string.IsNullOrEmpty(template))
                    {
                        template = Regex.Replace(template, pattern, match =>
                        {
                            var variableName = match.Groups[2].Value;
                            var tempVariable = $"{{{variableName}}}";
                            switch (variableName.ToLower())
                            {
                                case "minrequiredamount":
                                    if (myTaskReward.MinRequiredAmount.HasValue)
                                    {
                                        var amount = (long)myTaskReward.MinRequiredAmount.Value.AToM(currencyId);
                                        return amount.ToMoneyString(currencyId);
                                    }
                                    break;
                                case "rewardamount": return rewardAmount.ToString();
                            }
                            return tempVariable;
                        });
                    }
                    Sat_user_itemPO myUserItem = null;
                    int currentValue = 0, status = 0;
                    string detailId = null, rewardId = null;

                    if (myTask.Frequency > 0)
                    {
                        var myCompletedTaskDetail = completedTaskDetails.Find(f => f.ItemID == myTask.ItemID
                            && f.DayID == taskDayId && f.Level == myTaskReward.Level);
                        if (myCompletedTaskDetail != null)
                        {
                            if (myTask.IsResident)
                            {
                                detailId = myCompletedTaskDetail.DetailID;
                                status = 2;
                                currentValue = myTaskReward.MaxValue;
                                rewardId = myCompletedTaskDetail.RewardID;
                            }
                            else continue;
                        }
                        myUserItem = myUserItems.Find(f => f.ItemID == myTask.ItemID
                            && f.DayID == taskDayId && f.Level == myTaskReward.Level);
                    }
                    else
                    {
                        if (completedTaskDetails.Exists(f => f.ItemID == myTask.ItemID)) continue;
                        myUserItem = myUserItems.Find(f => f.ItemID == myTask.ItemID);
                    }
                    S_userPO userInfo = null;
                    var registerTime = await userCache.GetRegistDateAsync();
                    if (myTask.ItemID == 100019)
                    {
                        if (!myTask.EffectiveTime.HasValue)
                            throw new CustomException("100019任务配置错误，未配置EffectiveTime");
                        var mobile = await userCache.GetMobileAsync();
                        if (string.IsNullOrEmpty(mobile))
                            continue;

                        //以前注册的，绑定手机号的用户，不生成任务                      
                        if (!registerTime.HasValue)
                        {
                            userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == userId);
                            if (userInfo == null) continue;

                            registerTime = userInfo.RegistDate ?? userInfo.RecDate;
                        }
                        if (registerTime < myTask.EffectiveTime)
                            continue;
                    }
                    //注册时间<任务生效时间，不再生成注册任务
                    if (myTask.Category == 3 || myTask.ItemID == 100039)
                    {
                        if (!myTask.EffectiveTime.HasValue)
                            throw new CustomException($"{myTask.ItemID}任务配置错误，未配置EffectiveTime");
                        if (!registerTime.HasValue)
                        {
                            if (userInfo == null) userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == userId);
                            if (userInfo == null) continue;

                            registerTime = userInfo.RegistDate ?? userInfo.RecDate;
                        }
                        if (registerTime < myTask.EffectiveTime)
                            continue;

                        //判断注册IP地址限制
                        var registerTasks = new int[] { 100007, 100039 };
                        var userIp = AspNetUtil.GetRemoteIpString();
                        var count = await DbUtil.GetRepository<Sa_ip_recordPO>()
                            .CountAsync(f => f.IpAddress == userIp && registerTasks.Contains(f.ActivityID) && f.OperatorID == operatorId);
                        if (count >= myTaskReward.IpLimits)
                            continue;
                    }
                    if (myUserItem != null)
                    {
                        if (!string.IsNullOrEmpty(myUserItem.Value1))
                            currentValue = int.Parse(myUserItem.Value1);
                        detailId = myUserItem.DetailID;
                        rewardId = myUserItem.RewardID;
                        status = myUserItem.Status;
                        //非常驻任务，已完成不再生成
                        if (!myTask.IsResident && status == 2)
                            continue;
                    }

                    //如果是注册类任务，直接完成可以领取奖励
                    if ((myTask.Category == 3 || myTask.ItemID == 100039) && myUserItem == null)
                    {
                        status = 1;
                        currentValue = myTaskReward.MaxValue;

                        detailId = ObjectId.NewId();
                        await DbUtil.GetRepository<Sat_user_itemPO>()
                           .InsertAsync(new Sat_user_itemPO
                           {
                               DetailID = detailId,
                               UserID = userId,
                               ItemID = myTask.ItemID,
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
                    result.Add(new TaskDetailDto
                    {
                        DetailID = detailId,
                        UserID = userId,
                        ItemID = myTask.ItemID,
                        Level = myTaskReward.Level,
                        ActionType = myTask.ActionType,
                        ActionValue = myTask.ActionValue,
                        CurrentValue = currentValue,
                        MaxValue = myTaskReward.MaxValue,
                        InitActionType = myTask.InitActionType,
                        IsTask = myTask.IsTask,
                        IsResident = myTask.IsResident,
                        RewardType = myTaskReward.RewardType,
                        RewardAmount = rewardAmount,
                        RewardID = rewardId,
                        Sequence = myTask.Sequence,
                        Status = status,
                        Title = title,
                        Template = template
                    });
                }
            }
            else
            {
                //非任务，活动，没有金额，没有进度，没有等级，基本都是常驻任务
                Sat_user_itemPO myUserItem = null;
                if (myTask.Frequency > 0)
                {
                    if (completedTaskDetails.Exists(f => f.ItemID == myTask.ItemID && f.DayID == taskDayId)) continue;
                    myUserItem = myUserItems.Find(f => f.ItemID == myTask.ItemID && f.DayID == taskDayId);
                }
                else
                {
                    if (completedTaskDetails.Exists(f => f.ItemID == myTask.ItemID)) continue;
                    myUserItem = myUserItems.Find(f => f.ItemID == myTask.ItemID);
                }

                int currentValue = 0, status = 0;
                long rewardAmount = 0;
                string detailId = null, rewardId = null;
                string title = null, template = null;
                if (myUserItem != null)
                {
                    if (!string.IsNullOrEmpty(myUserItem.Value1))
                        currentValue = int.Parse(myUserItem.Value1);
                    detailId = myUserItem.DetailID;
                    rewardId = myUserItem.RewardID;
                    if (myUserItem.RewardAmount > 0)
                        rewardAmount = (long)myUserItem.RewardAmount.AToM(currencyId);
                    status = myUserItem.Status;

                    //非常驻任务，已完成不再生成
                    if (!myTask.IsResident && status == 2)
                        continue;
                }
                var myTaskLang = myTaskLangs.Find(f => f.ItemID == myItem.ItemID);
                if (myTaskLang != null)
                {
                    title = myTaskLang.Title;
                    template = myTaskLang.Template;
                }
                result.Add(new TaskDetailDto
                {
                    DetailID = detailId,
                    UserID = userId,
                    ItemID = myTask.ItemID,
                    Level = 0,
                    ActionType = myTask.ActionType,
                    ActionValue = myTask.ActionValue,
                    CurrentValue = currentValue,
                    MaxValue = 1,
                    InitActionType = myTask.InitActionType,
                    IsTask = myTask.IsTask,
                    IsResident = myTask.IsResident,
                    //默认值：bonus，后续会下掉奖励中心等其他任务
                    RewardType = 1,
                    RewardAmount = rewardAmount,
                    RewardID = rewardId,
                    Sequence = myTask.Sequence,
                    Status = status,
                    Title = title,
                    Template = template
                });
            }
        }
        result.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
        return result;
    }
    /// <summary>
    /// 领取Apk下载，领取奖励前，预处理
    /// </summary>
    /// <returns></returns>
    public async Task<ReceiveTaskRewardResponse> PreApkDownLoadReward(PreApkTaskRewardRequest ipo)
    {
        var result = new ReceiveTaskRewardResponse { Code = 401, Success = false };

        using var lockObj = await RedisUtil.LockAsync($"PreApkDownLoadReward.{ipo.UserId}.{ipo.DeviceId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"lobby:TaskService.PreApkDownLoadReward:Request for lock failed.Key:PreApkDownLoadReward.{ipo.UserId}.{ipo.DeviceId}");
        }

        //查询用户CPF
        var userBanksDCache = new BraUserBankDCache(ipo.OperatorId, ipo.UserId);
        var cacheData = await userBanksDCache.GetAsync();
        var cpf = string.Empty;
        if (cacheData.HasValue)
            cpf = cacheData.Value.FirstOrDefault()?.TaxId;
        else
        {
            var braUserBank = await DbUtil.GetRepository<L_bra_user_bankPO>().GetFirstAsync(f => f.UserID == ipo.UserId && f.OperatorID == ipo.OperatorId && f.AccountType == "CPF");
            if (braUserBank != null) cpf = braUserBank?.TaxId;
        }

        var userIp = AspNetUtil.GetRemoteIpAddress().ToString();
        var userTimes = await DbUtil.GetRepository<Sa_apk_recordPO>().CountAsync(f => f.UserId == ipo.UserId && f.Status == 2);
        if (userTimes >= 1)//判断是否已经领取过
        {
            result.Message = "Already Claim";
            return result;
        }

        var query2 = await DbUtil.GetRepository<Sa_apk_recordPO>().GetListAsync(f => f.IP == userIp || f.DeviceId == ipo.DeviceId || f.TaxId == cpf);

        var ipTimes = query2.Where(_ => _.IP == userIp).Count();
        var deviceTimes = query2.Where(_ => _.DeviceId == ipo.DeviceId).Count();
        var cpfTimes = !string.IsNullOrEmpty(cpf) && !string.IsNullOrWhiteSpace(cpf) ? query2.Where(_ => _.TaxId == cpf).Count() : 0;

        if (deviceTimes >= 1) //判断设备Id限制
            result.Message = "This Divice Already Claim";
        else if (cpfTimes >= 1)
            result.Message = "This CPF Already Claim";
        else if (ipTimes >= 3) //判断IP限制            
            result.Message = "This IP Already Claim More 3 Times";
        else
        {
            //以上条件都满足，则领取奖励
            var itemId = 100018;
            var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
            var myTask = allTasks.Find(f => f.ItemID == itemId);
            if (myTask == null || myTask.Status != 1) return result;
            var count = await DbUtil.GetRepository<Sat_task_detailPO>()
                .CountAsync(f => f.UserID == ipo.UserId && f.ItemID == 100018);
            if (count > 0) return result;

            var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, ipo.OperatorId);
            var myTaskReward = allTaskRewards.Find(f => f.ItemID == itemId);
            var detailId = ObjectId.NewId();

            var myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
                .GetFirstAsync(f => f.UserID == ipo.UserId && f.ItemID == 100018);
            if (myUserItem == null)
            {
                await DbUtil.GetRepository<Sat_user_itemPO>()
                   .InsertAsync(new Sat_user_itemPO
                   {
                       DetailID = detailId,
                       UserID = ipo.UserId,
                       ItemID = 100018,
                       DayID = DateTime.Parse("1900-01-01"),
                       OperatorID = ipo.OperatorId,
                       Level = 0,
                       Deadline = DateTime.MaxValue.AddDays(-1),
                       IsResident = myTask.IsResident,
                       RewardAmount = myTaskReward.RewardAmount,
                       Status = 1,
                       Value1 = myTaskReward.MaxValue.ToString(),
                       RecDate = DateTime.UtcNow,
                       UpdateTime = DateTime.UtcNow
                   });
            }
            else
            {
                detailId = myUserItem.DetailID;
                myUserItem.Status = 1;
                myUserItem.Value1 = myTaskReward.MaxValue.ToString();
                myUserItem.UpdateTime = DateTime.UtcNow;
                await DbUtil.GetRepository<Sat_user_itemPO>().UpdateAsync(myUserItem);
            }
            await this.ReceiveReward(ipo.UserId, detailId, ipo.AppId, ipo.CountryId);
            result.Success = true;
            result.Code = 200;
        }
        return result;
    }
}
