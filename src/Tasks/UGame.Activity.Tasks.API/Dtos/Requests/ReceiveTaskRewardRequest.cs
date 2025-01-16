using SActivity.Common.Ipos;

namespace UGame.Activity.Tasks.API.Dtos.Requests;

public class ReceiveTaskRewardRequest: LobbyBaseIpo
{
    public string DetailId { get; set; }
}
