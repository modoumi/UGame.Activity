using TinyFx.AspNet;

namespace UGame.Activity.DailyWheel.Models
{
    public class DailyWheelIpo
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
        /// 语言编码
        /// </summary>
        [RequiredEx("", "LangId cannot be empty.")]
        public string LangId { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary>
        [RequiredEx("", "AppId cannot be empty.")]
        public string AppId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 设备ID
        /// </summary>        
        public string? DeviceId { get; set; }
    }
}
