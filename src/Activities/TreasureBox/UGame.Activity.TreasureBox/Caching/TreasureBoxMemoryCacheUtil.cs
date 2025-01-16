using TinyFx.DbCaching;
using TinyFx.Randoms;
using UGame.Activity.TreasureBox.Models.Bos;
using UGame.Activity.TreasureBox.Repositories;

namespace UGame.Activity.TreasureBox.Caching;

/// <summary>
/// 宝箱内存缓存
/// </summary>
public static class TreasureBoxMemoryCacheUtil
{
    private static object _sync = new object();


    /// <summary>
    /// 获取宝箱配置
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="boxId"></param>
    /// <param name="langId"></param>
    /// <returns></returns>
    public static TreasureboxBo GetBox(string operatorId, string boxId, string langId)
    {
        var boxConfig = GetTreasureBoxConfig(boxId);
        var box = new TreasureboxBo();
        if (boxConfig != null)
        {
            box.BoxID = boxConfig.BoxID;
            box.OperatorID = boxConfig.OperatorID;
            box.CurrencyID = boxConfig.CurrencyID;
            box.BatchCode = boxConfig.BatchCode;
            box.GrantType = boxConfig.GrantType;
            box.GrantValue = boxConfig.GrantValue;
            box.GrantLinkUrl = boxConfig.GrantLinkUrl;
            box.OpenType = boxConfig.OpenType;
            box.OpenValue = boxConfig.OpenValue;
            box.PoolStatus = boxConfig.PoolStatus;
            box.SkinIcon = boxConfig.SkinIcon;
            box.ExpireType = boxConfig.ExpireType;
            box.ExpireRegular = boxConfig.ExpireRegular;
            box.ExpireTime = boxConfig.ExpireTime;
            box.LimitNumType = boxConfig.LimitNumType;
            box.RecDate = boxConfig.RecDate;
            box.Lang = GetTreasureBoxLangConfig(operatorId, boxId, langId);
            box.OpenLang = GetTreasureOpenBoxConfig(boxId, langId);
            box.Awards = GetTreasureBoxAwardConfig(operatorId, boxId);
        }
        return box;
    }

    #region 宝箱实例缓存


    /// <summary>
    /// 获取单个宝箱实例
    /// </summary> 
    /// <param name="boxId"></param>
    /// <returns></returns> 
    public static Sa_treasureboxPO GetTreasureBoxConfig(string boxId)
    {
        return LoadTreasureBoxConfigCache(boxId);
    }

    /// <summary>
    /// 获取宝箱列表
    /// </summary>
    /// <param name="boxId"></param>
    /// <returns></returns>
    private static Sa_treasureboxPO LoadTreasureBoxConfigCache(string boxId)
    {
        return LoadTreasureBoxList().FirstOrDefault(w => w.BoxID == boxId);
    }

    #endregion

    #region 根据类型获取宝箱列表

    /// <summary>
    /// 根据类型获取红包列表
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="grantType"></param>
    /// <returns></returns>
    public static List<Sa_treasureboxPO> GetTreasureBoxs(string operatorId, int grantType)
    {
        var configs = LoadTreasureBoxList();
        return configs.Where(w => w.OperatorID == operatorId && w.GrantType == grantType).ToList();
    }

    /// <summary>
    /// 获取所有宝箱
    /// </summary>
    /// <returns></returns>
    private static List<Sa_treasureboxPO> LoadTreasureBoxList()
    {
        return DbCachingUtil.GetAllList<Sa_treasureboxPO>();
    }

    #endregion

    #region 宝箱打开语言实例缓存

    /// <summary>
    /// 获取单个打开宝箱d实例
    /// </summary>
    /// <param name="boxId"></param>
    /// <param name="langId"></param>
    /// <returns></returns>
    public static Sa_treasurebox_open_langPO GetTreasureOpenBoxConfig(string boxId, string langId)
    {
        return LoadTreasureBoxLangConfigCache().FirstOrDefault(w => w.BoxID == boxId && w.LangID == langId);
    }

    /// <summary>
    /// 获取宝箱列表
    /// </summary> 
    /// <returns></returns>
    private static List<Sa_treasurebox_open_langPO> LoadTreasureBoxLangConfigCache()
    {
        return DbCachingUtil.GetAllList<Sa_treasurebox_open_langPO>();
    }

