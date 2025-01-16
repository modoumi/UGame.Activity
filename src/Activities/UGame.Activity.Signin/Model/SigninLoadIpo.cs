using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UGame.Activity.Signin.Model
{
    public class SigninLoadIpo : SigninBaseIpo
    {

        public SinginSourceEnum Source { get; set; } = SinginSourceEnum.None;

        [JsonIgnore]
        public SigninProcessData ProcessData { get; set; }
    }

    public enum SinginSourceEnum
    { 
        /// <summary>
        /// 非奖励中心入口
        /// </summary>
        None = 0,

        /// <summary>
        /// 奖励中心入口
        /// </summary>
        RewardCenter = 1
    }

}
