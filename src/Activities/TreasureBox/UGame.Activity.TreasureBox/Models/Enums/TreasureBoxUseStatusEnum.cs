using System.ComponentModel;

namespace UGame.Activity.TreasureBox.Models.Enums;

public enum TreasureBoxUseStatusEnum
{
    /// <summary>
    /// 未使用
    /// </summary>
    [Description("未使用")]
    UnUse = 0,

    /// <summary>
    /// 已使用
    /// </summary>
    [Description("已使用")]
    Use = 1
}
