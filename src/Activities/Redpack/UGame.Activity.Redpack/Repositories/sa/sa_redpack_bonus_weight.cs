using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Redpack.Repositories
{
    ///<summary>
    ///Bonus奖金权重
    ///</summary>
    [SugarTable("sa_redpack_bonus_weight")]
    public partial class Sa_redpack_bonus_weightPO
    {
           public Sa_redpack_bonus_weightPO(){

            this.Weight =0;
            this.Amount =0;

           }
           /// <summary>
           /// Desc:权重主键
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
           /// Desc:权重
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:赠送金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

    }
}
