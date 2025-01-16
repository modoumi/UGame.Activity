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
	/// 红包抽取明细
	/// 【表 sa_redpack_user_pack_detail 的实体类】
	/// </summary>
	[DataContract]
	public class Sa_redpack_user_pack_detailEO : IRowMapper<Sa_redpack_user_pack_detailEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sa_redpack_user_pack_detailEO()
		{
			this.GroupId = 0;
			this.Amount = 0;
			this.Bonus = 0;
			this.Status = 0;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalDetailID;
		/// <summary>
		/// 【数据库中的原始主键 DetailID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalDetailID
		{
			get { return _originalDetailID; }
			set { HasOriginal = true; _originalDetailID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "DetailID", DetailID }, };
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
		public string DetailID { get; set; }
		/// <summary>
		/// 编码objectID
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 2)]
		public string PackID { get; set; }
		/// <summary>
		/// 用户编码
		/// 【字段 varchar(36)】
		/// </summary>
		[DataMember(Order = 3)]
		public string UserID { get; set; }
		/// <summary>
		/// 被分享用户用户编码
		/// 【字段 varchar(36)】
		/// </summary>
		[DataMember(Order = 4)]
		public string PUserID { get; set; }
		/// <summary>
		/// 分组标志1-新注册2-分享3-下注4-客户端
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 5)]
		public int GroupId { get; set; }
		/// <summary>
		/// 进度奖金
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 6)]
		public long Amount { get; set; }
		/// <summary>
		/// 奖金
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long Bonus { get; set; }
		/// <summary>
		/// 状态(0-初始 1-已使用)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 8)]
		public int Status { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 9)]
		public DateTime RecDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sa_redpack_user_pack_detailEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sa_redpack_user_pack_detailEO MapDataReader(IDataReader reader)
		{
		    Sa_redpack_user_pack_detailEO ret = new Sa_redpack_user_pack_detailEO();
			ret.DetailID = reader.ToString("DetailID");
			ret.OriginalDetailID = ret.DetailID;
			ret.PackID = reader.ToString("PackID");
			ret.UserID = reader.ToString("UserID");
			ret.PUserID = reader.ToString("PUserID");
			ret.GroupId = reader.ToInt32("GroupId");
			ret.Amount = reader.ToInt64("Amount");
			ret.Bonus = reader.ToInt64("Bonus");
			ret.Status = reader.ToInt32("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 红包抽取明细
	/// 【表 sa_redpack_user_pack_detail 的操作类】
	/// </summary>
	public class Sa_redpack_user_pack_detailMO : MySqlTableMO<Sa_redpack_user_pack_detailEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sa_redpack_user_pack_detail`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sa_redpack_user_pack_detailMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sa_redpack_user_pack_detailMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sa_redpack_user_pack_detailMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sa_redpack_user_pack_detailEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`DetailID`, `PackID`, `UserID`, `PUserID`, `GroupId`, `Amount`, `Bonus`, `Status`, `RecDate`) VALUE (@DetailID, @PackID, @UserID, @PUserID, @GroupId, @Amount, @Bonus, @Status, @RecDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", item.DetailID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PUserID", item.PUserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupId", item.GroupId, MySqlDbType.Int32),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@Bonus", item.Bonus, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sa_redpack_user_pack_detailEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sa_redpack_user_pack_detailEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_redpack_user_pack_detailEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`DetailID`, `PackID`, `UserID`, `PUserID`, `GroupId`, `Amount`, `Bonus`, `Status`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.DetailID}','{item.PackID}','{item.UserID}','{item.PUserID}',{item.GroupId},{item.Amount},{item.Bonus},{item.Status},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string detailID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(detailID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(detailID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string detailID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.DetailID, tm_);
		}
		public async Task<int> RemoveAsync(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.DetailID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByPackID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
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
		#region RemoveByPUserID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPUserID(string pUserID, TransactionManager tm_ = null)
		{
			RepairRemoveByPUserIDData(pUserID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPUserIDAsync(string pUserID, TransactionManager tm_ = null)
		{
			RepairRemoveByPUserIDData(pUserID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPUserIDData(string pUserID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PUserID` = @PUserID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByPUserID
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
		#region RemoveByAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAmount(long amount, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountData(amount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAmountAsync(long amount, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountData(amount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAmountData(long amount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Amount` = @Amount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
		}
		#endregion // RemoveByAmount
		#region RemoveByBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBonus(long bonus, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusData(bonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBonusAsync(long bonus, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusData(bonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBonusData(long bonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Bonus` = @Bonus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64));
		}
		#endregion // RemoveByBonus
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByStatusAsync(int status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByStatusData(int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Status` = @Status";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
		}
		#endregion // RemoveByStatus
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
		public int Put(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sa_redpack_user_pack_detailEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sa_redpack_user_pack_detailEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DetailID` = @DetailID, `PackID` = @PackID, `UserID` = @UserID, `PUserID` = @PUserID, `GroupId` = @GroupId, `Amount` = @Amount, `Bonus` = @Bonus, `Status` = @Status WHERE `DetailID` = @DetailID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", item.DetailID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PackID", item.PackID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@PUserID", item.PUserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupId", item.GroupId, MySqlDbType.Int32),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@Bonus", item.Bonus, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@DetailID_Original", item.HasOriginal ? item.OriginalDetailID : item.DetailID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sa_redpack_user_pack_detailEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sa_redpack_user_pack_detailEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string detailID, string set_, params object[] values_)
		{
			return Put(set_, "`DetailID` = @DetailID", ConcatValues(values_, detailID));
		}
		public async Task<int> PutByPKAsync(string detailID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`DetailID` = @DetailID", ConcatValues(values_, detailID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string detailID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`DetailID` = @DetailID", tm_, ConcatValues(values_, detailID));
		}
		public async Task<int> PutByPKAsync(string detailID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`DetailID` = @DetailID", tm_, ConcatValues(values_, detailID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string detailID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`DetailID` = @DetailID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string detailID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`DetailID` = @DetailID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutPackID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPackIDByPK(string detailID, string packID, TransactionManager tm_ = null)
		{
			RepairPutPackIDByPKData(detailID, packID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPackIDByPKAsync(string detailID, string packID, TransactionManager tm_ = null)
		{
			RepairPutPackIDByPKData(detailID, packID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPackIDByPKData(string detailID, string packID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PackID` = @PackID  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
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
		#region PutUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIDByPK(string detailID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(detailID, userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIDByPKAsync(string detailID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(detailID, userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIDByPKData(string detailID, string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
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
		#region PutPUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPUserIDByPK(string detailID, string pUserID, TransactionManager tm_ = null)
		{
			RepairPutPUserIDByPKData(detailID, pUserID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPUserIDByPKAsync(string detailID, string pUserID, TransactionManager tm_ = null)
		{
			RepairPutPUserIDByPKData(detailID, pUserID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPUserIDByPKData(string detailID, string pUserID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PUserID` = @PUserID  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPUserID(string pUserID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PUserID` = @PUserID";
			var parameter_ = Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPUserIDAsync(string pUserID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PUserID` = @PUserID";
			var parameter_ = Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPUserID
		#region PutGroupId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGroupIdByPK(string detailID, int groupId, TransactionManager tm_ = null)
		{
			RepairPutGroupIdByPKData(detailID, groupId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutGroupIdByPKAsync(string detailID, int groupId, TransactionManager tm_ = null)
		{
			RepairPutGroupIdByPKData(detailID, groupId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutGroupIdByPKData(string detailID, int groupId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `GroupId` = @GroupId  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
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
		#region PutAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountByPK(string detailID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(detailID, amount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountByPKAsync(string detailID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(detailID, amount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountByPKData(string detailID, long amount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Amount` = @Amount  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmount(long amount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Amount` = @Amount";
			var parameter_ = Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAmountAsync(long amount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Amount` = @Amount";
			var parameter_ = Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAmount
		#region PutBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "bonus">奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonusByPK(string detailID, long bonus, TransactionManager tm_ = null)
		{
			RepairPutBonusByPKData(detailID, bonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBonusByPKAsync(string detailID, long bonus, TransactionManager tm_ = null)
		{
			RepairPutBonusByPKData(detailID, bonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBonusByPKData(string detailID, long bonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Bonus` = @Bonus  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonus(long bonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Bonus` = @Bonus";
			var parameter_ = Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBonusAsync(long bonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Bonus` = @Bonus";
			var parameter_ = Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBonus
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string detailID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(detailID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string detailID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(detailID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string detailID, int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutStatusAsync(int status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string detailID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(detailID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string detailID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(detailID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string detailID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `DetailID` = @DetailID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
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
		public bool Set(Sa_redpack_user_pack_detailEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.DetailID) == null)
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
		public async Task<bool> SetAsync(Sa_redpack_user_pack_detailEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.DetailID) == null)
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
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sa_redpack_user_pack_detailEO GetByPK(string detailID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(detailID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<Sa_redpack_user_pack_detailEO> GetByPKAsync(string detailID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(detailID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		private void RepairGetByPKData(string detailID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			if (isForUpdate_ && tm_ != null && tm_.IsolationLevel > IsolationLevel.ReadCommitted)
				throw new Exception("for update时，IsolationLevel不能大于ReadCommitted");
			sql_ = BuildSelectSQL("`DetailID` = @DetailID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 PackID（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetPackIDByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`PackID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<string> GetPackIDByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`PackID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PUserID（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetPUserIDByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`PUserID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<string> GetPUserIDByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`PUserID`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 GroupId（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetGroupIdByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`GroupId`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<int> GetGroupIdByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`GroupId`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Amount（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`Amount`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<long> GetAmountByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`Amount`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Bonus（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBonusByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`Bonus`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<long> GetBonusByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`Bonus`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetStatusByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Status`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<int> GetStatusByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Status`", "`DetailID` = @DetailID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "detailID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`DetailID` = @DetailID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string detailID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DetailID", detailID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`DetailID` = @DetailID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByPackID
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID)
		{
			return GetByPackID(packID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID)
		{
			return await GetByPackIDAsync(packID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, TransactionManager tm_)
		{
			return GetByPackID(packID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, int top_)
		{
			return GetByPackID(packID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, int top_)
		{
			return await GetByPackIDAsync(packID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, int top_, TransactionManager tm_)
		{
			return GetByPackID(packID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, int top_, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, string sort_)
		{
			return GetByPackID(packID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, string sort_)
		{
			return await GetByPackIDAsync(packID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, string sort_, TransactionManager tm_)
		{
			return GetByPackID(packID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, string sort_, TransactionManager tm_)
		{
			return await GetByPackIDAsync(packID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PackID（字段） 查询
		/// </summary>
		/// /// <param name = "packID">编码objectID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPackID(string packID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackID` = @PackID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPackIDAsync(string packID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PackID` = @PackID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PackID", packID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByPackID
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, int top_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, string sort_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByPUserID
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID)
		{
			return GetByPUserID(pUserID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID)
		{
			return await GetByPUserIDAsync(pUserID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, TransactionManager tm_)
		{
			return GetByPUserID(pUserID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, TransactionManager tm_)
		{
			return await GetByPUserIDAsync(pUserID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, int top_)
		{
			return GetByPUserID(pUserID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, int top_)
		{
			return await GetByPUserIDAsync(pUserID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, int top_, TransactionManager tm_)
		{
			return GetByPUserID(pUserID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, int top_, TransactionManager tm_)
		{
			return await GetByPUserIDAsync(pUserID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, string sort_)
		{
			return GetByPUserID(pUserID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, string sort_)
		{
			return await GetByPUserIDAsync(pUserID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, string sort_, TransactionManager tm_)
		{
			return GetByPUserID(pUserID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, string sort_, TransactionManager tm_)
		{
			return await GetByPUserIDAsync(pUserID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PUserID（字段） 查询
		/// </summary>
		/// /// <param name = "pUserID">被分享用户用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByPUserID(string pUserID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PUserID` = @PUserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByPUserIDAsync(string pUserID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PUserID` = @PUserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PUserID", pUserID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByPUserID
		#region GetByGroupId
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId)
		{
			return GetByGroupId(groupId, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId)
		{
			return await GetByGroupIdAsync(groupId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, TransactionManager tm_)
		{
			return GetByGroupId(groupId, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, TransactionManager tm_)
		{
			return await GetByGroupIdAsync(groupId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, int top_)
		{
			return GetByGroupId(groupId, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, int top_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, int top_, TransactionManager tm_)
		{
			return GetByGroupId(groupId, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, int top_, TransactionManager tm_)
		{
			return await GetByGroupIdAsync(groupId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupId（字段） 查询
		/// </summary>
		/// /// <param name = "groupId">分组标志1-新注册2-分享3-下注4-客户端</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, string sort_)
		{
			return GetByGroupId(groupId, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, string sort_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, string sort_, TransactionManager tm_)
		{
			return GetByGroupId(groupId, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByGroupId(int groupId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupId` = @GroupId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByGroupIdAsync(int groupId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupId` = @GroupId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupId", groupId, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByGroupId
		#region GetByAmount
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount)
		{
			return GetByAmount(amount, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, int top_)
		{
			return GetByAmount(amount, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, int top_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, int top_, TransactionManager tm_)
		{
			return GetByAmount(amount, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, int top_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, string sort_)
		{
			return GetByAmount(amount, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, string sort_)
		{
			return await GetByAmountAsync(amount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, string sort_, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, string sort_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">进度奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByAmount(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByAmountAsync(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByAmount
		#region GetByBonus
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus)
		{
			return GetByBonus(bonus, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus)
		{
			return await GetByBonusAsync(bonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, TransactionManager tm_)
		{
			return GetByBonus(bonus, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, TransactionManager tm_)
		{
			return await GetByBonusAsync(bonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, int top_)
		{
			return GetByBonus(bonus, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, int top_)
		{
			return await GetByBonusAsync(bonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, int top_, TransactionManager tm_)
		{
			return GetByBonus(bonus, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, int top_, TransactionManager tm_)
		{
			return await GetByBonusAsync(bonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, string sort_)
		{
			return GetByBonus(bonus, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, string sort_)
		{
			return await GetByBonusAsync(bonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, string sort_, TransactionManager tm_)
		{
			return GetByBonus(bonus, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, string sort_, TransactionManager tm_)
		{
			return await GetByBonusAsync(bonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Bonus（字段） 查询
		/// </summary>
		/// /// <param name = "bonus">奖金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByBonus(long bonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Bonus` = @Bonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByBonusAsync(long bonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Bonus` = @Bonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Bonus", bonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByBonus
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-初始 1-已使用)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_user_pack_detailEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_user_pack_detailEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_user_pack_detailEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
