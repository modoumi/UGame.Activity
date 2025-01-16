using System.Runtime.Serialization;

namespace UGame.Activity.CoinSignin.Model;

public class CoinSigninLoadDto
{
    /// <summary>
    /// 用户当天是否允许签到
    /// </summary>
    [DataMember(Order = 1)]
    public bool IsSignin { get; set; } = false;

    /// <summary>
    /// 当前周期签到次数
    /// </summary>
    public int SigninTimes { get; set; } = 0;

    /// <summary>
    /// 当前周期上一次签到日期
    /// </summary>
    public string? PreSigninDate { get; set; }

    /// <summary>
    /// 漏签日期集合
    /// </summary>
    public List<string?>? MissSigninDays { get; set; }

    /// <summary>
    /// 签到列表
    /// </summary>
    public List<CoinSignDetails> Items { get; set; } = new List<CoinSignDetails>();

}

public class CoinSignDetails
{
    /// <summary>
    /// 用户编码
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 是否选中
    /// </summary>
    public bool IsSelected { get; set; }

    /// <summary>
    /// 当前日期
    /// </summary>
    public string? DayId { get; set; }

    /// <summary>
    /// 当前周期标识
    /// </summary>
    public int DateNumber { get; set; }

    /// <summary>
    /// 当前日期返奖金额
    /// </summary>
    public decimal Reward { get; set; }

    public DateTime? RecDate { get; set; }

    /// <summary>
    /// SigninStatus
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 签到描述，上线后删除
    /// </summary>
    public string StatusDesc
    {
        get
        {
            if (Status == 1)
                return "已签到";
            if (Status == 2)
                return "允许签到";
            if (Status == 3)
                return "漏签";
            if (Status == 4)
                return "不允许签到";
            return "状态异常是bug";
        }
    }
}
