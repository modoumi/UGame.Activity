using UGame.Activity.TreasureBox.Models.Bos;

namespace UGame.Activity.TreasureBox.Utilities;

/// <summary>
/// 名称
/// </summary>
public static class BoxTemplateExtensions
{
    /// <summary>
    /// box名称
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public static string BoxName(this TreasureboxBo box)
    {
        if (box == null || box.Lang == null || string.IsNullOrEmpty(box.Lang.Name))
        {
            return string.Empty;
        }
        return box.Lang.Name;
    }

    /// <summary>
    /// 打开宝箱语言
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public static string BoxOpenRemark(this TreasureboxBo box)
    {
        if (box == null || box.OpenLang == null || string.IsNullOrWhiteSpace(box.OpenLang.Template))
        {
            return string.Empty;
        }
        return box.OpenLang.Template;
    }

    /// <summary>
    /// 备注
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public static string BoxRemark(this TreasureboxBo box)
    {
        if (box == null || box.Lang == null || string.IsNullOrEmpty(box.Lang.Remark))
        {
            return string.Empty;
        }
        return box.Lang.Remark;
    }

    /// <summary>
    /// 奖励备注
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public static string BoxRewardRemark(this TreasureboxBo box)
    {
        if (box == null || box.Lang == null || string.IsNullOrEmpty(box.Lang.AwardRemark))
        {
            return string.Empty;
        }

        return box.Lang.AwardRemark;
    }
}
