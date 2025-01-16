/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 18: 05:11
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

namespace SActivity.Common.Repositories.tinyfx
{
    #region EO
    /// <summary>
    /// 运营商活动关系表
    /// 【表 l_activity_operator 的实体类】
    /// </summary>
    [DataContract]
    [Obsolete]
    public class L_activity_operatorEO : IRowMapper<L_activity_operatorEO>
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public L_activity_operatorEO()
        {
            OrderNum = 0;
            Status = false;
            IsSendNotify = true;
            IsSendNotifyEmail = true;
            IsAllowEnd = false;
            IsAllowIndexRecommend = false;
            IsAllowPayRecommend = false;
            IsBonus = true;
        }
        #region 主键原始值 & 主键集合

        /// <summary>
        /// 当前对象是否保存原始主键值，当修改了主键值时为 true
        /// </summary>
        public bool HasOriginal { get; protected set; }

        private int _originalActivityID;
        /// <summary>
        /// 【数据库中的原始主键 ActivityID 值的副本，用于主键值更新】
        /// </summary>
        public int OriginalActivityID
        {
            get { return _originalActivityID; }
            set { HasOriginal = true; _originalActivityID = value; }
        }

        private string _originalOperatorID;
        /// <summary>
        /// 【数据库中的原始主键 OperatorID 值的副本，用于主键值更新】
        /// </summary>
        public string OriginalOperatorID
        {
            get { return _originalOperatorID; }
            set { HasOriginal = true; _originalOperatorID = value; }
        }

