using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Cupon.Repositories
{
    ///<summary>
    ///兑换码互斥组
    ///</summary>
    [SugarTable("sa_cupon_group")]
    public partial class Sa_cupon_groupPO
    {
           public Sa_cupon_groupPO(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:分组名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
