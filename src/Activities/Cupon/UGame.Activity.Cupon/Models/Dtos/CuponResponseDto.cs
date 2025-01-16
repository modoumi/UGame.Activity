using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Activity.Cupon.Models.Ipos
{
    public class CuponResponseDto
    {
        /// <summary>
        /// 用户编码
        /// </summary>
 
        public string UserId { get; set; }


        /// <summary>
        /// Desc:兑换码内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CuponID { get; set; }

        /// <summary>
        /// Desc:0-Cash 1-Bonus
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int IsBonus { get; set; }

        /// <summary>
        /// Desc:直接发放金额
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public decimal DirectAmount { get; set; }

        /// <summary>
        /// Desc:间接发放金额
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal IndirectAmount { get; set; }

        /// <summary>
        /// Desc:奖励中直接发放的比例
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? DirectRate { get; set; }

        /// <summary>
        /// Desc:延迟发放天数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? IndirectDay { get; set; }

         
        /// <summary>
        /// Desc:奖励中直接发放的比例
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal RandomAmount { get; set; }
    }
}
