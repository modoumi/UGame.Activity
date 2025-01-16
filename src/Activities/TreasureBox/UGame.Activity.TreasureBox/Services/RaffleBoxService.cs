using SActivity.Redpack.API.Caching;
using TinyFx.AspNet;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Bos;
using UGame.Activity.TreasureBox.Models.Dtos;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Models.Ipos;
using UGame.Activity.TreasureBox.Repositories;
using UGame.Activity.TreasureBox.Utilities;
using Xxyy.Common;
using Xxyy.Common.Services;

namespace UGame.Activity.TreasureBox.Services;

/// <summary>
/// 抽取宝箱
/// </summary>
public class RaffleBoxService
{
    /// <summary>
    /// 未到打开时间
    /// </summary>
    /// <param name="box"></param>
    /// <param name="boxConfig"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<TreasureBoxAwardResponseDto> NotYetTime(Sa_treasurebox_userPO box, TreasureboxBo boxConfig, string baseImageUrl)
    {
        var openValue = box.OpenType.OpenTypeSwitchValue(boxConfig.OpenValue, box.CurrencyID);
        var boxIcon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
        return await Task.FromResult(new TreasureBoxAwardResponseDto
        {
            Id = box.ID,
            IsBonus = box.IsBonus,
            Amount = 0,
            Status = 0,
            Url = boxConfig.GrantLinkUrl,
            Icon = baseImageUrl + boxIcon,
            Name = boxConfig.BoxName(),
            Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{openValue}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss")),
        });
    }

    /// <summary>
    /// 超时宝箱
    /// </summary>
    /// <param name="box"></param>
    /// <param name="boxConfig"></param>
    /// <param name="iconBaseUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> OvertimeBox(Sa_treasurebox_userPO box, TreasureboxBo boxConfig, string iconBaseUrl)
    {
        var boxIcon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
        return await Task.FromResult(new TreasureBoxAwardResponseDto
        {
            Id = box.ID,
            IsBonus = box.IsBonus,
            Amount = 0,
            Status = 1,
            Icon = iconBaseUrl + boxIcon,
            Name = boxConfig.BoxName(),
            Remark = boxConfig.BoxRemark()
        });
    }

    /// <summary>
    /// 已经打开过宝箱
    /// </summary>
    /// <param name="box"></param>
    /// <param name="boxConfig"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> AlreadyOpend(Sa_treasurebox_userPO box, TreasureboxBo boxConfig, string baseImageUrl)
    {
        var icon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
        return await Task.FromResult(new TreasureBoxAwardResponseDto
        {
            Id = box.ID,
            IsBonus = box.IsBonus,
            Amount = box.Amount.AToM(box.CurrencyID),
            Icon = baseImageUrl + icon,
            Status = 1,
            Name = boxConfig.BoxName(),
            Remark = boxConfig.BoxRemark()
        });
    }

    /// <summary>
    /// 奖池关闭获取宝箱
    /// </summary> 
    /// <param name="box"></param>
    /// <param name="boxConfig"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> AwardPoolClosed(Sa_treasurebox_userPO box, TreasureboxBo boxConfig, string baseImageUrl)
    {
        var boxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();

        await boxRepo.UpdateSetColumnsTrueAsync(it => new Sa_treasurebox_userPO { IsOpen = true, Amount = 0 }, it => it.ID == box.ID);
        var icon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
        return new TreasureBoxAwardResponseDto
        {
            Id = box.ID,
            IsBonus = box.IsBonus,
            Amount = 0,
            Status = 1,
            Icon = baseImageUrl + icon,
            Name = boxConfig.BoxName(),
            Remark = boxConfig.BoxRemark()
        };
    }

