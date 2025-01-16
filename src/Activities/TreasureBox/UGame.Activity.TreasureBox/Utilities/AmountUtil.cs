namespace UGame.Activity.TreasureBox.Utilities;

/// <summary>
/// 金额处理
/// </summary>
public static class AmountUtil
{
    /// <summary>
    /// 剩余金额计算
    /// </summary>
    /// <param name="remainAmount"></param>
    /// <param name="awardAmount"></param>
    /// <returns></returns>
    public static long RemainAmount(long remainAmount, long awardAmount)
    {
        if (remainAmount == 0)
        {
            return 0;
        }

        if (remainAmount == awardAmount)
        {
            return remainAmount;
        }

        if (remainAmount > awardAmount)
        {
            return awardAmount;
        }

        if (remainAmount < awardAmount)
        {
            return remainAmount;
        }

        return 0;
    }
}
