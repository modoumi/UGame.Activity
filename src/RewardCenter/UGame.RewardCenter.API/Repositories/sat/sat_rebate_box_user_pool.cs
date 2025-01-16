using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱最高返奖池记录表
    ///</summary>
    [SugarTable("sat_rebate_box_user_pool")]
    public partial class Sat_rebate_box_user_poolPO
    {
           public Sat_rebate_box_user_poolPO(){

            this.MaxRewardAmount =0;
            this.NextRewardAmount =0;
            this.UpdateTime =DateTime.Now;

           }
           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:活动或任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:日期ID，当日当周当月
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:最大返奖金额，乘以10000以后的金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxRewardAmount {get;set;}

           /// <summary>
           /// Desc:下个周期最大返奖金额，乘以10000以后的金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long NextRewardAmount {get;set;}

           /// <summary>
           /// Desc:记录更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

    }
}
