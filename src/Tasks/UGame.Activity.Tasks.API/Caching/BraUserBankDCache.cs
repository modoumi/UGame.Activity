using TinyFx.Caching;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Tasks.API.Domain.Models;

namespace UGame.Activity.Tasks.API.Caching;


public class BraUserBankDCache : RedisStringClient<List<L_bra_user_bankEO>>
{
    private const int EXPIRE_DAY = 1;

    private string OperatorId { get; set; }

    private string UserId { get; set; }

    public BraUserBankDCache(string operatorId, string userId)
    {
        OperatorId = operatorId;
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey("UserBank", $"{operatorId}:{userId}");
    }

    protected override async Task<CacheValue<List<L_bra_user_bankEO>>> LoadValueWhenRedisNotExistsAsync()
    {
        var ret = new CacheValue<List<L_bra_user_bankEO>>();
        ret.Value = await new L_bra_user_bankMO().GetSortAsync("UserID = @UserID", "RecDate desc", UserId);
        ret.HasValue = ret.Value != null && ret.Value.Any();
        return ret;
    }

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <returns></returns>
    public async Task<CacheValue<List<L_bra_user_bankEO>>> GetAsync()
    {
        return await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));
    }


    /// <summary>
    /// SetAsync
    /// </summary>
    /// <returns></returns>
    public async Task SetAsync()
    {
        await GetOrLoadAsync(true, TimeSpan.FromDays(EXPIRE_DAY));
    }

}
