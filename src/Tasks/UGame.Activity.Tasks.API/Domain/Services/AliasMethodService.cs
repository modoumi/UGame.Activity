namespace UGame.Activity.Tasks.API.Domain.Services;

public class ProbabilityPrize
{
    public double Probability { get; set; }
    public object Prize { get; set; }
}
public class AliasMethodService
{
    private readonly int[] aliasIndices;
    private readonly double[] indexProbabilities;
    private readonly Dictionary<int, object> probPrizes = new();

    public AliasMethodService(List<ProbabilityPrize> probPrizes)
    {
        var probabilities = new List<double>();
        int index = 0;
        foreach (var probPrize in probPrizes)
        {
            this.probPrizes[index] = probPrize.Prize;
            probabilities.Add(probPrize.Probability);
            index++;
        }

        this.indexProbabilities = new double[probabilities.Count];
        this.aliasIndices = new int[probabilities.Count];
        double average = 1.0 / probabilities.Count;

        var smallIndex = new Stack<int>();
        var largeIndex = new Stack<int>();
        for (int i = 0; i < probabilities.Count; ++i)
        {
            if (probabilities[i] >= average)
                largeIndex.Push(i);
            else smallIndex.Push(i);
        }
        while (smallIndex.Count > 0 && largeIndex.Count > 0)
        {
            int less = smallIndex.Pop();
            int more = largeIndex.Pop();

            this.indexProbabilities[less] = probabilities[less] * probabilities.Count;
            this.aliasIndices[less] = more;
            probabilities[more] = probabilities[more] + probabilities[less] - average;
            if (probabilities[more] >= average)
                largeIndex.Push(more);
            else smallIndex.Push(more);
        }
        while (smallIndex.Count > 0)
            this.indexProbabilities[smallIndex.Pop()] = 1.0;
        while (largeIndex.Count > 0)
            this.indexProbabilities[largeIndex.Pop()] = 1.0;
    }
    public TPrize Next<TPrize>()
    {
        long tick = DateTime.Now.Ticks;
        var seed = (int)(tick & 0xffffffffL) | (int)(tick >> 32);
        unchecked
        {
            seed = seed + new Random().Next(0, 100);
        }
        var random = new Random(seed);
        int index = random.Next(this.indexProbabilities.Length);
        bool coinToss = random.NextDouble() < this.indexProbabilities[index];
        var prizeIndex = coinToss ? index : this.aliasIndices[index];
        return (TPrize)this.probPrizes[prizeIndex];
    }
}
