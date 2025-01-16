/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 18: 05:08
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
    /// 参加返点活动的游戏每日统计
    /// 【表 sa_rebate_day 的实体类】
    /// </summary>
    [DataContract]
    [Obsolete]
    public class Sa_rebate_dayEO : IRowMapper<Sa_rebate_dayEO>
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public Sa_rebate_dayEO()
        {
            FromMode = 0;
            TotalBetAmount = 0;
            TotalBetBonus = 0;
            TotalWinAmount = 0;
            TotalWinBonus = 0;
            RecDate = DateTime.Now;
        }
        #region 主键原始值 & 主键集合

        /// <summary>
        /// 当前对象是否保存原始主键值，当修改了主键值时为 true
        /// </summary>
        public bool HasOriginal { get; protected set; }

        private DateTime _originalDayID;
        /// <summary>
        /// 【数据库中的原始主键 DayID 值的副本，用于主键值更新】
        /// </summary>
        public DateTime OriginalDayID
        {
            get { return _originalDayID; }
            set { HasOriginal = true; _originalDayID = value; }
        }

        private string _originalUserID;
        /// <summary>
        /// 【数据库中的原始主键 UserID 值的副本，用于主键值更新】
        /// </summary>
        public string OriginalUserID
        {
            get { return _originalUserID; }
            set { HasOriginal = true; _originalUserID = value; }
        }

        private int _originalActivityID;
        /// <summary>
        /// 【数据库中的原始主键 ActivityID 值的副本，用于主键值更新】
        /// </summary>
        public int OriginalActivityID
        {
            get { return _originalActivityID; }
            set { HasOriginal = true; _originalActivityID = value; }
        }
        /// <summary>
        /// 获取主键集合。key: 数据库字段名称, value: 主键值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetPrimaryKeys()
        {
            return new Dictionary<string, object>() { { "DayID", DayID }, { "UserID", UserID }, { "ActivityID", ActivityID }, };
        }
        /// <summary>
        /// 获取主键集合JSON格式
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
        #endregion // 主键原始值
        #region 所有字段
        /// <summary>
        /// 统计日
        /// 【主键 date】
        /// </summary>
        [DataMember(Order = 1)]
        public DateTime DayID { get; set; }
        /// <summary>
        /// 用户编码(GUID)
        /// 【主键 varchar(38)】
        /// </summary>
        [DataMember(Order = 2)]
        public string UserID { get; set; }
        /// <summary>
        /// 活动id
        /// 【主键 int】
        /// </summary>
        [DataMember(Order = 3)]
        public int ActivityID { get; set; }
        /// <summary>
        /// 运营商编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 4)]
        public string OperatorID { get; set; }
        /// <summary>
        /// 货币类型
        /// 【字段 varchar(5)】
        /// </summary>
        [DataMember(Order = 5)]
        public string CurrencyID { get; set; }
        /// <summary>
        /// 新用户来源方式
        ///                           0-获得运营商的新用户(s_operator)
        ///                           1-推广员获得的新用户（userid）
        ///                           2-推广渠道通过url获得的新用户（s_channel_url)
        ///                           3-推广渠道通过code获得的新用户（s_channel_code)
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 6)]
        public int FromMode { get; set; }
        /// <summary>
        /// 对应的编码（根据FromMode变化）
        ///                           FromMode=
        ///                           0-运营商的新用户(s_operator)==> OperatorID
        ///                           1-推广员获得的新用户（userid） ==> 邀请人的UserID
        ///                           2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
        ///                           3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
        /// 【字段 varchar(100)】
        /// </summary>
        [DataMember(Order = 7)]
        public string FromId { get; set; }
        /// <summary>
        /// 用户类型
        ///                           0-未知
        ///                           1-普通用户
        ///                           2-开发用户
        ///                           3-线上测试用户（调用第三方扣减）
        ///                           4-线上测试用户（不调用第三方扣减）
        ///                           5-仿真用户
        ///                           6-接口联调用户
        ///                           9-管理员
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 8)]
        public int UserKind { get; set; }
        /// <summary>
        /// 国家编码ISO 3166-1三位字母
        /// 【字段 varchar(5)】
        /// </summary>
        [DataMember(Order = 9)]
        public string CountryID { get; set; }
        /// <summary>
        /// 下注总额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 10)]
        public long TotalBetAmount { get; set; }
        /// <summary>
        /// 下注时扣除的bonus总额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 11)]
        public long TotalBetBonus { get; set; }
        /// <summary>
        /// 有效下注金额，根据配置给返奖的金额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 12)]
        public long EffectiveBetAmount { get; set; }
        /// <summary>
        /// 返奖总额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 13)]
        public long TotalWinAmount { get; set; }
        /// <summary>
        /// 返奖时增加的bonus总额
        /// 【字段 bigint】
        /// </summary>
        [DataMember(Order = 14)]
        public long TotalWinBonus { get; set; }
        /// <summary>
        /// 记录时间
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 15)]
        public DateTime RecDate { get; set; }
        /// <summary>
        /// 修改时间
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 16)]
        public DateTime? UpdateTime { get; set; }
        #endregion // 所有列
        #region 实体映射

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public Sa_rebate_dayEO MapRow(IDataReader reader)
        {
            return MapDataReader(reader);
        }

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public static Sa_rebate_dayEO MapDataReader(IDataReader reader)
        {
            Sa_rebate_dayEO ret = new Sa_rebate_dayEO();
            ret.DayID = reader.ToDateTime("DayID");
            ret.OriginalDayID = ret.DayID;
            ret.UserID = reader.ToString("UserID");
            ret.OriginalUserID = ret.UserID;
            ret.ActivityID = reader.ToInt32("ActivityID");
            ret.OriginalActivityID = ret.ActivityID;
            ret.OperatorID = reader.ToString("OperatorID");
            ret.CurrencyID = reader.ToString("CurrencyID");
            ret.FromMode = reader.ToInt32("FromMode");
            ret.FromId = reader.ToString("FromId");
            ret.UserKind = reader.ToInt32("UserKind");
            ret.CountryID = reader.ToString("CountryID");
            ret.TotalBetAmount = reader.ToInt64("TotalBetAmount");
            ret.TotalBetBonus = reader.ToInt64("TotalBetBonus");
            ret.EffectiveBetAmount = reader.ToInt64("EffectiveBetAmount");
            ret.TotalWinAmount = reader.ToInt64("TotalWinAmount");
            ret.TotalWinBonus = reader.ToInt64("TotalWinBonus");
            ret.RecDate = reader.ToDateTime("RecDate");
            ret.UpdateTime = reader.ToDateTimeN("UpdateTime");
            return ret;
        }

        #endregion
    }
    #endregion // EO

    #region MO
    /// <summary>
    /// 参加返点活动的游戏每日统计
    /// 【表 sa_rebate_day 的操作类】
    /// </summary>
    [Obsolete]
    public class Sa_rebate_dayMO : MySqlTableMO<Sa_rebate_dayEO>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName { get; set; } = "`sa_rebate_day`";

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "database">数据来源</param>
        public Sa_rebate_dayMO(MySqlDatabase database) : base(database) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
        public Sa_rebate_dayMO(string connectionStringName = null) : base(connectionStringName) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">CommandTimeout时间</param>
        public Sa_rebate_dayMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
        #endregion // Constructors

        #region  Add
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name = "item">要插入的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="useIgnore_">是否使用INSERT IGNORE</param>
        /// <return>受影响的行数</return>
        public override int Add(Sa_rebate_dayEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public override async Task<int> AddAsync(Sa_rebate_dayEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairAddData(Sa_rebate_dayEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
            sql_ += $" INTO {TableName} (`DayID`, `UserID`, `ActivityID`, `OperatorID`, `CurrencyID`, `FromMode`, `FromId`, `UserKind`, `CountryID`, `TotalBetAmount`, `TotalBetBonus`, `EffectiveBetAmount`, `TotalWinAmount`, `TotalWinBonus`, `RecDate`, `UpdateTime`) VALUE (@DayID, @UserID, @ActivityID, @OperatorID, @CurrencyID, @FromMode, @FromId, @UserKind, @CountryID, @TotalBetAmount, @TotalBetBonus, @EffectiveBetAmount, @TotalWinAmount, @TotalWinBonus, @RecDate, @UpdateTime);";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", item.DayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
                Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@TotalBetAmount", item.TotalBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalBetBonus", item.TotalBetBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@EffectiveBetAmount", item.EffectiveBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalWinAmount", item.TotalWinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalWinBonus", item.TotalWinBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@UpdateTime", item.UpdateTime.HasValue ? item.UpdateTime.Value : DBNull.Value, MySqlDbType.DateTime),
            };
        }
        public int AddByBatch(IEnumerable<Sa_rebate_dayEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += Database.ExecSqlNonQuery(sql, tm_);
            }
            return ret;
        }
        public async Task<int> AddByBatchAsync(IEnumerable<Sa_rebate_dayEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
            }
            return ret;
        }
        private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_rebate_dayEO> items, int batchCount)
        {
            var count = 0;
            var insertSql = $"INSERT INTO {TableName} (`DayID`, `UserID`, `ActivityID`, `OperatorID`, `CurrencyID`, `FromMode`, `FromId`, `UserKind`, `CountryID`, `TotalBetAmount`, `TotalBetBonus`, `EffectiveBetAmount`, `TotalWinAmount`, `TotalWinBonus`, `RecDate`, `UpdateTime`) VALUES ";
            var sql = new StringBuilder();
            foreach (var item in items)
            {
                count++;
                sql.Append($"('{item.DayID.ToString("yyyy-MM-dd HH:mm:ss")}','{item.UserID}',{item.ActivityID},'{item.OperatorID}','{item.CurrencyID}',{item.FromMode},'{item.FromId}',{item.UserKind},'{item.CountryID}',{item.TotalBetAmount},{item.TotalBetBonus},{item.EffectiveBetAmount},{item.TotalWinAmount},{item.TotalWinBonus},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}','{item.UpdateTime?.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepiarRemoveByPKData(DateTime dayID, string userID, int activityID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }
        /// <summary>
        /// 删除指定实体对应的记录
        /// </summary>
        /// <param name = "item">要删除的实体</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Remove(Sa_rebate_dayEO item, TransactionManager tm_ = null)
        {
            return RemoveByPK(item.DayID, item.UserID, item.ActivityID, tm_);
        }
        public async Task<int> RemoveAsync(Sa_rebate_dayEO item, TransactionManager tm_ = null)
        {
            return await RemoveByPKAsync(item.DayID, item.UserID, item.ActivityID, tm_);
        }
        #endregion // RemoveByPK

        #region RemoveByXXX
        #region RemoveByDayID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByDayID(DateTime dayID, TransactionManager tm_ = null)
        {
            RepairRemoveByDayIDData(dayID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByDayIDAsync(DateTime dayID, TransactionManager tm_ = null)
        {
            RepairRemoveByDayIDData(dayID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByDayIDData(DateTime dayID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `DayID` = @DayID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date));
        }
        #endregion // RemoveByDayID
        #region RemoveByUserID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByUserID(string userID, TransactionManager tm_ = null)
        {
            RepairRemoveByUserIDData(userID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByUserIDAsync(string userID, TransactionManager tm_ = null)
        {
            RepairRemoveByUserIDData(userID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByUserIDData(string userID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `UserID` = @UserID";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
        }
        #endregion // RemoveByUserID
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
        #region RemoveByFromMode
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByFromMode(int fromMode, TransactionManager tm_ = null)
        {
            RepairRemoveByFromModeData(fromMode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByFromModeAsync(int fromMode, TransactionManager tm_ = null)
        {
            RepairRemoveByFromModeData(fromMode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByFromModeData(int fromMode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `FromMode` = @FromMode";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
        }
        #endregion // RemoveByFromMode
        #region RemoveByFromId
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByFromId(string fromId, TransactionManager tm_ = null)
        {
            RepairRemoveByFromIdData(fromId, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByFromIdAsync(string fromId, TransactionManager tm_ = null)
        {
            RepairRemoveByFromIdData(fromId, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByFromIdData(string fromId, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (fromId != null)
                paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
        }
        #endregion // RemoveByFromId
        #region RemoveByUserKind
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByUserKind(int userKind, TransactionManager tm_ = null)
        {
            RepairRemoveByUserKindData(userKind, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByUserKindAsync(int userKind, TransactionManager tm_ = null)
        {
            RepairRemoveByUserKindData(userKind, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByUserKindData(int userKind, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `UserKind` = @UserKind";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
        }
        #endregion // RemoveByUserKind
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
            sql_ = $"DELETE FROM {TableName} WHERE " + (countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (countryID != null)
                paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
        }
        #endregion // RemoveByCountryID
        #region RemoveByTotalBetAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByTotalBetAmount(long totalBetAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalBetAmountData(totalBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByTotalBetAmountAsync(long totalBetAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalBetAmountData(totalBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByTotalBetAmountData(long totalBetAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `TotalBetAmount` = @TotalBetAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByTotalBetAmount
        #region RemoveByTotalBetBonus
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByTotalBetBonus(long totalBetBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalBetBonusData(totalBetBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByTotalBetBonusAsync(long totalBetBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalBetBonusData(totalBetBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByTotalBetBonusData(long totalBetBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `TotalBetBonus` = @TotalBetBonus";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64));
        }
        #endregion // RemoveByTotalBetBonus
        #region RemoveByEffectiveBetAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByEffectiveBetAmount(long effectiveBetAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByEffectiveBetAmountData(effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByEffectiveBetAmountAsync(long effectiveBetAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByEffectiveBetAmountData(effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByEffectiveBetAmountData(long effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `EffectiveBetAmount` = @EffectiveBetAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByEffectiveBetAmount
        #region RemoveByTotalWinAmount
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByTotalWinAmount(long totalWinAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalWinAmountData(totalWinAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByTotalWinAmountAsync(long totalWinAmount, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalWinAmountData(totalWinAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByTotalWinAmountData(long totalWinAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `TotalWinAmount` = @TotalWinAmount";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64));
        }
        #endregion // RemoveByTotalWinAmount
        #region RemoveByTotalWinBonus
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByTotalWinBonus(long totalWinBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalWinBonusData(totalWinBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByTotalWinBonusAsync(long totalWinBonus, TransactionManager tm_ = null)
        {
            RepairRemoveByTotalWinBonusData(totalWinBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByTotalWinBonusData(long totalWinBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `TotalWinBonus` = @TotalWinBonus";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64));
        }
        #endregion // RemoveByTotalWinBonus
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
        #region RemoveByUpdateTime
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByUpdateTime(DateTime? updateTime, TransactionManager tm_ = null)
        {
            RepairRemoveByUpdateTimeData(updateTime.Value, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByUpdateTimeAsync(DateTime? updateTime, TransactionManager tm_ = null)
        {
            RepairRemoveByUpdateTimeData(updateTime.Value, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByUpdateTimeData(DateTime? updateTime, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (updateTime.HasValue ? "`UpdateTime` = @UpdateTime" : "`UpdateTime` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (updateTime.HasValue)
                paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime.Value, MySqlDbType.DateTime));
        }
        #endregion // RemoveByUpdateTime
        #endregion // RemoveByXXX

        #region RemoveByFKOrUnique
        #region RemoveByDayIDAndUserIDAndActivityID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByDayIDAndUserIDAndActivityID(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepiarRemoveByDayIDAndUserIDAndActivityIDData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByDayIDAndUserIDAndActivityIDAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepiarRemoveByDayIDAndUserIDAndActivityIDData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepiarRemoveByDayIDAndUserIDAndActivityIDData(DateTime dayID, string userID, int activityID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }
        #endregion // RemoveByDayIDAndUserIDAndActivityID
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
        public int Put(Sa_rebate_dayEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAsync(Sa_rebate_dayEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutData(Sa_rebate_dayEO item, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `DayID` = @DayID, `UserID` = @UserID, `ActivityID` = @ActivityID, `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID, `FromMode` = @FromMode, `FromId` = @FromId, `UserKind` = @UserKind, `CountryID` = @CountryID, `TotalBetAmount` = @TotalBetAmount, `TotalBetBonus` = @TotalBetBonus, `EffectiveBetAmount` = @EffectiveBetAmount, `TotalWinAmount` = @TotalWinAmount, `TotalWinBonus` = @TotalWinBonus, `UpdateTime` = @UpdateTime WHERE `DayID` = @DayID_Original AND `UserID` = @UserID_Original AND `ActivityID` = @ActivityID_Original";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", item.DayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", item.ActivityID, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
                Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
                Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@TotalBetAmount", item.TotalBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalBetBonus", item.TotalBetBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@EffectiveBetAmount", item.EffectiveBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalWinAmount", item.TotalWinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@TotalWinBonus", item.TotalWinBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@UpdateTime", item.UpdateTime.HasValue ? item.UpdateTime.Value : DBNull.Value, MySqlDbType.DateTime),
                Database.CreateInParameter("@DayID_Original", item.HasOriginal ? item.OriginalDayID : item.DayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID_Original", item.HasOriginal ? item.OriginalActivityID : item.ActivityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新实体集合到数据库
        /// </summary>
        /// <param name = "items">要更新的实体对象集合</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Put(IEnumerable<Sa_rebate_dayEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += Put(item, tm_);
            }
            return ret;
        }
        public async Task<int> PutAsync(IEnumerable<Sa_rebate_dayEO> items, TransactionManager tm_ = null)
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
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(DateTime dayID, string userID, int activityID, string set_, params object[] values_)
        {
            return Put(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", ConcatValues(values_, dayID, userID, activityID));
        }
        public async Task<int> PutByPKAsync(DateTime dayID, string userID, int activityID, string set_, params object[] values_)
        {
            return await PutAsync(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", ConcatValues(values_, dayID, userID, activityID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(DateTime dayID, string userID, int activityID, string set_, TransactionManager tm_, params object[] values_)
        {
            return Put(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", tm_, ConcatValues(values_, dayID, userID, activityID));
        }
        public async Task<int> PutByPKAsync(DateTime dayID, string userID, int activityID, string set_, TransactionManager tm_, params object[] values_)
        {
            return await PutAsync(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", tm_, ConcatValues(values_, dayID, userID, activityID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="paras_">参数值</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutByPK(DateTime dayID, string userID, int activityID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return Put(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", ConcatParameters(paras_, newParas_), tm_);
        }
        public async Task<int> PutByPKAsync(DateTime dayID, string userID, int activityID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return await PutAsync(set_, "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", ConcatParameters(paras_, newParas_), tm_);
        }
        #endregion // PutByPK

        #region PutXXX
        #region PutDayID

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutDayID(DateTime dayID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `DayID` = @DayID";
            var parameter_ = Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutDayIDAsync(DateTime dayID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `DayID` = @DayID";
            var parameter_ = Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutDayID
        #region PutUserID

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUserID(string userID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UserID` = @UserID";
            var parameter_ = Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutUserIDAsync(string userID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UserID` = @UserID";
            var parameter_ = Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutUserID
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
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOperatorIDByPK(DateTime dayID, string userID, int activityID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(dayID, userID, activityID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutOperatorIDByPKAsync(DateTime dayID, string userID, int activityID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(dayID, userID, activityID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutOperatorIDByPKData(DateTime dayID, string userID, int activityID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
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
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCurrencyIDByPK(DateTime dayID, string userID, int activityID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(dayID, userID, activityID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCurrencyIDByPKAsync(DateTime dayID, string userID, int activityID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(dayID, userID, activityID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCurrencyIDByPKData(DateTime dayID, string userID, int activityID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
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
        #region PutFromMode
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFromModeByPK(DateTime dayID, string userID, int activityID, int fromMode, TransactionManager tm_ = null)
        {
            RepairPutFromModeByPKData(dayID, userID, activityID, fromMode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutFromModeByPKAsync(DateTime dayID, string userID, int activityID, int fromMode, TransactionManager tm_ = null)
        {
            RepairPutFromModeByPKData(dayID, userID, activityID, fromMode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutFromModeByPKData(DateTime dayID, string userID, int activityID, int fromMode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFromMode(int fromMode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode";
            var parameter_ = Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutFromModeAsync(int fromMode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode";
            var parameter_ = Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutFromMode
        #region PutFromId
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFromIdByPK(DateTime dayID, string userID, int activityID, string fromId, TransactionManager tm_ = null)
        {
            RepairPutFromIdByPKData(dayID, userID, activityID, fromId, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutFromIdByPKAsync(DateTime dayID, string userID, int activityID, string fromId, TransactionManager tm_ = null)
        {
            RepairPutFromIdByPKData(dayID, userID, activityID, fromId, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutFromIdByPKData(DateTime dayID, string userID, int activityID, string fromId, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `FromId` = @FromId  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@FromId", fromId != null ? fromId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutFromId(string fromId, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FromId` = @FromId";
            var parameter_ = Database.CreateInParameter("@FromId", fromId != null ? fromId : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutFromIdAsync(string fromId, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `FromId` = @FromId";
            var parameter_ = Database.CreateInParameter("@FromId", fromId != null ? fromId : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutFromId
        #region PutUserKind
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUserKindByPK(DateTime dayID, string userID, int activityID, int userKind, TransactionManager tm_ = null)
        {
            RepairPutUserKindByPKData(dayID, userID, activityID, userKind, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutUserKindByPKAsync(DateTime dayID, string userID, int activityID, int userKind, TransactionManager tm_ = null)
        {
            RepairPutUserKindByPKData(dayID, userID, activityID, userKind, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutUserKindByPKData(DateTime dayID, string userID, int activityID, int userKind, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUserKind(int userKind, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind";
            var parameter_ = Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutUserKindAsync(int userKind, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind";
            var parameter_ = Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutUserKind
        #region PutCountryID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCountryIDByPK(DateTime dayID, string userID, int activityID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(dayID, userID, activityID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCountryIDByPKAsync(DateTime dayID, string userID, int activityID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(dayID, userID, activityID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCountryIDByPKData(DateTime dayID, string userID, int activityID, string countryID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CountryID", countryID != null ? countryID : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
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
            var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
            var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutCountryID
        #region PutTotalBetAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalBetAmountByPK(DateTime dayID, string userID, int activityID, long totalBetAmount, TransactionManager tm_ = null)
        {
            RepairPutTotalBetAmountByPKData(dayID, userID, activityID, totalBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutTotalBetAmountByPKAsync(DateTime dayID, string userID, int activityID, long totalBetAmount, TransactionManager tm_ = null)
        {
            RepairPutTotalBetAmountByPKData(dayID, userID, activityID, totalBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutTotalBetAmountByPKData(DateTime dayID, string userID, int activityID, long totalBetAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `TotalBetAmount` = @TotalBetAmount  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalBetAmount(long totalBetAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalBetAmount` = @TotalBetAmount";
            var parameter_ = Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutTotalBetAmountAsync(long totalBetAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalBetAmount` = @TotalBetAmount";
            var parameter_ = Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutTotalBetAmount
        #region PutTotalBetBonus
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalBetBonusByPK(DateTime dayID, string userID, int activityID, long totalBetBonus, TransactionManager tm_ = null)
        {
            RepairPutTotalBetBonusByPKData(dayID, userID, activityID, totalBetBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutTotalBetBonusByPKAsync(DateTime dayID, string userID, int activityID, long totalBetBonus, TransactionManager tm_ = null)
        {
            RepairPutTotalBetBonusByPKData(dayID, userID, activityID, totalBetBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutTotalBetBonusByPKData(DateTime dayID, string userID, int activityID, long totalBetBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `TotalBetBonus` = @TotalBetBonus  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalBetBonus(long totalBetBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalBetBonus` = @TotalBetBonus";
            var parameter_ = Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutTotalBetBonusAsync(long totalBetBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalBetBonus` = @TotalBetBonus";
            var parameter_ = Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutTotalBetBonus
        #region PutEffectiveBetAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutEffectiveBetAmountByPK(DateTime dayID, string userID, int activityID, long effectiveBetAmount, TransactionManager tm_ = null)
        {
            RepairPutEffectiveBetAmountByPKData(dayID, userID, activityID, effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutEffectiveBetAmountByPKAsync(DateTime dayID, string userID, int activityID, long effectiveBetAmount, TransactionManager tm_ = null)
        {
            RepairPutEffectiveBetAmountByPKData(dayID, userID, activityID, effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutEffectiveBetAmountByPKData(DateTime dayID, string userID, int activityID, long effectiveBetAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `EffectiveBetAmount` = @EffectiveBetAmount  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutEffectiveBetAmount(long effectiveBetAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `EffectiveBetAmount` = @EffectiveBetAmount";
            var parameter_ = Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutEffectiveBetAmountAsync(long effectiveBetAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `EffectiveBetAmount` = @EffectiveBetAmount";
            var parameter_ = Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutEffectiveBetAmount
        #region PutTotalWinAmount
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalWinAmountByPK(DateTime dayID, string userID, int activityID, long totalWinAmount, TransactionManager tm_ = null)
        {
            RepairPutTotalWinAmountByPKData(dayID, userID, activityID, totalWinAmount, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutTotalWinAmountByPKAsync(DateTime dayID, string userID, int activityID, long totalWinAmount, TransactionManager tm_ = null)
        {
            RepairPutTotalWinAmountByPKData(dayID, userID, activityID, totalWinAmount, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutTotalWinAmountByPKData(DateTime dayID, string userID, int activityID, long totalWinAmount, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `TotalWinAmount` = @TotalWinAmount  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalWinAmount(long totalWinAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalWinAmount` = @TotalWinAmount";
            var parameter_ = Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutTotalWinAmountAsync(long totalWinAmount, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalWinAmount` = @TotalWinAmount";
            var parameter_ = Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutTotalWinAmount
        #region PutTotalWinBonus
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalWinBonusByPK(DateTime dayID, string userID, int activityID, long totalWinBonus, TransactionManager tm_ = null)
        {
            RepairPutTotalWinBonusByPKData(dayID, userID, activityID, totalWinBonus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutTotalWinBonusByPKAsync(DateTime dayID, string userID, int activityID, long totalWinBonus, TransactionManager tm_ = null)
        {
            RepairPutTotalWinBonusByPKData(dayID, userID, activityID, totalWinBonus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutTotalWinBonusByPKData(DateTime dayID, string userID, int activityID, long totalWinBonus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `TotalWinBonus` = @TotalWinBonus  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTotalWinBonus(long totalWinBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalWinBonus` = @TotalWinBonus";
            var parameter_ = Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutTotalWinBonusAsync(long totalWinBonus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TotalWinBonus` = @TotalWinBonus";
            var parameter_ = Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutTotalWinBonus
        #region PutRecDate
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRecDateByPK(DateTime dayID, string userID, int activityID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(dayID, userID, activityID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutRecDateByPKAsync(DateTime dayID, string userID, int activityID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(dayID, userID, activityID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutRecDateByPKData(DateTime dayID, string userID, int activityID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
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
        #region PutUpdateTime
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUpdateTimeByPK(DateTime dayID, string userID, int activityID, DateTime? updateTime, TransactionManager tm_ = null)
        {
            RepairPutUpdateTimeByPKData(dayID, userID, activityID, updateTime, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutUpdateTimeByPKAsync(DateTime dayID, string userID, int activityID, DateTime? updateTime, TransactionManager tm_ = null)
        {
            RepairPutUpdateTimeByPKData(dayID, userID, activityID, updateTime, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutUpdateTimeByPKData(DateTime dayID, string userID, int activityID, DateTime? updateTime, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime  WHERE `DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UpdateTime", updateTime.HasValue ? updateTime.Value : DBNull.Value, MySqlDbType.DateTime),
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUpdateTime(DateTime? updateTime, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime";
            var parameter_ = Database.CreateInParameter("@UpdateTime", updateTime.HasValue ? updateTime.Value : DBNull.Value, MySqlDbType.DateTime);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutUpdateTimeAsync(DateTime? updateTime, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime";
            var parameter_ = Database.CreateInParameter("@UpdateTime", updateTime.HasValue ? updateTime.Value : DBNull.Value, MySqlDbType.DateTime);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutUpdateTime
        #endregion // PutXXX
        #endregion // Put

        #region Set

        /// <summary>
        /// 插入或者更新数据
        /// </summary>
        /// <param name = "item">要更新的实体对象</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>true:插入操作；false:更新操作</return>
        public bool Set(Sa_rebate_dayEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.DayID, item.UserID, item.ActivityID) == null)
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
        public async Task<bool> SetAsync(Sa_rebate_dayEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.DayID, item.UserID, item.ActivityID) == null)
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
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
        /// <return></return>
        public Sa_rebate_dayEO GetByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<Sa_rebate_dayEO> GetByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        private void RepairGetByPKData(DateTime dayID, string userID, int activityID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
        {
            sql_ = BuildSelectSQL("`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", 0, null, null, isForUpdate_);
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }
        #endregion // GetByPK

        #region GetByUnique
        /// <summary>
        /// 按【唯一索引】查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        public Sa_rebate_dayEO GetByDayIDAndUserIDAndActivityID(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepairGetByDayIDAndUserIDAndActivityIDData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<Sa_rebate_dayEO> GetByDayIDAndUserIDAndActivityIDAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            RepairGetByDayIDAndUserIDAndActivityIDData(dayID, userID, activityID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        private void RepairGetByDayIDAndUserIDAndActivityIDData(DateTime dayID, string userID, int activityID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = BuildSelectSQL("`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", 0, null);
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
        }
        #endregion // GetByUnique
        #region GetXXXByPK

        /// <summary>
        /// 按主键查询 DayID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetDayIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime)GetScalar("`DayID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<DateTime> GetDayIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime)await GetScalarAsync("`DayID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 UserID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetUserIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`UserID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<string> GetUserIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`UserID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 ActivityID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetActivityIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`ActivityID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<int> GetActivityIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`ActivityID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 OperatorID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetOperatorIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`OperatorID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<string> GetOperatorIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`OperatorID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CurrencyID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCurrencyIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`CurrencyID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<string> GetCurrencyIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`CurrencyID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 FromMode（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetFromModeByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`FromMode`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<int> GetFromModeByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`FromMode`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 FromId（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetFromIdByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`FromId`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<string> GetFromIdByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`FromId`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 UserKind（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetUserKindByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)GetScalar("`UserKind`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<int> GetUserKindByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (int)await GetScalarAsync("`UserKind`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CountryID（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCountryIDByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)GetScalar("`CountryID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<string> GetCountryIDByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (string)await GetScalarAsync("`CountryID`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 TotalBetAmount（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetTotalBetAmountByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`TotalBetAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<long> GetTotalBetAmountByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`TotalBetAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 TotalBetBonus（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetTotalBetBonusByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`TotalBetBonus`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<long> GetTotalBetBonusByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`TotalBetBonus`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 EffectiveBetAmount（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetEffectiveBetAmountByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`EffectiveBetAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<long> GetEffectiveBetAmountByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`EffectiveBetAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 TotalWinAmount（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetTotalWinAmountByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`TotalWinAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<long> GetTotalWinAmountByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`TotalWinAmount`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 TotalWinBonus（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public long GetTotalWinBonusByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)GetScalar("`TotalWinBonus`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<long> GetTotalWinBonusByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (long)await GetScalarAsync("`TotalWinBonus`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 RecDate（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetRecDateByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime)GetScalar("`RecDate`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<DateTime> GetRecDateByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime)await GetScalarAsync("`RecDate`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 UpdateTime（字段）
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime? GetUpdateTimeByPK(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime?)GetScalar("`UpdateTime`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        public async Task<DateTime?> GetUpdateTimeByPKAsync(DateTime dayID, string userID, int activityID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date),
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32),
            };
            return (DateTime?)await GetScalarAsync("`UpdateTime`", "`DayID` = @DayID AND `UserID` = @UserID AND `ActivityID` = @ActivityID", paras_, tm_);
        }
        #endregion // GetXXXByPK
        #region GetByXXX
        #region GetByDayID

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID)
        {
            return GetByDayID(dayID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID)
        {
            return await GetByDayIDAsync(dayID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, TransactionManager tm_)
        {
            return GetByDayID(dayID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, TransactionManager tm_)
        {
            return await GetByDayIDAsync(dayID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, int top_)
        {
            return GetByDayID(dayID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, int top_)
        {
            return await GetByDayIDAsync(dayID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, int top_, TransactionManager tm_)
        {
            return GetByDayID(dayID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, int top_, TransactionManager tm_)
        {
            return await GetByDayIDAsync(dayID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, string sort_)
        {
            return GetByDayID(dayID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, string sort_)
        {
            return await GetByDayIDAsync(dayID, 0, sort_, null);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, string sort_, TransactionManager tm_)
        {
            return GetByDayID(dayID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, string sort_, TransactionManager tm_)
        {
            return await GetByDayIDAsync(dayID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 DayID（字段） 查询
        /// </summary>
        /// /// <param name = "dayID">统计日</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByDayID(DateTime dayID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`DayID` = @DayID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByDayIDAsync(DateTime dayID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`DayID` = @DayID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@DayID", dayID, MySqlDbType.Date));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByDayID
        #region GetByUserID

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID)
        {
            return GetByUserID(userID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID)
        {
            return await GetByUserIDAsync(userID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, TransactionManager tm_)
        {
            return GetByUserID(userID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, int top_)
        {
            return GetByUserID(userID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, int top_)
        {
            return await GetByUserIDAsync(userID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, int top_, TransactionManager tm_)
        {
            return GetByUserID(userID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, string sort_)
        {
            return GetByUserID(userID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, string sort_)
        {
            return await GetByUserIDAsync(userID, 0, sort_, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
        {
            return GetByUserID(userID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码(GUID)</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByUserID
        #region GetByActivityID

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID)
        {
            return GetByActivityID(activityID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, int top_)
        {
            return GetByActivityID(activityID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, int top_)
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
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, int top_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, int top_, TransactionManager tm_)
        {
            return await GetByActivityIDAsync(activityID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 ActivityID（字段） 查询
        /// </summary>
        /// /// <param name = "activityID">活动id</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, string sort_)
        {
            return GetByActivityID(activityID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, string sort_)
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
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, string sort_, TransactionManager tm_)
        {
            return GetByActivityID(activityID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_dayEO> GetByActivityID(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByActivityIDAsync(int activityID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`ActivityID` = @ActivityID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@ActivityID", activityID, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByActivityID
        #region GetByOperatorID

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, int top_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, string sort_)
        {
            return GetByOperatorID(operatorID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_dayEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByOperatorID
        #region GetByCurrencyID

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, int top_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, string sort_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_dayEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByCurrencyID
        #region GetByFromMode

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode)
        {
            return GetByFromMode(fromMode, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode)
        {
            return await GetByFromModeAsync(fromMode, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, TransactionManager tm_)
        {
            return GetByFromMode(fromMode, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, TransactionManager tm_)
        {
            return await GetByFromModeAsync(fromMode, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, int top_)
        {
            return GetByFromMode(fromMode, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, int top_)
        {
            return await GetByFromModeAsync(fromMode, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, int top_, TransactionManager tm_)
        {
            return GetByFromMode(fromMode, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, int top_, TransactionManager tm_)
        {
            return await GetByFromModeAsync(fromMode, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, string sort_)
        {
            return GetByFromMode(fromMode, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, string sort_)
        {
            return await GetByFromModeAsync(fromMode, 0, sort_, null);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, string sort_, TransactionManager tm_)
        {
            return GetByFromMode(fromMode, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, string sort_, TransactionManager tm_)
        {
            return await GetByFromModeAsync(fromMode, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 FromMode（字段） 查询
        /// </summary>
        /// /// <param name = "fromMode">新用户来源方式</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromMode(int fromMode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromModeAsync(int fromMode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByFromMode
        #region GetByFromId

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId)
        {
            return GetByFromId(fromId, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId)
        {
            return await GetByFromIdAsync(fromId, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, TransactionManager tm_)
        {
            return GetByFromId(fromId, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, TransactionManager tm_)
        {
            return await GetByFromIdAsync(fromId, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, int top_)
        {
            return GetByFromId(fromId, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, int top_)
        {
            return await GetByFromIdAsync(fromId, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, int top_, TransactionManager tm_)
        {
            return GetByFromId(fromId, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, int top_, TransactionManager tm_)
        {
            return await GetByFromIdAsync(fromId, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, string sort_)
        {
            return GetByFromId(fromId, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, string sort_)
        {
            return await GetByFromIdAsync(fromId, 0, sort_, null);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, string sort_, TransactionManager tm_)
        {
            return GetByFromId(fromId, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, string sort_, TransactionManager tm_)
        {
            return await GetByFromIdAsync(fromId, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 FromId（字段） 查询
        /// </summary>
        /// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByFromId(string fromId, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (fromId != null)
                paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByFromIdAsync(string fromId, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (fromId != null)
                paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByFromId
        #region GetByUserKind

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind)
        {
            return GetByUserKind(userKind, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind)
        {
            return await GetByUserKindAsync(userKind, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, TransactionManager tm_)
        {
            return GetByUserKind(userKind, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
        {
            return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, int top_)
        {
            return GetByUserKind(userKind, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, int top_)
        {
            return await GetByUserKindAsync(userKind, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
        {
            return GetByUserKind(userKind, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
        {
            return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, string sort_)
        {
            return GetByUserKind(userKind, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, string sort_)
        {
            return await GetByUserKindAsync(userKind, 0, sort_, null);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
        {
            return GetByUserKind(userKind, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
        {
            return await GetByUserKindAsync(userKind, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByUserKind
        #region GetByCountryID

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID)
        {
            return GetByCountryID(countryID, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, int top_)
        {
            return GetByCountryID(countryID, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, int top_)
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
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, string sort_)
        {
            return GetByCountryID(countryID, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, string sort_)
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
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_dayEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (countryID != null)
                paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (countryID != null)
                paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByCountryID
        #region GetByTotalBetAmount

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount)
        {
            return GetByTotalBetAmount(totalBetAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, TransactionManager tm_)
        {
            return GetByTotalBetAmount(totalBetAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, TransactionManager tm_)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, int top_)
        {
            return GetByTotalBetAmount(totalBetAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, int top_)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, int top_, TransactionManager tm_)
        {
            return GetByTotalBetAmount(totalBetAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, int top_, TransactionManager tm_)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, string sort_)
        {
            return GetByTotalBetAmount(totalBetAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, string sort_)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, string sort_, TransactionManager tm_)
        {
            return GetByTotalBetAmount(totalBetAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, string sort_, TransactionManager tm_)
        {
            return await GetByTotalBetAmountAsync(totalBetAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 TotalBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetAmount">下注总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetAmount(long totalBetAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalBetAmount` = @TotalBetAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetAmountAsync(long totalBetAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalBetAmount` = @TotalBetAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetAmount", totalBetAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByTotalBetAmount
        #region GetByTotalBetBonus

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus)
        {
            return GetByTotalBetBonus(totalBetBonus, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, TransactionManager tm_)
        {
            return GetByTotalBetBonus(totalBetBonus, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, TransactionManager tm_)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, int top_)
        {
            return GetByTotalBetBonus(totalBetBonus, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, int top_)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, int top_, TransactionManager tm_)
        {
            return GetByTotalBetBonus(totalBetBonus, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, int top_, TransactionManager tm_)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, string sort_)
        {
            return GetByTotalBetBonus(totalBetBonus, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, string sort_)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, 0, sort_, null);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, string sort_, TransactionManager tm_)
        {
            return GetByTotalBetBonus(totalBetBonus, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, string sort_, TransactionManager tm_)
        {
            return await GetByTotalBetBonusAsync(totalBetBonus, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 TotalBetBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalBetBonus">下注时扣除的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalBetBonus(long totalBetBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalBetBonus` = @TotalBetBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalBetBonusAsync(long totalBetBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalBetBonus` = @TotalBetBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalBetBonus", totalBetBonus, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByTotalBetBonus
        #region GetByEffectiveBetAmount

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, TransactionManager tm_)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, TransactionManager tm_)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, int top_)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, int top_)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, int top_, TransactionManager tm_)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, int top_, TransactionManager tm_)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, string sort_)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, string sort_)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, string sort_, TransactionManager tm_)
        {
            return GetByEffectiveBetAmount(effectiveBetAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, string sort_, TransactionManager tm_)
        {
            return await GetByEffectiveBetAmountAsync(effectiveBetAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 EffectiveBetAmount（字段） 查询
        /// </summary>
        /// /// <param name = "effectiveBetAmount">有效下注金额，根据配置给返奖的金额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByEffectiveBetAmount(long effectiveBetAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`EffectiveBetAmount` = @EffectiveBetAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByEffectiveBetAmountAsync(long effectiveBetAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`EffectiveBetAmount` = @EffectiveBetAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@EffectiveBetAmount", effectiveBetAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByEffectiveBetAmount
        #region GetByTotalWinAmount

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount)
        {
            return GetByTotalWinAmount(totalWinAmount, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, TransactionManager tm_)
        {
            return GetByTotalWinAmount(totalWinAmount, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, TransactionManager tm_)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, int top_)
        {
            return GetByTotalWinAmount(totalWinAmount, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, int top_)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, int top_, TransactionManager tm_)
        {
            return GetByTotalWinAmount(totalWinAmount, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, int top_, TransactionManager tm_)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, string sort_)
        {
            return GetByTotalWinAmount(totalWinAmount, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, string sort_)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, 0, sort_, null);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, string sort_, TransactionManager tm_)
        {
            return GetByTotalWinAmount(totalWinAmount, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, string sort_, TransactionManager tm_)
        {
            return await GetByTotalWinAmountAsync(totalWinAmount, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 TotalWinAmount（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinAmount">返奖总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinAmount(long totalWinAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalWinAmount` = @TotalWinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinAmountAsync(long totalWinAmount, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalWinAmount` = @TotalWinAmount", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinAmount", totalWinAmount, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByTotalWinAmount
        #region GetByTotalWinBonus

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus)
        {
            return GetByTotalWinBonus(totalWinBonus, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, TransactionManager tm_)
        {
            return GetByTotalWinBonus(totalWinBonus, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, TransactionManager tm_)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, int top_)
        {
            return GetByTotalWinBonus(totalWinBonus, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, int top_)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, int top_, TransactionManager tm_)
        {
            return GetByTotalWinBonus(totalWinBonus, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, int top_, TransactionManager tm_)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, string sort_)
        {
            return GetByTotalWinBonus(totalWinBonus, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, string sort_)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, 0, sort_, null);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, string sort_, TransactionManager tm_)
        {
            return GetByTotalWinBonus(totalWinBonus, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, string sort_, TransactionManager tm_)
        {
            return await GetByTotalWinBonusAsync(totalWinBonus, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 TotalWinBonus（字段） 查询
        /// </summary>
        /// /// <param name = "totalWinBonus">返奖时增加的bonus总额</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByTotalWinBonus(long totalWinBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalWinBonus` = @TotalWinBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByTotalWinBonusAsync(long totalWinBonus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`TotalWinBonus` = @TotalWinBonus", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@TotalWinBonus", totalWinBonus, MySqlDbType.Int64));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByTotalWinBonus
        #region GetByRecDate

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate)
        {
            return GetByRecDate(recDate, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, int top_)
        {
            return GetByRecDate(recDate, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">记录时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, string sort_)
        {
            return GetByRecDate(recDate, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
        public List<Sa_rebate_dayEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByRecDate
        #region GetByUpdateTime

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime)
        {
            return GetByUpdateTime(updateTime, 0, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime)
        {
            return await GetByUpdateTimeAsync(updateTime, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, TransactionManager tm_)
        {
            return GetByUpdateTime(updateTime, 0, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, TransactionManager tm_)
        {
            return await GetByUpdateTimeAsync(updateTime, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, int top_)
        {
            return GetByUpdateTime(updateTime, top_, string.Empty, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, int top_)
        {
            return await GetByUpdateTimeAsync(updateTime, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, int top_, TransactionManager tm_)
        {
            return GetByUpdateTime(updateTime, top_, string.Empty, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, int top_, TransactionManager tm_)
        {
            return await GetByUpdateTimeAsync(updateTime, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, string sort_)
        {
            return GetByUpdateTime(updateTime, 0, sort_, null);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, string sort_)
        {
            return await GetByUpdateTimeAsync(updateTime, 0, sort_, null);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, string sort_, TransactionManager tm_)
        {
            return GetByUpdateTime(updateTime, 0, sort_, tm_);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, string sort_, TransactionManager tm_)
        {
            return await GetByUpdateTimeAsync(updateTime, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 UpdateTime（字段） 查询
        /// </summary>
        /// /// <param name = "updateTime">修改时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<Sa_rebate_dayEO> GetByUpdateTime(DateTime? updateTime, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(updateTime.HasValue ? "`UpdateTime` = @UpdateTime" : "`UpdateTime` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (updateTime.HasValue)
                paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime.Value, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        public async Task<List<Sa_rebate_dayEO>> GetByUpdateTimeAsync(DateTime? updateTime, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(updateTime.HasValue ? "`UpdateTime` = @UpdateTime" : "`UpdateTime` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (updateTime.HasValue)
                paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime.Value, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_rebate_dayEO.MapDataReader);
        }
        #endregion // GetByUpdateTime
        #endregion // GetByXXX
        #endregion // Get
    }
    #endregion // MO
}
