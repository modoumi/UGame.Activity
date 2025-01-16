using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Repositories;
using StackExchange.Redis;
using System.Text.Json;
using TinyFx;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;

namespace SActivity.Redpack.API.Caching;

/// <summary>
/// 红包明细业务对象
/// </summary>
/// <param name="StarTime"></param>
/// <param name="EndTime"></param>
public record NumPollBo(DateTime StarTime, DateTime EndTime);

/// <summary>
/// 红包明细
/// </summary>
public class TreasureboxNumPoolDetailDCache : RedisHashExpireClient
{
    private const int EXPIRE_DAYS = 3;

    private string OperatorId { get; set; }

    private string BoxId { get; set; }

    private DateTime CurrDateTime { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="operatorId">运营商主键</param>
    /// <param name="boxId">宝箱主键</param>
    /// <param name="date">当地时间 LocalTime</param>
    public TreasureboxNumPoolDetailDCache(string operatorId, string boxId, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(operatorId))
            throw new CustomException("TreasureboxNumPoolDetailDCache: operatorId不能为空");
        OperatorId = operatorId;
        BoxId = boxId;
        CurrDateTime = date;
        RedisKey = GetProjectGroupRedisKey("Treasurebox", $"{OperatorId}|{BoxId}|{CurrDateTime:yyyyMMdd}");
    }

    /// <summary>
    /// 宝箱数量
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public async Task<(long num, NumPollBo bo)> NumDecrementAsync(int num)
    {
        await CreateAsync();
        var hash = await GetFiledKey();
        if (string.IsNullOrWhiteSpace(hash.filed)) return (0L, null);

        var luaScript = $@"
            local currentStock = redis.call('HGET', KEYS[1], '{hash.filed}')
            if tonumber(currentStock) >= tonumber(ARGV[1]) then
                return redis.call('HINCRBY', KEYS[1], '{hash.filed}', -tonumber(ARGV[1]))
            else
                return -1
            end ";

        var count = (long)await Database.ScriptEvaluateAsync(luaScript, new RedisKey[] { RedisKey }, new RedisValue[] { num });
        return (count, hash.bo);
    }

    /// <summary>
    /// 获取红包数量
    /// </summary>
    /// <returns></returns>
    public async Task<long> GetTreasureBoxNum()
    {
        var hash = await GetFiledKey();
        if (string.IsNullOrWhiteSpace(hash.filed)) return 0L;
        var packNum = await Database.HashGetAsync(RedisKey, hash.filed);
        if (!packNum.HasValue) return 0L;
        return (long)packNum;
    }

    /// <summary>
    /// 获取FiledKey
    /// </summary>
    /// <returns></returns>
    private async Task<(string filed, NumPollBo bo)> GetFiledKey()
    {
        var keys = await Database.HashKeysAsync(RedisKey);
        var timePeriods = (from key in keys
                           select key.ToString().Split("-")
                into times
                           let start = times[0].ToDateTime("yyyyMMddHH:mm:ss")
                           let end = times[1].ToDateTime("yyyyMMddHH:mm:ss")
                           select new NumPollBo(start, end))
            .ToList();
        var now = CurrDateTime;
        var time = timePeriods.FirstOrDefault(range => now >= range.StarTime && now <= range.EndTime);
        var filedKey = time == null ? string.Empty : $"{time.StarTime:yyyyMMddHH:mm:ss}-{time.EndTime:yyyyMMddHH:mm:ss}";
        var bo = time == null ? null : new NumPollBo(time.StarTime, time.EndTime);
        return (filedKey, bo);
    }

    /// <summary>
    /// 从Db创建
    /// </summary>
    public async Task CreateAsync()
    {
        if (!await Database.KeyExistsAsync(RedisKey))
        {
            var repostiroy = DbUtil.GetRepository<Sa_treasurebox_num_pool_detailPO>();
            var eos = await repostiroy.GetListAsync(w => w.OperatorID == this.OperatorId && w.StartTime.Date == CurrDateTime.Date && w.BoxID == this.BoxId);

            if (eos.Count == 0)
            {
                var now = CurrDateTime.Date;
                var configs = TreasureBoxMemoryCacheUtil.GetTreasureBoxNumConfig(OperatorId, BoxId);
                if (configs == null || configs.Count == 0) return;
                var details = configs.Select(w => new Sa_treasurebox_num_pool_detailPO
                {
                    OperatorID = OperatorId,
                    BoxID = BoxId,
                    StartTime = now + w.StartTime,
                    EndTime = now + w.EndTime,
                    Num = w.Num
                }).ToList();
                await repostiroy.InsertRangeAsync(details);
                eos = details;
            }

            await SetBaseValues(eos);
        }
    }

    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="eos"></param>
    /// <returns></returns>
    private async Task SetBaseValues(List<Sa_treasurebox_num_pool_detailPO> eos)
    {
        var dict = new Dictionary<string, object>();
        var date = CurrDateTime.Date;
        eos.ForEach(eo => { dict[$"{eo.StartTime:yyyyMMddHH:mm:ss}-{eo.EndTime:yyyyMMddHH:mm:ss}"] = eo.Num; });
        var entries = dict.Select((kv) => new HashEntry(kv.Key, JsonSerializer.SerializeToUtf8Bytes(kv.Value)));
        await Database.HashSetAsync(RedisKey, entries.ToArray());
        await Database.KeyExpireAsync(RedisKey, TimeSpan.FromDays(EXPIRE_DAYS));
    }
}