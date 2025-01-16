using System.ComponentModel;

namespace UGame.Activity.CoinWheel.Models;

public enum WheelEnums
{
    [Description("Bonus")]
    Bonus = 0,

    [Description("Cash")]
    Cash = 1,

    [Description("Coin")]
    Coin = 2
}


public enum WheelStatus
{
    [Description("无效")]
    Invalid = 0,

    [Description("有效")]
    Valid = 1
}
