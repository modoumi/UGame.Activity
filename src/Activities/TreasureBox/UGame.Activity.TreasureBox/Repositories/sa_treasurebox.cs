using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sa_treasurebox")]
    public partial class Sa_treasureboxPO
    {
           public Sa_treasureboxPO(){

            this.OpenType =0;
            this.PoolStatus =false;
            this.IsDelete =false;

           }
           /// <summary>
           /// Desc:宝箱主键- ObjectID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BoxID {get;set;}

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
           /// Desc:批次编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BatchCode {get;set;}

           /// <summary>
           /// Desc:获得条件
			/// 0、免费获取
			/// 1、直接购买
			/// 2、注册
			/// 3、绑定手机
			/// 4、每日登录
			/// 5、首次存款
			/// 6、累计存款额达到N
			/// 7、累计下注达到N
			/// 8、VIP达到N级
			/// 9、每下注额达到N赠送
			/// 10、每日下注额达到N
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int GrantType {get;set;}

           /// <summary>
           /// Desc:发放条件
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long GrantValue {get;set;}

           /// <summary>
           /// Desc:跳转链接
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? GrantLinkUrl {get;set;}

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
           /// Desc:打开时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int OpenTime {get;set;}

           /// <summary>
           /// Desc:条件对应的值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long OpenValue {get;set;}

           /// <summary>
           /// Desc:奖池开关 0-关 1-开
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool PoolStatus {get;set;}

           /// <summary>
           /// Desc:打开图标,包含打开和未打开
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SkinIcon {get;set;}

           /// <summary>
           /// Desc:宝箱有效期 0-周期有效期 1-固定有效期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ExpireType {get;set;}

           /// <summary>
           /// Desc:周期有效期(小时)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ExpireRegular {get;set;}

           /// <summary>
           /// Desc:固定有效期止(当地时间的UTC)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ExpireTime {get;set;}

           /// <summary>
           /// Desc:宝箱数量 0-无限制 1-有限制
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int LimitNumType {get;set;}

           /// <summary>
           /// Desc:操作时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsDelete {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CreateUserName {get;set;}

    }
}
