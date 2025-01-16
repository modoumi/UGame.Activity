using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.RedpackRain.Repositories
{
    ///<summary>
    ///红包雨基本配置表
    ///</summary>
    [SugarTable("sa_redpackrain_config")]
    public partial class Sa_redpackrain_configPO
    {
           public Sa_redpackrain_configPO(){


           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:个人充值真金百分比
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float PersonalRechargeRate {get;set;}

           /// <summary>
           /// Desc:个人真金亏损比例
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float PersonalLossRate {get;set;}

           /// <summary>
           /// Desc:个人奖池最大比例
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float PersonalMaxReward {get;set;}

           /// <summary>
           /// Desc:个人领奖的最小金额，同时也是个人/总体奖池耗尽之后的奖金数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PersonalMinReward {get;set;}

           /// <summary>
           /// Desc:热门时间配置模板
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HolidayModelID {get;set;}

           /// <summary>
           /// Desc:冷漠时间配置模板
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int NormalModelID {get;set;}

           /// <summary>
           /// Desc:打码倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:0-Cash 1-Bonus
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IsBonus {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:红包雨单人一天参与的最大领取次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MaxClaim {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
