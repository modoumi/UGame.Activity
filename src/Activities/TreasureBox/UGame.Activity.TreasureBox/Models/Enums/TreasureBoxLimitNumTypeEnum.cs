using System.ComponentModel;

namespace UGame.Activity.TreasureBox.Models.Enums;

/// <summary>
/// 宝箱打开限制
/// </summary>
public enum TreasureBoxLimitNumTypeEnum
{
    /// <summary>
    /// 无限制
    /// </summary>
    [Description("无限制")]
    NoLimit = 0,

    /// <summary>
    /// 有限制
    /// </summary>
    [Description("有限制")]
    HashLimit = 1,
}
