using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.RedpackRain.Repositories
{
    ///<summary>
    ///红包雨变动记录表
    ///</summary>
    [SugarTable("sa_redpackrain_detail")]
    public partial class Sa_redpackrain_detailPO
    {
           public Sa_redpackrain_detailPO(){

            this.Amount =0;

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
           /// Desc:国家编码
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
           /// Desc:1 按照充值比例赠送的金额业务类型
			/// 2 第二天输返赠送的业务类型
			/// 3 用户红包雨赠送的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BusCode {get;set;}

           /// <summary>
           /// Desc:不同的busCode对应的不同的主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ThridId {get;set;}

           /// <summary>
           /// Desc:变化金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:时间段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public TimeSpan? StartTime {get;set;}

           /// <summary>
           /// Desc:结束时间，配置为对应小时的59分59秒
           /// Default:
           /// Nullable:True
           /// </summary>           
           public TimeSpan? EndTime {get;set;}

           /// <summary>
           /// Desc:红包雨插入时当前的日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DayId {get;set;}

           /// <summary>
           /// Desc:模板id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ModelID {get;set;}

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
           /// Desc:用户IP
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? IP {get;set;}

           /// <summary>
           /// Desc:权重值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:最大数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MaxAmount {get;set;}

           /// <summary>
           /// Desc:最小数值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long MinAmount {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
