using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励日历各活动配置表
    ///</summary>
    [SugarTable("sat_reward_calendar_item")]
    public partial class Sat_reward_calendar_itemPO
    {
           public Sat_reward_calendar_itemPO(){

            this.ItemID =0;
            this.IsEnableConfig =true;
            this.Status =1;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:0
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
           /// Desc:是否启用IssueRate和DelayDays配置，兑奖码此配置不生效
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsEnableConfig {get;set;}

           /// <summary>
           /// Desc:延迟发放比率,小于1的小数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float DelayRate {get;set;}

           /// <summary>
           /// Desc:延迟发放天数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DelayDays {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效), 为1将在奖励日历中生效
           /// Default:1
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
