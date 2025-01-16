namespace UGame.Activity.DailyWheel.Models
{
    /// <summary>
    /// 加载轮盘
    /// </summary>
    public class DailyWheelLoadDto
    {
        /// <summary>
        /// 下次开始时间
        /// </summary>
        public DateTime? NextBeginTime { get; set; }

        /// <summary>
        /// 可抽奖次数
        /// </summary>
        public int LotteryNumbers { get; set; } = 0;
    }

    public class PositionInfo
    {
        /// <summary>
        /// 转盘位置
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string? ImagePath { get; set; }
    }
}
