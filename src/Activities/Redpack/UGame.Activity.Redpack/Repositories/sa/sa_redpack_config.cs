using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Activity.Redpack.Repositories
{
    ///<summary>
    ///.首次自开红包金额
    ///</summary>
    [SugarTable("sa_redpack_config")]
    public partial class Sa_redpack_configPO
    {
           public Sa_redpack_configPO(){

            this.PackAmount =0;
            this.MinRatio =0f;
            this.MaxRatio =0f;
            this.BoostUser =0;
            this.InvitedUserBoost =0;
            this.Expire =0;
            this.PerIDMaxBonus =0;
            this.CashFlowMultip =0;
            this.BonusFlowMultip =0;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:每个红包金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PackAmount {get;set;}

           /// <summary>
           /// Desc:最小额78.10%
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float MinRatio {get;set;}

           /// <summary>
           /// Desc:最大额85.90%
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float MaxRatio {get;set;}

           /// <summary>
           /// Desc:可助力用户数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BoostUser {get;set;}

           /// <summary>
           /// Desc:被邀请用户助力次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int InvitedUserBoost {get;set;}

           /// <summary>
           /// Desc:有效期(小时)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Expire {get;set;}

           /// <summary>
           /// Desc:每个用户最多领取奖金数50000
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PerIDMaxBonus {get;set;}

           /// <summary>
           /// Desc:真金流水倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CashFlowMultip {get;set;}

           /// <summary>
           /// Desc:Bonus流水倍数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BonusFlowMultip {get;set;}

    }
}
