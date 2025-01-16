using Newtonsoft.Json;
using SActivity.Common.Core;
using SActivity.Common.Ipos;
using SActivity.Common.Utils;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Logging;
using UGame.RewardCenter.API.Models.Dtos;
using UGame.RewardCenter.API.Repositories;
using Xxyy.Common;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;
using Xxyy.MQ.Xxyy;

namespace UGame.RewardCenter.API.Services;

public class RewardCenterService
{
    private RewardCalendarService rewardCalendarService = new RewardCalendarService();
    /// <summary>
    /// 获取奖励列表
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<List<RewardGroupDto>> GetRewardList(LobbyBaseIpo ipo)
    {
        if (string.IsNullOrEmpty(ipo.UserId))
            return null;
        if (string.IsNullOrEmpty(ipo.OperatorId))
            return null;

        //目前，只上长线版本
        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, ipo.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1) return null;

        var rewardItems = await DbUtil.GetRepository<Sat_reward_centerPO>().AsQueryable()
            .InnerJoin<Sat_reward_center_itemPO>((a, b) => a.ItemID == b.ItemID)
            .InnerJoin<Sat_item_operatorPO>((a, b, c) => a.ItemID == c.ItemID && a.OperatorID == c.OperatorID)
            .InnerJoin<Sat_reward_center_item_langPO>((a, b, c, d) => a.ItemID == d.ItemID && c.OperatorID == d.OperatorID && d.LangID == ipo.LangId)
            .InnerJoin<Sat_group_langPO>((a, b, c, d, e) => a.GroupID == e.GroupID && e.LangID == ipo.LangId)
            .Where((a, b, c, d, e) => a.OperatorID == ipo.OperatorId && a.Status == 1 && b.Status == 1 && c.Status == 1)
            .OrderBy((a, b, c, d, e) => new { a.GroupOrder, a.Sequence })
            .Select((a, b, c, d, e) => new RewardItemDto
            {
                ItemId = a.ItemID,
                GroupId = a.GroupID,
                Frequency = b.Frequency,
                GroupTitle = e.Title,
                IconUrl = b.IconUrl,
                Title = d.Title,
                Template = d.Template,
                TipTitle = d.TipTitle,
                TipContent = d.TipContent,
                TipUrl = d.TipUrl,
                ActionType = b.ActionType,
                LinkUrl = b.ActionValue,
                ButtonName = d.ButtonName
            })
            .ToListAsync();

