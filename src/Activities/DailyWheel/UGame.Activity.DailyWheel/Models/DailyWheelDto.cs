namespace UGame.Activity.DailyWheel.Models
{
    public class DailyWheelDto
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
        /// 国家编码
        /// </summary>        
        public string CountryId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>        
        public string CurrencyId { get; set; }

        /// <summary>
        /// 语言编码
        /// </summary>        
        public string LangId { get; set; }

        /// <summary>
        /// 是否可抽奖 
        /// 0:抽奖活动未开始
        /// 1:可以抽奖
        /// </summary>
        public int Status { get; set; }


    }
}
