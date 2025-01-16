namespace UGame.Activity.Rebate.Domain.Models;

/// <summary>
/// 实时返点配置表
/// </summary>
public class SaRebateRealtimeConfig
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
    /// 最小打码量
    /// </summary>
    public long BetMinAmount { get; set; }
    /// <summary>
    /// 最大打码量
    /// </summary>
    public long BetMaxAmount { get; set; }
    /// <summary>
    /// 赠金额度
    /// </summary>
    public long RebateAmount { get; set; }
    /// <summary>
    /// 赠金提现所需要的流水倍数
    /// </summary>
    public float FlowMultip { get; set; }
    /// <summary>
    /// 记录创建时间
    /// </summary>
    public DateTime RecDate { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    public int Level { get; set; }
    /// <summary>
    /// 打码类型：1bonus,2真金3真金加bouns
    /// </summary>
    public int AmountType { get; set; }
}
