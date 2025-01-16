using SqlSugar;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Rebate.Repositories;

namespace UGame.Activity.Rebate.Cache;

[SugarTable("sa_rebate_user_detail")]
public class RebateUserDetailInfo
{
    public string UserId { get; set; }
    public int ActivityId { get; set; }
    public DateTime DayId { get; set; }
    public int Level { get; set; }
}
public class UserRebateDetailDCache : RedisStringClient<List<RebateUserDetailInfo>>
{
    private string UserId { get; set; }
    private int ActivityId { get; set; }
    private DateTime DayId { get; set; }

    public UserRebateDetailDCache(string userId, int activityId, DateTime dayId)
    {
        this.UserId = userId;
        this.ActivityId = activityId;
        this.DayId = dayId;
        RedisKey = GetProjectGroupRedisKey("UserRebateDetail", $"{userId}|{activityId}|{dayId:yyyyMMdd}");
    }
    protected override async Task<CacheValue<List<RebateUserDetailInfo>>> LoadValueWhenRedisNotExistsAsync()
    {
        var ret = new CacheValue<List<RebateUserDetailInfo>>();
        var rebateDetailInfos = await DbUtil.GetRepository<Sa_rebate_user_detailPO>().AsQueryable()
            .Where(f => f.UserID == this.UserId && f.ActivityID == this.ActivityId && f.DayID == this.DayId)
            .Select(f => new RebateUserDetailInfo
            {
                UserId = f.UserID,
                ActivityId = f.ActivityID,
                DayId = f.DayID,
                Level = f.Level
            })
            .ToListAsync();
        ret.Value = rebateDetailInfos;
        ret.HasValue = ret.Value != null && ret.Value.Count > 0;
        return ret;
    }
}
