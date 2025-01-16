/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 18: 04:55
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

namespace UGame.Activity.Tasks.API.Domain.Models
{
    #region EO
    /// <summary>
    /// 巴西用户银行卡
    /// 【表 l_bra_user_bank 的实体类】
    /// </summary>
    [DataContract]
    [Obsolete]
    public class L_bra_user_bankEO : IRowMapper<L_bra_user_bankEO>
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public L_bra_user_bankEO()
        {
            UserKind = 0;
            LastUsing = false;
            RecDate = DateTime.Now;
        }
        #region 主键原始值 & 主键集合

        /// <summary>
        /// 当前对象是否保存原始主键值，当修改了主键值时为 true
        /// </summary>
        public bool HasOriginal { get; protected set; }

        private string _originalUserBankID;
        /// <summary>
        /// 【数据库中的原始主键 UserBankID 值的副本，用于主键值更新】
        /// </summary>
        public string OriginalUserBankID
        {
            get { return _originalUserBankID; }
            set { HasOriginal = true; _originalUserBankID = value; }
        }
        /// <summary>
        /// 获取主键集合。key: 数据库字段名称, value: 主键值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetPrimaryKeys()
        {
            return new Dictionary<string, object>() { { "UserBankID", UserBankID }, };
        }
        /// <summary>
        /// 获取主键集合JSON格式
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
        #endregion // 主键原始值
        #region 所有字段
        /// <summary>
        /// 唯一编码GUID
        /// 【主键 varchar(38)】
        /// </summary>
        [DataMember(Order = 1)]
        public string UserBankID { get; set; }
        /// <summary>
        /// 
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 2)]
        public string BankChannel { get; set; }
        /// <summary>
        /// 用户编码
        /// 【字段 varchar(38)】
        /// </summary>
        [DataMember(Order = 3)]
        public string UserID { get; set; }
        /// <summary>
        /// 用户类型
        ///              0-未知
        ///              1-普通用户
        ///              2-开发用户
        ///              3-线上测试用户（调用第三方扣减）
        ///              4-线上测试用户（不调用第三方扣减）
        ///              5-仿真用户
        ///              6-接口联调用户
        ///              9-管理员
        /// 【字段 int】
        /// </summary>
        [DataMember(Order = 4)]
        public int UserKind { get; set; }
        /// <summary>
        /// 运营商编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 5)]
        public string OperatorID { get; set; }
        /// <summary>
        /// 国家编码ISO 3166-1三位字母
        /// 【字段 varchar(5)】
        /// </summary>
        [DataMember(Order = 6)]
        public string CountryID { get; set; }
        /// <summary>
        /// 货币类型
        /// 【字段 varchar(20)】
        /// </summary>
        [DataMember(Order = 7)]
        public string CurrencyID { get; set; }
        /// <summary>
        /// 税号
        /// 【字段 varchar(200)】
        /// </summary>
        [DataMember(Order = 8)]
        public string TaxId { get; set; }
        /// <summary>
        /// mobile、email、random
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 9)]
        public string KeyCode { get; set; }
        /// <summary>
        /// 开户类型
        /// 【字段 varchar(200)】
        /// </summary>
        [DataMember(Order = 10)]
        public string AccountType { get; set; }
        /// <summary>
        /// 使用者名称
        /// 【字段 varchar(200)】
        /// </summary>
        [DataMember(Order = 11)]
        public string Name { get; set; }
        /// <summary>
        /// 所有者类型
        /// 【字段 varchar(200)】
        /// </summary>
        [DataMember(Order = 12)]
        public string OwnerType { get; set; }
        /// <summary>
        /// 银行名称
        /// 【字段 varchar(200)】
        /// </summary>
        [DataMember(Order = 13)]
        public string BankName { get; set; }
        /// <summary>
        /// 银行编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 14)]
        public string BankCode { get; set; }
        /// <summary>
        /// 支行编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 15)]
        public string BranchCode { get; set; }
        /// <summary>
        /// 银行卡号
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 16)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// 开户状态
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 17)]
        public string AccountStatus { get; set; }
        /// <summary>
        /// 最后充值、提现使用的卡
        /// 【字段 tinyint(1)】
        /// </summary>
        [DataMember(Order = 18)]
        public bool LastUsing { get; set; }
        /// <summary>
        /// 创建时间
        /// 【字段 datetime】
        /// </summary>
        [DataMember(Order = 19)]
        public DateTime RecDate { get; set; }
        #endregion // 所有列
        #region 实体映射

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public L_bra_user_bankEO MapRow(IDataReader reader)
        {
            return MapDataReader(reader);
        }

        /// <summary>
        /// 将IDataReader映射成实体对象
        /// </summary>
        /// <param name = "reader">只进结果集流</param>
        /// <return>实体对象</return>
        public static L_bra_user_bankEO MapDataReader(IDataReader reader)
        {
            L_bra_user_bankEO ret = new L_bra_user_bankEO();
            ret.UserBankID = reader.ToString("UserBankID");
            ret.OriginalUserBankID = ret.UserBankID;
            ret.BankChannel = reader.ToString("BankChannel");
            ret.UserID = reader.ToString("UserID");
            ret.UserKind = reader.ToInt32("UserKind");
            ret.OperatorID = reader.ToString("OperatorID");
            ret.CountryID = reader.ToString("CountryID");
            ret.CurrencyID = reader.ToString("CurrencyID");
            ret.TaxId = reader.ToString("TaxId");
            ret.KeyCode = reader.ToString("KeyCode");
            ret.AccountType = reader.ToString("AccountType");
            ret.Name = reader.ToString("Name");
            ret.OwnerType = reader.ToString("OwnerType");
            ret.BankName = reader.ToString("BankName");
            ret.BankCode = reader.ToString("BankCode");
            ret.BranchCode = reader.ToString("BranchCode");
            ret.AccountNumber = reader.ToString("AccountNumber");
            ret.AccountStatus = reader.ToString("AccountStatus");
            ret.LastUsing = reader.ToBoolean("LastUsing");
            ret.RecDate = reader.ToDateTime("RecDate");
            return ret;
        }

        #endregion
    }
    #endregion // EO

    #region MO
    /// <summary>
    /// 巴西用户银行卡
    /// 【表 l_bra_user_bank 的操作类】
    /// </summary>
    [Obsolete]
    public class L_bra_user_bankMO : MySqlTableMO<L_bra_user_bankEO>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName { get; set; } = "`l_bra_user_bank`";

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "database">数据来源</param>
        public L_bra_user_bankMO(MySqlDatabase database) : base(database) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
        public L_bra_user_bankMO(string connectionStringName = null) : base(connectionStringName) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">CommandTimeout时间</param>
        public L_bra_user_bankMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
        #endregion // Constructors

        #region  Add
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name = "item">要插入的实体对象</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="useIgnore_">是否使用INSERT IGNORE</param>
        /// <return>受影响的行数</return>
        public override int Add(L_bra_user_bankEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public override async Task<int> AddAsync(L_bra_user_bankEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
        {
            RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairAddData(L_bra_user_bankEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
            sql_ += $" INTO {TableName} (`UserBankID`, `BankChannel`, `UserID`, `UserKind`, `OperatorID`, `CountryID`, `CurrencyID`, `TaxId`, `KeyCode`, `AccountType`, `Name`, `OwnerType`, `BankName`, `BankCode`, `BranchCode`, `AccountNumber`, `AccountStatus`, `LastUsing`, `RecDate`) VALUE (@UserBankID, @BankChannel, @UserID, @UserKind, @OperatorID, @CountryID, @CurrencyID, @TaxId, @KeyCode, @AccountType, @Name, @OwnerType, @BankName, @BankCode, @BranchCode, @AccountNumber, @AccountStatus, @LastUsing, @RecDate);";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", item.UserBankID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankChannel", item.BankChannel, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@TaxId", item.TaxId != null ? item.TaxId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@KeyCode", item.KeyCode, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountType", item.AccountType != null ? item.AccountType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@Name", item.Name != null ? item.Name : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@OwnerType", item.OwnerType != null ? item.OwnerType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BranchCode", item.BranchCode != null ? item.BranchCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountNumber", item.AccountNumber != null ? item.AccountNumber : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountStatus", item.AccountStatus != null ? item.AccountStatus : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@LastUsing", item.LastUsing, MySqlDbType.Byte),
                Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
            };
        }
        public int AddByBatch(IEnumerable<L_bra_user_bankEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += Database.ExecSqlNonQuery(sql, tm_);
            }
            return ret;
        }
        public async Task<int> AddByBatchAsync(IEnumerable<L_bra_user_bankEO> items, int batchCount, TransactionManager tm_ = null)
        {
            var ret = 0;
            foreach (var sql in BuildAddBatchSql(items, batchCount))
            {
                ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
            }
            return ret;
        }
        private IEnumerable<string> BuildAddBatchSql(IEnumerable<L_bra_user_bankEO> items, int batchCount)
        {
            var count = 0;
            var insertSql = $"INSERT INTO {TableName} (`UserBankID`, `BankChannel`, `UserID`, `UserKind`, `OperatorID`, `CountryID`, `CurrencyID`, `TaxId`, `KeyCode`, `AccountType`, `Name`, `OwnerType`, `BankName`, `BankCode`, `BranchCode`, `AccountNumber`, `AccountStatus`, `LastUsing`, `RecDate`) VALUES ";
            var sql = new StringBuilder();
            foreach (var item in items)
            {
                count++;
                sql.Append($"('{item.UserBankID}','{item.BankChannel}','{item.UserID}',{item.UserKind},'{item.OperatorID}','{item.CountryID}','{item.CurrencyID}','{item.TaxId}','{item.KeyCode}','{item.AccountType}','{item.Name}','{item.OwnerType}','{item.BankName}','{item.BankCode}','{item.BranchCode}','{item.AccountNumber}','{item.AccountStatus}',{item.LastUsing},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByPK(string userBankID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(userBankID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            RepiarRemoveByPKData(userBankID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepiarRemoveByPKData(string userBankID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }
        /// <summary>
        /// 删除指定实体对应的记录
        /// </summary>
        /// <param name = "item">要删除的实体</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Remove(L_bra_user_bankEO item, TransactionManager tm_ = null)
        {
            return RemoveByPK(item.UserBankID, tm_);
        }
        public async Task<int> RemoveAsync(L_bra_user_bankEO item, TransactionManager tm_ = null)
        {
            return await RemoveByPKAsync(item.UserBankID, tm_);
        }
        #endregion // RemoveByPK

        #region RemoveByXXX
        #region RemoveByBankChannel
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBankChannel(string bankChannel, TransactionManager tm_ = null)
        {
            RepairRemoveByBankChannelData(bankChannel, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBankChannelAsync(string bankChannel, TransactionManager tm_ = null)
        {
            RepairRemoveByBankChannelData(bankChannel, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBankChannelData(string bankChannel, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `BankChannel` = @BankChannel";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar));
        }
        #endregion // RemoveByBankChannel
        #region RemoveByUserID
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
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
        #region RemoveByTaxId
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByTaxId(string taxId, TransactionManager tm_ = null)
        {
            RepairRemoveByTaxIdData(taxId, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByTaxIdAsync(string taxId, TransactionManager tm_ = null)
        {
            RepairRemoveByTaxIdData(taxId, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByTaxIdData(string taxId, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (taxId != null ? "`TaxId` = @TaxId" : "`TaxId` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (taxId != null)
                paras_.Add(Database.CreateInParameter("@TaxId", taxId, MySqlDbType.VarChar));
        }
        #endregion // RemoveByTaxId
        #region RemoveByKeyCode
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByKeyCode(string keyCode, TransactionManager tm_ = null)
        {
            RepairRemoveByKeyCodeData(keyCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByKeyCodeAsync(string keyCode, TransactionManager tm_ = null)
        {
            RepairRemoveByKeyCodeData(keyCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByKeyCodeData(string keyCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `KeyCode` = @KeyCode";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar));
        }
        #endregion // RemoveByKeyCode
        #region RemoveByAccountType
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByAccountType(string accountType, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountTypeData(accountType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByAccountTypeAsync(string accountType, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountTypeData(accountType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByAccountTypeData(string accountType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (accountType != null ? "`AccountType` = @AccountType" : "`AccountType` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (accountType != null)
                paras_.Add(Database.CreateInParameter("@AccountType", accountType, MySqlDbType.VarChar));
        }
        #endregion // RemoveByAccountType
        #region RemoveByName
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByName(string name, TransactionManager tm_ = null)
        {
            RepairRemoveByNameData(name, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByNameAsync(string name, TransactionManager tm_ = null)
        {
            RepairRemoveByNameData(name, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByNameData(string name, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (name != null ? "`Name` = @Name" : "`Name` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (name != null)
                paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
        }
        #endregion // RemoveByName
        #region RemoveByOwnerType
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByOwnerType(string ownerType, TransactionManager tm_ = null)
        {
            RepairRemoveByOwnerTypeData(ownerType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByOwnerTypeAsync(string ownerType, TransactionManager tm_ = null)
        {
            RepairRemoveByOwnerTypeData(ownerType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByOwnerTypeData(string ownerType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (ownerType != null ? "`OwnerType` = @OwnerType" : "`OwnerType` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (ownerType != null)
                paras_.Add(Database.CreateInParameter("@OwnerType", ownerType, MySqlDbType.VarChar));
        }
        #endregion // RemoveByOwnerType
        #region RemoveByBankName
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBankName(string bankName, TransactionManager tm_ = null)
        {
            RepairRemoveByBankNameData(bankName, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBankNameAsync(string bankName, TransactionManager tm_ = null)
        {
            RepairRemoveByBankNameData(bankName, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBankNameData(string bankName, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (bankName != null)
                paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
        }
        #endregion // RemoveByBankName
        #region RemoveByBankCode
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBankCode(string bankCode, TransactionManager tm_ = null)
        {
            RepairRemoveByBankCodeData(bankCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBankCodeAsync(string bankCode, TransactionManager tm_ = null)
        {
            RepairRemoveByBankCodeData(bankCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBankCodeData(string bankCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (bankCode != null)
                paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
        }
        #endregion // RemoveByBankCode
        #region RemoveByBranchCode
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByBranchCode(string branchCode, TransactionManager tm_ = null)
        {
            RepairRemoveByBranchCodeData(branchCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByBranchCodeAsync(string branchCode, TransactionManager tm_ = null)
        {
            RepairRemoveByBranchCodeData(branchCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByBranchCodeData(string branchCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (branchCode != null ? "`BranchCode` = @BranchCode" : "`BranchCode` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (branchCode != null)
                paras_.Add(Database.CreateInParameter("@BranchCode", branchCode, MySqlDbType.VarChar));
        }
        #endregion // RemoveByBranchCode
        #region RemoveByAccountNumber
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByAccountNumber(string accountNumber, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountNumberData(accountNumber, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByAccountNumberAsync(string accountNumber, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountNumberData(accountNumber, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByAccountNumberData(string accountNumber, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (accountNumber != null ? "`AccountNumber` = @AccountNumber" : "`AccountNumber` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (accountNumber != null)
                paras_.Add(Database.CreateInParameter("@AccountNumber", accountNumber, MySqlDbType.VarChar));
        }
        #endregion // RemoveByAccountNumber
        #region RemoveByAccountStatus
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByAccountStatus(string accountStatus, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountStatusData(accountStatus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByAccountStatusAsync(string accountStatus, TransactionManager tm_ = null)
        {
            RepairRemoveByAccountStatusData(accountStatus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByAccountStatusData(string accountStatus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE " + (accountStatus != null ? "`AccountStatus` = @AccountStatus" : "`AccountStatus` IS NULL");
            paras_ = new List<MySqlParameter>();
            if (accountStatus != null)
                paras_.Add(Database.CreateInParameter("@AccountStatus", accountStatus, MySqlDbType.VarChar));
        }
        #endregion // RemoveByAccountStatus
        #region RemoveByLastUsing
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name="tm_">事务管理对象</param>
        public int RemoveByLastUsing(bool lastUsing, TransactionManager tm_ = null)
        {
            RepairRemoveByLastUsingData(lastUsing, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> RemoveByLastUsingAsync(bool lastUsing, TransactionManager tm_ = null)
        {
            RepairRemoveByLastUsingData(lastUsing, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairRemoveByLastUsingData(bool lastUsing, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"DELETE FROM {TableName} WHERE `LastUsing` = @LastUsing";
            paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte));
        }
        #endregion // RemoveByLastUsing
        #region RemoveByRecDate
        /// <summary>
        /// 按字段删除
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
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
        public int Put(L_bra_user_bankEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAsync(L_bra_user_bankEO item, TransactionManager tm_ = null)
        {
            RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutData(L_bra_user_bankEO item, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `UserBankID` = @UserBankID, `BankChannel` = @BankChannel, `UserID` = @UserID, `UserKind` = @UserKind, `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `TaxId` = @TaxId, `KeyCode` = @KeyCode, `AccountType` = @AccountType, `Name` = @Name, `OwnerType` = @OwnerType, `BankName` = @BankName, `BankCode` = @BankCode, `BranchCode` = @BranchCode, `AccountNumber` = @AccountNumber, `AccountStatus` = @AccountStatus, `LastUsing` = @LastUsing WHERE `UserBankID` = @UserBankID_Original";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", item.UserBankID, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankChannel", item.BankChannel, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
                Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@TaxId", item.TaxId != null ? item.TaxId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@KeyCode", item.KeyCode, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountType", item.AccountType != null ? item.AccountType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@Name", item.Name != null ? item.Name : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@OwnerType", item.OwnerType != null ? item.OwnerType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@BranchCode", item.BranchCode != null ? item.BranchCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountNumber", item.AccountNumber != null ? item.AccountNumber : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@AccountStatus", item.AccountStatus != null ? item.AccountStatus : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@LastUsing", item.LastUsing, MySqlDbType.Byte),
                Database.CreateInParameter("@UserBankID_Original", item.HasOriginal ? item.OriginalUserBankID : item.UserBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新实体集合到数据库
        /// </summary>
        /// <param name = "items">要更新的实体对象集合</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int Put(IEnumerable<L_bra_user_bankEO> items, TransactionManager tm_ = null)
        {
            int ret = 0;
            foreach (var item in items)
            {
                ret += Put(item, tm_);
            }
            return ret;
        }
        public async Task<int> PutAsync(IEnumerable<L_bra_user_bankEO> items, TransactionManager tm_ = null)
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
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(string userBankID, string set_, params object[] values_)
        {
            return Put(set_, "`UserBankID` = @UserBankID", ConcatValues(values_, userBankID));
        }
        public async Task<int> PutByPKAsync(string userBankID, string set_, params object[] values_)
        {
            return await PutAsync(set_, "`UserBankID` = @UserBankID", ConcatValues(values_, userBankID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="values_">参数值</param>
        /// <return>受影响的行数</return>
        public int PutByPK(string userBankID, string set_, TransactionManager tm_, params object[] values_)
        {
            return Put(set_, "`UserBankID` = @UserBankID", tm_, ConcatValues(values_, userBankID));
        }
        public async Task<int> PutByPKAsync(string userBankID, string set_, TransactionManager tm_, params object[] values_)
        {
            return await PutAsync(set_, "`UserBankID` = @UserBankID", tm_, ConcatValues(values_, userBankID));
        }
        /// <summary>
        /// 按主键更新指定列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name = "set_">更新的列数据</param>
        /// <param name="paras_">参数值</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutByPK(string userBankID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return Put(set_, "`UserBankID` = @UserBankID", ConcatParameters(paras_, newParas_), tm_);
        }
        public async Task<int> PutByPKAsync(string userBankID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
        {
            var newParas_ = new List<MySqlParameter>() {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return await PutAsync(set_, "`UserBankID` = @UserBankID", ConcatParameters(paras_, newParas_), tm_);
        }
        #endregion // PutByPK

        #region PutXXX
        #region PutBankChannel
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "bankChannel"></param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankChannelByPK(string userBankID, string bankChannel, TransactionManager tm_ = null)
        {
            RepairPutBankChannelByPKData(userBankID, bankChannel, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBankChannelByPKAsync(string userBankID, string bankChannel, TransactionManager tm_ = null)
        {
            RepairPutBankChannelByPKData(userBankID, bankChannel, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBankChannelByPKData(string userBankID, string bankChannel, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BankChannel` = @BankChannel  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankChannel(string bankChannel, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankChannel` = @BankChannel";
            var parameter_ = Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBankChannelAsync(string bankChannel, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankChannel` = @BankChannel";
            var parameter_ = Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBankChannel
        #region PutUserID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "userID">用户编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUserIDByPK(string userBankID, string userID, TransactionManager tm_ = null)
        {
            RepairPutUserIDByPKData(userBankID, userID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutUserIDByPKAsync(string userBankID, string userID, TransactionManager tm_ = null)
        {
            RepairPutUserIDByPKData(userBankID, userID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutUserIDByPKData(string userBankID, string userID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
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
        #region PutUserKind
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutUserKindByPK(string userBankID, int userKind, TransactionManager tm_ = null)
        {
            RepairPutUserKindByPKData(userBankID, userKind, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutUserKindByPKAsync(string userBankID, int userKind, TransactionManager tm_ = null)
        {
            RepairPutUserKindByPKData(userBankID, userKind, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutUserKindByPKData(string userBankID, int userKind, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
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
        #region PutOperatorID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOperatorIDByPK(string userBankID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(userBankID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutOperatorIDByPKAsync(string userBankID, string operatorID, TransactionManager tm_ = null)
        {
            RepairPutOperatorIDByPKData(userBankID, operatorID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutOperatorIDByPKData(string userBankID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
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
        #region PutCountryID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCountryIDByPK(string userBankID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(userBankID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCountryIDByPKAsync(string userBankID, string countryID, TransactionManager tm_ = null)
        {
            RepairPutCountryIDByPKData(userBankID, countryID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCountryIDByPKData(string userBankID, string countryID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
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
        #region PutCurrencyID
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutCurrencyIDByPK(string userBankID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(userBankID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutCurrencyIDByPKAsync(string userBankID, string currencyID, TransactionManager tm_ = null)
        {
            RepairPutCurrencyIDByPKData(userBankID, currencyID, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutCurrencyIDByPKData(string userBankID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
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
        #region PutTaxId
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "taxId">税号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTaxIdByPK(string userBankID, string taxId, TransactionManager tm_ = null)
        {
            RepairPutTaxIdByPKData(userBankID, taxId, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutTaxIdByPKAsync(string userBankID, string taxId, TransactionManager tm_ = null)
        {
            RepairPutTaxIdByPKData(userBankID, taxId, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutTaxIdByPKData(string userBankID, string taxId, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `TaxId` = @TaxId  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@TaxId", taxId != null ? taxId : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutTaxId(string taxId, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TaxId` = @TaxId";
            var parameter_ = Database.CreateInParameter("@TaxId", taxId != null ? taxId : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutTaxIdAsync(string taxId, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `TaxId` = @TaxId";
            var parameter_ = Database.CreateInParameter("@TaxId", taxId != null ? taxId : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutTaxId
        #region PutKeyCode
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutKeyCodeByPK(string userBankID, string keyCode, TransactionManager tm_ = null)
        {
            RepairPutKeyCodeByPKData(userBankID, keyCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutKeyCodeByPKAsync(string userBankID, string keyCode, TransactionManager tm_ = null)
        {
            RepairPutKeyCodeByPKData(userBankID, keyCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutKeyCodeByPKData(string userBankID, string keyCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `KeyCode` = @KeyCode  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutKeyCode(string keyCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `KeyCode` = @KeyCode";
            var parameter_ = Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutKeyCodeAsync(string keyCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `KeyCode` = @KeyCode";
            var parameter_ = Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutKeyCode
        #region PutAccountType
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountTypeByPK(string userBankID, string accountType, TransactionManager tm_ = null)
        {
            RepairPutAccountTypeByPKData(userBankID, accountType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAccountTypeByPKAsync(string userBankID, string accountType, TransactionManager tm_ = null)
        {
            RepairPutAccountTypeByPKData(userBankID, accountType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutAccountTypeByPKData(string userBankID, string accountType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `AccountType` = @AccountType  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@AccountType", accountType != null ? accountType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountType(string accountType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountType` = @AccountType";
            var parameter_ = Database.CreateInParameter("@AccountType", accountType != null ? accountType : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutAccountTypeAsync(string accountType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountType` = @AccountType";
            var parameter_ = Database.CreateInParameter("@AccountType", accountType != null ? accountType : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutAccountType
        #region PutName
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "name">使用者名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutNameByPK(string userBankID, string name, TransactionManager tm_ = null)
        {
            RepairPutNameByPKData(userBankID, name, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutNameByPKAsync(string userBankID, string name, TransactionManager tm_ = null)
        {
            RepairPutNameByPKData(userBankID, name, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutNameByPKData(string userBankID, string name, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `Name` = @Name  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@Name", name != null ? name : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutName(string name, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Name` = @Name";
            var parameter_ = Database.CreateInParameter("@Name", name != null ? name : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutNameAsync(string name, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `Name` = @Name";
            var parameter_ = Database.CreateInParameter("@Name", name != null ? name : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutName
        #region PutOwnerType
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOwnerTypeByPK(string userBankID, string ownerType, TransactionManager tm_ = null)
        {
            RepairPutOwnerTypeByPKData(userBankID, ownerType, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutOwnerTypeByPKAsync(string userBankID, string ownerType, TransactionManager tm_ = null)
        {
            RepairPutOwnerTypeByPKData(userBankID, ownerType, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutOwnerTypeByPKData(string userBankID, string ownerType, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `OwnerType` = @OwnerType  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@OwnerType", ownerType != null ? ownerType : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutOwnerType(string ownerType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OwnerType` = @OwnerType";
            var parameter_ = Database.CreateInParameter("@OwnerType", ownerType != null ? ownerType : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutOwnerTypeAsync(string ownerType, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `OwnerType` = @OwnerType";
            var parameter_ = Database.CreateInParameter("@OwnerType", ownerType != null ? ownerType : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutOwnerType
        #region PutBankName
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankNameByPK(string userBankID, string bankName, TransactionManager tm_ = null)
        {
            RepairPutBankNameByPKData(userBankID, bankName, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBankNameByPKAsync(string userBankID, string bankName, TransactionManager tm_ = null)
        {
            RepairPutBankNameByPKData(userBankID, bankName, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBankNameByPKData(string userBankID, string bankName, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BankName` = @BankName  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BankName", bankName != null ? bankName : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankName(string bankName, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankName` = @BankName";
            var parameter_ = Database.CreateInParameter("@BankName", bankName != null ? bankName : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBankNameAsync(string bankName, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankName` = @BankName";
            var parameter_ = Database.CreateInParameter("@BankName", bankName != null ? bankName : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBankName
        #region PutBankCode
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankCodeByPK(string userBankID, string bankCode, TransactionManager tm_ = null)
        {
            RepairPutBankCodeByPKData(userBankID, bankCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBankCodeByPKAsync(string userBankID, string bankCode, TransactionManager tm_ = null)
        {
            RepairPutBankCodeByPKData(userBankID, bankCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBankCodeByPKData(string userBankID, string bankCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBankCode(string bankCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
            var parameter_ = Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBankCodeAsync(string bankCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
            var parameter_ = Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBankCode
        #region PutBranchCode
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBranchCodeByPK(string userBankID, string branchCode, TransactionManager tm_ = null)
        {
            RepairPutBranchCodeByPKData(userBankID, branchCode, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutBranchCodeByPKAsync(string userBankID, string branchCode, TransactionManager tm_ = null)
        {
            RepairPutBranchCodeByPKData(userBankID, branchCode, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutBranchCodeByPKData(string userBankID, string branchCode, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `BranchCode` = @BranchCode  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@BranchCode", branchCode != null ? branchCode : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutBranchCode(string branchCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BranchCode` = @BranchCode";
            var parameter_ = Database.CreateInParameter("@BranchCode", branchCode != null ? branchCode : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutBranchCodeAsync(string branchCode, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `BranchCode` = @BranchCode";
            var parameter_ = Database.CreateInParameter("@BranchCode", branchCode != null ? branchCode : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutBranchCode
        #region PutAccountNumber
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountNumberByPK(string userBankID, string accountNumber, TransactionManager tm_ = null)
        {
            RepairPutAccountNumberByPKData(userBankID, accountNumber, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAccountNumberByPKAsync(string userBankID, string accountNumber, TransactionManager tm_ = null)
        {
            RepairPutAccountNumberByPKData(userBankID, accountNumber, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutAccountNumberByPKData(string userBankID, string accountNumber, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `AccountNumber` = @AccountNumber  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@AccountNumber", accountNumber != null ? accountNumber : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountNumber(string accountNumber, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountNumber` = @AccountNumber";
            var parameter_ = Database.CreateInParameter("@AccountNumber", accountNumber != null ? accountNumber : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutAccountNumberAsync(string accountNumber, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountNumber` = @AccountNumber";
            var parameter_ = Database.CreateInParameter("@AccountNumber", accountNumber != null ? accountNumber : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutAccountNumber
        #region PutAccountStatus
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountStatusByPK(string userBankID, string accountStatus, TransactionManager tm_ = null)
        {
            RepairPutAccountStatusByPKData(userBankID, accountStatus, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutAccountStatusByPKAsync(string userBankID, string accountStatus, TransactionManager tm_ = null)
        {
            RepairPutAccountStatusByPKData(userBankID, accountStatus, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutAccountStatusByPKData(string userBankID, string accountStatus, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `AccountStatus` = @AccountStatus  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@AccountStatus", accountStatus != null ? accountStatus : DBNull.Value, MySqlDbType.VarChar),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutAccountStatus(string accountStatus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountStatus` = @AccountStatus";
            var parameter_ = Database.CreateInParameter("@AccountStatus", accountStatus != null ? accountStatus : DBNull.Value, MySqlDbType.VarChar);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutAccountStatusAsync(string accountStatus, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `AccountStatus` = @AccountStatus";
            var parameter_ = Database.CreateInParameter("@AccountStatus", accountStatus != null ? accountStatus : DBNull.Value, MySqlDbType.VarChar);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutAccountStatus
        #region PutLastUsing
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutLastUsingByPK(string userBankID, bool lastUsing, TransactionManager tm_ = null)
        {
            RepairPutLastUsingByPKData(userBankID, lastUsing, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutLastUsingByPKAsync(string userBankID, bool lastUsing, TransactionManager tm_ = null)
        {
            RepairPutLastUsingByPKData(userBankID, lastUsing, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutLastUsingByPKData(string userBankID, bool lastUsing, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `LastUsing` = @LastUsing  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutLastUsing(bool lastUsing, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `LastUsing` = @LastUsing";
            var parameter_ = Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte);
            return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        public async Task<int> PutLastUsingAsync(bool lastUsing, TransactionManager tm_ = null)
        {
            string sql_ = $"UPDATE {TableName} SET `LastUsing` = @LastUsing";
            var parameter_ = Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte);
            return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
        }
        #endregion // PutLastUsing
        #region PutRecDate
        /// <summary>
        /// 按主键更新列数据
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>受影响的行数</return>
        public int PutRecDateByPK(string userBankID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(userBankID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return Database.ExecSqlNonQuery(sql_, paras_, tm_);
        }
        public async Task<int> PutRecDateByPKAsync(string userBankID, DateTime recDate, TransactionManager tm_ = null)
        {
            RepairPutRecDateByPKData(userBankID, recDate, out string sql_, out List<MySqlParameter> paras_);
            return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
        }
        private void RepairPutRecDateByPKData(string userBankID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
        {
            sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `UserBankID` = @UserBankID";
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
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
        #endregion // PutXXX
        #endregion // Put

        #region Set

        /// <summary>
        /// 插入或者更新数据
        /// </summary>
        /// <param name = "item">要更新的实体对象</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>true:插入操作；false:更新操作</return>
        public bool Set(L_bra_user_bankEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.UserBankID) == null)
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
        public async Task<bool> SetAsync(L_bra_user_bankEO item, TransactionManager tm = null)
        {
            bool ret = true;
            if (GetByPK(item.UserBankID) == null)
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
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
        /// <return></return>
        public L_bra_user_bankEO GetByPK(string userBankID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(userBankID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return Database.ExecSqlSingle(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<L_bra_user_bankEO> GetByPKAsync(string userBankID, TransactionManager tm_ = null, bool isForUpdate_ = false)
        {
            RepairGetByPKData(userBankID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
            return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        private void RepairGetByPKData(string userBankID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
        {
            sql_ = BuildSelectSQL("`UserBankID` = @UserBankID", 0, null, null, isForUpdate_);
            paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
        }
        #endregion // GetByPK

        #region GetXXXByPK

        /// <summary>
        /// 按主键查询 BankChannel（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetBankChannelByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`BankChannel`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetBankChannelByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`BankChannel`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 UserID（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetUserIDByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`UserID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetUserIDByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`UserID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 UserKind（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public int GetUserKindByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (int)GetScalar("`UserKind`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<int> GetUserKindByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (int)await GetScalarAsync("`UserKind`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 OperatorID（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetOperatorIDByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`OperatorID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetOperatorIDByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`OperatorID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CountryID（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCountryIDByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`CountryID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetCountryIDByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`CountryID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 CurrencyID（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetCurrencyIDByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`CurrencyID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetCurrencyIDByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`CurrencyID`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 TaxId（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetTaxIdByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`TaxId`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetTaxIdByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`TaxId`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 KeyCode（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetKeyCodeByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`KeyCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetKeyCodeByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`KeyCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 AccountType（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetAccountTypeByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`AccountType`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetAccountTypeByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`AccountType`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 Name（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetNameByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`Name`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetNameByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`Name`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 OwnerType（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetOwnerTypeByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`OwnerType`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetOwnerTypeByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`OwnerType`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 BankName（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetBankNameByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`BankName`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetBankNameByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`BankName`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 BankCode（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetBankCodeByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`BankCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetBankCodeByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`BankCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 BranchCode（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetBranchCodeByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`BranchCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetBranchCodeByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`BranchCode`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 AccountNumber（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetAccountNumberByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`AccountNumber`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetAccountNumberByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`AccountNumber`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 AccountStatus（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public string GetAccountStatusByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)GetScalar("`AccountStatus`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<string> GetAccountStatusByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (string)await GetScalarAsync("`AccountStatus`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 LastUsing（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public bool GetLastUsingByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (bool)GetScalar("`LastUsing`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<bool> GetLastUsingByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (bool)await GetScalarAsync("`LastUsing`", "`UserBankID` = @UserBankID", paras_, tm_);
        }

        /// <summary>
        /// 按主键查询 RecDate（字段）
        /// </summary>
        /// /// <param name = "userBankID">唯一编码GUID</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return></return>
        public DateTime GetRecDateByPK(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (DateTime)GetScalar("`RecDate`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        public async Task<DateTime> GetRecDateByPKAsync(string userBankID, TransactionManager tm_ = null)
        {
            var paras_ = new List<MySqlParameter>()
            {
                Database.CreateInParameter("@UserBankID", userBankID, MySqlDbType.VarChar),
            };
            return (DateTime)await GetScalarAsync("`RecDate`", "`UserBankID` = @UserBankID", paras_, tm_);
        }
        #endregion // GetXXXByPK
        #region GetByXXX
        #region GetByBankChannel

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel)
        {
            return GetByBankChannel(bankChannel, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel)
        {
            return await GetByBankChannelAsync(bankChannel, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, TransactionManager tm_)
        {
            return GetByBankChannel(bankChannel, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, TransactionManager tm_)
        {
            return await GetByBankChannelAsync(bankChannel, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, int top_)
        {
            return GetByBankChannel(bankChannel, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, int top_)
        {
            return await GetByBankChannelAsync(bankChannel, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, int top_, TransactionManager tm_)
        {
            return GetByBankChannel(bankChannel, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, int top_, TransactionManager tm_)
        {
            return await GetByBankChannelAsync(bankChannel, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, string sort_)
        {
            return GetByBankChannel(bankChannel, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, string sort_)
        {
            return await GetByBankChannelAsync(bankChannel, 0, sort_, null);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, string sort_, TransactionManager tm_)
        {
            return GetByBankChannel(bankChannel, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, string sort_, TransactionManager tm_)
        {
            return await GetByBankChannelAsync(bankChannel, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BankChannel（字段） 查询
        /// </summary>
        /// /// <param name = "bankChannel"></param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankChannel(string bankChannel, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BankChannel` = @BankChannel", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankChannelAsync(string bankChannel, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`BankChannel` = @BankChannel", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@BankChannel", bankChannel, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByBankChannel
        #region GetByUserID

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID)
        {
            return GetByUserID(userID, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID)
        {
            return await GetByUserIDAsync(userID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, TransactionManager tm_)
        {
            return GetByUserID(userID, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, int top_)
        {
            return GetByUserID(userID, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, int top_)
        {
            return await GetByUserIDAsync(userID, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, int top_, TransactionManager tm_)
        {
            return GetByUserID(userID, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, string sort_)
        {
            return GetByUserID(userID, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, string sort_)
        {
            return await GetByUserIDAsync(userID, 0, sort_, null);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
        {
            return GetByUserID(userID, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
        {
            return await GetByUserIDAsync(userID, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 UserID（字段） 查询
        /// </summary>
        /// /// <param name = "userID">用户编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByUserID
        #region GetByUserKind

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserKind(int userKind)
        {
            return GetByUserKind(userKind, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind)
        {
            return await GetByUserKindAsync(userKind, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, TransactionManager tm_)
        {
            return GetByUserKind(userKind, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
        {
            return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, int top_)
        {
            return GetByUserKind(userKind, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, int top_)
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
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
        {
            return GetByUserKind(userKind, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
        {
            return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 UserKind（字段） 查询
        /// </summary>
        /// /// <param name = "userKind">用户类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, string sort_)
        {
            return GetByUserKind(userKind, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, string sort_)
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
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
        {
            return GetByUserKind(userKind, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
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
        public List<L_bra_user_bankEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByUserKind
        #region GetByOperatorID

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, int top_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
        {
            return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OperatorID（字段） 查询
        /// </summary>
        /// /// <param name = "operatorID">运营商编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, string sort_)
        {
            return GetByOperatorID(operatorID, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
        {
            return GetByOperatorID(operatorID, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
        public List<L_bra_user_bankEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByOperatorID
        #region GetByCountryID

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCountryID(string countryID)
        {
            return GetByCountryID(countryID, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, int top_)
        {
            return GetByCountryID(countryID, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, int top_)
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
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
        {
            return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CountryID（字段） 查询
        /// </summary>
        /// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, string sort_)
        {
            return GetByCountryID(countryID, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, string sort_)
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
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
        {
            return GetByCountryID(countryID, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
        public List<L_bra_user_bankEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByCountryID
        #region GetByCurrencyID

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, int top_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
        {
            return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 CurrencyID（字段） 查询
        /// </summary>
        /// /// <param name = "currencyID">货币类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, string sort_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
        {
            return GetByCurrencyID(currencyID, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
        public List<L_bra_user_bankEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByCurrencyID
        #region GetByTaxId

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId)
        {
            return GetByTaxId(taxId, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId)
        {
            return await GetByTaxIdAsync(taxId, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, TransactionManager tm_)
        {
            return GetByTaxId(taxId, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, TransactionManager tm_)
        {
            return await GetByTaxIdAsync(taxId, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, int top_)
        {
            return GetByTaxId(taxId, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, int top_)
        {
            return await GetByTaxIdAsync(taxId, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, int top_, TransactionManager tm_)
        {
            return GetByTaxId(taxId, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, int top_, TransactionManager tm_)
        {
            return await GetByTaxIdAsync(taxId, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, string sort_)
        {
            return GetByTaxId(taxId, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, string sort_)
        {
            return await GetByTaxIdAsync(taxId, 0, sort_, null);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, string sort_, TransactionManager tm_)
        {
            return GetByTaxId(taxId, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, string sort_, TransactionManager tm_)
        {
            return await GetByTaxIdAsync(taxId, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 TaxId（字段） 查询
        /// </summary>
        /// /// <param name = "taxId">税号</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByTaxId(string taxId, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(taxId != null ? "`TaxId` = @TaxId" : "`TaxId` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (taxId != null)
                paras_.Add(Database.CreateInParameter("@TaxId", taxId, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByTaxIdAsync(string taxId, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(taxId != null ? "`TaxId` = @TaxId" : "`TaxId` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (taxId != null)
                paras_.Add(Database.CreateInParameter("@TaxId", taxId, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByTaxId
        #region GetByKeyCode

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode)
        {
            return GetByKeyCode(keyCode, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode)
        {
            return await GetByKeyCodeAsync(keyCode, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, TransactionManager tm_)
        {
            return GetByKeyCode(keyCode, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, TransactionManager tm_)
        {
            return await GetByKeyCodeAsync(keyCode, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, int top_)
        {
            return GetByKeyCode(keyCode, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, int top_)
        {
            return await GetByKeyCodeAsync(keyCode, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, int top_, TransactionManager tm_)
        {
            return GetByKeyCode(keyCode, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, int top_, TransactionManager tm_)
        {
            return await GetByKeyCodeAsync(keyCode, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, string sort_)
        {
            return GetByKeyCode(keyCode, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, string sort_)
        {
            return await GetByKeyCodeAsync(keyCode, 0, sort_, null);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, string sort_, TransactionManager tm_)
        {
            return GetByKeyCode(keyCode, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, string sort_, TransactionManager tm_)
        {
            return await GetByKeyCodeAsync(keyCode, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 KeyCode（字段） 查询
        /// </summary>
        /// /// <param name = "keyCode">mobile、email、random</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByKeyCode(string keyCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`KeyCode` = @KeyCode", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByKeyCodeAsync(string keyCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`KeyCode` = @KeyCode", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@KeyCode", keyCode, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByKeyCode
        #region GetByAccountType

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType)
        {
            return GetByAccountType(accountType, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType)
        {
            return await GetByAccountTypeAsync(accountType, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, TransactionManager tm_)
        {
            return GetByAccountType(accountType, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, TransactionManager tm_)
        {
            return await GetByAccountTypeAsync(accountType, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, int top_)
        {
            return GetByAccountType(accountType, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, int top_)
        {
            return await GetByAccountTypeAsync(accountType, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, int top_, TransactionManager tm_)
        {
            return GetByAccountType(accountType, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, int top_, TransactionManager tm_)
        {
            return await GetByAccountTypeAsync(accountType, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, string sort_)
        {
            return GetByAccountType(accountType, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, string sort_)
        {
            return await GetByAccountTypeAsync(accountType, 0, sort_, null);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, string sort_, TransactionManager tm_)
        {
            return GetByAccountType(accountType, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, string sort_, TransactionManager tm_)
        {
            return await GetByAccountTypeAsync(accountType, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 AccountType（字段） 查询
        /// </summary>
        /// /// <param name = "accountType">开户类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountType(string accountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountType != null ? "`AccountType` = @AccountType" : "`AccountType` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountType != null)
                paras_.Add(Database.CreateInParameter("@AccountType", accountType, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountTypeAsync(string accountType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountType != null ? "`AccountType` = @AccountType" : "`AccountType` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountType != null)
                paras_.Add(Database.CreateInParameter("@AccountType", accountType, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByAccountType
        #region GetByName

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name)
        {
            return GetByName(name, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name)
        {
            return await GetByNameAsync(name, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, TransactionManager tm_)
        {
            return GetByName(name, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, TransactionManager tm_)
        {
            return await GetByNameAsync(name, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, int top_)
        {
            return GetByName(name, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, int top_)
        {
            return await GetByNameAsync(name, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, int top_, TransactionManager tm_)
        {
            return GetByName(name, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, int top_, TransactionManager tm_)
        {
            return await GetByNameAsync(name, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, string sort_)
        {
            return GetByName(name, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, string sort_)
        {
            return await GetByNameAsync(name, 0, sort_, null);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, string sort_, TransactionManager tm_)
        {
            return GetByName(name, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, string sort_, TransactionManager tm_)
        {
            return await GetByNameAsync(name, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 Name（字段） 查询
        /// </summary>
        /// /// <param name = "name">使用者名称</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByName(string name, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (name != null)
                paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByNameAsync(string name, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (name != null)
                paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByName
        #region GetByOwnerType

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType)
        {
            return GetByOwnerType(ownerType, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType)
        {
            return await GetByOwnerTypeAsync(ownerType, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, TransactionManager tm_)
        {
            return GetByOwnerType(ownerType, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, TransactionManager tm_)
        {
            return await GetByOwnerTypeAsync(ownerType, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, int top_)
        {
            return GetByOwnerType(ownerType, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, int top_)
        {
            return await GetByOwnerTypeAsync(ownerType, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, int top_, TransactionManager tm_)
        {
            return GetByOwnerType(ownerType, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, int top_, TransactionManager tm_)
        {
            return await GetByOwnerTypeAsync(ownerType, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, string sort_)
        {
            return GetByOwnerType(ownerType, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, string sort_)
        {
            return await GetByOwnerTypeAsync(ownerType, 0, sort_, null);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, string sort_, TransactionManager tm_)
        {
            return GetByOwnerType(ownerType, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, string sort_, TransactionManager tm_)
        {
            return await GetByOwnerTypeAsync(ownerType, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 OwnerType（字段） 查询
        /// </summary>
        /// /// <param name = "ownerType">所有者类型</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByOwnerType(string ownerType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(ownerType != null ? "`OwnerType` = @OwnerType" : "`OwnerType` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (ownerType != null)
                paras_.Add(Database.CreateInParameter("@OwnerType", ownerType, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByOwnerTypeAsync(string ownerType, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(ownerType != null ? "`OwnerType` = @OwnerType" : "`OwnerType` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (ownerType != null)
                paras_.Add(Database.CreateInParameter("@OwnerType", ownerType, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByOwnerType
        #region GetByBankName

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName)
        {
            return GetByBankName(bankName, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName)
        {
            return await GetByBankNameAsync(bankName, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, TransactionManager tm_)
        {
            return GetByBankName(bankName, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, TransactionManager tm_)
        {
            return await GetByBankNameAsync(bankName, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, int top_)
        {
            return GetByBankName(bankName, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, int top_)
        {
            return await GetByBankNameAsync(bankName, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, int top_, TransactionManager tm_)
        {
            return GetByBankName(bankName, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, int top_, TransactionManager tm_)
        {
            return await GetByBankNameAsync(bankName, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, string sort_)
        {
            return GetByBankName(bankName, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, string sort_)
        {
            return await GetByBankNameAsync(bankName, 0, sort_, null);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, string sort_, TransactionManager tm_)
        {
            return GetByBankName(bankName, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, string sort_, TransactionManager tm_)
        {
            return await GetByBankNameAsync(bankName, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BankName（字段） 查询
        /// </summary>
        /// /// <param name = "bankName">银行名称</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankName(string bankName, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (bankName != null)
                paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankNameAsync(string bankName, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (bankName != null)
                paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByBankName
        #region GetByBankCode

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode)
        {
            return GetByBankCode(bankCode, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode)
        {
            return await GetByBankCodeAsync(bankCode, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, TransactionManager tm_)
        {
            return GetByBankCode(bankCode, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, TransactionManager tm_)
        {
            return await GetByBankCodeAsync(bankCode, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, int top_)
        {
            return GetByBankCode(bankCode, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, int top_)
        {
            return await GetByBankCodeAsync(bankCode, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, int top_, TransactionManager tm_)
        {
            return GetByBankCode(bankCode, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, int top_, TransactionManager tm_)
        {
            return await GetByBankCodeAsync(bankCode, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, string sort_)
        {
            return GetByBankCode(bankCode, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, string sort_)
        {
            return await GetByBankCodeAsync(bankCode, 0, sort_, null);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, string sort_, TransactionManager tm_)
        {
            return GetByBankCode(bankCode, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, string sort_, TransactionManager tm_)
        {
            return await GetByBankCodeAsync(bankCode, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BankCode（字段） 查询
        /// </summary>
        /// /// <param name = "bankCode">银行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBankCode(string bankCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (bankCode != null)
                paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBankCodeAsync(string bankCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (bankCode != null)
                paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByBankCode
        #region GetByBranchCode

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode)
        {
            return GetByBranchCode(branchCode, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode)
        {
            return await GetByBranchCodeAsync(branchCode, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, TransactionManager tm_)
        {
            return GetByBranchCode(branchCode, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, TransactionManager tm_)
        {
            return await GetByBranchCodeAsync(branchCode, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, int top_)
        {
            return GetByBranchCode(branchCode, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, int top_)
        {
            return await GetByBranchCodeAsync(branchCode, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, int top_, TransactionManager tm_)
        {
            return GetByBranchCode(branchCode, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, int top_, TransactionManager tm_)
        {
            return await GetByBranchCodeAsync(branchCode, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, string sort_)
        {
            return GetByBranchCode(branchCode, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, string sort_)
        {
            return await GetByBranchCodeAsync(branchCode, 0, sort_, null);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, string sort_, TransactionManager tm_)
        {
            return GetByBranchCode(branchCode, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, string sort_, TransactionManager tm_)
        {
            return await GetByBranchCodeAsync(branchCode, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 BranchCode（字段） 查询
        /// </summary>
        /// /// <param name = "branchCode">支行编码</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByBranchCode(string branchCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(branchCode != null ? "`BranchCode` = @BranchCode" : "`BranchCode` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (branchCode != null)
                paras_.Add(Database.CreateInParameter("@BranchCode", branchCode, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByBranchCodeAsync(string branchCode, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(branchCode != null ? "`BranchCode` = @BranchCode" : "`BranchCode` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (branchCode != null)
                paras_.Add(Database.CreateInParameter("@BranchCode", branchCode, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByBranchCode
        #region GetByAccountNumber

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber)
        {
            return GetByAccountNumber(accountNumber, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber)
        {
            return await GetByAccountNumberAsync(accountNumber, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, TransactionManager tm_)
        {
            return GetByAccountNumber(accountNumber, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, TransactionManager tm_)
        {
            return await GetByAccountNumberAsync(accountNumber, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, int top_)
        {
            return GetByAccountNumber(accountNumber, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, int top_)
        {
            return await GetByAccountNumberAsync(accountNumber, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, int top_, TransactionManager tm_)
        {
            return GetByAccountNumber(accountNumber, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, int top_, TransactionManager tm_)
        {
            return await GetByAccountNumberAsync(accountNumber, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, string sort_)
        {
            return GetByAccountNumber(accountNumber, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, string sort_)
        {
            return await GetByAccountNumberAsync(accountNumber, 0, sort_, null);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, string sort_, TransactionManager tm_)
        {
            return GetByAccountNumber(accountNumber, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, string sort_, TransactionManager tm_)
        {
            return await GetByAccountNumberAsync(accountNumber, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 AccountNumber（字段） 查询
        /// </summary>
        /// /// <param name = "accountNumber">银行卡号</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountNumber(string accountNumber, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountNumber != null ? "`AccountNumber` = @AccountNumber" : "`AccountNumber` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountNumber != null)
                paras_.Add(Database.CreateInParameter("@AccountNumber", accountNumber, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountNumberAsync(string accountNumber, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountNumber != null ? "`AccountNumber` = @AccountNumber" : "`AccountNumber` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountNumber != null)
                paras_.Add(Database.CreateInParameter("@AccountNumber", accountNumber, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByAccountNumber
        #region GetByAccountStatus

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus)
        {
            return GetByAccountStatus(accountStatus, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus)
        {
            return await GetByAccountStatusAsync(accountStatus, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, TransactionManager tm_)
        {
            return GetByAccountStatus(accountStatus, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, TransactionManager tm_)
        {
            return await GetByAccountStatusAsync(accountStatus, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, int top_)
        {
            return GetByAccountStatus(accountStatus, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, int top_)
        {
            return await GetByAccountStatusAsync(accountStatus, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, int top_, TransactionManager tm_)
        {
            return GetByAccountStatus(accountStatus, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, int top_, TransactionManager tm_)
        {
            return await GetByAccountStatusAsync(accountStatus, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, string sort_)
        {
            return GetByAccountStatus(accountStatus, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, string sort_)
        {
            return await GetByAccountStatusAsync(accountStatus, 0, sort_, null);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, string sort_, TransactionManager tm_)
        {
            return GetByAccountStatus(accountStatus, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, string sort_, TransactionManager tm_)
        {
            return await GetByAccountStatusAsync(accountStatus, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 AccountStatus（字段） 查询
        /// </summary>
        /// /// <param name = "accountStatus">开户状态</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByAccountStatus(string accountStatus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountStatus != null ? "`AccountStatus` = @AccountStatus" : "`AccountStatus` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountStatus != null)
                paras_.Add(Database.CreateInParameter("@AccountStatus", accountStatus, MySqlDbType.VarChar));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByAccountStatusAsync(string accountStatus, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL(accountStatus != null ? "`AccountStatus` = @AccountStatus" : "`AccountStatus` IS NULL", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            if (accountStatus != null)
                paras_.Add(Database.CreateInParameter("@AccountStatus", accountStatus, MySqlDbType.VarChar));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByAccountStatus
        #region GetByLastUsing

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing)
        {
            return GetByLastUsing(lastUsing, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing)
        {
            return await GetByLastUsingAsync(lastUsing, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, TransactionManager tm_)
        {
            return GetByLastUsing(lastUsing, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, TransactionManager tm_)
        {
            return await GetByLastUsingAsync(lastUsing, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, int top_)
        {
            return GetByLastUsing(lastUsing, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, int top_)
        {
            return await GetByLastUsingAsync(lastUsing, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, int top_, TransactionManager tm_)
        {
            return GetByLastUsing(lastUsing, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, int top_, TransactionManager tm_)
        {
            return await GetByLastUsingAsync(lastUsing, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, string sort_)
        {
            return GetByLastUsing(lastUsing, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, string sort_)
        {
            return await GetByLastUsingAsync(lastUsing, 0, sort_, null);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, string sort_, TransactionManager tm_)
        {
            return GetByLastUsing(lastUsing, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, string sort_, TransactionManager tm_)
        {
            return await GetByLastUsingAsync(lastUsing, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 LastUsing（字段） 查询
        /// </summary>
        /// /// <param name = "lastUsing">最后充值、提现使用的卡</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByLastUsing(bool lastUsing, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`LastUsing` = @LastUsing", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByLastUsingAsync(bool lastUsing, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`LastUsing` = @LastUsing", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@LastUsing", lastUsing, MySqlDbType.Byte));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByLastUsing
        #region GetByRecDate

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate)
        {
            return GetByRecDate(recDate, 0, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, int top_)
        {
            return GetByRecDate(recDate, top_, string.Empty, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, int top_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, top_, string.Empty, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, string sort_)
        {
            return GetByRecDate(recDate, 0, sort_, null);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, string sort_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, null);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return GetByRecDate(recDate, 0, sort_, tm_);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
        {
            return await GetByRecDateAsync(recDate, 0, sort_, tm_);
        }

        /// <summary>
        /// 按 RecDate（字段） 查询
        /// </summary>
        /// /// <param name = "recDate">创建时间</param>
        /// <param name = "top_">获取行数</param>
        /// <param name = "sort_">排序表达式</param>
        /// <param name="tm_">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<L_bra_user_bankEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return Database.ExecSqlList(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        public async Task<List<L_bra_user_bankEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
        {
            var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
            var paras_ = new List<MySqlParameter>();
            paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
            return await Database.ExecSqlListAsync(sql_, paras_, tm_, L_bra_user_bankEO.MapDataReader);
        }
        #endregion // GetByRecDate
        #endregion // GetByXXX
        #endregion // Get
    }
    #endregion // MO
}
