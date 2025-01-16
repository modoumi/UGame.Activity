using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;
using TinyFx;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Redpack.Models.Bos;
using UGame.Activity.Redpack.Repositories.sa;

namespace UGame.Activity.Redpack.Caching;

/// <summary>
/// 用户缓存对象
/// </summary>
public class UserDCache : RedisHashExpireClient
{
    private const int EXPIRE_DAYS = 30; // 缓存有效期

    private string UserId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="userId"></param>
    public UserDCache(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CustomException("RedpackNumDCache: userId不能为空");
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey("Redpack", UserId);
    }

    /// <summary>
    /// 用户红包递增
    /// </summary> 
    /// <returns></returns>
    public async Task<long> UserPackNumIncrementAsync()
    {
        var packNum = nameof(RedpackUserBo.PackNum);
        return await Database.HashIncrementAsync(RedisKey, packNum, 1);
    }

    /// <summary>
    /// 获取红包数量
    /// </summary>
    /// <returns></returns>
    public async Task<long> GetUserPackNumAsync()
    {
        await Create();
        var packNum = nameof(RedpackUserBo.PackNum);
        return (long)await Database.HashGetAsync(RedisKey, packNum);
    }

    /// <summary>
    /// 填充用户信息
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public async Task Create(Func<Task<RedpackUserBo>> func = null)
    {
        if (!await Database.KeyExistsAsync(RedisKey))
        {
            var packNum = await new Sa_redpack_user_packMO().GetCountAsync("UserID=@UserID AND CurrAmount>=PackAmount");
            var userBo = new RedpackUserBo
            {
                PackNum = packNum,
            };
            await SetBaseValues(userBo);
        }
    }

    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="bo"></param>
    /// <returns></returns>
    private async Task SetBaseValues(RedpackUserBo bo)
    {
        var dict = new Dictionary<string, object>();
        var properties = bo.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            dict[property.Name] = property.GetValue(bo);
        }
        var entries = dict.Select((kv) => new HashEntry(kv.Key, JsonSerializer.SerializeToUtf8Bytes(kv.Value)));
        await Database.HashSetAsync(RedisKey, entries.ToArray());
    }
}