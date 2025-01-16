using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.RewardCenter.API.Repositories;
using Xxyy.Common;
using Xxyy.MQ.Lobby.Activity;

namespace UGame.RewardCenter.API.Services;

public class RebateBoxService
{
    public async Task CreateRebateBox(string userId, int itemId, DateTime dayId, DateTime beginDate, DateTime endDate, string operatorId, string currencyId,
        Sat_rebate_box_configPO boxSetting, List<Sat_rebate_box_config_linePO> conditions, List<Sat_rebate_box_vipPO> myVipSettings, List<Sr_user_dayPO> userDailyDatas)
    {
        //已经生成宝箱直接领奖数据，直接跳过不再生成
        var boxData = await DbUtil.GetRepository<Sat_rebate_boxPO>()
            .GetFirstAsync(f => f.UserID == userId && f.DayID == dayId && f.ItemID == itemId);

        var lineDatas = new List<Sat_rebate_box_linePO>();
        var rewardId = ObjectId.NewId();
        //生成下注返、输钱返的数据行
        //不能从缓存取，等级更新不及时
        var userInfo = await DbUtil.GetRepository<S_userPO>().GetFirstAsync(f => f.UserID == userId);
        Sat_rebate_box_vipPO myVipSetting = null;
        if (boxSetting.IsUseVip)
            myVipSetting = myVipSettings.Find(f => f.ItemID == itemId && f.VipGrade == userInfo.VIP);

        foreach (var condition in conditions)
        {
            var userDayData = await this.GetItemUserInfo(userId, itemId, dayId, beginDate, endDate, userDailyDatas);
            if (userDayData == null) continue;

            var lineData = await this.CreateRebateBoxLine(userId, dayId, rewardId, boxSetting, condition, myVipSetting, userDayData);
            if (lineData == null) continue;
            lineDatas.Add(lineData);
        }
        //需要更新下周的最高返奖金额
        int status = boxData?.Status ?? 0;
        var today = DateTime.UtcNow.ToLocalTime(operatorId).Date;
        var totalRewardAmount = lineDatas.Sum(f => f.RewardAmount);
        //如果统计类型是历史累计统计，小于等于历史最高返奖金额，则不发奖
        long lastMaxRewardAmount = 0;
        if (boxSetting.StatisticsType == 2)
        {
            var userItemData = await DbUtil.GetRepository<Sat_rebate_box_user_poolPO>()
                .GetFirstAsync(f => f.UserID == userId && f.ItemID == itemId);
            if (userItemData != null)
            {
                //只发放高于历史最高返奖的部分
                //重新计算了上周的返奖总金额，更新到NextRewardAmount栏位，下次执行再更新到MaxRewardAmount中
                if (itemId > 100030)
                {
                    //周月返奖逻辑
                    if (dayId == userItemData.DayID)
                        userItemData.NextRewardAmount = totalRewardAmount;
                    if (dayId > userItemData.DayID)
                    {
                        //更新上周的历史最大发奖金额和日期
                        userItemData.DayID = dayId;
                        if (userItemData.NextRewardAmount > userItemData.MaxRewardAmount)
                            userItemData.MaxRewardAmount = userItemData.NextRewardAmount;
                        //新的下周的金额更新
                        userItemData.NextRewardAmount = totalRewardAmount;
                    }

                    userItemData.UpdateTime = DateTime.UtcNow;
                    await DbUtil.GetRepository<Sat_rebate_box_user_poolPO>()
                        .UpdateAsync(userItemData);

                    //计算下周应该发奖金额
                    lastMaxRewardAmount = userItemData.MaxRewardAmount;
                    if (totalRewardAmount > userItemData.MaxRewardAmount)
                    {
                        totalRewardAmount -= lastMaxRewardAmount;
                        if (today >= dayId && status < 1)
                            status = 1;
                    }
                    else if (totalRewardAmount <= userItemData.MaxRewardAmount)
                    {
                        if (today >= dayId && status < 1)
                        {
                            status = 1;
                        }

                    }
                    //else totalRewardAmount = 0;
                }
                else
                {
                    //日返奖逻辑
                    lastMaxRewardAmount = userItemData.MaxRewardAmount;
                    userItemData.DayID = dayId;
                    if (totalRewardAmount > lastMaxRewardAmount)
                        userItemData.MaxRewardAmount = totalRewardAmount;
                    userItemData.UpdateTime = DateTime.UtcNow;
                    await DbUtil.GetRepository<Sat_rebate_box_user_poolPO>()
                        .UpdateAsync(userItemData);

                    if (totalRewardAmount > lastMaxRewardAmount)
                    {
                        totalRewardAmount -= lastMaxRewardAmount;
                        status = 1;
                    }
                    else totalRewardAmount = 0;
                }
            }
            else
            {
                if (today >= dayId && totalRewardAmount > 0)
                    status = 1;

                await DbUtil.GetRepository<Sat_rebate_box_user_poolPO>()
                    .InsertAsync(new Sat_rebate_box_user_poolPO
                    {
                        UserID = userId,
                        ItemID = itemId,
                        DayID = dayId,
                        MaxRewardAmount = 0,
                        NextRewardAmount = totalRewardAmount,
                        UpdateTime = DateTime.UtcNow
                    });
            }
        }
        else
        {
            if (today >= dayId && totalRewardAmount > 0 && status < 1)
                status = 1;
        }
        if (boxData != null)
        {
            //已经存在并完成了，什么也不做，说明奖励已经生成了，有可能已经都发放了
            if (boxData.Status > 1) return;
            await DbUtil.GetRepository<Sat_rebate_boxPO>().AsUpdateable()
               .Where(f => f.RewardID == boxData.RewardID)
               .SetColumns(it => new Sat_rebate_boxPO()
               {
                   MaxRewardAmount = lastMaxRewardAmount,
                   RewardAmount = totalRewardAmount,
                   Status = status
               })
               .ExecuteCommandAsync();
        }
        else
        {
            //先发总奖金到活动中，在活动领奖时，再分发到延期奖金中
            await DbUtil.GetRepository<Sat_rebate_boxPO>()
               .InsertAsync(boxData = new Sat_rebate_boxPO
               {
                   RewardID = rewardId,
                   UserID = userId,
                   DayID = dayId,
                   ItemID = itemId,
                   OperatorID = operatorId,
                   CurrencyID = currencyId,
                   IsBonus = boxSetting.IsBonus,
                   FlowMultip = boxSetting.FlowMultip,
                   MaxRewardAmount = lastMaxRewardAmount,
                   RewardAmount = totalRewardAmount,
                   Status = status,
                   RecDate = DateTime.Now,
                   UpdateTime = DateTime.Now
               });
        }

        var deadline = dayId;
        switch (itemId)
        {
            case 100030: deadline = dayId.AddDays(1); break;
            case 100031: deadline = dayId.AddDays(7); break;
            case 100032: deadline = dayId.AddMonths(1); break;
        }

        //发消息，生成日周月返奖任务
        if (status == 1)
        {
            var activityMessage = new UserTaskCreatingMsg
            {
                UserId = userId,
                ItemId = itemId,
                DayId = dayId,
                Deadline = deadline,
                OperatorId = operatorId,
                DetailId = rewardId,
                CurrencyId = currencyId,
                IsBonus = boxSetting.IsBonus,
                FlowMultip = boxSetting.FlowMultip,
                RewardAmount = totalRewardAmount,
                Status = status
            };
            await MQUtil.PublishAsync(activityMessage);
            Console.WriteLine(JsonConvert.SerializeObject(activityMessage));

            await DbUtil.GetRepository<Sat_reward_center_dataPO>()
                .InsertAsync(new Sat_reward_center_dataPO
                {
                    RewardID = rewardId,
                    DetailID = rewardId,
                    UserID = userId,
                    DayID = dayId,
                    ItemID = itemId,
                    OperatorID = operatorId,
                    CurrencyID = currencyId,
                    IsBonus = boxSetting.IsBonus,
                    FlowMultip = boxSetting.FlowMultip,
                    RewardAmount = totalRewardAmount,
                    Status = status,
                    RecDate = DateTime.Now,
                    UpdateTime = DateTime.Now
                });
        }
    }
    private async Task<Sr_user_dayPO> GetItemUserInfo(string userId, int itemId, DateTime dayId, DateTime beginDate, DateTime endDate, List<Sr_user_dayPO> userDailyDatas)
    {
        var weeklyDailyDatas = userDailyDatas.FindAll(f => f.UserID == userId && f.DayID >= beginDate && f.DayID < endDate);
        return new Sr_user_dayPO
        {
            UserID = userId,
            DayID = dayId,
            BetAmount = weeklyDailyDatas.Sum(f => f.BetAmount),
            BetBonus = weeklyDailyDatas.Sum(f => f.BetBonus),
            BetCount = weeklyDailyDatas.Sum(f => f.BetCount),
            WinAmount = weeklyDailyDatas.Sum(f => f.WinAmount),
            WinBonus = weeklyDailyDatas.Sum(f => f.WinBonus),
            WinCount = weeklyDailyDatas.Sum(f => f.WinCount),
            PayAmount = weeklyDailyDatas.Sum(f => f.PayAmount),
            PayCount = weeklyDailyDatas.Sum(f => f.PayCount)
        };
    }
    private async Task<Sat_rebate_box_linePO> CreateRebateBoxLine(string userId, DateTime nextDayId, string rewardId, Sat_rebate_box_configPO boxSetting, Sat_rebate_box_config_linePO condition, Sat_rebate_box_vipPO myVipSetting, Sr_user_dayPO totalDailyDatas)
    {
        var boxLine = await DbUtil.GetRepository<Sat_rebate_box_linePO>()
            .GetFirstAsync(f => f.UserID == userId && f.DayID == nextDayId
                && f.ItemID == condition.ItemID && f.ConditionType == condition.ConditionType);
        //要使用decimal类型，除法会有余数，再做加减法会有精度损失
        decimal rewardAmount = 0, changedAmount = 0;
        switch (condition.ConditionType)
        {
            //下注
            case 1:
                if (totalDailyDatas.BetCount == 0) return null;
                //实际下注的金额
                switch (condition.AmountType)
                {
                    //Bonus
                    case 1: changedAmount = totalDailyDatas.BetBonus; break;
                    //真金
                    case 2: changedAmount = totalDailyDatas.BetAmount - totalDailyDatas.BetBonus; break;
                    //真金+Bonus
                    default: changedAmount = totalDailyDatas.BetAmount; break;
                }
                if (changedAmount < condition.MinRequiredAmount) return null;
                break;
            //输钱
            case 2:
                if (totalDailyDatas.BetCount == 0) return null;
                //实际输的金额
                switch (condition.AmountType)
                {
                    //Bonus
                    case 1: changedAmount = totalDailyDatas.WinBonus - totalDailyDatas.BetBonus; break;
                    //真金
                    case 2: changedAmount = totalDailyDatas.WinAmount - totalDailyDatas.WinBonus - (totalDailyDatas.BetAmount - totalDailyDatas.BetBonus); break;
                    //真金+Bonus
                    default: changedAmount = totalDailyDatas.WinAmount - totalDailyDatas.BetAmount; break;
                }
                if (changedAmount >= 0) return null;
                changedAmount = Math.Abs(changedAmount);
                if (changedAmount < condition.MinRequiredAmount) return null;
                break;
            //充值
            case 3:
                if (!totalDailyDatas.HasPay) return null;
                if (totalDailyDatas.PayAmount < condition.MinRequiredAmount) return null;
                break;
        }
        //使用decimal类型，防止除法精度损失
        decimal rewardRate = 0;
        if (boxSetting.IsUseVip)
        {
            rewardRate = (decimal)myVipSetting.RewardRate;
            rewardAmount = changedAmount * rewardRate;
        }
        else
        {
            rewardRate = (decimal)condition.RewardRate;
            rewardAmount = changedAmount * rewardRate;
        }
        //不足一元的小数部分舍弃
        var minUnitAmount = 1d.MToA(boxSetting.CurrencyID);
        rewardAmount = (long)rewardAmount / minUnitAmount * minUnitAmount;
        //奖励金额=0，也生成数据，方便查看数据      

        //先更新记录，后面再统一汇总，再比较历史最高返奖金额，更新返奖金额
        if (boxLine != null)
        {
            await DbUtil.GetRepository<Sat_rebate_box_linePO>().AsUpdateable()
               .Where(f => f.LineID == boxLine.LineID)
               .SetColumns(it => new Sat_rebate_box_linePO()
               {
                   ChangedAmount = (long)changedAmount,
                   RewardRate = (double)rewardRate,
                   RewardAmount = (long)rewardAmount
               })
               .ExecuteCommandAsync();
            boxLine.ChangedAmount = (long)changedAmount;
            boxLine.RewardAmount = (long)rewardAmount;
        }
        else
        {
            await DbUtil.GetRepository<Sat_rebate_box_linePO>()
                .InsertAsync(boxLine = new Sat_rebate_box_linePO
                {
                    LineID = ObjectId.NewId(),
                    RewardID = rewardId,
                    UserID = userId,
                    DayID = nextDayId,
                    AmountType = condition.AmountType,
                    ConditionType = condition.ConditionType,
                    ItemID = condition.ItemID,
                    OperatorID = condition.OperatorID,
                    RequiredAmount = condition.MinRequiredAmount,
                    IsBonus = boxSetting.IsBonus,
                    CurrencyID = boxSetting.CurrencyID,
                    FlowMultip = boxSetting.FlowMultip,
                    ChangedAmount = (long)changedAmount,
                    RewardRate = (double)rewardRate,
                    RewardAmount = (long)rewardAmount
                });
        }

        return boxLine;
    }
}
