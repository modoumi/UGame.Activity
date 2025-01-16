using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.DailyWheel.Repositories
{
    ///<summary>
    ///每日转盘配置表
    ///</summary>
    [SugarTable("sa_dailywheel_config")]
    public partial class Sa_dailywheel_configPO
    {
           public Sa_dailywheel_configPO(){

            this.DefaultPot =0;
            this.MaxPot =0;
            this.PotRate =0f;
            this.MinReward =0;
            this.DeviceIdLimit =0;
            this.IPLimit =0;
            this.FlowMultip =0f;
            this.Status =0;
            this.StatisticsDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:初始奖池数值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long DefaultPot {get;set;}

           /// <summary>
           /// Desc:付费用户最大奖池数值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxPot {get;set;}

           /// <summary>
           /// Desc:付费用户上一日亏损累计速度
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float PotRate {get;set;}

           /// <summary>
           /// Desc:奖池为0的时候的发奖额度
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MinReward {get;set;}

           /// <summary>
           /// Desc:设备Id限制次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DeviceIdLimit {get;set;}

           /// <summary>
           /// Desc:请求IP限制次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IPLimit {get;set;}

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

           /// <summary>
           /// Desc:统计开始时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime StatisticsDate {get;set;}

    }
}
