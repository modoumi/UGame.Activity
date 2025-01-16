using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///活动领取记录ip表
    ///</summary>
    [SugarTable("sa_ip_record")]
    public partial class Sa_ip_recordPO
    {
           public Sa_ip_recordPO(){

            this.Bonus =0;
            this.FlowMultip =0f;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:活动编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ActivityID {get;set;}

           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

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
           public string CountryId {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:ip地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string IpAddress {get;set;}

           /// <summary>
           /// Desc:获得奖金
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Bonus {get;set;}

           /// <summary>
           /// Desc:提现时候需要完成的下注流水倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
