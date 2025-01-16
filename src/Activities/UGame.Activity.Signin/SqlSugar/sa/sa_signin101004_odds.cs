using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Signin.SqlSugar
{
    ///<summary>
    ///1.8版签到奖励概率配置
    ///</summary>
    [SugarTable("sa_signin101004_odds")]
    public partial class Sa_signin101004_oddsPO
    {
           public Sa_signin101004_oddsPO(){

            this.Bonus =0;
            this.Odds =0;
            this.BonusShowType =0;
            this.DateNumber =0;
            this.IsStartDay =false;
            this.FlowMultip =1.00f;
            this.RewardType =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ConfigID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:签到奖励
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Bonus {get;set;}

           /// <summary>
           /// Desc:概率
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Odds {get;set;}

           /// <summary>
           /// Desc:前端bonus显示类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BonusShowType {get;set;}

           /// <summary>
           /// Desc:日期编号
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DateNumber {get;set;}

           /// <summary>
           /// Desc:是否为第一天
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsStartDay {get;set;}

           /// <summary>
           /// Desc:赠金提现所需要的流水倍数
           /// Default:1.00
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
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
