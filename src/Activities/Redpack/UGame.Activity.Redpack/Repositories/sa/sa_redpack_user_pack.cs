/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-21 17: 38:09
 ******************************************************/

using System.Data;
using System.Runtime.Serialization;
using System.Text;
using MySql.Data.MySqlClient;
using TinyFx;
using TinyFx.Data;
using TinyFx.Data.MySql;

namespace UGame.Activity.Redpack.Repositories.sa
{
	#region EO
	/// <summary>
	/// 用户红包记录
	/// 【表 sa_redpack_user_pack 的实体类】
	/// </summary>
	[DataContract]
	public class Sa_redpack_user_packEO : IRowMapper<Sa_redpack_user_packEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sa_redpack_user_packEO()
		{
			this.FromMode = 0;
			this.UserKind = 0;
			this.PackAmount = 0;
			this.CurrAmount = 0;
			this.RemainCount = 0;
			this.PackFlag = 0;
			this.BetAmount = 0;
			this.PayAmount = 0;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalPackID;
		/// <summary>
		/// 【数据库中的原始主键 PackID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalPackID
		{
			get { return _originalPackID; }
			set { HasOriginal = true; _originalPackID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "PackID", PackID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 编码objectID
		/// 【主键 varchar(38)】
		/// </summary>
		[DataMember(Order = 1)]
		public string PackID { get; set; }
		/// <summary>
		/// 用户主键
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 2)]
		public string UserID { get; set; }
		/// <summary>
		/// 应用提供商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 3)]
		public string ProviderID { get; set; }
		/// <summary>
		/// 应用编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 4)]
		public string AppID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 5)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 新用户来源方式
		///              0-获得运营商的新用户(s_operator)
		///              1-推广员获得的新用户（userid）uid=xxx
		///              2-推广渠道通过url获得的新用户（s_channel)  cid=xxx
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 6)]
		public int FromMode { get; set; }
		/// <summary>
		/// 对应的编码（根据FromMode变化）
		///              FromMode=
		///              0-运营商的新用户(s_operator)==> OperatorID
		///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
		///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
		///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 7)]
		public string FromId { get; set; }
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
		[DataMember(Order = 8)]
		public int UserKind { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 9)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币类型（货币缩写RMB,USD）
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 10)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 红包过期-时效
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 11)]
		public int Expire { get; set; }
		/// <summary>
		/// 每个红包金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 12)]
		public long PackAmount { get; set; }
		/// <summary>
		/// 当前红包金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 13)]
		public long CurrAmount { get; set; }
		/// <summary>
		/// 剩余次数
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 14)]
		public int RemainCount { get; set; }
		/// <summary>
		/// 是否提现
		/// 【字段 tinyint】
		/// </summary>
		[DataMember(Order = 15)]
		public int IsWidthdraw { get; set; }
		/// <summary>
		/// 红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 16)]
		public int PackFlag { get; set; }
		/// <summary>
		/// 下注总记录数
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 17)]
		public long BetAmount { get; set; }
		/// <summary>
		/// 充值流水总数
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 18)]
		public long PayAmount { get; set; }
		/// <summary>
		/// 记录时间
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
		public Sa_redpack_user_packEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sa_redpack_user_packEO MapDataReader(IDataReader reader)
		{
		    Sa_redpack_user_packEO ret = new Sa_redpack_user_packEO();
			ret.PackID = reader.ToString("PackID");
			ret.OriginalPackID = ret.PackID;
			ret.UserID = reader.ToString("UserID");
			ret.ProviderID = reader.ToString("ProviderID");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.FromMode = reader.ToInt32("FromMode");
			ret.FromId = reader.ToString("FromId");
			ret.UserKind = reader.ToInt32("UserKind");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.Expire = reader.ToInt32("Expire");
			ret.PackAmount = reader.ToInt64("PackAmount");
			ret.CurrAmount = reader.ToInt64("CurrAmount");
			ret.RemainCount = reader.ToInt32("RemainCount");
			ret.IsWidthdraw = reader.ToInt32("IsWidthdraw");
			ret.PackFlag = reader.ToInt32("PackFlag");
			ret.BetAmount = reader.ToInt64("BetAmount");
			ret.PayAmount = reader.ToInt64("PayAmount");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 用户红包记录
	/// 【表 sa_redpack_user_pack 的操作类】
	/// </summary>
	public class Sa_redpack_user_packMO : MySqlTableMO<Sa_redpack_user_packEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sa_redpack_user_pack`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sa_redpack_user_packMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sa_redpack_user_packMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sa_redpack_user_packMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sa_redpack_user_packEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sa_redpack_user_packEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sa_redpack_user_packEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`PackID`, `UserID`, `ProviderID`, `AppID`, `OperatorID`, `FromMode`, `FromId`, `UserKind`, `CountryID`, `CurrencyID`, `Expire`, `PackAmount`, `CurrAmount`, `RemainCount`, `IsWidthdraw`, `PackFlag`, `BetAmount`, `PayAmount`, `RecDate`) VALUE (@PackID, @UserID, @ProviderID, @AppID, @OperatorID, @FromMode, @FromId, @UserKind, @CountryID, @CurrencyID, @Expire, @PackAmount, @CurrAmount, @RemainCount, @IsWidthdraw, @PackFlag, @BetAmount, @PayAmount, @RecDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Expire", item.Expire, MySqlDbType.Int32),
				Database.CreateInParameter("@PackAmount", item.PackAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CurrAmount", item.CurrAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@RemainCount", item.RemainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@IsWidthdraw", item.IsWidthdraw, MySqlDbType.Byte),
				Database.CreateInParameter("@PackFlag", item.PackFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@BetAmount", item.BetAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayAmount", item.PayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sa_redpack_user_packEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sa_redpack_user_packEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_redpack_user_packEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`PackID`, `UserID`, `ProviderID`, `AppID`, `OperatorID`, `FromMode`, `FromId`, `UserKind`, `CountryID`, `CurrencyID`, `Expire`, `PackAmount`, `CurrAmount`, `RemainCount`, `IsWidthdraw`, `PackFlag`, `BetAmount`, `PayAmount`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.PackID}','{item.UserID}','{item.ProviderID}','{item.AppID}','{item.OperatorID}',{item.FromMode},'{item.FromId}',{item.UserKind},'{item.CountryID}','{item.CurrencyID}',{item.Expire},{item.PackAmount},{item.CurrAmount},{item.RemainCount},{item.IsWidthdraw},{item.PackFlag},{item.BetAmount},{item.PayAmount},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string packID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(packID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string packID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(packID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string packID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sa_redpack_user_packEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.PackID, tm_);
		}
		public async Task<int> RemoveAsync(Sa_redpack_user_packEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.PackID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByUserID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
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
		#region RemoveByProviderID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByProviderID(string providerID, TransactionManager tm_ = null)
		{
			RepairRemoveByProviderIDData(providerID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByProviderIDAsync(string providerID, TransactionManager tm_ = null)
		{
			RepairRemoveByProviderIDData(providerID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByProviderIDData(string providerID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ProviderID` = @ProviderID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByProviderID
		#region RemoveByAppID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppID(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppIDData(string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AppID` = @AppID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppID
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
			sql_ = $"DELETE FROM {TableName} WHERE `FromId` = @FromId";
			paras_ = new List<MySqlParameter>();
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
			sql_ = $"DELETE FROM {TableName} WHERE `CountryID` = @CountryID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCountryID
		#region RemoveByCurrencyID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
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
		#region RemoveByExpire
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByExpire(int expire, TransactionManager tm_ = null)
		{
			RepairRemoveByExpireData(expire, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByExpireAsync(int expire, TransactionManager tm_ = null)
		{
			RepairRemoveByExpireData(expire, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByExpireData(int expire, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Expire` = @Expire";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32));
		}
		#endregion // RemoveByExpire
		#region RemoveByPackAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPackAmount(long packAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPackAmountData(packAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPackAmountAsync(long packAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPackAmountData(packAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPackAmountData(long packAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PackAmount` = @PackAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByPackAmount
		#region RemoveByCurrAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCurrAmount(long currAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrAmountData(currAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCurrAmountAsync(long currAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrAmountData(currAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCurrAmountData(long currAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CurrAmount` = @CurrAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByCurrAmount
		#region RemoveByRemainCount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRemainCount(int remainCount, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainCountData(remainCount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRemainCountAsync(int remainCount, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainCountData(remainCount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRemainCountData(int remainCount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RemainCount` = @RemainCount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32));
		}
		#endregion // RemoveByRemainCount
		#region RemoveByIsWidthdraw
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsWidthdraw(int isWidthdraw, TransactionManager tm_ = null)
		{
			RepairRemoveByIsWidthdrawData(isWidthdraw, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsWidthdrawAsync(int isWidthdraw, TransactionManager tm_ = null)
		{
			RepairRemoveByIsWidthdrawData(isWidthdraw, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsWidthdrawData(int isWidthdraw, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsWidthdraw` = @IsWidthdraw";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsWidthdraw
		#region RemoveByPackFlag
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPackFlag(int packFlag, TransactionManager tm_ = null)
		{
			RepairRemoveByPackFlagData(packFlag, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPackFlagAsync(int packFlag, TransactionManager tm_ = null)
		{
			RepairRemoveByPackFlagData(packFlag, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPackFlagData(int packFlag, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PackFlag` = @PackFlag";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32));
		}
		#endregion // RemoveByPackFlag
		#region RemoveByBetAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBetAmount(long betAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetAmountData(betAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBetAmountAsync(long betAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetAmountData(betAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBetAmountData(long betAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BetAmount` = @BetAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBetAmount
		#region RemoveByPayAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayAmount(long payAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayAmountData(payAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayAmountAsync(long payAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayAmountData(payAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayAmountData(long payAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayAmount` = @PayAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByPayAmount
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
		public int Put(Sa_redpack_user_packEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sa_redpack_user_packEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sa_redpack_user_packEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PackID` = @PackID, `UserID` = @UserID, `ProviderID` = @ProviderID, `AppID` = @AppID, `OperatorID` = @OperatorID, `FromMode` = @FromMode, `FromId` = @FromId, `UserKind` = @UserKind, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `Expire` = @Expire, `PackAmount` = @PackAmount, `CurrAmount` = @CurrAmount, `RemainCount` = @RemainCount, `IsWidthdraw` = @IsWidthdraw, `PackFlag` = @PackFlag, `BetAmount` = @BetAmount, `PayAmount` = @PayAmount WHERE `PackID` = @PackID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Expire", item.Expire, MySqlDbType.Int32),
				Database.CreateInParameter("@PackAmount", item.PackAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CurrAmount", item.CurrAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@RemainCount", item.RemainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@IsWidthdraw", item.IsWidthdraw, MySqlDbType.Byte),
				Database.CreateInParameter("@PackFlag", item.PackFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@BetAmount", item.BetAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayAmount", item.PayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PackID_Original", item.HasOriginal ? item.OriginalPackID : item.PackID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sa_redpack_user_packEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sa_redpack_user_packEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string packID, string set_, params object[] values_)
		{
			return Put(set_, "`PackID` = @PackID", ConcatValues(values_, packID));
		}
		public async Task<int> PutByPKAsync(string packID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`PackID` = @PackID", ConcatValues(values_, packID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string packID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`PackID` = @PackID", tm_, ConcatValues(values_, packID));
		}
		public async Task<int> PutByPKAsync(string packID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`PackID` = @PackID", tm_, ConcatValues(values_, packID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string packID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`PackID` = @PackID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string packID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`PackID` = @PackID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "userID">用户主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIDByPK(string packID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(packID, userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIDByPKAsync(string packID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(packID, userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIDByPKData(string packID, string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
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
		#region PutProviderID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProviderIDByPK(string packID, string providerID, TransactionManager tm_ = null)
		{
			RepairPutProviderIDByPKData(packID, providerID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutProviderIDByPKAsync(string packID, string providerID, TransactionManager tm_ = null)
		{
			RepairPutProviderIDByPKData(packID, providerID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutProviderIDByPKData(string packID, string providerID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProviderID(string providerID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID";
			var parameter_ = Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutProviderIDAsync(string providerID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID";
			var parameter_ = Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutProviderID
		#region PutAppID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppIDByPK(string packID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(packID, appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppIDByPKAsync(string packID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(packID, appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppIDByPKData(string packID, string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppID` = @AppID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppID(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppID
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(string packID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(packID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(string packID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(packID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(string packID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
		#region PutFromMode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromModeByPK(string packID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(packID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromModeByPKAsync(string packID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(packID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromModeByPKData(string packID, int fromMode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromIdByPK(string packID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(packID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromIdByPKAsync(string packID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(packID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromIdByPKData(string packID, string fromId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromId` = @FromId  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
			var parameter_ = Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFromIdAsync(string fromId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FromId` = @FromId";
			var parameter_ = Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFromId
		#region PutUserKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserKindByPK(string packID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(packID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserKindByPKAsync(string packID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(packID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserKindByPKData(string packID, int userKind, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(string packID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(packID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(string packID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(packID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(string packID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(string packID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(packID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(string packID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(packID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(string packID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
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
		#region PutExpire
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExpireByPK(string packID, int expire, TransactionManager tm_ = null)
		{
			RepairPutExpireByPKData(packID, expire, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutExpireByPKAsync(string packID, int expire, TransactionManager tm_ = null)
		{
			RepairPutExpireByPKData(packID, expire, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutExpireByPKData(string packID, int expire, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Expire` = @Expire  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExpire(int expire, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Expire` = @Expire";
			var parameter_ = Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutExpireAsync(int expire, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Expire` = @Expire";
			var parameter_ = Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutExpire
		#region PutPackAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackAmountByPK(string packID, long packAmount, TransactionManager tm_ = null)
		{
			RepairPutPackAmountByPKData(packID, packAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPackAmountByPKAsync(string packID, long packAmount, TransactionManager tm_ = null)
		{
			RepairPutPackAmountByPKData(packID, packAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPackAmountByPKData(string packID, long packAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PackAmount` = @PackAmount  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackAmount(long packAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackAmount` = @PackAmount";
			var parameter_ = Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPackAmountAsync(long packAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackAmount` = @PackAmount";
			var parameter_ = Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPackAmount
		#region PutCurrAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrAmountByPK(string packID, long currAmount, TransactionManager tm_ = null)
		{
			RepairPutCurrAmountByPKData(packID, currAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrAmountByPKAsync(string packID, long currAmount, TransactionManager tm_ = null)
		{
			RepairPutCurrAmountByPKData(packID, currAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrAmountByPKData(string packID, long currAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrAmount` = @CurrAmount  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrAmount(long currAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrAmount` = @CurrAmount";
			var parameter_ = Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrAmountAsync(long currAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrAmount` = @CurrAmount";
			var parameter_ = Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrAmount
		#region PutRemainCount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainCountByPK(string packID, int remainCount, TransactionManager tm_ = null)
		{
			RepairPutRemainCountByPKData(packID, remainCount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRemainCountByPKAsync(string packID, int remainCount, TransactionManager tm_ = null)
		{
			RepairPutRemainCountByPKData(packID, remainCount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRemainCountByPKData(string packID, int remainCount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RemainCount` = @RemainCount  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainCount(int remainCount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainCount` = @RemainCount";
			var parameter_ = Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRemainCountAsync(int remainCount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainCount` = @RemainCount";
			var parameter_ = Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRemainCount
		#region PutIsWidthdraw
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsWidthdrawByPK(string packID, int isWidthdraw, TransactionManager tm_ = null)
		{
			RepairPutIsWidthdrawByPKData(packID, isWidthdraw, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsWidthdrawByPKAsync(string packID, int isWidthdraw, TransactionManager tm_ = null)
		{
			RepairPutIsWidthdrawByPKData(packID, isWidthdraw, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsWidthdrawByPKData(string packID, int isWidthdraw, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsWidthdraw` = @IsWidthdraw  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsWidthdraw(int isWidthdraw, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsWidthdraw` = @IsWidthdraw";
			var parameter_ = Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsWidthdrawAsync(int isWidthdraw, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsWidthdraw` = @IsWidthdraw";
			var parameter_ = Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsWidthdraw
		#region PutPackFlag
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackFlagByPK(string packID, int packFlag, TransactionManager tm_ = null)
		{
			RepairPutPackFlagByPKData(packID, packFlag, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPackFlagByPKAsync(string packID, int packFlag, TransactionManager tm_ = null)
		{
			RepairPutPackFlagByPKData(packID, packFlag, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPackFlagByPKData(string packID, int packFlag, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PackFlag` = @PackFlag  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackFlag(int packFlag, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackFlag` = @PackFlag";
			var parameter_ = Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPackFlagAsync(int packFlag, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackFlag` = @PackFlag";
			var parameter_ = Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPackFlag
		#region PutBetAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetAmountByPK(string packID, long betAmount, TransactionManager tm_ = null)
		{
			RepairPutBetAmountByPKData(packID, betAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBetAmountByPKAsync(string packID, long betAmount, TransactionManager tm_ = null)
		{
			RepairPutBetAmountByPKData(packID, betAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBetAmountByPKData(string packID, long betAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BetAmount` = @BetAmount  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetAmount(long betAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetAmount` = @BetAmount";
			var parameter_ = Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBetAmountAsync(long betAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetAmount` = @BetAmount";
			var parameter_ = Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBetAmount
		#region PutPayAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayAmountByPK(string packID, long payAmount, TransactionManager tm_ = null)
		{
			RepairPutPayAmountByPKData(packID, payAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayAmountByPKAsync(string packID, long payAmount, TransactionManager tm_ = null)
		{
			RepairPutPayAmountByPKData(packID, payAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayAmountByPKData(string packID, long payAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayAmount` = @PayAmount  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayAmount(long payAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayAmount` = @PayAmount";
			var parameter_ = Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayAmountAsync(long payAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayAmount` = @PayAmount";
			var parameter_ = Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayAmount
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string packID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(packID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string packID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(packID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string packID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sa_redpack_user_packEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.PackID) == null)
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
		public async Task<bool> SetAsync(Sa_redpack_user_packEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.PackID) == null)
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
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sa_redpack_user_packEO GetByPK(string packID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(packID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<Sa_redpack_user_packEO> GetByPKAsync(string packID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(packID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		private void RepairGetByPKData(string packID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			if (isForUpdate_ && tm_ != null && tm_.IsolationLevel > IsolationLevel.ReadCommitted)
				throw new Exception("for update时，IsolationLevel不能大于ReadCommitted");
			sql_ = BuildSelectSQL("`PackID` = @PackID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ProviderID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetProviderIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`ProviderID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetProviderIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`ProviderID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetAppIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromMode（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetFromModeByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`FromMode`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetFromModeByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`FromMode`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromId（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetFromIdByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`FromId`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetFromIdByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`FromId`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserKind（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetUserKindByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`UserKind`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetUserKindByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`UserKind`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CurrencyID`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Expire（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetExpireByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Expire`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetExpireByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Expire`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PackAmount（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPackAmountByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`PackAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetPackAmountByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`PackAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrAmount（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCurrAmountByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CurrAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetCurrAmountByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CurrAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RemainCount（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetRemainCountByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`RemainCount`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetRemainCountByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`RemainCount`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsWidthdraw（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetIsWidthdrawByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`IsWidthdraw`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetIsWidthdrawByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`IsWidthdraw`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PackFlag（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetPackFlagByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`PackFlag`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetPackFlagByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`PackFlag`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BetAmount（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBetAmountByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`BetAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetBetAmountByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`BetAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayAmount（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPayAmountByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`PayAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetPayAmountByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`PayAmount`", "`PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`PackID` = @PackID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`PackID` = @PackID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, int top_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, string sort_)
		{
			return await GetByUserIDAsync(userID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByProviderID
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID)
		{
			return GetByProviderID(providerID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, int top_)
		{
			return GetByProviderID(providerID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, int top_)
		{
			return await GetByProviderIDAsync(providerID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, int top_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, int top_, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, string sort_)
		{
			return GetByProviderID(providerID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, string sort_)
		{
			return await GetByProviderIDAsync(providerID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, string sort_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, string sort_, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByProviderID(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ProviderID` = @ProviderID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByProviderIDAsync(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ProviderID` = @ProviderID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByProviderID
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, int top_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, string sort_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AppID` = @AppID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AppID` = @AppID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByFromMode
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode)
		{
			return GetByFromMode(fromMode, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, int top_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, int top_)
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
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, int top_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, int top_, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, string sort_)
		{
			return GetByFromMode(fromMode, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, string sort_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByFromMode(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromModeAsync(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByFromMode
		#region GetByFromId
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId)
		{
			return GetByFromId(fromId, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, int top_)
		{
			return GetByFromId(fromId, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, int top_)
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
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, int top_, TransactionManager tm_)
		{
			return GetByFromId(fromId, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, int top_, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, string sort_)
		{
			return GetByFromId(fromId, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, string sort_, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByFromId(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromId` = @FromId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByFromIdAsync(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromId` = @FromId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByFromId
		#region GetByUserKind
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind)
		{
			return GetByUserKind(userKind, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, int top_)
		{
			return GetByUserKind(userKind, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, int top_)
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
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, string sort_)
		{
			return GetByUserKind(userKind, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByUserKind
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByExpire
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire)
		{
			return GetByExpire(expire, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire)
		{
			return await GetByExpireAsync(expire, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, TransactionManager tm_)
		{
			return GetByExpire(expire, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, TransactionManager tm_)
		{
			return await GetByExpireAsync(expire, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, int top_)
		{
			return GetByExpire(expire, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, int top_)
		{
			return await GetByExpireAsync(expire, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, int top_, TransactionManager tm_)
		{
			return GetByExpire(expire, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, int top_, TransactionManager tm_)
		{
			return await GetByExpireAsync(expire, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, string sort_)
		{
			return GetByExpire(expire, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, string sort_)
		{
			return await GetByExpireAsync(expire, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, string sort_, TransactionManager tm_)
		{
			return GetByExpire(expire, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, string sort_, TransactionManager tm_)
		{
			return await GetByExpireAsync(expire, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Expire（字段） 查询
		/// </summary>
		/// /// <param name = "expire">红包过期-时效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByExpire(int expire, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Expire` = @Expire", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByExpireAsync(int expire, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Expire` = @Expire", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Expire", expire, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByExpire
		#region GetByPackAmount
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount)
		{
			return GetByPackAmount(packAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount)
		{
			return await GetByPackAmountAsync(packAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, TransactionManager tm_)
		{
			return GetByPackAmount(packAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, TransactionManager tm_)
		{
			return await GetByPackAmountAsync(packAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, int top_)
		{
			return GetByPackAmount(packAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, int top_)
		{
			return await GetByPackAmountAsync(packAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, int top_, TransactionManager tm_)
		{
			return GetByPackAmount(packAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, int top_, TransactionManager tm_)
		{
			return await GetByPackAmountAsync(packAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, string sort_)
		{
			return GetByPackAmount(packAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, string sort_)
		{
			return await GetByPackAmountAsync(packAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, string sort_, TransactionManager tm_)
		{
			return GetByPackAmount(packAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPackAmountAsync(packAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PackAmount（字段） 查询
		/// </summary>
		/// /// <param name = "packAmount">每个红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackAmount(long packAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackAmount` = @PackAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackAmountAsync(long packAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackAmount` = @PackAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackAmount", packAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByPackAmount
		#region GetByCurrAmount
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount)
		{
			return GetByCurrAmount(currAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount)
		{
			return await GetByCurrAmountAsync(currAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, TransactionManager tm_)
		{
			return GetByCurrAmount(currAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, TransactionManager tm_)
		{
			return await GetByCurrAmountAsync(currAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, int top_)
		{
			return GetByCurrAmount(currAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, int top_)
		{
			return await GetByCurrAmountAsync(currAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, int top_, TransactionManager tm_)
		{
			return GetByCurrAmount(currAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, int top_, TransactionManager tm_)
		{
			return await GetByCurrAmountAsync(currAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, string sort_)
		{
			return GetByCurrAmount(currAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, string sort_)
		{
			return await GetByCurrAmountAsync(currAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, string sort_, TransactionManager tm_)
		{
			return GetByCurrAmount(currAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, string sort_, TransactionManager tm_)
		{
			return await GetByCurrAmountAsync(currAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrAmount（字段） 查询
		/// </summary>
		/// /// <param name = "currAmount">当前红包金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByCurrAmount(long currAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrAmount` = @CurrAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByCurrAmountAsync(long currAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrAmount` = @CurrAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrAmount", currAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByCurrAmount
		#region GetByRemainCount
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount)
		{
			return GetByRemainCount(remainCount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount)
		{
			return await GetByRemainCountAsync(remainCount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, int top_)
		{
			return GetByRemainCount(remainCount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, int top_)
		{
			return await GetByRemainCountAsync(remainCount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, int top_, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, int top_, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, string sort_)
		{
			return GetByRemainCount(remainCount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, string sort_)
		{
			return await GetByRemainCountAsync(remainCount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, string sort_, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, string sort_, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRemainCount(int remainCount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainCount` = @RemainCount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRemainCountAsync(int remainCount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainCount` = @RemainCount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByRemainCount
		#region GetByIsWidthdraw
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw)
		{
			return GetByIsWidthdraw(isWidthdraw, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, TransactionManager tm_)
		{
			return GetByIsWidthdraw(isWidthdraw, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, TransactionManager tm_)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, int top_)
		{
			return GetByIsWidthdraw(isWidthdraw, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, int top_)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, int top_, TransactionManager tm_)
		{
			return GetByIsWidthdraw(isWidthdraw, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, int top_, TransactionManager tm_)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, string sort_)
		{
			return GetByIsWidthdraw(isWidthdraw, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, string sort_)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, string sort_, TransactionManager tm_)
		{
			return GetByIsWidthdraw(isWidthdraw, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, string sort_, TransactionManager tm_)
		{
			return await GetByIsWidthdrawAsync(isWidthdraw, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsWidthdraw（字段） 查询
		/// </summary>
		/// /// <param name = "isWidthdraw">是否提现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByIsWidthdraw(int isWidthdraw, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsWidthdraw` = @IsWidthdraw", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByIsWidthdrawAsync(int isWidthdraw, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsWidthdraw` = @IsWidthdraw", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsWidthdraw", isWidthdraw, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByIsWidthdraw
		#region GetByPackFlag
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag)
		{
			return GetByPackFlag(packFlag, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag)
		{
			return await GetByPackFlagAsync(packFlag, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, TransactionManager tm_)
		{
			return GetByPackFlag(packFlag, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, TransactionManager tm_)
		{
			return await GetByPackFlagAsync(packFlag, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, int top_)
		{
			return GetByPackFlag(packFlag, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, int top_)
		{
			return await GetByPackFlagAsync(packFlag, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, int top_, TransactionManager tm_)
		{
			return GetByPackFlag(packFlag, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, int top_, TransactionManager tm_)
		{
			return await GetByPackFlagAsync(packFlag, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, string sort_)
		{
			return GetByPackFlag(packFlag, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, string sort_)
		{
			return await GetByPackFlagAsync(packFlag, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, string sort_, TransactionManager tm_)
		{
			return GetByPackFlag(packFlag, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, string sort_, TransactionManager tm_)
		{
			return await GetByPackFlagAsync(packFlag, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PackFlag（字段） 查询
		/// </summary>
		/// /// <param name = "packFlag">红包flag 1-手气最佳2-今日之星3-幸运之王4-超级赢家</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPackFlag(int packFlag, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackFlag` = @PackFlag", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPackFlagAsync(int packFlag, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackFlag` = @PackFlag", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackFlag", packFlag, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByPackFlag
		#region GetByBetAmount
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount)
		{
			return GetByBetAmount(betAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount)
		{
			return await GetByBetAmountAsync(betAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, int top_)
		{
			return GetByBetAmount(betAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, int top_)
		{
			return await GetByBetAmountAsync(betAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, int top_, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, int top_, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, string sort_)
		{
			return GetByBetAmount(betAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, string sort_)
		{
			return await GetByBetAmountAsync(betAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, string sort_, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注总记录数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByBetAmount(long betAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetAmount` = @BetAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByBetAmountAsync(long betAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetAmount` = @BetAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByBetAmount
		#region GetByPayAmount
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount)
		{
			return GetByPayAmount(payAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount)
		{
			return await GetByPayAmountAsync(payAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, int top_)
		{
			return GetByPayAmount(payAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, int top_)
		{
			return await GetByPayAmountAsync(payAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, int top_, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, int top_, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, string sort_)
		{
			return GetByPayAmount(payAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, string sort_)
		{
			return await GetByPayAmountAsync(payAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, string sort_, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值流水总数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByPayAmount(long payAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayAmount` = @PayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByPayAmountAsync(long payAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayAmount` = @PayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByPayAmount
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_packEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_packEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_packEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
