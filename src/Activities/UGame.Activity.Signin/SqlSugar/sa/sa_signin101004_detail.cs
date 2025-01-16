using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Signin.SqlSugar
{
    ///<summary>
    ///1.8签到奖励明细
    ///</summary>
    [SugarTable("sa_signin101004_detail")]
    public partial class Sa_signin101004_detailPO
    {
           public Sa_signin101004_detailPO(){

            this.UserKind =0;
            this.CurrentCycleNumber =0;
            this.Bonus =0;
            this.FlowMultip =1.0f;
            this.RewardType =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:奖励日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public DateTime DayId {get;set;}

           /// <summary>
           /// Desc:用户编码guid
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

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
           /// Desc:用户类型
			///                           0-未知
			///                           1-普通用户
			///                           2-开发用户
			///                           3-线上测试用户（调用第三方扣减）
			///                           4-线上测试用户（不调用第三方扣减）
			///                           5-仿真用户
			///                           6-接口联调用户
			///                           9-管理员
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:当前签到周期第几天
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CurrentCycleNumber {get;set;}

           /// <summary>
           /// Desc:奖金
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Bonus {get;set;}

           /// <summary>
           /// Desc:签到奖励流水倍数
           /// Default:1.0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:奖励类型,0、bonus;1、积分
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RewardType {get;set;}

           /// <summary>
           /// Desc:签到周期起始日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime SigninCycleStartDate {get;set;}

           /// <summary>
           /// Desc:签到周期截止日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime SigninCycleEndDate {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
