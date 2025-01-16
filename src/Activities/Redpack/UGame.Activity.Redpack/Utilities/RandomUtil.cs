using Xxyy.Common;

namespace UGame.Activity.Redpack.Utilities;

/// <summary>
/// 随机函数
/// </summary>
public class RandomUtil
{

    private static readonly Random random = Random.Shared;
    private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    /// <summary>
    /// 随机生成7位用户名
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static List<string> GenerateRandomName(int length)
    {
        var names = new List<string>();
        for (int i = 0; i < length; i++)
        {
            char[] nameChar = new char[7];
            nameChar[0] = alphabet[random.Next(alphabet.Length)];
            nameChar[1] = alphabet[random.Next(alphabet.Length)];
            nameChar[2] = '*';
            nameChar[3] = '*';
            nameChar[4] = '*';
            nameChar[5] = alphabet[random.Next(alphabet.Length)];
            nameChar[6] = alphabet[random.Next(alphabet.Length)];
            names.Add(string.Join("", nameChar));
        }
        return names;
    }

    /// <summary>
    /// 获取随机金额
    /// </summary>
    /// <param name="min"></param>
    /// <param name="maxAmount"></param>
    /// <param name="remainSize"></param>
    /// <param name="currencyId"></param>
    /// <returns></returns>
    public static long NextAmount(double min, long maxAmount, int remainSize, string currencyId)
    {
        if (maxAmount == 0) return 0;
        if (remainSize == 1) return maxAmount;

        var max = (double)maxAmount.AToM(currencyId) / remainSize * 2;
        var money = Random.Shared.NextDouble() * max;
        money = money <= min ? min : money;
        return (Math.Floor(money * 100) / 100).MToA(currencyId);
    }

    /// <summary>
    /// 随机匹配值
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float NextFloat(float min, float max)
    {
        double val = random.NextDouble() * (max - min) + min;
        return (float)val;
    }

}

public class WeightRandomProvider<T>
{
    private class WeightRandomItem<T>
    {
        public float Weight { get; set; }

        public T Item { get; set; }
    }

    private List<WeightRandomItem<T>> _list = new List<WeightRandomItem<T>>();

    private bool _init;

    private object _sync = new object();

    private float _totalWeight;

    private List<WeightRandomItem<T>> _calcList;

    public void AddItem(float weight, T item)
    {
        _init = false;
        _list.Add(new WeightRandomItem<T>
        {
            Weight = weight,
            Item = item
        });
    }

    public void ClearItems()
    {
        _init = false;
        _list.Clear();
    }

    public void Init()
    {
        if (_init)
        {
            return;
        }

        lock (_sync)
        {
            if (!_init)
            {
                _calcList = (from x in _list
                             where x.Weight > 0
                             orderby x.Weight
                             select x).ToList();
                _totalWeight = _calcList.Sum((x) => x.Weight);
                _init = true;
            }
        }
    }

    public T Next()
    {
        Init();
        float num = 0;
        float num2 = RandomUtil.NextFloat(0, _totalWeight);
        foreach (WeightRandomItem<T> calc in _calcList)
        {
            num += calc.Weight;
            if (num > num2)
            {
                return calc.Item;
            }
        }

        throw new Exception("WeightRandomHelper没有获得随机数!");
    }
}
