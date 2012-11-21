namespace Client
{
    partial class Result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result));
            this.gb_FrequentItems = new System.Windows.Forms.GroupBox();
            this.lv_Frequent = new System.Windows.Forms.ListView();
            this.colItem = new System.Windows.Forms.ColumnHeader();
            this.colSupport = new System.Windows.Forms.ColumnHeader();
            this.gb_MaximalItems = new System.Windows.Forms.GroupBox();
            this.lb_maximal = new System.Windows.Forms.ListBox();
            this.gb_ClosedItems = new System.Windows.Forms.GroupBox();
            this.lb_closed = new System.Windows.Forms.ListBox();
            this.gb_StrongRules = new System.Windows.Forms.GroupBox();
            this.lv_Rules = new System.Windows.Forms.ListView();
            this.colRule = new System.Windows.Forms.ColumnHeader();
            this.colConfidence = new System.Windows.Forms.ColumnHeader();
            this.gb_FrequentItems.SuspendLayout();
            this.gb_MaximalItems.SuspendLayout();
            this.gb_ClosedItems.SuspendLayout();
            this.gb_StrongRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_FrequentItems
            // 
            this.gb_FrequentItems.Controls.Add(this.lv_Frequent);
            this.gb_FrequentItems.Location = new System.Drawing.Point(12, 12);
            this.gb_FrequentItems.Name = "gb_FrequentItems";
            this.gb_FrequentItems.Size = new System.Drawing.Size(158, 152);
            this.gb_FrequentItems.TabIndex = 0;
            this.gb_FrequentItems.TabStop = false;
            this.gb_FrequentItems.Text = "Frequent Items";
            // 
            // lv_Frequent
            // 
            this.lv_Frequent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colSupport});
            this.lv_Frequent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Frequent.Location = new System.Drawing.Point(3, 16);
            this.lv_Frequent.Name = "lv_Frequent";
            this.lv_Frequent.Size = new System.Drawing.Size(152, 133);
            this.lv_Frequent.TabIndex = 0;
            this.lv_Frequent.UseCompatibleStateImageBehavior = false;
            this.lv_Frequent.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 66;
            // 
            // colSupport
            // 
            this.colSupport.Text = "Support";
            // 
            // gb_MaximalItems
            // 
            this.gb_MaximalItems.Controls.Add(this.lb_maximal);
            this.gb_MaximalItems.Location = new System.Drawing.Point(194, 12);
            this.gb_MaximalItems.Name = "gb_MaximalItems";
            this.gb_MaximalItems.Size = new System.Drawing.Size(158, 152);
            this.gb_MaximalItems.TabIndex = 1;
            this.gb_MaximalItems.TabStop = false;
            this.gb_MaximalItems.Text = "Maximal Items";
            // 
            // lb_maximal
            // 
            this.lb_maximal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_maximal.FormattingEnabled = true;
            this.lb_maximal.Location = new System.Drawing.Point(3, 16);
            this.lb_maximal.Name = "lb_maximal";
            this.lb_maximal.Size = new System.Drawing.Size(152, 121);
            this.lb_maximal.TabIndex = 1;
            // 
            // gb_ClosedItems
            // 
            this.gb_ClosedItems.Controls.Add(this.lb_closed);
            this.gb_ClosedItems.Location = new System.Drawing.Point(12, 174);
            this.gb_ClosedItems.Name = "gb_ClosedItems";
            this.gb_ClosedItems.Size = new System.Drawing.Size(158, 152);
            this.gb_ClosedItems.TabIndex = 1;
            this.gb_ClosedItems.TabStop = false;
            this.gb_ClosedItems.Text = "Closed Items";
            // 
            // lb_closed
            // 
            this.lb_closed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_closed.FormattingEnabled = true;
            this.lb_closed.Location = new System.Drawing.Point(3, 16);
            this.lb_closed.Name = "lb_closed";
            this.lb_closed.Size = new System.Drawing.Size(152, 121);
            this.lb_closed.TabIndex = 1;
            // 
            // gb_StrongRules
            // 
            this.gb_StrongRules.Controls.Add(this.lv_Rules);
            this.gb_StrongRules.Location = new System.Drawing.Point(194, 174);
            this.gb_StrongRules.Name = "gb_StrongRules";
            this.gb_StrongRules.Size = new System.Drawing.Size(158, 152);
            this.gb_StrongRules.TabIndex = 1;
            this.gb_StrongRules.TabStop = false;
            this.gb_StrongRules.Text = "Strong Rules";
            // 
            // lv_Rules
            // 
            this.lv_Rules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRule,
            this.colConfidence});
            this.lv_Rules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Rules.Location = new System.Drawing.Point(3, 16);
            this.lv_Rules.Name = "lv_Rules";
            this.lv_Rules.Size = new System.Drawing.Size(152, 133);
            this.lv_Rules.TabIndex = 1;
            this.lv_Rules.UseCompatibleStateImageBehavior = false;
            this.lv_Rules.View = System.Windows.Forms.View.Details;
            // 
            // colRule
            // 
            this.colRule.Text = "Rules";
            this.colRule.Width = 71;
            // 
            // colConfidence
            // 
            this.colConfidence.Text = "Confidence";
            this.colConfidence.Width = 76;
            // 
            // frmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 338);
            this.Controls.Add(this.gb_ClosedItems);
            this.Controls.Add(this.gb_StrongRules);
            this.Controls.Add(this.gb_MaximalItems);
            this.Controls.Add(this.gb_FrequentItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOutput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Output";
            this.gb_FrequentItems.ResumeLayout(false);
            this.gb_MaximalItems.ResumeLayout(false);
            this.gb_ClosedItems.ResumeLayout(false);
            this.gb_StrongRules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_FrequentItems;
        private System.Windows.Forms.GroupBox gb_MaximalItems;
        private System.Windows.Forms.GroupBox gb_ClosedItems;
        private System.Windows.Forms.GroupBox gb_StrongRules;
        private System.Windows.Forms.ListBox lb_maximal;
        private System.Windows.Forms.ListBox lb_closed;
        private System.Windows.Forms.ListView lv_Frequent;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colSupport;
        private System.Windows.Forms.ListView lv_Rules;
        private System.Windows.Forms.ColumnHeader colRule;
        private System.Windows.Forms.ColumnHeader colConfidence;
    }
}