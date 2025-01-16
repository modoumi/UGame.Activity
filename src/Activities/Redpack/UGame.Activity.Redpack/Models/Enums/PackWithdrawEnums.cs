using System.ComponentModel;

namespace UGame.Activity.Redpack.Models.Enums;

public enum PackWithdrawEnums
{
    /// <summary>
    /// 未提现
    /// </summary>
    [Description("未提现")]
    NoWithdraw = 0,

    /// <summary>
    /// 已提现
    /// </summary>
    [Description("已提现")]
    Withdraw = 1
}
