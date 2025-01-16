using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.RedpackRain.Repositories
{
    ///<summary>
    ///红包雨各个时间段开启时间
    ///</summary>
    [SugarTable("sa_redpackrain_time")]
    public partial class Sa_redpackrain_timePO
    {
           public Sa_redpackrain_timePO(){


           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:1.热门时间
			/// 2.常规时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ModelID {get;set;}

           /// <summary>
           /// Desc:起始时间，配置为对应时间的0分0秒
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public TimeSpan StartTime {get;set;}

           /// <summary>
           /// Desc:结束时间，配置为对应小时的59分59秒
           /// Default:
           /// Nullable:True
           /// </summary>           
           public TimeSpan? EndTime {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
