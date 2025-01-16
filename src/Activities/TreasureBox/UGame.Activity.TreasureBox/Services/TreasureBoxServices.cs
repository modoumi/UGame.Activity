using EasyNetQ;
using SActivity.Redpack.API.Caching;
using SqlSugar;
using System.Data;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Extensions;
using UGame.Activity.TreasureBox.Models;
using UGame.Activity.TreasureBox.Models.Bos;
using UGame.Activity.TreasureBox.Models.Dtos;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Models.Ipos;
using UGame.Activity.TreasureBox.Repositories;
using UGame.Activity.TreasureBox.Utilities;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;

namespace UGame.Activity.TreasureBox.Services;

/// <summary>
/// 宝箱接口
/// </summary>
public class TreasureBoxServices
{
    /// <summary>
    /// 获取宝箱列表
    /// </summary>
    /// <param name="ipo">请求对象</param>
    /// <param name="userId">用户主键</param>
    /// <returns></returns>
    public async Task<PagerList<TreasureBoxResponseDto>> GetBoxesAsync(TreasureBoxRequestIpo ipo, string userId)
    {
        var user = new GlobalUserDCache(userId);
        var operatorId = await user.GetOperatorIdAsync();

        var localTime = DateTime.UtcNow.AddDays(-3); // DateTime.UtcNow.ToLocalTime(operatorId);
        var boxRepository = DbUtil.GetRepository<Sa_treasurebox_userPO>();

        var pager = new PageModel { PageIndex = ipo.PageIndex, PageSize = ipo.PageSize };
        var boxes = await boxRepository.GetPageListAsync(w => w.UserID == userId && w.EndTime > localTime && !w.IsOpen,
            pager,
            order => order.EndTime,
            OrderByType.Desc);

        var reponses = new List<TreasureBoxResponseDto>();

        var lobbyAppOptions = ConfigUtil.GetSection<OptionsSection>();
        var baseImageUrl = lobbyAppOptions.ImageBaseUrl;

        foreach (var w in boxes)
        {
            await new TreasureboxAmountPoolDetailDCache(w.OperatorID, w.BoxID, DateTime.UtcNow.ToLocalTime(w.OperatorID)).CreateAsync();
            await new TreasureboxNumPoolDetailDCache(w.OperatorID, w.BoxID, DateTime.UtcNow.ToLocalTime(w.OperatorID)).CreateAsync();
            var box = TreasureBoxMemoryCacheUtil.GetBox(operatorId, w.BoxID, ipo.LangId);
            var icon = BoxIconUtil.GetIconUrl(box.SkinIcon, TreasureBoxIconOpenEnum.UnOpen);
            reponses.Add(new TreasureBoxResponseDto
            {
                Id = w.ID,
                Icon = baseImageUrl + icon,
                Name = box.BoxName(),
                Remark = box.BoxRemark(),
                IsEffective = w.EndTime > DateTime.UtcNow,
                ExpiryDateTime = (w.EndTime.Date == DateTime.MaxValue.Date ? DateTime.MaxValue.Date : w.EndTime.ToLocalTime(w.OperatorID)),
                AwardRemark = box.BoxRewardRemark()
            }); ;
        }
        return new PagerList<TreasureBoxResponseDto>(pager.PageIndex, pager.PageSize, pager.TotalCount, reponses);
    }

    /// <summary>
    /// 打开宝箱
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> OpenAsync(TreasureBoxAwardRequestIpo ipo, string userId)
    {
        using var redlock = await RedisUtil.LockAsync($"Activity:TreasureBox:Open:{ipo.UserId}", 30);
        if (!redlock.IsLocked)
        {
            redlock.Release();
            throw new CustomException(CommonCodes.UserConcurrent, $"Activity TreasureBox for lock failed.open:{ipo.UserId}");
        }

        var boxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        var box = await boxRepo.GetSingleAsync(b => b.ID == ipo.Id && b.UserID == userId);
        if (box == null) throw new CustomException(TreasureBoxCodes.RS_NOT_FOUND_BOX, "RS_NOT_FOUND_BOX");

        var lobbyAppOptions = ConfigUtil.GetSection<OptionsSection>();
        var baseImageUrl = lobbyAppOptions.ImageBaseUrl;

        var boxConfig = TreasureBoxMemoryCacheUtil.GetBox(box.OperatorID, box.BoxID, ipo.LangId);

        if (box.OpenTime >= DateTime.UtcNow) // 未到打开时间
        {
            return await new RaffleBoxService().NotYetTime(box, boxConfig, baseImageUrl);
        }

        if (box.EndTime < DateTime.UtcNow) // 已经过期
        {
            return await new RaffleBoxService().OvertimeBox(box, boxConfig, baseImageUrl);
        }

        if (box.IsOpen) // 已经打开过宝箱
        {
            return await new RaffleBoxService().AlreadyOpend(box, boxConfig, baseImageUrl);
        }

        if (!boxConfig.PoolStatus) // 奖池关闭-更新对象 返回结果
        {
            return await new RaffleBoxService().AwardPoolClosed(box, boxConfig, baseImageUrl);
        }

        var rst = box.OpenType switch
        {
            1 => await UnconditionalOpen(ipo, boxConfig, box, baseImageUrl), // 直接打开
            2 => await AccumulatedDeposits(ipo, boxConfig, box, baseImageUrl), // 累计存款
            3 => await SingleDeposits(ipo, boxConfig, box, baseImageUrl),   // 单笔存款
            4 => await AccumulatedBet(ipo, boxConfig, box, baseImageUrl), // 累计下注
            5 => await NetProfit(ipo, boxConfig, box, baseImageUrl), // 净盈利
            6 => await NetLoss(ipo, boxConfig, box, baseImageUrl), // 净亏损
            7 => await InviteFriendRegister(ipo, boxConfig, box, baseImageUrl), // 邀请好友注册
            8 => await InviteFriendPay(ipo, boxConfig, box, baseImageUrl), // 邀请好友存款
            9 => await InviteFriendBet(ipo, boxConfig, box, baseImageUrl),// 邀请好友下注
            10 => await VIPLevel(ipo, boxConfig, box, baseImageUrl), // 检验VIP
            11 => await PerDayBet(ipo, boxConfig, box, baseImageUrl), // 每日下注
            _ => throw new CustomException(TreasureBoxCodes.RS_NOT_FOUND_BOX, "RS_NOT_FOUND_BOX")
        };
        return rst;
    }

