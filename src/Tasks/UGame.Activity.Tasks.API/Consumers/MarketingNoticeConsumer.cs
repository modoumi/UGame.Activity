using EasyNetQ;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using Xxyy.DAL;
using Xxyy.MQ.Email;

namespace UGame.Activity.Tasks.API.Consumers;

public class MarketingNoticeConsumer : MQBizSubConsumer<MarketingNoticeMsg>
{
    public MarketingNoticeConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public async Task Handle(MarketingNoticeMsg message, CancellationToken cancellationToken)
    {
        var userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
        if (userInfo == null) return;
        //注册用户并且未充值，将发送营销短信
        if (userInfo.UserMode != 2 || userInfo.HasPay) return;

        var templateId = "Register24HoursNoDepositNotice";
        //注册24小时后，没有充值将发一封营销短信
        await MQUtil.PublishAsync(new UserEmailMsg
        {
            UserId = message.UserId,
            AppId = message.AppId,
            BeginDateUtc = DateTime.UtcNow.AddDays(1),
            EndDateUtc = DateTime.UtcNow.AddDays(8),
            OperatorId = message.OperatorId,
            TemplateId = templateId,
            TemplateKey = templateId,
            CountryId = message.CountryId,
            DisplayTag = 0,
            SenderId = "system"
        });
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {
    }

    protected override Task OnMessage(MarketingNoticeMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
public class MarketingNoticeMsg
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public string UserId { get; set; }
    /// <summary>
    /// 应用ID
    /// </summary>
    public string AppId { get; set; }
    /// <summary>
    /// 运营商ID
    /// </summary>
    public string OperatorId { get; set; }
    /// <summary>
    /// 国家ID
    /// </summary>
    public string CountryId { get; set; }
    /// <summary>
    /// 业务类型，具体业务中自己定义
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// 通知类型，1: 邮件 2:弹窗通知
    /// </summary>
    public int NoticeType { get; set; }
    /// <summary>
    /// 通知生效日期，没有值将从Now开始
    /// </summary>
    public DateTime? BeginDateUtc { get; set; }
    /// <summary>
    /// 通知失效时间，没有值将7天后过期
    /// </summary>
    public DateTime? EndDateUtc { get; set; }
}
