using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///广告位定义
    ///</summary>
    [SugarTable("sc_banner")]
    public partial class Sc_bannerPO
    {
           public Sc_bannerPO(){

            this.BannerType =0;
            this.Code =0;
            this.ShowDay =0;
            this.ShowInterval =0;
            this.Position =0;
            this.LinkType =0;
            this.OrderNum =0;
            this.Status =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:Banner编码GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BannerID {get;set;}

           /// <summary>
           /// Desc:banner类型
			/// 1-游客
			/// 2-注册用户
			/// 3-注册未充值用户
			/// 4-注册已充值用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BannerType {get;set;}

           /// <summary>
           /// Desc:10000X活动；50000XVIP
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Code {get;set;}

           /// <summary>
           /// Desc:0-不参与规则1-每天首次显示2-每天非首次显示(目前只针对position=7生效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ShowDay {get;set;}

           /// <summary>
           /// Desc:当前banner针对用户显示间隔,单位:分
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ShowInterval {get;set;}

           /// <summary>
           /// Desc:应用编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AppID {get;set;}

           /// <summary>
           /// Desc:运营商编码（null意味着全部）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:使用位置
			///              0-未知
			///              1-首页推荐
			///              2-首页顶部
			///              3-汉堡栏
			///              4-个人中心
			///              5-充值页
			///              6-首页浮窗
			///              7-首页弹框(目前只支持注册后)
			///              8-注册页面banner
			///              9-绑定手机号弹框banner
			///              10-奖励中心banner
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Position {get;set;}

           /// <summary>
           /// Desc:语言代码（null意味着全部）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string LangID {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Title {get;set;}

           /// <summary>
           /// Desc:提示信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Tip {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Content {get;set;}

           /// <summary>
           /// Desc:图片地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ImageUrl {get;set;}

           /// <summary>
           /// Desc:链接类型1-相对地址2-绝对地址3-游戏地址
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int LinkType {get;set;}

           /// <summary>
           /// Desc:链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? LinkUrl {get;set;}

           /// <summary>
           /// Desc:可能存在的链接参数格式(json)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? LinkParams {get;set;}

           /// <summary>
           /// Desc:排序（从小到大）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OrderNum {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
