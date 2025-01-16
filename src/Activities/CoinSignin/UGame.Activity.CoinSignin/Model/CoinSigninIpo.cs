using System.Text.Json.Serialization;
using TinyFx.AspNet;

namespace UGame.Activity.CoinSignin.Model;

public class CoinSigninIpo
{
    /// <summary>
    /// 用户编码
    /// </summary>
    [RequiredEx("", "UserId cannot be empty.")]
    public string UserId { get; set; }
    /// <summary>
    /// 运营商编码
    /// </summary>
    [RequiredEx("", "OperatorId cannot be empty.")]
    public string OperatorId { get; set; }
    /// <summary>
    /// 国家编码
    /// </summary>
    [RequiredEx("", "CountryId cannot be empty.")]
    public string CountryId { get; set; }
    /// <summary>
    /// 货币编码
    /// </summary>
    [RequiredEx("", "CurrencyId cannot be empty.")]
    public string CurrencyId { get; set; }
    /// <summary>
    /// 语言编码
    /// </summary>
    [RequiredEx("", "LangId cannot be empty.")]
    public string LangId { get; set; }
    /// <summary>
    /// 应用ID
    /// </summary>
    [RequiredEx("", "AppId cannot be empty.")]
    public string AppId { get; set; }

    /// <summary>
    /// 日期编号
    /// </summary>
    [RangeEx(1, 366, "", "DateNumber must be a correct integer between 1 and 366.")]
    public int DateNumber { get; set; } = 1;

    /// <summary>
    /// 签到过程中用到的数据
    /// </summary>
    [JsonIgnore]
    public CoinSigninProcessData? ProcessData { get; set; }
}
