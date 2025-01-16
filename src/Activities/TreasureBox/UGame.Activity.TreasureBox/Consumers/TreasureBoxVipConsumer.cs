using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.TreasureBox.Caching;
using UGame.Activity.TreasureBox.Models.Enums;
using UGame.Activity.TreasureBox.Repositories;
using Xxyy.Common.Caching;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.TreasureBox.Consumers;

/// <summary>
/// VIP订阅
/// </summary>
public class TreasureBoxVipConsumer : MQBizSubConsumer<VipUpgradeMsg>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TreasureBoxVipConsumer()
    {
        AddHandler(TreasureBoxVipHandle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    protected override void Configuration(ISubscriptionConfiguration config)
    {        
    }

    protected override Task OnMessage(VipUpgradeMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// VIP等级升级
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TreasureBoxVipHandle(VipUpgradeMsg message, CancellationToken cancellationToken)
    {
        if (message == null) return;

        var user = await GlobalUserDCache.Create(message.UserId);
        var operatorId = await user.GetOperatorIdAsync();
        var currenctyId = await user.GetCurrencyIdAsync();
        var vipBoxes = TreasureBoxMemoryCacheUtil.GetTreasureBoxs(operatorId, (int)TreasureBoxGrantTypeEnum.VipLevel);
        if (vipBoxes == null || vipBoxes.Count == 0) return;

        var userBoxRepo = DbUtil.GetRepository<Sa_treasurebox_userPO>();
        var boxCount = await userBoxRepo.CountAsync(w => w.UserID == message.UserId && w.GrantType == (int)TreasureBoxGrantTypeEnum.VipLevel);
        if (boxCount > 0) return;

        var boxes = vipBoxes.Where(w => message.VipTo >= w.GrantValue && !w.IsDelete).ToList();
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
                OperatorID = operatorId,
                CurrencyID = currenctyId,
                UserID = message.UserId,
                BoxID = box.BoxID,
                OpenType = box.OpenType,
                GrantType = (int)TreasureBoxGrantTypeEnum.VipLevel,
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
