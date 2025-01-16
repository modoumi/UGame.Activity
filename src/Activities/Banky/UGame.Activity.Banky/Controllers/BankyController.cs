using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.Banky.Models;
using UGame.Activity.Banky.Services;

namespace UGame.Activity.Banky.Controllers;

[EnableCors()]
[ClientSignFilter()]
public class BankyController : TinyFxControllerBase
{

    private readonly BankyService _bankyService = new();

    /// <summary>
    /// 是否已展示过
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task IsDisplay(BankyIpo ipo)
    {
        ipo.UserId = base.UserId;
        await _bankyService.IsDisplay(ipo);
    }
}
