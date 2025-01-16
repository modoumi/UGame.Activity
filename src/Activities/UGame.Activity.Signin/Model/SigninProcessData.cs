using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Activity.Signin.SqlSugar;

namespace UGame.Activity.Signin.Model
{

    public class SigninProcessData
    {
        /// <summary>
        /// 运营商编码
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }
        /// <summary>
        /// 当前utc时间
        /// </summary>
        public DateTime UtcTime { get; set; }
        /// <summary>
        /// 当前日期
        /// </summary>
        public DateTime CurrentDate { get; set; }
        /// <summary>
        /// 签到周期
        /// </summary>
        public int SigninCycle { get; set; }
        /// <summary>
        /// 签到周期起始日期
        /// </summary>
        public DateTime SigninCycleStartDate { get; set; }
        /// <summary>
        /// 签到周期截止日期
        /// </summary>
        public DateTime SigninCycleEndDate { get; set; }
        /// <summary>
        /// 用户最后一次签到明细（可能为null）
        /// </summary>
        public Sa_signin101004_detailPO UserLastDetailEo { get; set; }
        /// <summary>
        /// 用户最近一个签到周期明细
        /// </summary>
        public List<Sa_signin101004_detailPO> UserLastDetailEoList { get; set; }
        /// <summary>
        /// 签到配置
        /// </summary>
        public Sa_signin101004_configPO SigninConfigEo { get; set; }
        /// <summary>
        /// 签到配置List
        /// </summary>
        public List<Sa_signin101004_oddsPO> SigninOddsEoList { get; set; }
        /// <summary>
        /// 用户当天充值总金额
        /// </summary>
        public long UserDaySumPayAmount { get; set; }
        /// <summary>
        /// 用户当天是否允许签到
        /// </summary>
        public bool IsSignin { get; set; } = false;
        /// <summary>
        /// 连续签到总共可以领取到的奖金
        /// </summary>
        public decimal SumBonus { get; set; } = 0;
        /// <summary>
        /// 还可以领取的奖金
        /// </summary>
        public decimal AllowSumBonus { get; set; } = 0;
    }

}
