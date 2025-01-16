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
/// 绑定手机号
/// </summary>
public class TreasureBoxBindMobileConsumer : MQBizSubConsumer<ChangeMobileMsg>
{
    /// <summary>
    /// 构造
    /// </summary>
    public TreasureBoxBindMobileConsumer()
    {
        AddHandler(TreasureBoxBindMobileHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(ChangeMobileMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 绑定手机号
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TreasureBoxBindMobileHandle(ChangeMobileMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;
        if (!message.IsFirst) return;

        var boxes = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.BindMobile);
        if (boxes == null || boxes.Count == 0) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
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
                GrantType = (int)TreasureBoxGrantTypeEnum.BindMobile,
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
}
