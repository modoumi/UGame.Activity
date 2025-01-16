using EasyNetQ;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using UGame.Activity.RedpackRain.Repositories;
using Xxyy.MQ.Quartz;

namespace UGame.Activity.RedpackRain.Consumers
{
    public class SrUserDayChangedConsumer : MQBizSubConsumer<SRPerDayMsg>
    {
        public SrUserDayChangedConsumer()
        {
            AddHandler(Handle);
        }

        public override MQSubscribeMode SubscribeMode => MQSubscribeMode.OneQueue;

        public async Task Handle(SRPerDayMsg message, CancellationToken cancellationToken)
        {
            if (message == null || message.Type != SRPerDayType.SrUserDay)
                return;
            //需要增加生成任务的判断和逻辑
            LogUtil.GetContextLogger()
                .AddField("UGame.Activity.RedpackRain.Consumers.SrUserDayChangedConsumer.Status", "Start")
                .AddField("UGame.Activity.RedpackRain.Consumers.SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
                .AddField("UGame.Activity.RedpackRain.Consumers.SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));
            if (string.IsNullOrEmpty(message.OperatorId))
            {
                LogUtil.GetContextLogger()
                    .AddException(new ArgumentNullException(nameof(message.OperatorId)))
                    .AddField("UGame.Activity.RedpackRain.Consumers.SrUserDayChangedConsumer.Source", "SrUserDayChangedConsumer.Handle")
                    .AddField("UGame.Activity.RedpackRain.Consumers.SrUserDayChangedConsumer.Message", JsonConvert.SerializeObject(message));
                return;
            }
            var redpackConfig = DbUtil.GetRepository<Sa_redpackrain_configPO>().AsQueryable().Where(c=>c.OperatorID==message.OperatorId).First();
            if (redpackConfig == null || redpackConfig.Status == 0)
            {
                return;
            }
            DateTime dayId = message.DayId;
            var result = DbUtil.GetRepository<Sr_user_dayPO>().AsQueryable().Where(c =>
                c.DayID == dayId && c.OperatorID==message.OperatorId).ToList();

            var recDate = DateTime.UtcNow;

            foreach (Sr_user_dayPO userday in result)
            {
                if (DbUtil.GetRepository<Sa_redpackrain_userPO>().AsQueryable()
                        .Count(c => c.UserID == userday.UserID) == 0)
                {
                    continue;
                }
                var amount =Convert.ToInt64( ((userday.BetAmount - userday.BetBonus) - (userday.WinAmount - userday.WinBonus)) *redpackConfig.PersonalLossRate);

                if (amount <= 0)
                {
                    continue;
                }
                var tm = new DbTransactionManager();
                try
                {
                    var redpackrainDetail = new Sa_redpackrain_detailPO()
                    {
                        DetailID = ObjectId.NewId(),
                        CountryID = userday.CountryID,
                        CurrencyID = userday.CurrencyID,
                        OperatorID = userday.OperatorID,
                        BusCode = 2,
                        RecDate = recDate,
                        ThridId = userday.DayID.ToString("yyyy-MM-dd"),
                        UserID = userday.UserID,
                        Amount = amount,
                        IP = "",
                        StartTime = recDate.TimeOfDay,
                        EndTime = recDate.TimeOfDay,
                        ModelID = -2,
                        DayId = userday.DayID,
                        Weight = 0,
                        MinAmount = 0,
                        MaxAmount = 0,
                        FlowMultip = 0,
                        IsBonus = 0
                    };
                    await tm.GetRepository<Sa_redpackrain_detailPO>().InsertAsync(redpackrainDetail);

                    await tm.GetRepository<Sa_redpackrain_userPO>().AsUpdateable()
                        .SetColumns(it => it.PotAmount == it.PotAmount + redpackrainDetail.Amount)
                        .SetColumns(it => it.TransportAmount == it.TransportAmount + redpackrainDetail.Amount)
                        .SetColumns(c => c.LastUpdateDate == recDate)
                        .Where(c =>
                            c.UserID == userday.UserID)
                        .ExecuteCommandAsync();
                    await tm.CommitAsync();
                }
                catch (Exception ex)
                {
                    await tm.RollbackAsync();
                    LogUtil.GetContextLogger().AddException(new CustomException($"RedPackRainService处理出错" + ex));
                }
            }
        }

        protected override void Configuration(ISubscriptionConfiguration x)
        {
           
            x.WithPrefetchCount(1);
            
        }

        protected override Task OnMessage(SRPerDayMsg message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
