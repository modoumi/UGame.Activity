using UGame.Activity.RedpackRain.Repositories;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinyFx.AspNet;
using TinyFx.Extensions.AutoMapper;

namespace SActivity.Cupon.API.Models.Ipos
{
    public class LoadResponseDto
    {
        /// <summary>
        /// 红包雨时间段信息
        /// </summary>
        public List<RedpackrainTimeBo> ListDate { get; set; }

        /// <summary>
        /// 下一个红包雨时间段
        /// </summary>
        public TimeSpan? NextStartTime { get; set; }


        /// <summary>
        /// 当前红包雨时段
        /// </summary>
        //[System.Text.Json.Serialization.JsonIgnore]
        public RedpackrainTimeBo? CurrentTime { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public string UserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string OperatorId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public string CountryId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public string CurrencyId { get; set; }

        /// <summary>
        /// 当前日期时间戳
        /// </summary>
        public long TIMESTAMP { get; set; }

        /// <summary>
        /// 1 业务正常
        /// -2 红包雨活动已经关闭或者未配置
        /// -3 没有到开启的时间段
        /// -4 同时段内领取过奖励
        /// -5 红包雨单人一天参与的最大领取次数被超过
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///  1 冲过值
        ///  0 否
        /// </summary>
        public int HasPay { get; set; }

        /// <summary>
        /// 想通时间段领取的钱
        /// </summary>
        public string Amount { get; set; } = string.Empty;
    }

    public class RedpackrainTimeBo:IMapFrom<Sa_redpackrain_timePO>, IMapTo<Sa_redpackrain_timePO>
    {
        /// <summary>
        /// Desc:1.热门时间2.常规时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public int ModelID { get; set; }

        /// <summary>
        /// Desc:起始时间，配置为对应时间的0分0秒
        /// Default:
        /// Nullable:False
        /// </summary>           
        
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Desc:结束时间，配置为对应小时的59分59秒
        /// Default:
        /// Nullable:True
        /// </summary>           
        public TimeSpan? EndTime { get; set; }

        public void MapFrom(Sa_redpackrain_timePO source)
        {
            
        }

        public void MapTo(Sa_redpackrain_timePO destination)
        {
            
        }
    }

    public class RaffleResponseDto
    {
        public string Amount { get; set; }
        /// <summary>
        /// 1 业务正常
        /// -2 红包雨活动已经关闭或者未配置
        /// -3 没有到开启的时间段
        /// -4 同时段内领取过奖励
        /// -5 红包雨单人一天参与的最大领取次数被超过
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///  1 冲过值
        ///  0 否
        /// </summary>
        public int HasPay { get; set; }
    }
}
