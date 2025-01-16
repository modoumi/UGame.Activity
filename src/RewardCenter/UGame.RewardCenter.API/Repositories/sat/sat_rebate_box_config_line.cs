using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱条件配置表
    ///</summary>
    [SugarTable("sat_rebate_box_config_line")]
    public partial class Sat_rebate_box_config_linePO
    {
           public Sat_rebate_box_config_linePO(){


           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:活动或任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:条件类型，0-未知 1-下注 2-输钱 3-充值
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ConditionType {get;set;}

           /// <summary>
           /// Desc:金额类型，0-未知 1-Bonus 2-真金 3-真金+Bonus
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int AmountType {get;set;}

           /// <summary>
           /// Desc:必须达到的最小金额，乘以10000后的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MinRequiredAmount {get;set;}

           /// <summary>
           /// Desc:返奖比率，小于1的数字
           /// Default:
           /// Nullable:False
           /// </summary>           
           public double RewardRate {get;set;}

    }
}
