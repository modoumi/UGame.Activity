using TinyFx.Caching;
using TinyFx.Extensions.StackExchangeRedis;

namespace UGame.Activity.CoinSignin.Caching;

public class CoinSigninResetRecordDCache : RedisStringClient<bool>
{
    private const int EXPIRE_MINUTES = 1500;

    public string UserId { get; set; }

    public CoinSigninResetRecordDCache(DateTime dayId, string userId)
    {
        this.UserId = userId;
        RedisKey = GetProjectRedisKey($"{dayId:yyyyMMdd}:{userId}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task<CacheValue<bool>> LoadValueWhenRedisNotExistsAsync()
    {
        var ret = new CacheValue<bool>
        {
            Value = false,
            HasValue = true
        };
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