        private string _originalCurrencyID;
        /// <summary>
        /// 【数据库中的原始主键 CurrencyID 值的副本，用于主键值更新】
        /// </summary>
        public string OriginalCurrencyID
        {
            get { return _originalCurrencyID; }
            set { HasOriginal = true; _originalCurrencyID = value; }
        }
        /// <summary>
        /// 获取主键集合。key: 数据库字段名称, value: 主键值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetPrimaryKeys()
        {
            return new Dictionary<string, object>() { { "ActivityID", ActivityID }, { "OperatorID", OperatorID }, { "CurrencyID", CurrencyID }, };
        }
        /// <summary>
        /// 获取主键集合JSON格式
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
        #endregion // 主键原始值
        #region 所有字段
        /// <summary>
        /// 活动id
        /// 【主键 int】
        /// </summary>
        [DataMember(Order = 1)]
        public int ActivityID { get; set; }
        /// <summary>
        /// 运营商编码
        /// 【主键 varchar(50)】
        /// </summary>
        [DataMember(Order = 2)]
        public string OperatorID { get; set; }
        /// <summary>
        /// 货币类型
        /// 【主键 varchar(20)】
        /// </summary>
        [DataMember(Order = 3)]
        public string CurrencyID { get; set; }
        /// <summary>
        /// 国家编码ISO 3166-1三位字母
        /// 【字段 varchar(5)】
        /// </summary>
        [DataMember(Order = 4)]
        public string CountryID { get; set; }
        /// <summary>
        /// 起始日期（默认2016-01-01）
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 5)]
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 截止日期（默认2099-01-01）
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 6)]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 排序
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 7)]
        public int OrderNum { get; set; }
        /// <summary>
        /// 状态(0-无效1-有效)
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 8)]
        public bool Status { get; set; }
        /// <summary>
        /// 是否发送弹框通知
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 9)]
        public bool IsSendNotify { get; set; }
        /// <summary>
        /// 是否发送站内邮件溶质
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 10)]
        public bool IsSendNotifyEmail { get; set; }
        /// <summary>
        /// 是否允许完成
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 11)]
        public bool IsAllowEnd { get; set; }
        /// <summary>
        /// 是否允许首页banner位推荐
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 12)]
        public bool IsAllowIndexRecommend { get; set; }
        /// <summary>
        /// 是否为充值页推荐的banner
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 13)]
        public bool IsAllowPayRecommend { get; set; }
        /// <summary>
        /// 0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 14)]
        public bool IsBonus { get; set; }
        #endregion // 所有列
        #region 实体映射

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public L_activity_operatorEO MapRow(IDataReader reader)
        {
            return MapDataReader(reader);
        }

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public static L_activity_operatorEO MapDataReader(IDataReader reader)
        {
            L_activity_operatorEO ret = new L_activity_operatorEO();
            ret.ActivityID = reader.ToInt32("ActivityID");
            ret.OriginalActivityID = ret.ActivityID;
            ret.OperatorID = reader.ToString("OperatorID");
            ret.OriginalOperatorID = ret.OperatorID;
            ret.CurrencyID = reader.ToString("CurrencyID");
            ret.OriginalCurrencyID = ret.CurrencyID;
            ret.CountryID = reader.ToString("CountryID");
            ret.BeginDate = reader.ToDateTime("BeginDate");
            ret.EndDate = reader.ToDateTime("EndDate");
            ret.OrderNum = reader.ToInt32("OrderNum");
            ret.Status = reader.ToBoolean("Status");
            ret.IsSendNotify = reader.ToBoolean("IsSendNotify");
            ret.IsSendNotifyEmail = reader.ToBoolean("IsSendNotifyEmail");
            ret.IsAllowEnd = reader.ToBoolean("IsAllowEnd");
            ret.IsAllowIndexRecommend = reader.ToBoolean("IsAllowIndexRecommend");
            ret.IsAllowPayRecommend = reader.ToBoolean("IsAllowPayRecommend");
            ret.IsBonus = reader.ToBoolean("IsBonus");
            return ret;
        }

        #endregion
    }
    #endregion // EO

    #region MO
    /// <summary>
    /// 运营商活动关系表
    /// 【表 l_activity_operator 的操作类】
    /// </summary>
    [Obsolete]
    public class L_activity_operatorMO : MySqlTableMO<L_activity_operatorEO>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName { get; set; } = "`l_activity_operator`";

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "database">数据来源</param>
        public L_activity_operatorMO(MySqlDatabase database) : base(database) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
        public L_activity_operatorMO(string connectionStringName = null) : base(connectionStringName) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">CommandTimeout时间</param>
        public L_activity_operatorMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
        #endregion // Constructors

        #region  Add
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name = "item">要插入的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="useIgnore_">是否使用INSERT IGNORE</param>
        /// <return>受影响的行数</return>
        public override int Add(L_activity_operatorEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public override async Task<int> AddAsync(L_activity_operatorEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairAddData(L_activity_operatorEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
            sql_ += $" INTO {TableName} (`ActivityID`, `OperatorID`, `CurrencyID`, `CountryID`, `BeginDate`, `EndDate`, `OrderNum`, `Status`, `IsSendNotify`, `IsSendNotifyEmail`, `IsAllowEnd`, `IsAllowIndexRecommend`, `IsAllowPayRecommend`, `IsBonus`) VALUE (@ActivityID, @OperatorID, @CurrencyID, @CountryID, @BeginDate, @EndDate, @OrderNum, @Status, @IsSendNotify, @IsSendNotifyEmail, @IsAllowEnd, @IsAllowIndexRecommend, @IsAllowPayRecommend, @IsBonus);";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BeginDate", item.BeginDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@EndDate", item.EndDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
                Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
                Database.CreateInParameter("@IsSendNotify", item.IsSendNotify, MySqlDbType.Byte),
                Database.CreateInParameter("@IsSendNotifyEmail", item.IsSendNotifyEmail, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowEnd", item.IsAllowEnd, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowIndexRecommend", item.IsAllowIndexRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowPayRecommend", item.IsAllowPayRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@IsBonus", item.IsBonus, MySqlDbType.Byte),
            };
        }
        public int AddByBatch(IEnumerable<L_activity_operatorEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += Database.ExecSqlNonQuery(sql, tm_);
            }
            return ret;
        }
        public async Task<int> AddByBatchAsync(IEnumerable<L_activity_operatorEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
            }
            return ret;
        }
        private IEnumerable<string> BuildAddBatchSql(IEnumerable<L_activity_operatorEO> items, int batchCount)
        {
            var count = 0;
            var insertSql = $"INSERT INTO {TableName} (`ActivityID`, `OperatorID`, `CurrencyID`, `CountryID`, `BeginDate`, `EndDate`, `OrderNum`, `Status`, `IsSendNotify`, `IsSendNotifyEmail`, `IsAllowEnd`, `IsAllowIndexRecommend`, `IsAllowPayRecommend`, `IsBonus`) VALUES ";
            var sql = new StringBuilder();
            foreach (var item in items)
            {
                count++;
                sql.Append($"({item.ActivityID},'{item.OperatorID}','{item.CurrencyID}','{item.CountryID}','{item.BeginDate.ToString("yyyy-MM-dd HH:mm:ss")}','{item.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.OrderNum},{item.Status},{item.IsSendNotify},{item.IsSendNotifyEmail},{item.IsAllowEnd},{item.IsAllowIndexRecommend},{item.IsAllowPayRecommend},{item.IsBonus}),");
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
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(activityID, operatorID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(activityID, operatorID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepiarRemoveByPKData(int activityID, string operatorID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }
        /// <summary>
        /// 删除指定实体对应的记录
        /// </summary>
        /// <param name = "item">要删除的实体</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Remove(L_activity_operatorEO item, TransactionManager tm_ = null)
        {
            return RemoveByPK(item.ActivityID, item.OperatorID, item.CurrencyID, tm_);
        }
        public async Task<int> RemoveAsync(L_activity_operatorEO item, TransactionManager tm_ = null)
        {
            return await RemoveByPKAsync(item.ActivityID, item.OperatorID, item.CurrencyID, tm_);
        }
        #endregion // RemoveByPK

        #region RemoveByXXX
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
        #region RemoveByBeginDate
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBeginDate(DateTime beginDate, TransactionManager tm_ = null)
        {
            RepairRemoveByBeginDateData(beginDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBeginDateAsync(DateTime beginDate, TransactionManager tm_ = null)
        {
            RepairRemoveByBeginDateData(beginDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBeginDateData(DateTime beginDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `BeginDate` = @BeginDate";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime));
        }
        #endregion // RemoveByBeginDate
        #region RemoveByEndDate
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByEndDate(DateTime endDate, TransactionManager tm_ = null)
        {
            RepairRemoveByEndDateData(endDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByEndDateAsync(DateTime endDate, TransactionManager tm_ = null)
        {
            RepairRemoveByEndDateData(endDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByEndDateData(DateTime endDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `EndDate` = @EndDate";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime));
        }
        #endregion // RemoveByEndDate
        #region RemoveByOrderNum
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByOrderNum(int orderNum, TransactionManager tm_ = null)
        {
            RepairRemoveByOrderNumData(orderNum, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByOrderNumAsync(int orderNum, TransactionManager tm_ = null)
        {
            RepairRemoveByOrderNumData(orderNum, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByOrderNumData(int orderNum, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `OrderNum` = @OrderNum";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
        }
        #endregion // RemoveByOrderNum
        #region RemoveByStatus
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByStatus(bool status, TransactionManager tm_ = null)
        {
            RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByStatusAsync(bool status, TransactionManager tm_ = null)
        {
            RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByStatusData(bool status, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `Status` = @Status";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
        }
        #endregion // RemoveByStatus
        #region RemoveByIsSendNotify
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsSendNotify(bool isSendNotify, TransactionManager tm_ = null)
        {
            RepairRemoveByIsSendNotifyData(isSendNotify, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsSendNotifyAsync(bool isSendNotify, TransactionManager tm_ = null)
        {
            RepairRemoveByIsSendNotifyData(isSendNotify, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsSendNotifyData(bool isSendNotify, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsSendNotify` = @IsSendNotify";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsSendNotify
        #region RemoveByIsSendNotifyEmail
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsSendNotifyEmail(bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            RepairRemoveByIsSendNotifyEmailData(isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsSendNotifyEmailAsync(bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            RepairRemoveByIsSendNotifyEmailData(isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsSendNotifyEmailData(bool isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsSendNotifyEmail` = @IsSendNotifyEmail";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsSendNotifyEmail
        #region RemoveByIsAllowEnd
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsAllowEnd(bool isAllowEnd, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowEndData(isAllowEnd, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsAllowEndAsync(bool isAllowEnd, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowEndData(isAllowEnd, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsAllowEndData(bool isAllowEnd, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsAllowEnd` = @IsAllowEnd";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsAllowEnd
        #region RemoveByIsAllowIndexRecommend
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsAllowIndexRecommend(bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowIndexRecommendData(isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowIndexRecommendData(isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsAllowIndexRecommendData(bool isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsAllowIndexRecommend` = @IsAllowIndexRecommend";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsAllowIndexRecommend
        #region RemoveByIsAllowPayRecommend
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsAllowPayRecommend(bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowPayRecommendData(isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsAllowPayRecommendAsync(bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            RepairRemoveByIsAllowPayRecommendData(isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsAllowPayRecommendData(bool isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsAllowPayRecommend` = @IsAllowPayRecommend";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsAllowPayRecommend
        #region RemoveByIsBonus
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByIsBonus(bool isBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByIsBonusData(isBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByIsBonusAsync(bool isBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByIsBonusData(isBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByIsBonusData(bool isBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `IsBonus` = @IsBonus";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
        }
        #endregion // RemoveByIsBonus
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
        public int Put(L_activity_operatorEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAsync(L_activity_operatorEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutData(L_activity_operatorEO item, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `ActivityID` = @ActivityID, `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID, `CountryID` = @CountryID, `BeginDate` = @BeginDate, `EndDate` = @EndDate, `OrderNum` = @OrderNum, `Status` = @Status, `IsSendNotify` = @IsSendNotify, `IsSendNotifyEmail` = @IsSendNotifyEmail, `IsAllowEnd` = @IsAllowEnd, `IsAllowIndexRecommend` = @IsAllowIndexRecommend, `IsAllowPayRecommend` = @IsAllowPayRecommend, `IsBonus` = @IsBonus WHERE `ActivityID` = @ActivityID_Original AND `OperatorID` = @OperatorID_Original AND `CurrencyID` = @CurrencyID_Original";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BeginDate", item.BeginDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@EndDate", item.EndDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
                Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
                Database.CreateInParameter("@IsSendNotify", item.IsSendNotify, MySqlDbType.Byte),
                Database.CreateInParameter("@IsSendNotifyEmail", item.IsSendNotifyEmail, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowEnd", item.IsAllowEnd, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowIndexRecommend", item.IsAllowIndexRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@IsAllowPayRecommend", item.IsAllowPayRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@IsBonus", item.IsBonus, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID_Original", item.HasOriginal ? item.OriginalActivityID : item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID_Original", item.HasOriginal ? item.OriginalOperatorID : item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID_Original", item.HasOriginal ? item.OriginalCurrencyID : item.CurrencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新实体集合到数据库
        /// </summary>
        /// <param name = "items">要更新的实体对象集合</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Put(IEnumerable<L_activity_operatorEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += Put(item, tm_);
            }
            return ret;
        }
        public async Task<int> PutAsync(IEnumerable<L_activity_operatorEO> items, TransactionManager tm_ = null)
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
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int activityID, string operatorID, string currencyID, string set_, params object[] values_)
        {
            return Put(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", ConcatValues(values_, activityID, operatorID, currencyID));
        }
        public async Task<int> PutByPKAsync(int activityID, string operatorID, string currencyID, string set_, params object[] values_)
        {
            return await PutAsync(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", ConcatValues(values_, activityID, operatorID, currencyID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int activityID, string operatorID, string currencyID, string set_, TransactionManager tm_, params object[] values_)
        {
            return Put(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", tm_, ConcatValues(values_, activityID, operatorID, currencyID));
        }
        public async Task<int> PutByPKAsync(int activityID, string operatorID, string currencyID, string set_, TransactionManager tm_, params object[] values_)
        {
            return await PutAsync(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", tm_, ConcatValues(values_, activityID, operatorID, currencyID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="paras_">参数值</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutByPK(int activityID, string operatorID, string currencyID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return Put(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", ConcatParameters(paras_, newParas_), tm_);
        }
        public async Task<int> PutByPKAsync(int activityID, string operatorID, string currencyID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return await PutAsync(set_, "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", ConcatParameters(paras_, newParas_), tm_);
        }
        #endregion // PutByPK

        #region PutXXX
        #region PutActivityID

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
        #region PutOperatorID

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
        #region PutCountryID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCountryIDByPK(int activityID, string operatorID, string currencyID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(activityID, operatorID, currencyID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCountryIDByPKAsync(int activityID, string operatorID, string currencyID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(activityID, operatorID, currencyID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCountryIDByPKData(int activityID, string operatorID, string currencyID, string countryID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
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
        #region PutBeginDate
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBeginDateByPK(int activityID, string operatorID, string currencyID, DateTime beginDate, TransactionManager tm_ = null)
        {
            RepairPutBeginDateByPKData(activityID, operatorID, currencyID, beginDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBeginDateByPKAsync(int activityID, string operatorID, string currencyID, DateTime beginDate, TransactionManager tm_ = null)
        {
            RepairPutBeginDateByPKData(activityID, operatorID, currencyID, beginDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBeginDateByPKData(int activityID, string operatorID, string currencyID, DateTime beginDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BeginDate` = @BeginDate  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBeginDate(DateTime beginDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BeginDate` = @BeginDate";
            var parameter_ = Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBeginDateAsync(DateTime beginDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BeginDate` = @BeginDate";
            var parameter_ = Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBeginDate
        #region PutEndDate
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutEndDateByPK(int activityID, string operatorID, string currencyID, DateTime endDate, TransactionManager tm_ = null)
        {
            RepairPutEndDateByPKData(activityID, operatorID, currencyID, endDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutEndDateByPKAsync(int activityID, string operatorID, string currencyID, DateTime endDate, TransactionManager tm_ = null)
        {
            RepairPutEndDateByPKData(activityID, operatorID, currencyID, endDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutEndDateByPKData(int activityID, string operatorID, string currencyID, DateTime endDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `EndDate` = @EndDate  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutEndDate(DateTime endDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `EndDate` = @EndDate";
            var parameter_ = Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutEndDateAsync(DateTime endDate, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `EndDate` = @EndDate";
            var parameter_ = Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutEndDate
        #region PutOrderNum
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "orderNum">排序</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOrderNumByPK(int activityID, string operatorID, string currencyID, int orderNum, TransactionManager tm_ = null)
        {
            RepairPutOrderNumByPKData(activityID, operatorID, currencyID, orderNum, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutOrderNumByPKAsync(int activityID, string operatorID, string currencyID, int orderNum, TransactionManager tm_ = null)
        {
            RepairPutOrderNumByPKData(activityID, operatorID, currencyID, orderNum, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutOrderNumByPKData(int activityID, string operatorID, string currencyID, int orderNum, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOrderNum(int orderNum, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum";
            var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutOrderNumAsync(int orderNum, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum";
            var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutOrderNum
        #region PutStatus
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutStatusByPK(int activityID, string operatorID, string currencyID, bool status, TransactionManager tm_ = null)
        {
            RepairPutStatusByPKData(activityID, operatorID, currencyID, status, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutStatusByPKAsync(int activityID, string operatorID, string currencyID, bool status, TransactionManager tm_ = null)
        {
            RepairPutStatusByPKData(activityID, operatorID, currencyID, status, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutStatusByPKData(int activityID, string operatorID, string currencyID, bool status, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutStatus(bool status, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
            var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutStatusAsync(bool status, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
            var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutStatus
        #region PutIsSendNotify
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsSendNotifyByPK(int activityID, string operatorID, string currencyID, bool isSendNotify, TransactionManager tm_ = null)
        {
            RepairPutIsSendNotifyByPKData(activityID, operatorID, currencyID, isSendNotify, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsSendNotifyByPKAsync(int activityID, string operatorID, string currencyID, bool isSendNotify, TransactionManager tm_ = null)
        {
            RepairPutIsSendNotifyByPKData(activityID, operatorID, currencyID, isSendNotify, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsSendNotifyByPKData(int activityID, string operatorID, string currencyID, bool isSendNotify, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsSendNotify` = @IsSendNotify  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsSendNotify(bool isSendNotify, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsSendNotify` = @IsSendNotify";
            var parameter_ = Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsSendNotifyAsync(bool isSendNotify, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsSendNotify` = @IsSendNotify";
            var parameter_ = Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsSendNotify
        #region PutIsSendNotifyEmail
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsSendNotifyEmailByPK(int activityID, string operatorID, string currencyID, bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            RepairPutIsSendNotifyEmailByPKData(activityID, operatorID, currencyID, isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsSendNotifyEmailByPKAsync(int activityID, string operatorID, string currencyID, bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            RepairPutIsSendNotifyEmailByPKData(activityID, operatorID, currencyID, isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsSendNotifyEmailByPKData(int activityID, string operatorID, string currencyID, bool isSendNotifyEmail, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsSendNotifyEmail` = @IsSendNotifyEmail  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsSendNotifyEmail(bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsSendNotifyEmail` = @IsSendNotifyEmail";
            var parameter_ = Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsSendNotifyEmailAsync(bool isSendNotifyEmail, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsSendNotifyEmail` = @IsSendNotifyEmail";
            var parameter_ = Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsSendNotifyEmail
        #region PutIsAllowEnd
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowEndByPK(int activityID, string operatorID, string currencyID, bool isAllowEnd, TransactionManager tm_ = null)
        {
            RepairPutIsAllowEndByPKData(activityID, operatorID, currencyID, isAllowEnd, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsAllowEndByPKAsync(int activityID, string operatorID, string currencyID, bool isAllowEnd, TransactionManager tm_ = null)
        {
            RepairPutIsAllowEndByPKData(activityID, operatorID, currencyID, isAllowEnd, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsAllowEndByPKData(int activityID, string operatorID, string currencyID, bool isAllowEnd, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsAllowEnd` = @IsAllowEnd  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowEnd(bool isAllowEnd, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowEnd` = @IsAllowEnd";
            var parameter_ = Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsAllowEndAsync(bool isAllowEnd, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowEnd` = @IsAllowEnd";
            var parameter_ = Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsAllowEnd
        #region PutIsAllowIndexRecommend
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowIndexRecommendByPK(int activityID, string operatorID, string currencyID, bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            RepairPutIsAllowIndexRecommendByPKData(activityID, operatorID, currencyID, isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsAllowIndexRecommendByPKAsync(int activityID, string operatorID, string currencyID, bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            RepairPutIsAllowIndexRecommendByPKData(activityID, operatorID, currencyID, isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsAllowIndexRecommendByPKData(int activityID, string operatorID, string currencyID, bool isAllowIndexRecommend, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsAllowIndexRecommend` = @IsAllowIndexRecommend  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowIndexRecommend(bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowIndexRecommend` = @IsAllowIndexRecommend";
            var parameter_ = Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowIndexRecommend` = @IsAllowIndexRecommend";
            var parameter_ = Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsAllowIndexRecommend
        #region PutIsAllowPayRecommend
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowPayRecommendByPK(int activityID, string operatorID, string currencyID, bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            RepairPutIsAllowPayRecommendByPKData(activityID, operatorID, currencyID, isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsAllowPayRecommendByPKAsync(int activityID, string operatorID, string currencyID, bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            RepairPutIsAllowPayRecommendByPKData(activityID, operatorID, currencyID, isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsAllowPayRecommendByPKData(int activityID, string operatorID, string currencyID, bool isAllowPayRecommend, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsAllowPayRecommend` = @IsAllowPayRecommend  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsAllowPayRecommend(bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowPayRecommend` = @IsAllowPayRecommend";
            var parameter_ = Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsAllowPayRecommendAsync(bool isAllowPayRecommend, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsAllowPayRecommend` = @IsAllowPayRecommend";
            var parameter_ = Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsAllowPayRecommend
        #region PutIsBonus
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsBonusByPK(int activityID, string operatorID, string currencyID, bool isBonus, TransactionManager tm_ = null)
        {
            RepairPutIsBonusByPKData(activityID, operatorID, currencyID, isBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutIsBonusByPKAsync(int activityID, string operatorID, string currencyID, bool isBonus, TransactionManager tm_ = null)
        {
            RepairPutIsBonusByPKData(activityID, operatorID, currencyID, isBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutIsBonusByPKData(int activityID, string operatorID, string currencyID, bool isBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus  WHERE `ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutIsBonus(bool isBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus";
            var parameter_ = Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutIsBonusAsync(bool isBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus";
            var parameter_ = Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutIsBonus
        #endregion // PutXXX
        #endregion // Put

        #region Set

        /// <summary>
        /// 插入或者更新数据
        /// </summary>
        /// <param name = "item">要更新的实体对象</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>true:插入操作；false:更新操作</return>
        public bool Set(L_activity_operatorEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.ActivityID, item.OperatorID, item.CurrencyID) == null)
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
        public async Task<bool> SetAsync(L_activity_operatorEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.ActivityID, item.OperatorID, item.CurrencyID) == null)
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
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
        /// <return></return>
        public L_activity_operatorEO GetByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(activityID, operatorID, currencyID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<L_activity_operatorEO> GetByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(activityID, operatorID, currencyID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        private void RepairGetByPKData(int activityID, string operatorID, string currencyID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
        {
            sql_ = BuildSelectSQL("`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", 0, null, null, isForUpdate_);
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
        }
        #endregion // GetByPK

        #region GetXXXByPK

        /// <summary>
        /// 按主键查询 ActivityID（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetActivityIDByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (int)GetScalar("`ActivityID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<int> GetActivityIDByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (int)await GetScalarAsync("`ActivityID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 OperatorID（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetOperatorIDByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`OperatorID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<string> GetOperatorIDByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`OperatorID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CurrencyID（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCurrencyIDByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`CurrencyID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<string> GetCurrencyIDByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`CurrencyID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CountryID（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCountryIDByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`CountryID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<string> GetCountryIDByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`CountryID`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 BeginDate（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetBeginDateByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (DateTime)GetScalar("`BeginDate`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<DateTime> GetBeginDateByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (DateTime)await GetScalarAsync("`BeginDate`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 EndDate（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetEndDateByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (DateTime)GetScalar("`EndDate`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<DateTime> GetEndDateByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (DateTime)await GetScalarAsync("`EndDate`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 OrderNum（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetOrderNumByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (int)GetScalar("`OrderNum`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<int> GetOrderNumByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (int)await GetScalarAsync("`OrderNum`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 Status（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetStatusByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`Status`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetStatusByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`Status`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsSendNotify（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsSendNotifyByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsSendNotify`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsSendNotifyByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsSendNotify`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsSendNotifyEmail（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsSendNotifyEmailByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsSendNotifyEmail`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsSendNotifyEmailByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsSendNotifyEmail`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsAllowEnd（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsAllowEndByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsAllowEnd`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsAllowEndByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsAllowEnd`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsAllowIndexRecommend（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsAllowIndexRecommendByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsAllowIndexRecommend`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsAllowIndexRecommendByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsAllowIndexRecommend`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsAllowPayRecommend（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsAllowPayRecommendByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsAllowPayRecommend`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsAllowPayRecommendByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsAllowPayRecommend`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 IsBonus（字段）
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetIsBonusByPK(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`IsBonus`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        public async Task<bool> GetIsBonusByPKAsync(int activityID, string operatorID, string currencyID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`IsBonus`", "`ActivityID` = @ActivityID AND `OperatorID` = @OperatorID AND `CurrencyID` = @CurrencyID", paras_, tm_);
        }
        #endregion // GetXXXByPK
        #region GetByXXX
        #region GetByActivityID

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByActivityID(int activityID)
        {
            return GetByActivityID(activityID, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByActivityID(int activityID, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByActivityID(int activityID, int top_)
        {
            return GetByActivityID(activityID, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, int top_)
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
        public List<L_activity_operatorEO> GetByActivityID(int activityID, int top_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, int top_, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByActivityID(int activityID, string sort_)
        {
            return GetByActivityID(activityID, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, string sort_)
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
        public List<L_activity_operatorEO> GetByActivityID(int activityID, string sort_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, string sort_, TransactionManager tm_)
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
        public List<L_activity_operatorEO> GetByActivityID(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByActivityIDAsync(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByActivityID
        #region GetByOperatorID

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, int top_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, string sort_)
        {
            return GetByOperatorID(operatorID, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
        public List<L_activity_operatorEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByOperatorID
        #region GetByCurrencyID

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, int top_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, string sort_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
        public List<L_activity_operatorEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByCurrencyID
        #region GetByCountryID

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCountryID(string countryID)
        {
            return GetByCountryID(countryID, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCountryID(string countryID, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCountryID(string countryID, int top_)
        {
            return GetByCountryID(countryID, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, int top_)
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
        public List<L_activity_operatorEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByCountryID(string countryID, string sort_)
        {
            return GetByCountryID(countryID, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, string sort_)
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
        public List<L_activity_operatorEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
        public List<L_activity_operatorEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByCountryID
        #region GetByBeginDate

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate)
        {
            return GetByBeginDate(beginDate, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate)
        {
            return await GetByBeginDateAsync(beginDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, TransactionManager tm_)
        {
            return GetByBeginDate(beginDate, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, TransactionManager tm_)
        {
            return await GetByBeginDateAsync(beginDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, int top_)
        {
            return GetByBeginDate(beginDate, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, int top_)
        {
            return await GetByBeginDateAsync(beginDate, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, int top_, TransactionManager tm_)
        {
            return GetByBeginDate(beginDate, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, int top_, TransactionManager tm_)
        {
            return await GetByBeginDateAsync(beginDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, string sort_)
        {
            return GetByBeginDate(beginDate, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, string sort_)
        {
            return await GetByBeginDateAsync(beginDate, 0, sort_, null);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, string sort_, TransactionManager tm_)
        {
            return GetByBeginDate(beginDate, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, string sort_, TransactionManager tm_)
        {
            return await GetByBeginDateAsync(beginDate, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BeginDate（字段） 查询
        /// </summary>
        /// /// <param name = "beginDate">起始日期（默认2016-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByBeginDate(DateTime beginDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BeginDate` = @BeginDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByBeginDateAsync(DateTime beginDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BeginDate` = @BeginDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BeginDate", beginDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByBeginDate
        #region GetByEndDate

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate)
        {
            return GetByEndDate(endDate, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate)
        {
            return await GetByEndDateAsync(endDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, TransactionManager tm_)
        {
            return GetByEndDate(endDate, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, TransactionManager tm_)
        {
            return await GetByEndDateAsync(endDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, int top_)
        {
            return GetByEndDate(endDate, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, int top_)
        {
            return await GetByEndDateAsync(endDate, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, int top_, TransactionManager tm_)
        {
            return GetByEndDate(endDate, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, int top_, TransactionManager tm_)
        {
            return await GetByEndDateAsync(endDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, string sort_)
        {
            return GetByEndDate(endDate, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, string sort_)
        {
            return await GetByEndDateAsync(endDate, 0, sort_, null);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, string sort_, TransactionManager tm_)
        {
            return GetByEndDate(endDate, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, string sort_, TransactionManager tm_)
        {
            return await GetByEndDateAsync(endDate, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 EndDate（字段） 查询
        /// </summary>
        /// /// <param name = "endDate">截止日期（默认2099-01-01）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByEndDate(DateTime endDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`EndDate` = @EndDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByEndDateAsync(DateTime endDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`EndDate` = @EndDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EndDate", endDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByEndDate
        #region GetByOrderNum

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum)
        {
            return GetByOrderNum(orderNum, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum)
        {
            return await GetByOrderNumAsync(orderNum, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, TransactionManager tm_)
        {
            return GetByOrderNum(orderNum, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, TransactionManager tm_)
        {
            return await GetByOrderNumAsync(orderNum, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, int top_)
        {
            return GetByOrderNum(orderNum, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, int top_)
        {
            return await GetByOrderNumAsync(orderNum, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, int top_, TransactionManager tm_)
        {
            return GetByOrderNum(orderNum, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, int top_, TransactionManager tm_)
        {
            return await GetByOrderNumAsync(orderNum, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, string sort_)
        {
            return GetByOrderNum(orderNum, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, string sort_)
        {
            return await GetByOrderNumAsync(orderNum, 0, sort_, null);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, string sort_, TransactionManager tm_)
        {
            return GetByOrderNum(orderNum, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, string sort_, TransactionManager tm_)
        {
            return await GetByOrderNumAsync(orderNum, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 OrderNum（字段） 查询
        /// </summary>
        /// /// <param name = "orderNum">排序</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByOrderNum(int orderNum, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByOrderNumAsync(int orderNum, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByOrderNum
        #region GetByStatus

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status)
        {
            return GetByStatus(status, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status)
        {
            return await GetByStatusAsync(status, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, TransactionManager tm_)
        {
            return GetByStatus(status, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, TransactionManager tm_)
        {
            return await GetByStatusAsync(status, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, int top_)
        {
            return GetByStatus(status, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, int top_)
        {
            return await GetByStatusAsync(status, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, int top_, TransactionManager tm_)
        {
            return GetByStatus(status, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, int top_, TransactionManager tm_)
        {
            return await GetByStatusAsync(status, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, string sort_)
        {
            return GetByStatus(status, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, string sort_)
        {
            return await GetByStatusAsync(status, 0, sort_, null);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, string sort_, TransactionManager tm_)
        {
            return GetByStatus(status, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, string sort_, TransactionManager tm_)
        {
            return await GetByStatusAsync(status, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 Status（字段） 查询
        /// </summary>
        /// /// <param name = "status">状态(0-无效1-有效)</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByStatus(bool status, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByStatusAsync(bool status, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByStatus
        #region GetByIsSendNotify

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify)
        {
            return GetByIsSendNotify(isSendNotify, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, TransactionManager tm_)
        {
            return GetByIsSendNotify(isSendNotify, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, TransactionManager tm_)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, int top_)
        {
            return GetByIsSendNotify(isSendNotify, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, int top_)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, int top_, TransactionManager tm_)
        {
            return GetByIsSendNotify(isSendNotify, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, int top_, TransactionManager tm_)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, string sort_)
        {
            return GetByIsSendNotify(isSendNotify, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, string sort_)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, string sort_, TransactionManager tm_)
        {
            return GetByIsSendNotify(isSendNotify, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, string sort_, TransactionManager tm_)
        {
            return await GetByIsSendNotifyAsync(isSendNotify, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsSendNotify（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotify">是否发送弹框通知</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotify(bool isSendNotify, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsSendNotify` = @IsSendNotify", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyAsync(bool isSendNotify, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsSendNotify` = @IsSendNotify", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotify", isSendNotify, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsSendNotify
        #region GetByIsSendNotifyEmail

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, TransactionManager tm_)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, TransactionManager tm_)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, int top_)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, int top_)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, int top_, TransactionManager tm_)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, int top_, TransactionManager tm_)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, string sort_)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, string sort_)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, string sort_, TransactionManager tm_)
        {
            return GetByIsSendNotifyEmail(isSendNotifyEmail, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, string sort_, TransactionManager tm_)
        {
            return await GetByIsSendNotifyEmailAsync(isSendNotifyEmail, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsSendNotifyEmail（字段） 查询
        /// </summary>
        /// /// <param name = "isSendNotifyEmail">是否发送站内邮件溶质</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsSendNotifyEmail(bool isSendNotifyEmail, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsSendNotifyEmail` = @IsSendNotifyEmail", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsSendNotifyEmailAsync(bool isSendNotifyEmail, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsSendNotifyEmail` = @IsSendNotifyEmail", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsSendNotifyEmail", isSendNotifyEmail, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsSendNotifyEmail
        #region GetByIsAllowEnd

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd)
        {
            return GetByIsAllowEnd(isAllowEnd, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, TransactionManager tm_)
        {
            return GetByIsAllowEnd(isAllowEnd, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, TransactionManager tm_)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, int top_)
        {
            return GetByIsAllowEnd(isAllowEnd, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, int top_)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, int top_, TransactionManager tm_)
        {
            return GetByIsAllowEnd(isAllowEnd, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, int top_, TransactionManager tm_)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, string sort_)
        {
            return GetByIsAllowEnd(isAllowEnd, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, string sort_)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, string sort_, TransactionManager tm_)
        {
            return GetByIsAllowEnd(isAllowEnd, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, string sort_, TransactionManager tm_)
        {
            return await GetByIsAllowEndAsync(isAllowEnd, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsAllowEnd（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowEnd">是否允许完成</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowEnd(bool isAllowEnd, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowEnd` = @IsAllowEnd", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowEndAsync(bool isAllowEnd, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowEnd` = @IsAllowEnd", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowEnd", isAllowEnd, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsAllowEnd
        #region GetByIsAllowIndexRecommend

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, TransactionManager tm_)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, TransactionManager tm_)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, int top_)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, int top_)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, int top_, TransactionManager tm_)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, int top_, TransactionManager tm_)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, string sort_)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, string sort_)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, string sort_, TransactionManager tm_)
        {
            return GetByIsAllowIndexRecommend(isAllowIndexRecommend, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, string sort_, TransactionManager tm_)
        {
            return await GetByIsAllowIndexRecommendAsync(isAllowIndexRecommend, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsAllowIndexRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowIndexRecommend">是否允许首页banner位推荐</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowIndexRecommend(bool isAllowIndexRecommend, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowIndexRecommend` = @IsAllowIndexRecommend", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowIndexRecommendAsync(bool isAllowIndexRecommend, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowIndexRecommend` = @IsAllowIndexRecommend", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowIndexRecommend", isAllowIndexRecommend, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsAllowIndexRecommend
        #region GetByIsAllowPayRecommend

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, TransactionManager tm_)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, TransactionManager tm_)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, int top_)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, int top_)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, int top_, TransactionManager tm_)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, int top_, TransactionManager tm_)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, string sort_)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, string sort_)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, string sort_, TransactionManager tm_)
        {
            return GetByIsAllowPayRecommend(isAllowPayRecommend, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, string sort_, TransactionManager tm_)
        {
            return await GetByIsAllowPayRecommendAsync(isAllowPayRecommend, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsAllowPayRecommend（字段） 查询
        /// </summary>
        /// /// <param name = "isAllowPayRecommend">是否为充值页推荐的banner</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsAllowPayRecommend(bool isAllowPayRecommend, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowPayRecommend` = @IsAllowPayRecommend", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsAllowPayRecommendAsync(bool isAllowPayRecommend, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsAllowPayRecommend` = @IsAllowPayRecommend", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsAllowPayRecommend", isAllowPayRecommend, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsAllowPayRecommend
        #region GetByIsBonus

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus)
        {
            return GetByIsBonus(isBonus, 0, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus)
        {
            return await GetByIsBonusAsync(isBonus, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, TransactionManager tm_)
        {
            return GetByIsBonus(isBonus, 0, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, TransactionManager tm_)
        {
            return await GetByIsBonusAsync(isBonus, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, int top_)
        {
            return GetByIsBonus(isBonus, top_, string.Empty, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, int top_)
        {
            return await GetByIsBonusAsync(isBonus, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, int top_, TransactionManager tm_)
        {
            return GetByIsBonus(isBonus, top_, string.Empty, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, int top_, TransactionManager tm_)
        {
            return await GetByIsBonusAsync(isBonus, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, string sort_)
        {
            return GetByIsBonus(isBonus, 0, sort_, null);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, string sort_)
        {
            return await GetByIsBonusAsync(isBonus, 0, sort_, null);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, string sort_, TransactionManager tm_)
        {
            return GetByIsBonus(isBonus, 0, sort_, tm_);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, string sort_, TransactionManager tm_)
        {
            return await GetByIsBonusAsync(isBonus, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 IsBonus（字段） 查询
        /// </summary>
        /// /// <param name = "isBonus">0-真金1-bonus,如果s_operator.EnableBonus=false,则忽视当前值,统一为真金</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_activity_operatorEO> GetByIsBonus(bool isBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsBonus` = @IsBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        public async Task<List<L_activity_operatorEO>> GetByIsBonusAsync(bool isBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`IsBonus` = @IsBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_activity_operatorEO.MapDataReader);
        }
        #endregion // GetByIsBonus
        #endregion // GetByXXX
        #endregion // Get
    }
    #endregion // MO
}
