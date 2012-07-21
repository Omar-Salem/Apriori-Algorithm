using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AprioriAlgorithm
{
    public class Rule : IComparable<Rule>
    {
        string strCombination, strRemaining;
        double _confidence;

        public Rule(string strCombination, string strRemaining, double Confidence)
        {
            this.strCombination = strCombination;
            this.strRemaining = strRemaining;
            this._confidence = Confidence;
        }
        public string X { get { return strCombination; } }
        public string Y { get { return strRemaining; } }
        public double Confidence { get { return _confidence; } }



        #region IComparable<clssRules> Members

        public int CompareTo(Rule other)
        {
            return X.CompareTo(other.X);
        }

        #endregion
    }
}