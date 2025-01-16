using System.ComponentModel;

namespace UGame.Activity.TreasureBox.Models.Enums;

/// <summary>
/// 发放枚举
/// </summary>
public enum TreasureBoxGrantTypeEnum
{
    /// <summary>
    /// 免费发放
    /// </summary>
    [Description("免费发放")]
    Free = 0,

    /// <summary>
    /// 购买
    /// </summary>
    [Description("购买")]
    Bug = 1,

    /// <summary>
    /// 注册
    /// </summary>
    [Description("注册")]
    Register = 2,

    /// <summary>
    /// 绑定手机
    /// </summary>
    [Description("绑定手机")]
    BindMobile = 3,

    /// <summary>
    /// 每日登录
    /// </summary>
    [Description("每日登录")]
    Login = 4,

    /// <summary>
    /// 首次存款
    /// </summary>
    [Description("首次存款")]
    FirstPay = 5,

    /// <summary>
    /// 累计存款额
    /// </summary>
    [Description("累计存款额")]
    CumulativePay = 6,

    /// <summary>
    /// 累计下注额
    /// </summary>
    [Description("累计下注额")]
    CumulativeBets = 7,

    /// <summary>
    /// VIP等级
    /// </summary>
    [Description("VIP等级")]
    VipLevel = 8,

    /// <summary>
    /// 每次下注额
    /// </summary>
    [Description("每次下注额")]
    PerUserBet = 9,

    /// <summary>
    /// 每日下注额
    /// </summary>
    [Description("每日下注额")]
    PerDayUserBet = 10,
}