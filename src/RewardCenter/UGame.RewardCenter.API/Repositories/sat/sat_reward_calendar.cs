using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励日历数据表
    ///</summary>
    [SugarTable("sat_reward_calendar")]
    public partial class Sat_reward_calendarPO
    {
           public Sat_reward_calendarPO(){

            this.CalendarID ="0";
            this.IsBonus =true;
            this.FlowMultip =20.00f;
            this.TotalRewardAmount =0;
            this.Status =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =DateTime.Now;

           }
           /// <summary>
           /// Desc:日历ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CalendarID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:是否是赠金
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

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
           public long TotalRewardAmount {get;set;}

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
