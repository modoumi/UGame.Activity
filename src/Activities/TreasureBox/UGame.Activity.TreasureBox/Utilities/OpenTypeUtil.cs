using UGame.Activity.TreasureBox.Models;
using UGame.Activity.TreasureBox.Models.Dtos;
using UGame.Activity.TreasureBox.Models.Enums;
using TinyFx;
using Xxyy.Common;

namespace UGame.Activity.TreasureBox.Utilities;

/// <summary>
/// 打开ATM转换
/// </summary>
public static class OpenTypeUtil
{
    /// <summary>
    /// 打开转换value
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public static decimal OpenTypeSwitchValue(this int type, long value, string currencyId)
    {
        var rst = type switch
        {
            1 => value.AToM(currencyId), // 直接打开
            2 => value.AToM(currencyId), // 累计存款
            3 => value.AToM(currencyId),   // 单笔存款
            4 => value.AToM(currencyId), // 累计下注
            5 => value.AToM(currencyId), // 净盈利
            6 => value.AToM(currencyId), // 净亏损
            7 => value, // 邀请好友注册
            8 => value, // 邀请好友存款
            9 => value,// 邀请好友下注
            10 => value, // 检验VIP
            _ => 0
        };
        return rst;
    }
}
