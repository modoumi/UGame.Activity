using System.Collections.Generic;

namespace UGame.RewardCenter.API.Models.Dtos;

/// <summary>
/// 奖励中心分组返回对象
/// </summary>
public class RewardGroupDto
{
    /// <summary>
    /// 组ID
    /// </summary>
    public string GroupId { get; set; }
    /// <summary>
    /// 组标题
    /// </summary>
    public string GroupTitle { get; set; }
    /// <summary>
    /// 组内各个活动明细数据
    /// </summary>
    public List<RewardItemDto> Items { get; set; }
}
