using System.ComponentModel;

namespace UGame.Activity.Banky.Modelsp;

public enum BankyStatusEnum
{
    [Description("初始值")]
    Initial,

    [Description("进行中")]
    InProgress,

    [Description("已完成")]
    Completed,

    [Description("提现清零")]
    ReSet
}

public enum StatusEnum
{
    [Description("无效的")]
    Invalid,

    [Description("正常的")]
    Normal
}
