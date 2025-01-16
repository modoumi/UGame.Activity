using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.RedpackRain.Repositories
{
    ///<summary>
    ///红包雨个人奖池表
    ///</summary>
    [SugarTable("sa_redpackrain_user")]
    public partial class Sa_redpackrain_userPO
    {
           public Sa_redpackrain_userPO(){


           }
           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码
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
           /// Desc:当前用户奖池总金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? PotAmount {get;set;}

           /// <summary>
           /// Desc:输返累计的返奖池得额度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? TransportAmount {get;set;}

           /// <summary>
           /// Desc:最后一次更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastUpdateDate {get;set;}

           /// <summary>
           /// Desc:创建日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
