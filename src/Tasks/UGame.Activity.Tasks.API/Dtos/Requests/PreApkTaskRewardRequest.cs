using SActivity.Common.Ipos;

namespace UGame.Activity.Tasks.API.Dtos.Requests;

/// <summary>
/// 下载App返奖
/// </summary>
public class PreApkTaskRewardRequest : LobbyBaseIpo
{
    /// <summary>
    /// 记录Id
    /// </summary>
    public string DetailId { get; set; }

    /// <summary>
    /// 设备Id
    /// </summary>
    public string DeviceId { get; set; }
}
