using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Banky.Repositories
{
    ///<summary>
    ///破产保护用户表
    ///</summary>
    [SugarTable("sa_banky_user")]
    public partial class Sa_banky_userPO
    {
           public Sa_banky_userPO(){

            this.TotalAmount =0;
            this.RefundType =0;
            this.Times =0;
            this.Status =0;

           }
           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:返还总金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalAmount {get;set;}

           /// <summary>
           /// Desc:1-Cash
			/// 2-Bonus
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? RefundType {get;set;}

           /// <summary>
           /// Desc:次数(动态变小)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Times {get;set;}

           /// <summary>
           /// Desc:状态(0-未触发 1-已触发 2-已完成)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

    }
}
