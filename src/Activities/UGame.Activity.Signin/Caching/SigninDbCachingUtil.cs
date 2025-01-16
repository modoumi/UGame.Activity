using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.DbCaching;
using UGame.Activity.Signin.SqlSugar;

namespace UGame.Activity.Signin.Caching
{
    public static class SigninDbCachingUtil
    {
        public static Sa_signin101004_configPO GetSignin101004ConfigSignle(string operatorId, string currencyId)
        {
            var ret = DbCachingUtil.GetSingle<Sa_signin101004_configPO>(d => new { d.OperatorID, d.CurrencyID }, new Sa_signin101004_configPO
            {
                OperatorID = operatorId,
                CurrencyID = currencyId
            });

            if (ret == null)
                throw new Exception($"sa_signin101004_config不存在。operator:{operatorId},currencyId:{currencyId}");

            return ret;
        }


        public static List<Sa_signin101004_oddsPO> GetSignin101004OddsList(string operatorId, string currencyId)
        {
            var ret = DbCachingUtil.GetList<Sa_signin101004_oddsPO>(d => new { d.OperatorID, d.CurrencyID }, new Sa_signin101004_oddsPO
            {
                OperatorID = operatorId,
                CurrencyID = currencyId
            });

            if (ret == null || !ret.Any())
                return new List<Sa_signin101004_oddsPO>();

            return ret;
        }

        public static List<L_activity_operatorPO> GetAllActivityOperator(string operatorId, string currencyId)
        {
            var ret = DbCachingUtil.GetList<L_activity_operatorPO>(d => new { d.OperatorID, d.CurrencyID }, new L_activity_operatorPO
            {
                OperatorID = operatorId,
                CurrencyID = currencyId
            });

            if (ret == null || !ret.Any())
                return new List<L_activity_operatorPO>();

            return ret;
        }

    }
}
