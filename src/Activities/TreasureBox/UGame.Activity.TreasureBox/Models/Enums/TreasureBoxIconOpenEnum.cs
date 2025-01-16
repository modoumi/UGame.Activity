using System.ComponentModel;

namespace UGame.Activity.TreasureBox.Models.Enums;

/// <summary>
/// 宝箱图标
/// </summary>
public enum TreasureBoxIconOpenEnum
{
    /// <summary>
    /// 未打开状态
    /// </summary>
    [Description("未打开状态")]
    UnOpen = 0,

    /// <summary>
    /// 打开状态
    /// </summary>
    [Description("打开状态")] 
    Open = 1,
}