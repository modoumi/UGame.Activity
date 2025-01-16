using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Lobby.Notify;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.TreasureBox.Consumers;

/// <summary>
/// 下注消息
/// </summary>
public class TreasureBoxBetConsumers : MQBizSubConsumer<UserBetMsg>
{
    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    /// <summary>
    /// 构造函数
    /// </summary>
    public TreasureBoxBetConsumers()
    {
        AddHandler(PerBetUserHandle); // 每次下注额
        AddHandler(PerDayUserBetHandle); // 每日下注额 
        AddHandler(UserCumulativeBetHandle); // 累计下注金额
        AddHandler(UserBetHandle); // 邀请好友下注额
    }

    /// <summary>
    /// 邀请好友下注
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private async Task UserBetHandle(UserBetMsg msg, CancellationToken token)
    {
        if (msg == null) return;

        var user = await GlobalUserDCache.Create(msg.UserId);
        var pUserId = await user.GetPUserID1Async();
        // 不存在上级
        if (string.IsNullOrWhiteSpace(pUserId)) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        // 邀请好友存在的有效宝箱
        var userBoxes = await userBoxRepo.GetListAsync(w => w.UserID == pUserId
                                && w.OpenType == (int)TreasureBoxOpenTypeEnum.InviteFriendBet
                                && w.IsOpen == false && w.EndTime >= DateTime.UtcNow);

        if (userBoxes.Count() == 0) return;

        var detailRepo = DbUtil.GetRepository<Sa_treasurebox_user_detailPO>();
        var details = new List<Sa_treasurebox_user_detailPO>();
        foreach (var userbox in userBoxes)
        {
            details.Add(new Sa_treasurebox_user_detailPO
            {
                ID = ObjectId.NewId(),
                BoxID = userbox.BoxID,
                UserID = pUserId,
                PUserID = msg.UserId,
                OpenType = (int)TreasureBoxOpenTypeEnum.InviteFriendBet,
                Value = msg.BetAmount
            });
        }

        await detailRepo.InsertRangeAsync(details);
    }

    /// <summary>
    /// 每日下注额
    /// </summary>
    /// <param name="message"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private async Task PerDayUserBetHandle(UserBetMsg message, CancellationToken token)
    {
        if (message == null || message.BetAmount == 0) return;

        var boxConfig = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.PerDayUserBet);
        if (boxConfig == null || boxConfig.Count == 0) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        var hasBox = await userBoxRepo.IsAnyAsync(w => w.UserID == message.UserId && w.StartTime.Date == DateTime.UtcNow.Date && w.GrantType == (int)TreasureBoxGrantTypeEnum.PerDayUserBet);
        if (hasBox) return;

        var currTime = message.BetTime.ToLocalTime(message.OperatorId);
        var userDayCache = await DayUserDCache.Create(currTime, message.UserId);
        var dayAmount = await userDayCache.GetBetAmount();
        if (dayAmount == 0) return;

        var boxes = boxConfig.Where(w => dayAmount >= w.GrantValue && !w.IsDelete).ToList();
        var userBoxes = new List<Sa_treasurebox_userPO>();
        var now = DateTime.UtcNow;


        var notifies = new List<Notify>();
        var notifyUsers = new List<NotifyUser>();

