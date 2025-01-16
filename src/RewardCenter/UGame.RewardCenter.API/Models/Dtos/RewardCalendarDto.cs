using System;
using System.Collections.Generic;

namespace UGame.RewardCenter.API.Models.Dtos;

/// <summary>
/// 奖励日历返回对象
/// </summary>
public class RewardCalendarDto
{
    /// <summary>
    /// 今天+以后总的可领取金额，除以10000以后的金额
    /// </summary>
    public decimal TotalRewardAmount { get; set; }
    /// <summary>
    /// 历史日历数据
    /// </summary>
    public List<RewardCalendarItemDto> Histories { get; set; }
    /// <summary>
    /// 今日+以后日历数据
    /// </summary>
    public List<RewardCalendarItemDto> Futures { get; set; }
}
/// <summary>
/// 奖励日历某一天项对象
/// </summary>
public class RewardCalendarItemDto
{
    /// <summary>
    /// 日历ID
    /// </summary>
    public string CalendarId { get; set; }
    /// <summary>
    /// 日期
    /// </summary>
    public DateTime DayId { get; set; }
    /// <summary>
    /// 奖励金额，除以10000以后的金额
    /// </summary>
    public decimal RewardAmount { get; set; }
    /// <summary>
    /// 状态，0-待领取 1-可领取 2-已领取 3-已过期(历史日历中的数据状态)
    /// </summary>
    public int Status { get; set; }
}
