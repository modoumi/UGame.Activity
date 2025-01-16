using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Cupon.Repositories
{
    ///<summary>
    ///兑换码中奖记录表
    ///</summary>
    [SugarTable("sa_cupon_user")]
    public partial class Sa_cupon_userPO
    {
           public Sa_cupon_userPO(){

            this.IsBonus =0;
            this.DirectAmount =0;
            this.MaxAmount =0;
            this.MinAmount =0;
            this.Weight =0;
            this.RandomAmount =0;
            this.FlowMultip =0.00f;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:运营商主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:用户主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:0-Cash 1-Bonus
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsBonus {get;set;}

           /// <summary>
           /// Desc:直接发放金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long DirectAmount {get;set;}

           /// <summary>
           /// Desc:间接发放金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? IndirectAmount {get;set;}

           /// <summary>
           /// Desc:奖励中直接发放的比例
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? DirectRate {get;set;}

           /// <summary>
           /// Desc:延迟发放天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IndirectDay {get;set;}

           /// <summary>
           /// Desc:兑换码内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CuponID {get;set;}

           /// <summary>
           /// Desc:互斥组ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CuponGroupID {get;set;}

           /// <summary>
           /// Desc:规则ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CuponRuleId {get;set;}

           /// <summary>
           /// Desc:最大数值
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public long? MaxAmount {get;set;}

           /// <summary>
           /// Desc:最小数值
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public long? MinAmount {get;set;}

           /// <summary>
           /// Desc:权重
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? Weight {get;set;}

           /// <summary>
           /// Desc:随机的金额
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public long? RandomAmount {get;set;}

           /// <summary>
           /// Desc:流水倍数
           /// Default:0.00
           /// Nullable:True
           /// </summary>           
           public float? FlowMultip {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
