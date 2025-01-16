using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.CoinWheel.Repositories;

namespace UGame.Activity.CoinWheel.Caching;

public class CoinWheelPositionDCache : RedisStringClient<List<Sa_coinwheel_positionPO>>
{

    private const int EXPIRE_DAY = 1;// 缓存有效期

    public string OperatorId { get; set; }


    /// <summary>
    /// 构造
    /// </summary>
    public CoinWheelPositionDCache(string operatorId)
    {
        if (string.IsNullOrEmpty(operatorId))
        {
            throw new CustomException("CoinWheelUserDCache:OperatorId不能为空");
        }

        this.OperatorId = operatorId;
        RedisKey = GetProjectGroupRedisKey("CoinWheel", $"{this.OperatorId}");
    }

    protected override async Task<CacheValue<List<Sa_coinwheel_positionPO>>> LoadValueWhenRedisNotExistsAsync()
    {
        var wheelUserRepository = DbUtil.GetRepository<Sa_coinwheel_positionPO>();
        var value = await wheelUserRepository.AsQueryable().Where(_ => _.OperatorID == OperatorId).ToListAsync();

        var ret = new CacheValue<List<Sa_coinwheel_positionPO>>
        {
            HasValue = value != null,
            Value = value ?? new List<Sa_coinwheel_positionPO>()
        };
        return ret;
    }

    /// <summary>
    /// 加载缓存
    /// 如果不存在调用LoadValueWhenRedisNotExistsAsync
    /// </summary>
    /// <returns></returns>
    public async Task<List<Sa_coinwheel_positionPO>> GetAsync()
    {
        var cache = await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));

        if (cache.HasValue)
            return cache.Value;

        return new List<Sa_coinwheel_positionPO>();
    }

    /// <summary>
    /// 强制加载
    /// enforce=true
    /// </summary>
    /// <returns></returns>
    public async Task SetAsync()
    {
        await GetOrLoadAsync(true, TimeSpan.FromDays(EXPIRE_DAY));
    }

    /// <summary>
    /// 更新缓存
    /// </summary>
    /// <param name="lastPosition"></param>
    /// <returns></returns>
    public async Task SetAsync(List<Sa_coinwheel_positionPO> lastPosition)
    {
        await SetAsync(lastPosition, TimeSpan.FromDays(EXPIRE_DAY));
    }
}
