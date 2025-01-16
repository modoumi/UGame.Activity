using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱数据表
    ///</summary>
    [SugarTable("sat_rebate_box")]
    public partial class Sat_rebate_boxPO
    {
           public Sat_rebate_boxPO(){

            this.IsBonus =true;
            this.MaxRewardAmount =0;
            this.FlowMultip =20.00f;
            this.Status =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =DateTime.Now;

           }
           /// <summary>
           /// Desc:返奖ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string RewardID {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:日期ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:活动或任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
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
           /// Desc:历史最大返奖金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxRewardAmount {get;set;}

           /// <summary>
           /// Desc:返奖总金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:直发金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RedirectRewardAmount {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:20.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:领取状态 0-待领取 1-可领取 2-已领取 3-已过期
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

           /// <summary>
           /// Desc:记录更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

    }
}
