using UGame.Activity.CoinSignin.Repositories;

namespace UGame.Activity.CoinSignin.Model;

public class CoinSigninProcessData
{
    /// <summary>
    /// 运营商编码
    /// </summary>
    public string OperatorId { get; set; }

    /// <summary>
    /// 货币编码
    /// </summary>
    public string CurrencyId { get; set; }

    /// <summary>
    /// 当前utc时间
    /// </summary>
    public DateTime UtcTime { get; set; }

    /// <summary>
    /// 当前日期
    /// </summary>
    public DateTime CurrentDate { get; set; }

    /// <summary>
    /// 签到周期
    /// </summary>
    public int SigninCycle { get; set; }

    /// <summary>
    /// 签到周期起始日期
    /// </summary>
    public DateTime SigninCycleStartDate { get; set; }

    /// <summary>
    /// 签到周期截止日期
    /// </summary>
    public DateTime SigninCycleEndDate { get; set; }

    /// <summary>
    /// 用户最后一次签到明细（可能为null）
    /// </summary>
    public Sa_coin_signin_detailPO UserLastDetailEo { get; set; }

    /// <summary>
    /// 用户最近一个签到周期明细
    /// </summary>
    public List<Sa_coin_signin_detailPO> UserLastDetailEoList { get; set; }

    /// <summary>
    /// 签到配置
    /// </summary>
    public List<Sa_coin_signin_configPO> SigninConfigEoList { get; set; }
        
    /// <summary>
    /// 用户当天是否允许签到
    /// </summary>
    public bool IsSignin { get; set; }=false;
    
}
