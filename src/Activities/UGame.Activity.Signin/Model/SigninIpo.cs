using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Activity.Signin.Model
{
    public class SigninIpo : SigninBaseIpo
    {

        /// <summary>
        /// 日期编号
        /// </summary>
        [RangeEx(1, 366, "", "DateNumber must be a correct integer between 1 and 366.")]
        public int DateNumber { get; set; } = 1;

        /// <summary>
        /// 签到过程中用到的数据
        /// </summary>
        [JsonIgnore]
        public SigninProcessData ProcessData { get; set; }
    }
}
