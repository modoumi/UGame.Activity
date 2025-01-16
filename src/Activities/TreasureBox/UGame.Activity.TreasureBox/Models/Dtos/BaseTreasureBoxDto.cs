namespace UGame.Activity.TreasureBox.Models.Dtos;

/// <summary>
/// 宝箱对象
/// </summary>
public class BaseTreasureBoxDto
{
    /// <summary>
    /// 宝箱名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 有效时间
    /// </summary>
    public DateTime EffectiveTime { get; set; }

    /// <summary>
    /// 皮肤
    /// </summary>
    public string Skin { get; set; } 
}
