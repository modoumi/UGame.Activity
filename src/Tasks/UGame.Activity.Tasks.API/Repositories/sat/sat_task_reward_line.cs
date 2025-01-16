using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务奖励定义表
    ///</summary>
    [SugarTable("sat_task_reward_line")]
    public partial class Sat_task_reward_linePO
    {
           public Sat_task_reward_linePO(){

            this.ItemID =0;
            this.Level =0;
            this.RewardAmount =0;
            this.Weight =100;

           }
           /// <summary>
           /// Desc:行ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LineID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Level {get;set;}

           /// <summary>
           /// Desc:奖励金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:权重值,以100以内整数
           /// Default:100
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

    }
}
