using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SActivity.Common.Ipos;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.RewardCenter.API.Models.Dtos;
using UGame.RewardCenter.API.Services;

namespace UGame.RewardCenter.API.Controllers;

/// <summary>
/// 奖励中心接口
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class RewardCenterController : TinyFxControllerBase
{
    private readonly RewardCenterService rewardCenterService = new();

    /// <summary>
    /// 获取奖励中心接口
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<RewardGroupDto>> GetRewardList(LobbyBaseIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await this.rewardCenterService.GetRewardList(ipo);
    }
    /// <summary>
    /// 获取奖励日历接口
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<RewardCalendarDto> GetCalendar(LobbyBaseIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await this.rewardCenterService.GetCalendar(ipo);
    }
    /// <summary>
    /// 日历领奖领奖接口
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<decimal> ReceiveCalendarReward(RewardCalendarIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await this.rewardCenterService.ReceiveCalendarReward(ipo);
    }
    /// <summary>
    /// 获取奖励日历明细
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<RewardCalendarDetailDto> GetCalendarDetail(RewardCalendarIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await this.rewardCenterService.GetCalendarDetail(ipo);
    }
    /// <summary>
    /// 领取返奖宝箱直发奖励
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<decimal> ReceiveReward(ReceiveRewardCenterIpo ipo)
    {
        ipo.UserId = base.UserId;
        return await this.rewardCenterService.ReceiveReward(ipo);
    }
    //[HttpPost, AllowAnonymous]
    //public async Task Test()
    //{
    //    var json = "{\"MQMeta\":{\"RoutingKey\":null,\"Delay\":\"00:00:00\",\"MessageId\":\"659e339f7003e25f7b113ee5\",\"Timestamp\":1704866719784,\"ErrorAction\":null,\"RepublishCount\":0},\"Type\":2,\"DayId\":\"2024-03-23T00:00:00\",\"SRStartTime\":\"2024-01-10T06:05:19.7807212Z\",\"SREndTime\":\"2024-01-10T06:05:19.7846659Z\",\"OperatorId\":\"own_lobby_bra13\"}";
    //    var message = json.JsonTo<SRPerDayMsg>();
    //    var consumer = new SrUserDayChangedConsumer();
    //    await consumer.Handle(message, CancellationToken.None);
    //}
}
