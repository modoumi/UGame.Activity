using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.CoinSignin.Repositories
{
    ///<summary>
    ///运营商活动关系表
    ///</summary>
    [SugarTable("l_activity_operator")]
    public partial class L_activity_operatorPO
    {
           public L_activity_operatorPO(){

            this.BeginDate =Convert.ToDateTime("2000-01-01 00:00:00");
            this.EndDate =Convert.ToDateTime("9999-12-31 00:00:00");
            this.OrderNum =0;
            this.Status =false;
            this.IsSendNotify =true;
            this.IsSendNotifyEmail =true;
            this.IsAllowEnd =false;
            this.IsAllowIndexRecommend =false;
            this.IsAllowPayRecommend =false;
            this.IsBonus =true;

           }
           /// <summary>
           /// Desc:活动id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ActivityID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:起始日期（默认2016-01-01）
           /// Default:2000-01-01 00:00:00
           /// Nullable:False
           /// </summary>           
           public DateTime BeginDate {get;set;}

           /// <summary>
           /// Desc:截止日期（默认2099-01-01）
           /// Default:9999-12-31 00:00:00
           /// Nullable:False
           /// </summary>           
           public DateTime EndDate {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OrderNum {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:是否发送弹框通知
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsSendNotify {get;set;}

           /// <summary>
           /// Desc:是否发送站内邮件溶质
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsSendNotifyEmail {get;set;}

           /// <summary>
           /// Desc:是否允许完成
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsAllowEnd {get;set;}

           /// <summary>
           /// Desc:是否允许首页banner位推荐
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsAllowIndexRecommend {get;set;}

           /// <summary>
           /// Desc:是否为充值页推荐的banner
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsAllowPayRecommend {get;set;}

           /// <summary>
           /// Desc:0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

    }
}
