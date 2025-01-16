using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///任务活动显示分组表
    ///</summary>
    [SugarTable("sat_group_lang")]
    public partial class Sat_group_langPO
    {
           public Sat_group_langPO(){

            this.GroupID ="0";
            this.Title ="0";

           }
           /// <summary>
           /// Desc:分组ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string GroupID {get;set;}

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