    #endregion

    #region 宝箱语言实例缓存

    /// <summary>
    /// 获取宝箱语言列表
    /// </summary> 
    /// <returns></returns>
    private static List<Sa_treasurebox_langPO> LoadTreasureBoxLanguageConfigCache()
    {
        return DbCachingUtil.GetAllList<Sa_treasurebox_langPO>();
    }

    /// <summary>
    /// 获取宝箱语言表
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="boxId"></param>
    /// <param name="langId"></param>
    /// <returns></returns>
    public static Sa_treasurebox_langPO GetTreasureBoxLangConfig(string operatorId, string boxId, string langId)
    {
        return LoadTreasureBoxLanguageConfigCache().FirstOrDefault(w => w.OperatorID == operatorId && w.BoxID == boxId && w.LangID == langId);
    }
    #endregion

    #region 根据类型获取宝箱列表

    /// <summary>
    /// 红包内存对象
    /// </summary>
    /// <returns></returns>
    private static List<Sa_treasurebox_amount_poolPO> LoadTreasureBoxAmountConfigCache()
    {
        return DbCachingUtil.GetAllList<Sa_treasurebox_amount_poolPO>();
    }

    /// <summary>
    /// 根据类型获取红包列表
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="boxId"></param>
    /// <returns></returns>
    public static List<Sa_treasurebox_amount_poolPO> GetTreasureBoxAmountConfig(string operatorId, string boxId)
    {
        return LoadTreasureBoxAmountConfigCache().Where(w => w.OperatorID == operatorId && w.BoxID == boxId).ToList();
    }

    #endregion

    #region 根据类型获取宝箱列表

    /// <summary>
    /// 宝箱数量限制表
    /// </summary>
    /// <returns></returns>
    private static List<Sa_treasurebox_num_poolPO> LoadTreasureBoxNumConfigCache()
    {
        return DbCachingUtil.GetAllList<Sa_treasurebox_num_poolPO>();
    }

    /// <summary>
    /// 宝箱数量限制表
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="boxId"></param>
    /// <returns></returns>
    public static List<Sa_treasurebox_num_poolPO> GetTreasureBoxNumConfig(string operatorId, string boxId)
    {
        return LoadTreasureBoxNumConfigCache().Where(w => w.OperatorID == operatorId && w.BoxID == boxId).ToList();
    }

    #endregion

    #region 根据类型获取宝箱奖励 

    /// <summary>
    /// 获取宝箱的奖池
    /// </summary>
    /// <param name="operatorId"></param>
    /// <param name="boxId"></param>
    /// <returns></returns>
    public static List<Sa_treasurebox_awardPO> GetTreasureBoxAwardConfig(string operatorId, string boxId)
    {
        return LoadTreasureBoxAwardConfigCache().Where(w => w.OperatorID == operatorId && w.BoxID == boxId).ToList();
    }

    /// <summary>
    /// 红包内存对象
    /// </summary>
    /// <returns></returns>
    private static List<Sa_treasurebox_awardPO> LoadTreasureBoxAwardConfigCache()
    {
        return DbCachingUtil.GetAllList<Sa_treasurebox_awardPO>();
    }

    #endregion

    #region 奖励权重
    private static WeightRandomProvider<Sa_treasurebox_awardPO> _treasureBoxAwardWeight;
    private static WeightRandomProvider<Sa_treasurebox_awardPO> GetAwardsWeight(List<Sa_treasurebox_awardPO> awards)
    {
        lock (_sync)
        {
            if (awards != null)
            {
                _treasureBoxAwardWeight = new WeightRandomProvider<Sa_treasurebox_awardPO>();
                awards.ForEach(x => _treasureBoxAwardWeight.AddItem(x.Weight, x));
            }
        }
        return _treasureBoxAwardWeight;
    }

    /// <summary>
    /// 奖励权重
    /// </summary>
    /// <param name="awards"></param>
    /// <returns></returns>
    public static Sa_treasurebox_awardPO GetBonusNextWeight(List<Sa_treasurebox_awardPO> awards)
    {
        return GetAwardsWeight(awards).Next();
    }
    #endregion
}