        foreach (var box in boxes)
        {
            var endTime = box.ExpireType switch
            {
                0 => now.AddHours(box.ExpireRegular),
                1 => (DateTime)box.ExpireTime,
                2 => DateTime.MaxValue.Date,
                _ => DateTime.MaxValue.Date,
            };

            userBoxes.Add(new Sa_treasurebox_userPO
            {
                ID = ObjectId.NewId(),
                OperatorID = message.OperatorId,
                CurrencyID = message.CurrencyId,
                UserID = message.UserId,
                BoxID = box.BoxID,
                OpenType = box.OpenType,
                GrantType = (int)TreasureBoxGrantTypeEnum.PerDayUserBet,
                IsOpen = false,
                StartTime = now,
                EndTime = endTime,
                OpenTime = now.AddHours(box.OpenTime),
                IsBonus = false,
                Amount = 0,
                RecDate = now
            });
        }
        await userBoxRepo.InsertRangeAsync(userBoxes);
    }

    /// <summary>
    /// 累计下注赠送宝箱
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task UserCumulativeBetHandle(UserBetMsg message, CancellationToken cancellationToken)
    {
        if (message == null || message.BetAmount == 0) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();

        var dbBoxes = await userBoxRepo.GetListAsync(w => w.UserID == message.UserId && w.GrantType == (int)TreasureBoxGrantTypeEnum.CumulativeBets);

        var boxConfig = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.CumulativeBets);
        if (boxConfig == null || boxConfig.Count == 0) return;

        var boxIds = dbBoxes.Select(w => w.BoxID).ToList();
        var user = new UserService(message.UserId).GetUserExMo().GetByPK(message.UserId);
        var boxes = boxConfig.Where(w => user.TotalBetAmount >= w.GrantValue && !boxIds.Contains(w.BoxID) && !w.IsDelete).ToList();
        if (boxes.Count == 0) return;

        var userBoxes = new List<Sa_treasurebox_userPO>();
        var now = DateTime.UtcNow;
        foreach (var box in boxes)
        {
            var endTime = box.ExpireType switch
            {
                0 => now.AddHours(box.ExpireRegular),
                1 => (DateTime)box.ExpireTime,
                2 => DateTime.MaxValue.Date,
                _ => DateTime.MaxValue.Date,
            };
            userBoxes.Add(new Sa_treasurebox_userPO
            {
                ID = ObjectId.NewId(),
                OperatorID = message.OperatorId,
                CurrencyID = message.CurrencyId,
                UserID = message.UserId,
                BoxID = box.BoxID,
                OpenType = box.OpenType,
                GrantType = (int)TreasureBoxGrantTypeEnum.CumulativeBets,
                IsOpen = false,
                StartTime = now,
                EndTime = endTime,
                OpenTime = now.AddHours(box.OpenTime),
                IsBonus = false,
                Amount = 0,
                RecDate = now
            });
        }
        await userBoxRepo.InsertRangeAsync(userBoxes);

    }

    /// <summary>
    /// 每次下注额
    /// </summary>
    /// <param name="message"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private async Task PerBetUserHandle(UserBetMsg message, CancellationToken token)
    {
        if (message == null || message.BetAmount == 0) return;

        var boxConfig = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.PerUserBet);
        if (boxConfig == null || boxConfig.Count == 0) return;


        var boxes = boxConfig.Where(w => message.BetAmount >= w.GrantValue && !w.IsDelete).ToList();
        var userBoxes = new List<Sa_treasurebox_userPO>();
        var now = DateTime.UtcNow;
        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        foreach (var box in boxes)
        {
            var endTime = box.ExpireType switch
            {
                0 => now.AddHours(box.ExpireRegular),
                1 => (DateTime)box.ExpireTime,
                2 => DateTime.MaxValue.Date,
                _ => DateTime.MaxValue.Date,
            };
            userBoxes.Add(new Sa_treasurebox_userPO
            {
                ID = ObjectId.NewId(),
                OperatorID = message.OperatorId,
                CurrencyID = message.CurrencyId,
                UserID = message.UserId,
                BoxID = box.BoxID,
                OpenType = box.OpenType,
                GrantType = (int)TreasureBoxGrantTypeEnum.PerUserBet,
                IsOpen = false,
                StartTime = now,
                EndTime = endTime,
                OpenTime = now.AddHours(box.OpenTime),
                IsBonus = false,
                Amount = 0,
                RecDate = now
            });
        }
        await userBoxRepo.InsertRangeAsync(userBoxes);

    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserBetMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
