namespace UGame.Activity.Rebate.Domain.Models;

/// <summary>
/// 返点活动用户返奖详情
/// </summary>
public class SaRebateUserDetail
{
    /// <summary>
    /// 活动奖励记录id
    /// </summary>
    public string DetailID { get; set; }
    /// <summary>
    /// 用户编码
    /// </summary>
    public string UserID { get; set; }
    /// <summary>
    /// 记录天
    /// </summary>
    public DateTime DayID { get; set; }
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
    /// 返点类型0默认值，1返点，2返水
    /// </summary>
    public int RebateType { get; set; }
    /// <summary>
    /// 返点金额
    /// </summary>
    public long RebateAmount { get; set; }
    /// <summary>
    /// 赠金提现所需要的流水倍数
    /// </summary>
    public float FlowMultip { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    public int Level { get; set; }
    /// <summary>
    /// 发送通知状态，0-未通知1-已通知
    /// </summary>
    public int NotifyStatus { get; set; }
    /// <summary>
    /// 用户领取状态，0-未领取1-已领取
    /// </summary>
    public int ReceiveStatus { get; set; }
    /// <summary>
    /// 记录时间
    /// </summary>
    public DateTime RecDate { get; set; }
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
    /// <summary>
    /// 金额类型1bouns2真金
    /// </summary>
    public int RewardType { get; set; }
}
