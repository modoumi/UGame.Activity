using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.CoinWheel.Models;
using UGame.Activity.CoinWheel.Services;

namespace UGame.Activity.CoinWheel.Controllers;

[EnableCors()]
[ClientSignFilter()]
public class CoinWheelController:TinyFxControllerBase
{

    private readonly CoinWheelServices _services = new();

    /// <summary>
    /// 加载转盘信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CoinWheelLoadDto> Load(CoinWheelIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await _services.LoadAsync(ipo);
    }

    /// <summary>
    /// 抽奖
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<CoinWheelResultDto> Raffle(CoinWheelIpo input)
    {
        input.UserId = base.UserId;
        return await _services.RaffleAsync(input);
    }
}
