using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱数据行表
    ///</summary>
    [SugarTable("sat_rebate_box_line")]
    public partial class Sat_rebate_box_linePO
    {
           public Sat_rebate_box_linePO(){

            this.FlowMultip =20.00f;
            this.RewardRate =0.0000d;

           }
           /// <summary>
           /// Desc:行ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LineID {get;set;}

           /// <summary>
           /// Desc:返奖ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RewardID {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:日期ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:活动或任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:条件类型，0-未知 1-下注 2-输钱 3-充值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ConditionType {get;set;}

           /// <summary>
           /// Desc:金额类型，0-未知 1-Bonus 2-真金 3-真金+Bonus
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int AmountType {get;set;}

           /// <summary>
           /// Desc:要求达到的标准金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RequiredAmount {get;set;}

           /// <summary>
           /// Desc:返奖是否是Bonus
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:20.00
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:实际发生的金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ChangedAmount {get;set;}

           /// <summary>
           /// Desc:返奖比率
           /// Default:0.0000
           /// Nullable:False
           /// </summary>           
           public double RewardRate {get;set;}

           /// <summary>
           /// Desc:返奖金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

    }
}
