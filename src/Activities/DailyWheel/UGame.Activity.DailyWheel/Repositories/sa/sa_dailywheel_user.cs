﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.DailyWheel.Repositories
{
    ///<summary>
    ///每日转盘用户奖池表
    ///</summary>
    [SugarTable("sa_dailywheel_user")]
    public partial class Sa_dailywheel_userPO
    {
           public Sa_dailywheel_userPO(){

            this.PlayNums =0;

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
           /// Desc:当前用户奖池金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PotAmount {get;set;}

           /// <summary>
           /// Desc:最后一次转的时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastPlayDate {get;set;}

           /// <summary>
           /// Desc:可以转的次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int PlayNums {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RecDate {get;set;}

    }
}
