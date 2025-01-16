using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务列表语言配置表
    ///</summary>
    [SugarTable("sat_task_lang")]
    public partial class Sat_task_langPO
    {
           public Sat_task_langPO(){

            this.Type =0;

           }
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
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:语言
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LangID {get;set;}

           /// <summary>
           /// Desc:类型 0-未知 1-提示任务 2-完成任务
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Type {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Title {get;set;}

           /// <summary>
           /// Desc:内容模板,模板变量 RewardAmount, MaxRewardAmount
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Template {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
