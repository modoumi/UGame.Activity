using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Redpack.Repositories
{
    ///<summary>
    ///红包数量pool
    ///</summary>
    [SugarTable("sa_redpack_pack_pool")]
    public partial class Sa_redpack_pack_poolPO
    {
           public Sa_redpack_pack_poolPO(){

            this.StartTime =TimeSpan.Parse("00:00:00");
            this.EndTime = TimeSpan.Parse("02:00:00");
            this.TotalPack =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:开始时间00:00:00
           /// Default:00:00:00
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public TimeSpan StartTime {get;set;}

           /// <summary>
           /// Desc:结束时间02:00:00
           /// Default:02:00:00
           /// Nullable:False
           /// </summary>           
           public TimeSpan EndTime {get;set;}

           /// <summary>
           /// Desc:可完成红包数量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalPack {get;set;}

    }
}
