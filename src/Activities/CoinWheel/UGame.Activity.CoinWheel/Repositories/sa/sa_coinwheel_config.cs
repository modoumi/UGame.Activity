using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.CoinWheel.Repositories
{
    ///<summary>
    ///签到送积分配置表-v2.0
    ///</summary>
    [SugarTable("sa_coinwheel_config")]
    public partial class Sa_coinwheel_configPO
    {
           public Sa_coinwheel_configPO(){

            this.MaxPot =0;
            this.PotRate =0f;
            this.FlowMultip =0f;
            this.Status =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:最大奖池数值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxPot {get;set;}

           /// <summary>
           /// Desc:个人存款奖池百分比
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float PotRate {get;set;}

           /// <summary>
           /// Desc:每日免费次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? DailyFree {get;set;}

           /// <summary>
           /// Desc:额外旋转消耗积分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ExtraCoin {get;set;}

           /// <summary>
           /// Desc:打码倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:重置时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ResetTime {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
