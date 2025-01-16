using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.Banky.Models;
using UGame.Activity.Banky.Repositories;
using Xxyy.Common;

namespace UGame.Activity.Banky.Services;

public class BankyService
{

    /// <summary>
    /// 更新展示状态
    /// </summary>
    /// <param name="ipo"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public async Task IsDisplay(BankyIpo ipo)
    {
        using var lockObj = await RedisUtil.LockAsync($"Banky.{ipo.OperatorId}.{ipo.UserId}", 20);
        if (!lockObj.IsLocked)
        {
            lockObj.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"activity:BankyService:Request for lock failed.Key:Banky.{ipo.UserId}");
        }

        var result = await DbUtil.GetRepository<Sa_banky_detailPO>().AsUpdateable()
            .SetColumns(_ => _.IsDisplay == 1)
            .Where(_ => _.DetailID == ipo.DetailId && _.IsDisplay == 0)
            .ExecuteCommandAsync();
    }
}
