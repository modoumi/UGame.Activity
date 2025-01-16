using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///工具总列表
    ///</summary>
    [SugarTable("sat_item")]
    public partial class Sat_itemPO
    {
           public Sat_itemPO(){

            this.SourceTypeID =0;
            this.TriggerType =0;
            this.ItemType =0;
            this.Status =0;

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:工具名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Name {get;set;}

           /// <summary>
           /// Desc:类别 0-未知 1-活动 2-任务 3-兑奖码兑奖 4-奖励日历
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Category {get;set;}

           /// <summary>
           /// Desc:统计编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SourceTypeID {get;set;}

           /// <summary>
           /// Desc:触发类型0 未知, 1消息, 2 自主定时,3 主动触发 API调用
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TriggerType {get;set;}

           /// <summary>
           /// Desc:工具类型 0未知 1-循环类,2-可完成类
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ItemType {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
