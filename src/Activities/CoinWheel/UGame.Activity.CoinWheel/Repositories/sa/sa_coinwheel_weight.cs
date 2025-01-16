using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.CoinWheel.Repositories
{
    ///<summary>
    ///2.0版本-签到送积分权重表
    ///</summary>
    [SugarTable("sa_coinwheel_weight")]
    public partial class Sa_coinwheel_weightPO
    {
           public Sa_coinwheel_weightPO(){

            this.Weight =0;
            this.RewardCurrency =0;
            this.Reward =0;

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
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:权重值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:奖励货币类型 0-bonus,1-cash,2-coin
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RewardCurrency {get;set;}

           /// <summary>
           /// Desc:奖励值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Reward {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
