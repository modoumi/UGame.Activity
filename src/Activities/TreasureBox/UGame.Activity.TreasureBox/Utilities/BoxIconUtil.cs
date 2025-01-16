using System.Text.Json;
using UGame.Activity.TreasureBox.Models.Dtos;
using UGame.Activity.TreasureBox.Models.Enums;

namespace UGame.Activity.TreasureBox.Utilities;

/// <summary>
/// 宝箱图标
/// </summary>
public static class BoxIconUtil
{
    /// <summary>
    /// 获取宝箱图标
    /// </summary>
    /// <param name="skinIcons"></param>
    /// <param name="iconStatus"></param>
    /// <returns></returns>
    public static string GetIconUrl(string skinIcons, TreasureBoxIconOpenEnum iconStatus)
    {
        var icons = new List<TreasureBoxIconDto>();
        if (!string.IsNullOrWhiteSpace(skinIcons))
        {
            icons = JsonSerializer.Deserialize<List<TreasureBoxIconDto>>(skinIcons);
        }

        var url = icons.FirstOrDefault(s => s.Status == (int)iconStatus)?.Url;
        return url;
    }
}
