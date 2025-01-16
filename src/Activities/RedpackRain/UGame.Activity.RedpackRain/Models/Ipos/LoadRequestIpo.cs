using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.Extensions.AutoMapper;

namespace UGame.Activity.RedpackRain.Models.Ipos
{
    public class LoadRequestIpo
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        
        public string UserId { get; set; }

        /// <summary>
        /// 运营商编码
        /// </summary>
         
        public string OperatorId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
 
        public string CountryId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
 
        public string CurrencyId { get; set; }
    }

    public class RaffleRequestIpo:IMapFrom<LoadRequestIpo>,IMapTo<LoadRequestIpo>
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 运营商编码
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }

        public void MapFrom(LoadRequestIpo source)
        {
            
        }

        public void MapTo(LoadRequestIpo destination)
        {
        
        }
    }
}