    /// <summary>
    /// 检查宝箱
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> CheckBox(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var tm = new DbTransactionManager();

        try
        {
            await tm.BeginAsync();
            if (boxConfig.LimitNumType == (int)TreasureBoxLimitNumTypeEnum.HashLimit) // 有限制则扣减数量
            {
                return await CheckBoxHasLimit(ipo, boxConfig, box, baseImageUrl, tm);
            }

            return await CheckBoxNoLimit(ipo, boxConfig, box, baseImageUrl, tm);

        }
        catch (Exception ex)
        {
            await tm.RollbackAsync();
            LogUtil.Error($"treasurebox checkbox:{ex.Message}");

            var icon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                IsBonus = box.IsBonus,
                Amount = 0,
                Icon = baseImageUrl + icon,
                Status = 1,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxRemark()
            };
        }
    }

    /// <summary>
    /// 无限制
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <param name="tm"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> CheckBoxNoLimit(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl, DbTransactionManager tm)
    {
        try
        {
            var localTime = DateTime.UtcNow.ToLocalTime(box.OperatorID);
            var icon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
            var awards = boxConfig.Awards;
            var awardWeight = TreasureBoxMemoryCacheUtil.GetBonusNextWeight(awards);

            var boxRepo = tm.GetRepository<Sa_treasurebox_userPO>();

            if (awardWeight == null) // 奖池权重为空
            {
                await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
                {
                    IsOpen = true,
                    Amount = 0,
                    IsBonus = awardWeight.Type == 1
                }, w => w.ID == box.ID);

                await tm.CommitAsync();

                return new TreasureBoxAwardResponseDto
                {
                    Id = box.ID,
                    IsBonus = box.IsBonus,
                    Amount = 0,
                    Icon = baseImageUrl + icon,
                    Status = 1,
                    Name = boxConfig.BoxName(),
                    Remark = boxConfig.BoxRemark()
                };
            }

            // 计算奖励金额
            var remainAmount = await new TreasureboxAmountPoolDetailDCache(box.OperatorID, box.BoxID, localTime).GetAmountPool();
            var amount = AmountUtil.RemainAmount(remainAmount, awardWeight.Amount);

            var poolAmount = await new TreasureboxAmountPoolDetailDCache(box.OperatorID, box.BoxID, localTime).AmountDecrementAsync(amount);

            if (poolAmount.bo != null)
            {
                var amountDetailRepo = tm.GetRepository<Sa_treasurebox_amount_pool_detailPO>();
                await amountDetailRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_amount_pool_detailPO
                {
                    Amount = w.Amount - amount
                }, w => w.OperatorID == box.OperatorID && w.BoxID == box.BoxID && w.StartTime == poolAmount.bo.StarTime);
            }

            if (amount > 0)
            {
                var currencyService = new CurrencyChange2Service(box.UserID);
                var currencyChangeReq = new CurrencyChangeReq();
                currencyChangeReq.UserId = box.UserID;
                currencyChangeReq.AppId = ipo.AppId;
                currencyChangeReq.OperatorId = box.OperatorID;
                currencyChangeReq.CurrencyId = box.CurrencyID;
                currencyChangeReq.UserIp = AspNetUtil.GetRemoteIpString();
                currencyChangeReq.Reason = $"宝箱赠送";
                currencyChangeReq.Amount = amount;
                currencyChangeReq.SourceType = 510000;
                currencyChangeReq.SourceTable = "sa_treasurebox_user";
                currencyChangeReq.SourceId = box.ID;
                currencyChangeReq.ChangeTime = DateTime.UtcNow;
                currencyChangeReq.ChangeBalance = awardWeight.Type == 0 ? CurrencyChangeBalance.Cash : CurrencyChangeBalance.Bonus;
                currencyChangeReq.FlowMultip = awardWeight.FlowMultip;
                currencyChangeReq.DbTM = tm;

                var changeMsg = await currencyService.Add(currencyChangeReq);

                await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
                {
                    IsOpen = true,
                    Amount = amount,
                    IsBonus = awardWeight.Type == 1
                }, w => w.ID == box.ID);

                await tm.CommitAsync();
                if (changeMsg != null)
                {
                    await MQUtil.PublishAsync(changeMsg);
                }

                return new TreasureBoxAwardResponseDto
                {
                    Id = box.ID,
                    IsBonus = box.IsBonus,
                    Amount = amount.AToM(box.CurrencyID),
                    Icon = baseImageUrl + icon,
                    Status = 1,
                    Name = boxConfig.BoxName(),
                    Remark = boxConfig.BoxRemark()
                };
            }

            await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
            {
                IsOpen = true,
                Amount = amount,
                IsBonus = awardWeight.Type == 1
            }, w => w.ID == box.ID);
            await tm.CommitAsync();

            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                IsBonus = box.IsBonus,
                Amount = amount.AToM(box.CurrencyID),
                Icon = baseImageUrl + icon,
                Status = 1,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxRemark()
            };
        }
        catch (Exception ex)
        {
            LogUtil.Error(ex.Message);
            throw;
        }
    }

    /// <summary>
    /// 限制宝箱
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> CheckBoxHasLimit(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl, DbTransactionManager tm)
    {
        try
        {
            var localTime = DateTime.UtcNow.ToLocalTime(box.OperatorID);
            var icon = BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.Open);
            var awardWeight = TreasureBoxMemoryCacheUtil.GetBonusNextWeight(boxConfig.Awards);

            var boxRepo = tm.GetRepository<Sa_treasurebox_userPO>();

            if (awardWeight == null)
            {
                await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
                {
                    IsOpen = true,
                    Amount = 0,
                    IsBonus = awardWeight.Type == 1
                }, w => w.ID == box.ID);

                await tm.CommitAsync();
                return new TreasureBoxAwardResponseDto
                {
                    Id = box.ID,
                    IsBonus = box.IsBonus,
                    Amount = 0,
                    Icon = baseImageUrl + icon,
                    Status = 1,
                    Name = boxConfig.BoxName(),
                    Remark = boxConfig.BoxRemark()
                };
            }

            // 计算奖励金额
            var remainAmount = await new TreasureboxAmountPoolDetailDCache(box.OperatorID, box.BoxID, localTime).GetAmountPool();
            var amount = AmountUtil.RemainAmount(remainAmount, awardWeight.Amount);

            var currencyService = new CurrencyChange2Service(box.UserID);
            var currencyChangeReq = new CurrencyChangeReq();

            var numPool = await new TreasureboxNumPoolDetailDCache(box.OperatorID, box.BoxID, localTime).NumDecrementAsync(1);

            if (numPool.num > -1)
            {
                // 扣减数量
                if (numPool.bo != null)
                {
                    var numRepo = tm.GetRepository<Sa_treasurebox_num_pool_detailPO>();
                    await numRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_num_pool_detailPO
                    {
                        Num = w.Num - 1
                    }, w => w.OperatorID == box.OperatorID && w.BoxID == box.BoxID && w.StartTime == numPool.bo.StarTime);
                }
                var amountPool = await new TreasureboxAmountPoolDetailDCache(box.OperatorID, box.BoxID, localTime).AmountDecrementAsync(amount);
                if (amountPool.bo != null)
                {
                    // 扣减金额 
                    var amountRepo = tm.GetRepository<Sa_treasurebox_amount_pool_detailPO>();
                    await amountRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_amount_pool_detailPO
                    {
                        Amount = w.Amount - amount
                    }, w => w.OperatorID == box.OperatorID && w.BoxID == box.BoxID && w.StartTime == amountPool.bo.StarTime);
                }
                if (amount > 0)
                {
                    currencyChangeReq.UserId = box.UserID;
                    currencyChangeReq.AppId = ipo.AppId;
                    currencyChangeReq.OperatorId = box.OperatorID;
                    currencyChangeReq.CurrencyId = box.CurrencyID;
                    currencyChangeReq.UserIp = AspNetUtil.GetRemoteIpString();
                    currencyChangeReq.Reason = $"宝箱赠送";
                    currencyChangeReq.Amount = amount;
                    currencyChangeReq.SourceType = 510000;
                    currencyChangeReq.SourceTable = "sa_treasurebox_user";
                    currencyChangeReq.SourceId = box.ID;
                    currencyChangeReq.ChangeTime = DateTime.UtcNow;
                    currencyChangeReq.ChangeBalance = awardWeight.Type == 0 ? CurrencyChangeBalance.Cash : CurrencyChangeBalance.Bonus;
                    currencyChangeReq.FlowMultip = awardWeight.FlowMultip;
                    currencyChangeReq.DbTM = tm;

                    var changeMsg = await currencyService.Add(currencyChangeReq);

                    await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
                    {
                        IsOpen = true,
                        Amount = amount,
                        IsBonus = awardWeight.Type == 1
                    }, w => w.ID == box.ID);

                    await tm.CommitAsync();

                    if (changeMsg != null)
                    {
                        await MQUtil.PublishAsync(changeMsg);
                    }
                    return new TreasureBoxAwardResponseDto
                    {
                        Id = box.ID,
                        IsBonus = box.IsBonus,
                        Amount = amount.AToM(box.CurrencyID),
                        Icon = baseImageUrl + icon,
                        Status = 1,
                        Name = boxConfig.BoxName(),
                        Remark = boxConfig.BoxRemark()
                    };
                } 

                await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
                {
                    IsOpen = true,
                    Amount = amount,
                    IsBonus = awardWeight.Type == 1
                }, w => w.ID == box.ID);

                await tm.CommitAsync();

                return new TreasureBoxAwardResponseDto
                {
                    Id = box.ID,
                    IsBonus = box.IsBonus,
                    Amount = amount.AToM(box.CurrencyID),
                    Icon = baseImageUrl + icon,
                    Status = 1,
                    Name = boxConfig.BoxName(),
                    Remark = boxConfig.BoxRemark()
                };
            }

            await boxRepo.UpdateSetColumnsTrueAsync(w => new Sa_treasurebox_userPO
            {
                IsOpen = true,
                Amount = 0,
                IsBonus = awardWeight.Type == 1
            }, w => w.ID == box.ID);

            await tm.CommitAsync();
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                IsBonus = box.IsBonus,
                Amount = 0,
                Icon = baseImageUrl + icon,
                Status = 1,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxRemark()
            };
        }
        catch (Exception ex)
        {
            LogUtil.Error(ex.Message);
            throw;
        }
    }

}
