namespace UGame.Activity.DailyWheel.Models
{
    public class DailyWheelResultDto
    {

        /// <summary>
        /// 下次开始时间
        /// </summary>
        public DateTime NextBeginTime { get; set; }

        /// <summary>
        /// 转盘位置
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// 奖励的Bonus
        /// </summary>
        public decimal Bonus { get; set; }

        /// <summary>
        /// 可抽奖次数
        /// </summary>
        public int LotteryNumbers { get; set; } = 0;

    }
}
