using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AprioriAlgorithm;

namespace Client
{
    public partial class frmMain : Form
    {
        #region Global Variables
        Dictionary<int, string> transactions = new Dictionary<int, string>();
        int m_nLastTransId = 1;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_AddItem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(txt_Item, false))
            {
                string strNewItem = txt_Item.Text;
                foreach (ListViewItem lvItem in lv_Items.Items)
                {
                    if (lvItem.Text == strNewItem)
                    {
                        MessageBox.Show("Item (" + strNewItem + ") already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Item.Text = string.Empty;
                        return;
                    }
                }
                lv_Items.Items.Add(strNewItem);
                txt_Item.Text = string.Empty;
            }
        }

        private void btn_DeleteItem_Click(object sender, EventArgs e)
        {
            if (lv_Items.CheckedItems.Count > 0)
            {
                for (int i = lv_Items.CheckedItems.Count - 1; i >= 0; i--)
                {
                    List<int> lst_Transactions = new List<int>();
                    string strItemtoDelete = lv_Items.CheckedItems[i].ToString();
                    if (ItemIsRemovable(strItemtoDelete, ref lst_Transactions))
                    {
                        lv_Items.Items.Remove(lv_Items.CheckedItems[i]);
                    }
                    else
                    {
                        string strTransactions = string.Empty;
                        foreach (int nTransactionId in lst_Transactions)
                        {
                            strTransactions += nTransactionId.ToString() + ",";
                        }
                        strTransactions = strTransactions.Remove(strTransactions.Length - 1);
                        MessageBox.Show("Can not delete item " + strItemtoDelete + ", item exists in transactions " + strTransactions, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("please choose items to add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private bool ValidateInput(TextBox txtBox, bool bIsNumber)
        {
            if (txtBox.Text.Length == 0)
            {
                errorProvider1.SetError(txtBox, "please enter value");
                return false;
            }
            else
            {
                if (bIsNumber && int.Parse(txtBox.Text) > 100)
                {
                    errorProvider1.SetError(txtBox, "please enter value between 0 and 100");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(txtBox, "");
                    return true;
                }
            }
        }

        private void btn_AddTrans_Click(object sender, EventArgs e)
        {
            if (lv_Items.CheckedItems.Count <= 0)
            {
                MessageBox.Show("please choose items to add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string strTransactiondic;
            string strTransactionLV = GetTransactionFromListView(out strTransactiondic);
            ListViewItem lvi = new ListViewItem(m_nLastTransId.ToString());
            lvi.Tag = m_nLastTransId;
            lvi.SubItems.Add(strTransactionLV);
            lv_Transactions.Items.Add(lvi);
            transactions.Add(m_nLastTransId, strTransactiondic);
            m_nLastTransId++;

        }

        private void btn_EditTrans_Click(object sender, EventArgs e)
        {
            int nChosenTransactions = lv_Transactions.CheckedItems.Count;
            if (nChosenTransactions > 1 || nChosenTransactions == 0)
            {
                MessageBox.Show("please choose one transaction to modify", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            EnableControls(false);
            int nTransId = (int)lv_Transactions.CheckedItems[0].Tag;
            string strTransaction = transactions[nTransId];
            foreach (ListViewItem lvi in lv_Items.Items)
            {
                lvi.Checked = false;
            }
            foreach (char cItem in strTransaction)
            {
                for (int i = 0; i < lv_Items.Items.Count; i++)
                {
                    if (lv_Items.Items[i].Text == cItem.ToString())
                    {
                        lv_Items.Items[i].Checked = true;
                    }
                }
            }
        }

        private void btn_EndEdit_Click(object sender, EventArgs e)
        {
            EnableControls(true);
            int nTransId = (int)lv_Transactions.CheckedItems[0].Tag;
            string strTransactiondic;
            string strTransactionLV = GetTransactionFromListView(out strTransactiondic);
            transactions[nTransId] = strTransactiondic;
            ListViewItem lvi = lv_Transactions.CheckedItems[0];
            lvi.SubItems.Clear();
            lvi.SubItems[0].Text = nTransId.ToString();
            lvi.SubItems.Add(strTransactionLV);
        }

        private void btn_DeleteTrans_Click(object sender, EventArgs e)
        {
            int nChosenTransactions = lv_Transactions.CheckedItems.Count;
            if (nChosenTransactions < 1)
            {
                MessageBox.Show("please choose at least one transaction to delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < lv_Transactions.CheckedItems.Count; i++)
            {
                transactions.Remove((int)lv_Transactions.CheckedItems[i].Tag);
                lv_Transactions.Items.Remove(lv_Transactions.CheckedItems[i]);
            }
        }

        private void btn_ClearTransactions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear All Transactions ?", "Apriori", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                m_nLastTransId = 1;
                lv_Transactions.Items.Clear();
                transactions.Clear();
            }
        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            #region validation
            if (!ValidateInput(txt_Support, true) || !ValidateInput(txt_Confidence, true))
            {
                return;
            }
            if (lv_Transactions.Items.Count <= 0)
            {
                MessageBox.Show("Enter Transactions first", "Apriori", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            IApriori Apriori = new Apriori();
            double minSupport = double.Parse(txt_Support.Text) / 100;
            double minConfidence = double.Parse(txt_Confidence.Text) / 100;
            IEnumerable<string> Items = GetItems();
            var ourput = Apriori.Solve(minSupport, minConfidence, Items, transactions);

            frmOutput objfrmOutput = new frmOutput(ourput);
            objfrmOutput.ShowDialog();
        }

        private IEnumerable<string> GetItems()
        {
            foreach (ListViewItem item in lv_Items.Items)
            {
                yield return item.Text;
            }
        }

        private void txt_Confidence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txt_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private string GetTransactionFromListView(out string strTransactiondic)
        {
            strTransactiondic = string.Empty;
            string strTransactionReturn = string.Empty;
            foreach (ListViewItem lviCheckedItem in lv_Items.CheckedItems)
            {
                strTransactiondic += lviCheckedItem.Text;
                strTransactionReturn += lviCheckedItem.Text + ",";
            }
            strTransactionReturn = strTransactionReturn.Remove(strTransactionReturn.Length - 1);
            return strTransactionReturn;
        }

        private void EnableControls(bool bEnable)
        {
            btn_AddItem.Enabled = bEnable;
            btn_DeleteItem.Enabled = bEnable;
            btn_AddTrans.Enabled = bEnable;
            btn_EditTrans.Visible = bEnable;
            btn_DeleteTrans.Enabled = bEnable;
            btn_ClearTransactions.Enabled = bEnable;
            btn_Solve.Enabled = bEnable;
            lv_Transactions.Enabled = bEnable;
        }

        private bool ItemIsRemovable(string strItem, ref List<int> lst_Transactions)
        {
            string strTransaction;
            bool bItemRemovable = true;
            foreach (int nTransaction in transactions.Keys)
            {
                strTransaction = transactions[nTransaction];
                if (strTransaction.Contains(strItem))
                {
                    lst_Transactions.Add(nTransaction);
                    bItemRemovable = false;
                }
            }
            return bItemRemovable;
        }

      }
}
