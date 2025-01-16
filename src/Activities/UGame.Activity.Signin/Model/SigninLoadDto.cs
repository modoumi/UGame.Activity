using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UGame.Activity.Signin.Model
{
    public class SigninLoadDto
    {

        /// <summary>
        /// 用户当天是否允许签到
        /// </summary>
        [DataMember(Order = 1)]
        public bool IsSignin { get; set; } = false;
        /// <summary>
        /// 签到需要完成的充值金额
        /// </summary>
        public decimal SigninPayAmount { get; set; }
        /// <summary>
        /// 当前周期签到次数
        /// </summary>
        public int SigninTimes { get; set; } = 0;
        /// <summary>
        /// 当前周期上一次签到日期
        /// </summary>
        public string PreSigninDate { get; set; } = null;
        /// <summary>
        /// 是否提示重置弹框
        /// </summary>
        public bool IsTipReset { get; set; } = false;
        /// <summary>
        /// 漏签日期集合
        /// </summary>
        public List<string> MissSigninDays { get; set; } = new List<string>();
        /// <summary>
        /// 连续签到总共可以领取到的奖金
        /// </summary>
        public decimal SumBonus { get; set; } = 0;
        /// <summary>
        /// 还可以领取的奖金
        /// </summary>
        public decimal AllowSumBonus { get; set; } = 0;
        /// <summary>
        /// 【测试字段】服务器时间
        /// </summary>
        public string ServerTime { get; set; }
        /// <summary>
        /// 【测试字段】UTC时间
        /// </summary>
        public string UtcTime { get; set; }
        /// <summary>
        /// 【测试字段】运营商当地时间
        /// </summary>
        public string LocalTime { get; set; }
        /// <summary>
        /// 【测试字段】本次签到周期起始日期
        /// </summary>
        public string SigninCycleStartDate { get; set; }
        /// <summary>
        /// 【测试字段】本次签到周期截止日期
        /// </summary>
        public string SigninCycleEndDate { get; set; }
        /// <summary>
        /// 签到列表
        /// </summary>
        public List<UserSignDetails> Items { get; set; } = new List<UserSignDetails>();
    }

    public class UserSignDetails
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// 当前日期
        /// </summary>
        public string DayId { get; set; } = null;
        /// <summary>
        /// 当前周期标识
        /// </summary>
        public int DateNumber { get; set; }
        /// <summary>
        /// 当前日期返奖金额（已签到则为实际奖励金额，未签到、漏签为最大奖励金额）
        /// </summary>
        public decimal Reward { get; set; }
        /// <summary>
        /// 奖金显示类型
        /// 0-默认
        /// 1-、、、
        /// </summary>
        public int RewardShowType { get; set; }

        public DateTime? RecDate { get; set; } = null;

        /// <summary>
        /// SigninStatus
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 签到描述，上线后删除
        /// </summary>
        public string StatusDesc
        {
            get
            {
                if (this.Status == 1)
                    return "已签到";
                if (this.Status == 2)
                    return "允许签到";
                if (this.Status == 3)
                    return "漏签";
                if (this.Status == 4)
                    return "不允许签到";
                return "状态异常是bug";
            }
        }
    }
}
