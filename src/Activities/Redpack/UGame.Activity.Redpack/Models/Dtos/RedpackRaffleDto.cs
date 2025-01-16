namespace UGame.Activity.Redpack.Models.Dtos;

/// <summary>
/// 红包返回对象
/// </summary>
public class RedpackRaffleDto
{
    /// <summary>
    /// 抽奖金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 当前获奖金额
    /// </summary>
    public decimal PrizeAmount { get; set; }

    /// <summary>
    /// 奖金总额
    /// </summary>
    public decimal PackAmount { get; set; }

    /// <summary>
    /// 剩余抽奖次数
    /// </summary>
    public int RemainingNum { get; set; }

    /// <summary>
    /// 红包Flag
    /// </summary>
    public int PackFlag { get; set; }

    /// <summary>
    /// 非首开剩余时间(秒)
    /// </summary>
    public double? LastTime { get; set; }
}