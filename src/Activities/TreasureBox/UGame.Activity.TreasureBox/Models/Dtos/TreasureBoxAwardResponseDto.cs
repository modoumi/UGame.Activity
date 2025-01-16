namespace UGame.Activity.TreasureBox.Models.Dtos;

/// <summary>
/// 打开宝箱对象
/// </summary>
public class TreasureBoxAwardResponseDto
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
    /// 宝箱完成条件的描述
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 状态 0-不满足条件 1-满足条件
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 是否为Bonus
    /// </summary>
    public bool IsBonus { get; set; }

    /// <summary>
    /// 未完成任务跳转链接
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }
}