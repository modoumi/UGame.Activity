using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SActivity.Cupon.API.Models.Ipos;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.RedpackRain.Models.Ipos;
using UGame.Activity.RedpackRain.Services;
using Xxyy.Common;

namespace UGame.Activity.RedpackRain.Controllers;

[EnableCors()]
[ClientSignFilter()]
public class RedpackRainController : TinyFxControllerBase
{

    private readonly RedpackRainServices _services = new();

    /// <summary>
    /// 加载红包雨基础信息
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<LoadResponseDto> Load(LoadRequestIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await _services.LoadAsync(ipo);
    }

    /// <summary>
    /// 抽奖
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RaffleResponseDto> Raffle(RaffleRequestIpo input)
    {
        input.UserId = base.UserId;
        return await _services.RaffleAsync(input);
    }
 
}
