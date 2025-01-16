using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///用户货币变化表（除s_provider_order,s_bank_order,s_operator_order以外的变化
    ///</summary>
    [SugarTable("s_currency_change")]
    public partial class S_currency_changePO
    {
           public S_currency_changePO(){

            this.FromMode =0;
            this.UserKind =1;
            this.CurrencyType =0;
            this.IsBonus =false;
            this.FlowMultip =0f;
            this.PlanAmount =0;
            this.SourceType =1;
            this.Status =0;
            this.RecDate =DateTime.Now;
            this.Amount =0;
            this.EndBalance =0;
            this.AmountBonus =0;
            this.EndBonus =0;
            this.AmountCoin =0;
            this.EndCoin =0;
            this.SettlStatus =0;
            this.SettlAmount =0;

           }
           /// <summary>
           /// Desc:货币变化编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ChangeID {get;set;}

           /// <summary>
           /// Desc:应用提供商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ProviderID {get;set;}

           /// <summary>
           /// Desc:应用编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AppID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserID {get;set;}

           /// <summary>
           /// Desc:新用户来源方式
			///              0-获得运营商的新用户(s_operator)
			///              1-推广员获得的新用户（userid）
			///              2-推广渠道通过url获得的新用户（s_channel_url)
			///              3-推广渠道通过code获得的新用户（s_channel_code)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int FromMode {get;set;}

           /// <summary>
           /// Desc:对应的编码（根据FromMode变化）
			///              FromMode=
			///              0-运营商的新用户(s_operator)==> OperatorID
			///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
			///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
			///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? FromId {get;set;}

           /// <summary>
           /// Desc:域名（不带http）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? DomainID {get;set;}

           /// <summary>
           /// Desc:用户类型
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型（货币缩写USD）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CurrencyType {get;set;}

           /// <summary>
           /// Desc:是否赠金
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

           /// <summary>
           /// Desc:要求的流水系数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:变化原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Reason {get;set;}

           /// <summary>
           /// Desc:计划变化金额（正负数）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PlanAmount {get;set;}

           /// <summary>
           /// Desc:扩展数据
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Meta {get;set;}

           /// <summary>
           /// Desc:0-未知1-运营活动2
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int SourceType {get;set;}

           /// <summary>
           /// Desc:源表名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SourceTable {get;set;}

           /// <summary>
           /// Desc:源表编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SourceId {get;set;}

           /// <summary>
           /// Desc:用户IP
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserIp {get;set;}

           /// <summary>
           /// Desc:状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:处理时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DealTime {get;set;}

           /// <summary>
           /// Desc:处理状态数据
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? DealStatus {get;set;}

           /// <summary>
           /// Desc:实际金额（正负数）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:处理后余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBalance {get;set;}

           /// <summary>
           /// Desc:bonus实际变化数量（正负数）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AmountBonus {get;set;}

           /// <summary>
           /// Desc:处理后bonus余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBonus {get;set;}

           /// <summary>
           /// Desc:实际coin变化（正负数）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AmountCoin {get;set;}

           /// <summary>
           /// Desc:处理后coin余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndCoin {get;set;}

           /// <summary>
           /// Desc:结算状态（0-未结算1-已结算）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SettlStatus {get;set;}

           /// <summary>
           /// Desc:结算表名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SettlTable {get;set;}

           /// <summary>
           /// Desc:结算编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SettlId {get;set;}

           /// <summary>
           /// Desc:结算金额(正负数)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long SettlAmount {get;set;}

    }
}
