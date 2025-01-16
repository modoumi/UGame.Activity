using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox_user")]
    public partial class Sa_treasurebox_userPO
    {
           public Sa_treasurebox_userPO(){

            this.OpenType =0;
            this.GrantType =0;
            this.IsOpen =false;
            this.IsBonus =false;
            this.Amount =0;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:运营商主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:用户主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:宝箱主键
           /// Default:
           /// Nullable:False
           /// </summary>           
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
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OpenType {get;set;}

           /// <summary>
           /// Desc:获得条件（0：系统发放，任务，活动）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int GrantType {get;set;}

           /// <summary>
           /// Desc:是否打开
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsOpen {get;set;}

           /// <summary>
           /// Desc:开始时间(获取宝箱时间)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime StartTime {get;set;}

           /// <summary>
           /// Desc:截至时间(宝箱过期时间)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime EndTime {get;set;}

           /// <summary>
           /// Desc:打开时间有效期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime OpenTime {get;set;}

           /// <summary>
           /// Desc:0-Cash 1-Bonus
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:操作时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
