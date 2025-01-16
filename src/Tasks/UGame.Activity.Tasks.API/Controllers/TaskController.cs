using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SActivity.Common.Ipos;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.Tasks.API.Domain.Services;
using UGame.Activity.Tasks.API.Dtos.Requests;
using UGame.Activity.Tasks.API.Dtos.Responses;

namespace UGame.Activity.Tasks.API.Controllers;

/// <summary>
/// 任务中心接口
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class TaskController : TinyFxControllerBase
{
    private readonly TaskService taskService = new();

    /// <summary>
    /// 获取任务列表
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TaskDetailDto>> GetTaskList(LobbyBaseIpo request)
        => await this.taskService.GetTaskList(this.UserId, request.LangId);

    /// <summary>
    /// 获取任务Tips
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TaskTipsResponse>> GetTaskTips(LobbyBaseIpo request)
        => await this.taskService.GetTaskTips(this.UserId, request.OperatorId, request.CurrencyId, request.LangId);

    /// <summary>
    /// 获取提取金额
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<DrawableAmountDto> GetDrawableAmount(LobbyBaseIpo request)
        => await this.taskService.GetDrawableAmount(this.UserId, request.LangId);

    /// <summary>
    /// 获取奖励
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="CustomException"></exception>
    [HttpPost]
    public async Task ReceiveReward(ReceiveTaskRewardRequest request)
    {
        if (string.IsNullOrEmpty(request.DetailId))
            throw new CustomException("DetailId不能为null");
        await this.taskService.ReceiveReward(this.UserId, request.DetailId, request.AppId, request.CountryId);
    }
    /// <summary>
    /// 下载APK任务，领取奖励前，预处理
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ReceiveTaskRewardResponse> PreApkTask(PreApkTaskRewardRequest ipo)
    {
        ipo.UserId = base.UserId;
        return await this.taskService.PreApkDownLoadReward(ipo);
    }
}
