using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱配置表
    ///</summary>
    [SugarTable("sat_rebate_box_config")]
    public partial class Sat_rebate_box_configPO
    {
           public Sat_rebate_box_configPO(){

            this.IsBonus =true;
            this.StatisticsType =1;
            this.FlowMultip =20.00f;
            this.IsUseVip =false;
            this.Status =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:活动或任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:是否是赠金
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:统计周期类型，1-周期统计 2-历史累计
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int StatisticsType {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:20.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:是否启动VIP等级返奖
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsUseVip {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
