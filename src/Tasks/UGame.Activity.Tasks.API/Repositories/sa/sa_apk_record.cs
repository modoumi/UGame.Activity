using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///APK下载领取奖励记录表
    ///</summary>
    [SugarTable("sa_apk_record")]
    public partial class Sa_apk_recordPO
    {
           public Sa_apk_recordPO(){

            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:记录Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string Id {get;set;}

           /// <summary>
           /// Desc:用户Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserId {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:状态 0-进行中 1-已完成未领取 2-已领取
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:请求IP
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string IP {get;set;}

           /// <summary>
           /// Desc:设备Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DeviceId {get;set;}

           /// <summary>
           /// Desc:税号(CPF)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TaxId {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
