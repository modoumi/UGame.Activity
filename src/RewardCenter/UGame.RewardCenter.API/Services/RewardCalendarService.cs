using SqlSugar;
using System;
using System.Linq;
using System.Threading.Tasks;
using TinyFx.Data.SqlSugar;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.RewardCenter.API.Repositories;
using Xxyy.Common;

namespace UGame.RewardCenter.API.Services;

public class RewardCalendarService
{
    public async Task CreateCalendarDelayReward(string userId, DateTime beginDate, int itemId, string currencyId, string operatorId,
        string detailId, int delayDays, bool isBonus, long delayTotalRewardAmount, float flowMultip, string reason)
    {
        //如果该活动还有延迟奖金，则往奖励日历中添加延迟奖金日历
        var endDate = beginDate.AddDays(delayDays);
        var calendars = await DbUtil.GetRepository<Sat_reward_calendarPO>()
            .GetListAsync(f => f.UserID == userId && f.DayID >= beginDate && f.DayID < endDate);

        //缺失的日历要先生成，方便后面+Amount操作，直接插入带有金额的操作会有并发问题，丢失金额数据
        if (calendars.Count < delayDays)
        {
            var delayDate = beginDate.AddDays(calendars.Count);
            while (delayDate < endDate)
            {
                var newCalender = new Sat_reward_calendarPO
                {
                    CalendarID = ObjectId.NewId(),
                    UserID = userId,
                    DayID = delayDate,
                    CurrencyID = currencyId,
                    IsBonus = isBonus,
                    FlowMultip = flowMultip,
                    TotalRewardAmount = 0,
                    Status = 0,
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                };
                calendars.Add(newCalender);
                try
                {
                    await DbUtil.GetRepository<Sat_reward_calendarPO>().InsertAsync(newCalender);
                }
                catch
                {
                    //并发插入重复，忽略                      
                }
                delayDate = delayDate.AddDays(1);
            }
        }

        //按照时间排序
        calendars.Sort((x, y) => x.DayID.CompareTo(y.DayID));
        //延迟奖金总金额
        var avgAmount = delayTotalRewardAmount / delayDays;
        var ceilingAmount = avgAmount;
        var ceilingDays = 0;
        var hasLowPrecision = this.HasLowPrecision(avgAmount, 2, out var floorAvgAmount);
        if (hasLowPrecision)
        {
            ceilingDays = (int)((delayTotalRewardAmount - floorAvgAmount * delayDays) / Math.Pow(10, 2));
            ceilingAmount = floorAvgAmount + 1M.MToA(currencyId) / (long)Math.Pow(10, 2);
        }
        int dayIndex = 0;
        while (dayIndex < delayDays)
        {
            var calendar = calendars[dayIndex];
            var lineId = ObjectId.NewId();
            //当天延迟奖金金额
            //如果有低于精度的小数，在越靠前的延迟天内，进行向上取整到两位精度，精确到分
            long delayRewardAmount = floorAvgAmount;
            if (hasLowPrecision && dayIndex < ceilingDays)
                delayRewardAmount = ceilingAmount;
            if (!string.IsNullOrEmpty(detailId))
            {
                //延期的日期会有重叠，所有UserId+ItemId+DayId+DetailId才能确定唯一，兑换码和三个日周月返奖都一样
                var count1 = await DbUtil.GetRepository<Sat_reward_calendar_linePO>()
                    .AsQueryable().CountAsync(f => f.UserID == userId && f.DayID == calendar.DayID && f.ItemID == itemId && f.DetailID == detailId);
                if (count1 > 0)
                {
                    dayIndex++;
                    continue;
                }
            }

            try
            {
                await DbUtil.GetRepository<Sat_reward_calendar_linePO>()
                    .InsertAsync(new Sat_reward_calendar_linePO
                    {
                        LineID = lineId,
                        CalendarID = calendar.CalendarID,
                        DetailID = detailId,
                        UserID = userId,
                        DayID = calendar.DayID,
                        ItemID = itemId,
                        CurrencyID = currencyId,
                        Level = 0,//TODO:暂时没有等级
                        IsBonus = isBonus,
                        FlowMultip = flowMultip,
                        DelayIndex = dayIndex + 1,
                        Remark = reason,
                        RewardAmount = delayRewardAmount,
                        RecDate = DateTime.UtcNow
                    });
            }
            catch (Exception ex)
            {
                //并发插入忽略
                LogUtil.GetContextLogger().AddException(ex)
                    .AddField("GenerateRewardCalendarData.FlagId", "sat_reward_calendar_line")
                    .AddField("GenerateRewardCalendarData.ItemId", itemId)
                    .AddField("GenerateRewardCalendarData.DetailId", detailId);
            }
            dayIndex++;
        }
        try
        {
            //更新奖励日历可领取金额，都是明天以后的金额，包括明天
            var calendarIds = calendars.Select(f => f.CalendarID).Distinct().ToList();
            await DbUtil.GetRepository<Sat_reward_calendarPO>().AsUpdateable()
                .Where(f => f.UserID == userId && calendarIds.Contains(f.CalendarID))
                .SetColumns(it => new Sat_reward_calendarPO()
                {
                    TotalRewardAmount = SqlFunc.Subqueryable<Sat_reward_calendar_linePO>()
                        .Where(f => f.CalendarID == it.CalendarID)
                        .Sum(f => f.RewardAmount),
                    UpdateTime = DateTime.UtcNow
                })
                .ExecuteCommandAsync();
        }
        catch (Exception ex)
        {
            //并发插入忽略
            LogUtil.GetContextLogger().AddException(ex)
                .AddField("GenerateRewardCalendarData.FlagId", "sat_reward_calendar")
                .AddField("GenerateRewardCalendarData.ItemId", itemId)
                .AddField("GenerateRewardCalendarData.DetailId", detailId);
        }
        var count = await DbUtil.GetRepository<Sat_reward_center_itemPO>().AsQueryable()
           .InnerJoin<Sat_reward_centerPO>((a, b) => a.ItemID == b.ItemID && b.OperatorID == operatorId)
           .InnerJoin<Sat_item_operatorPO>((a, b, c) => a.ItemID == c.ItemID && c.OperatorID == operatorId)
           .Where((a, b, c) => a.Status == 1 && b.Status == 1 && c.Status == 1 && a.ItemID == 100034)
           .CountAsync();
        if (count == 0) return;

        foreach (var calendar in calendars)
        {
            try
            {
                count = await DbUtil.GetRepository<Sat_reward_center_dataPO>()
                   .AsQueryable().CountAsync(f => f.UserID == userId && f.DayID == calendar.DayID && f.ItemID == 100034 && f.DetailID == calendar.CalendarID);
                if (count > 0) continue;

                await DbUtil.GetRepository<Sat_reward_center_dataPO>()
                   .InsertAsync(new Sat_reward_center_dataPO
                   {
                       RewardID = ObjectId.NewId(),
                       UserID = userId,
                       DayID = calendar.DayID,
                       CurrencyID = currencyId,
                       DetailID = calendar.CalendarID,
                       FlowMultip = flowMultip,
                       IsBonus = isBonus,
                       ItemID = 100034,
                       OperatorID = operatorId,
                       RewardAmount = 0,
                       Status = 0,
                       RecDate = DateTime.UtcNow,
                       UpdateTime = DateTime.UtcNow
                   });
            }
            catch (Exception ex)
            {
                //已存在，忽略
                LogUtil.GetContextLogger().AddException(ex)
                    .AddField("GenerateRewardCalendarData.FlagId", "sat_reward_center_insert")
                    .AddField("GenerateRewardCalendarData.ItemId", 100034)
                    .AddField("GenerateRewardCalendarData.DetailId", calendar.CalendarID);
            }
        }
        try
        {
            await DbUtil.GetRepository<Sat_reward_center_dataPO>().AsUpdateable()
                .Where(f => f.UserID == userId && f.ItemID == 100034)
                .SetColumns(it => new Sat_reward_center_dataPO()
                {
                    RewardAmount = SqlFunc.Subqueryable<Sat_reward_calendarPO>()
                         .Where(f => f.UserID == it.UserID && f.DayID == it.DayID)
                         .Sum(f => f.TotalRewardAmount),
                    UpdateTime = DateTime.UtcNow
                })
                .ExecuteCommandAsync();
        }
        catch (Exception ex)
        {
            //已存在，忽略
            LogUtil.GetContextLogger().AddException(ex)
                .AddField("GenerateRewardCalendarData.FlagId", "sat_reward_center_update")
                .AddField("GenerateRewardCalendarData.ItemId", 100034);
        }
    }
    /// <summary>
    /// 是否有低于精度的金额
    /// </summary>
    /// <param name="rewardAmount">奖励Amount</param>
    /// <param name="precision">精度，小数点位数</param>
    /// <param name="floorAmount">按照精度precision，向下取整Amount金额</param>
    /// <returns></returns>
    private bool HasLowPrecision(long rewardAmount, int precision, out long floorAmount)
    {
        floorAmount = rewardAmount;
        int powTimes = (int)Math.Pow(10, precision);
        var decimalAmount = (decimal)rewardAmount / powTimes;
        var hasDecimal = decimalAmount > Math.Floor(decimalAmount);
        if (hasDecimal) floorAmount = (long)Math.Floor(decimalAmount) * powTimes;
        return hasDecimal;
    }
}
