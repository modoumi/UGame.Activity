using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Banky.Repositories
{
    ///<summary>
    ///破产保护返还记录表
    ///</summary>
    [SugarTable("sa_banky_detail")]
    public partial class Sa_banky_detailPO
    {
           public Sa_banky_detailPO(){

            this.RefundType =0;
            this.RefundAmount =0;
            this.FlowMultip =0f;
            this.IsDisplay =0;

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
           public string UserID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:1-Cash
			/// 2-Bonus
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RefundType {get;set;}

           /// <summary>
           /// Desc:返还金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RefundAmount {get;set;}

           /// <summary>
           /// Desc:打码倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

           /// <summary>
           /// Desc:是否展示0:展示,1:不展示
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsDisplay {get;set;}

    }
}
