using EasyNetQ;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Activity.Tasks.API.Repositories;
using Xxyy.DAL;
using Xxyy.MQ.Email;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Tasks.API.Consumers;

public class RegisterConsumer : MQBizSubConsumer<UserRegisterMsg>
{
    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public RegisterConsumer()
    {
        AddHandler(HandleTask);
        AddHandler(HandleNotice);
    }

    public async Task HandleTask(UserRegisterMsg message, CancellationToken cancellationToken)
    {
        var itemId = 100039;
        var allOperatorItems = DbCachingUtil.GetList<Sat_item_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItem = allOperatorItems.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myOperatorItem == null) return;

        var allItems = DbCachingUtil.GetAllList<Sat_itemPO>();
        var myItem = allItems.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myItem == null) return;

        var allTasks = DbCachingUtil.GetAllList<Sat_taskPO>();
        var myTask = allTasks.Find(f => f.Status == 1 && f.ItemID == itemId);
        if (myTask == null) return;

        var myTaskDetail = await DbUtil.GetRepository<Sat_task_detailPO>()
            .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == itemId);
        if (myTaskDetail != null) return;

        var myUserItem = await DbUtil.GetRepository<Sat_user_itemPO>()
            .GetFirstAsync(f => f.UserID == message.UserId && f.ItemID == itemId);
        if (myUserItem != null) return;

        var allTaskRewards = DbCachingUtil.GetList<Sat_task_rewardPO>(f => f.OperatorID, message.OperatorId);
        var myTaskReward = allTaskRewards.Find(f => f.ItemID == itemId);

        if (!myTask.EffectiveTime.HasValue)
            throw new CustomException($"{myTask.ItemID}任务配置错误，未配置EffectiveTime");

        var userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
        if (userInfo == null) return;

        var registerTime = userInfo.RegistDate ?? userInfo.RecDate;
        if (registerTime < myTask.EffectiveTime) return;

        //判断注册IP地址限制
        var registerTasks = new int[] { 100007, 100039 };
        var userIp = message.UserIp;
        var count = await DbUtil.GetRepository<Sa_ip_recordPO>()
            .CountAsync(f => f.IpAddress == userIp && registerTasks.Contains(f.ActivityID) && f.OperatorID == message.OperatorId);
        if (count >= myTaskReward.IpLimits)
            return;

        //在领奖时，再添加注册用户IP地址，此处不做添加
        try
        {
            await DbUtil.GetRepository<Sat_user_itemPO>()
                .InsertAsync(new Sat_user_itemPO
                {
                    DetailID = ObjectId.NewId(),
                    UserID = message.UserId,
                    ItemID = myTaskReward.ItemID,
                    DayID = DateTime.Parse("1900-01-01"),
                    Level = myTaskReward.Level,
                    Deadline = DateTime.MaxValue.AddDays(-1),
                    IsResident = myTask.IsResident,
                    RewardAmount = myTaskReward.RewardAmount,
                    Status = 1,
                    Value1 = myTaskReward.MaxValue.ToString(),
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                });
        }
        catch
        {
            //并发插入，忽略
        }
    }
    public async Task HandleNotice(UserRegisterMsg message, CancellationToken cancellationToken)
    {
        var userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == message.UserId);
        if (userInfo == null) return;
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

    protected override Task OnMessage(UserRegisterMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
