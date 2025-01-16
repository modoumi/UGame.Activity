using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using UGame.Activity.DailyWheel.Models;
using UGame.Activity.DailyWheel.Services;
using Xxyy.Common;

namespace UGame.Activity.DailyWheel.Controllers
{
    /// <summary>
    /// 每日转盘
    /// </summary>
    [EnableCors()]
    [ClientSignFilter()]
    public class DailyWheelController : TinyFxControllerBase
    {
        private readonly DailyWheelServices _services = new();

        /// <summary>
        /// 加载转盘信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<DailyWheelLoadDto> Load(DailyWheelIpo ipo)
        {
            ipo.UserId = base.UserId;
            return await _services.LoadAsync(ipo);
        }

        /// <summary>
        /// 抽奖
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<DailyWheelResultDto> Raffle(DailyWheelIpo input)
        {
            input.UserId = base.UserId;
            return await _services.RaffleAsync(input);
        }
    }
}
