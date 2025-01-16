namespace UGame.Activity.CoinSignin.Model;

/// <summary>
/// 
/// </summary>
public class CoinSigninDto
{
    public bool Status { get; set; } = false;

    public decimal Reward { get; set; } = 0;

    public string? StatusDesc { get; set; }
}