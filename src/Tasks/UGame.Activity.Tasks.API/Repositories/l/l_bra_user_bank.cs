using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///巴西用户银行卡
    ///</summary>
    [SugarTable("l_bra_user_bank")]
    public partial class L_bra_user_bankPO
    {
           public L_bra_user_bankPO(){

            this.BankChannel ="";
            this.UserKind =0;
            this.LastUsing =false;
            this.CardStatus =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:唯一编码GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserBankID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BankChannel {get;set;}

           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:用户类型
			///              0-未知
			///              1-普通用户
			///              2-开发用户
			///              3-线上测试用户（调用第三方扣减）
			///              4-线上测试用户（不调用第三方扣减）
			///              5-仿真用户
			///              6-接口联调用户
			///              9-管理员
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:税号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TaxId {get;set;}

           /// <summary>
           /// Desc:mobile、email、random
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string KeyCode {get;set;}

           /// <summary>
           /// Desc:开户类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AccountType {get;set;}

           /// <summary>
           /// Desc:使用者名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Name {get;set;}

           /// <summary>
           /// Desc:所有者类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OwnerType {get;set;}

           /// <summary>
           /// Desc:银行名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankName {get;set;}

           /// <summary>
           /// Desc:银行编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankCode {get;set;}

           /// <summary>
           /// Desc:支行编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BranchCode {get;set;}

           /// <summary>
           /// Desc:银行卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AccountNumber {get;set;}

           /// <summary>
           /// Desc:开户状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AccountStatus {get;set;}

           /// <summary>
           /// Desc:最后充值、提现使用的卡
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool LastUsing {get;set;}

           /// <summary>
           /// Desc:用户支付信息Hash码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CardInfoHash {get;set;}

           /// <summary>
           /// Desc:当前支付信息验证状态(0.默认待验证 1.验证通过)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CardStatus {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