    /// <summary>
    /// 每日下注
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns> 
    private async Task<TreasureBoxAwardResponseDto> PerDayBet(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var currTime = DateTime.UtcNow.ToLocalTime(ipo.OperatorId);
        var userDayCache = await DayUserDCache.Create(currTime, ipo.UserId);
        var dayAmount = await userDayCache.GetBetAmount();
        if (dayAmount < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                Status = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig?.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 直接打开
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> UnconditionalOpen(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 邀请好友下注
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> InviteFriendBet(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var detailRepo = DbUtil.GetRepository<Sa_treasurebox_user_detailPO>();
        var count = await detailRepo.CountAsync(w => w.BoxID == box.BoxID && w.UserID == box.UserID && w.Value > 0 && w.OpenType == (int)TreasureBoxOpenTypeEnum.InviteFriendBet);
        if (count < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 邀请好友存款
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> InviteFriendPay(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var detailRepo = DbUtil.GetRepository<Sa_treasurebox_user_detailPO>();
        var count = await detailRepo.CountAsync(w => w.BoxID == box.BoxID && w.UserID == box.UserID && w.Value > 0 && w.OpenType == (int)TreasureBoxOpenTypeEnum.InviteFriendPay);
        if (count < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 邀请好友注册
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> InviteFriendRegister(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var detailRepo = DbUtil.GetRepository<Sa_treasurebox_user_detailPO>();
        var count = await detailRepo.CountAsync(w => w.BoxID == box.BoxID && w.UserID == box.UserID && w.OpenType == (int)TreasureBoxOpenTypeEnum.InviteFriendRegister);
        if (count < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 净亏损
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> NetLoss(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var user = new UserService(ipo.UserId).GetUserExMo().GetByPK(ipo.UserId);
        var amount = user.TotalBetAmount - user.TotalWinAmount - user.TotalChangeAmount;
        if (Math.Abs(amount) < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 净盈利
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> NetProfit(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var user = new UserService(ipo.UserId).GetUserExMo().GetByPK(ipo.UserId);
        var amount = user.TotalBetAmount - user.TotalWinAmount - user.TotalChangeAmount;
        if (amount < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                IsBonus = false,
                Status = 0,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 累计下注
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> AccumulatedBet(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var user = new UserService(ipo.UserId).GetUserExMo().GetByPK(ipo.UserId);
        if (user.TotalBetAmount < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                Status = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig?.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }

        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 单笔存款
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> SingleDeposits(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var bankRepo = DbUtil.GetRepository<Sb_bank_orderPO>().AsQueryable();
        var isExist = await bankRepo.AnyAsync(w => w.UserID == ipo.UserId && w.Status == 2 && w.BankCallbackTime >= box.StartTime && w.Amount >= boxConfig.OpenValue && w.OrderType == 1);

        if (!isExist)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                Status = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }

        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// 累计存款
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    public async Task<TreasureBoxAwardResponseDto> AccumulatedDeposits(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var user = new UserService(ipo.UserId).GetUserExMo().GetByPK(ipo.UserId);
        if (user.TotalPayAmount < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                Status = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig?.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue.AToM(box.CurrencyID)}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }

        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }

    /// <summary>
    /// VIP等级
    /// </summary>
    /// <param name="ipo"></param>
    /// <param name="boxConfig"></param>
    /// <param name="box"></param>
    /// <param name="baseImageUrl"></param>
    /// <returns></returns>
    private async Task<TreasureBoxAwardResponseDto> VIPLevel(TreasureBoxAwardRequestIpo ipo, TreasureboxBo boxConfig, Sa_treasurebox_userPO box, string baseImageUrl)
    {
        var userRepo = DbUtil.GetRepository<S_userPO>();
        var user = await userRepo.GetSingleAsync(w => w.UserID == ipo.UserId);
        if (user.VIP < boxConfig.OpenValue)
        {
            return new TreasureBoxAwardResponseDto
            {
                Id = box.ID,
                Amount = 0,
                Status = 0,
                IsBonus = false,
                Icon = baseImageUrl + BoxIconUtil.GetIconUrl(boxConfig.SkinIcon, TreasureBoxIconOpenEnum.UnOpen),
                Url = boxConfig.GrantLinkUrl,
                Name = boxConfig.BoxName(),
                Remark = boxConfig.BoxOpenRemark().Replace("{0}", $"{boxConfig.OpenValue}").Replace("{1}", box.OpenTime.ToLocalTime(box.OperatorID).ToString("HH:mm:ss"))
            };
        }
        return await new RaffleBoxService().CheckBox(ipo, boxConfig, box, baseImageUrl);
    }
}