using TinyFx.Randoms;
using UGame.Activity.Cupon.Repositories;

namespace UGame.Activity.Cupon.Caching;

/// <summary>
///  兑换码权重设置
/// </summary>
public class CuponDbCacheUtil
{
    private static object _sync = new object();
    
    #region 兑换码权重
    private static WeightRandomProvider<Sa_cupon_rulePO> _configWeight;
    private static WeightRandomProvider<Sa_cupon_rulePO> GetWeight(List<Sa_cupon_rulePO> bonus)
    {
        lock (_sync)
        {
            _configWeight = new WeightRandomProvider<Sa_cupon_rulePO>();
            bonus.ForEach(x => _configWeight.AddItem(x.Weight, x));
        }
        return _configWeight;
    }

    /// <summary>
    ///兑换码权重
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Sa_cupon_rulePO GetCuponWeight(List<Sa_cupon_rulePO> list)
    {
        return GetWeight(list).Next();
    }
    #endregion

    
}
