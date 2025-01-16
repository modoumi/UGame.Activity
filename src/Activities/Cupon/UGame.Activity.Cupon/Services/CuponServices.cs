using SActivity.TreasureBox.API.Models;
using SqlSugar;
using System.Drawing;
using System.Linq.Expressions;
using SqlSugar.Extensions;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Configuration;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Activity;
using Microsoft.IdentityModel.Tokens;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Cupon.Caching;
using UGame.Activity.Cupon.Models.Ipos;
using UGame.Activity.Cupon.Repositories;

namespace UGame.Activity.Cupon.Services;

/// <summary>
/// 兑换码接口
/// </summary>
public class CuponServices
{
    /// <summary>
    /// 兑换码验证接口
    /// </summary>
    /// <param name="ipo">请求对象</param>
    /// <returns></returns>
    public async Task<CuponResponseDto> CuponValiteAsync(CuponRequestIpo ipo, string userId)
    {
        using var redlock = await RedisUtil.LockAsync($"Activity:Cupon:Open:{userId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"Activity Cupon for lock failed.open:{ipo.UserId}");
        }

        var userDCache = await GlobalUserDCache.Create(userId);
        string countryId = await userDCache.GetCountryIdAsync();
        string currencyId = await userDCache.GetCurrencyIdAsync();
        string operatorId = await userDCache.GetOperatorIdAsync();


        CuponErrorUserDCache errorUserDCache = new CuponErrorUserDCache(userId);

        //步骤1 判断用户有没有被平台封禁，如果被封禁，直接返回账号数据异常
        if ((await userDCache.GetUserStatusAsync()) != UserStatus.Normal)
        {
            throw new CustomException(Xxyy.Common.CommonCodes.RS_USER_DISABLED, Xxyy.Common.CommonCodes.RS_USER_DISABLED);
        }
        //步骤2 判断用户在这个渠道的兑换码功能中有没有触发短期内错误多次的临时封禁，如果有的话，返回当前无法兑换，请联系客服
        if ((await errorUserDCache.GetOrDefaultAsync("0")).ToInt16() >= 3)
        {
            throw new CustomException(CuponCodes.RS_CUPON_FJ, CuponCodes.RS_CUPON_FJ);
        }

        var cauponRepository = DbUtil.GetRepository<Sa_cuponPO>();
        var cuponModel = await cauponRepository.AsQueryable().Where(c => c.CuponID == ipo.CuponID && c.OperatorID == operatorId).FirstAsync();
        //步骤3 判断这个码是否存在，根据兑换的渠道，搜索该渠道正在上架的兑换码，如果不存在，直接返回错误的兑换码
        if (cuponModel == null)
        {
            await errorUserDCache.IncrementAsync();
            throw new CustomException(CuponCodes.RS_CUPON_ERROR, CuponCodes.RS_CUPON_ERROR);
        }
        //步骤3 判断这个码是否存在，根据兑换的渠道，搜索该渠道正在上架的兑换码，如果不存在，直接返回错误的兑换码
        if (cuponModel.Online == 0)
        {
            await errorUserDCache.IncrementAsync();
            throw new CustomException(CuponCodes.RS_CUPON_ERROR, CuponCodes.RS_CUPON_ERROR);
        }
        //步骤4：判断用户有没有在当前渠道领取过这个奖励，如果领取过，返回已领取过此类奖励 
        CuponUserDCache cuponUserDCache = new CuponUserDCache(userId);
        if ((await cuponUserDCache.GetOrLoadAsync(cuponUserDCache.GetField(operatorId, ipo.CuponID))).HasValue)
        {
            throw new CustomException(CuponCodes.RS_CUPON_RECEIVE, CuponCodes.RS_CUPON_RECEIVE);
        }

        //步骤6 判断这个券是否过期，过期的话，返回无效的兑换码
        if (cuponModel.ExpireDay < DateTime.UtcNow)
        {
            throw new CustomException(CuponCodes.RS_CUPON_INVALID, CuponCodes.RS_CUPON_INVALID);
        }

        //步骤7 在当前渠道这个兑换码对应的cupomID是否还有可发奖名额，如果没有的话，则返回无效的兑换码 
        if (cuponModel.ExchangeLimit <= cuponModel.TotalNumber)
        {
            throw new CustomException(CuponCodes.RS_CUPON_INVALID, CuponCodes.RS_CUPON_INVALID);
        }
        //步骤9 判断用户是否存在在这个奖励的互斥组中，查询用户历史兑换数据，是否有相同互斥组的发奖（多个0是允许的），如果用户触发了互斥，则返回不符合兑换条件
        if (!string.IsNullOrEmpty(cuponModel.CuponGroupID))
        {
            if (DbUtil.GetRepository<Sa_cupon_userPO>().AsQueryable().Count(c =>
                    c.UserID == userId && c.CuponGroupID == cuponModel.CuponGroupID && c.OperatorID == operatorId) > 0)
            {
                throw new CustomException(CuponCodes.RS_CUPON_NOTCONDITIONS, CuponCodes.RS_CUPON_NOTCONDITIONS);
            }
        }

        CuponRuleDCache ruleDCache = new CuponRuleDCache(ipo.CuponID, operatorId);
        var rules = await ruleDCache.GetAllOrLoadAsync();
        var cauponRuleList = rules.Value.Select(c => c.Value).ToList();
        if (cauponRuleList == null || cauponRuleList.Count == 0)
        {
            throw new CustomException(CuponCodes.RS_CUPON_ERROR, CuponCodes.RS_CUPON_ERROR);
        }



        var cuponRule = CuponDbCacheUtil.GetCuponWeight(cauponRuleList);

        //计算金额
        decimal amount =Math.Round(Random.Shared.NextInt64(cuponRule.MinAmount, cuponRule.MaxAmount).AToMByCountryId(countryId), 2) ;

        //直接发出金额
        var directAmount = (decimal)RoundToPrecision(Convert.ToDouble(cuponModel.DirectRate * amount), 2);
        //间接发出金额
        var indirectAmount = amount - directAmount;

        if (directAmount > 0)
        {
            var tm = new DbTransactionManager();
            try
            {

                string cuponUserId = ObjectId.NewId();
                await tm.BeginAsync();
                var cuponUserRepository = tm.GetRepository<Sa_cupon_userPO>();
                var recDate = DateTime.UtcNow;

                var insertCuponUser = new Sa_cupon_userPO()
                {
                    CountryID = countryId,
                    CuponGroupID = cuponModel.CuponGroupID??"",
                    CuponID = cuponModel.CuponID,
                    CurrencyID = currencyId,
                    DirectAmount = directAmount.MToA(currencyId),
                    OperatorID = operatorId,
                    RecDate = recDate,
                    DirectRate = cuponModel.DirectRate,
                    ID = cuponUserId,
                    IndirectAmount = indirectAmount.MToA(currencyId),
                    IndirectDay = cuponModel.DirectRate<1?cuponModel.IndirectDay:0,
                    UserID = userId,
                    RandomAmount = amount.MToA(currencyId),
                    CuponRuleId = cuponRule.ID,
                    Weight = cuponRule.Weight,
                    MinAmount = cuponRule.MinAmount,
                    MaxAmount = cuponRule.MaxAmount,
                    FlowMultip = cuponRule.FlowMultip,
                    IsBonus = cuponRule.IsBonus
                };

                bool res1 = await cuponUserRepository.InsertAsync(insertCuponUser);

                var res2 = await tm.GetRepository<Sa_cuponPO>().AsUpdateable()
                    .SetColumns(it => it.TotalNumber == it.TotalNumber + 1)
                    .SetColumns(c => c.TotalDirectAmount == c.TotalDirectAmount + directAmount.MToA(currencyId))
                    .SetColumns(c => c.TotalIndirectAmount == c.TotalIndirectAmount + indirectAmount.MToA(currencyId))
                    .Where(c =>
                        c.CuponID == ipo.CuponID && c.OperatorID == operatorId && c.ExchangeLimit >= c.TotalNumber)
                    .ExecuteCommandAsync();

                if (res1 && res2 > 0)
                {

                    var currencyService = new CurrencyChange2Service(userId);
                    var currencyChangeReq = new CurrencyChangeReq();
                    currencyChangeReq.UserId = userId;
                    currencyChangeReq.AppId = "lobby";
                    currencyChangeReq.OperatorId = operatorId;
                    currencyChangeReq.CurrencyId = currencyId;
                    currencyChangeReq.UserIp = AspNetUtil.GetRemoteIpString();
                    currencyChangeReq.Reason = $"兑换码直接发放";
                    currencyChangeReq.Amount = directAmount.MToA(currencyId);
                    currencyChangeReq.SourceType = 100033;
                    currencyChangeReq.SourceTable = "sa_cupon_user";
                    currencyChangeReq.SourceId = cuponUserId;
                    currencyChangeReq.ChangeTime = recDate;
                    currencyChangeReq.ChangeBalance =
                        cuponRule.IsBonus == 0 ? CurrencyChangeBalance.Cash : CurrencyChangeBalance.Bonus;
                    currencyChangeReq.FlowMultip = cuponRule.FlowMultip;
                    currencyChangeReq.DbTM = tm;

                    var changeMsg = await currencyService.Add(currencyChangeReq);

                    await tm.CommitAsync();

                    if (changeMsg != null)
                    {
                        await MQUtil.PublishAsync(changeMsg);
                    }

                    if (cuponModel.DirectRate < 1)
                    {
                        await MQUtil.PublishAsync(new UserItemRewardMsg
                        {
                            CountryId = countryId,
                            CurrencyId = currencyId,
                            DetailId = cuponUserId,
                            UserId = insertCuponUser.UserID,
                            ItemId = 100035,
                            Level = 0,
                            Meta = null,
                            MQMeta = null,
                            OperatorId = operatorId,
                            DelayDays = insertCuponUser.IndirectDay??0,
                            Reason = insertCuponUser.UserID+"/" +(insertCuponUser.IndirectDay ?? 0)+"/"+ indirectAmount.MToA(currencyId),
                            DelayRewardAmount = indirectAmount.MToA(currencyId),
                            IsBonus = cuponRule.IsBonus == 1,
                            FlowMultip = cuponRule.FlowMultip

                        });
                    }

                    await cuponUserDCache.SetAsync(cuponUserDCache.GetField(operatorId, ipo.CuponID), insertCuponUser);
                }
                else
                {
                    await tm.RollbackAsync();
                }

            }
            catch (Exception e)
            {
                await tm.RollbackAsync();
                LogUtil.Error(e, "CuponValiteAsync: " + e.Message);
            }
        }
        else
        {
            throw new CustomException(CuponCodes.RS_CUPON_ERROR, CuponCodes.RS_CUPON_ERROR);
        }

        return new CuponResponseDto() { CuponID = ipo.CuponID, DirectRate = cuponModel.DirectRate, DirectAmount = directAmount, IndirectAmount = indirectAmount, IndirectDay = cuponModel.IndirectDay, IsBonus = cuponRule.IsBonus, UserId = userId, RandomAmount = amount };
    }

    private static double RoundToPrecision(double value, int precision)
    {
        // 将 value 乘以 10 的 precision 次方，得到指定小数点位数的整数
        double multipliedValue = value * Math.Pow(10, precision);

        // 向上取整
        double roundedValue = Math.Ceiling(multipliedValue);

        // 除以 10 的 precision 次方，得到最终结果
        double result = roundedValue / Math.Pow(10, precision);

        return result;
    }
}