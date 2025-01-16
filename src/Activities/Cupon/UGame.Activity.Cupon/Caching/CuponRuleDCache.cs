using Google.Protobuf.WellKnownTypes;
using StackExchange.Redis;
using System;
using System.Reflection;
using System.Text.Json;
using SqlSugar;
using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Cupon.Repositories;
using Xxyy.Common;

namespace UGame.Activity.Cupon.Caching;

/// <summary>
/// 兑换码中奖规则
/// </summary>
public class CuponRuleDCache : RedisHashClient<Sa_cupon_rulePO>
{
    private string CuponId { get; set; }

    private string OperatorId { get; set; }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="cuponId"></param>
    public CuponRuleDCache(string cuponId,string operatorId)
    {
        if (string.IsNullOrWhiteSpace(cuponId)|| string.IsNullOrWhiteSpace(operatorId))
            throw new CustomException("CuponRuleDCache: cuponId/operatorId 不能为空");
        this.CuponId = cuponId;
        this.OperatorId= operatorId;
        RedisKey = GetProjectGroupRedisKey("Cupon", cuponId);
    }
    ///// <summary>
    ///// GetField
    ///// </summary>
    ///// <param name="operatorId"></param>
    ///// <param name="cuponId"></param>
    ///// <returns></returns>
    //public  string GetField(string operatorId,string cuponId) => $"{operatorId}|{cuponId}";

    /// <summary>
    /// LoadValueWhenRedisNotExistsAsync
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    //protected override async Task<CacheValue<Sa_cupon_userPO>> LoadValueWhenRedisNotExistsAsync(string field)
    //{
    //    Sa_cupon_userPO value = null;

    //    var keys = field.Split('|');
    //    var operatorId = keys[0];
    //    var cuponId = keys[1];

    //    var suponUserRepository = DbUtil.GetRepository<Sa_cupon_userPO>();

    //    value = await suponUserRepository.AsQueryable().Where(c => c.CuponID == cuponId && c.OperatorID == operatorId&&c.UserID==UserId).FirstAsync();

    //    var ret = new CacheValue<Sa_cupon_userPO>();
    //    ret.HasValue = value != null;
    //    ret.Value = value;
    //    return ret;
    //}


    protected override async Task<CacheValue<Dictionary<string, Sa_cupon_rulePO>>> LoadAllValuesWhenRedisNotExistsAsync()
    {
        var cauponRuleRepository = DbUtil.GetRepository<Sa_cupon_rulePO>();

        var cauponRuleList = cauponRuleRepository.AsQueryable()
            .Where(c => c.CuponID == CuponId && c.OperatorID == OperatorId).ToList().ToDictionary(c=>c.ID,c=>c);

        var ret = new CacheValue<Dictionary<string, Sa_cupon_rulePO>>();
        ret.HasValue = cauponRuleList != null&& cauponRuleList.Any();
        ret.Value = cauponRuleList;
        //Database.KeyExpire(RedisKey, TimeSpan.FromMinutes(EXPIRE_MINUTES));
        return ret;
    }
}