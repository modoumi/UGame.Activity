using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Banky.Repositories
{
    ///<summary>
    ///破产保护配置表
    ///</summary>
    [SugarTable("sa_banky_config")]
    public partial class Sa_banky_configPO
    {
           public Sa_banky_configPO(){

            this.MinLimit =0;
            this.RefundType =0;
            this.Times =0;
            this.Rate =0f;
            this.FlowMultip =0f;
            this.Status =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:破产保护触发最小真金值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MinLimit {get;set;}

           /// <summary>
           /// Desc:1-Cash
			/// 2-Bonus
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RefundType {get;set;}

           /// <summary>
           /// Desc:每一笔存款触发的破产保护次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Times {get;set;}

           /// <summary>
           /// Desc:每一次破产保护的比例
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float Rate {get;set;}

           /// <summary>
           /// Desc:打码倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
