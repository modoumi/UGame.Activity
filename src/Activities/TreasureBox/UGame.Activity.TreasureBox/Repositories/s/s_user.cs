using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{

    ///<summary>
    ///用户表
    ///</summary>
    [SugarTable("s_user")]
    public partial class S_userPO
    {
        public S_userPO()
        {

            this.UserMode = 1;
            this.OAuthType = 0;
            this.FromMode = 0;
            this.Cash = 0;
            this.Bonus = 0;
            this.Coin = 0;
            this.Gold = 0;
            this.SWB = 0;
            this.Point = 0;
            this.VIP = 1;
            this.UserProfile = 0;
            this.UserKind = 0;
            this.Status = 0;
            this.RecDate = DateTime.Now;
            this.LastLoginDate = DateTime.Now;
            this.HasBet = false;
            this.HasPay = false;
            this.HasCash = false;

        }
        /// <summary>
        /// Desc:用户编码(GUID)
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string UserID { get; set; }

        /// <summary>
        /// Desc:用户登录模式 1-游客 2-注册用户
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int UserMode { get; set; }

        /// <summary>
        /// Desc:授权登录方式0-我方1-facebook2-google3-twitter
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int OAuthType { get; set; }

        /// <summary>
        /// Desc:授权登录用户ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? OAuthID { get; set; }

        /// <summary>
        /// Desc:昵称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Nickname { get; set; }

        /// <summary>
        /// Desc:新用户来源方式
        ///              0-获得运营商的新用户(s_operator)
        ///              1-推广员获得的新用户（userid）
        ///              2-推广渠道通过url获得的新用户（s_channel_url)
        ///              3-推广渠道通过code获得的新用户（s_channel_code)
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int FromMode { get; set; }

        /// <summary>
        /// Desc:对应的编码（根据FromMode变化）
        ///              FromMode=
        ///              0-运营商的新用户(s_operator)==> OperatorID
        ///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
        ///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
        ///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? FromId { get; set; }

        /// <summary>
        /// Desc:运营商编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? OperatorID { get; set; }

        /// <summary>
        /// Desc:运营商用户标识（用户关联）
        ///              我方运营商为null
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? OperatorUserId { get; set; }

        /// <summary>
        /// Desc:国家编码ISO 3166-1三位字母
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? CountryID { get; set; }

        /// <summary>
        /// Desc:货币类型
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? CurrencyID { get; set; }

        /// <summary>
        /// Desc:现金（一级货币）*100000
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Cash { get; set; }

        /// <summary>
        /// Desc:剩余赠金
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Bonus { get; set; }

        /// <summary>
        /// Desc:硬币（二级货币）
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Coin { get; set; }

        /// <summary>
        /// Desc:金币
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Gold { get; set; }

        /// <summary>
        /// Desc:试玩币
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long SWB { get; set; }

        /// <summary>
        /// Desc:vip积分
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Point { get; set; }

        /// <summary>
        /// Desc:vip等级
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int VIP { get; set; }

        /// <summary>
        /// Desc:1级推广员用户编码（直接推广员）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? PUserID1 { get; set; }

        /// <summary>
        /// Desc:2级推广员用户编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? PUserID2 { get; set; }

        /// <summary>
        /// Desc:用户画像
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int UserProfile { get; set; }

        /// <summary>
        /// Desc:用户类型
        ///              0-未知
        ///              1-普通用户
        ///              2-开发用户
        ///              3-线上测试用户（调用第三方扣减）
        ///              4-线上测试用户（不调用第三方扣减）
        ///              5-仿真用户
        ///              6-接口联调用户
        ///              9-管理员
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int UserKind { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? IMEI { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? GAID { get; set; }

        /// <summary>
        /// Desc:用户IP
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? UserIp { get; set; }

        /// <summary>
        /// Desc:用户第一次进入客户端时的url
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? ClientUrl { get; set; }

        /// <summary>
        /// Desc:域名（不带http）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? DomainID { get; set; }

        /// <summary>
        /// Desc:样式编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? ThemesID { get; set; }

        /// <summary>
        /// Desc:状态
        ///              0-未知
        ///              1-有效
        ///              2-用户数据异常封闭
        ///              9-系统封闭
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int Status { get; set; }

        /// <summary>
        /// Desc:记录时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>           
        public DateTime RecDate { get; set; }

        /// <summary>
        /// Desc:注册时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RegistDate { get; set; }

        /// <summary>
        /// Desc:最后一次登录时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>           
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Desc:手机号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Mobile { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Email { get; set; }

        /// <summary>
        /// Desc:登录用户名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Username { get; set; }

        /// <summary>
        /// Desc:密码哈希值
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Password { get; set; }

        /// <summary>
        /// Desc:密码哈希Salt
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? PasswordSalt { get; set; }

        /// <summary>
        /// Desc:是否下过注
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool HasBet { get; set; }

        /// <summary>
        /// Desc:是否充过值
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool HasPay { get; set; }

        /// <summary>
        /// Desc:是否提过现
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool HasCash { get; set; }

    }
}
