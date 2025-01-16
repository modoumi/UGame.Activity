using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.RewardCenter.API.Repositories
{
    ///<summary>
    ///奖励中心营销工具语言表
    ///</summary>
    [SugarTable("sat_reward_center_item_lang")]
    public partial class Sat_reward_center_item_langPO
    {
           public Sat_reward_center_item_langPO(){

            this.ItemID =0;
            this.Title ="0";

           }
           /// <summary>
           /// Desc:营销编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ItemID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:语言编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LangID {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:内容模板
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Template {get;set;}

           /// <summary>
           /// Desc:提示中的标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TipTitle {get;set;}

           /// <summary>
           /// Desc:提示中的内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TipContent {get;set;}

           /// <summary>
           /// Desc:提示中的链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TipUrl {get;set;}

           /// <summary>
           /// Desc:按钮名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ButtonName {get;set;}

    }
}
