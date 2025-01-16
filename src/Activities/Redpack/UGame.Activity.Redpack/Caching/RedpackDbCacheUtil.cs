using TinyFx;
using TinyFx.DbCaching;
using UGame.Activity.Redpack.Repositories;
using UGame.Activity.Redpack.Repositories.sa;
using UGame.Activity.Redpack.Utilities;

namespace UGame.Activity.Redpack.Caching;

/// <summary>
/// 红包内存缓存对象
/// </summary>
public class RedpackDbCacheUtil
{
    private static object _sync = new object();

    #region Redpack-Config Cache

    /// <summary>
    /// 红包配置表
    /// </summary>
    //private static Dictionary<string, Sa_redpack_configEO> _redpackConfigDict;
    //private static async Task<Dictionary<string, Sa_redpack_configEO>> LoadRedpackConfigCache() => _redpackConfigDict ??= (await new Sa_redpack_configMO().GetAllAsync()).ToDictionary(x => x.OperatorID);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="operatorId"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public static Sa_redpack_configPO GetRedpackConfig(string operatorId)
    {
        var config = DbCachingUtil.GetSingle<Sa_redpack_configPO>(f => f.OperatorID, operatorId);
        if (config == null)
            throw new CustomException($"redpack_config配置不能为空! operatorId:{operatorId}");
        return config;
    }
    #endregion

    #region Redpack-Bonus-Weights Cache

    /// <summary>
    /// Bonus权重表
    /// </summary>
    //private static Dictionary<string, List<Sa_redpack_bonus_weightEO>> _redpackBonusWeightDict;

    //private static async Task<Dictionary<string, List<Sa_redpack_bonus_weightEO>>> LoadRedpackBonusWeightCache() => _redpackBonusWeightDict ??= (await new Sa_redpack_bonus_weightMO().GetAllAsync()).GroupBy(d => d.OperatorID).ToDictionary(d => d.Key, d => d.ToList());

    /// <summary>
    /// 获取Bonus权重
    /// </summary>
    /// <param name="operatorId"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public static List<Sa_redpack_bonus_weightPO> GetAllRedpackBonusWeightConfig(string operatorId)
    {
        var config = DbCachingUtil.GetList<Sa_redpack_bonus_weightPO>(f => f.OperatorID, operatorId);
        //var configs = await LoadRedpackBonusWeightCache();
        if (config == null)
            throw new CustomException($"bonus_weight配置不能为空!operatorId:{operatorId}");
        return config;
    }
    #endregion

    #region Redpack-Bonus-Poll Cache

    /// <summary>
    /// Bonus Pool配置
    /// </summary>
    //private static Dictionary<string, List<Sa_redpack_bonus_poolEO>> _redpackBonusPollDict;

    //private static async Task<Dictionary<string, List<Sa_redpack_bonus_poolEO>>> LoadRedpackBonusPollCache() => _redpackBonusPollDict ??= (await new Sa_redpack_bonus_poolMO().GetAllAsync()).GroupBy(d => d.OperatorID).ToDictionary(d => d.Key, d => d.ToList());

    /// <summary>
    /// 获取所有Bonus配置
    /// </summary>
    /// <param name="operatorId"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public static List<Sa_redpack_bonus_poolPO> GetAllRedpackBonusPollConfig(string operatorId)
    {
        var config = DbCachingUtil.GetList<Sa_redpack_bonus_poolPO>(f => f.OperatorID, operatorId);
        //var configs = await LoadRedpackBonusPollCache();
        if (config == null)
            throw new CustomException($"bonus_pool配置不能为空!operatorId:{operatorId}");
        return config;
    }
    #endregion

    #region Redpack-Pack-Poll Cache

    /// <summary>
    /// 红包 Pool配置
    /// </summary>
    //private static Dictionary<string, List<Sa_redpack_pack_poolEO>> _redpackPackPollDict;

