using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///用户当前任务字段设置
    ///</summary>
    [SugarTable("sat_user_item_setting")]
    public partial class Sat_user_item_settingPO
    {
           public Sat_user_item_settingPO(){


           }
           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:字段名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string FieldName {get;set;}

           /// <summary>
           /// Desc:变量名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? VariableName {get;set;}

           /// <summary>
           /// Desc:字段描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Description {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Sequence {get;set;}

    }
}
