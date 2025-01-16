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
	/// 
	/// 【表 sa_redpack_user_task 的实体类】
	/// </summary>
	[DataContract]
	public class Sa_redpack_user_taskEO : IRowMapper<Sa_redpack_user_taskEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sa_redpack_user_taskEO()
		{
			this.ConfigID = "0";
			this.GroupId = 0;
			this.Ratio = 0f;
			this.RemainCount = 0;
			this.RemainAmount = 0;
			this.RecDate = DateTime.Now;
			this.BetAmount = 0;
			this.PayAmount = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalConfigID;
		/// <summary>
		/// 【数据库中的原始主键 ConfigID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalConfigID
		{
			get { return _originalConfigID; }
			set { HasOriginal = true; _originalConfigID = value; }
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
	        return new Dictionary<string, object>() { { "ConfigID", ConfigID },  { "UserID", UserID },  { "PackID", PackID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 主键GUID
		/// 【主键 varchar(36)】
		/// </summary>
		[DataMember(Order = 1)]
		public string ConfigID { get; set; }
		/// <summary>
		/// 用户编码
		/// 【主键 varchar(36)】
		/// </summary>
		[DataMember(Order = 2)]
		public string UserID { get; set; }
		/// <summary>
		/// 红包主键
		/// 【主键 varchar(36)】
		/// </summary>
		[DataMember(Order = 3)]
		public string PackID { get; set; }
		/// <summary>
		/// 分组标志1-新注册2-分享3-下注4-客户端
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 4)]
		public int GroupId { get; set; }
		/// <summary>
		/// 分配概率60%
		/// 【字段 float】
		/// </summary>
		[DataMember(Order = 5)]
		public float Ratio { get; set; }
		/// <summary>
		/// 当前剩余次数
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 6)]
		public int RemainCount { get; set; }
		/// <summary>
		/// 当前剩余金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long RemainAmount { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 8)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// 下注金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 9)]
		public long BetAmount { get; set; }
		/// <summary>
		/// 充值金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 10)]
		public long PayAmount { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sa_redpack_user_taskEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sa_redpack_user_taskEO MapDataReader(IDataReader reader)
		{
		    Sa_redpack_user_taskEO ret = new Sa_redpack_user_taskEO();
			ret.ConfigID = reader.ToString("ConfigID");
			ret.OriginalConfigID = ret.ConfigID;
			ret.UserID = reader.ToString("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.PackID = reader.ToString("PackID");
			ret.OriginalPackID = ret.PackID;
			ret.GroupId = reader.ToInt32("GroupId");
			ret.Ratio = reader.ToSingle("Ratio");
			ret.RemainCount = reader.ToInt32("RemainCount");
			ret.RemainAmount = reader.ToInt64("RemainAmount");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.BetAmount = reader.ToInt64("BetAmount");
			ret.PayAmount = reader.ToInt64("PayAmount");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 
	/// 【表 sa_redpack_user_task 的操作类】
	/// </summary>
	public class Sa_redpack_user_taskMO : MySqlTableMO<Sa_redpack_user_taskEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sa_redpack_user_task`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sa_redpack_user_taskMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sa_redpack_user_taskMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sa_redpack_user_taskMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sa_redpack_user_taskEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sa_redpack_user_taskEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sa_redpack_user_taskEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`ConfigID`, `UserID`, `PackID`, `GroupId`, `Ratio`, `RemainCount`, `RemainAmount`, `RecDate`, `BetAmount`, `PayAmount`) VALUE (@ConfigID, @UserID, @PackID, @GroupId, @Ratio, @RemainCount, @RemainAmount, @RecDate, @BetAmount, @PayAmount);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", item.ConfigID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupId", item.GroupId, MySqlDbType.Int32),
				Database.CreateInParameter("@Ratio", item.Ratio, MySqlDbType.Float),
				Database.CreateInParameter("@RemainCount", item.RemainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@RemainAmount", item.RemainAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@BetAmount", item.BetAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayAmount", item.PayAmount, MySqlDbType.Int64),
			};
		}
		public int AddByBatch(IEnumerable<Sa_redpack_user_taskEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sa_redpack_user_taskEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_redpack_user_taskEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`ConfigID`, `UserID`, `PackID`, `GroupId`, `Ratio`, `RemainCount`, `RemainAmount`, `RecDate`, `BetAmount`, `PayAmount`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.ConfigID}','{item.UserID}','{item.PackID}',{item.GroupId},{item.Ratio},{item.RemainCount},{item.RemainAmount},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.BetAmount},{item.PayAmount}),");
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
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(configID, userID, packID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(configID, userID, packID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string configID, string userID, string packID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sa_redpack_user_taskEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.ConfigID, item.UserID, item.PackID, tm_);
		}
		public async Task<int> RemoveAsync(Sa_redpack_user_taskEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.ConfigID, item.UserID, item.PackID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByConfigID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByConfigID(string configID, TransactionManager tm_ = null)
		{
			RepairRemoveByConfigIDData(configID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByConfigIDAsync(string configID, TransactionManager tm_ = null)
		{
			RepairRemoveByConfigIDData(configID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByConfigIDData(string configID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByConfigID
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
		#region RemoveByPackID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPackID(string packID, TransactionManager tm_ = null)
		{
			RepairRemoveByPackIDData(packID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPackIDAsync(string packID, TransactionManager tm_ = null)
		{
			RepairRemoveByPackIDData(packID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPackIDData(string packID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PackID` = @PackID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByPackID
		#region RemoveByGroupId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGroupId(int groupId, TransactionManager tm_ = null)
		{
			RepairRemoveByGroupIdData(groupId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByGroupIdAsync(int groupId, TransactionManager tm_ = null)
		{
			RepairRemoveByGroupIdData(groupId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByGroupIdData(int groupId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `GroupId` = @GroupId";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32));
		}
		#endregion // RemoveByGroupId
		#region RemoveByRatio
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRatio(float ratio, TransactionManager tm_ = null)
		{
			RepairRemoveByRatioData(ratio, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRatioAsync(float ratio, TransactionManager tm_ = null)
		{
			RepairRemoveByRatioData(ratio, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRatioData(float ratio, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Ratio` = @Ratio";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float));
		}
		#endregion // RemoveByRatio
		#region RemoveByRemainCount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
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
		#region RemoveByRemainAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRemainAmount(long remainAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainAmountData(remainAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRemainAmountAsync(long remainAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainAmountData(remainAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRemainAmountData(long remainAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RemainAmount` = @RemainAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByRemainAmount
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
		#region RemoveByBetAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
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
		/// /// <param name = "payAmount">充值金额</param>
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
		public int Put(Sa_redpack_user_taskEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sa_redpack_user_taskEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sa_redpack_user_taskEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ConfigID` = @ConfigID, `UserID` = @UserID, `PackID` = @PackID, `GroupId` = @GroupId, `Ratio` = @Ratio, `RemainCount` = @RemainCount, `RemainAmount` = @RemainAmount, `BetAmount` = @BetAmount, `PayAmount` = @PayAmount WHERE `ConfigID` = @ConfigID_Original AND `UserID` = @UserID_Original AND `PackID` = @PackID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", item.ConfigID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupId", item.GroupId, MySqlDbType.Int32),
				Database.CreateInParameter("@Ratio", item.Ratio, MySqlDbType.Float),
				Database.CreateInParameter("@RemainCount", item.RemainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@RemainAmount", item.RemainAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BetAmount", item.BetAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayAmount", item.PayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID_Original", item.HasOriginal ? item.OriginalConfigID : item.ConfigID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID_Original", item.HasOriginal ? item.OriginalPackID : item.PackID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sa_redpack_user_taskEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sa_redpack_user_taskEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string configID, string userID, string packID, string set_, params object[] values_)
		{
			return Put(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", ConcatValues(values_, configID, userID, packID));
		}
		public async Task<int> PutByPKAsync(string configID, string userID, string packID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", ConcatValues(values_, configID, userID, packID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string configID, string userID, string packID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", tm_, ConcatValues(values_, configID, userID, packID));
		}
		public async Task<int> PutByPKAsync(string configID, string userID, string packID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", tm_, ConcatValues(values_, configID, userID, packID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string configID, string userID, string packID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string configID, string userID, string packID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutConfigID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConfigID(string configID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ConfigID` = @ConfigID";
			var parameter_ = Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutConfigIDAsync(string configID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ConfigID` = @ConfigID";
			var parameter_ = Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutConfigID
		#region PutUserID
	 
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
		#region PutPackID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackID(string packID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackID` = @PackID";
			var parameter_ = Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPackIDAsync(string packID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PackID` = @PackID";
			var parameter_ = Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPackID
		#region PutGroupId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGroupIdByPK(string configID, string userID, string packID, int groupId, TransactionManager tm_ = null)
		{
			RepairPutGroupIdByPKData(configID, userID, packID, groupId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutGroupIdByPKAsync(string configID, string userID, string packID, int groupId, TransactionManager tm_ = null)
		{
			RepairPutGroupIdByPKData(configID, userID, packID, groupId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutGroupIdByPKData(string configID, string userID, string packID, int groupId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `GroupId` = @GroupId  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGroupId(int groupId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GroupId` = @GroupId";
			var parameter_ = Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutGroupIdAsync(int groupId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GroupId` = @GroupId";
			var parameter_ = Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGroupId
		#region PutRatio
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRatioByPK(string configID, string userID, string packID, float ratio, TransactionManager tm_ = null)
		{
			RepairPutRatioByPKData(configID, userID, packID, ratio, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRatioByPKAsync(string configID, string userID, string packID, float ratio, TransactionManager tm_ = null)
		{
			RepairPutRatioByPKData(configID, userID, packID, ratio, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRatioByPKData(string configID, string userID, string packID, float ratio, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Ratio` = @Ratio  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRatio(float ratio, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Ratio` = @Ratio";
			var parameter_ = Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRatioAsync(float ratio, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Ratio` = @Ratio";
			var parameter_ = Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRatio
		#region PutRemainCount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainCountByPK(string configID, string userID, string packID, int remainCount, TransactionManager tm_ = null)
		{
			RepairPutRemainCountByPKData(configID, userID, packID, remainCount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRemainCountByPKAsync(string configID, string userID, string packID, int remainCount, TransactionManager tm_ = null)
		{
			RepairPutRemainCountByPKData(configID, userID, packID, remainCount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRemainCountByPKData(string configID, string userID, string packID, int remainCount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RemainCount` = @RemainCount  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
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
		#region PutRemainAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainAmountByPK(string configID, string userID, string packID, long remainAmount, TransactionManager tm_ = null)
		{
			RepairPutRemainAmountByPKData(configID, userID, packID, remainAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRemainAmountByPKAsync(string configID, string userID, string packID, long remainAmount, TransactionManager tm_ = null)
		{
			RepairPutRemainAmountByPKData(configID, userID, packID, remainAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRemainAmountByPKData(string configID, string userID, string packID, long remainAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RemainAmount` = @RemainAmount  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainAmount(long remainAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainAmount` = @RemainAmount";
			var parameter_ = Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRemainAmountAsync(long remainAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainAmount` = @RemainAmount";
			var parameter_ = Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRemainAmount
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string configID, string userID, string packID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(configID, userID, packID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string configID, string userID, string packID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(configID, userID, packID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string configID, string userID, string packID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
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
		#region PutBetAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetAmountByPK(string configID, string userID, string packID, long betAmount, TransactionManager tm_ = null)
		{
			RepairPutBetAmountByPKData(configID, userID, packID, betAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBetAmountByPKAsync(string configID, string userID, string packID, long betAmount, TransactionManager tm_ = null)
		{
			RepairPutBetAmountByPKData(configID, userID, packID, betAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBetAmountByPKData(string configID, string userID, string packID, long betAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BetAmount` = @BetAmount  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
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
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayAmountByPK(string configID, string userID, string packID, long payAmount, TransactionManager tm_ = null)
		{
			RepairPutPayAmountByPKData(configID, userID, packID, payAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayAmountByPKAsync(string configID, string userID, string packID, long payAmount, TransactionManager tm_ = null)
		{
			RepairPutPayAmountByPKData(configID, userID, packID, payAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayAmountByPKData(string configID, string userID, string packID, long payAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayAmount` = @PayAmount  WHERE `ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sa_redpack_user_taskEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.ConfigID, item.UserID, item.PackID) == null)
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
		public async Task<bool> SetAsync(Sa_redpack_user_taskEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.ConfigID, item.UserID, item.PackID) == null)
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
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sa_redpack_user_taskEO GetByPK(string configID, string userID, string packID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(configID, userID, packID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<Sa_redpack_user_taskEO> GetByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(configID, userID, packID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		private void RepairGetByPKData(string configID, string userID, string packID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			if (isForUpdate_ && tm_ != null && tm_.IsolationLevel > IsolationLevel.ReadCommitted)
				throw new Exception("for update时，IsolationLevel不能大于ReadCommitted");
			sql_ = BuildSelectSQL("`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 ConfigID（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetConfigIDByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`ConfigID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetConfigIDByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`ConfigID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PackID（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetPackIDByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`PackID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<string> GetPackIDByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`PackID`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 GroupId（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetGroupIdByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`GroupId`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetGroupIdByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`GroupId`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Ratio（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetRatioByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (float)GetScalar("`Ratio`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<float> GetRatioByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (float)await GetScalarAsync("`Ratio`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RemainCount（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetRemainCountByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`RemainCount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<int> GetRemainCountByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`RemainCount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RemainAmount（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetRemainAmountByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`RemainAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetRemainAmountByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`RemainAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BetAmount（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBetAmountByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`BetAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetBetAmountByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`BetAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayAmount（字段）
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPayAmountByPK(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`PayAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		public async Task<long> GetPayAmountByPKAsync(string configID, string userID, string packID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`PayAmount`", "`ConfigID` = @ConfigID AND `UserID` = @UserID AND `PackID` = @PackID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByConfigID
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID)
		{
			return GetByConfigID(configID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID)
		{
			return await GetByConfigIDAsync(configID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, TransactionManager tm_)
		{
			return GetByConfigID(configID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, TransactionManager tm_)
		{
			return await GetByConfigIDAsync(configID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, int top_)
		{
			return GetByConfigID(configID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, int top_)
		{
			return await GetByConfigIDAsync(configID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, int top_, TransactionManager tm_)
		{
			return GetByConfigID(configID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, int top_, TransactionManager tm_)
		{
			return await GetByConfigIDAsync(configID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, string sort_)
		{
			return GetByConfigID(configID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, string sort_)
		{
			return await GetByConfigIDAsync(configID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, string sort_, TransactionManager tm_)
		{
			return GetByConfigID(configID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, string sort_, TransactionManager tm_)
		{
			return await GetByConfigIDAsync(configID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ConfigID（字段） 查询
		/// </summary>
		/// /// <param name = "configID">主键GUID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByConfigID(string configID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ConfigID` = @ConfigID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByConfigIDAsync(string configID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ConfigID` = @ConfigID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConfigID", configID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByConfigID
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, int top_)
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
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, string sort_)
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
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_taskEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByPackID
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID)
		{
			return GetByPackID(packID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID)
		{
			return await GetByPackIDAsync(packID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, TransactionManager tm_)
		{
			return GetByPackID(packID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, int top_)
		{
			return GetByPackID(packID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, int top_)
		{
			return await GetByPackIDAsync(packID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, int top_, TransactionManager tm_)
		{
			return GetByPackID(packID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, int top_, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, string sort_)
		{
			return GetByPackID(packID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, string sort_)
		{
			return await GetByPackIDAsync(packID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, string sort_, TransactionManager tm_)
		{
			return GetByPackID(packID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, string sort_, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">红包主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPackID(string packID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackID` = @PackID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPackIDAsync(string packID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackID` = @PackID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByPackID
		#region GetByGroupId
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId)
		{
			return GetByGroupId(groupId, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId)
		{
			return await GetByGroupIdAsync(groupId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, TransactionManager tm_)
		{
			return GetByGroupId(groupId, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, TransactionManager tm_)
		{
			return await GetByGroupIdAsync(groupId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, int top_)
		{
			return GetByGroupId(groupId, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, int top_)
		{
			return await GetByGroupIdAsync(groupId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, int top_, TransactionManager tm_)
		{
			return GetByGroupId(groupId, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, int top_, TransactionManager tm_)
		{
			return await GetByGroupIdAsync(groupId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, string sort_)
		{
			return GetByGroupId(groupId, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, string sort_)
		{
			return await GetByGroupIdAsync(groupId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, string sort_, TransactionManager tm_)
		{
			return GetByGroupId(groupId, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, string sort_, TransactionManager tm_)
		{
			return await GetByGroupIdAsync(groupId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByGroupId(int groupId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupId` = @GroupId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByGroupIdAsync(int groupId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupId` = @GroupId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByGroupId
		#region GetByRatio
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio)
		{
			return GetByRatio(ratio, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio)
		{
			return await GetByRatioAsync(ratio, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, TransactionManager tm_)
		{
			return GetByRatio(ratio, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, TransactionManager tm_)
		{
			return await GetByRatioAsync(ratio, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, int top_)
		{
			return GetByRatio(ratio, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, int top_)
		{
			return await GetByRatioAsync(ratio, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, int top_, TransactionManager tm_)
		{
			return GetByRatio(ratio, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, int top_, TransactionManager tm_)
		{
			return await GetByRatioAsync(ratio, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, string sort_)
		{
			return GetByRatio(ratio, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, string sort_)
		{
			return await GetByRatioAsync(ratio, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, string sort_, TransactionManager tm_)
		{
			return GetByRatio(ratio, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, string sort_, TransactionManager tm_)
		{
			return await GetByRatioAsync(ratio, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Ratio（字段） 查询
		/// </summary>
		/// /// <param name = "ratio">分配概率60%</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRatio(float ratio, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Ratio` = @Ratio", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRatioAsync(float ratio, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Ratio` = @Ratio", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Ratio", ratio, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByRatio
		#region GetByRemainCount
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount)
		{
			return GetByRemainCount(remainCount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount)
		{
			return await GetByRemainCountAsync(remainCount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, int top_)
		{
			return GetByRemainCount(remainCount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, int top_)
		{
			return await GetByRemainCountAsync(remainCount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, int top_, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, int top_, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, string sort_)
		{
			return GetByRemainCount(remainCount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, string sort_)
		{
			return await GetByRemainCountAsync(remainCount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, string sort_, TransactionManager tm_)
		{
			return GetByRemainCount(remainCount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, string sort_, TransactionManager tm_)
		{
			return await GetByRemainCountAsync(remainCount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RemainCount（字段） 查询
		/// </summary>
		/// /// <param name = "remainCount">当前剩余次数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainCount(int remainCount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainCount` = @RemainCount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainCountAsync(int remainCount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainCount` = @RemainCount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainCount", remainCount, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByRemainCount
		#region GetByRemainAmount
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount)
		{
			return GetByRemainAmount(remainAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount)
		{
			return await GetByRemainAmountAsync(remainAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, TransactionManager tm_)
		{
			return GetByRemainAmount(remainAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, TransactionManager tm_)
		{
			return await GetByRemainAmountAsync(remainAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, int top_)
		{
			return GetByRemainAmount(remainAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, int top_)
		{
			return await GetByRemainAmountAsync(remainAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, int top_, TransactionManager tm_)
		{
			return GetByRemainAmount(remainAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, int top_, TransactionManager tm_)
		{
			return await GetByRemainAmountAsync(remainAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, string sort_)
		{
			return GetByRemainAmount(remainAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, string sort_)
		{
			return await GetByRemainAmountAsync(remainAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, string sort_, TransactionManager tm_)
		{
			return GetByRemainAmount(remainAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, string sort_, TransactionManager tm_)
		{
			return await GetByRemainAmountAsync(remainAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RemainAmount（字段） 查询
		/// </summary>
		/// /// <param name = "remainAmount">当前剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRemainAmount(long remainAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainAmount` = @RemainAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRemainAmountAsync(long remainAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainAmount` = @RemainAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainAmount", remainAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByRemainAmount
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_taskEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByBetAmount
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount)
		{
			return GetByBetAmount(betAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount)
		{
			return await GetByBetAmountAsync(betAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, int top_)
		{
			return GetByBetAmount(betAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, int top_)
		{
			return await GetByBetAmountAsync(betAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, int top_, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, int top_, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, string sort_)
		{
			return GetByBetAmount(betAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, string sort_)
		{
			return await GetByBetAmountAsync(betAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, string sort_, TransactionManager tm_)
		{
			return GetByBetAmount(betAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBetAmountAsync(betAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BetAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betAmount">下注金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByBetAmount(long betAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetAmount` = @BetAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByBetAmountAsync(long betAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetAmount` = @BetAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetAmount", betAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByBetAmount
		#region GetByPayAmount
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount)
		{
			return GetByPayAmount(payAmount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount)
		{
			return await GetByPayAmountAsync(payAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, int top_)
		{
			return GetByPayAmount(payAmount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, int top_)
		{
			return await GetByPayAmountAsync(payAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, int top_, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, int top_, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, string sort_)
		{
			return GetByPayAmount(payAmount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, string sort_)
		{
			return await GetByPayAmountAsync(payAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, string sort_, TransactionManager tm_)
		{
			return GetByPayAmount(payAmount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPayAmountAsync(payAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payAmount">充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_taskEO> GetByPayAmount(long payAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayAmount` = @PayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_taskEO>> GetByPayAmountAsync(long payAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayAmount` = @PayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayAmount", payAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_taskEO.MapDataReader);
		}
		#endregion // GetByPayAmount
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
