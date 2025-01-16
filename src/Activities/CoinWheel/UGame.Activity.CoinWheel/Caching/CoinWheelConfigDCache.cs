using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.CoinWheel.Repositories;

namespace UGame.Activity.CoinWheel.Caching;

public class CoinWheelConfigDCache : RedisStringClient<Sa_coinwheel_configPO>
{
    private const int EXPIRE_DAY = 1;//缓存有效期

    /// <summary>
    /// 
    /// </summary>
    public string OperatorId { get; set; }

    public CoinWheelConfigDCache(string operatorId)
    {
        if (string.IsNullOrEmpty(operatorId))
        {
            throw new CustomException("CoinWheelUserDCache:UserId不能为空");
        }
        OperatorId=operatorId;
        RedisKey=GetProjectGroupRedisKey("CoinWheel", $"{this.OperatorId}");
    }


    protected override async Task<CacheValue<Sa_coinwheel_configPO>> LoadValueWhenRedisNotExistsAsync()
    {
        var wheelUserRepository = DbUtil.GetRepository<Sa_coinwheel_configPO>();
        var value = await wheelUserRepository.AsQueryable().Where(_ => _.OperatorID == OperatorId).FirstAsync();

        var ret = new CacheValue<Sa_coinwheel_configPO>
        {
            HasValue = value != null,
            Value = value ?? new Sa_coinwheel_configPO()
        };
        return ret;
    }

    /// <summary>
    /// 加载缓存
    /// 如果不存在调用LoadValueWhenRedisNotExistsAsync
    /// </summary>
    /// <returns></returns>
    public async Task<Sa_coinwheel_configPO> GetAsync()
    {
        var cache = await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));

        if (cache.HasValue)
            return cache.Value;

        return new Sa_coinwheel_configPO();
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


}
