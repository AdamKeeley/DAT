namespace CMS
{
    partial class frm_ProjectAll
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
            this.lbl_LeadApplicant = new System.Windows.Forms.Label();
            this.btn_ClearSearch = new System.Windows.Forms.Button();
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.lbl_Faculty = new System.Windows.Forms.Label();
            this.cb_DATRAG = new System.Windows.Forms.ComboBox();
            this.lbl_DATRAG = new System.Windows.Forms.Label();
            this.lbl_pClassification = new System.Windows.Forms.Label();
            this.cb_pClassification = new System.Windows.Forms.ComboBox();
            this.btn_NewProject = new System.Windows.Forms.Button();
            this.dgv_ProjectList = new System.Windows.Forms.DataGridView();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.cb_pStage = new System.Windows.Forms.ComboBox();
            this.lbl_pStage = new System.Windows.Forms.Label();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.cb_LeadApplicant = new System.Windows.Forms.ComboBox();
            this.cb_PI = new System.Windows.Forms.ComboBox();
            this.lbl_recordCount = new System.Windows.Forms.Label();
            this.lbl_PortfolioNo = new System.Windows.Forms.Label();
            this.cb_PortfolioNo = new System.Windows.Forms.ComboBox();
            this.lbl_VreNumber = new System.Windows.Forms.Label();
            this.cb_VreNumber = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LeadApplicant
            // 
            this.lbl_LeadApplicant.AutoSize = true;
            this.lbl_LeadApplicant.Location = new System.Drawing.Point(501, 60);
            this.lbl_LeadApplicant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LeadApplicant.Name = "lbl_LeadApplicant";
            this.lbl_LeadApplicant.Size = new System.Drawing.Size(78, 13);
            this.lbl_LeadApplicant.TabIndex = 12;
            this.lbl_LeadApplicant.Text = "Lead Applicant";
            // 
            // btn_ClearSearch
            // 
            this.btn_ClearSearch.Location = new System.Drawing.Point(970, 75);
            this.btn_ClearSearch.Name = "btn_ClearSearch";
            this.btn_ClearSearch.Size = new System.Drawing.Size(90, 23);
            this.btn_ClearSearch.TabIndex = 19;
            this.btn_ClearSearch.Text = "Clear Search";
            this.btn_ClearSearch.UseVisualStyleBackColor = true;
            this.btn_ClearSearch.Click += new System.EventHandler(this.clearSearch);
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Faculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(584, 111);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(173, 21);
            this.cb_Faculty.TabIndex = 17;
            this.cb_Faculty.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_Faculty
            // 
            this.lbl_Faculty.AutoSize = true;
            this.lbl_Faculty.Location = new System.Drawing.Point(537, 114);
            this.lbl_Faculty.Name = "lbl_Faculty";
            this.lbl_Faculty.Size = new System.Drawing.Size(41, 13);
            this.lbl_Faculty.TabIndex = 16;
            this.lbl_Faculty.Text = "Faculty";
            // 
            // cb_DATRAG
            // 
            this.cb_DATRAG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_DATRAG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_DATRAG.FormattingEnabled = true;
            this.cb_DATRAG.Location = new System.Drawing.Point(681, 6);
            this.cb_DATRAG.Name = "cb_DATRAG";
            this.cb_DATRAG.Size = new System.Drawing.Size(76, 21);
            this.cb_DATRAG.TabIndex = 3;
            this.cb_DATRAG.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_DATRAG
            // 
            this.lbl_DATRAG.AutoSize = true;
            this.lbl_DATRAG.Location = new System.Drawing.Point(620, 9);
            this.lbl_DATRAG.Name = "lbl_DATRAG";
            this.lbl_DATRAG.Size = new System.Drawing.Size(55, 13);
            this.lbl_DATRAG.TabIndex = 2;
            this.lbl_DATRAG.Text = "DAT RAG";
            // 
            // lbl_pClassification
            // 
            this.lbl_pClassification.AutoSize = true;
            this.lbl_pClassification.Location = new System.Drawing.Point(265, 114);
            this.lbl_pClassification.Name = "lbl_pClassification";
            this.lbl_pClassification.Size = new System.Drawing.Size(68, 13);
            this.lbl_pClassification.TabIndex = 10;
            this.lbl_pClassification.Text = "Classification";
            // 
            // cb_pClassification
            // 
            this.cb_pClassification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pClassification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pClassification.FormattingEnabled = true;
            this.cb_pClassification.Location = new System.Drawing.Point(339, 110);
            this.cb_pClassification.Name = "cb_pClassification";
            this.cb_pClassification.Size = new System.Drawing.Size(124, 21);
            this.cb_pClassification.TabIndex = 11;
            this.cb_pClassification.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Location = new System.Drawing.Point(971, 103);
            this.btn_NewProject.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(90, 24);
            this.btn_NewProject.TabIndex = 20;
            this.btn_NewProject.Text = "Create Project";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.open_frm_ProjectAdd);
            // 
            // dgv_ProjectList
            // 
            this.dgv_ProjectList.AllowUserToAddRows = false;
            this.dgv_ProjectList.AllowUserToDeleteRows = false;
            this.dgv_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProjectList.Location = new System.Drawing.Point(11, 137);
            this.dgv_ProjectList.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ProjectList.Name = "dgv_ProjectList";
            this.dgv_ProjectList.ReadOnly = true;
            this.dgv_ProjectList.RowHeadersVisible = false;
            this.dgv_ProjectList.RowTemplate.Height = 24;
            this.dgv_ProjectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProjectList.Size = new System.Drawing.Size(1050, 420);
            this.dgv_ProjectList.TabIndex = 21;
            this.dgv_ProjectList.TabStop = false;
            this.dgv_ProjectList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ProjectList_CellDoubleClick);
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(474, 87);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(105, 13);
            this.lbl_pPI.TabIndex = 14;
            this.lbl_pPI.Text = "Principal Investigator";
            // 
            // cb_pStage
            // 
            this.cb_pStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pStage.FormattingEnabled = true;
            this.cb_pStage.Location = new System.Drawing.Point(339, 84);
            this.cb_pStage.Margin = new System.Windows.Forms.Padding(2);
            this.cb_pStage.Name = "cb_pStage";
            this.cb_pStage.Size = new System.Drawing.Size(124, 21);
            this.cb_pStage.TabIndex = 9;
            this.cb_pStage.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_pStage
            // 
            this.lbl_pStage.AutoSize = true;
            this.lbl_pStage.Location = new System.Drawing.Point(300, 87);
            this.lbl_pStage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStage.Name = "lbl_pStage";
            this.lbl_pStage.Size = new System.Drawing.Size(35, 13);
            this.lbl_pStage.TabIndex = 8;
            this.lbl_pStage.Text = "Stage";
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(339, 32);
            this.tb_pNameValue.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.Size = new System.Drawing.Size(418, 20);
            this.tb_pNameValue.TabIndex = 5;
            this.tb_pNameValue.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(272, 35);
            this.lbl_pName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(63, 13);
            this.lbl_pName.TabIndex = 4;
            this.lbl_pName.Text = "Project Title";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(969, 46);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(91, 23);
            this.btn_Refresh.TabIndex = 18;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.refreshPage);
            // 
            // cb_LeadApplicant
            // 
            this.cb_LeadApplicant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_LeadApplicant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_LeadApplicant.FormattingEnabled = true;
            this.cb_LeadApplicant.Location = new System.Drawing.Point(584, 57);
            this.cb_LeadApplicant.Name = "cb_LeadApplicant";
            this.cb_LeadApplicant.Size = new System.Drawing.Size(173, 21);
            this.cb_LeadApplicant.TabIndex = 13;
            this.cb_LeadApplicant.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // cb_PI
            // 
            this.cb_PI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PI.FormattingEnabled = true;
            this.cb_PI.Location = new System.Drawing.Point(584, 84);
            this.cb_PI.Name = "cb_PI";
            this.cb_PI.Size = new System.Drawing.Size(173, 21);
            this.cb_PI.TabIndex = 15;
            this.cb_PI.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_recordCount
            // 
            this.lbl_recordCount.Location = new System.Drawing.Point(961, 561);
            this.lbl_recordCount.Name = "lbl_recordCount";
            this.lbl_recordCount.Size = new System.Drawing.Size(100, 23);
            this.lbl_recordCount.TabIndex = 72;
            this.lbl_recordCount.Text = "# records";
            this.lbl_recordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PortfolioNo
            // 
            this.lbl_PortfolioNo.AutoSize = true;
            this.lbl_PortfolioNo.Location = new System.Drawing.Point(271, 60);
            this.lbl_PortfolioNo.Name = "lbl_PortfolioNo";
            this.lbl_PortfolioNo.Size = new System.Drawing.Size(62, 13);
            this.lbl_PortfolioNo.TabIndex = 6;
            this.lbl_PortfolioNo.Text = "Portfolio No";
            // 
            // cb_PortfolioNo
            // 
            this.cb_PortfolioNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PortfolioNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PortfolioNo.FormattingEnabled = true;
            this.cb_PortfolioNo.Location = new System.Drawing.Point(339, 57);
            this.cb_PortfolioNo.Name = "cb_PortfolioNo";
            this.cb_PortfolioNo.Size = new System.Drawing.Size(124, 21);
            this.cb_PortfolioNo.TabIndex = 7;
            this.cb_PortfolioNo.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_VreNumber
            // 
            this.lbl_VreNumber.AutoSize = true;
            this.lbl_VreNumber.Location = new System.Drawing.Point(266, 9);
            this.lbl_VreNumber.Name = "lbl_VreNumber";
            this.lbl_VreNumber.Size = new System.Drawing.Size(69, 13);
            this.lbl_VreNumber.TabIndex = 0;
            this.lbl_VreNumber.Text = "VRE Number";
            // 
            // cb_VreNumber
            // 
            this.cb_VreNumber.FormattingEnabled = true;
            this.cb_VreNumber.Location = new System.Drawing.Point(339, 6);
            this.cb_VreNumber.Name = "cb_VreNumber";
            this.cb_VreNumber.Size = new System.Drawing.Size(124, 21);
            this.cb_VreNumber.TabIndex = 1;
            this.cb_VreNumber.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // frm_ProjectAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 593);
            this.Controls.Add(this.cb_VreNumber);
            this.Controls.Add(this.lbl_VreNumber);
            this.Controls.Add(this.cb_PortfolioNo);
            this.Controls.Add(this.lbl_PortfolioNo);
            this.Controls.Add(this.lbl_recordCount);
            this.Controls.Add(this.cb_PI);
            this.Controls.Add(this.cb_LeadApplicant);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.lbl_LeadApplicant);
            this.Controls.Add(this.btn_ClearSearch);
            this.Controls.Add(this.cb_Faculty);
            this.Controls.Add(this.lbl_Faculty);
            this.Controls.Add(this.cb_DATRAG);
            this.Controls.Add(this.lbl_DATRAG);
            this.Controls.Add(this.lbl_pClassification);
            this.Controls.Add(this.cb_pClassification);
            this.Controls.Add(this.btn_NewProject);
            this.Controls.Add(this.dgv_ProjectList);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.cb_pStage);
            this.Controls.Add(this.lbl_pStage);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Name = "frm_ProjectAll";
            this.Text = "LIDA Projects";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_LeadApplicant;
        private System.Windows.Forms.Button btn_ClearSearch;
        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Label lbl_Faculty;
        private System.Windows.Forms.ComboBox cb_DATRAG;
        private System.Windows.Forms.Label lbl_DATRAG;
        private System.Windows.Forms.Label lbl_pClassification;
        private System.Windows.Forms.ComboBox cb_pClassification;
        private System.Windows.Forms.Button btn_NewProject;
        private System.Windows.Forms.DataGridView dgv_ProjectList;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.ComboBox cb_pStage;
        private System.Windows.Forms.Label lbl_pStage;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ComboBox cb_LeadApplicant;
        private System.Windows.Forms.ComboBox cb_PI;
        private System.Windows.Forms.Label lbl_recordCount;
        private System.Windows.Forms.Label lbl_PortfolioNo;
        private System.Windows.Forms.ComboBox cb_PortfolioNo;
        private System.Windows.Forms.Label lbl_VreNumber;
        private System.Windows.Forms.ComboBox cb_VreNumber;
    }
}