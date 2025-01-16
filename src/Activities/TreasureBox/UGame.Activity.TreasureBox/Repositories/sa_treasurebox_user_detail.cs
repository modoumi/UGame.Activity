using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox_user_detail")]
    public partial class Sa_treasurebox_user_detailPO
    {
           public Sa_treasurebox_user_detailPO(){

            this.Value =0;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:宝箱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BoxID {get;set;}

           /// <summary>
           /// Desc:上级用户主键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? PUserID {get;set;}

           /// <summary>
           /// Desc:用户主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:打开条件： 
			/// 1、直接打开
			/// 2、累计存款(获得宝箱后)
			/// 3、单笔存款(获得宝箱后)
			/// 4、累计下注(获得宝箱后)
			/// 5、净盈利（总净盈利）
			/// 6、净亏损（总净亏损）
			/// 7、邀请好友注册(获得宝箱后)
			/// 8、邀请好友存款(获得宝箱后)
			/// 9、邀请好友下注(获得宝箱后)
			/// 10、VIP等级
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int OpenType {get;set;}

           /// <summary>
           /// Desc:值1
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Value {get;set;}

    }
}
