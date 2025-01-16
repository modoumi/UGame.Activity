using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///系统规则定义表
    ///</summary>
    [SugarTable("sc_rule")]
    public partial class Ssc_ruleEO
    {
           public Ssc_ruleEO(){


           }
           /// <summary>
           /// Desc:规则ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string RuleID {get;set;}

           /// <summary>
           /// Desc:分类，用在哪里
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Category {get;set;}

           /// <summary>
           /// Desc:规则表达式，能够返回bool值的表达式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ConditionExpr {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Description {get;set;}

    }
}
