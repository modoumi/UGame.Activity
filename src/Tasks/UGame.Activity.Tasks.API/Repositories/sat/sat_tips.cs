using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务提示定义表，前端进入指定地方触发任务提示，有进入游戏时，进入大厅时，进入存款页面时
    ///</summary>
    [SugarTable("sat_tips")]
    public partial class Sat_tipsPO
    {
           public Sat_tipsPO(){

            this.Status =1;

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
           /// Desc:描述
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

    }
}
