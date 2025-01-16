using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Rebate.Repositories
{
    ///<summary>
    ///定时任务返点活动配置表
    ///</summary>
    [SugarTable("sa_rebate_quartz_config")]
    public partial class Sa_rebate_quartz_configPO
    {
           public Sa_rebate_quartz_configPO(){

            this.OperatorID ="0";
            this.RewardRatio =0.00000f;
            this.FlowMultip =1.00f;
            this.RecDate =DateTime.Now;
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
           /// Default:0
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
           /// Desc:返奖比例
           /// Default:0.00000
           /// Nullable:False
           /// </summary>           
           public float RewardRatio {get;set;}

           /// <summary>
           /// Desc:奖励发放最小金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MinAmount {get;set;}

           /// <summary>
           /// Desc:要求的流水倍数
           /// Default:1.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:1bonus,2真金
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int AmountType {get;set;}

    }
}
