using System.Globalization;

namespace SActivity.Common.Core;

/// <summary>
/// 
/// </summary>
public static class Extensions
{
    private readonly static Dictionary<string, string> langMap = new()
    {
        {"BRL","pt-BR"},
        {"MXN","es-ES"},
        {"GHS","en-US"},
        {"USD","en-US"}
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="moneyAmount"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    public static string ToMoneyString(this long moneyAmount, string currencyId)
    {
        if (!langMap.TryGetValue(currencyId.ToUpper(), out var culture))
            culture = "pt-BR";
        return moneyAmount.ToString("N0", CultureInfo.CreateSpecificCulture(culture));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="moneyAmount"></param>
    /// <param name="currenyId"></param>
    /// <returns></returns>
    public static string ToMoneyString(this decimal moneyAmount, string currenyId)
    {
        if (!langMap.TryGetValue(currenyId.ToUpper(), out var culture))
            culture = "pt-BR";
        return string.Format("{0:N2}", moneyAmount, CultureInfo.CreateSpecificCulture(culture));
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="moneyAmount"></param>
    /// <param name="precision"></param>
    /// <returns></returns>
    public static long ToPrecision(this long moneyAmount, int precision = 2)
    {
        int powTimes = (int)Math.Pow(10, precision);
        return moneyAmount / powTimes * powTimes;
    }
}
