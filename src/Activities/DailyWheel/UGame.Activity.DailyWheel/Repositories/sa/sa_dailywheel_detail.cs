using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.DailyWheel.Repositories
{
    ///<summary>
    ///用户抽奖记录表
    ///</summary>
    [SugarTable("sa_dailywheel_detail")]
    public partial class Sa_dailywheel_detailPO
    {
           public Sa_dailywheel_detailPO(){

            this.Position =0;
            this.PlanReward =0;
            this.RewardAmount =0;
            this.BeforePot =0;
            this.AfterPot =0;

           }
           /// <summary>
           /// Desc:明细编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string DetailID {get;set;}

           /// <summary>
           /// Desc:用户Id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:奖品位置
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Position {get;set;}

           /// <summary>
           /// Desc:计划金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PlanReward {get;set;}

           /// <summary>
           /// Desc:实际金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RewardAmount {get;set;}

           /// <summary>
           /// Desc:抽奖之前奖池金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BeforePot {get;set;}

           /// <summary>
           /// Desc:抽奖之后奖池金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AfterPot {get;set;}

           /// <summary>
           /// Desc:用户IP
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? IP {get;set;}

           /// <summary>
           /// Desc:用户设备Id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? DeviceId {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