        var dayId = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
        var dailyItemIds = rewardItems.Where(f => f.ActionType == 1 && f.Frequency == 1).Select(f => f.ItemId).ToList();
        var weeklyDayId = DateTimeUtil.BeginDayOfWeek(dayId);
        var weeklyItemIds = rewardItems.Where(f => f.ActionType == 1 && f.Frequency == 2).Select(f => f.ItemId).ToList();
        var monthlyDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);
        var monthlyItemIds = rewardItems.Where(f => f.ActionType == 1 && f.Frequency == 3).Select(f => f.ItemId).ToList();

        var builder = new StringBuilder();
        if (dailyItemIds.Count > 0)
            builder.Append($"(DayID='{dayId:yyyy-MM-dd}' and ItemID in ({string.Join(',', dailyItemIds)}))");
        if (weeklyItemIds.Count > 0)
        {
            if (builder.Length > 0) builder.Append(" OR ");
            builder.Append($"(DayID='{weeklyDayId:yyyy-MM-dd}' and ItemID in ({string.Join(',', weeklyItemIds)}))");
        }
        if (monthlyItemIds.Count > 0)
        {
            if (builder.Length > 0) builder.Append(" OR ");
            builder.Append($"(DayID='{monthlyDayId:yyyy-MM-dd}' and ItemID in ({string.Join(',', monthlyItemIds)}))");
        }
        if (builder.Length > 0)
            builder.Append(')').Insert(0, " and (");
        builder.Insert(0, "select * from sat_reward_center_data where UserID=@UserId");

        //奖励日历，是特殊活动，不是循环活动，只要奖励中心配置有，就会存在，不管今天是否有奖励金额，所以，此处配置不是循环活动
        builder.Append($" UNION ALL select * from sat_reward_center_data where UserID=@UserId and ItemID=100034 and DayID='{dayId:yyyy-MM-dd}'");
        var sql = builder.ToString();

        var waitingDatas = await DbUtil.GetRepository<Sat_reward_center_dataPO>().AsSugarClient()
            .Ado.SqlQueryAsync<Sat_reward_center_dataPO>(sql, new { ipo.UserId });
        var boxItemIds = new int[] { 100030, 100031, 100032 };
        var calendarSettings = await DbUtil.GetRepository<Sat_reward_calendar_itemPO>()
            .GetListAsync(f => f.OperatorID == ipo.OperatorId && f.Status == 1 && boxItemIds.Contains(f.ItemID));

        long totalRewardAmount = 0;
        Sat_reward_calendarPO todayCalendar = null;
        if (rewardItems.Exists(f => f.ItemId == 100034))
        {
            totalRewardAmount = await DbUtil.GetRepository<Sat_reward_calendarPO>().AsQueryable()
                .Where(f => f.UserID == ipo.UserId && f.DayID >= dayId && f.Status < 1)
                .SumAsync(f => f.TotalRewardAmount);
            todayCalendar = await DbUtil.GetRepository<Sat_reward_calendarPO>().AsQueryable()
                .Where(f => f.UserID == ipo.UserId && f.DayID == dayId)
                .FirstAsync();
        }

        foreach (var rewardItem in rewardItems)
        {
            decimal rewardAmount = 0;
            var rewardData = waitingDatas.Find(f => f.ItemID == rewardItem.ItemId);
            if (rewardData != null)
            {
                rewardItem.RewardId = rewardData.RewardID;
                var boxCalendarSetting = calendarSettings.Find(f => f.ItemID == rewardItem.ItemId);
                if (boxCalendarSetting != null)
                {
                    //只显示直发金额，去掉延迟金额
                    var longRewardAmount = (long)(rewardData.RewardAmount - boxCalendarSetting.DelayRate * rewardData.RewardAmount);
                    rewardAmount = longRewardAmount.AToM(ipo.CurrencyId);
                }
                else rewardAmount = rewardData.RewardAmount.AToM(ipo.CurrencyId);

                rewardItem.DetailId = rewardData.DetailID;
                //三个返奖活动的状态，由sr_user_day表更新后的消息消费者来更新，此处只需要直接获取状态即可
                rewardItem.Status = rewardData.Status;

                if (rewardData.ItemID == 100034)
                {
                    rewardAmount = totalRewardAmount.AToM(ipo.CurrencyId);
                    //今日有奖励日历，并且今日金额>0，没有领取过
                    if (todayCalendar != null && todayCalendar.Status < 2 && todayCalendar.TotalRewardAmount > 0)
                        rewardItem.Status = 1;
                }
            }
            //奖励日历的奖励金额是今日以后的所有金额，包括今日
            if (rewardItem.ItemId == 100034)
                rewardAmount = totalRewardAmount.AToM(ipo.CurrencyId);
            rewardItem.IconUrl = IconUtil.GetIcon(rewardItem.IconUrl);
            if (!string.IsNullOrEmpty(rewardItem.Template))
            {
                var templateValue = rewardAmount.ToMoneyString(ipo.CurrencyId);
                rewardItem.Template = rewardItem.Template.Replace("{{rewardAmount}}", templateValue);
            }
        }

        var ret = new List<RewardGroupDto>();
        RewardGroupDto groupDto = null;
        var groupItems = new List<RewardItemDto>();
        foreach (var rewardItem in rewardItems)
        {
            if (groupDto == null || groupDto.GroupId != rewardItem.GroupId)
            {
                groupDto = new RewardGroupDto
                {
                    GroupId = rewardItem.GroupId,
                    GroupTitle = rewardItem.Title,
                    Items = new List<RewardItemDto>()
                };
                ret.Add(groupDto);
            }
            groupDto.Items.Add(rewardItem);
        }
        return ret;
    }
    /// <summary>
    /// 获取奖励日历接口
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    public async Task<RewardCalendarDto> GetCalendar(LobbyBaseIpo ipo)
    {
        if (string.IsNullOrEmpty(ipo.UserId))
            throw new CustomException($"参数不能为null，UserId");
        if (string.IsNullOrEmpty(ipo.OperatorId))
            throw new CustomException($"参数不能为null，OperatorId");

        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, ipo.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1) return null;

        var settings = await DbUtil.GetRepository<Sat_reward_calendar_settingPO>()
            .GetFirstAsync(f => f.OperatorID == ipo.OperatorId);

        var dayId = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
        var beginDate = dayId.AddDays(-settings.HistoryDays);
        var endDate = dayId.AddDays(settings.TotalDays).AddDays(-settings.HistoryDays);

        var calendars = await DbUtil.GetRepository<Sat_reward_calendarPO>().AsQueryable()
             .Where(f => f.UserID == ipo.UserId && f.DayID >= beginDate && f.DayID < endDate)
             .Select(f => new RewardCalendarItemDto
             {
                 CalendarId = f.CalendarID,
                 DayId = f.DayID,
                 RewardAmount = f.TotalRewardAmount,
                 Status = f.Status
             })
             .ToListAsync();
        var histories = new List<RewardCalendarItemDto>();
        var futures = new List<RewardCalendarItemDto>();
        if (calendars.Count > 1)
            calendars.Sort((x, y) => x.DayId.CompareTo(y.DayId));

        var currentDayId = beginDate;
        while (currentDayId < endDate)
        {
            var calendarItem = calendars.Find(f => f.DayId == currentDayId);
            if (calendarItem == null)
            {
                calendarItem = new RewardCalendarItemDto
                {
                    DayId = currentDayId,
                    RewardAmount = 0,
                    Status = 0
                };
            }
            // 金额转换
            else calendarItem.RewardAmount = ((long)calendarItem.RewardAmount).AToM(ipo.CurrencyId);
            if (currentDayId == dayId)
            {
                //今日变为可领取状态
                if (calendarItem.Status <= 1)
                    calendarItem.Status = calendarItem.RewardAmount > 0 ? 1 : 0;
                futures.Add(calendarItem);
            }
            else if (currentDayId < dayId)
            {
                //过期未领取变为已过期状态
                if (calendarItem.Status < 2)
                    calendarItem.Status = 3;
                histories.Add(calendarItem);
            }
            else futures.Add(calendarItem);
            currentDayId = currentDayId.AddDays(1);
        }
        //总金额显示所有可领取金额的总和，但不一定和当前页面的金额总和相等，大于等于当前页面金额总和。
        var totalRewardAmount = await DbUtil.GetRepository<Sat_reward_calendarPO>().AsQueryable()
            .Where(f => f.UserID == ipo.UserId && f.DayID >= dayId && f.Status < 2)
            .SumAsync(f => f.TotalRewardAmount);
        return new RewardCalendarDto
        {
            TotalRewardAmount = totalRewardAmount.AToM(ipo.CurrencyId),
            Histories = histories,
            Futures = futures
        };
    }
    public async Task<decimal> ReceiveCalendarReward(RewardCalendarIpo ipo)
    {
        if (string.IsNullOrEmpty(ipo.UserId))
            throw new CustomException($"参数不能为null，UserId");
        if (string.IsNullOrEmpty(ipo.OperatorId))
            throw new CustomException($"参数不能为null，OperatorId");
        if (string.IsNullOrEmpty(ipo.CalendarId))
            throw new CustomException($"参数不能为null，CalendarId");

        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, ipo.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1)
            throw new CustomException($"领取失败，非长线版本不开放，Versions：{sOperatorInfo.OperatorVersion}");

        using var lockObj = await RedisUtil.LockAsync($"ReceiveRewardCalendar.{ipo.UserId}.{ipo.CalendarId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"Activities01:RewardCenterService.ReceiveRewardCalendar:Request for lock failed.Key:ReceiveRewardCalendar.{ipo.UserId}.{ipo.CalendarId}");
        }
        //不存在或已领取
        var calendarData = await DbUtil.GetRepository<Sat_reward_calendarPO>()
            .GetFirstAsync(f => f.CalendarID == ipo.CalendarId);
        if (calendarData == null)
            throw new CustomException("领取失败，该奖励日历不存在");
        var dayId = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
        if (!(calendarData.DayID == dayId && calendarData.Status <= 1))
            throw new CustomException($"领取失败，该奖励日历不可领取，Status：{calendarData.Status},DayId:{calendarData.DayID}");

        //不是本人领取
        if (calendarData.UserID != ipo.UserId)
            throw new CustomException($"领取失败，非本人领奖");

        Sat_reward_center_dataPO centerData = null;
        var centerSetting = await DbUtil.GetRepository<Sat_reward_center_itemPO>()
           .GetFirstAsync(f => f.ItemID == 100034);
        if (centerSetting != null && centerSetting.Status == 1)
        {
            centerData = await DbUtil.GetRepository<Sat_reward_center_dataPO>()
                .GetFirstAsync(f => f.UserID == ipo.UserId && f.ItemID == 100034 && f.DayID == dayId);
        }
        return await this.ReceiveCalendarReward(ipo.UserId, centerData,
            calendarData, ipo.AppId, ipo.OperatorId, ipo.CurrencyId);
    }
    public async Task<RewardCalendarDetailDto> GetCalendarDetail(RewardCalendarIpo ipo)
    {
        if (string.IsNullOrEmpty(ipo.UserId))
            throw new CustomException($"参数不能为null，UserId");
        if (string.IsNullOrEmpty(ipo.OperatorId))
            throw new CustomException($"参数不能为null，OperatorId");
        if (string.IsNullOrEmpty(ipo.CalendarId))
            throw new CustomException($"参数不能为null，CalendarId");

        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, ipo.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1) return null;

        //不存在或已领取
        var calendar = await DbUtil.GetRepository<Sat_reward_calendarPO>()
            .GetFirstAsync(f => f.CalendarID == ipo.CalendarId);
        if (calendar == null) return null;

        var calendarLines = await DbUtil.GetRepository<Sat_reward_calendar_linePO>().AsQueryable()
            .InnerJoin<Sat_reward_calendar_item_langPO>((a, b) => a.ItemID == b.ItemID && b.LangID == ipo.LangId)
            .Where((a, b) => a.CalendarID == ipo.CalendarId)
            .Select((a, b) => new RewardCalendarLineDto
            {
                Source = b.Title,
                RewardAmount = a.RewardAmount
            })
            .ToListAsync();
        if (calendarLines.Count == 0) return null;

        calendarLines.ForEach(f => f.RewardAmount = ((long)f.RewardAmount).AToM(ipo.CurrencyId));
        return new RewardCalendarDetailDto
        {
            TotalRewardAmount = calendar.TotalRewardAmount.AToM(ipo.CurrencyId),
            Lines = calendarLines
        };
    }
    /// <summary>
    /// 奖励中心领奖，三个日周月返奖活动直发+奖金日历延迟领奖
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public async Task<decimal> ReceiveReward(ReceiveRewardCenterIpo ipo)
    {
        if (string.IsNullOrEmpty(ipo.UserId))
            throw new CustomException($"参数不能为null，UserId");
        if (string.IsNullOrEmpty(ipo.OperatorId))
            throw new CustomException($"参数不能为null，OperatorId");
        if (string.IsNullOrEmpty(ipo.RewardId))
            throw new CustomException($"参数不能为null，RewardId");

        var sOperatorInfo = DbCachingUtil.GetSingle<S_operatorPO>(f => f.OperatorID, ipo.OperatorId);
        if (sOperatorInfo == null || sOperatorInfo.OperatorVersion != 1)
            throw new CustomException($"领取失败，非长线版本不开放，Versions：{sOperatorInfo.OperatorVersion}");

        //不存在或已领取
        var rewardData = await DbUtil.GetRepository<Sat_reward_center_dataPO>()
            .GetFirstAsync(f => f.UserID == ipo.UserId && f.RewardID == ipo.RewardId);

        //不是本人领取
        if (rewardData.UserID != ipo.UserId)
            throw new CustomException($"领取失败，非本人领奖");

        if (rewardData.ItemID == 100034 && rewardData.Status > 1)
            throw new CustomException($"奖励已领取，Status:{rewardData?.Status}");

        if (rewardData.ItemID != 100034 && rewardData.Status != 1)
            throw new CustomException($"奖励不可领取，Status:{rewardData?.Status}");

        var dayId = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date;
        if (rewardData.DayID != dayId)
            throw new CustomException($"领奖日期不正确，不可领取，DayId:{rewardData.DayID:yyyy-MM-dd}");

        using var lockObj = await RedisUtil.LockAsync($"ReceiveRebateBoxReward.{ipo.UserId}.{ipo.RewardId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"Activities01:RewardCenterService.ReceiveRebateBoxReward:Request for lock failed.Key:ReceiveRebateBoxReward.{ipo.UserId}.{ipo.RewardId}");
        }

        decimal result = 0;
        if (rewardData.ItemID == 100034)
        {
            var calendarData = await DbUtil.GetRepository<Sat_reward_calendarPO>()
                .GetFirstAsync(f => f.CalendarID == rewardData.DetailID);
            result = await this.ReceiveCalendarReward(ipo.UserId, rewardData, calendarData, ipo.AppId, ipo.OperatorId, ipo.CurrencyId);
        }
        else result = await this.ReceiveBoxReward(ipo.UserId, rewardData, ipo.AppId, ipo.OperatorId, ipo.CurrencyId);
        return result;
    }
    private async Task<decimal> ReceiveCalendarReward(string userId, Sat_reward_center_dataPO centerData,
        Sat_reward_calendarPO calendarData, string appId, string operatorId, string currencyId)
    {
        var calendarLines = await DbUtil.GetRepository<Sat_reward_calendar_linePO>()
            .GetListAsync(f => f.CalendarID == calendarData.CalendarID);
        if (calendarLines.Count == 0) return 0;
        calendarLines.Sort((x, y) => x.DayID.CompareTo(y.DayID));

        decimal result = 0;
        var tm = new DbTransactionManager();
        try
        {
            await tm.BeginAsync();
            calendarData.Status = 2;
            calendarData.UpdateTime = DateTime.UtcNow;
            await tm.GetRepository<Sat_reward_calendarPO>()
                .AsUpdateable(calendarData)
                .UpdateColumns("Status", "UpdateTime")
                .ExecuteCommandAsync();

            if (centerData != null)
            {
                centerData.Status = 2;
                centerData.UpdateTime = DateTime.UtcNow;
                await tm.GetRepository<Sat_reward_center_dataPO>()
                    .AsUpdateable(centerData)
                    .UpdateColumns("Status", "UpdateTime")
                    .ExecuteCommandAsync();
            }

            int dayIndex = 1;
            var changeMsgs = new List<CurrencyChangeMsg>();
            foreach (var calendarLine in calendarLines)
            {
                var currencyService = new CurrencyChange2Service(userId);
                var currencyChangeReq = new CurrencyChangeReq();
                currencyChangeReq.UserId = userId;
                currencyChangeReq.AppId = appId;
                currencyChangeReq.OperatorId = operatorId;
                currencyChangeReq.CurrencyId = currencyId;
                currencyChangeReq.UserIp = AspNetUtil.GetRemoteIpString();
                currencyChangeReq.Reason = $"奖励日历延迟奖金，活动{calendarLine.ItemID},DetailId:{calendarLine.DetailID}第{calendarLine.DelayIndex}天奖励";
                currencyChangeReq.Amount = calendarLine.RewardAmount;
                currencyChangeReq.SourceType = calendarLine.ItemID;
                currencyChangeReq.SourceTable = "sat_reward_calendar_line";
                currencyChangeReq.SourceId = calendarLine.DetailID;
                currencyChangeReq.ChangeTime = DateTime.UtcNow;
                currencyChangeReq.ChangeBalance = calendarLine.IsBonus ? CurrencyChangeBalance.Bonus : CurrencyChangeBalance.Cash;
                currencyChangeReq.FlowMultip = calendarLine.FlowMultip;
                currencyChangeReq.DbTM = tm;
                var changeMsg = await currencyService.Add(currencyChangeReq);
                changeMsgs.Add(changeMsg);
                dayIndex++;
            }
            result = calendarData.TotalRewardAmount.AToM(currencyId);
            await tm.CommitAsync();

            foreach (var changeMsg in changeMsgs)
            {
                await MQUtil.PublishAsync(changeMsg);
                await MQUtil.PublishAsync(new UserActivityMsg()
                {
                    UserId = userId,
                    ActivityType = changeMsg.SourceType
                });
            }

            //发消息，生成奖金日历任务，任务中心会判断，是否生成
            var taskMessage = new UserTaskCreatingMsg
            {
                UserId = userId,
                ItemId = 100034,
                DayId = calendarData.DayID,
                Deadline = calendarData.DayID.AddDays(1),
                OperatorId = operatorId,
                DetailId = calendarData.CalendarID,
                CurrencyId = currencyId,
                IsBonus = calendarData.IsBonus,
                FlowMultip = calendarData.FlowMultip,
                RewardAmount = calendarData.TotalRewardAmount,
                AppId = appId,
                Status = 2
            };
            await MQUtil.PublishAsync(taskMessage);
            Console.WriteLine(JsonConvert.SerializeObject(taskMessage));
            Console.WriteLine($"UserTaskCreatingMsg，task 100034 completed, taskMessage: {JsonConvert.SerializeObject(taskMessage)}");
            LogUtil.GetContextLogger()
                .AddField("ReceiveCalendarReward.Source", "RewardCenterService.UserTaskCreatingMsg")
                .AddField("ReceiveCalendarReward.UserTaskCreatingMsg", JsonConvert.SerializeObject(taskMessage));
        }
        catch (Exception ex)
        {
            await tm.RollbackAsync();
            result = 0;
            LogUtil.GetContextLogger()
                .AddException(ex)
                .AddField("ReceiveCalendarReward.Source", "RewardCenterService.ReceiveCalendarReward")
                .AddField("ReceiveCalendarReward.center_data", JsonConvert.SerializeObject(centerData))
                .AddField("ReceiveCalendarReward.calendar_data", JsonConvert.SerializeObject(calendarData));
            throw new CustomException("领取失败");
        }
        return result;
    }
    private async Task<decimal> ReceiveBoxReward(string userId, Sat_reward_center_dataPO rewardData, string appId, string operatorId, string currencyId)
    {
        decimal result = 0;
        var boxData = await DbUtil.GetRepository<Sat_rebate_boxPO>()
            .GetSingleAsync(f => f.RewardID == rewardData.DetailID);
        var boxSetting = await DbUtil.GetRepository<Sat_rebate_box_configPO>()
            .GetSingleAsync(f => f.OperatorID == operatorId && f.ItemID == rewardData.ItemID);

        //发放延迟奖励，延迟ID:36,37,38
        var delayItemId = rewardData.ItemID + 6;

        //判断是否在奖励日历有配置直接返奖+延迟返奖
        var calendarSetting = await DbUtil.GetRepository<Sat_reward_calendar_itemPO>()
             .GetFirstAsync(f => f.OperatorID == operatorId && f.ItemID == rewardData.ItemID && f.Status == 1);

        if (calendarSetting == null)
            throw new CustomException($"sat_reward_calendar_item表缺少配置{rewardData.ItemID}活动配置");

        //三个活动都在奖励中心有配置
        long totalDelayRewardAmount = 0, redirectRewardAmount = 0;
        if (calendarSetting != null && calendarSetting.DelayRate > 0)
        {
            //计算直接发放的金额和延迟发放的金额，直接发放的金额，如果有比2位精度还小的数字，则向上取整
            redirectRewardAmount = (long)((1 - calendarSetting.DelayRate) * boxData.RewardAmount);
            redirectRewardAmount = redirectRewardAmount.ToPrecision();
            //有配置延迟发放金额，总金额就变成了直发金额
            totalDelayRewardAmount = boxData.RewardAmount - redirectRewardAmount;
            totalDelayRewardAmount = totalDelayRewardAmount.ToPrecision();
        }
      
        var tm = new DbTransactionManager();
        try
        {
            await tm.BeginAsync();
            rewardData.Status = 2;
            rewardData.RewardAmount = redirectRewardAmount;
            rewardData.UpdateTime = DateTime.UtcNow;
            await tm.GetRepository<Sat_reward_center_dataPO>().AsUpdateable(rewardData)
                .UpdateColumns("Status", "RewardAmount", "UpdateTime")
                .ExecuteCommandAsync();

            boxData.Status = 2;
            boxData.RedirectRewardAmount = redirectRewardAmount;
            boxData.UpdateTime = DateTime.UtcNow;
            await tm.GetRepository<Sat_rebate_boxPO>().AsUpdateable(boxData)
               .UpdateColumns("Status", "RedirectRewardAmount", "UpdateTime")
               .ExecuteCommandAsync();

            var currencyService = new CurrencyChange2Service(userId);
            var currencyChangeReq = new CurrencyChangeReq();
            currencyChangeReq.UserId = userId;
            currencyChangeReq.AppId = appId;
            currencyChangeReq.OperatorId = operatorId;
            currencyChangeReq.CurrencyId = currencyId;
            currencyChangeReq.UserIp = AspNetUtil.GetRemoteIpString();
            currencyChangeReq.Reason = $"返奖宝箱{rewardData.ItemID}活动直发部分奖金，DetailId:{rewardData.RewardID}";
            currencyChangeReq.Amount = redirectRewardAmount;
            currencyChangeReq.SourceType = rewardData.ItemID;
            currencyChangeReq.SourceTable = "sat_rebate_box";
            currencyChangeReq.SourceId = rewardData.DetailID;
            currencyChangeReq.ChangeTime = DateTime.UtcNow;
            currencyChangeReq.ChangeBalance = rewardData.IsBonus ? CurrencyChangeBalance.Bonus : CurrencyChangeBalance.Cash;
            currencyChangeReq.FlowMultip = rewardData.FlowMultip;
            currencyChangeReq.DbTM = tm;
            var changeMsg = await currencyService.Add(currencyChangeReq);
            result = redirectRewardAmount.AToM(currencyId);
           
            await tm.CommitAsync();

            await MQUtil.PublishAsync(changeMsg);
            await MQUtil.PublishAsync(new UserActivityMsg()
            {
                UserId = userId,
                ActivityType = changeMsg.SourceType
            });
        }
        catch (Exception ex)
        {
            await tm.RollbackAsync();
            result = 0;
            LogUtil.GetContextLogger()
                .AddException(ex)
                .AddField("ReceiveBoxReward.Source", "RewardCenterService.ReceiveBoxReward")
                .AddField("ReceiveBoxReward.BoxData", JsonConvert.SerializeObject(boxData));
            Console.WriteLine($"ReceiveBoxReward Error, Detail:{ex},Request: {JsonConvert.SerializeObject(boxData)}");
            throw new CustomException("领取失败");
        }
        if (calendarSetting != null && calendarSetting.DelayRate > 0)
        {
            var beginDate = DateTime.UtcNow.ToLocalTime(operatorId).Date.AddDays(1);
            await rewardCalendarService.CreateCalendarDelayReward(userId, beginDate, delayItemId, currencyId, operatorId, boxData.RewardID,
                calendarSetting.DelayDays, boxSetting.IsBonus, totalDelayRewardAmount, boxSetting.FlowMultip, $"奖励中心宝箱活动{boxData.ItemID}延迟奖励");
        }
        //发消息，生成奖金日历任务，任务中心会判断，是否生成
        var deadline = boxData.DayID;
        switch (boxData.ItemID)
        {
            case 100030: deadline = boxData.DayID.AddDays(1); break;
            case 100031: deadline = boxData.DayID.AddDays(7); break;
            case 100032: deadline = boxData.DayID.AddMonths(1); break;
        }
        var taskMessage = new UserTaskCreatingMsg
        {
            UserId = userId,
            ItemId = boxData.ItemID,
            DayId = boxData.DayID,
            Deadline = deadline,
            OperatorId = operatorId,
            DetailId = boxData.RewardID,
            CurrencyId = currencyId,
            IsBonus = boxData.IsBonus,
            FlowMultip = boxData.FlowMultip,
            RewardAmount = boxData.RewardAmount,
            AppId = appId,
            //日周月返任务已完成，变更状态
            Status = 2
        };
        await MQUtil.PublishAsync(taskMessage);
        Console.WriteLine($"UserTaskCreatingMsg，task {boxData.ItemID} completed, taskMessage: {JsonConvert.SerializeObject(taskMessage)}");
        LogUtil.GetContextLogger()
            .AddField("ReceiveCalendarReward.Source", "RewardCenterService.UserTaskCreatingMsg")
            .AddField("ReceiveCalendarReward.UserTaskCreatingMsg", JsonConvert.SerializeObject(taskMessage));

        return result;
    }
}
