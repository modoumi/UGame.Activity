namespace UGame.Activity.DailyWheel.Models
{
    public class DailyWheelConfigDto
    {

        /// <summary>
        /// Desc:活动Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ActivityID { get; set; }

        /// <summary>
        /// Desc:运营商编码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string OperatorID { get; set; }

        /// <summary>
        /// Desc:货币类型
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CurrencyID { get; set; }

        /// <summary>
        /// Desc:国家编码ISO 3166-1三位字母
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CountryID { get; set; }

        /// <summary>
        /// Desc:初始奖池数值
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int DefaultPot { get; set; }

        /// <summary>
        /// Desc:付费用户最大奖池数值
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int MaxPot { get; set; }

        /// <summary>
        /// Desc:付费用户上一日亏损累计速度
        /// Default:
        /// Nullable:False
        /// </summary>           
        public float PotRate { get; set; }

        /// <summary>
        /// Desc:奖池为0的时候的发奖额度
        /// Default:
        /// Nullable:False
        /// </summary>           
        public float MinReward { get; set; }

        /// <summary>
        /// Desc:设备Id限制次数
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int DeviceIdLimit { get; set; }

        /// <summary>
        /// Desc:请求IP限制次数
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int IPLimit { get; set; }

        /// <summary>
        /// Desc:打码倍数
        /// Default:
        /// Nullable:False
        /// </summary>           
        public float FlowMultip { get; set; }

        /// <summary>
        /// Desc:重置时间，数组形式
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ResetTime { get; set; }

        /// <summary>
        /// Desc:状态(0-无效1-有效)
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Status { get; set; }

    }
}
