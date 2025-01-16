using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.RedpackRain.Repositories
{
    ///<summary>
    ///红包雨权重配置
    ///</summary>
    [SugarTable("sa_redpackrain_weight")]
    public partial class Sa_redpackrain_weightPO
    {
           public Sa_redpackrain_weightPO(){


           }
           /// <summary>
           /// Desc:权重配置编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string WeightID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:国家编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:权重值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:最小数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MinAmount {get;set;}

           /// <summary>
           /// Desc:最大数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MaxAmount {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
