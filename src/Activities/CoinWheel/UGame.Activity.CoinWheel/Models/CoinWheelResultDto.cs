namespace UGame.Activity.CoinWheel.Models;

public class CoinWheelResultDto
{
    /// <summary>
    /// 转盘位置
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// 奖励值
    /// </summary>
    public decimal Reward { get; set; }

    /// <summary>
    /// 奖励类型
    /// </summary>
    public int RewardType { get; set; }

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
