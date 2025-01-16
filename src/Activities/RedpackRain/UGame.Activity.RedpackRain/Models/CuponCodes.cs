namespace SActivity.TreasureBox.API.Models;

public class CuponCodes
{
    /// <summary>
    /// 无效兑换码
    /// </summary>
    public const string RS_CUPON_INVALID = "RS_CUPON_INVALID";

    /// <summary>
    /// 错误兑换码
    /// </summary>
    public const string RS_CUPON_ERROR = "RS_CUPON_ERROR";

    /// <summary>
    /// 当前无法兑换，请联系客服
    /// </summary>
    public const string RS_CUPON_FJ = "RS_CUPON_FJ";

    /// <summary>
    /// 已领取过此类奖励 
    /// </summary>
    public const string RS_CUPON_RECEIVE = "RS_CUPON_RECEIVE";

    /// <summary>
    /// 不符合兑换条件 
    /// </summary>
    public const string RS_CUPON_NOTCONDITIONS = "RS_CUPON_NOTCONDITIONS";
}