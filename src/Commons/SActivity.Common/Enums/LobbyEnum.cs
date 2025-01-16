namespace SActivity.Common.Enums
{
    /// <summary>
    /// 表单数据类型
    /// </summary>
    public enum FormDbType
    {
        /// <summary>
        /// 时间
        /// </summary>
        datetime = 1
    }


    #region 幸运转盘活动


    /// <summary>
    /// 幸运转盘活动，奖励类型枚举
    /// </summary>
    public enum RouletteDetailType
    {
        /// <summary>
        /// 注册赠送
        /// </summary>
        register = 1,

        /// <summary>
        /// 首充赠送
        /// </summary>
        firstPay = 2,

        /// <summary>
        /// 下注
        /// </summary>
        bet = 3
    }

    /// <summary>
    /// 幸运转盘活动，用户类型枚举
    /// </summary>
    public enum RouletteUserType
    {
        /// <summary>
        /// 新用户
        /// </summary>
        newUser = 1,

        /// <summary>
        /// 盈利用户
        /// </summary>
        profitUser = 2,

        /// <summary>
        /// 亏损用户
        /// </summary>
        lossUser = 3
    }

    #endregion

    #region 全局活动枚举

    /// <summary>
    /// 活动类型
    /// 100000-20000属于活动
    /// 400000-50000后台
    /// 500000-60000VIP
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// 注册、首充活动
        /// </summary>
        RegPay = 100001,

        /// <summary>
        /// 幸运转盘活动
        /// </summary>
        Roulette = 100002,

        /// <summary>
        /// 输返活动
        /// </summary>
        LoseCashBack = 100003,

        /// <summary>
        /// 新用户首充500%奖励
        /// </summary>
        UserFirstPay5 = 100004,

        /// <summary>
        /// 签到活动
        /// </summary>
        SignIn = 100005,

        /// <summary>
        /// 绑定手机领取奖励
        /// </summary>
        BindMobile = 100006,

        /// <summary>
        /// 注册送bonus
        /// </summary>
        Register7 = 100007,

        /// <summary>
        /// 每日充值激励
        /// </summary>
        UserPay100008 = 100008,

        /// <summary>
        /// 日返点
        /// </summary>
        RebateDot = 100009,

        /// <summary>
        /// 日返水
        /// </summary>
        RebateWater = 100010,

        /// <summary>
        /// 拉新活动
        /// </summary>
        InvitationNewUser100011 = 100011,

        /// <summary>
        /// 1.5版本签到
        /// </summary>
        Signin_15 = 100012,

        /// <summary>
        /// 新版拉新活动
        /// </summary>
        InviteNewUser100013 = 100013,

        /// <summary>
        /// 周返点
        /// </summary>
        RebateDotWeekly = 100014,

        /// <summary>
        /// 周返水
        /// </summary>
        RebateWaterWeekly = 100015,

        /// <summary>
        /// 月返点
        /// </summary>
        RebateDotMonthly = 100016,

        /// <summary>
        /// 周返水
        /// </summary>
        RebateWaterMonthly = 100017,

        //下面是任务

        /// <summary>
        /// APP下载并登录任务
        /// </summary>
        AppDownloadLoginTask = 100018,
        /// <summary>
        /// 绑定手机号任务
        /// </summary>
        BindMobileTask = 100019,
        /// <summary>
        /// 进入tele频道
        /// </summary>
        EnterTeleChannelTask = 100020,
        /// <summary>
        /// 关注facebook首页
        /// </summary>
        FollowFacebookTask = 100021,
        /// <summary>
        /// 邀请好友奖励
        /// </summary>
        FriendInvitationTask = 100022,
        /// <summary>
        /// 累计日充值
        /// </summary>
        TotalDepositDailyTask = 100023,
        /// <summary>
        /// 累计周充值
        /// </summary>
        TotalDepositWeeklyTask = 100024,
        /// <summary>
        /// 累计月充值
        /// </summary>
        TotalDepositMonthlyTask = 100025,
        /// <summary>
        /// 当日有充值
        /// </summary>
        DepositTask = 100026,
        /// <summary>
        /// 累计日下注
        /// </summary>
        TotalBetDailyTask = 100027,
        /// <summary>
        /// 累计周下注
        /// </summary>
        TotalBetWeeklyTask = 100028,
        /// <summary>
        /// 累计月下注
        /// </summary>
        TotalBetMonthlyTask = 100029,

        //奖励中心使用的枚举
        /// <summary>
        /// 奖励中心每日返奖直发
        /// </summary>
        RewardCenterDailyRebate = 100030,
        /// <summary>
        /// 奖励中心每周返奖直发
        /// </summary>
        RewardCenterWeeklyRebate = 100031,
        /// <summary>
        /// 奖励中心每月返奖直发
        /// </summary>
        RewardCenterMonthlyRebate = 100032,
        /// <summary>
        /// 奖励中心兑换码直发
        /// </summary>
        RewardCenterRedeemCode = 100033,
        /// <summary>
        /// 奖励中心奖金日历
        /// </summary>
        RewardCenterCalendar = 100034,
        /// <summary>
        /// 奖励中心兑换码延发
        /// </summary>
        RewardCenterRedeemCodeDelay = 100035,
        /// <summary>
        /// 奖励中心每日返奖延发
        /// </summary>
        RewardCenterDailyRebateDelay = 100036,
        /// <summary>
        /// 奖励中心每周返奖直发
        /// </summary>
        RewardCenterWeeklyRebateDelay = 100037,
        /// <summary>
        /// 奖励中心每月返奖直发
        /// </summary>
        RewardCenterMonthlyRebateDelay = 100038,

        /// <summary>
        /// 注册送奖励任务
        /// </summary>
        RegisterRewardTask = 100039,

        /// <summary>
        /// 1.7版抽奖轮盘
        /// </summary>
        Roulette101001 = 101001,

        /// <summary>
        /// 1.7版本，周卡
        /// </summary>
        WeeklyCard = 101002,

        /// <summary>
        /// 1.8版本，包赔
        /// </summary>
        Compensation = 101003,

        /// <summary>
        /// 1.8版本签到
        /// </summary>
        Signin101004 = 101004,

        /// <summary>
        /// 1.9版本每日转盘
        /// </summary>
        DailyWheel = 101005,

        /// <summary>
        /// 2.0版本积分转盘
        /// </summary>
        CoinWheel = 101006,

        /// <summary>
        /// 2.0版本签到送积分
        /// </summary>
        CoinSignin = 101007,

        /// <summary>
        /// 红包雨
        /// </summary>
        RedPackRain = 101008,

        /// <summary>
        /// 破产保护功能
        /// </summary>
        Banky = 101009,


        /// <summary>
        /// 邮件奖励
        /// </summary>
        EmailReward = 400001,

        /// <summary>
        /// VIP奖励
        /// </summary>
        Vip = 500001,

        /// <summary>
        /// VIP周奖励
        /// </summary>
        VipWeek = 500002

    }

    /// <summary>
    /// 活动种类
    /// </summary>
    public enum ActivityKind
    {
        /// <summary>
        /// 展示类活动
        /// </summary>
        Show = 1,

        /// <summary>
        /// 自定义活动
        /// </summary>
        Custom = 2,

        /// <summary>
        /// Job类活动
        /// </summary>
        Job = 3
    }

    /// <summary>
    /// 活动事件枚举，对应l_activity_event.EventID
    /// </summary>
    public enum ActivityEvent
    {
        /// <summary>
        /// 充值
        /// </summary>
        Pay = 1,

        /// <summary>
        /// 提现
        /// </summary>
        Cash = 2,

        /// <summary>
        /// 下注
        /// </summary>
        Bet = 3,

        /// <summary>
        /// 返奖
        /// </summary>
        Win = 4,

        /// <summary>
        /// 注册
        /// </summary>
        Register = 5,

        /// <summary>
        /// 签到
        /// </summary>
        SignIn = 6,

        /// <summary>
        /// 绑定手机
        /// </summary>
        BindMobile = 7,

        /// <summary>
        /// 输返
        /// </summary>
        LoseCashBack = 8
    }

    #endregion

    #region 巴西支付


    /// <summary>
    /// 巴西支付渠道（尽量与sb_paytype.PayTypeID保持一致）
    /// </summary>
    public enum BraPayChannel
    {
        /// <summary>
        /// panda pay
        /// </summary>
        pandapay = 4,

        /// <summary>
        /// tejee pay
        /// </summary>
        tejeepay = 5,

        /// <summary>
        /// letspay
        /// </summary>
        letspay = 7
    }

    /// <summary>
    /// tejeePay提现方式
    /// </summary>
    public enum TejeePayMethod
    {
        /// <summary>
        /// CPF
        /// </summary>
        CPF = 0,

        /// <summary>
        /// CNPJ
        /// </summary>
        CNPJ = 1,

        /// <summary>
        /// PHONE
        /// </summary>
        PHONE = 2,

        /// <summary>
        /// EMAIL
        /// </summary>
        EMAIL = 3,

        /// <summary>
        /// EVP
        /// </summary>
        EVP = 4
    }

    #endregion

    /// <summary>
    /// 通知类型
    /// </summary>
    public enum NotifyTypeEnum
    {
        /// <summary>
        /// 默认弹框通知
        /// </summary>
        None = 1,
        /// <summary>
        /// 邮件通知
        /// </summary>
        Email = 2
    }

    /// <summary>
    /// sc_banner.Position
    /// </summary>
    public enum BannerPosition
    {
        /// <summary>
        /// 首页推荐
        /// </summary>
        IndexRecommend = 1,
        /// <summary>
        /// 首页头部
        /// </summary>
        IndexHead = 2,
        /// <summary>
        /// 首页左侧菜单
        /// </summary>
        IndexMenu = 3,
        /// <summary>
        /// 个人中心
        /// </summary>
        Center = 4,
        /// <summary>
        /// 充值页banner
        /// </summary>
        Pay = 5,
        /// <summary>
        /// 首页浮动窗口
        /// </summary>
        IndexFloatingWindow = 6,
        /// <summary>
        /// 首页弹框
        /// </summary>
        IndexPopupBox = 7,
        /// <summary>
        /// 注册页面banner
        /// </summary>
        RegisterBanner = 8,

        /// <summary>
        /// 绑定手机号弹框
        /// </summary>
        BindMobile = 9
    }

}
