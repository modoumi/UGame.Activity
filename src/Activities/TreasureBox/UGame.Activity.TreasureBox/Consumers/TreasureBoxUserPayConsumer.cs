using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Repositories;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.MQ.Bank;

namespace UGame.Activity.TreasureBox.Consumers;

/// <summary>
/// 用户
/// </summary>
public class TreasureBoxUserPayConsumer : MQBizSubConsumer<UserPayMsg>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TreasureBoxUserPayConsumer()
    {
        AddHandler(TreasureBoxUserPayHandle);
        AddHandler(TreasureBoxInviteUserPayHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserPayMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 邀请好友存款
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private async Task TreasureBoxInviteUserPayHandle(UserPayMsg msg, CancellationToken token)
    {
        if (msg == null) return;

        var user = await GlobalUserDCache.Create(msg.UserId);
        var pUserId = await user.GetPUserID1Async();
        // 不存在上级
        if (string.IsNullOrWhiteSpace(pUserId)) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        // 邀请好友存在的有效宝箱
        var userBoxes = await userBoxRepo.GetListAsync(w => w.UserID == pUserId
                                && w.OpenType == (int)TreasureBoxOpenTypeEnum.InviteFriendPay
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
                OpenType = (int)TreasureBoxOpenTypeEnum.InviteFriendPay,
                Value = msg.PayAmount
            });
        }

        await detailRepo.InsertRangeAsync(details);
    }

    /// <summary>
    /// 累计存款额
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TreasureBoxUserPayHandle(UserPayMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;

        var boxConfig = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.CumulativePay);
        if (boxConfig == null) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        var dbBoxes = await userBoxRepo.GetListAsync(w => w.UserID == message.UserId && w.GrantType == (int)TreasureBoxGrantTypeEnum.CumulativePay);

        var user = new UserService(message.UserId).GetUserExMo().GetByPK(message.UserId);
        if (user.TotalPayAmount == 0) return;

        var boxIds = dbBoxes.Select(w => w.BoxID).ToList();
        var boxes = boxConfig.Where(w => user.TotalPayAmount >= w.GrantValue && !boxIds.Contains(w.BoxID) && !w.IsDelete).ToList();

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

            if (!dbBoxes.Any(w => w.BoxID == box.BoxID))
            {
                userBoxes.Add(new Sa_treasurebox_userPO
                {
                    ID = ObjectId.NewId(),
                    OperatorID = message.OperatorId,
                    CurrencyID = message.CurrencyId,
                    UserID = message.UserId,
                    BoxID = box.BoxID,
                    OpenType = box.OpenType,
                    GrantType = (int)TreasureBoxGrantTypeEnum.CumulativePay,
                    IsOpen = false,
                    StartTime = now,
                    EndTime = endTime,
                    OpenTime = now.AddHours(box.OpenTime),
                    IsBonus = false,
                    Amount = 0,
                    RecDate = now
                });
            }
        }
        await userBoxRepo.InsertRangeAsync(userBoxes);
    }
}
