using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心定义表
    ///</summary>
    [SugarTable("sat_reward_center")]
    public partial class Sat_reward_centerPO
    {
           public Sat_reward_centerPO(){

            this.ItemID =0;
            this.GroupID ="0";
            this.Sequence =0;
            this.Status =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:中心ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CenterID {get;set;}

           /// <summary>
           /// Desc:运营商ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:分组ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public string GroupID {get;set;}

           /// <summary>
           /// Desc:分组序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GroupOrder {get;set;}

           /// <summary>
           /// Desc:序号
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? Sequence {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
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

    }
}
