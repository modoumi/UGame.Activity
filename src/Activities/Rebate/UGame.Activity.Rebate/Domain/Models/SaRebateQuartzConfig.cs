namespace UGame.Activity.Rebate.Domain.Models;

/// <summary>
/// 定时任务返点活动配置表
/// </summary>
public class SaRebateQuartzConfig
{
    /// <summary>
    /// 主键
    /// </summary>
    public int ConfigID { get; set; }
    /// <summary>
    /// 运营商编码
    /// </summary>
    public string OperatorID { get; set; }
    /// <summary>
    /// 货币类型
    /// </summary>
    public string CurrencyID { get; set; }
    /// <summary>
    /// 活动id
    /// </summary>
    public int ActivityID { get; set; }
    /// <summary>
    /// 国家编码ISO 3166-1三位字母 
    /// </summary>
    public string CountryID { get; set; }
    /// <summary>
    /// 返奖比例
    /// </summary>
    public float RewardRatio { get; set; }
    /// <summary>
    /// 奖励发放最小金额
    /// </summary>
    public long MinAmount { get; set; }
    /// <summary>
    /// 要求的流水倍数
    /// </summary>
    public float FlowMultip { get; set; }
    /// <summary>
    /// 记录时间
    /// </summary>
    public DateTime RecDate { get; set; }
    /// <summary>
    /// 1bonus,2真金
    /// </summary>
    public int AmountType { get; set; }
}
