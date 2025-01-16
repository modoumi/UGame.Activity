using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sat_user_item")]
    public partial class Sat_user_itemPO
    {
           public Sat_user_itemPO(){

            this.IsResident =false;
            this.Level =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =DateTime.Now;

           }
           /// <summary>
           /// Desc:明细ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DetailID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:日期ID,针对循环类活动,通常是日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
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
           /// Desc:是否常驻任务，完成不删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsResident {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int Level {get;set;}

           /// <summary>
           /// Desc:奖励金额，乘以10000之后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:失效时间, UTC格式有时间,不包含此日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime Deadline {get;set;}

           /// <summary>
           /// Desc:状态 0-进行中 1-已完成未领取 2-已领取 3-已完成
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value6 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value7 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value8 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value9 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Value10 {get;set;}

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
