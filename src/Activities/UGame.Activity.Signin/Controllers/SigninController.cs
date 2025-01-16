using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.AspNet.ClientSign;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Signin.Model;
using UGame.Activity.Signin.Services;
using Xxyy.Common;

namespace UGame.Activity.Signin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors()]
    [ClientSignFilter]
    public class SigninController : TinyFxControllerBase
    {

        private SigninService _signinService = new();

        /// <summary>
        /// 加载签到
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SigninLoadDto> Load(SigninLoadIpo ipo)
        {
            ipo.UserId = base.UserId;
            return await _signinService.LoadAsync(ipo);
        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SigninDto> Execute(SigninIpo ipo)
        {
            ipo.UserId = base.UserId;
            using (var redlock = await RedisUtil.LockAsync($"UGame.Activity.Signin.Controllers.Execute{base.UserId}", 30))
            {
                if (!redlock.IsLocked)
                {
                    redlock.Release();
                    throw new CustomException(CommonCodes.UserConcurrent, $"UGame.Activity.Signin.Controllers.Execute;Request for lock failed.userId:{ipo.UserId}");
                }

                return await _signinService.ExecuteAsync(ipo);
            }
        }

    }
}
