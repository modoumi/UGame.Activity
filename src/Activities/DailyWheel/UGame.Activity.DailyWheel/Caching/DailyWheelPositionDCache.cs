using TinyFx;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Activity.DailyWheel.Repositories;

namespace UGame.Activity.DailyWheel.Caching
{
    public class DailywheelPositionDCache : RedisStringClient<List<Sa_dailywheel_positionPO>>
    {
        private const int EXPIRE_DAY = 1;// 缓存有效期

        public string OperatorId { get; set; }


        /// <summary>
        /// 构造
        /// </summary>
        public DailywheelPositionDCache(string operatorId)
        {
            if (string.IsNullOrEmpty(operatorId))
            {
                throw new CustomException("DailyWheelUserDCache:OperatorId不能为空");
            }

            this.OperatorId = operatorId;
            RedisKey = GetProjectGroupRedisKey("DailyWheel", $"{this.OperatorId}");
        }

        protected override async Task<CacheValue<List<Sa_dailywheel_positionPO>>> LoadValueWhenRedisNotExistsAsync()
        {
            var wheelUserRepository = DbUtil.GetRepository<Sa_dailywheel_positionPO>();
            var value = await wheelUserRepository.AsQueryable().Where(_ => _.OperatorID == OperatorId).ToListAsync();

            var ret = new CacheValue<List<Sa_dailywheel_positionPO>>
            {
                HasValue = value != null,
                Value = value ?? new List<Sa_dailywheel_positionPO>()
            };
            return ret;
        }

        /// <summary>
        /// 加载缓存
        /// 如果不存在调用LoadValueWhenRedisNotExistsAsync
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sa_dailywheel_positionPO>> GetAsync()
        {
            var cache = await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));

            if (cache.HasValue)
                return cache.Value;

            return new List<Sa_dailywheel_positionPO>();
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

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="lastPosition"></param>
        /// <returns></returns>
        public async Task SetAsync(List<Sa_dailywheel_positionPO> lastPosition)
        {
            await SetAsync(lastPosition, TimeSpan.FromDays(EXPIRE_DAY));
        }

    }
}
