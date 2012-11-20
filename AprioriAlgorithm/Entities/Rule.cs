using System;

namespace AprioriAlgorithm
{
    public class Rule : IComparable<Rule>
    {
        string combination, remaining;
        double confidence;

        public Rule(string combination, string remaining, double confidence)
        {
            this.combination = combination;
            this.remaining = remaining;
            this.confidence = confidence;
        }

        public string X { get { return combination; } }

        public string Y { get { return remaining; } }

        public double Confidence { get { return confidence; } }

        #region IComparable<clssRules> Members

        public int CompareTo(Rule other)
        {
            return X.CompareTo(other.X);
        }

        #endregion
    }
}