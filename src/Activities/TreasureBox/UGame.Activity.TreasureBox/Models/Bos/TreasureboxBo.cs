using UGame.Activity.TreasureBox.Repositories;

namespace UGame.Activity.TreasureBox.Models.Bos
{
    /// <summary>
    /// 宝箱对象
    /// </summary>
    public class TreasureboxBo : Sa_treasureboxPO
    {
        /// <summary>
        /// 奖励
        /// </summary>
        public List<Sa_treasurebox_awardPO> Awards { get; set; } = new();

        /// <summary>
        /// 语言
        /// </summary>
        public Sa_treasurebox_langPO Lang { get; set; } = new();

        /// <summary>
        /// 打开宝箱语言
        /// </summary>
        public Sa_treasurebox_open_langPO OpenLang { get; set; } = new();
    }
}
