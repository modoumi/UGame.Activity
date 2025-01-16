using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务明细
    ///</summary>
    [SugarTable("sat_task_detail")]
    public partial class Sat_task_detailPO
    {
           public Sat_task_detailPO(){

            this.Level =0;
            this.RewardType =0;
            this.IssueRule =1;
            this.RewardAmount =0;

           }
           /// <summary>
           /// Desc:明细ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string DetailID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:日期ID,针对循环类活动,通常是日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:运营商ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:奖励ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? RewardID {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Level {get;set;}

           /// <summary>
           /// Desc:失效日期, 不包含此日期 utc格式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? Deadline {get;set;}

           /// <summary>
           /// Desc:奖励类型 0-未知 1-Bonus 2-真金 3-积分
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? RewardType {get;set;}

           /// <summary>
           /// Desc:币种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int FlowMultip {get;set;}

           /// <summary>
           /// Desc:发放规则,0-未知 1-固定金额 2-按权重 3-随机抽取
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public int? IssueRule {get;set;}

           /// <summary>
           /// Desc:奖励的金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:奖励行json
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? RewardLines {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
