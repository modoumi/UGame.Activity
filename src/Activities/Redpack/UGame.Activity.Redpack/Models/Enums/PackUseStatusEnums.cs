using System.ComponentModel;

namespace UGame.Activity.Redpack.Models.Enums;

/// <summary>
/// 使用状态
/// </summary>
public enum PackUseStatusEnums
{
    /// <summary>
    /// 未使用，初始化状态
    /// </summary>
    [Description("未使用，初始化状态")]
    UnUsed = 0,

    /// <summary>
    /// 已使用
    /// </summary>
    [Description("已使用")]
    Used = 1
}
