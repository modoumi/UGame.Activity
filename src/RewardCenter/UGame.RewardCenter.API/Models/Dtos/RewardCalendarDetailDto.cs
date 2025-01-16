using System.Collections.Generic;

namespace UGame.RewardCenter.API.Models.Dtos;

/// <summary>
/// 奖励日历明细返回对象
/// </summary>
public class RewardCalendarDetailDto
{
    /// <summary>
    /// 今天总的可领取金额，除以10000以后的金额
    /// </summary>
    public decimal TotalRewardAmount { get; set; }
    /// <summary>
    /// 历史日历数据
    /// </summary>
    public List<RewardCalendarLineDto> Lines { get; set; }
}
/// <summary>
/// 奖励日历明细行对象
/// </summary>
public class RewardCalendarLineDto
{
    /// <summary>
    /// 延迟奖金来源
    /// </summary>
    public string Source { get; set; }
    /// <summary>
    /// 延迟奖金金额
    /// </summary>
    public decimal RewardAmount { get; set; }
}
