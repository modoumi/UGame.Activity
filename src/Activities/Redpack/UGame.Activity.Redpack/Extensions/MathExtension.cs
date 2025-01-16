namespace UGame.Activity.Redpack.Extensions;

/// <summary>
/// Math方法扩展类
/// </summary>
public static class MathExtension
{
    /// <summary>
    /// 获取金额
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static decimal MathTruncate(this decimal amount)
    {
        return Math.Truncate(amount * 100) / 100;
    }
}