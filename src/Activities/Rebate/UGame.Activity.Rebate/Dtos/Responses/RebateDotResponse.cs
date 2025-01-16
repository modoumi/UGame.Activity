namespace UGame.Activity.Rebate.Dtos.Responses;

public class RebateDotResponse
{
    /// <summary>
    /// 总的奖励数
    /// </summary>
    public decimal TotalReward { get; set; }
    public List<RebateDotDto> DotList { get; set; }
}

public class RebateDotDto  
{
    /// <summary>
    /// 活动奖励记录id
    /// 【主键 varchar(36)】
    /// </summary>
    public string DetailID { get; set; }
    /// <summary>
    /// 用户编码
    /// 【字段 varchar(36)】
    /// </summary>

    public string UserID { get; set; }
    /// <summary>
    /// 记录天
    /// 【字段 date】
    /// </summary>
    public DateTime? DayID { get; set; }

    /// <summary>
    /// 运营商编码
    /// 【字段 varchar(50)】
    /// </summary>
    public string OperatorID { get; set; }

    /// <summary>
    /// 返点类型0默认值，1返点，2返水
    /// 【字段 int】
    /// </summary>
    public int RebateType { get; set; }
    /// <summary>
    /// 返点金额
    /// 【字段 bigint】
    /// </summary>
    public long RebateAmount { get; set; }

    public decimal RebateAmount3 { get; set; }

    public decimal BetMinAmount { get; set; }
    /// <summary>
    /// 等级
    /// 【字段 int】
    /// </summary>
    public int Level { get; set; }

    ///// <summary>
    ///// 发送通知状态，0-未通知1-已通知
    ///// 【字段 int】
    ///// </summary>
    //public int NotifyStatus { get; set; }
    /// <summary>
    /// 用户领取状态，0-未领取1-已领取
    /// 【字段 int】
    /// </summary>
    public int ReceiveStatus { get; set; }
    /// <summary>
    /// 记录时间
    /// 【字段 datetime】
    /// </summary>
    public DateTime RecDate { get; set; }
    /// <summary>
    /// 完成度
    /// </summary>
    public int Percent { get; set; }
    /// <summary>
    /// 当前总下注额
    /// </summary>
    public decimal TotalBetAmount { get; set; }
    /// <summary>
    /// 当前下注额
    /// </summary>
    public decimal CurrentBetAmount { get; set; }
    /// <summary>
    /// 需要完成下注额
    /// </summary>
    public decimal NeedBetAmount { get; set; }
}
