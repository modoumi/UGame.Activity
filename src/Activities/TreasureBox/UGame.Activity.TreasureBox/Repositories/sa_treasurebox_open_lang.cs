using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox_open_lang")]
    public partial class Sa_treasurebox_open_langPO
    {
           public Sa_treasurebox_open_langPO(){

            this.IsDelete =false;

           }
           /// <summary>
           /// Desc:宝箱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BoxID {get;set;}

           /// <summary>
           /// Desc:打开条件： 
			/// 1、直接打开
			/// 2、累计存款
			/// 3、单笔存款
			/// 4、累计下注
			/// 5、净盈利
			/// 6、净亏损
			/// 7、邀请好友注册
			/// 8、邀请好友存款
			/// 9、邀请好友下注
			/// 10、VIP等级
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int OpenType {get;set;}

           /// <summary>
           /// Desc:语言编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LangID {get;set;}

           /// <summary>
           /// Desc:模板
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Template {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsDelete {get;set;}

    }
}
