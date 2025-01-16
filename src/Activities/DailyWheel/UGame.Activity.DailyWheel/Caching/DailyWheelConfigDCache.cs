using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.DailyWheel.Repositories;

namespace UGame.Activity.DailyWheel.Caching
{
    /// <summary>
    /// 每日轮盘配置缓存
    /// </summary>
    public class DailywheelConfigDCache : RedisStringClient<Sa_dailywheel_configPO>
    {
        private const int EXPIRE_DAY = 1;// 缓存有效期

        public string OperatorId { get; set; }


        /// <summary>
        /// 构造
        /// </summary>
        public DailywheelConfigDCache(string operatorId)
        {
            if (string.IsNullOrEmpty(operatorId))
            {
                throw new CustomException("DailyWheelUserDCache:UserId不能为空");
            }

            this.OperatorId = operatorId;
            RedisKey = GetProjectGroupRedisKey("DailyWheel", $"{this.OperatorId}");
        }

        protected override async Task<CacheValue<Sa_dailywheel_configPO>> LoadValueWhenRedisNotExistsAsync()
        {
            var wheelUserRepository = DbUtil.GetRepository<Sa_dailywheel_configPO>();
            var value = await wheelUserRepository.AsQueryable().Where(_ => _.OperatorID == OperatorId).FirstAsync();

            var ret = new CacheValue<Sa_dailywheel_configPO>
            {
                HasValue = value != null,
                Value = value ?? new Sa_dailywheel_configPO()
            };
            return ret;
        }

        /// <summary>
        /// 加载缓存
        /// 如果不存在调用LoadValueWhenRedisNotExistsAsync
        /// </summary>
        /// <returns></returns>
        public async Task<Sa_dailywheel_configPO> GetAsync()
        {
            var cache = await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));

            if (cache.HasValue)
                return cache.Value;

            return new Sa_dailywheel_configPO();
        }

        /// <summary>
        /// 强制加载
        /// enforce=true
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync()
        {
            await GetOrLoadAsync(true, TimeSpan.FromDays(EXPIRE_DAY));
        }

    }
}
