using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Activity.Cupon.Models.Ipos
{
    public class CuponRequestIpo
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [RequiredEx("", "UserId cannot be empty.")]
        public string UserId { get; set; }

        /// <summary>
        /// 运营商编码
        /// </summary>
        [RequiredEx("", "OperatorId cannot be empty.")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        [RequiredEx("", "CountryId cannot be empty.")]
        public string CountryId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        [RequiredEx("", "CurrencyId cannot be empty.")]
        public string CurrencyId { get; set; }


        /// <summary>
        /// Desc:兑换码内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        [RequiredEx("", "CuponID cannot be empty.")]
        public string CuponID { get; set; }
    }
}
