using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.CoinSignin.Model;
using UGame.Activity.CoinSignin.Service;
using Xxyy.Common;

namespace UGame.Activity.CoinSignin.Controllers;

/// <summary>
/// 积分签到
/// </summary>
[EnableCors()]
[ClientSignFilter()]
public class CoinSigninController : TinyFxControllerBase
{
    private readonly CoinSigninService _signinService;

    public CoinSigninController()
    {
        _signinService=new CoinSigninService();
    }

    /// <summary>
    /// 加载签到
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CoinSigninLoadDto> Load(CoinSigninIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await _signinService.LoadAsync(ipo);
    }

    /// <summary>
    /// 签到
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CoinSigninDto> Execute(CoinSigninIpo ipo)
    {
        ipo.UserId = base.UserId;
        using var redlock = await RedisUtil.LockAsync($"UGame.Activity.CoinSignin.Execute{base.UserId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"UGame.Activity.CoinSignin.Execute;Request for lock failed.userId:{ipo.UserId}");
        }

        return await _signinService.ExecuteAsync(ipo);
    }
}
