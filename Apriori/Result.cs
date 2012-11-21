using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AprioriAlgorithm;

namespace Client
{
    public partial class Result : Form
    {
        public Result(Output output)
        {
            InitializeComponent();
            LoadClosedItems(output.ClosedItemSets);
            lb_maximal.DataSource = output.MaximalItemSets;
            LoadFrequentItems(output.FrequentItems);
            LoadRules(output.StrongRules);
        }

        private void LoadClosedItems(Dictionary<string, Dictionary<string, double>> dicClosedItemSets)
        {
            foreach (string strItem in dicClosedItemSets.Keys)
            {
                lb_closed.Items.Add(strItem);
            }
        }

        private void LoadRules(IList<Rule> strongRules)
        {
            foreach (Rule Rule in strongRules)
            {
                ListViewItem lvi = new ListViewItem(Rule.X + "-->" + Rule.Y);
                lvi.SubItems.Add(String.Format("{0:0.00}", (Rule.Confidence * 100)) + "%");
                lv_Rules.Items.Add(lvi);
            }
        }

        private void LoadFrequentItems(IndexedDictionary frequentItems)
        {
            foreach (var Item in frequentItems)
            {
                ListViewItem lvi = new ListViewItem(Item.Name);
                lvi.SubItems.Add(Item.Support.ToString());
                lv_Frequent.Items.Add(lvi);
            }
        }
    }
}