    //private static async Task<Dictionary<string, List<Sa_redpack_pack_poolEO>>> LoadRedpackPackPollCache() => _redpackPackPollDict ??= (await new Sa_redpack_pack_poolMO().GetAllAsync()).GroupBy(d => d.OperatorID).ToDictionary(d => d.Key, d => d.ToList());

    public static async Task<List<Sa_redpack_pack_poolPO>> GetAllRedpackPackPollConfig(string operatorId)
    {
        var configs = DbCachingUtil.GetList<Sa_redpack_pack_poolPO>(f => f.OperatorID, operatorId);
        //var value = default(List<Sa_redpack_pack_poolPO>);
        //var configs = await LoadRedpackPackPollCache();
        if (configs == null)
            throw new CustomException($"pack_pool配置不能为空!operatorId:{operatorId}");
        return configs;
    }
    #endregion

    #region Redpack-Task-Config Cache

    /// <summary>
    /// 红包 Pool配置
    /// </summary>
    //private static Dictionary<string, List<Sa_redpack_task_configEO>> _redpackTaskConfigDict;

    //private static async Task<Dictionary<string, List<Sa_redpack_task_configEO>>> LoadRedpackTaskConfigCache() => _redpackTaskConfigDict ??= (await new Sa_redpack_task_configMO().GetAllAsync()).GroupBy(d => d.OperatorID).ToDictionary(d => d.Key, d => d.ToList());

    public static List<Sa_redpack_task_configPO> GetAllRedpackTaskConfig(string operatorId)
    {
        var configs = DbCachingUtil.GetList<Sa_redpack_task_configPO>(f => f.OperatorID, operatorId);
        //var configs = await LoadRedpackTaskConfigCache();
        if (configs == null)
            throw new CustomException($"task_config配置不能为空!operatorId:{operatorId}");
        return configs;
    }
    #endregion

    #region 红包权重
    private static WeightRandomProvider<Sa_redpack_user_taskEO> _taskConfigWeight;
    private static WeightRandomProvider<Sa_redpack_user_taskEO> GetUserTaskWeight(List<Sa_redpack_user_taskEO> tasks)
    {
        lock (_sync)
        {
            _taskConfigWeight = new WeightRandomProvider<Sa_redpack_user_taskEO>();
            tasks.ForEach(x => _taskConfigWeight.AddItem(x.Ratio, x));
        }
        return _taskConfigWeight;
    }

    public static Sa_redpack_user_taskEO GetUserTaskRatio(List<Sa_redpack_user_taskEO> tasks)
    {
        return GetUserTaskWeight(tasks).Next();
    }

    #endregion


    #region Bonus权重
    private static WeightRandomProvider<Sa_redpack_bonus_weightPO> _bonusConfigWeight;
    private static WeightRandomProvider<Sa_redpack_bonus_weightPO> GetBonusWeight(List<Sa_redpack_bonus_weightPO> bonus)
    {
        lock (_sync)
        {
            _bonusConfigWeight = new WeightRandomProvider<Sa_redpack_bonus_weightPO>();
            bonus.ForEach(x => _bonusConfigWeight.AddItem(x.Weight, x));
        }
        return _bonusConfigWeight;
    }

    /// <summary>
    /// 获取bonus权重
    /// </summary>
    /// <param name="tasks"></param>
    /// <returns></returns>
    public static Sa_redpack_bonus_weightPO GetBonusNextWeight(List<Sa_redpack_bonus_weightPO> tasks)
    {
        return GetBonusWeight(tasks).Next();
    }
    #endregion

    /// <summary>
    /// 清理缓存
    /// </summary>
    //public static void Clear()
    //{
    //    _redpackConfigDict = null;
    //    _redpackTaskConfigDict = null;
    //    _redpackBonusWeightDict = null;
    //    _redpackBonusPollDict = null;
    //    _redpackPackPollDict = null;
    //}
}
