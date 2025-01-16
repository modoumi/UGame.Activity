using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.SqlSugar;
using TinyFx;
using TinyFx.DbCaching;
using Xxyy.MQ.Bank;
using TinyFx.Text;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Extensions.RabbitMQ;
using EasyNetQ;
using UGame.Activity.RedpackRain.Repositories;

namespace UGame.Activity.RedpackRain.Consumers
{
    public class UserPayConsumer : MQBizSubConsumer<UserPayMsg>
    {
        public UserPayConsumer()
        {
            AddHandler(Handle);
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
        /// 充值送积分抽奖奖池金额
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task Handle(UserPayMsg message, CancellationToken cancellationToken)
        {
            var configBasic =
                   DbCachingUtil.GetSingle<Sa_redpackrain_configPO>(it => it.OperatorID, message.OperatorId);

            if (configBasic == null) return;

            var tm = new DbTransactionManager();

            try
            {
            

               

                await tm.BeginAsync();

                var redpackrainUser = await DbUtil.GetRepository<Sa_redpackrain_userPO>().AsQueryable()
                    .Where(_ => _.UserID == message.UserId).FirstAsync(cancellationToken);

                long addAmount = (long)(message.PayAmount * configBasic.PersonalRechargeRate);

                var recdate = DateTime.UtcNow;

                string detailId = ObjectId.NewId();
                Sa_redpackrain_detailPO redpackrainDetail = new Sa_redpackrain_detailPO()
                {
                    DetailID = detailId,
                    UserID = message.UserId,
                    OperatorID = message.OperatorId,
                    CountryID = message.CountryId,
                    CurrencyID = message.CurrencyId,
                    BusCode = 1,
                    ThridId = message.OrderID,
                    Amount = addAmount,
                    StartTime = recdate.TimeOfDay,
                    EndTime = recdate.TimeOfDay,
                    DayId = recdate.Date,
                    ModelID = -1,
                    FlowMultip = 0,
                    IsBonus = 0,
                    IP = "",
                    Weight = 0,
                    MaxAmount = 0,
                    MinAmount = 0,
                    RecDate = recdate
                };
                await tm.GetRepository<Sa_redpackrain_detailPO>().InsertAsync(redpackrainDetail);

                if (redpackrainUser == null)
                {
                    var redpackRainUser = new Sa_redpackrain_userPO
                    {
                        UserID = message.UserId,
                        OperatorID = message.OperatorId,
                        CountryID = message.CountryId,
                        CurrencyID = message.CurrencyId,
                        PotAmount = addAmount,//累计金额大于0则累计，否则默认值
                        TransportAmount = 0,
                        LastUpdateDate = recdate,
                        RecDate = recdate,
                    };
                     await tm.GetRepository<Sa_redpackrain_userPO>().InsertAsync(redpackRainUser);
                }
                else
                {
                    
                    await tm.GetRepository<Sa_redpackrain_userPO>().AsUpdateable()
                        .SetColumns(it => it.PotAmount == it.PotAmount + addAmount)
                        .SetColumns(c => c.LastUpdateDate == recdate)
                        .Where(c =>
                            c.UserID == message.UserId)
                        .ExecuteCommandAsync();
                }
                await tm.CommitAsync();
            }
            catch (Exception ex)
            {
                await tm.RollbackAsync();
                throw new CustomException($"UserPayConsumer_Handle_Exception Message:{ex}");
            }
        }
    }
}
