namespace UGame.Activity.Rebate.Domain.Models;

/// <summary>
/// 参加返点活动的游戏每日统计
/// </summary>
public class SaRebateDay
{
    /// <summary>
    /// 统计日
    /// </summary>
    public DateTime DayID { get; set; }
    /// <summary>
    /// 用户编码(GUID)
    /// </summary>
    public string UserID { get; set; }
    /// <summary>
    /// 活动id
    /// </summary>
    public int ActivityID { get; set; }
    /// <summary>
    /// 运营商编码
    /// </summary>
    public string OperatorID { get; set; }
    /// <summary>
    /// 货币类型
    /// </summary>
    public string CurrencyID { get; set; }
    /// <summary>
    /// 新用户来源方式
    /// 0-获得运营商的新用户(s_operator)
    /// 1-推广员获得的新用户（userid）
    /// 2-推广渠道通过url获得的新用户（s_channel_url)
    /// 3-推广渠道通过code获得的新用户（s_channel_code)
    /// </summary>
    public int FromMode { get; set; }
    /// <summary>
    /// 对应的编码（根据FromMode变化）
    /// FromMode=
    /// 0-运营商的新用户(s_operator)==> OperatorID
    /// 1-推广员获得的新用户（userid） ==> 邀请人的UserID
    /// 2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
    /// 3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
    /// </summary>
    public string FromId { get; set; }
    /// <summary>
    /// 用户类型
    /// 0-未知
    /// 1-普通用户
    /// 2-开发用户
    /// 3-线上测试用户（调用第三方扣减）
    /// 4-线上测试用户（不调用第三方扣减）
    /// 5-仿真用户
    /// 6-接口联调用户
    /// 9-管理员
    /// </summary>
    public int UserKind { get; set; }
    /// <summary>
    /// 国家编码ISO 3166-1三位字母 
    /// </summary>
    public string CountryID { get; set; }
    /// <summary>
    /// 下注总额
    /// </summary>
    public long TotalBetAmount { get; set; }
    /// <summary>
    /// 下注时扣除的bonus总额
    /// </summary>
    public long TotalBetBonus { get; set; }
    /// <summary>
    /// 有效下注金额，根据配置给返奖的金额
    /// </summary>
    public long EffectiveBetAmount { get; set; }
    /// <summary>
    /// 返奖总额
    /// </summary>
    public long TotalWinAmount { get; set; }
    /// <summary>
    /// 返奖时增加的bonus总额
    /// </summary>
    public long TotalWinBonus { get; set; }
    /// <summary>
    /// 记录时间
    /// </summary>
    public DateTime RecDate { get; set; }
    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
}
