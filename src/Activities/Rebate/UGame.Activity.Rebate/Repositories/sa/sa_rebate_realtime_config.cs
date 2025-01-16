using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Rebate.Repositories
{
    ///<summary>
    ///实时返点配置表
    ///</summary>
    [SugarTable("sa_rebate_realtime_config")]
    public partial class Sa_rebate_realtime_configPO
    {
           public Sa_rebate_realtime_configPO(){

            this.BetMinAmount =0;
            this.BetMaxAmount =0;
            this.FlowMultip =10.00f;
            this.RecDate =DateTime.Now;
            this.Level =0;
            this.AmountType =1;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ConfigID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:活动id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ActivityID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:最小打码量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetMinAmount {get;set;}

           /// <summary>
           /// Desc:最大打码量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetMaxAmount {get;set;}

           /// <summary>
           /// Desc:赠金额度
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RebateAmount {get;set;}

           /// <summary>
           /// Desc:赠金提现所需要的流水倍数
           /// Default:10.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:记录创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Level {get;set;}

           /// <summary>
           /// Desc:打码类型：1bonus,2真金3真金加bouns
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int AmountType {get;set;}

    }
}
