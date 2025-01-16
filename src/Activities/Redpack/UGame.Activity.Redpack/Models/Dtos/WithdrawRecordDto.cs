namespace UGame.Activity.Redpack.Models.Dtos;

public class WithdrawRecordDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime RecDate { get; set; }
}
