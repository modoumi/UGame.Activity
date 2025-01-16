using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励日历各活动语言配置表
    ///</summary>
    [SugarTable("sat_reward_calendar_item_lang")]
    public partial class Sat_reward_calendar_item_langPO
    {
           public Sat_reward_calendar_item_langPO(){

            this.ItemID =0;
            this.Title ="0";

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:语言编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LangID {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

    }
}
