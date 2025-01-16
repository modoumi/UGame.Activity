using UGame.Activity.Cupon.Repositories;
using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;
using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;

namespace UGame.Activity.Cupon.Caching;

/// <summary>
/// 用户错误兑换码次数
/// </summary>
public class CuponErrorUserDCache : RedisStringClient<string>
{
    private string UserId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="userId"></param>
    public CuponErrorUserDCache(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CustomException("CuponUserDCache: userId不能为空");
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey("Cupon", UserId);
        Options.SlidingExpiration = TimeSpan.FromMinutes(5);
    }

    /// <summary>
    /// 自增
    /// </summary>
    /// <returns></returns>
    public async Task<long> IncrementAsync()
    {
        long res = await base.IncrementAsync();

        if (res >= 3)
        {

            await this.KeyExpireMinutesAsync(30);
        }

        return res;
    }

}