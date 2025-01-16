using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Signin.SqlSugar
{
    ///<summary>
    ///1.8版签到配置
    ///</summary>
    [SugarTable("sa_signin101004_config")]
    public partial class Sa_signin101004_configPO
    {
           public Sa_signin101004_configPO(){

            this.SigninPayAmount =0;

           }
           /// <summary>
           /// Desc:运营商编码
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
           public string CountryId {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:签到需要满足的当日充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long SigninPayAmount {get;set;}

    }
}
