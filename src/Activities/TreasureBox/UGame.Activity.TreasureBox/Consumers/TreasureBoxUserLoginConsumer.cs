using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Repositories;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.TreasureBox.Consumers;

/// <summary>
/// 用户登录消息
/// </summary>
public class TreasureBoxUserLoginConsumer : MQBizSubConsumer<UserLoginMsg>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TreasureBoxUserLoginConsumer()
    {
        AddHandler(TreasureBoxUserLoginHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserLoginMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 用户登录对象
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TreasureBoxUserLoginHandle(UserLoginMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;
        if (!message.IsFirstLoginOfDay) return;

        var boxes = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.Login);
        if (boxes == null || boxes.Count == 0) return;

        // 查询当日是否存在
        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        var hasBox = await userBoxRepo.IsAnyAsync(w => w.UserID == message.UserId && w.StartTime.Date == DateTime.UtcNow.Date && w.GrantType == (int)TreasureBoxGrantTypeEnum.Login);
        if (hasBox) return;

        var userBoxes = new List<Sa_treasurebox_userPO>();
        var now = DateTime.UtcNow;
        foreach (var box in boxes.Where(w => !w.IsDelete))
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
                GrantType = (int)TreasureBoxGrantTypeEnum.Login,
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

        await MQUtil.PublishAsync<NotifyRewardMsg>(new NotifyRewardMsg
        {
            OperatorId = message.OperatorId,
            CurrencyId = message.CurrencyId,
            IsSendNotify = true,
            IsSendNotifyEmail = false,
            UserId = message.UserId,
            CountryId = message.CountryId,
            RewardFlagId = 510000,
            SenderId = "box",
        });
    }
}
