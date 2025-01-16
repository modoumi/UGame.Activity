using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.Rebate.Domain.Services;
using UGame.Activity.Rebate.Dtos.Requests;
using UGame.Activity.Rebate.Dtos.Responses;
using Xxyy.Common;

namespace UGame.Activity.Rebate.Controllers;

/// <summary>
/// 返点返水
/// </summary>
[EnableCors()]
[ClientSignFilter]
public class RebateController : TinyFxControllerBase
{
    private readonly RebateService rebateService = new();

    /// <summary>
    /// 获取返点列表
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<RebateDotResponse> GetRebateDotList(RebateDotRequet ipo)
    {
        ipo.UserId = base.UserId;
        return await rebateService.GetRebateDotList(ipo);
    }

    /// <summary>
    /// 领取返点奖励
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task TakeRebate(TakeRebateRequest ipo)
    {
        ipo.UserId = base.UserId;
        await rebateService.TakeRebate(ipo);
    }

    /// <summary>
    /// 获取每日的返水
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RebateWaterResponse> GetRebateWater(RebateWaterRequest ipo)
    {
        ipo.UserId = base.UserId;
        return await rebateService.GetRebateWater(ipo);
    }

    /// <summary>
    /// 获取返点的配置信心
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<RebateDotConfigResponse>> GetRebateDotConfig(RebateDotConfigRequest ipo)
    {
        ipo.UserId = base.UserId;
        return await rebateService.GetRebateDotConfig(ipo);
    }
    //[HttpGet]
    //[AllowAnonymous]
    //public async Task<string> Test()
    //{
    //    var json = "{\"messageId\":\"655456f7b86d5306f8eed8b6\",\"message\":\"{\\\"mqMeta\\\":{\\\"delay\\\":\\\"00:00:00\\\",\\\"messageId\\\":\\\"655456f70650cefa7848656d\\\",\\\"timestamp\\\":1700026103227,\\\"republishCount\\\":0},\\\"userId\\\":\\\"6554553a5a5f8810a5ad829e\\\",\\\"userKind\\\":1,\\\"appId\\\":\\\"best_shooter\\\",\\\"operatorId\\\":\\\"own_lobby_bra\\\",\\\"countryId\\\":\\\"BRA\\\",\\\"currencyId\\\":\\\"BRL\\\",\\\"currencyType\\\":9,\\\"betTime\\\":\\\"2023-11-15 13:28:23\\\",\\\"providerId\\\":\\\"own\\\",\\\"betType\\\":3,\\\"isFirst\\\":false,\\\"betAmount\\\":7840000,\\\"betBonus\\\":7840000,\\\"winAmount\\\":19816000,\\\"winBonus\\\":19816000,\\\"amount\\\":11976000,\\\"orderId\\\":\\\"655456f70650cefa7848656c\\\",\\\"roundClosed\\\":true,\\\"roundId\\\":\\\"546deabc-bcbd-42d9-96da-027f29ea28ce\\\"}\"}";
    //    var message = json.JsonTo<TinyFx.MessageDriven.TheaMessage>();
    //    var betMessage = message.Message.JsonTo<UserBetMsg>();
    //    var consumer = DIUtil.GetService<BetConsumer>();
    //    await consumer.Handle(betMessage);
    //    return "ok";
    //}
}
