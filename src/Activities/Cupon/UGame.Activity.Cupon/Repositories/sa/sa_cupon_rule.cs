using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Cupon.Repositories
{
    ///<summary>
    ///兑换码规则表
    ///</summary>
    [SugarTable("sa_cupon_rule")]
    public partial class Sa_cupon_rulePO
    {
           public Sa_cupon_rulePO(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:最小数值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long MinAmount {get;set;}

           /// <summary>
           /// Desc:最大数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MaxAmount {get;set;}

           /// <summary>
           /// Desc:0-Cash 1-Bonus
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IsBonus {get;set;}

           /// <summary>
           /// Desc:权重
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:兑换码内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CuponID {get;set;}

    }
}
