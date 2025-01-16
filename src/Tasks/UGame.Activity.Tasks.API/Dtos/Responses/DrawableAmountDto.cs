namespace UGame.Activity.Tasks.API.Dtos.Responses;

public class DrawableAmountDto
{
    public decimal TotalAmount { get; set; }
    public decimal RegisterAmount { get; set; }
    /// <summary>
    /// 注册奖励是否已领取
    /// </summary>
    public bool IsRegisterReceived { get; set; }
}
