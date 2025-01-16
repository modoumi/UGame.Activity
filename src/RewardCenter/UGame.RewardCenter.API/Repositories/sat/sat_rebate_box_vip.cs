using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心返奖宝箱vip等级返奖比例表
    ///</summary>
    [SugarTable("sat_rebate_box_vip")]
    public partial class Sat_rebate_box_vipPO
    {
           public Sat_rebate_box_vipPO(){

            this.VipGrade =1;
            this.RewardRate =20.0000d;

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
           /// Desc:VIP等级
           /// Default:1
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int VipGrade {get;set;}

           /// <summary>
           /// Desc:返奖比例，小数
           /// Default:20.0000
           /// Nullable:False
           /// </summary>           
           public double RewardRate {get;set;}

    }
}
