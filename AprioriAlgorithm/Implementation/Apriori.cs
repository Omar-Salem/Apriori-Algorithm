namespace AprioriAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Apriori : IApriori
    {
        private readonly IndexedDictionary _allFrequentItems;

        public Apriori()
        {
            _allFrequentItems = new IndexedDictionary();
        }

        #region IApriori

        Output IApriori.Solve(double minSupport, double minConfidence, IEnumerable<string> items, Dictionary<int, string> transactions)
        {
            IList<Item> frequentItems = GetL1FrequentItems(minSupport, items, transactions);
            Dictionary<string, double> candidates = new Dictionary<string, double>();
            double transactionsCount = transactions.Count;

            do
            {
                candidates = GenerateCandidates(frequentItems, transactions);
                frequentItems = GetFrequentItems(candidates, minSupport, transactionsCount);
            }
            while (candidates.Count != 0);

            var closedItemSets = GetClosedItemSets();
            var maximalItemSets = GetMaximalItemSets(closedItemSets);
            var rules = GenerateRules();
            var strongRules = GetStrongRules(minConfidence, rules);

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

        private IList<Item> GetL1FrequentItems(double minSupport, IEnumerable<string> items, Dictionary<int, string> transactions)
        {
            var frequentItemsL1 = new List<Item>();
            double transactionsCount = transactions.Count;

            foreach (var item in items)
            {
                double support = GetSupport(item, transactions);

                if ((support / transactionsCount >= minSupport))
                {
                    frequentItemsL1.Add(new Item { Name = item, Support = support });
                    _allFrequentItems.Add(new Item { Name = item, Support = support });
                }
            }

            return frequentItemsL1;
        }

        private double GetSupport(string strGeneratedCandidate, Dictionary<int, string> transactions)
        {
            double support = 0;

            foreach (string transaction in transactions.Values)
            {
                if (CheckIsSubset(strGeneratedCandidate, transaction))
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

        private Dictionary<string, double> GenerateCandidates(IList<Item> frequentItems, Dictionary<int, string> transactions)
        {
            Dictionary<string, double> candidates = new Dictionary<string, double>();

            for (int i = 0; i < frequentItems.Count - 1; i++)
            {
                string firstItem = Sort(frequentItems[i].Name);

                for (int j = i + 1; j < frequentItems.Count; j++)
                {
                    string secondItem = Sort(frequentItems[j].Name);
                    string generatedCandidate = GetCandidate(firstItem, secondItem);

                    if (generatedCandidate != string.Empty)
                    {
                        generatedCandidate = Sort(generatedCandidate);
                        double dSupport = GetSupport(generatedCandidate, transactions);
                        candidates.Add(generatedCandidate, dSupport);
                    }
                }
            }

            return candidates;
        }

        private string Sort(string token)
        {
            char[] tokenArray = token.ToCharArray();
            Array.Sort(tokenArray);
            return new string(tokenArray);
        }

        private string GetCandidate(string firstItem, string secondItem)
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

        private IList<Item> GetFrequentItems(Dictionary<string, double> candidates, double minSupport, double transactionsCount)
        {
            var frequentItems = new List<Item>();

            foreach (var item in candidates)
            {
                if ((item.Value / transactionsCount >= minSupport))
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
                var parents = GetItemParents(item.Name, ++i);

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
                var parents = closedItemSets[item];

                if (parents.Count == 0)
                {
                    maximalItemSets.Add(item);
                }
            }

            return maximalItemSets;
        }

        private IList<Rule> GenerateRules()
        {
            var rules = new List<Rule>();

            foreach (var item in _allFrequentItems)
            {
                if (item.Name.Length > 1)
                {
                    int maxCombinationLength = item.Name.Length / 2;
                    GenerateCombination(item.Name, maxCombinationLength, ref rules);
                }
            }

            return rules;
        }

        private void GenerateCombination(string item, int combinationLength, ref List<Rule> rules)
        {
            int itemLength = item.Length;

            switch (itemLength)
            {
                case 2:
                    AddItem(item[0].ToString(), item, ref rules);
                    break;
                case 3:
                    for (int i = 0; i < itemLength; i++)
                    {
                        AddItem(item[i].ToString(), item, ref rules);
                    }
                    break;
                default:
                    for (int i = 0; i < itemLength; i++)
                    {
                        GetCombinationRecursive(item[i].ToString(), item, combinationLength, ref rules);
                    }
                    break;
            }
        }

        private void AddItem(string combination, string item, ref List<Rule> rules)
        {
            string remaining = GetRemaining(combination, item);
            Rule rule = new Rule(combination, remaining, 0);
            rules.Add(rule);
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

        private string GetCombinationRecursive(string combination, string item, int combinationLength, ref List<Rule> rules)
        {
            AddItem(combination, item, ref rules);

            char lastTokenCharacter = combination[combination.Length - 1];
            int lastTokenCharcaterIndex = combination.IndexOf(lastTokenCharacter);
            int lastTokenCharcaterIndexInParent = item.IndexOf(lastTokenCharacter);
            char lastItemCharacter = item[item.Length - 1];

            string newToken;

            if (combination.Length == combinationLength)
            {
                if (lastTokenCharacter == lastItemCharacter)
                {
                    return string.Empty;

                }

                combination = combination.Remove(lastTokenCharcaterIndex, 1);
                char nextCharacter = item[lastTokenCharcaterIndexInParent + 1];
                newToken = combination + nextCharacter;

            }
            else
            {
                if (combination != lastItemCharacter.ToString())
                {
                    return string.Empty;
                }

                char cNextCharacter = item[lastTokenCharcaterIndexInParent + 1];
                newToken = combination + cNextCharacter;
            }

            return (GetCombinationRecursive(newToken, item, combinationLength, ref rules));
        }

        private IList<Rule> GetStrongRules(double minConfidence, IList<Rule> rules)
        {
            var strongRules = new List<Rule>();

            foreach (Rule rule in rules)
            {
                string XY = Sort(rule.X + rule.Y);
                AddStrongRule(rule, XY, ref strongRules, minConfidence);
            }

            strongRules.Sort();
            return strongRules;
        }

        private void AddStrongRule(Rule rule, string XY, ref List<Rule> strongRules, double minConfidence)
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
            double support_X = _allFrequentItems[X].Support;
            double support_XY = _allFrequentItems[XY].Support;
            return support_XY / support_X;
        }

        #endregion
    }
}