using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.DailyWheel.Repositories
{
    ///<summary>
    ///1.9版本-每日转盘抽奖概率
    ///</summary>
    [SugarTable("sa_dailywheel_position")]
    public partial class Sa_dailywheel_positionPO
    {
           public Sa_dailywheel_positionPO(){

            this.Position =0;
            this.MinReward =0;
            this.MaxReward =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:位置，从1开始，顺时针排列
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int Position {get;set;}

           /// <summary>
           /// Desc:位置图片路径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ImagePath {get;set;}

           /// <summary>
           /// Desc:位置最小奖励值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MinReward {get;set;}

           /// <summary>
           /// Desc:位置最大奖励值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxReward {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
