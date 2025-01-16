using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;
using TinyFx;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Redpack.Repositories.sa;

namespace UGame.Activity.Redpack.Caching;

/// <summary>
/// 有效红包缓存
/// </summary>
public class EffectiveDCache : RedisHashExpireClient
{
    private string UserId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="userId"></param>
    /// <exception cref="CustomException"></exception>
    public EffectiveDCache(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CustomException("EffectiveDCache: userId不能为空");
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey("Redpack", UserId);
    }

    /// <summary>
    /// 追加剩余次数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public async Task<long> RemainCountIncrementAsync(long num)
    {
        var remainCount = nameof(Sa_redpack_user_packEO.RemainCount);
        return await Database.HashIncrementAsync(RedisKey, remainCount, num);
    }

    /// <summary>
    /// 扣减剩余次数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public async Task<long> RemainCountDecrementAsync(long num)
    {
        var remainCount = nameof(Sa_redpack_user_packEO.RemainCount);
        var luaScript = $@"
            local currentStock = redis.call('HGET', KEYS[1], '{remainCount}')
            if tonumber(currentStock) >= tonumber(ARGV[1]) then
                return redis.call('HINCRBY', KEYS[1], '{remainCount}', -tonumber(ARGV[1]))
            else
                return 0
            end ";

        return (long)await Database.ScriptEvaluateAsync(luaScript, new RedisKey[] { RedisKey }, new RedisValue[] { num });
    }

    /// <summary>
    /// 追加当前金额
    /// </summary>
    /// <returns></returns>
    public async Task<long> CurrAmountIncrementAsync(long amount)
    {
        var currAmount = nameof(Sa_redpack_user_packEO.CurrAmount);
        return await Database.HashIncrementAsync(RedisKey, currAmount, amount);
    }

    /// <summary>
    /// 追加下注金额
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public async Task<long> IncrementBetAmount(long amount)
    {
        var betAmount = nameof(Sa_redpack_user_packEO.BetAmount);
        return await Database.HashIncrementAsync(RedisKey, betAmount, amount);
    }

    /// <summary>
    /// 重置下注额
    /// </summary>
    /// <returns></returns>
    public async Task ResetBetAmount()
    {
        var betAmount = nameof(Sa_redpack_user_packEO.BetAmount);
        await Database.HashSetAsync(RedisKey, betAmount, 0);
    }

    /// <summary>
    /// 重置充值额
    /// </summary>
    /// <returns></returns>
    public async Task ResetPayAmount()
    {
        var payAmount = nameof(Sa_redpack_user_packEO.PayAmount);
        await Database.HashSetAsync(RedisKey, payAmount, 0);
    }

    /// <summary>
    /// 追加支付金额
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public async Task<long> IncrementPayAmount(long amount)
    {
        var payAmount = nameof(Sa_redpack_user_packEO.PayAmount);
        return await Database.HashIncrementAsync(RedisKey, payAmount, amount);
    }

    /// <summary>
    /// 设置值
    /// </summary>
    /// <param name="pack"></param>
    /// <param name="isFirstCreate"></param>
    public async Task SetAsync(Sa_redpack_user_packEO pack, bool isFirstCreate = false)
    {
        var dict = new Dictionary<string, object>();
        var properties = pack.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            dict[property.Name] = property.GetValue(pack);
        }

        if (isFirstCreate)
        {
            var seconds = (pack.RecDate.AddHours(pack.Expire) - pack.RecDate).TotalSeconds;
            var entries = dict.Select((kv) => new HashEntry(kv.Key, JsonSerializer.SerializeToUtf8Bytes(kv.Value)));
            await Database.HashSetAsync(RedisKey, entries.ToArray());
            await Database.KeyExpireAsync(RedisKey, TimeSpan.FromSeconds(seconds));
        }

        var kvs = dict.Select((kv) => new HashEntry(kv.Key, JsonSerializer.SerializeToUtf8Bytes(kv.Value)));
        await Database.HashSetAsync(RedisKey, kvs.ToArray());
    }

    /// <summary>
    /// 填充用户信息
    /// </summary>
    /// <returns></returns>
    public async Task<Sa_redpack_user_packEO> GetFromRedisOrDBAsync()
    {
        var pack = await GetFromRedisAsync();
        if (pack is not null) return pack;
        var nowTime = DateTime.UtcNow;
        pack = await new Sa_redpack_user_packMO().GetSingleAsync("UserID=@UserID AND IsWidthdraw=0 AND @Time>=RecDate AND @Time<DATE_ADD(RecDate, INTERVAL Expire HOUR)", UserId, nowTime);
        if (pack == null) return null;
        await SetBaseValues(pack);
        return pack;
    }

    /// <summary>
    /// 直接从redis读取
    /// </summary>
    /// <returns></returns>
    public async Task<Sa_redpack_user_packEO> GetFromRedisAsync()
    {
        var pack = default(Sa_redpack_user_packEO);
        var array = await Database.HashGetAllAsync(RedisKey);

        if (array is { Length: 0 }) return null;
        pack = new Sa_redpack_user_packEO();
        foreach (var hashEntry in array)
        {
            string propertyName = hashEntry.Name;
            var propertyValue = hashEntry.Value;
            var property = typeof(Sa_redpack_user_packEO).GetProperty(propertyName);

            if (property == null || !propertyValue.HasValue) continue;

            var fieldValueBytes = (byte[])propertyValue;
            if (property.PropertyType == typeof(DateTime))
            {
                DateTime.TryParse(propertyValue, out var time);
                property.SetValue(pack, Convert.ChangeType(time, property.PropertyType));
                continue;
            }

            var value = JsonSerializer.Deserialize(fieldValueBytes, property.PropertyType);
            property.SetValue(pack, Convert.ChangeType(value, property.PropertyType));
        }

        return pack;
    }

    /// <summary>
    /// 设置业务UserBo
    /// </summary>
    /// <param name="pack"></param>
    private async Task<Sa_redpack_user_packEO> SetBaseValues(Sa_redpack_user_packEO pack)
    {
        var dict = new Dictionary<string, object>();
        var properties = pack.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            dict[property.Name] = property.GetValue(pack);
        }

        var seconds = (pack.RecDate.AddHours(pack.Expire) - pack.RecDate).TotalSeconds;
        var entries = dict.Select((kv) => new HashEntry(kv.Key, JsonSerializer.SerializeToUtf8Bytes(kv.Value)));
        await Database.HashSetAsync(RedisKey, entries.ToArray());
        await Database.KeyExpireAsync(RedisKey, TimeSpan.FromSeconds(seconds));
        return pack;
    }
}