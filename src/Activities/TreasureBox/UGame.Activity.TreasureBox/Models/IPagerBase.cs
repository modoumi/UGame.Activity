namespace UGame.Activity.TreasureBox.Models;

/// <summary>
/// 分页
/// </summary>
public interface IPagerBase
{
    /// <summary>
    /// 当前页码
    /// </summary>
    int PageIndex { get; set; }

    /// <summary>
    /// 页数量
    /// </summary>
    int PageSize { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    long Total { get; set; }
}
