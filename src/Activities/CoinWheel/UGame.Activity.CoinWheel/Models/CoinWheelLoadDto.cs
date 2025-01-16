using Serilog;

namespace UGame.Activity.CoinWheel.Models;

public class CoinWheelLoadDto
{
    /// <summary>
    /// 可抽奖次数
    /// </summary>
    public int PlayNumbers { get; set; } = 0;

    /// <summary>
    /// 用户积分余额
    /// </summary>
    public long TotalCoin { get; set; } = 0;

    /// <summary>
    /// 抽奖消耗积分
    /// </summary>
    public int ExtraCoin { get; set; }
}
