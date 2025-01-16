using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;
using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Cupon.Repositories;

namespace UGame.Activity.Cupon.Caching;

/// <summary>
/// 用户中奖信息hash
/// </summary>
public class CuponUserDCache : RedisHashClient<Sa_cupon_userPO>
{
    private string UserId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="userId"></param>
    public CuponUserDCache(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CustomException("CuponUserDCache: userId不能为空");
        UserId = userId;
        RedisKey = GetProjectGroupRedisKey("Cupon", UserId);
    }
    /// <summary>
    /// GetField
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="cuponId"></param>
    /// <returns></returns>
    public  string GetField(string operatorId,string cuponId) => $"{operatorId}|{cuponId}";

    /// <summary>
    /// LoadValueWhenRedisNotExistsAsync
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected override async Task<CacheValue<Sa_cupon_userPO>> LoadValueWhenRedisNotExistsAsync(string field)
    {
        Sa_cupon_userPO value = null;

        var keys = field.Split('|');
        var operatorId = keys[0];
        var cuponId = keys[1];

        var suponUserRepository = DbUtil.GetRepository<Sa_cupon_userPO>();

        value = await suponUserRepository.AsQueryable().Where(c => c.CuponID == cuponId && c.OperatorID == operatorId&&c.UserID==UserId).FirstAsync();

        var ret = new CacheValue<Sa_cupon_userPO>();
        ret.HasValue = value != null;
        ret.Value = value;
        return ret;
    }
}