using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心定义item配置表
    ///</summary>
    [SugarTable("sat_reward_center_item")]
    public partial class Sat_reward_center_itemPO
    {
           public Sat_reward_center_itemPO(){

            this.ItemID =0;
            this.Frequency =0;
            this.ActionType =0;
            this.Status =0;

           }
           /// <summary>
           /// Desc:工具编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:频度 0-非循环类 1-每日 2-每周 3-每月
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Frequency {get;set;}

           /// <summary>
           /// Desc:左侧图标url
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? IconUrl {get;set;}

           /// <summary>
           /// Desc:行为类型0-没有行为 1-Api接口调用 2-跳转链接, 前端弹窗设置0
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ActionType {get;set;}

           /// <summary>
           /// Desc:Api接口地址或是跳转链接
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

    }
}
