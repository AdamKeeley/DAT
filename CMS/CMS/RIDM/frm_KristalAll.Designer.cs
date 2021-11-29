namespace CMS.RIDM
{
    partial class frm_KristalAll
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
            this.cb_GrantStage = new System.Windows.Forms.ComboBox();
            this.lbl_GrantStage = new System.Windows.Forms.Label();
            this.dgv_KristalList = new System.Windows.Forms.DataGridView();
            this.lbl_recordCount = new System.Windows.Forms.Label();
            this.lbl_KristalName = new System.Windows.Forms.Label();
            this.tb_KristalName = new System.Windows.Forms.TextBox();
            this.lbl_KristalRef = new System.Windows.Forms.Label();
            this.tb_KristalRef = new System.Windows.Forms.TextBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_ClearSearch = new System.Windows.Forms.Button();
            this.btn_NewGrant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalList)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_GrantStage
            // 
            this.cb_GrantStage.FormattingEnabled = true;
            this.cb_GrantStage.Location = new System.Drawing.Point(341, 6);
            this.cb_GrantStage.Name = "cb_GrantStage";
            this.cb_GrantStage.Size = new System.Drawing.Size(124, 21);
            this.cb_GrantStage.TabIndex = 0;
            this.cb_GrantStage.TextChanged += new System.EventHandler(this.searchItemAddedKristalAll);
            // 
            // lbl_GrantStage
            // 
            this.lbl_GrantStage.AutoSize = true;
            this.lbl_GrantStage.Location = new System.Drawing.Point(271, 9);
            this.lbl_GrantStage.Name = "lbl_GrantStage";
            this.lbl_GrantStage.Size = new System.Drawing.Size(64, 13);
            this.lbl_GrantStage.TabIndex = 1;
            this.lbl_GrantStage.Text = "Grant Stage";
            // 
            // dgv_KristalList
            // 
            this.dgv_KristalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KristalList.Location = new System.Drawing.Point(15, 58);
            this.dgv_KristalList.Name = "dgv_KristalList";
            this.dgv_KristalList.RowHeadersVisible = false;
            this.dgv_KristalList.Size = new System.Drawing.Size(450, 177);
            this.dgv_KristalList.TabIndex = 2;
            // 
            // lbl_recordCount
            // 
            this.lbl_recordCount.Location = new System.Drawing.Point(453, 238);
            this.lbl_recordCount.Name = "lbl_recordCount";
            this.lbl_recordCount.Size = new System.Drawing.Size(100, 23);
            this.lbl_recordCount.TabIndex = 73;
            this.lbl_recordCount.Text = "# records";
            this.lbl_recordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_KristalName
            // 
            this.lbl_KristalName.AutoSize = true;
            this.lbl_KristalName.Location = new System.Drawing.Point(12, 35);
            this.lbl_KristalName.Name = "lbl_KristalName";
            this.lbl_KristalName.Size = new System.Drawing.Size(66, 13);
            this.lbl_KristalName.TabIndex = 74;
            this.lbl_KristalName.Text = "Kristal Name";
            // 
            // tb_KristalName
            // 
            this.tb_KristalName.Location = new System.Drawing.Point(131, 32);
            this.tb_KristalName.Name = "tb_KristalName";
            this.tb_KristalName.Size = new System.Drawing.Size(334, 20);
            this.tb_KristalName.TabIndex = 75;
            this.tb_KristalName.TextChanged += new System.EventHandler(this.searchItemAddedKristalAll);
            // 
            // lbl_KristalRef
            // 
            this.lbl_KristalRef.AutoSize = true;
            this.lbl_KristalRef.Location = new System.Drawing.Point(12, 9);
            this.lbl_KristalRef.Name = "lbl_KristalRef";
            this.lbl_KristalRef.Size = new System.Drawing.Size(88, 13);
            this.lbl_KristalRef.TabIndex = 77;
            this.lbl_KristalRef.Text = "Kristal Reference";
            // 
            // tb_KristalRef
            // 
            this.tb_KristalRef.Location = new System.Drawing.Point(131, 6);
            this.tb_KristalRef.Name = "tb_KristalRef";
            this.tb_KristalRef.Size = new System.Drawing.Size(124, 20);
            this.tb_KristalRef.TabIndex = 78;
            this.tb_KristalRef.TextChanged += new System.EventHandler(this.searchItemAddedKristalAll);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(468, 154);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(91, 23);
            this.btn_Refresh.TabIndex = 79;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.refreshPage);
            // 
            // btn_ClearSearch
            // 
            this.btn_ClearSearch.Location = new System.Drawing.Point(469, 183);
            this.btn_ClearSearch.Name = "btn_ClearSearch";
            this.btn_ClearSearch.Size = new System.Drawing.Size(90, 23);
            this.btn_ClearSearch.TabIndex = 80;
            this.btn_ClearSearch.Text = "Clear Search";
            this.btn_ClearSearch.UseVisualStyleBackColor = true;
            this.btn_ClearSearch.Click += new System.EventHandler(this.clearSearch);
            // 
            // btn_NewGrant
            // 
            this.btn_NewGrant.Location = new System.Drawing.Point(470, 211);
            this.btn_NewGrant.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NewGrant.Name = "btn_NewGrant";
            this.btn_NewGrant.Size = new System.Drawing.Size(90, 24);
            this.btn_NewGrant.TabIndex = 81;
            this.btn_NewGrant.Text = "Create Grant";
            this.btn_NewGrant.UseVisualStyleBackColor = true;
            // 
            // frm_KristalAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 265);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_ClearSearch);
            this.Controls.Add(this.btn_NewGrant);
            this.Controls.Add(this.lbl_KristalRef);
            this.Controls.Add(this.tb_KristalRef);
            this.Controls.Add(this.tb_KristalName);
            this.Controls.Add(this.lbl_KristalName);
            this.Controls.Add(this.lbl_recordCount);
            this.Controls.Add(this.dgv_KristalList);
            this.Controls.Add(this.lbl_GrantStage);
            this.Controls.Add(this.cb_GrantStage);
            this.Name = "frm_KristalAll";
            this.Text = "frm_KristalAll";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_GrantStage;
        private System.Windows.Forms.Label lbl_GrantStage;
        private System.Windows.Forms.DataGridView dgv_KristalList;
        private System.Windows.Forms.Label lbl_recordCount;
        private System.Windows.Forms.Label lbl_KristalName;
        private System.Windows.Forms.TextBox tb_KristalName;
        private System.Windows.Forms.Label lbl_KristalRef;
        private System.Windows.Forms.TextBox tb_KristalRef;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_ClearSearch;
        private System.Windows.Forms.Button btn_NewGrant;
    }
}