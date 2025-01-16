using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.DailyWheel.Repositories
{
    ///<summary>
    ///1.9版本-每日转盘抽奖概率
    ///</summary>
    [SugarTable("sa_dailywheel_weight")]
    public partial class Sa_dailywheel_weightPO
    {
           public Sa_dailywheel_weightPO(){

            this.WeightGroup =0;
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
           /// Desc:权重组0-未充值用户1-充值用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int WeightGroup {get;set;}

           /// <summary>
           /// Desc:权重值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:奖励货币类型 0-bonus1-cash
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
