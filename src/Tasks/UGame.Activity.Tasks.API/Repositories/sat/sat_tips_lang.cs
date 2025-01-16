using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务提示多语言表
    ///</summary>
    [SugarTable("sat_tips_lang")]
    public partial class Sat_tips_langPO
    {
           public Sat_tips_langPO(){


           }
           /// <summary>
           /// Desc:提示ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int TipsID {get;set;}

           /// <summary>
           /// Desc:运营商ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:语言ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LangID {get;set;}

           /// <summary>
           /// Desc:提示模板
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Template {get;set;}

    }
}
