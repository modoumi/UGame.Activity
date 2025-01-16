using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Repositories;
using Xxyy.MQ.Bank;

namespace UGame.Activity.TreasureBox.Consumers;

/// <summary>
/// 首次存款
/// </summary>
public class TreasureBoxSingleUserPayConsumer : MQBizSubConsumer<UserFirstPayMsg>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TreasureBoxSingleUserPayConsumer()
    {
        AddHandler(TreasureBoxSingleUserPayHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(UserFirstPayMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 用户首次充值
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TreasureBoxSingleUserPayHandle(UserFirstPayMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;

        var boxes = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(message.OperatorId, (int)TreasureBoxGrantTypeEnum.FirstPay);
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

            if (message.PayAmount >= box.GrantValue)
            {
                userBoxes.Add(new Sa_treasurebox_userPO
                {
                    ID = ObjectId.NewId(),
                    OperatorID = message.OperatorId,
                    CurrencyID = message.CurrencyId,
                    UserID = message.UserId,
                    BoxID = box.BoxID,
                    OpenType = box.OpenType,
                    GrantType = (int)TreasureBoxGrantTypeEnum.FirstPay,
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
