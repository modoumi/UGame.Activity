using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;
using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.RedpackRain.Repositories;

namespace UGame.Activity.RedpackRain.Caching;

/// <summary>
/// 用户中奖信息hash
/// </summary>
public class RedpackRainUserDCache : RedisHashClient<Sa_redpackrain_detailPO>
{
    private string UserId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="userId"></param>
    public RedpackRainUserDCache(string userId,DateTime dayId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CustomException("RedpackRainUserDCache: userId不能为空");
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey(dayId.ToString("yyyy-MM-dd"), UserId);
        Options.SlidingExpiration = TimeSpan.FromHours(48);
     
    }
    /// <summary>
    /// GetField
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="cuponId"></param>
    /// <returns></returns>
    public  string GetField(string operatorId,int busCode,int modelID,TimeSpan startTime,DateTime dayId) => $"{operatorId}|{busCode}|{modelID}|{startTime}|{dayId.ToString("yyyy-MM-dd")}";

    
    /// <summary>
    /// LoadValueWhenRedisNotExistsAsync
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected override async Task<CacheValue<Sa_redpackrain_detailPO>> LoadValueWhenRedisNotExistsAsync(string field)
    {
        Sa_redpackrain_detailPO value = null;

        var keys = field.Split('|');
        var operatorId = keys[0];
        var busCode = keys[1];
        var modelID = keys[2];
        var startTime = keys[3];
        var dayId = keys[4];

        var suponUserRepository = DbUtil.GetRepository<Sa_redpackrain_detailPO>();

        value = await suponUserRepository.AsQueryable().Where(c =>c.UserID==UserId&&c.BusCode==Convert.ToInt32(busCode)&&c.ModelID==Convert.ToInt32(modelID)&&c.StartTime==TimeSpan.Parse(startTime)&&c.DayId== Convert.ToDateTime(dayId)).FirstAsync();

        var ret = new CacheValue<Sa_redpackrain_detailPO>();
        ret.HasValue = value != null;
        ret.Value = value;
        return ret;
    }
}