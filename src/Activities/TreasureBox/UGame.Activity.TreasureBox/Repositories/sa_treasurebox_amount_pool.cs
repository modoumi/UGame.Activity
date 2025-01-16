using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox_amount_pool")]
    public partial class Sa_treasurebox_amount_poolPO
    {
           public Sa_treasurebox_amount_poolPO(){

            this.Amount =0;
            this.IsDelete =0;

           }
           /// <summary>
           /// Desc:宝箱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BoxID {get;set;}

           /// <summary>
           /// Desc:运营商主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:开始时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public TimeSpan StartTime {get;set;}

           /// <summary>
           /// Desc:结束时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public TimeSpan EndTime {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsDelete {get;set;}

    }
}
