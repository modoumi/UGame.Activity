namespace UGame.Activity.TreasureBox.Models.Enums;

/// <summary>
/// 宝箱打开条件
/// </summary>
public enum TreasureBoxOpenTypeEnum
{
    /// <summary>
    /// 直接打开
    /// </summary>
    UnconditionalOpen = 1,

    /// <summary>
    /// 累计存款
    /// </summary>
    AccumulatedDeposits = 2,

    /// <summary>
    /// 单笔存款
    /// </summary>
    SingleDeposits = 3,

    /// <summary>
    /// 累计下注
    /// </summary>
    AccumulatedBet = 4,

    /// <summary>
    /// 净盈利
    /// </summary>
    NetProfit = 5,

    /// <summary>
    /// 净亏损
    /// </summary>
    NetLoss = 6,

    /// <summary>
    /// 邀请好友注册
    /// </summary>
    InviteFriendRegister = 7,

    /// <summary>
    /// 邀请好友存款
    /// </summary>
    InviteFriendPay = 8,

    /// <summary>
    /// 邀请好友下注
    /// </summary>
    InviteFriendBet = 9,

    /// <summary>
    /// VIP等级
    /// </summary>
    VIPLevel = 10

}
