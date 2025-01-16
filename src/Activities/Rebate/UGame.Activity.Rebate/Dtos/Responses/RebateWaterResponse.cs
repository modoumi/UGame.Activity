namespace UGame.Activity.Rebate.Dtos.Responses;

public class RebateWaterResponse
{
    public decimal TotalBetAmount { get; set; }
    public decimal RebateAmount { get; set; }
    public DateTime RewardTime { get; set; }
    public string SearchKey { get; set; }
}
