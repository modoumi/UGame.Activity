using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Rebate.Repositories
{
    ///<summary>
    ///活动列表
    ///</summary>
    [SugarTable("l_activity_base")]
    public partial class L_activity_basePO
    {
           public L_activity_basePO(){


           }
           /// <summary>
           /// Desc:活动id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ActivityID {get;set;}

           /// <summary>
           /// Desc:活动名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Name {get;set;}

    }
}
