using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务奖励定义表
    ///</summary>
    [SugarTable("sat_task_reward")]
    public partial class Sat_task_rewardPO
    {
           public Sat_task_rewardPO(){

            this.Level =0;
            this.RewardType =0;
            this.IsNeedReceive =true;
            this.IssueRule =1;
            this.IpLimits =0;

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int Level {get;set;}

           /// <summary>
           /// Desc:奖励类型 0-未知 1-Bonus 2-真金 3-积分
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RewardType {get;set;}

           /// <summary>
           /// Desc:币种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:奖励是否需要领取
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsNeedReceive {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int FlowMultip {get;set;}

           /// <summary>
           /// Desc:发放规则,0-未知 1-固定金额 2-按权重 3-随机抽取
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int IssueRule {get;set;}

           /// <summary>
           /// Desc:最小要求金额，乘以10000以后的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? MinRequiredAmount {get;set;}

           /// <summary>
           /// Desc:奖励金额, 发放规则为固定金额时有效
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:IP地址限制
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IpLimits {get;set;}

           /// <summary>
           /// Desc:进度最大值 钱是Money，除以10000后的数字
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MaxValue {get;set;}

    }
}
