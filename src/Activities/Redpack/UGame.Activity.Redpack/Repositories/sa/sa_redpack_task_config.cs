using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Redpack.Repositories
{
    ///<summary>
    ///任务配置项
    ///</summary>
    [SugarTable("sa_redpack_task_config")]
    public partial class Sa_redpack_task_configPO
    {
           public Sa_redpack_task_configPO(){

            this.PackNum =0;
            this.GroupId =0;
            this.OrderNum =0;
            this.TotalCount =0;
            this.TotalAmount =0;
            this.Ratio =0;
            this.BetAmount =0;
            this.PayAmount =0;

           }
           /// <summary>
           /// Desc:编码
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
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:红包序号
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int PackNum {get;set;}

           /// <summary>
           /// Desc:分组标志1-新注册2-分享3-下注4-客户端
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int GroupId {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OrderNum {get;set;}

           /// <summary>
           /// Desc:总次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalCount {get;set;}

           /// <summary>
           /// Desc:总金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalAmount {get;set;}

           /// <summary>
           /// Desc:分配概率60%
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Ratio {get;set;}

           /// <summary>
           /// Desc:下注金额条件
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetAmount {get;set;}

           /// <summary>
           /// Desc:充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PayAmount {get;set;}

    }
}
