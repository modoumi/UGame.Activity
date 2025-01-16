using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///工具运营商表，描述运营商工具配置
    ///</summary>
    [SugarTable("sat_item_operator")]
    public partial class Sat_item_operatorPO
    {
           public Sat_item_operatorPO(){

            this.BeginDate =Convert.ToDateTime("2000-01-01 00:00:00");
            this.EndDate =Convert.ToDateTime("9999-12-31 00:00:00");
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
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:Cron表达式, 触发类型为自主定时时有效
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CronExpr {get;set;}

           /// <summary>
           /// Desc:起始日期（默认2016-01-01）
           /// Default:2000-01-01 00:00:00
           /// Nullable:False
           /// </summary>           
           public DateTime BeginDate {get;set;}

           /// <summary>
           /// Desc:截止日期（默认2099-01-01）
           /// Default:9999-12-31 00:00:00
           /// Nullable:False
           /// </summary>           
           public DateTime EndDate {get;set;}

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
