using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.Redpack.Models.Dtos;
using UGame.Activity.Redpack.Models.Ipos;
using UGame.Activity.Redpack.Services;

namespace UGame.Activity.Redpack.Controllers;

/// <summary>
/// 红包接口
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class RedpackController : TinyFxControllerBase
{
    private readonly RedpackService _redpackSvc = new();

    /// <summary>
    /// 红包信息
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RedpackRaffleDto> PackInfo() => await _redpackSvc.PackInfo(UserId);

    /// <summary>
    /// 开始抽奖
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RedpackRaffleDto> Raffle([FromBody] ClientBaseIpo ipo) => await _redpackSvc.Raffle(ipo, UserId);

    /// <summary>
    /// 提现
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<dynamic> Withdraw([FromBody] ClientBaseIpo ipo) => await _redpackSvc.CashWithdraw(ipo, UserId);

    /// <summary>
    /// 抽奖任务完成记录 - 当前红包的任务完成记录
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TaskRecordDto>> TaskRecord() => await _redpackSvc.TaskRecord(UserId);

    /// <summary>
    /// 获取红包的记录
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<WithdrawRecordDto>> RedpackRecord() => await _redpackSvc.RedpackRecord(UserId);

    /// <summary>
    /// 下载客户端
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task DownApp() => await _redpackSvc.DownApp(UserId);

    /// <summary>
    /// 分享
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task Share() => await _redpackSvc.Share(UserId);
}
