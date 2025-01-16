using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.DailyWheel.Repositories;

namespace UGame.Activity.DailyWheel.Caching
{
    public class DailywheelWeightDCache : RedisStringClient<List<Sa_dailywheel_weightPO>>
    {
        private const int EXPIRE_DAY = 1;// 缓存有效期

        public string OperatorId { get; set; }


        /// <summary>
        /// 构造
        /// </summary>
        public DailywheelWeightDCache(string operatorId)
        {
            if (string.IsNullOrEmpty(operatorId))
            {
                throw new CustomException("DailywheelWeightDCache:OperatorId不能为空");
            }

            this.OperatorId = operatorId;
            RedisKey = GetProjectGroupRedisKey("DailyWheel", $"{this.OperatorId}");
        }

        protected override async Task<CacheValue<List<Sa_dailywheel_weightPO>>> LoadValueWhenRedisNotExistsAsync()
        {
            var wheelUserRepository = DbUtil.GetRepository<Sa_dailywheel_weightPO>();
            var value = await wheelUserRepository.AsQueryable().Where(_ => _.OperatorID == OperatorId).ToListAsync();

            var ret = new CacheValue<List<Sa_dailywheel_weightPO>>
            {
                HasValue = value != null,
                Value = value ?? new List<Sa_dailywheel_weightPO>()
            };
            return ret;
        }

        /// <summary>
        /// 加载缓存
        /// 如果不存在调用LoadValueWhenRedisNotExistsAsync
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sa_dailywheel_weightPO>> GetAsync()
        {
            var cache = await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));

            if (cache.HasValue)
                return cache.Value;

            return new List<Sa_dailywheel_weightPO>();
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
