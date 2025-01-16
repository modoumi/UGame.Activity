using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sr_user_day")]
    public partial class Sr_user_dayPO
    {
           public Sr_user_dayPO(){

            this.UserKind =0;
            this.FromMode =0;
            this.IsNew =false;
            this.IsLogin =false;
            this.LoginDays =0;
            this.IsRegister =false;
            this.IsNewBet =false;
            this.HasBet =false;
            this.IsNewPay =false;
            this.HasPay =false;
            this.IsNewCash =false;
            this.HasCash =false;
            this.BetCount =0;
            this.BetAmount =0;
            this.BetBonus =0;
            this.WinCount =0;
            this.WinAmount =0;
            this.WinBonus =0;
            this.PayCount =0;
            this.PayAmount =0;
            this.CashCount =0;
            this.CashAmount =0;
            this.ActivityCount =0;
            this.ActivityAmount =0;
            this.ChangeCount =0;
            this.ChangeAmount =0;
            this.CashAuditAmount =0;
            this.PayUserFee =0.000m;
            this.PayOwnFee =0.000m;
            this.CashUserFee =0.000m;
            this.CashOwnFee =0.000m;
            this.EndBalance =0;
            this.EndBonus =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:统计日
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:用户类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

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
           /// Desc:是否新用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNew {get;set;}

           /// <summary>
           /// Desc:当天是否登录
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsLogin {get;set;}

           /// <summary>
           /// Desc:连续登录天数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int LoginDays {get;set;}

           /// <summary>
           /// Desc:上次登录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastLoginTime {get;set;}

           /// <summary>
           /// Desc:当天是否进行了注册
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsRegister {get;set;}

           /// <summary>
           /// Desc:注册时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RegistDate {get;set;}

           /// <summary>
           /// Desc:是否是第一次下注用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewBet {get;set;}

           /// <summary>
           /// Desc:当天是否下注
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasBet {get;set;}

           /// <summary>
           /// Desc:是否是第一次充值用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewPay {get;set;}

           /// <summary>
           /// Desc:当天是否充值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasPay {get;set;}

           /// <summary>
           /// Desc:是否第一次体现用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewCash {get;set;}

           /// <summary>
           /// Desc:当天是否有提现行为
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasCash {get;set;}

           /// <summary>
           /// Desc:下注次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BetCount {get;set;}

           /// <summary>
           /// Desc:当天用户下注额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetAmount {get;set;}

           /// <summary>
           /// Desc:当天用户bonus下注
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetBonus {get;set;}

           /// <summary>
           /// Desc:返奖次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int WinCount {get;set;}

           /// <summary>
           /// Desc:当天用户返奖额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long WinAmount {get;set;}

           /// <summary>
           /// Desc:当天用户bonus返奖
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long WinBonus {get;set;}

           /// <summary>
           /// Desc:充值次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int PayCount {get;set;}

           /// <summary>
           /// Desc:当天用户充值额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PayAmount {get;set;}

           /// <summary>
           /// Desc:提现次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CashCount {get;set;}

           /// <summary>
           /// Desc:当天用户提现额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashAmount {get;set;}

           /// <summary>
           /// Desc:活动赠送bonus次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ActivityCount {get;set;}

           /// <summary>
           /// Desc:活动赠送bonus总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long ActivityAmount {get;set;}

           /// <summary>
           /// Desc:变化次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ChangeCount {get;set;}

           /// <summary>
           /// Desc:变化总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long ChangeAmount {get;set;}

           /// <summary>
           /// Desc:提现待审金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashAuditAmount {get;set;}

           /// <summary>
           /// Desc:当天用户充值手续费
           /// Default:0.000
           /// Nullable:False
           /// </summary>           
           public decimal PayUserFee {get;set;}

           /// <summary>
           /// Desc:当天用户充值我方手续费
           /// Default:0.000
           /// Nullable:False
           /// </summary>           
           public decimal PayOwnFee {get;set;}

           /// <summary>
           /// Desc:当天用户提现手续费
           /// Default:0.000
           /// Nullable:False
           /// </summary>           
           public decimal CashUserFee {get;set;}

           /// <summary>
           /// Desc:当天用户提现我方手续费
           /// Default:0.000
           /// Nullable:True
           /// </summary>           
           public decimal? CashOwnFee {get;set;}

           /// <summary>
           /// Desc:当天用户的账户余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBalance {get;set;}

           /// <summary>
           /// Desc:当天用户bonus余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBonus {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:用户注册的ip
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserIp {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Mobile {get;set;}

    }
}
