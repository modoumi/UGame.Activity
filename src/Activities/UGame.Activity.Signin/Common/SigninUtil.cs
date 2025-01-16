using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Activity.Signin.Common
{
    public class SigninUtil
    {

        /// <summary>
        /// 查询当前运营商编码查询当天数据区间
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public static (DateTime startTime, DateTime endTime) GetDBTimeInterval(string operatorId)
        {
            var utcTime = DateTime.UtcNow;
            (DateTime startTime, DateTime endTime) ret = new(utcTime, utcTime);

            var countryEo = DbCacheUtil.GetCountryByOperatorId(operatorId);
            var localTime = utcTime.AddHours(countryEo.TimeZone);
            var timeZoneAbs = Math.Abs(countryEo.TimeZone);

            ret.startTime = new DateTime(localTime.Year, localTime.Month, localTime.Day, timeZoneAbs, 0, 0);
            ret.endTime = ret.startTime.AddDays(1);

            return ret;
        }

        /// <summary>
        /// 查询用户当天充值总额
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public static async Task<long> UserCurrentDaySumPay(string userId, string operatorId)
        {
            var timeInterval = GetDBTimeInterval(operatorId);

            var sql = $@"select sum(Amount) from sb_bank_order 
                                where OrderType = 1 
                                and `Status` = 2 
                                and UserID = @UserId
                                and RecDate >= @StartTime
                                and RecDate < @endTime;";

            //判断是否满足补签的充值要求
            var SumPayAmount = await DbSink.MainDb.ExecSqlScalarAsync<long?>(sql, userId, timeInterval.startTime, timeInterval.endTime);

            if (SumPayAmount.HasValue)
                return SumPayAmount.Value;

            return 0;
        }
    }



    /// <summary>
    /// 签到状态
    /// </summary>
    public enum SigninStatus
    {
        /// <summary>
        /// 预留状态
        /// </summary>
        None = 0,
        /// <summary>
        /// 已签到
        /// </summary>
        Signined = 1,
        /// <summary>
        /// 允许签到
        /// </summary>
        Allow = 2,
        /// <summary>
        /// 漏签
        /// </summary>
        MissSignin = 3,
        /// <summary>
        /// 不允许签到
        /// </summary>
        NoAllow = 4
    }
}
