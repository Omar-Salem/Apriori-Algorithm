using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AprioriAlgorithm;

namespace Client
{
    public partial class frmOutput : Form
    {
        public frmOutput(Output output)
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

        private void LoadRules(IList<Rule> lstStrongRules)
        {
            foreach (Rule Rule in lstStrongRules)
            {
                ListViewItem lvi = new ListViewItem(Rule.X + "-->" + Rule.Y);
                lvi.SubItems.Add(String.Format("{0:0.00}", (Rule.Confidence * 100)) + "%");
                lv_Rules.Items.Add(lvi);
            }
        }

        private void LoadFrequentItems(Dictionary<string, double> dicFrequentItems)
        {
            foreach (string strItem in dicFrequentItems.Keys)
            {
                ListViewItem lvi = new ListViewItem(strItem);
                lvi.SubItems.Add(dicFrequentItems[strItem].ToString());
                lv_Frequent.Items.Add(lvi);
            }
        }
    }
}
