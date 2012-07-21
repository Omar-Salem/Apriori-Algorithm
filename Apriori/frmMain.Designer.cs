namespace Client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("a");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("b");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("c");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("d");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lv_Transactions = new System.Windows.Forms.ListView();
            this.col_TransId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_AddItem = new System.Windows.Forms.Button();
            this.grpbx_Items = new System.Windows.Forms.GroupBox();
            this.btn_ClearTransactions = new System.Windows.Forms.Button();
            this.lv_Items = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_DeleteTrans = new System.Windows.Forms.Button();
            this.btn_DeleteItem = new System.Windows.Forms.Button();
            this.btn_AddTrans = new System.Windows.Forms.Button();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.txt_Item = new System.Windows.Forms.TextBox();
            this.btn_EditTrans = new System.Windows.Forms.Button();
            this.btn_EndEdit = new System.Windows.Forms.Button();
            this.grpbx_Transactions = new System.Windows.Forms.GroupBox();
            this.txt_Confidence = new System.Windows.Forms.TextBox();
            this.lbl_Confidence = new System.Windows.Forms.Label();
            this.lbl_Support = new System.Windows.Forms.Label();
            this.txt_Support = new System.Windows.Forms.TextBox();
            this.btn_Solve = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpbx_Items.SuspendLayout();
            this.grpbx_Transactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_Transactions
            // 
            this.lv_Transactions.CheckBoxes = true;
            this.lv_Transactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_TransId,
            this.col_Items});
            this.lv_Transactions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lv_Transactions.GridLines = true;
            this.lv_Transactions.Location = new System.Drawing.Point(3, 16);
            this.lv_Transactions.Name = "lv_Transactions";
            this.lv_Transactions.Size = new System.Drawing.Size(235, 81);
            this.lv_Transactions.TabIndex = 3;
            this.lv_Transactions.UseCompatibleStateImageBehavior = false;
            this.lv_Transactions.View = System.Windows.Forms.View.Details;
            // 
            // col_TransId
            // 
            this.col_TransId.Text = "Trans. Id";
            // 
            // col_Items
            // 
            this.col_Items.Text = "Items";
            this.col_Items.Width = 244;
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Location = new System.Drawing.Point(143, 12);
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(75, 23);
            this.btn_AddItem.TabIndex = 1;
            this.btn_AddItem.Text = "Add Item";
            this.btn_AddItem.UseVisualStyleBackColor = true;
            this.btn_AddItem.Click += new System.EventHandler(this.btn_AddItem_Click);
            // 
            // grpbx_Items
            // 
            this.grpbx_Items.Controls.Add(this.lv_Items);
            this.grpbx_Items.Controls.Add(this.btn_DeleteItem);
            this.grpbx_Items.Controls.Add(this.btn_AddTrans);
            this.grpbx_Items.Controls.Add(this.lbl_Item);
            this.grpbx_Items.Controls.Add(this.txt_Item);
            this.grpbx_Items.Controls.Add(this.btn_AddItem);
            this.grpbx_Items.Location = new System.Drawing.Point(9, 11);
            this.grpbx_Items.Name = "grpbx_Items";
            this.grpbx_Items.Size = new System.Drawing.Size(316, 177);
            this.grpbx_Items.TabIndex = 5;
            this.grpbx_Items.TabStop = false;
            this.grpbx_Items.Text = "Items";
            // 
            // btn_ClearTransactions
            // 
            this.btn_ClearTransactions.Location = new System.Drawing.Point(244, 73);
            this.btn_ClearTransactions.Name = "btn_ClearTransactions";
            this.btn_ClearTransactions.Size = new System.Drawing.Size(68, 23);
            this.btn_ClearTransactions.TabIndex = 18;
            this.btn_ClearTransactions.Text = "&Clear All";
            this.btn_ClearTransactions.UseVisualStyleBackColor = true;
            this.btn_ClearTransactions.Click += new System.EventHandler(this.btn_ClearTransactions_Click);
            // 
            // lv_Items
            // 
            this.lv_Items.CheckBoxes = true;
            this.lv_Items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem});
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.lv_Items.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lv_Items.Location = new System.Drawing.Point(6, 74);
            this.lv_Items.Name = "lv_Items";
            this.lv_Items.Size = new System.Drawing.Size(121, 97);
            this.lv_Items.TabIndex = 16;
            this.lv_Items.UseCompatibleStateImageBehavior = false;
            this.lv_Items.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            // 
            // btn_DeleteTrans
            // 
            this.btn_DeleteTrans.Location = new System.Drawing.Point(244, 44);
            this.btn_DeleteTrans.Name = "btn_DeleteTrans";
            this.btn_DeleteTrans.Size = new System.Drawing.Size(68, 23);
            this.btn_DeleteTrans.TabIndex = 14;
            this.btn_DeleteTrans.Text = "&Delete";
            this.btn_DeleteTrans.UseVisualStyleBackColor = true;
            this.btn_DeleteTrans.Click += new System.EventHandler(this.btn_DeleteTrans_Click);
            // 
            // btn_DeleteItem
            // 
            this.btn_DeleteItem.Location = new System.Drawing.Point(233, 12);
            this.btn_DeleteItem.Name = "btn_DeleteItem";
            this.btn_DeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteItem.TabIndex = 13;
            this.btn_DeleteItem.Text = "Delete Item";
            this.btn_DeleteItem.UseVisualStyleBackColor = true;
            this.btn_DeleteItem.Click += new System.EventHandler(this.btn_DeleteItem_Click);
            // 
            // btn_AddTrans
            // 
            this.btn_AddTrans.Location = new System.Drawing.Point(132, 112);
            this.btn_AddTrans.Name = "btn_AddTrans";
            this.btn_AddTrans.Size = new System.Drawing.Size(176, 23);
            this.btn_AddTrans.TabIndex = 2;
            this.btn_AddTrans.Text = "&Add Transaction";
            this.btn_AddTrans.UseVisualStyleBackColor = true;
            this.btn_AddTrans.Click += new System.EventHandler(this.btn_AddTrans_Click);
            // 
            // lbl_Item
            // 
            this.lbl_Item.AutoSize = true;
            this.lbl_Item.Location = new System.Drawing.Point(9, 22);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(27, 13);
            this.lbl_Item.TabIndex = 12;
            this.lbl_Item.Text = "Item";
            // 
            // txt_Item
            // 
            this.txt_Item.Location = new System.Drawing.Point(50, 18);
            this.txt_Item.MaxLength = 1;
            this.txt_Item.Name = "txt_Item";
            this.txt_Item.Size = new System.Drawing.Size(42, 20);
            this.txt_Item.TabIndex = 0;
            this.txt_Item.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Item_KeyPress);
            // 
            // btn_EditTrans
            // 
            this.btn_EditTrans.Location = new System.Drawing.Point(244, 15);
            this.btn_EditTrans.Name = "btn_EditTrans";
            this.btn_EditTrans.Size = new System.Drawing.Size(68, 23);
            this.btn_EditTrans.TabIndex = 15;
            this.btn_EditTrans.Text = "&Edit";
            this.btn_EditTrans.UseVisualStyleBackColor = true;
            this.btn_EditTrans.Click += new System.EventHandler(this.btn_EditTrans_Click);
            // 
            // btn_EndEdit
            // 
            this.btn_EndEdit.Location = new System.Drawing.Point(244, 15);
            this.btn_EndEdit.Name = "btn_EndEdit";
            this.btn_EndEdit.Size = new System.Drawing.Size(68, 23);
            this.btn_EndEdit.TabIndex = 17;
            this.btn_EndEdit.Text = "End Edit";
            this.btn_EndEdit.UseVisualStyleBackColor = true;
            this.btn_EndEdit.Click += new System.EventHandler(this.btn_EndEdit_Click);
            // 
            // grpbx_Transactions
            // 
            this.grpbx_Transactions.Controls.Add(this.btn_ClearTransactions);
            this.grpbx_Transactions.Controls.Add(this.lv_Transactions);
            this.grpbx_Transactions.Controls.Add(this.btn_DeleteTrans);
            this.grpbx_Transactions.Controls.Add(this.btn_EditTrans);
            this.grpbx_Transactions.Controls.Add(this.btn_EndEdit);
            this.grpbx_Transactions.Location = new System.Drawing.Point(9, 193);
            this.grpbx_Transactions.Name = "grpbx_Transactions";
            this.grpbx_Transactions.Size = new System.Drawing.Size(319, 100);
            this.grpbx_Transactions.TabIndex = 6;
            this.grpbx_Transactions.TabStop = false;
            this.grpbx_Transactions.Text = "Transactions";
            // 
            // txt_Confidence
            // 
            this.txt_Confidence.Location = new System.Drawing.Point(107, 320);
            this.txt_Confidence.MaxLength = 3;
            this.txt_Confidence.Name = "txt_Confidence";
            this.txt_Confidence.Size = new System.Drawing.Size(44, 20);
            this.txt_Confidence.TabIndex = 1;
            this.txt_Confidence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Confidence_KeyPress);
            // 
            // lbl_Confidence
            // 
            this.lbl_Confidence.AutoSize = true;
            this.lbl_Confidence.Location = new System.Drawing.Point(18, 324);
            this.lbl_Confidence.Name = "lbl_Confidence";
            this.lbl_Confidence.Size = new System.Drawing.Size(83, 13);
            this.lbl_Confidence.TabIndex = 8;
            this.lbl_Confidence.Text = "min. Confidence";
            // 
            // lbl_Support
            // 
            this.lbl_Support.AutoSize = true;
            this.lbl_Support.Location = new System.Drawing.Point(18, 301);
            this.lbl_Support.Name = "lbl_Support";
            this.lbl_Support.Size = new System.Drawing.Size(66, 13);
            this.lbl_Support.TabIndex = 10;
            this.lbl_Support.Text = "min. Support";
            // 
            // txt_Support
            // 
            this.txt_Support.Location = new System.Drawing.Point(107, 297);
            this.txt_Support.MaxLength = 3;
            this.txt_Support.Name = "txt_Support";
            this.txt_Support.Size = new System.Drawing.Size(44, 20);
            this.txt_Support.TabIndex = 0;
            this.txt_Support.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Confidence_KeyPress);
            // 
            // btn_Solve
            // 
            this.btn_Solve.Location = new System.Drawing.Point(112, 344);
            this.btn_Solve.Name = "btn_Solve";
            this.btn_Solve.Size = new System.Drawing.Size(117, 42);
            this.btn_Solve.TabIndex = 2;
            this.btn_Solve.Text = "&Solve";
            this.btn_Solve.UseVisualStyleBackColor = true;
            this.btn_Solve.Click += new System.EventHandler(this.btn_Solve_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "%";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btn_Solve;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Solve);
            this.Controls.Add(this.lbl_Support);
            this.Controls.Add(this.txt_Support);
            this.Controls.Add(this.lbl_Confidence);
            this.Controls.Add(this.txt_Confidence);
            this.Controls.Add(this.grpbx_Transactions);
            this.Controls.Add(this.grpbx_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apriori";
            this.grpbx_Items.ResumeLayout(false);
            this.grpbx_Items.PerformLayout();
            this.grpbx_Transactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Transactions;
        private System.Windows.Forms.ColumnHeader col_TransId;
        private System.Windows.Forms.ColumnHeader col_Items;
        private System.Windows.Forms.Button btn_AddItem;
        private System.Windows.Forms.GroupBox grpbx_Items;
        private System.Windows.Forms.GroupBox grpbx_Transactions;
        private System.Windows.Forms.TextBox txt_Confidence;
        private System.Windows.Forms.Label lbl_Confidence;
        private System.Windows.Forms.Label lbl_Support;
        private System.Windows.Forms.TextBox txt_Support;
        private System.Windows.Forms.Button btn_Solve;
        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.TextBox txt_Item;
        private System.Windows.Forms.Button btn_AddTrans;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_DeleteItem;
        private System.Windows.Forms.Button btn_EditTrans;
        private System.Windows.Forms.Button btn_DeleteTrans;
        private System.Windows.Forms.ListView lv_Items;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.Button btn_EndEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ClearTransactions;
    }
}