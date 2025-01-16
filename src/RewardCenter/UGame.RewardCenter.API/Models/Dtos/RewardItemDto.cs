namespace UGame.RewardCenter.API.Models.Dtos;

/// <summary>
/// 奖励中心组中某一项明细返回对象
/// </summary>
public class RewardItemDto
{
    /// <summary>
    /// 奖励ID
    /// </summary>
    public string RewardId { get; set; }
    /// <summary>
    /// 组ID
    /// </summary>
    public string GroupId { get; set; }
    /// <summary>
    /// 频度 0-非循环类 1-每日 2-每周 3-每月
    /// </summary>
    public int Frequency { get; set; }
    /// <summary>
    /// 组标题
    /// </summary>
    public string GroupTitle { get; set; }
    /// <summary>
    /// 活动ID
    /// </summary>
    public int ItemId { get; set; }
    /// <summary>
    /// 图标地址
    /// </summary>
    public string IconUrl { get; set; }
    /// <summary>
    /// 活动标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 内容模板
    /// </summary>
    public string Template { get; set; }
    /// <summary>
    /// 提示标题
    /// </summary>
    public string TipTitle { get; set; }
    /// <summary>
    /// 提示内容
    /// </summary>
    public string TipContent { get; set; }
    /// <summary>
    /// 提示链接地址
    /// </summary>
    public string TipUrl { get; set; }
    /// <summary>
    /// 行为类型，1-API接口，2-链接地址
    /// </summary>
    public int ActionType { get; set; }
    /// <summary>
    /// 链接地址
    /// </summary>
    public string LinkUrl { get; set; }
    /// <summary>
    /// 领奖ID
    /// </summary>
    public string DetailId { get; set; }
    /// <summary>
    /// 当前活动状态
    /// </summary>
    public int Status { get; set; }
    /// <summary>
    /// 奖励金额，除以10000后的金额
    /// </summary>
    public decimal RewardAmount { get; set; }
    /// <summary>
    /// 按钮名称
    /// </summary>
    public string ButtonName { get; set; }
}
