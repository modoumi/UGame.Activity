using EasyNetQ;
using Newtonsoft.Json;
using System.Text;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.Rebate.Cache;
using UGame.Activity.Rebate.Repositories;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.MQ.Xxyy;

namespace UGame.Activity.Rebate.Consumers;

public class BetConsumer : MQBizSubConsumer<UserBetMsg>
{
    public BetConsumer()
    {
        AddHandler(Handle);
    }

    public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

    public async Task Handle(UserBetMsg message, CancellationToken cancellationToken)
    {
        //兼容系统发送的下注金额为0，订单ID为null消息
        if (string.IsNullOrEmpty(message.OrderId) && message.BetAmount == 0)
            return;
        Console.WriteLine($"BetConsumer.Handle,message:{message.ToJson()},Begin:");
        var nextUserRebateInfos = await this.HandleRebateDailyData(message);
        if (nextUserRebateInfos?.Count > 0)
            await this.HandleRebateDot(message, nextUserRebateInfos);
        Console.WriteLine($"BetConsumer.Handle,message:{message.ToJson()},End.");
    }

    protected override void Configuration(ISubscriptionConfiguration config)
    {        
    }

    protected override Task OnMessage(UserBetMsg message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task<List<NextUserRebateInfo>> HandleRebateDailyData(UserBetMsg message)
    {
        //当前这个运营商开启的活动列表
        var activityIds = new List<int> { 100009, 100010, 100014, 100015, 100016, 100017 };
        var itemOperators = DbCachingUtil.GetList<L_activity_operatorPO>(f => f.OperatorID, message.OperatorId);
        var myOperatorItems = itemOperators.FindAll(f => f.Status && activityIds.Contains(f.ActivityID));
        if (myOperatorItems == null || myOperatorItems.Count == 0) return null;

        //当前这个应用开启的活动列表，未开启活动不处理返点返水
        var appActivityInfo = DbCachingUtil.GetSingle<S_operator_appPO>(f => new { f.AppID, f.OperatorID },
            new S_operator_appPO { AppID = message.AppId, OperatorID = message.OperatorId });
        if (appActivityInfo == null || string.IsNullOrEmpty(appActivityInfo.ActivityIds) || appActivityInfo.Status == 0) return null;
        var strActivityIds = appActivityInfo.ActivityIds.Split('|');

        var myActivityIds = strActivityIds.Select(f => int.Parse(f)).ToList();
        myActivityIds = myActivityIds.FindAll(f => myOperatorItems.Exists(t => t.ActivityID == f));
        if (myActivityIds.Count == 0) return null;

        if (message.BetTime.Kind == DateTimeKind.Local)
            message.BetTime = message.BetTime.ToUniversalTime();
        var dayId = message.BetTime.ToLocalTime(message.OperatorId).Date;
        var weeklyDayId = DateTimeUtil.BeginDayOfWeek(dayId);
        var monthlyDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);

        var realtimeConfigInfos = DbCachingUtil.GetList<Sa_rebate_realtime_configPO>(f => f.OperatorID, message.OperatorId);
        var quartzConfigInfos = DbCachingUtil.GetList<Sa_rebate_quartz_configPO>(f => f.OperatorID, message.OperatorId);
        var rebateDotActivityIds = new int[] { 100009, 100014, 100016 };
        var nextUserRebateInfos = new List<NextUserRebateInfo>();

        foreach (var activityId in myActivityIds)
        {
            List<Sa_rebate_realtime_configPO> myRealtimeConfigInfos = null;
            Sa_rebate_quartz_configPO myQuartzConfigInfo = null;

            //打码类型，1：Bonus 2：真金 3：真金+Bonus
            int amountType = 0;
            if (rebateDotActivityIds.Contains(activityId))
            {
                if (realtimeConfigInfos == null || realtimeConfigInfos.Count == 0)
                    continue;
                myRealtimeConfigInfos = realtimeConfigInfos.FindAll(f => f.ActivityID == activityId);
                if (myRealtimeConfigInfos == null || myRealtimeConfigInfos.Count == 0) continue;
                //所有等级的打码类型，都一样的，取第一个等级的打码类型
                amountType = myRealtimeConfigInfos.First().AmountType;
            }
            else
            {
                if (quartzConfigInfos == null || quartzConfigInfos.Count == 0)
                    continue;
                myQuartzConfigInfo = quartzConfigInfos.Find(f => f.ActivityID == activityId);
                if (myQuartzConfigInfo == null) continue;
                amountType = myQuartzConfigInfo.AmountType;
            }

            var effectiveBetAmount = amountType switch
            {
                1 => message.BetBonus,
                2 => message.BetAmount - message.BetBonus,
                3 => message.BetAmount,
                _ => message.BetAmount
            };
            if (effectiveBetAmount <= 0) continue;

            var activityDayId = dayId;
            switch (activityId)
            {
                case 100014:
                case 100015:
                    activityDayId = DateTimeUtil.BeginDayOfWeek(dayId);
                    break;
                case 100016:
                case 100017:
                    activityDayId = DateTimeUtil.LastDayOfPrdviousMonth(dayId).AddDays(1);
                    break;
            }
            var rebateDailyCache = new UserRebateDailyDCache(message.UserId, activityId, activityDayId);
            var rebateDailyInfo = await rebateDailyCache.GetOrLoadAsync();

            if (rebateDailyInfo.HasValue)
            {
                //更新数据库
                await DbUtil.GetRepository<Sa_rebate_dayPO>().AsUpdateable()
                    .SetColumns(f => new Sa_rebate_dayPO()
                    {
                        TotalBetAmount = f.TotalBetAmount + message.BetAmount,
                        TotalBetBonus = f.TotalBetBonus + message.BetBonus,
                        TotalWinAmount = f.TotalWinAmount + message.WinAmount,
                        TotalWinBonus = f.TotalWinBonus + message.WinBonus,
                        EffectiveBetAmount = f.EffectiveBetAmount + effectiveBetAmount
                    })
                    .Where(f => f.UserID == message.UserId && f.DayID == activityDayId && f.ActivityID == activityId)
                    .ExecuteCommandAsync();

                //更新缓存
                rebateDailyInfo.Value.TotalBetAmount += message.BetAmount;
                rebateDailyInfo.Value.TotalBetBonus += message.BetBonus;
                rebateDailyInfo.Value.TotalWinAmount += message.WinAmount;
                rebateDailyInfo.Value.TotalWinBonus += message.WinBonus;
                rebateDailyInfo.Value.EffectiveBetAmount += effectiveBetAmount;
                await rebateDailyCache.SetAsync(rebateDailyInfo.Value, TimeSpan.FromDays(1));
            }
            else
            {
                //更新数据库
                //由于有多个负载执行，可能会有并发，所以使用insert on duplicate key update语句防止丢失数据
                var globalUserCache = await GlobalUserDCache.Create(message.UserId);
                var fromId = await globalUserCache.GetFromIdAsync();
                var fromMode = await globalUserCache.GetFromModeAsync();
                int userKind = (int)await globalUserCache.GetUserKindAsync();

                var builder = new StringBuilder();
                builder.Append("INSERT INTO `sa_rebate_day` (`DayID`, `UserID`, `OperatorID`, `CurrencyID`, `ActivityID`, `FromMode`, `FromId`, `UserKind`, `CountryID`, `TotalBetAmount`, `TotalBetBonus`, `EffectiveBetAmount`, `TotalWinAmount`, `TotalWinBonus`, `RecDate`, `UpdateTime`) VALUES ");
                builder.Append($"('{activityDayId:yyyy-MM-dd}','{message.UserId}','{message.OperatorId}','{message.CurrencyId}',{activityId},{fromMode},'{fromId}',{userKind},'{message.CountryId}',{message.BetAmount},{message.BetBonus},{effectiveBetAmount},{message.WinAmount},{message.WinBonus},UTC_TIMESTAMP(),UTC_TIMESTAMP()) on duplicate key update ");
                builder.Append($"`TotalBetAmount`=`TotalBetAmount`+{message.BetAmount},`TotalBetBonus`=`TotalBetBonus`+{message.BetBonus},`EffectiveBetAmount`=`EffectiveBetAmount`+{effectiveBetAmount},`TotalWinAmount`=`TotalWinAmount`+{message.WinAmount},`TotalWinBonus`=`TotalWinBonus`+{message.WinBonus},`UpdateTime`=UTC_TIMESTAMP()");
                await DbUtil.GetRepository<Sa_rebate_dayPO>().AsSugarClient().Ado
                    .ExecuteCommandAsync(builder.ToString());

                //更新缓存
                await rebateDailyCache.SetAsync(rebateDailyInfo.Value = new Sa_rebate_dayPO
                {
                    ActivityID = activityId,
                    UserID = message.UserId,
                    DayID = activityDayId,
                    OperatorID = message.OperatorId,
                    CountryID = message.CountryId,
                    CurrencyID = message.CurrencyId,
                    FromId = fromId,
                    FromMode = fromMode,
                    UserKind = userKind,
                    TotalBetAmount = message.BetAmount,
                    TotalBetBonus = message.BetBonus,
                    TotalWinAmount = message.WinAmount,
                    TotalWinBonus = message.WinBonus,
                    EffectiveBetAmount = effectiveBetAmount,
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                }, TimeSpan.FromDays(1));
            }

            //为返点处理做准备
            if (rebateDotActivityIds.Contains(activityId))
            {
                var myActivityOperatorInfo = myOperatorItems.Find(f => f.ActivityID == activityId);
                nextUserRebateInfos.Add(new NextUserRebateInfo
                {
                    UserId = message.UserId,
                    ActivityId = activityId,
                    DayId = activityDayId,
                    ConfigInfos = myRealtimeConfigInfos,
                    ActivityOperatorInfo = myActivityOperatorInfo,
                    DailyInfo = rebateDailyInfo.Value
                });
            }
        }
        return nextUserRebateInfos;
    }
    private async Task HandleRebateDot(UserBetMsg message, List<NextUserRebateInfo> nextUserRebateInfos)
    {
        var globalUserCache = await GlobalUserDCache.Create(message.UserId);
        foreach (var userRebateInfo in nextUserRebateInfos)
        {
            if (userRebateInfo.DailyInfo == null) continue;
            var effectiveBetAmount = userRebateInfo.DailyInfo.EffectiveBetAmount;
            var userRebateDetailCache = new UserRebateDetailDCache(userRebateInfo.UserId, userRebateInfo.ActivityId, userRebateInfo.DayId);
            var myUserRebateDetailsCache = await userRebateDetailCache.GetOrLoadAsync();
            if (!myUserRebateDetailsCache.HasValue)
                myUserRebateDetailsCache.Value = new List<RebateUserDetailInfo>();

            var myUserRebateDetails = myUserRebateDetailsCache.Value;
            var activityOperatorInfo = userRebateInfo.ActivityOperatorInfo;

            foreach (var myLevelConfigInfo in userRebateInfo.ConfigInfos)
            {
                if (myUserRebateDetails.Exists(f => f.Level == myLevelConfigInfo.Level))
                    continue;

                if (effectiveBetAmount < myLevelConfigInfo.BetMinAmount)
                    continue;

                //更新数据库
                try
                {
                    await DbUtil.GetRepository<Sa_rebate_user_detailPO>()
                        .InsertAsync(new Sa_rebate_user_detailPO
                        {
                            DetailID = ObjectId.NewId(),
                            UserID = userRebateInfo.UserId,
                            ActivityID = userRebateInfo.ActivityId,
                            DayID = userRebateInfo.DayId,
                            Level = myLevelConfigInfo.Level,
                            OperatorID = myLevelConfigInfo.OperatorID,
                            CountryID = message.CountryId,
                            CurrencyID = message.CurrencyId,
                            FlowMultip = myLevelConfigInfo.FlowMultip,
                            FromId = await globalUserCache.GetFromIdAsync(),
                            FromMode = await globalUserCache.GetFromModeAsync(),
                            UserKind = (int)await globalUserCache.GetUserKindAsync(),
                            RebateType = 1,
                            RebateAmount = myLevelConfigInfo.RebateAmount,
                            NotifyStatus = 0,
                            ReceiveStatus = 0,
                            RewardType = activityOperatorInfo.IsBonus ? 1 : 2,
                            RecDate = DateTime.UtcNow,
                            UpdateTime = DateTime.UtcNow
                        });
                }
                catch (Exception ex)
                {
                    //插入重复忽略
                    LogUtil.GetContextLogger()
                        .AddException(ex)
                        .AddField("BetConsumer.Source", "HandleRebateDot")
                        .AddField("BetConsumer.Message", $"下注消费者有并发插入，Message:{JsonConvert.SerializeObject(message)}");
                }

                myUserRebateDetails.Add(new RebateUserDetailInfo
                {
                    UserId = userRebateInfo.UserId,
                    ActivityId = userRebateInfo.ActivityId,
                    DayId = userRebateInfo.DayId,
                    Level = myLevelConfigInfo.Level,
                });
                await userRebateDetailCache.SetAsync(myUserRebateDetails, TimeSpan.FromDays(1));
            }
        }
    }

    class NextUserRebateInfo
    {
        public string UserId { get; set; }
        public int ActivityId { get; set; }
        public DateTime DayId { get; set; }
        public List<Sa_rebate_realtime_configPO> ConfigInfos { get; set; }
        public L_activity_operatorPO ActivityOperatorInfo { get; set; }
        public Sa_rebate_dayPO DailyInfo { get; set; }
    }
}
