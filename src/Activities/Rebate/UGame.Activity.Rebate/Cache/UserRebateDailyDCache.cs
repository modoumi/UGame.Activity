using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Rebate.Repositories;

namespace UGame.Activity.Rebate.Cache;

public class UserRebateDailyDCache : RedisStringClient<Sa_rebate_dayPO>
{
    private string UserId { get; set; }
    private int ActivityId { get; set; }
    private DateTime DayId { get; set; }

    public UserRebateDailyDCache(string userId, int activityId, DateTime dayId)
    {
        this.UserId = userId;
        this.ActivityId = activityId;
        this.DayId = dayId;
        RedisKey = GetProjectGroupRedisKey("UserRebateDaily", $"{userId}|{activityId}|{dayId:yyyyMMdd}");
    }
    protected override async Task<CacheValue<Sa_rebate_dayPO>> LoadValueWhenRedisNotExistsAsync()
    {
        var ret = new CacheValue<Sa_rebate_dayPO>();
        var rebateDailyInfo = await DbUtil.GetRepository<Sa_rebate_dayPO>()
            .GetFirstAsync(f => f.UserID == this.UserId && f.ActivityID == this.ActivityId && f.DayID == this.DayId);
        ret.Value = rebateDailyInfo;
        ret.HasValue = ret.Value != null;
        return ret;
    }
}
