using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.TreasureBox.Repositories
{
    ///<summary>
    ///银行订单表
    ///</summary>
    [SugarTable("sb_bank_order")]
    public partial class Sb_bank_orderPO
    {
        public Sb_bank_orderPO()
        {

            this.FromMode = 0;
            this.UserKind = 0;
            this.OrderType = 0;
            this.PaytypeID = 0;
            this.PaytypeChannel = 0;
            this.RecDate = DateTime.Now;
            this.PlanAmount = 0;
            this.AppRequestTime = DateTime.Now;
            this.IsFirstCashOfDay = false;
            this.Status = 0;
            this.TransMoney = 0.000000m;
            this.OrderMoney = 0.000000m;
            this.Amount = 0;
            this.OwnFee = 0.000m;
            this.UserFee = 0.000m;
            this.UserMoney = 0.00m;
            this.AmountBonus = 0;
            this.EndBonus = 0;
            this.SettlAmount = 0;
            this.SettlStatus = 0;
            this.CompleteFlag = 0;
            this.IsAddBalance = true;
            this.IsAuditOrder = false;
            this.UserFeeAmount = 0;

        }
        /// <summary>
        /// Desc:订单编码GUID
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string OrderID { get; set; }

        /// <summary>
        /// Desc:应用提供商编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? ProviderID { get; set; }

        /// <summary>
        /// Desc:应用编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AppID { get; set; }

        /// <summary>
        /// Desc:运营商编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? OperatorID { get; set; }

        /// <summary>
        /// Desc:用户编码(GUID)
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserID { get; set; }

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
        /// Desc:域名（不带http）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? DomainID { get; set; }

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
        /// Desc:注册时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RegistDate { get; set; }

        /// <summary>
        /// Desc:充值返现1-充值2-返现
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int OrderType { get; set; }

        /// <summary>
        /// Desc:银行编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? BankID { get; set; }

        /// <summary>
        /// Desc:支付方式0-综合1-visa2-spei
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int PaytypeID { get; set; }

        /// <summary>
        /// Desc:支付方式下的渠道
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int PaytypeChannel { get; set; }

        /// <summary>
        /// Desc:货币类型（货币缩写USD）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? CurrencyID { get; set; }

        /// <summary>
        /// Desc:记录时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>           
        public DateTime RecDate { get; set; }

        /// <summary>
        /// Desc:计划变化金额（正负数）
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long PlanAmount { get; set; }

        /// <summary>
        /// Desc:请求唯一号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AppRequestUUID { get; set; }

        /// <summary>
        /// Desc:app订单编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AppOrderId { get; set; }

        /// <summary>
        /// Desc:请求备注
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AppReqComment { get; set; }

        /// <summary>
        /// Desc:请求时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>           
        public DateTime AppRequestTime { get; set; }

        /// <summary>
        /// Desc:账户名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AccName { get; set; }

        /// <summary>
        /// Desc:账户卡号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? AccNumber { get; set; }

        /// <summary>
        /// Desc:银行编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? BankCode { get; set; }

        /// <summary>
        /// Desc:是否当天第一次提现
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool IsFirstCashOfDay { get; set; }

        /// <summary>
        /// Desc:扩展数据
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Meta { get; set; }

        /// <summary>
        /// Desc:状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int Status { get; set; }

        /// <summary>
        /// Desc:充值用户ip
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? UserIP { get; set; }

        /// <summary>
        /// Desc:我方传给银行的订单号（transaction_id）对账使用!
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? OwnOrderId { get; set; }

        /// <summary>
        /// Desc:传给银行的交易金额
        /// Default:0.000000
        /// Nullable:False
        /// </summary>           
        public decimal TransMoney { get; set; }

        /// <summary>
        /// Desc:订单对账金额（单位元）
        /// Default:0.000000
        /// Nullable:False
        /// </summary>           
        public decimal OrderMoney { get; set; }

        /// <summary>
        /// Desc:银行返回时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? BankResponseTime { get; set; }

        /// <summary>
        /// Desc:银行订单编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? BankOrderId { get; set; }

        /// <summary>
        /// Desc:银行回调时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? BankCallbackTime { get; set; }

        /// <summary>
        /// Desc:银行订单的成功时间（对账使用）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? BankTime { get; set; }

        /// <summary>
        /// Desc:支付条形码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? BrCode { get; set; }

        /// <summary>
        /// Desc:支付二维码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? QrCode { get; set; }

        /// <summary>
        /// Desc:实际数量（正负数）
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long Amount { get; set; }

        /// <summary>
        /// Desc:我方承担的手续费
        /// Default:0.000
        /// Nullable:False
        /// </summary>           
        public decimal OwnFee { get; set; }

        /// <summary>
        /// Desc:用户承担的手续费
        /// Default:0.000
        /// Nullable:False
        /// </summary>           
        public decimal UserFee { get; set; }

        /// <summary>
        /// Desc:支付金额（提款金额）
        /// Default:0.00
        /// Nullable:False
        /// </summary>           
        public decimal UserMoney { get; set; }

        /// <summary>
        /// Desc:处理后余额
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long EndBalance { get; set; }

        /// <summary>
        /// Desc:bonus实际变化数量（正负数）
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long AmountBonus { get; set; }

        /// <summary>
        /// Desc:处理后bonus余额
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long EndBonus { get; set; }

        /// <summary>
        /// Desc:结算表名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? SettlTable { get; set; }

        /// <summary>
        /// Desc:结算编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? SettlId { get; set; }

        /// <summary>
        /// Desc:结算金额(正负数)
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long SettlAmount { get; set; }

        /// <summary>
        /// Desc:结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int SettlStatus { get; set; }

        /// <summary>
        /// Desc:完成标记0.三方回调完成 1.我方主动调用
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int CompleteFlag { get; set; }

        /// <summary>
        /// Desc:活动id集合|分割
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? ActivityIds { get; set; }

        /// <summary>
        /// Desc:充值是否添加账户余额
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public bool IsAddBalance { get; set; }

        /// <summary>
        /// Desc:是否提现审核订单
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool IsAuditOrder { get; set; }

        /// <summary>
        /// Desc:国家编码ISO 3166-1三位字母
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? CountryID { get; set; }

        /// <summary>
        /// Desc:我方收取的vip用户手续费
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long UserFeeAmount { get; set; }

    }
}
