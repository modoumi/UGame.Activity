using UGame.Activity.TreasureBox.Models.Enums;

namespace UGame.Activity.TreasureBox.Models.Dtos;

/// <summary>
/// 宝箱对象
/// </summary>
public class TreasureBoxResponseDto
{
    /// <summary>
    /// 主键
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 宝箱名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 宝箱备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 奖励描述
    /// </summary>
    public string AwardRemark { get; set; }

    /// <summary>
    /// 是否有效宝箱
    /// </summary>
    public bool IsEffective { get; set; }

    /// <summary>
    /// 截止日期 (本地时间)
    /// </summary>
    public DateTime ExpiryDateTime { get; set; }
}