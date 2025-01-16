using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.TreasureBox.Models;
using UGame.Activity.TreasureBox.Models.Dtos;
using UGame.Activity.TreasureBox.Models.Ipos;
using UGame.Activity.TreasureBox.Services;
using Xxyy.Common;

namespace UGame.Activity.TreasureBox.Controllers;

/// <summary>
/// 宝箱接口
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class TreasureBoxController : TinyFxControllerBase
{
    private readonly TreasureBoxServices _svc = new();

    /// <summary>
    /// 获取宝箱列表
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<PagerList<TreasureBoxResponseDto>> List([FromBody] TreasureBoxRequestIpo ipo) => await _svc.GetBoxesAsync(ipo, UserId);

    /// <summary>
    /// 打开宝箱
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<TreasureBoxAwardResponseDto> Open([FromBody] TreasureBoxAwardRequestIpo ipo) => await _svc.OpenAsync(ipo, UserId);
}
