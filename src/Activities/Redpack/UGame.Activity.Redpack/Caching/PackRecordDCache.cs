using StackExchange.Redis;
using TinyFx;
using TinyFx.Caching;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Redpack.Models.Dtos;
using UGame.Activity.Redpack.Utilities;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Activity.Redpack.Caching;

/// <summary>
/// 红包随机记录缓存
/// </summary>
public class PackRecordDCache : RedisStringClient<List<WithdrawRecordDto>>
{
    private const int EXPIRE_MINUTES = 10;

    private string OperatorId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="operatorId"></param>
    public PackRecordDCache(string operatorId)
    {
        OperatorId = operatorId;
        RedisKey = GetProjectGroupRedisKey("Redpack", $"{OperatorId}");
    }

    /// <summary>
    /// 随机生成100个用户
    /// </summary>
    /// <returns></returns>
    protected override async Task<CacheValue<List<WithdrawRecordDto>>> LoadValueWhenRedisNotExistsAsync()
    {
        var config = RedpackDbCacheUtil.GetRedpackConfig(OperatorId);
        var op = DbCacheUtil.GetOperator(OperatorId);

        var names = RandomUtil.GenerateRandomName(100);
        var currentDate = DateTime.UtcNow;

        var records = (from name in names
                       let randomDays = Random.Shared.Next(0, 3)
                       select new WithdrawRecordDto
                       {
                           UserName = name,
                           Amount = config.PackAmount.AToM(op.CurrencyID),
                           RecDate = currentDate.AddDays(-randomDays).ToLocalTime(OperatorId).Date,
                       }).ToList();

        var hasValue = records.Any();
        return new CacheValue<List<WithdrawRecordDto>>(hasValue, records);
    }

    /// <summary>
    /// 从Redis获取，降级到数据库
    /// </summary>
    /// <returns></returns>
    public async Task<List<WithdrawRecordDto>> GetFromRedisAsync()
    {
        var hasNotInRedis = !TryDeserialize<List<WithdrawRecordDto>>(await Database.StringGetAsync(RedisKey), out var value);
        if (!hasNotInRedis) return value;
        var ret = await LoadValueWhenRedisNotExistsAsync();
        if (ret.HasValue)
        {
            await Database.StringSetAsync(RedisKey, Serialize(ret.Value), TimeSpan.FromMinutes(EXPIRE_MINUTES), When.Always);
        }
        return ret.Value;
    }

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <returns></returns>
    public async Task<List<WithdrawRecordDto>> GetAsync()
    {
        var result = await GetOrLoadAsync(false, TimeSpan.FromMinutes(EXPIRE_MINUTES));
        if (!result.HasValue)
            throw new CustomException($"RedpackRecord异常,请检查配置！operatorid:{OperatorId}");
        return result.Value;
    }
}
