using System.ComponentModel;

namespace UGame.Activity.CoinSignin.Common;

public enum SigninStatus
{
    [Description("预留状态")]
    None = 0,
    
    [Description("已签到")]
    Signined = 1,
   
    [Description("允许签到")]
    Allow = 2,
    
    [Description("漏签")]
    MissSignin = 3,
    
    [Description("不允许签到")]
    NoAllow = 4
}
