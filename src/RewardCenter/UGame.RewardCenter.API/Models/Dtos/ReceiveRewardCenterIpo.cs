using SActivity.Common.Ipos;

namespace UGame.RewardCenter.API.Models.Dtos;

public class ReceiveRewardCenterIpo : LobbyBaseIpo
{
    /// <summary>
    /// 奖励ID
    /// </summary>
    public string RewardId { get; set; }
}
