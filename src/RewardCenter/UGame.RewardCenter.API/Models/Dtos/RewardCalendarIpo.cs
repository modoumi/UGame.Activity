using SActivity.Common.Ipos;

namespace UGame.RewardCenter.API.Models.Dtos;

/// <summary>
/// 奖励日历请求参数
/// </summary>
public class RewardCalendarIpo : LobbyBaseIpo
{
    /// <summary>
    /// 日历ID
    /// </summary>
    public string CalendarId { get; set; }
}
