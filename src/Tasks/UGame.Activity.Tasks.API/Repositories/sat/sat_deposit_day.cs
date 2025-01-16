using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///玩家每日充值累加表，记录每个玩家当天的累计充值金额
    ///</summary>
    [SugarTable("sat_deposit_day")]
    public partial class Sat_deposit_dayPO
    {
           public Sat_deposit_dayPO(){

            this.DepositAmount =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =DateTime.Now;

           }
           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:运营商ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:币种ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long DepositAmount {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

    }
}
