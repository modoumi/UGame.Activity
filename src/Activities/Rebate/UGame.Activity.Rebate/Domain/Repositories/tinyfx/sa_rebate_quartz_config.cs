/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 18: 05:06
 ******************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using MySql.Data.MySqlClient;
using System.Text;
using TinyFx.Data.MySql;

namespace UGame.Activity.Rebate.Domain.Repositories.tinyfx
{
    #region EO
    /// <summary>
    /// 定时任务返点活动配置表
    /// 【表 sa_rebate_quartz_config 的实体类】
    /// </summary>
    [DataContract]
    [Obsolete]
    public class Sa_rebate_quartz_configEO : IRowMapper<Sa_rebate_quartz_configEO>
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public Sa_rebate_quartz_configEO()
        {
            OperatorID = "0";
            RewardRatio = 0.00000f;
            FlowMultip = 1.00f;
            RecDate = DateTime.Now;
            AmountType = 1;
        }
        #region 主键原始值 & 主键集合

        /// <summary>
        /// 当前对象是否保存原始主键值，当修改了主键值时为 true
        /// </summary>
        public bool HasOriginal { get; protected set; }

        private int _originalConfigID;
        /// <summary>
        /// 【数据库中的原始主键 ConfigID 值的副本，用于主键值更新】
        /// </summary>
        public int OriginalConfigID
        {
            get { return _originalConfigID; }
            set { HasOriginal = true; _originalConfigID = value; }
        }
        /// <summary>
        /// 获取主键集合。key: 数据库字段名称, value: 主键值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetPrimaryKeys()
        {
            return new Dictionary<string, object>() { { "ConfigID", ConfigID }, };
        }
        /// <summary>
        /// 获取主键集合JSON格式
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
        #endregion // 主键原始值
        #region 所有字段
        /// <summary>
        /// 主键
        /// 【主键 int】
        /// </summary>
        [DataMember(Order = 1)]
        public int ConfigID { get; set; }
        /// <summary>
        /// 运营商编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 2)]
        public string OperatorID { get; set; }
        /// <summary>
        /// 货币类型
        /// 【字段 varchar(20)】
        /// </summary>
        [DataMember(Order = 3)]
        public string CurrencyID { get; set; }
        /// <summary>
        /// 活动id
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 4)]
        public int ActivityID { get; set; }
        /// <summary>
        /// 国家编码ISO 3166-1三位字母
        /// 【字段 varchar(5)】
        /// </summary>
        [DataMember(Order = 5)]
        public string CountryID { get; set; }
        /// <summary>
        /// 返奖比例
        /// 【字段 float(10,5)】
        /// </summary>
        [DataMember(Order = 6)]
        public float RewardRatio { get; set; }
        /// <summary>
        /// 奖励发放最小金额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 7)]
        public long MinAmount { get; set; }
        /// <summary>
        /// 要求的流水倍数
        /// 【字段 float(10,2)】
        /// </summary>
        [DataMember(Order = 8)]
        public float FlowMultip { get; set; }
        /// <summary>
        /// 记录时间
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 9)]
        public DateTime RecDate { get; set; }
        /// <summary>
        /// 1bonus,2真金
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 10)]
        public int AmountType { get; set; }
        #endregion // 所有列
        #region 实体映射

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public Sa_rebate_quartz_configEO MapRow(IDataReader reader)
        {
            return MapDataReader(reader);
        }

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public static Sa_rebate_quartz_configEO MapDataReader(IDataReader reader)
        {
            Sa_rebate_quartz_configEO ret = new Sa_rebate_quartz_configEO();
            ret.ConfigID = reader.ToInt32("ConfigID");
            ret.OriginalConfigID = ret.ConfigID;
            ret.OperatorID = reader.ToString("OperatorID");
            ret.CurrencyID = reader.ToString("CurrencyID");
            ret.ActivityID = reader.ToInt32("ActivityID");
            ret.CountryID = reader.ToString("CountryID");
            ret.RewardRatio = reader.ToSingle("RewardRatio");
            ret.MinAmount = reader.ToInt64("MinAmount");
            ret.FlowMultip = reader.ToSingle("FlowMultip");
            ret.RecDate = reader.ToDateTime("RecDate");
            ret.AmountType = reader.ToInt32("AmountType");
            return ret;
        }

        #endregion
    }
    #endregion // EO

    #region MO
    /// <summary>
    /// 定时任务返点活动配置表
    /// 【表 sa_rebate_quartz_config 的操作类】
    /// </summary>
    [Obsolete]
    public class Sa_rebate_quartz_configMO : MySqlTableMO<Sa_rebate_quartz_configEO>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName { get; set; } = "`sa_rebate_quartz_config`";

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "database">数据来源</param>
        public Sa_rebate_quartz_configMO(MySqlDatabase database) : base(database) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
        public Sa_rebate_quartz_configMO(string connectionStringName = null) : base(connectionStringName) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">CommandTimeout时间</param>
        public Sa_rebate_quartz_configMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
        #endregion // Constructors

        #region  Add
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name = "item">要插入的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="useIgnore_">是否使用INSERT IGNORE</param>
        /// <return>受影响的行数</return>
        public override int Add(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            item.ConfigID = Database.ExecSqlScalar<int>(sql_, paras_, tm_);
            return 1;
        }
        public override async Task<int> AddAsync(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            item.ConfigID = await Database.ExecSqlScalarAsync<int>(sql_, paras_, tm_);
            return 1;
        }
        private void RepairAddData(Sa_rebate_quartz_configEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
            sql_ += $" INTO {TableName} (`OperatorID`, `CurrencyID`, `ActivityID`, `CountryID`, `RewardRatio`, `MinAmount`, `FlowMultip`, `RecDate`, `AmountType`) VALUE (@OperatorID, @CurrencyID, @ActivityID, @CountryID, @RewardRatio, @MinAmount, @FlowMultip, @RecDate, @AmountType);SELECT LAST_INSERT_ID();";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@RewardRatio", item.RewardRatio, MySqlDbType.Float),
                Database.CreateInParameter("@MinAmount", item.MinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
                Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@AmountType", item.AmountType, MySqlDbType.Int32),
            };
        }
        public int AddByBatch(IEnumerable<Sa_rebate_quartz_configEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += Database.ExecSqlNonQuery(sql, tm_);
            }
            return ret;
        }
        public async Task<int> AddByBatchAsync(IEnumerable<Sa_rebate_quartz_configEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
            }
            return ret;
        }
        private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_rebate_quartz_configEO> items, int batchCount)
        {
            var count = 0;
            var insertSql = $"INSERT INTO {TableName} (`ConfigID`, `OperatorID`, `CurrencyID`, `ActivityID`, `CountryID`, `RewardRatio`, `MinAmount`, `FlowMultip`, `RecDate`, `AmountType`) VALUES ";
            var sql = new StringBuilder();
            foreach (var item in items)
            {
                count++;
                sql.Append($"({item.ConfigID},'{item.OperatorID}','{item.CurrencyID}',{item.ActivityID},'{item.CountryID}',{item.RewardRatio},{item.MinAmount},{item.FlowMultip},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.AmountType}),");
                if (count == batchCount)
                {
                    count = 0;
                    sql.Insert(0, insertSql);
                    var ret = sql.ToString().TrimEnd(',');
                    sql.Clear();
                    yield return ret;
                }
            }
            if (sql.Length > 0)
            {
                sql.Insert(0, insertSql);
                yield return sql.ToString().TrimEnd(',');
            }
        }
        #endregion // Add

        #region Remove
        #region RemoveByPK
        /// <summary>
        /// 按主键删除
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByPK(int configID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(configID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByPKAsync(int configID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(configID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepiarRemoveByPKData(int configID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }
        /// <summary>
        /// 删除指定实体对应的记录
        /// </summary>
        /// <param name = "item">要删除的实体</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Remove(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null)
        {
            return RemoveByPK(item.ConfigID, tm_);
        }
        public async Task<int> RemoveAsync(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null)
        {
            return await RemoveByPKAsync(item.ConfigID, tm_);
        }
        #endregion // RemoveByPK

        #region RemoveByXXX
        #region RemoveByOperatorID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByOperatorID(string operatorID, TransactionManager tm_ = null)
        {
            RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
        {
            RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByOperatorIDData(string operatorID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
        }
        #endregion // RemoveByOperatorID
        #region RemoveByCurrencyID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByCurrencyID(string currencyID, TransactionManager tm_ = null)
        {
            RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
        {
            RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByCurrencyIDData(string currencyID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
        }
        #endregion // RemoveByCurrencyID
        #region RemoveByActivityID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByActivityID(int activityID, TransactionManager tm_ = null)
        {
            RepairRemoveByActivityIDData(activityID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByActivityIDAsync(int activityID, TransactionManager tm_ = null)
        {
            RepairRemoveByActivityIDData(activityID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByActivityIDData(int activityID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
        }
        #endregion // RemoveByActivityID
        #region RemoveByCountryID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByCountryID(string countryID, TransactionManager tm_ = null)
        {
            RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByCountryIDAsync(string countryID, TransactionManager tm_ = null)
        {
            RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByCountryIDData(string countryID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `CountryID` = @CountryID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
        }
        #endregion // RemoveByCountryID
        #region RemoveByRewardRatio
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByRewardRatio(float rewardRatio, TransactionManager tm_ = null)
        {
            RepairRemoveByRewardRatioData(rewardRatio, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByRewardRatioAsync(float rewardRatio, TransactionManager tm_ = null)
        {
            RepairRemoveByRewardRatioData(rewardRatio, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByRewardRatioData(float rewardRatio, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `RewardRatio` = @RewardRatio";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float));
        }
        #endregion // RemoveByRewardRatio
        #region RemoveByMinAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByMinAmount(long minAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByMinAmountData(minAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByMinAmountAsync(long minAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByMinAmountData(minAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByMinAmountData(long minAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `MinAmount` = @MinAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByMinAmount
        #region RemoveByFlowMultip
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByFlowMultip(float flowMultip, TransactionManager tm_ = null)
        {
            RepairRemoveByFlowMultipData(flowMultip, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByFlowMultipAsync(float flowMultip, TransactionManager tm_ = null)
        {
            RepairRemoveByFlowMultipData(flowMultip, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByFlowMultipData(float flowMultip, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `FlowMultip` = @FlowMultip";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
        }
        #endregion // RemoveByFlowMultip
        #region RemoveByRecDate
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
        {
            RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
        {
            RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByRecDateData(DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `RecDate` = @RecDate";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
        }
        #endregion // RemoveByRecDate
        #region RemoveByAmountType
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByAmountType(int amountType, TransactionManager tm_ = null)
        {
            RepairRemoveByAmountTypeData(amountType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByAmountTypeAsync(int amountType, TransactionManager tm_ = null)
        {
            RepairRemoveByAmountTypeData(amountType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByAmountTypeData(int amountType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `AmountType` = @AmountType";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32));
        }
        #endregion // RemoveByAmountType
        #endregion // RemoveByXXX

        #region RemoveByFKOrUnique
        #endregion // RemoveByFKOrUnique
        #endregion //Remove

        #region Put
        #region PutItem
        /// <summary>
        /// 更新实体到数据库
        /// </summary>
        /// <param name = "item">要更新的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Put(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAsync(Sa_rebate_quartz_configEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutData(Sa_rebate_quartz_configEO item, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID, `ActivityID` = @ActivityID, `CountryID` = @CountryID, `RewardRatio` = @RewardRatio, `MinAmount` = @MinAmount, `FlowMultip` = @FlowMultip, `AmountType` = @AmountType WHERE `ConfigID` = @ConfigID_Original";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@RewardRatio", item.RewardRatio, MySqlDbType.Float),
                Database.CreateInParameter("@MinAmount", item.MinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
                Database.CreateInParameter("@AmountType", item.AmountType, MySqlDbType.Int32),
                Database.CreateInParameter("@ConfigID_Original", item.HasOriginal ? item.OriginalConfigID : item.ConfigID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新实体集合到数据库
        /// </summary>
        /// <param name = "items">要更新的实体对象集合</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Put(IEnumerable<Sa_rebate_quartz_configEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += Put(item, tm_);
            }
            return ret;
        }
        public async Task<int> PutAsync(IEnumerable<Sa_rebate_quartz_configEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += await PutAsync(item, tm_);
            }
            return ret;
        }
        #endregion // PutItem

        #region PutByPK
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int configID, string set_, params object[] values_)
        {
            return Put(set_, "`ConfigID` = @ConfigID", ConcatValues(values_, configID));
        }
        public async Task<int> PutByPKAsync(int configID, string set_, params object[] values_)
        {
            return await PutAsync(set_, "`ConfigID` = @ConfigID", ConcatValues(values_, configID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int configID, string set_, TransactionManager tm_, params object[] values_)
        {
            return Put(set_, "`ConfigID` = @ConfigID", tm_, ConcatValues(values_, configID));
        }
        public async Task<int> PutByPKAsync(int configID, string set_, TransactionManager tm_, params object[] values_)
        {
            return await PutAsync(set_, "`ConfigID` = @ConfigID", tm_, ConcatValues(values_, configID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="paras_">参数值</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int configID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return Put(set_, "`ConfigID` = @ConfigID", ConcatParameters(paras_, newParas_), tm_);
        }
        public async Task<int> PutByPKAsync(int configID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return await PutAsync(set_, "`ConfigID` = @ConfigID", ConcatParameters(paras_, newParas_), tm_);
        }
        #endregion // PutByPK

        #region PutXXX
        #region PutOperatorID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOperatorIDByPK(int configID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(configID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutOperatorIDByPKAsync(int configID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(configID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutOperatorIDByPKData(int configID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOperatorID(string operatorID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
            var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
            var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutOperatorID
        #region PutCurrencyID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCurrencyIDByPK(int configID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(configID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCurrencyIDByPKAsync(int configID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(configID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCurrencyIDByPKData(int configID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCurrencyID(string currencyID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
            var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
            var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutCurrencyID
        #region PutActivityID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutActivityIDByPK(int configID, int activityID, TransactionManager tm_ = null)
        {
            RepairPutActivityIDByPKData(configID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutActivityIDByPKAsync(int configID, int activityID, TransactionManager tm_ = null)
        {
            RepairPutActivityIDByPKData(configID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutActivityIDByPKData(int configID, int activityID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `ActivityID` = @ActivityID  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutActivityID(int activityID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `ActivityID` = @ActivityID";
            var parameter_ = Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutActivityIDAsync(int activityID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `ActivityID` = @ActivityID";
            var parameter_ = Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutActivityID
        #region PutCountryID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCountryIDByPK(int configID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(configID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCountryIDByPKAsync(int configID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(configID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCountryIDByPKData(int configID, string countryID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCountryID(string countryID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
            var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
            var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutCountryID
        #region PutRewardRatio
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRewardRatioByPK(int configID, float rewardRatio, TransactionManager tm_ = null)
        {
            RepairPutRewardRatioByPKData(configID, rewardRatio, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutRewardRatioByPKAsync(int configID, float rewardRatio, TransactionManager tm_ = null)
        {
            RepairPutRewardRatioByPKData(configID, rewardRatio, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutRewardRatioByPKData(int configID, float rewardRatio, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `RewardRatio` = @RewardRatio  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRewardRatio(float rewardRatio, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RewardRatio` = @RewardRatio";
            var parameter_ = Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutRewardRatioAsync(float rewardRatio, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RewardRatio` = @RewardRatio";
            var parameter_ = Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutRewardRatio
        #region PutMinAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutMinAmountByPK(int configID, long minAmount, TransactionManager tm_ = null)
        {
            RepairPutMinAmountByPKData(configID, minAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutMinAmountByPKAsync(int configID, long minAmount, TransactionManager tm_ = null)
        {
            RepairPutMinAmountByPKData(configID, minAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutMinAmountByPKData(int configID, long minAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `MinAmount` = @MinAmount  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutMinAmount(long minAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `MinAmount` = @MinAmount";
            var parameter_ = Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutMinAmountAsync(long minAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `MinAmount` = @MinAmount";
            var parameter_ = Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutMinAmount
        #region PutFlowMultip
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFlowMultipByPK(int configID, float flowMultip, TransactionManager tm_ = null)
        {
            RepairPutFlowMultipByPKData(configID, flowMultip, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutFlowMultipByPKAsync(int configID, float flowMultip, TransactionManager tm_ = null)
        {
            RepairPutFlowMultipByPKData(configID, flowMultip, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutFlowMultipByPKData(int configID, float flowMultip, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFlowMultip(float flowMultip, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip";
            var parameter_ = Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutFlowMultipAsync(float flowMultip, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip";
            var parameter_ = Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutFlowMultip
        #region PutRecDate
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRecDateByPK(int configID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(configID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutRecDateByPKAsync(int configID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(configID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutRecDateByPKData(int configID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRecDate(DateTime recDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
            var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
            var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutRecDate
        #region PutAmountType
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAmountTypeByPK(int configID, int amountType, TransactionManager tm_ = null)
        {
            RepairPutAmountTypeByPKData(configID, amountType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAmountTypeByPKAsync(int configID, int amountType, TransactionManager tm_ = null)
        {
            RepairPutAmountTypeByPKData(configID, amountType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutAmountTypeByPKData(int configID, int amountType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `AmountType` = @AmountType  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAmountType(int amountType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AmountType` = @AmountType";
            var parameter_ = Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutAmountTypeAsync(int amountType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AmountType` = @AmountType";
            var parameter_ = Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutAmountType
        #endregion // PutXXX
        #endregion // Put

        #region Set

        /// <summary>
        /// 插入或者更新数据
        /// </summary>
        /// <param name = "item">要更新的实体对象</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>true:插入操作；false:更新操作</return>
        public bool Set(Sa_rebate_quartz_configEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.ConfigID) == null)
            {
                Add(item, tm);
            }
            else
            {
                Put(item, tm);
                ret = false;
            }
            return ret;
        }
        public async Task<bool> SetAsync(Sa_rebate_quartz_configEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.ConfigID) == null)
            {
                await AddAsync(item, tm);
            }
            else
            {
                await PutAsync(item, tm);
                ret = false;
            }
            return ret;
        }

        #endregion // Set

        #region Get
        #region GetByPK
        /// <summary>
        /// 按 PK（主键） 查询
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
        /// <return></return>
        public Sa_rebate_quartz_configEO GetByPK(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<Sa_rebate_quartz_configEO> GetByPKAsync(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        private void RepairGetByPKData(int configID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
        {
            sql_ = BuildSelectSQL("`ConfigID` = @ConfigID", 0, null, null, isForUpdate_);
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }
        #endregion // GetByPK

        #region GetXXXByPK

        /// <summary>
        /// 按主键查询 OperatorID（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetOperatorIDByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`OperatorID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<string> GetOperatorIDByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`OperatorID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CurrencyID（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCurrencyIDByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`CurrencyID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<string> GetCurrencyIDByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`CurrencyID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 ActivityID（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetActivityIDByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`ActivityID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<int> GetActivityIDByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`ActivityID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CountryID（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCountryIDByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`CountryID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<string> GetCountryIDByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`CountryID`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 RewardRatio（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public float GetRewardRatioByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (float)GetScalar("`RewardRatio`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<float> GetRewardRatioByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (float)await GetScalarAsync("`RewardRatio`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 MinAmount（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetMinAmountByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`MinAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<long> GetMinAmountByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`MinAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 FlowMultip（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public float GetFlowMultipByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (float)GetScalar("`FlowMultip`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<float> GetFlowMultipByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (float)await GetScalarAsync("`FlowMultip`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 RecDate（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetRecDateByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (DateTime)GetScalar("`RecDate`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<DateTime> GetRecDateByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (DateTime)await GetScalarAsync("`RecDate`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 AmountType（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetAmountTypeByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`AmountType`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<int> GetAmountTypeByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`AmountType`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        #endregion // GetXXXByPK
        #region GetByXXX
        #region GetByOperatorID

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, int top_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, int top_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, string sort_)
        {
            return GetByOperatorID(operatorID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, string sort_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, sort_, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByOperatorID
        #region GetByCurrencyID

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, int top_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, int top_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, string sort_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByCurrencyID
        #region GetByActivityID

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID)
        {
            return GetByActivityID(activityID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, int top_)
        {
            return GetByActivityID(activityID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, int top_)
        {
            return await GetByActivityIDAsync(activityID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, int top_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, int top_, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, string sort_)
        {
            return GetByActivityID(activityID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, string sort_)
        {
            return await GetByActivityIDAsync(activityID, 0, sort_, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, string sort_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, string sort_, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByActivityID(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByActivityIDAsync(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByActivityID
        #region GetByCountryID

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID)
        {
            return GetByCountryID(countryID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, int top_)
        {
            return GetByCountryID(countryID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, int top_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, string sort_)
        {
            return GetByCountryID(countryID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, string sort_)
        {
            return await GetByCountryIDAsync(countryID, 0, sort_, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByCountryID
        #region GetByRewardRatio

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio)
        {
            return GetByRewardRatio(rewardRatio, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio)
        {
            return await GetByRewardRatioAsync(rewardRatio, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, TransactionManager tm_)
        {
            return GetByRewardRatio(rewardRatio, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, TransactionManager tm_)
        {
            return await GetByRewardRatioAsync(rewardRatio, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, int top_)
        {
            return GetByRewardRatio(rewardRatio, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, int top_)
        {
            return await GetByRewardRatioAsync(rewardRatio, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, int top_, TransactionManager tm_)
        {
            return GetByRewardRatio(rewardRatio, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, int top_, TransactionManager tm_)
        {
            return await GetByRewardRatioAsync(rewardRatio, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, string sort_)
        {
            return GetByRewardRatio(rewardRatio, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, string sort_)
        {
            return await GetByRewardRatioAsync(rewardRatio, 0, sort_, null);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, string sort_, TransactionManager tm_)
        {
            return GetByRewardRatio(rewardRatio, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, string sort_, TransactionManager tm_)
        {
            return await GetByRewardRatioAsync(rewardRatio, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 RewardRatio（字段） 查询
        /// </summary>
        /// /// <param name = "rewardRatio">返奖比例</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRewardRatio(float rewardRatio, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RewardRatio` = @RewardRatio", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRewardRatioAsync(float rewardRatio, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RewardRatio` = @RewardRatio", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RewardRatio", rewardRatio, MySqlDbType.Float));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByRewardRatio
        #region GetByMinAmount

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount)
        {
            return GetByMinAmount(minAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount)
        {
            return await GetByMinAmountAsync(minAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, TransactionManager tm_)
        {
            return GetByMinAmount(minAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, TransactionManager tm_)
        {
            return await GetByMinAmountAsync(minAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, int top_)
        {
            return GetByMinAmount(minAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, int top_)
        {
            return await GetByMinAmountAsync(minAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, int top_, TransactionManager tm_)
        {
            return GetByMinAmount(minAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, int top_, TransactionManager tm_)
        {
            return await GetByMinAmountAsync(minAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, string sort_)
        {
            return GetByMinAmount(minAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, string sort_)
        {
            return await GetByMinAmountAsync(minAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, string sort_, TransactionManager tm_)
        {
            return GetByMinAmount(minAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, string sort_, TransactionManager tm_)
        {
            return await GetByMinAmountAsync(minAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 MinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "minAmount">奖励发放最小金额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByMinAmount(long minAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`MinAmount` = @MinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByMinAmountAsync(long minAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`MinAmount` = @MinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@MinAmount", minAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByMinAmount
        #region GetByFlowMultip

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip)
        {
            return GetByFlowMultip(flowMultip, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, int top_)
        {
            return GetByFlowMultip(flowMultip, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, int top_)
        {
            return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, int top_, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, int top_, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, string sort_)
        {
            return GetByFlowMultip(flowMultip, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, string sort_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, sort_, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, string sort_, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, string sort_, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">要求的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByFlowMultip(float flowMultip, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByFlowMultipAsync(float flowMultip, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByFlowMultip
        #region GetByRecDate

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate)
        {
            return GetByRecDate(recDate, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, int top_)
        {
            return GetByRecDate(recDate, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, int top_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, string sort_)
        {
            return GetByRecDate(recDate, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, string sort_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByRecDate
        #region GetByAmountType

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType)
        {
            return GetByAmountType(amountType, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType)
        {
            return await GetByAmountTypeAsync(amountType, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, TransactionManager tm_)
        {
            return GetByAmountType(amountType, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, int top_)
        {
            return GetByAmountType(amountType, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, int top_)
        {
            return await GetByAmountTypeAsync(amountType, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, int top_, TransactionManager tm_)
        {
            return GetByAmountType(amountType, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, int top_, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, string sort_)
        {
            return GetByAmountType(amountType, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, string sort_)
        {
            return await GetByAmountTypeAsync(amountType, 0, sort_, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, string sort_, TransactionManager tm_)
        {
            return GetByAmountType(amountType, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, string sort_, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">1bonus,2真金</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_quartz_configEO> GetByAmountType(int amountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`AmountType` = @AmountType", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_quartz_configEO>> GetByAmountTypeAsync(int amountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`AmountType` = @AmountType", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_quartz_configEO.MapDataReader);
        }
        #endregion // GetByAmountType
        #endregion // GetByXXX
        #endregion // Get
    }
    #endregion // MO
}
