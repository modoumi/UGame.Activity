using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励日历数据行表
    ///</summary>
    [SugarTable("sat_reward_calendar_line")]
    public partial class Sat_reward_calendar_linePO
    {
           public Sat_reward_calendar_linePO(){

            this.CalendarID ="0";
            this.ItemID =0;
            this.Level =0;
            this.DelayIndex =1;
            this.IsBonus =true;
            this.FlowMultip =20.00f;
            this.RewardAmount =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:行ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LineID {get;set;}

           /// <summary>
           /// Desc:日历ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public string CalendarID {get;set;}

           /// <summary>
           /// Desc:原奖励明细ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DetailID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Level {get;set;}

           /// <summary>
           /// Desc:延迟天索引，从1开始
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int DelayIndex {get;set;}

           /// <summary>
           /// Desc:来源备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Remark {get;set;}

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
           /// Desc:流水倍数
           /// Default:20.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:今日奖励总金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
