using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.Cupon.Models.Ipos;
using UGame.Activity.Cupon.Services;
using Xxyy.Common;

namespace UGame.Activity.Cupon.Controllers;

/// <summary>
/// 兑换码
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class CuponController : TinyFxControllerBase
{
    private readonly CuponServices _svc = new();
    /// <summary>
    /// 兑换验证码
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CuponResponseDto> CuponValite([FromBody]  CuponRequestIpo ipo) =>  await _svc.CuponValiteAsync(ipo,UserId);

}
