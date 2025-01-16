using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Cupon.Repositories
{
    ///<summary>
    ///兑换码
    ///</summary>
    [SugarTable("sa_cupon")]
    public partial class Sa_cuponPO
    {
           public Sa_cuponPO(){


           }
           /// <summary>
           /// Desc:批次号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BatchID {get;set;}

           /// <summary>
           /// Desc:运营商ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
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
           /// Desc:兑换码内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CuponID {get;set;}

           /// <summary>
           /// Desc:奖励中直接发放的比例
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal DirectRate {get;set;}

           /// <summary>
           /// Desc:奖励中延迟发放的天数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IndirectDay {get;set;}

           /// <summary>
           /// Desc:兑换次数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ExchangeLimit {get;set;}

           /// <summary>
           /// Desc:已兑次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? TotalNumber {get;set;}

           /// <summary>
           /// Desc:已兑直发金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? TotalDirectAmount {get;set;}

           /// <summary>
           /// Desc:已兑间接金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? TotalIndirectAmount {get;set;}

           /// <summary>
           /// Desc:兑换码过期的时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime ExpireDay {get;set;}

           /// <summary>
           /// Desc:状态1开启 0关闭
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Online {get;set;}

           /// <summary>
           /// Desc:创建日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:互斥组ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CuponGroupID {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Desc {get;set;}

    }
}
