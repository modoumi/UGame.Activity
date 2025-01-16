namespace UGame.Activity.Tasks.API.Domain.Models;

public class RuleEngineParameter
{
    public Dictionary<string, object> Parameters { get; set; }

    public UserInfo User { get; set; }
    public UserInfo Referrer { get; set; }

    public long? TotalDepositAmountDaily { get; set; }
    public long? TotalDepositAmountWeekly { get; set; }
    public long? TotalDepositAmountMonthly { get; set; }

    public long? TotalBetAmountDaily { get; set; }
    public long? TotalBetAmountWeekly { get; set; }
    public long? TotalBetAmountMonthly { get; set; }
}
public class UserInfo
{
    //
    // 摘要:
    //     用户编码(GUID) 【主键 varchar(38)】
    public string UserID { get; set; }
    //
    // 摘要:
    //     用户登录模式 1-游客 2-注册用户 【字段 int】
    public int UserMode { get; set; }
    //
    // 摘要:
    //     新用户来源方式 0-获得运营商的新用户(s_operator) 1-推广员获得的新用户（userid） 2-推广渠道通过url获得的新用户（s_channel_url)
    //     3-推广渠道通过code获得的新用户（s_channel_code) 【字段 int】
    public int FromMode { get; set; }
    //
    // 摘要:
    //     对应的编码（根据FromMode变化） FromMode= 0-运营商的新用户(s_operator)==> OperatorID 1-推广员获得的新用户（userid）
    //     ==> 邀请人的UserID 2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID 3-推广渠道通过code获得的新用户（s_channel_code)
    //     ==> CCodeID 【字段 varchar(100)】
    public string FromId { get; set; }
    //
    // 摘要:
    //     运营商编码 【字段 varchar(50)】
    public string OperatorID { get; set; }
    //
    // 摘要:
    //     国家编码ISO 3166-1三位字母 【字段 varchar(5)】
    public string CountryID { get; set; }
    //
    // 摘要:
    //     货币类型 【字段 varchar(5)】
    public string CurrencyID { get; set; }
    //
    // 摘要:
    //     现金（一级货币）*100000 【字段 bigint】
    public long Cash { get; set; }
    //
    // 摘要:
    //     剩余赠金 【字段 bigint】
    public long Bonus { get; set; }
    //
    // 摘要:
    //     vip积分 【字段 bigint】
    public long Point { get; set; }
    //
    // 摘要:
    //     vip等级 【字段 int】
    public int VIP { get; set; }
    //
    // 摘要:
    //     1级推广员用户编码（直接推广员） 【字段 varchar(38)】
    public string PUserID1 { get; set; }
    //
    // 摘要:
    //     用户类型 0-未知 1-普通用户 2-开发用户 3-线上测试用户（调用第三方扣减） 4-线上测试用户（不调用第三方扣减） 5-仿真用户 6-接口联调用户
    //     9-管理员 【字段 int】
    public int UserKind { get; set; }
    //
    // 摘要:
    //     状态 0-未知 1-有效 2-用户数据异常封闭 9-系统封闭 【字段 int】
    public int Status { get; set; }
    //
    // 摘要:
    //     注册时间 【字段 datetime】
    public DateTime? RegistDate { get; set; }
    //
    // 摘要:
    //     最后一次登录时间 【字段 datetime】
    public DateTime LastLoginDate { get; set; }
    //
    // 摘要:
    //     手机号 【字段 varchar(50)】
    public string Mobile { get; set; }
    //
    // 摘要:
    //     邮箱 【字段 varchar(100)】
    public string Email { get; set; }
    //
    // 摘要:
    //     登录用户名 【字段 varchar(50)】
    public string Username { get; set; }
    //
    // 摘要:
    //     是否下过注 【字段 tinyint(1)】

    public bool HasBet { get; set; }
    //
    // 摘要:
    //     是否充过值 【字段 tinyint(1)】

    public bool HasPay { get; set; }
    //
    // 摘要:
    //     是否提过现 【字段 tinyint(1)】
    public bool HasCash { get; set; }
}
