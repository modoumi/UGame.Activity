namespace UGame.Activity.DailyWheel.Models
{
    public class DailyWheelUserDto
    {
        /// <summary>
        /// 用户编码
        /// </summary>        
        public string UserId { get; set; }

        /// <summary>
        /// 运营商编码
        /// </summary>        
        public string OperatorId { get; set; }

        /// <summary>
        /// 0:非充值用户
        /// 1:充值用户
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 当前用户奖池金额
        /// </summary>
        public decimal CurrentReward { get; set; }

        /// <summary>
        /// 最近一次累计金额
        /// </summary>
        public decimal AddReward { get; set; }

        /// <summary>
        /// 是否可抽奖 
        /// 0:抽奖活动未开始
        /// 1:可以抽奖
        /// </summary>
        public int Status { get; set; }


    }
}
