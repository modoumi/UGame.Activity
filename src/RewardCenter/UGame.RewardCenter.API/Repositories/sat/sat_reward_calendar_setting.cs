using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励日历配置表
    ///</summary>
    [SugarTable("sat_reward_calendar_setting")]
    public partial class Sat_reward_calendar_settingPO
    {
           public Sat_reward_calendar_settingPO(){

            this.TotalDays =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:显示总天数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalDays {get;set;}

           /// <summary>
           /// Desc:历史天数,用于前端显示的过去天数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HistoryDays {get;set;}

    }
}
