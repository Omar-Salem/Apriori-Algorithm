// -----------------------------------------------------------------------
// <copyright file="AprioriOutput.cs" company="">
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
    public class Output
    {
        public List<Rule> StrongRules { get; set; }

        public List<string> MaximalItemSets { get; set; }

        public Dictionary<string, Dictionary<string, double>> ClosedItemSets { get; set; }

        public Dictionary<string, double> AllFrequentItems { get; set; }
    }
}