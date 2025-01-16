using TinyFx.Extensions.AutoMapper;
using UGame.Activity.Rebate.Domain.Repositories.tinyfx;

namespace UGame.Activity.Rebate.Dtos.Responses;

public class RebateDotConfigResponse : IMapFrom<Sa_rebate_realtime_configEO>
{
    /// <summary>
    /// 主键
    /// 【主键 int】
    /// </summary>
    public int ConfigID { get; set; }
    /// <summary>
    /// 运营商编码
    /// 【字段 varchar(50)】
    /// </summary>

    public string OperatorID { get; set; }
    /// <summary>
    /// 货币类型
    /// 【字段 varchar(20)】
    /// </summary>

    public string CurrencyID { get; set; }
    /// <summary>
    /// 国家编码ISO 3166-1三位字母
    /// 【字段 varchar(5)】
    /// </summary>

    public string CountryID { get; set; }
    /// <summary>
    /// 最小打码量
    /// 【字段 bigint】
    /// </summary>

    public long BetMinAmount { get; set; }
    /// <summary>
    /// 最大打码量
    /// 【字段 bigint】
    /// </summary>

    public long BetMaxAmount { get; set; }
    /// <summary>
    /// 赠金额度
    /// 【字段 bigint】
    /// </summary>

    public long RebateAmount { get; set; }
    /// <summary>
    /// 赠金提现所需要的流水倍数
    /// 【字段 float(10,2)】
    /// </summary>

    public float FlowMultip { get; set; }
    /// <summary>
    /// 记录创建时间
    /// 【字段 datetime】
    /// </summary>

    public DateTime RecDate { get; set; }
    /// <summary>
    /// 等级
    /// 【字段 int】
    /// </summary>

    public int? Level { get; set; }

    public void MapFrom(Sa_rebate_realtime_configEO source)
    {
        //throw new NotImplementedException();
    }
}
