using System.ComponentModel;

namespace UGame.Activity.Redpack.Models.Enums;

/// <summary>
/// 任务类型
/// </summary>
public enum TaskCategoryEnums
{
    /// <summary>
    /// 新用户注册
    /// </summary>
    [Description("新用户注册")]
    NewUser = 1,

    /// <summary>
    /// 分享
    /// </summary>
    [Description("分享")]
    Shared = 2,

    /// <summary>
    /// 下注
    /// </summary>
    [Description("下注")]
    Bet = 3,

    /// <summary>
    /// 下载客户端
    /// </summary>
    [Description("下载客户端")]
    DownloadApp = 4,

    /// <summary>
    /// 充值
    /// </summary>
    [Description("充值")]
    Pay = 5,
}
