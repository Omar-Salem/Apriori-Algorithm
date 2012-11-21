using System;
using System.ComponentModel.Composition;

namespace AprioriAlgorithm
{
    [Export(typeof(ISorter))]
    class Sorter : ISorter
    {
        string ISorter.Sort(string token)
        {
            char[] tokenArray = token.ToCharArray();
            Array.Sort(tokenArray);
            return new string(tokenArray);
        }
    }
}
