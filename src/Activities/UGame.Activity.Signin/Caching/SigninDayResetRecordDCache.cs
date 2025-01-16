using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Caching;
using TinyFx.Data;
using TinyFx.Extensions.StackExchangeRedis;

namespace UGame.Activity.Signin.Caching
{
    public class SigninDayResetRecordDCache : RedisStringClient<bool>
    {
        private const int EXPIRE_MINUTES = 1500;

        public string UserId { get; set; }

        public SigninDayResetRecordDCache(DateTime dayId, string userId)
        {
            this.UserId = userId;
            RedisKey = GetProjectRedisKey($"{dayId.ToString("yyyyMMdd")}:{userId}");
        }

        protected override async Task<CacheValue<bool>> LoadValueWhenRedisNotExistsAsync()
        {
            var ret = new CacheValue<bool>();
            ret.Value = false;
            ret.HasValue = true;
            return ret;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetAsync()
        {
            var cache = await GetOrLoadAsync(false, TimeSpan.FromMinutes(EXPIRE_MINUTES));

            if (cache.HasValue)
                return cache.Value;

            return false;
        }

        /// <summary>
        /// SetAsync
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync()
        {
            await SetAsync(true, TimeSpan.FromMinutes(EXPIRE_MINUTES));
        }
    }

}
