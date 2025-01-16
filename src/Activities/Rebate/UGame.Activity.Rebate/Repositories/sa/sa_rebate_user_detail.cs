using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Rebate.Repositories
{
    ///<summary>
    ///返点活动用户返奖详情
    ///</summary>
    [SugarTable("sa_rebate_user_detail")]
    public partial class Sa_rebate_user_detailPO
    {
           public Sa_rebate_user_detailPO(){

            this.DetailID ="0";
            this.FromMode =0;
            this.RebateType =1;
            this.RebateAmount =0;
            this.NotifyStatus =0;
            this.ReceiveStatus =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =DateTime.Now;
            this.RewardType =1;

           }
           /// <summary>
           /// Desc:活动奖励记录id
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string DetailID {get;set;}

           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:记录天
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
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:活动id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ActivityID {get;set;}

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
           /// Desc:返点类型0默认值，1返点，2返水
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int RebateType {get;set;}

           /// <summary>
           /// Desc:返点金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RebateAmount {get;set;}

           /// <summary>
           /// Desc:赠金提现所需要的流水倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Level {get;set;}

           /// <summary>
           /// Desc:发送通知状态，0-未通知1-已通知
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int NotifyStatus {get;set;}

           /// <summary>
           /// Desc:用户领取状态，0-未领取1-已领取
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ReceiveStatus {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

           /// <summary>
           /// Desc:金额类型1bouns2真金
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int RewardType {get;set;}

    }
}
