// -----------------------------------------------------------------------
// <copyright file="IApriori.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace AprioriAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IApriori
    {
        Output Solve(double minSupport, double minConfidence, IEnumerable<string> items, Dictionary<int, string> transactions);
    }
}