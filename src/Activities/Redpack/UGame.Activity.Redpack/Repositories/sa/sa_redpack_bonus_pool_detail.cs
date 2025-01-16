/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-21 17: 38:08
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
	/// bonus数量pool，明细
	/// 【表 sa_redpack_bonus_pool_detail 的实体类】
	/// </summary>
	[DataContract]
	public class Sa_redpack_bonus_pool_detailEO : IRowMapper<Sa_redpack_bonus_pool_detailEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sa_redpack_bonus_pool_detailEO()
		{
			this.StartTime = DateTime.Now;
			this.EndTime = DateTime.Now;
			this.RemainBonus = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalOperatorID;
		/// <summary>
		/// 【数据库中的原始主键 OperatorID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalOperatorID
		{
			get { return _originalOperatorID; }
			set { HasOriginal = true; _originalOperatorID = value; }
		}
		
		private DateTime _originalStartTime;
		/// <summary>
		/// 【数据库中的原始主键 StartTime 值的副本，用于主键值更新】
		/// </summary>
		public DateTime OriginalStartTime
		{
			get { return _originalStartTime; }
			set { HasOriginal = true; _originalStartTime = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "OperatorID", OperatorID },  { "StartTime", StartTime }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 运营商编码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 开始时间00:00:00
		/// 【主键 datetime】
		/// </summary>
		[DataMember(Order = 2)]
		public DateTime StartTime { get; set; }
		/// <summary>
		/// 结束时间02:00:00
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 3)]
		public DateTime EndTime { get; set; }
		/// <summary>
		/// 剩余bonus金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 4)]
		public long RemainBonus { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sa_redpack_bonus_pool_detailEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sa_redpack_bonus_pool_detailEO MapDataReader(IDataReader reader)
		{
		    Sa_redpack_bonus_pool_detailEO ret = new Sa_redpack_bonus_pool_detailEO();
			ret.OperatorID = reader.ToString("OperatorID");
			ret.OriginalOperatorID = ret.OperatorID;
			ret.StartTime = reader.ToDateTime("StartTime");
			ret.OriginalStartTime = ret.StartTime;
			ret.EndTime = reader.ToDateTime("EndTime");
			ret.RemainBonus = reader.ToInt64("RemainBonus");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// bonus数量pool，明细
	/// 【表 sa_redpack_bonus_pool_detail 的操作类】
	/// </summary>
	public class Sa_redpack_bonus_pool_detailMO : MySqlTableMO<Sa_redpack_bonus_pool_detailEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sa_redpack_bonus_pool_detail`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sa_redpack_bonus_pool_detailMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sa_redpack_bonus_pool_detailMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sa_redpack_bonus_pool_detailMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sa_redpack_bonus_pool_detailEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperatorID`, `StartTime`, `EndTime`, `RemainBonus`) VALUE (@OperatorID, @StartTime, @EndTime, @RemainBonus);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", item.StartTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@EndTime", item.EndTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@RemainBonus", item.RemainBonus, MySqlDbType.Int64),
			};
		}
		public int AddByBatch(IEnumerable<Sa_redpack_bonus_pool_detailEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sa_redpack_bonus_pool_detailEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sa_redpack_bonus_pool_detailEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OperatorID`, `StartTime`, `EndTime`, `RemainBonus`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OperatorID}','{item.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}','{item.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}',{item.RemainBonus}),");
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, startTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, startTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string operatorID, DateTime startTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID AND `StartTime` = @StartTime";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OperatorID, item.StartTime, tm_);
		}
		public async Task<int> RemoveAsync(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.OperatorID, item.StartTime, tm_);
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
		#region RemoveByStartTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStartTime(DateTime startTime, TransactionManager tm_ = null)
		{
			RepairRemoveByStartTimeData(startTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByStartTimeAsync(DateTime startTime, TransactionManager tm_ = null)
		{
			RepairRemoveByStartTimeData(startTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByStartTimeData(DateTime startTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `StartTime` = @StartTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime));
		}
		#endregion // RemoveByStartTime
		#region RemoveByEndTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByEndTime(DateTime endTime, TransactionManager tm_ = null)
		{
			RepairRemoveByEndTimeData(endTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByEndTimeAsync(DateTime endTime, TransactionManager tm_ = null)
		{
			RepairRemoveByEndTimeData(endTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByEndTimeData(DateTime endTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `EndTime` = @EndTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime));
		}
		#endregion // RemoveByEndTime
		#region RemoveByRemainBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRemainBonus(long remainBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainBonusData(remainBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRemainBonusAsync(long remainBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByRemainBonusData(remainBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRemainBonusData(long remainBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RemainBonus` = @RemainBonus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64));
		}
		#endregion // RemoveByRemainBonus
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
		public int Put(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sa_redpack_bonus_pool_detailEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `RemainBonus` = @RemainBonus WHERE `OperatorID` = @OperatorID_Original AND `StartTime` = @StartTime_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@RemainBonus", item.RemainBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID_Original", item.HasOriginal ? item.OriginalOperatorID : item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime_Original", item.HasOriginal ? item.OriginalStartTime : item.StartTime, MySqlDbType.DateTime),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sa_redpack_bonus_pool_detailEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sa_redpack_bonus_pool_detailEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, DateTime startTime, string set_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", ConcatValues(values_, operatorID, startTime));
		}
		public async Task<int> PutByPKAsync(string operatorID, DateTime startTime, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", ConcatValues(values_, operatorID, startTime));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, DateTime startTime, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", tm_, ConcatValues(values_, operatorID, startTime));
		}
		public async Task<int> PutByPKAsync(string operatorID, DateTime startTime, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", tm_, ConcatValues(values_, operatorID, startTime));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, DateTime startTime, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
	        };
			return Put(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string operatorID, DateTime startTime, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
	        };
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
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
		#region PutStartTime
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStartTime(DateTime startTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `StartTime` = @StartTime";
			var parameter_ = Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutStartTimeAsync(DateTime startTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `StartTime` = @StartTime";
			var parameter_ = Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStartTime
		#region PutEndTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndTimeByPK(string operatorID, DateTime startTime, DateTime endTime, TransactionManager tm_ = null)
		{
			RepairPutEndTimeByPKData(operatorID, startTime, endTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutEndTimeByPKAsync(string operatorID, DateTime startTime, DateTime endTime, TransactionManager tm_ = null)
		{
			RepairPutEndTimeByPKData(operatorID, startTime, endTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutEndTimeByPKData(string operatorID, DateTime startTime, DateTime endTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `EndTime` = @EndTime  WHERE `OperatorID` = @OperatorID AND `StartTime` = @StartTime";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndTime(DateTime endTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndTime` = @EndTime";
			var parameter_ = Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutEndTimeAsync(DateTime endTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndTime` = @EndTime";
			var parameter_ = Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutEndTime
		#region PutRemainBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainBonusByPK(string operatorID, DateTime startTime, long remainBonus, TransactionManager tm_ = null)
		{
			RepairPutRemainBonusByPKData(operatorID, startTime, remainBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRemainBonusByPKAsync(string operatorID, DateTime startTime, long remainBonus, TransactionManager tm_ = null)
		{
			RepairPutRemainBonusByPKData(operatorID, startTime, remainBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRemainBonusByPKData(string operatorID, DateTime startTime, long remainBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RemainBonus` = @RemainBonus  WHERE `OperatorID` = @OperatorID AND `StartTime` = @StartTime";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemainBonus(long remainBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainBonus` = @RemainBonus";
			var parameter_ = Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRemainBonusAsync(long remainBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RemainBonus` = @RemainBonus";
			var parameter_ = Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRemainBonus
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID, item.StartTime) == null)
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
		public async Task<bool> SetAsync(Sa_redpack_bonus_pool_detailEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID, item.StartTime) == null)
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sa_redpack_bonus_pool_detailEO GetByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, startTime, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		public async Task<Sa_redpack_bonus_pool_detailEO> GetByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, startTime, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		private void RepairGetByPKData(string operatorID, DateTime startTime, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			if (isForUpdate_ && tm_ != null && tm_.IsolationLevel > IsolationLevel.ReadCommitted)
				throw new Exception("for update时，IsolationLevel不能大于ReadCommitted");
			sql_ = BuildSelectSQL("`OperatorID` = @OperatorID AND `StartTime` = @StartTime", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (string)GetScalar("`OperatorID`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 StartTime（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetStartTimeByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (DateTime)GetScalar("`StartTime`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		public async Task<DateTime> GetStartTimeByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (DateTime)await GetScalarAsync("`StartTime`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 EndTime（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetEndTimeByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (DateTime)GetScalar("`EndTime`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		public async Task<DateTime> GetEndTimeByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (DateTime)await GetScalarAsync("`EndTime`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RemainBonus（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetRemainBonusByPK(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (long)GetScalar("`RemainBonus`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		public async Task<long> GetRemainBonusByPKAsync(string operatorID, DateTime startTime, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime),
			};
			return (long)await GetScalarAsync("`RemainBonus`", "`OperatorID` = @OperatorID AND `StartTime` = @StartTime", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sa_redpack_bonus_pool_detailEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByStartTime
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime)
		{
			return GetByStartTime(startTime, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime)
		{
			return await GetByStartTimeAsync(startTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, TransactionManager tm_)
		{
			return GetByStartTime(startTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, TransactionManager tm_)
		{
			return await GetByStartTimeAsync(startTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, int top_)
		{
			return GetByStartTime(startTime, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, int top_)
		{
			return await GetByStartTimeAsync(startTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, int top_, TransactionManager tm_)
		{
			return GetByStartTime(startTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, int top_, TransactionManager tm_)
		{
			return await GetByStartTimeAsync(startTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, string sort_)
		{
			return GetByStartTime(startTime, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, string sort_)
		{
			return await GetByStartTimeAsync(startTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, string sort_, TransactionManager tm_)
		{
			return GetByStartTime(startTime, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, string sort_, TransactionManager tm_)
		{
			return await GetByStartTimeAsync(startTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 StartTime（字段） 查询
		/// </summary>
		/// /// <param name = "startTime">开始时间00:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByStartTime(DateTime startTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`StartTime` = @StartTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByStartTimeAsync(DateTime startTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`StartTime` = @StartTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@StartTime", startTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		#endregion // GetByStartTime
		#region GetByEndTime
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime)
		{
			return GetByEndTime(endTime, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime)
		{
			return await GetByEndTimeAsync(endTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, TransactionManager tm_)
		{
			return GetByEndTime(endTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, TransactionManager tm_)
		{
			return await GetByEndTimeAsync(endTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, int top_)
		{
			return GetByEndTime(endTime, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, int top_)
		{
			return await GetByEndTimeAsync(endTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, int top_, TransactionManager tm_)
		{
			return GetByEndTime(endTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, int top_, TransactionManager tm_)
		{
			return await GetByEndTimeAsync(endTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, string sort_)
		{
			return GetByEndTime(endTime, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, string sort_)
		{
			return await GetByEndTimeAsync(endTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, string sort_, TransactionManager tm_)
		{
			return GetByEndTime(endTime, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, string sort_, TransactionManager tm_)
		{
			return await GetByEndTimeAsync(endTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 EndTime（字段） 查询
		/// </summary>
		/// /// <param name = "endTime">结束时间02:00:00</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByEndTime(DateTime endTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndTime` = @EndTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByEndTimeAsync(DateTime endTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndTime` = @EndTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndTime", endTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		#endregion // GetByEndTime
		#region GetByRemainBonus
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus)
		{
			return GetByRemainBonus(remainBonus, 0, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus)
		{
			return await GetByRemainBonusAsync(remainBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, TransactionManager tm_)
		{
			return GetByRemainBonus(remainBonus, 0, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, TransactionManager tm_)
		{
			return await GetByRemainBonusAsync(remainBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, int top_)
		{
			return GetByRemainBonus(remainBonus, top_, string.Empty, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, int top_)
		{
			return await GetByRemainBonusAsync(remainBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, int top_, TransactionManager tm_)
		{
			return GetByRemainBonus(remainBonus, top_, string.Empty, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, int top_, TransactionManager tm_)
		{
			return await GetByRemainBonusAsync(remainBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, string sort_)
		{
			return GetByRemainBonus(remainBonus, 0, sort_, null);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, string sort_)
		{
			return await GetByRemainBonusAsync(remainBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, string sort_, TransactionManager tm_)
		{
			return GetByRemainBonus(remainBonus, 0, sort_, tm_);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, string sort_, TransactionManager tm_)
		{
			return await GetByRemainBonusAsync(remainBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RemainBonus（字段） 查询
		/// </summary>
		/// /// <param name = "remainBonus">剩余bonus金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sa_redpack_bonus_pool_detailEO> GetByRemainBonus(long remainBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainBonus` = @RemainBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		public async Task<List<Sa_redpack_bonus_pool_detailEO>> GetByRemainBonusAsync(long remainBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RemainBonus` = @RemainBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RemainBonus", remainBonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sa_redpack_bonus_pool_detailEO.MapDataReader);
		}
		#endregion // GetByRemainBonus
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
