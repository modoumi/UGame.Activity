using SActivity.Common.Ipos;

namespace UGame.Activity.Rebate.Dtos.Requests;

public class TakeRebateRequest : LobbyBaseIpo
{
    public string DetailID { get; set; }
}
