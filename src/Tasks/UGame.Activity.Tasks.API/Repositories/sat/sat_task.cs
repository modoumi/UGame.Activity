using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Tasks.API.Repositories
{
    ///<summary>
    ///任务定义表，描述哪些活动可以做为任务以及对应描述配置
    ///</summary>
    [SugarTable("sat_task")]
    public partial class Sat_taskPO
    {
           public Sat_taskPO(){

            this.IsTask =true;
            this.IsResident =true;
            this.Frequency =0;
            this.InitActionType =1;
            this.ActionType =0;
            this.Status =0;

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:任务分类,0-未知 1-充值类 2-下注类 3-注册类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Category {get;set;}

           /// <summary>
           /// Desc:标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Tag {get;set;}

           /// <summary>
           /// Desc:是否是任务
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsTask {get;set;}

           /// <summary>
           /// Desc:是否常驻任务，完成不删除
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsResident {get;set;}

           /// <summary>
           /// Desc:频度 0-非循环类 1-每日 2-每周 3-每月
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? Frequency {get;set;}

           /// <summary>
           /// Desc:排序（从小到大）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Sequence {get;set;}

           /// <summary>
           /// Desc:初始行为类型, 0-无动作 1-跳转连接
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int InitActionType {get;set;}

           /// <summary>
           /// Desc:链接地址(详细页面)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? LinkUrl {get;set;}

           /// <summary>
           /// Desc:生效起始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? EffectiveTime {get;set;}

           /// <summary>
           /// Desc:领取奖励类型 0-未知 1-API接口 2-跳转连接 3-自定义处理
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ActionType {get;set;}

           /// <summary>
           /// Desc:领取奖励行为,ActionType为本地方法调用时此值为类名/方法名, 为跳转链接时是链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ActionValue {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
