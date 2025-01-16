using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Activity.Signin.Common
{
    /// <summary>
    /// 活动类型
    /// 100000-20000属于活动
    /// 400000-50000后台
    /// 500000-60000VIP
    /// </summary>
    public enum ActivityTypeEnum
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
        /// 1.8版本每日签到
        /// </summary>
        Signin101004 = 101004,


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
}
