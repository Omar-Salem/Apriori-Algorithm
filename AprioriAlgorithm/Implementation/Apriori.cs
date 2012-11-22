namespace AprioriAlgorithm
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;
    using System.Text;

    [Export(typeof(IApriori))]
    public class Apriori : IApriori
    {
        #region Member Variables

        readonly ItemsDictionary _allFrequentItems;
        readonly ISorter _sorter;

        #endregion

        #region Constructor

        public Apriori()
        {
            _allFrequentItems = new ItemsDictionary();
            _sorter = ContainerProvider.Container.GetExportedValue<ISorter>();
        }

        #endregion

        #region IApriori

        Output IApriori.ProcessTransaction(double minSupport, double minConfidence, IEnumerable<string> items, string[] transactions)
        {
            IList<Item> frequentItems = GetL1FrequentItems(minSupport, items, transactions);
            IDictionary<string, double> candidates = new Dictionary<string, double>();
            double transactionsCount = transactions.Count();

            do
            {
                candidates = GenerateCandidates(frequentItems, transactions);
                frequentItems = GetFrequentItems(candidates, minSupport, transactionsCount);
            }
            while (candidates.Count != 0);

            HashSet<Rule> rules = GenerateRules();
            IList<Rule> strongRules = GetStrongRules(minConfidence, rules);
            Dictionary<string, Dictionary<string, double>> closedItemSets = GetClosedItemSets();
            IList<string> maximalItemSets = GetMaximalItemSets(closedItemSets);

            return new Output
            {
                StrongRules = strongRules,
                MaximalItemSets = maximalItemSets,
                ClosedItemSets = closedItemSets,
                FrequentItems = _allFrequentItems
            };
        }

        #endregion

        #region Private Methods

        private List<Item> GetL1FrequentItems(double minSupport, IEnumerable<string> items, IEnumerable<string> transactions)
        {
            var frequentItemsL1 = new List<Item>();
            double transactionsCount = transactions.Count();

            foreach (var item in items)
            {
                double support = GetSupport(item, transactions);

                if (support / transactionsCount >= minSupport)
                {
                    frequentItemsL1.Add(new Item { Name = item, Support = support });
                    _allFrequentItems.Add(new Item { Name = item, Support = support });
                }
            }
            frequentItemsL1.Sort();
            return frequentItemsL1;
        }

        private double GetSupport(string generatedCandidate, IEnumerable<string> transactionsList)
        {
            double support = 0;

            foreach (string transaction in transactionsList)
            {
                if (CheckIsSubset(generatedCandidate, transaction))
                {
                    support++;
                }
            }

            return support;
        }

        private bool CheckIsSubset(string child, string parent)
        {
            foreach (char c in child)
            {
                if (!parent.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, double> GenerateCandidates(IList<Item> frequentItems, IEnumerable<string> transactions)
        {
            Dictionary<string, double> candidates = new Dictionary<string, double>();

            for (int i = 0; i < frequentItems.Count - 1; i++)
            {
                string firstItem = _sorter.Sort(frequentItems[i].Name);

                for (int j = i + 1; j < frequentItems.Count; j++)
                {
                    string secondItem = _sorter.Sort(frequentItems[j].Name);
                    string generatedCandidate = GenerateCandidate(firstItem, secondItem);

                    if (generatedCandidate != string.Empty)
                    {
                        double support = GetSupport(generatedCandidate, transactions);
                        candidates.Add(generatedCandidate, support);
                    }
                }
            }

            return candidates;
        }

        private string GenerateCandidate(string firstItem, string secondItem)
        {
            int length = firstItem.Length;

            if (length == 1)
            {
                return firstItem + secondItem;
            }
            else
            {
                string firstSubString = firstItem.Substring(0, length - 1);
                string secondSubString = secondItem.Substring(0, length - 1);

                if (firstSubString == secondSubString)
                {
                    return firstItem + secondItem[length - 1];
                }

                return string.Empty;
            }
        }

        private List<Item> GetFrequentItems(IDictionary<string, double> candidates, double minSupport, double transactionsCount)
        {
            var frequentItems = new List<Item>();

            foreach (var item in candidates)
            {
                if (item.Value / transactionsCount >= minSupport)
                {
                    frequentItems.Add(new Item { Name = item.Key, Support = item.Value });
                    _allFrequentItems.Add(new Item { Name = item.Key, Support = item.Value });
                }
            }

            return frequentItems;
        }

        private Dictionary<string, Dictionary<string, double>> GetClosedItemSets()
        {
            var closedItemSets = new Dictionary<string, Dictionary<string, double>>();
            int i = 0;

            foreach (var item in _allFrequentItems)
            {
                Dictionary<string, double> parents = GetItemParents(item.Name, ++i);

                if (CheckIsClosed(item.Name, parents))
                {
                    closedItemSets.Add(item.Name, parents);
                }
            }

            return closedItemSets;
        }

        private Dictionary<string, double> GetItemParents(string child, int index)
        {
            var parents = new Dictionary<string, double>();

            for (int j = index; j < _allFrequentItems.Count; j++)
            {
                string parent = _allFrequentItems[j].Name;

                if (parent.Length == child.Length + 1)
                {
                    if (CheckIsSubset(child, parent))
                    {
                        parents.Add(parent, _allFrequentItems[parent].Support);
                    }
                }
            }

            return parents;
        }

        private bool CheckIsClosed(string child, Dictionary<string, double> parents)
        {
            foreach (string parent in parents.Keys)
            {
                if (_allFrequentItems[child].Support == _allFrequentItems[parent].Support)
                {
                    return false;
                }
            }

            return true;
        }

        private IList<string> GetMaximalItemSets(Dictionary<string, Dictionary<string, double>> closedItemSets)
        {
            var maximalItemSets = new List<string>();

            foreach (string item in closedItemSets.Keys)
            {
                Dictionary<string, double> parents = closedItemSets[item];

                if (parents.Count == 0)
                {
                    maximalItemSets.Add(item);
                }
            }

            return maximalItemSets;
        }

        private HashSet<Rule> GenerateRules()
        {
            var rulesList = new HashSet<Rule>();

            foreach (var item in _allFrequentItems)
            {
                if (item.Name.Length > 1)
                {
                    IEnumerable<string> subsetsList = GenerateSubsets(item.Name);

                    foreach (var subset in subsetsList)
                    {
                        string remaining = GetRemaining(subset, item.Name);
                        Rule rule = new Rule(subset, remaining, 0);

                        if (!rulesList.Contains(rule))
                        {
                            rulesList.Add(rule);
                        }
                    }
                }
            }

            return rulesList;
        }

        private IEnumerable<string> GenerateSubsets(string item)
        {
            IEnumerable<string> allSubsets = new string[] { };
            int subsetLength = item.Length / 2;

            for (int i = 1; i <= subsetLength; i++)
            {
                IList<string> subsets = new List<string>();
                GenerateSubsetsRecursive(item, i, new char[item.Length], subsets);
                allSubsets = allSubsets.Concat(subsets);
            }

            return allSubsets;
        }

        private void GenerateSubsetsRecursive(string item, int subsetLength, char[] temp, IList<string> subsets, int q = 0, int r = 0)
        {
            if (q == subsetLength)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < subsetLength; i++)
                {
                    sb.Append(temp[i]);
                }

                subsets.Add(sb.ToString());
            }

            else
            {
                for (int i = r; i < item.Length; i++)
                {
                    temp[q] = item[i];
                    GenerateSubsetsRecursive(item, subsetLength, temp, subsets, q + 1, i + 1);
                }
            }
        }

        private string GetRemaining(string child, string parent)
        {
            for (int i = 0; i < child.Length; i++)
            {
                int index = parent.IndexOf(child[i]);
                parent = parent.Remove(index, 1);
            }

            return parent;
        }

        private IList<Rule> GetStrongRules(double minConfidence, HashSet<Rule> rules)
        {
            var strongRules = new List<Rule>();

            foreach (Rule rule in rules)
            {
                string xy = _sorter.Sort(rule.X + rule.Y);
                AddStrongRule(rule, xy, strongRules, minConfidence);
            }

            strongRules.Sort();
            return strongRules;
        }

        private void AddStrongRule(Rule rule, string XY, List<Rule> strongRules, double minConfidence)
        {
            double confidence = GetConfidence(rule.X, XY);

            if (confidence >= minConfidence)
            {
                Rule newRule = new Rule(rule.X, rule.Y, confidence);
                strongRules.Add(newRule);
            }

            confidence = GetConfidence(rule.Y, XY);

            if (confidence >= minConfidence)
            {
                Rule newRule = new Rule(rule.Y, rule.X, confidence);
                strongRules.Add(newRule);
            }
        }

        private double GetConfidence(string X, string XY)
        {
            double supportX = _allFrequentItems[X].Support;
            double supportXY = _allFrequentItems[XY].Support;
            return supportXY / supportX;
        }

        #endregion
    }
}