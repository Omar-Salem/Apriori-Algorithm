namespace AprioriAlgorithm
{
    using System.Collections.Generic;

    public interface IApriori
    {
        Output ProcessTransaction(double minSupport, double minConfidence, IEnumerable<string> items, IDictionary<int, string> transactions);
    }
}