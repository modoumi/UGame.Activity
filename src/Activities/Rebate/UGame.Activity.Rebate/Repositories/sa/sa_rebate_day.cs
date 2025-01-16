using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Rebate.Repositories
{
    ///<summary>
    ///参加返点活动的游戏每日统计
    ///</summary>
    [SugarTable("sa_rebate_day")]
    public partial class Sa_rebate_dayPO
    {
           public Sa_rebate_dayPO(){

            this.FromMode =0;
            this.TotalBetAmount =0;
            this.TotalBetBonus =0;
            this.TotalWinAmount =0;
            this.TotalWinBonus =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:统计日
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:活动id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ActivityID {get;set;}

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
           /// Desc:新用户来源方式
			///                           0-获得运营商的新用户(s_operator)
			///                           1-推广员获得的新用户（userid）
			///                           2-推广渠道通过url获得的新用户（s_channel_url)
			///                           3-推广渠道通过code获得的新用户（s_channel_code)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int FromMode {get;set;}

           /// <summary>
           /// Desc:对应的编码（根据FromMode变化）
			///                           FromMode=
			///                           0-运营商的新用户(s_operator)==> OperatorID
			///                           1-推广员获得的新用户（userid） ==> 邀请人的UserID
			///                           2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
			///                           3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? FromId {get;set;}

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
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:下注总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalBetAmount {get;set;}

           /// <summary>
           /// Desc:下注时扣除的bonus总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalBetBonus {get;set;}

           /// <summary>
           /// Desc:有效下注金额，根据配置给返奖的金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long EffectiveBetAmount {get;set;}

           /// <summary>
           /// Desc:返奖总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalWinAmount {get;set;}

           /// <summary>
           /// Desc:返奖时增加的bonus总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalWinBonus {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateTime {get;set;}

    }
}
