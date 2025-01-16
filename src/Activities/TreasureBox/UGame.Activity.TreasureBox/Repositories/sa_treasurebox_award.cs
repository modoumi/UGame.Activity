using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox_award")]
    public partial class Sa_treasurebox_awardPO
    {
           public Sa_treasurebox_awardPO(){

            this.Type =0;
            this.Weight =0;
            this.IsDelete =0;

           }
           /// <summary>
           /// Desc:奖励主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string AwardID {get;set;}

           /// <summary>
           /// Desc:运营商主键
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
           /// Desc:宝箱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BoxID {get;set;}

           /// <summary>
           /// Desc:0-Cash 1-Bonus
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Type {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:打码流水倍数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int FlowMultip {get;set;}

           /// <summary>
           /// Desc:权重
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Weight {get;set;}

           /// <summary>
           /// Desc:操作时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsDelete {get;set;}

    }
}
