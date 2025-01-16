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
    /// 实时返点配置表
    /// 【表 sa_rebate_realtime_config 的实体类】
    /// </summary>
    [DataContract]
    [Obsolete]
    public class Sa_rebate_realtime_configEO : IRowMapper<Sa_rebate_realtime_configEO>
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public Sa_rebate_realtime_configEO()
        {
            BetMinAmount = 0;
            BetMaxAmount = 0;
            FlowMultip = 10.00f;
            RecDate = DateTime.Now;
            Level = 0;
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
        /// 最小打码量
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 6)]
        public long BetMinAmount { get; set; }
        /// <summary>
        /// 最大打码量
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 7)]
        public long BetMaxAmount { get; set; }
        /// <summary>
        /// 赠金额度
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 8)]
        public long RebateAmount { get; set; }
        /// <summary>
        /// 赠金提现所需要的流水倍数
        /// 【字段 float(10,2)】
        /// </summary>
        [DataMember(Order = 9)]
        public float FlowMultip { get; set; }
        /// <summary>
        /// 记录创建时间
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 10)]
        public DateTime RecDate { get; set; }
        /// <summary>
        /// 等级
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 11)]
        public int Level { get; set; }
        /// <summary>
        /// 打码类型：1bonus,2真金3真金加bouns
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 12)]
        public int AmountType { get; set; }
        #endregion // 所有列
        #region 实体映射

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public Sa_rebate_realtime_configEO MapRow(IDataReader reader)
        {
            return MapDataReader(reader);
        }

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public static Sa_rebate_realtime_configEO MapDataReader(IDataReader reader)
        {
            Sa_rebate_realtime_configEO ret = new Sa_rebate_realtime_configEO();
            ret.ConfigID = reader.ToInt32("ConfigID");
            ret.OriginalConfigID = ret.ConfigID;
            ret.OperatorID = reader.ToString("OperatorID");
            ret.CurrencyID = reader.ToString("CurrencyID");
            ret.ActivityID = reader.ToInt32("ActivityID");
            ret.CountryID = reader.ToString("CountryID");
            ret.BetMinAmount = reader.ToInt64("BetMinAmount");
            ret.BetMaxAmount = reader.ToInt64("BetMaxAmount");
            ret.RebateAmount = reader.ToInt64("RebateAmount");
            ret.FlowMultip = reader.ToSingle("FlowMultip");
            ret.RecDate = reader.ToDateTime("RecDate");
            ret.Level = reader.ToInt32("Level");
            ret.AmountType = reader.ToInt32("AmountType");
            return ret;
        }

        #endregion
    }
    #endregion // EO

    #region MO
    /// <summary>
    /// 实时返点配置表
    /// 【表 sa_rebate_realtime_config 的操作类】
    /// </summary>
    [Obsolete]
    public class Sa_rebate_realtime_configMO : MySqlTableMO<Sa_rebate_realtime_configEO>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName { get; set; } = "`sa_rebate_realtime_config`";

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "database">数据来源</param>
        public Sa_rebate_realtime_configMO(MySqlDatabase database) : base(database) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
        public Sa_rebate_realtime_configMO(string connectionStringName = null) : base(connectionStringName) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">CommandTimeout时间</param>
        public Sa_rebate_realtime_configMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
        #endregion // Constructors

        #region  Add
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name = "item">要插入的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="useIgnore_">是否使用INSERT IGNORE</param>
        /// <return>受影响的行数</return>
        public override int Add(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            item.ConfigID = Database.ExecSqlScalar<int>(sql_, paras_, tm_);
            return 1;
        }
        public override async Task<int> AddAsync(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            item.ConfigID = await Database.ExecSqlScalarAsync<int>(sql_, paras_, tm_);
            return 1;
        }
        private void RepairAddData(Sa_rebate_realtime_configEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
            sql_ += $" INTO {TableName} (`OperatorID`, `CurrencyID`, `ActivityID`, `CountryID`, `BetMinAmount`, `BetMaxAmount`, `RebateAmount`, `FlowMultip`, `RecDate`, `Level`, `AmountType`) VALUE (@OperatorID, @CurrencyID, @ActivityID, @CountryID, @BetMinAmount, @BetMaxAmount, @RebateAmount, @FlowMultip, @RecDate, @Level, @AmountType);SELECT LAST_INSERT_ID();";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BetMinAmount", item.BetMinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@BetMaxAmount", item.BetMaxAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@RebateAmount", item.RebateAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
                Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@Level", item.Level, MySqlDbType.Int32),
                Database.CreateInParameter("@AmountType", item.AmountType, MySqlDbType.Int32),
            };
        }
        public int AddByBatch(IEnumerable<Sa_rebate_realtime_configEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += Database.ExecSqlNonQuery(sql, tm_);
            }
            return ret;
        }
        public async Task<int> AddByBatchAsync(IEnumerable<Sa_rebate_realtime_configEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
            }
            return ret;
        }
        private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_rebate_realtime_configEO> items, int batchCount)
        {
            var count = 0;
            var insertSql = $"INSERT INTO {TableName} (`ConfigID`, `OperatorID`, `CurrencyID`, `ActivityID`, `CountryID`, `BetMinAmount`, `BetMaxAmount`, `RebateAmount`, `FlowMultip`, `RecDate`, `Level`, `AmountType`) VALUES ";
            var sql = new StringBuilder();
            foreach (var item in items)
            {
                count++;
                sql.Append($"({item.ConfigID},'{item.OperatorID}','{item.CurrencyID}',{item.ActivityID},'{item.CountryID}',{item.BetMinAmount},{item.BetMaxAmount},{item.RebateAmount},{item.FlowMultip},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.Level},{item.AmountType}),");
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
        public int Remove(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null)
        {
            return RemoveByPK(item.ConfigID, tm_);
        }
        public async Task<int> RemoveAsync(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null)
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
        #region RemoveByBetMinAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBetMinAmount(long betMinAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByBetMinAmountData(betMinAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBetMinAmountAsync(long betMinAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByBetMinAmountData(betMinAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBetMinAmountData(long betMinAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `BetMinAmount` = @BetMinAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByBetMinAmount
        #region RemoveByBetMaxAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBetMaxAmount(long betMaxAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByBetMaxAmountData(betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByBetMaxAmountData(betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBetMaxAmountData(long betMaxAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `BetMaxAmount` = @BetMaxAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByBetMaxAmount
        #region RemoveByRebateAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByRebateAmount(long rebateAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByRebateAmountData(rebateAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByRebateAmountAsync(long rebateAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByRebateAmountData(rebateAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByRebateAmountData(long rebateAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `RebateAmount` = @RebateAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByRebateAmount
        #region RemoveByFlowMultip
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
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
        /// /// <param name = "recDate">记录创建时间</param>
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
        #region RemoveByLevel
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByLevel(int level, TransactionManager tm_ = null)
        {
            RepairRemoveByLevelData(level, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByLevelAsync(int level, TransactionManager tm_ = null)
        {
            RepairRemoveByLevelData(level, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByLevelData(int level, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `Level` = @Level";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.Int32));
        }
        #endregion // RemoveByLevel
        #region RemoveByAmountType
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
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
        public int Put(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAsync(Sa_rebate_realtime_configEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutData(Sa_rebate_realtime_configEO item, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID, `ActivityID` = @ActivityID, `CountryID` = @CountryID, `BetMinAmount` = @BetMinAmount, `BetMaxAmount` = @BetMaxAmount, `RebateAmount` = @RebateAmount, `FlowMultip` = @FlowMultip, `Level` = @Level, `AmountType` = @AmountType WHERE `ConfigID` = @ConfigID_Original";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BetMinAmount", item.BetMinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@BetMaxAmount", item.BetMaxAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@RebateAmount", item.RebateAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
                Database.CreateInParameter("@Level", item.Level, MySqlDbType.Int32),
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
        public int Put(IEnumerable<Sa_rebate_realtime_configEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += Put(item, tm_);
            }
            return ret;
        }
        public async Task<int> PutAsync(IEnumerable<Sa_rebate_realtime_configEO> items, TransactionManager tm_ = null)
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
        #region PutBetMinAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBetMinAmountByPK(int configID, long betMinAmount, TransactionManager tm_ = null)
        {
            RepairPutBetMinAmountByPKData(configID, betMinAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBetMinAmountByPKAsync(int configID, long betMinAmount, TransactionManager tm_ = null)
        {
            RepairPutBetMinAmountByPKData(configID, betMinAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBetMinAmountByPKData(int configID, long betMinAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBetMinAmount(long betMinAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount";
            var parameter_ = Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBetMinAmountAsync(long betMinAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount";
            var parameter_ = Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBetMinAmount
        #region PutBetMaxAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBetMaxAmountByPK(int configID, long betMaxAmount, TransactionManager tm_ = null)
        {
            RepairPutBetMaxAmountByPKData(configID, betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBetMaxAmountByPKAsync(int configID, long betMaxAmount, TransactionManager tm_ = null)
        {
            RepairPutBetMaxAmountByPKData(configID, betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBetMaxAmountByPKData(int configID, long betMaxAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBetMaxAmount(long betMaxAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount";
            var parameter_ = Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount";
            var parameter_ = Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBetMaxAmount
        #region PutRebateAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRebateAmountByPK(int configID, long rebateAmount, TransactionManager tm_ = null)
        {
            RepairPutRebateAmountByPKData(configID, rebateAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutRebateAmountByPKAsync(int configID, long rebateAmount, TransactionManager tm_ = null)
        {
            RepairPutRebateAmountByPKData(configID, rebateAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutRebateAmountByPKData(int configID, long rebateAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `RebateAmount` = @RebateAmount  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRebateAmount(long rebateAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RebateAmount` = @RebateAmount";
            var parameter_ = Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutRebateAmountAsync(long rebateAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `RebateAmount` = @RebateAmount";
            var parameter_ = Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutRebateAmount
        #region PutFlowMultip
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
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
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
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
        /// /// <param name = "recDate">记录创建时间</param>
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
        /// /// <param name = "recDate">记录创建时间</param>
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
        #region PutLevel
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "level">等级</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutLevelByPK(int configID, int level, TransactionManager tm_ = null)
        {
            RepairPutLevelByPKData(configID, level, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutLevelByPKAsync(int configID, int level, TransactionManager tm_ = null)
        {
            RepairPutLevelByPKData(configID, level, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutLevelByPKData(int configID, int level, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `Level` = @Level  WHERE `ConfigID` = @ConfigID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@Level", level, MySqlDbType.Int32),
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutLevel(int level, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Level` = @Level";
            var parameter_ = Database.CreateInParameter("@Level", level, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutLevelAsync(int level, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Level` = @Level";
            var parameter_ = Database.CreateInParameter("@Level", level, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutLevel
        #region PutAmountType
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
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
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
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
        public bool Set(Sa_rebate_realtime_configEO item, TransactionManager tm = null)
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
        public async Task<bool> SetAsync(Sa_rebate_realtime_configEO item, TransactionManager tm = null)
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
        public Sa_rebate_realtime_configEO GetByPK(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<Sa_rebate_realtime_configEO> GetByPKAsync(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
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
        /// 按主键查询 BetMinAmount（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetBetMinAmountByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`BetMinAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<long> GetBetMinAmountByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`BetMinAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 BetMaxAmount（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetBetMaxAmountByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`BetMaxAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<long> GetBetMaxAmountByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`BetMaxAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 RebateAmount（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetRebateAmountByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`RebateAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<long> GetRebateAmountByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`RebateAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
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
        /// 按主键查询 Level（字段）
        /// </summary>
        /// /// <param name = "configID">主键</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetLevelByPK(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`Level`", "`ConfigID` = @ConfigID", paras_, tm_);
        }
        public async Task<int> GetLevelByPKAsync(int configID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`Level`", "`ConfigID` = @ConfigID", paras_, tm_);
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
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, int top_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, string sort_)
        {
            return GetByOperatorID(operatorID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_realtime_configEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByOperatorID
        #region GetByCurrencyID

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, int top_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, string sort_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_realtime_configEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByCurrencyID
        #region GetByActivityID

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID)
        {
            return GetByActivityID(activityID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, int top_)
        {
            return GetByActivityID(activityID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, int top_)
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
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, int top_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, int top_, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, string sort_)
        {
            return GetByActivityID(activityID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, string sort_)
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
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, string sort_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_realtime_configEO> GetByActivityID(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByActivityIDAsync(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByActivityID
        #region GetByCountryID

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID)
        {
            return GetByCountryID(countryID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, int top_)
        {
            return GetByCountryID(countryID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, int top_)
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
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, string sort_)
        {
            return GetByCountryID(countryID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, string sort_)
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
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_realtime_configEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByCountryID
        #region GetByBetMinAmount

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount)
        {
            return GetByBetMinAmount(betMinAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount)
        {
            return await GetByBetMinAmountAsync(betMinAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, TransactionManager tm_)
        {
            return GetByBetMinAmount(betMinAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, TransactionManager tm_)
        {
            return await GetByBetMinAmountAsync(betMinAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, int top_)
        {
            return GetByBetMinAmount(betMinAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_)
        {
            return await GetByBetMinAmountAsync(betMinAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, int top_, TransactionManager tm_)
        {
            return GetByBetMinAmount(betMinAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_, TransactionManager tm_)
        {
            return await GetByBetMinAmountAsync(betMinAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, string sort_)
        {
            return GetByBetMinAmount(betMinAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, string sort_)
        {
            return await GetByBetMinAmountAsync(betMinAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, string sort_, TransactionManager tm_)
        {
            return GetByBetMinAmount(betMinAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, string sort_, TransactionManager tm_)
        {
            return await GetByBetMinAmountAsync(betMinAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BetMinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMinAmount">最小打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMinAmount(long betMinAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BetMinAmount` = @BetMinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BetMinAmount` = @BetMinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByBetMinAmount
        #region GetByBetMaxAmount

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount)
        {
            return GetByBetMaxAmount(betMaxAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, TransactionManager tm_)
        {
            return GetByBetMaxAmount(betMaxAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, int top_)
        {
            return GetByBetMaxAmount(betMaxAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, int top_, TransactionManager tm_)
        {
            return GetByBetMaxAmount(betMaxAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_, TransactionManager tm_)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, string sort_)
        {
            return GetByBetMaxAmount(betMaxAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, string sort_)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, string sort_, TransactionManager tm_)
        {
            return GetByBetMaxAmount(betMaxAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, string sort_, TransactionManager tm_)
        {
            return await GetByBetMaxAmountAsync(betMaxAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BetMaxAmount（字段） 查询
        /// </summary>
        /// /// <param name = "betMaxAmount">最大打码量</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByBetMaxAmount(long betMaxAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BetMaxAmount` = @BetMaxAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BetMaxAmount` = @BetMaxAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByBetMaxAmount
        #region GetByRebateAmount

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount)
        {
            return GetByRebateAmount(rebateAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount)
        {
            return await GetByRebateAmountAsync(rebateAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, TransactionManager tm_)
        {
            return GetByRebateAmount(rebateAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, TransactionManager tm_)
        {
            return await GetByRebateAmountAsync(rebateAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, int top_)
        {
            return GetByRebateAmount(rebateAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, int top_)
        {
            return await GetByRebateAmountAsync(rebateAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, int top_, TransactionManager tm_)
        {
            return GetByRebateAmount(rebateAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, int top_, TransactionManager tm_)
        {
            return await GetByRebateAmountAsync(rebateAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, string sort_)
        {
            return GetByRebateAmount(rebateAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, string sort_)
        {
            return await GetByRebateAmountAsync(rebateAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, string sort_, TransactionManager tm_)
        {
            return GetByRebateAmount(rebateAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, string sort_, TransactionManager tm_)
        {
            return await GetByRebateAmountAsync(rebateAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 RebateAmount（字段） 查询
        /// </summary>
        /// /// <param name = "rebateAmount">赠金额度</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRebateAmount(long rebateAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RebateAmount` = @RebateAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRebateAmountAsync(long rebateAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RebateAmount` = @RebateAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RebateAmount", rebateAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByRebateAmount
        #region GetByFlowMultip

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip)
        {
            return GetByFlowMultip(flowMultip, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, int top_)
        {
            return GetByFlowMultip(flowMultip, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, int top_)
        {
            return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, int top_, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, int top_, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, string sort_)
        {
            return GetByFlowMultip(flowMultip, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, string sort_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, sort_, null);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, string sort_, TransactionManager tm_)
        {
            return GetByFlowMultip(flowMultip, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, string sort_, TransactionManager tm_)
        {
            return await GetByFlowMultipAsync(flowMultip, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 FlowMultip（字段） 查询
        /// </summary>
        /// /// <param name = "flowMultip">赠金提现所需要的流水倍数</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByFlowMultip(float flowMultip, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByFlowMultipAsync(float flowMultip, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByFlowMultip
        #region GetByRecDate

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate)
        {
            return GetByRecDate(recDate, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, int top_)
        {
            return GetByRecDate(recDate, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, int top_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, string sort_)
        {
            return GetByRecDate(recDate, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, string sort_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByRecDate
        #region GetByLevel

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level)
        {
            return GetByLevel(level, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level)
        {
            return await GetByLevelAsync(level, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, TransactionManager tm_)
        {
            return GetByLevel(level, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, TransactionManager tm_)
        {
            return await GetByLevelAsync(level, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, int top_)
        {
            return GetByLevel(level, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, int top_)
        {
            return await GetByLevelAsync(level, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, int top_, TransactionManager tm_)
        {
            return GetByLevel(level, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, int top_, TransactionManager tm_)
        {
            return await GetByLevelAsync(level, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, string sort_)
        {
            return GetByLevel(level, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, string sort_)
        {
            return await GetByLevelAsync(level, 0, sort_, null);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, string sort_, TransactionManager tm_)
        {
            return GetByLevel(level, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, string sort_, TransactionManager tm_)
        {
            return await GetByLevelAsync(level, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 Level（字段） 查询
        /// </summary>
        /// /// <param name = "level">等级</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByLevel(int level, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`Level` = @Level", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByLevelAsync(int level, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`Level` = @Level", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByLevel
        #region GetByAmountType

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType)
        {
            return GetByAmountType(amountType, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType)
        {
            return await GetByAmountTypeAsync(amountType, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, TransactionManager tm_)
        {
            return GetByAmountType(amountType, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, int top_)
        {
            return GetByAmountType(amountType, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, int top_)
        {
            return await GetByAmountTypeAsync(amountType, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, int top_, TransactionManager tm_)
        {
            return GetByAmountType(amountType, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, int top_, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, string sort_)
        {
            return GetByAmountType(amountType, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, string sort_)
        {
            return await GetByAmountTypeAsync(amountType, 0, sort_, null);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, string sort_, TransactionManager tm_)
        {
            return GetByAmountType(amountType, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, string sort_, TransactionManager tm_)
        {
            return await GetByAmountTypeAsync(amountType, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 AmountType（字段） 查询
        /// </summary>
        /// /// <param name = "amountType">打码类型：1bonus,2真金3真金加bouns</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_realtime_configEO> GetByAmountType(int amountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`AmountType` = @AmountType", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_realtime_configEO>> GetByAmountTypeAsync(int amountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`AmountType` = @AmountType", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@AmountType", amountType, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_realtime_configEO.MapDataReader);
        }
        #endregion // GetByAmountType
        #endregion // GetByXXX
        #endregion // Get
    }
    #endregion // MO
}
