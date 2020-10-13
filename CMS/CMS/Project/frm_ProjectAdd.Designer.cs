namespace CMS
{
    partial class frm_ProjectAdd
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
            this.mtb_pStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.mtb_pEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_pEndDate = new System.Windows.Forms.Label();
            this.lbl_pStartDate = new System.Windows.Forms.Label();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.cb_pStage = new System.Windows.Forms.ComboBox();
            this.lbl_pStage = new System.Windows.Forms.Label();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.mtb_ProjectedStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ProjectedStartDate = new System.Windows.Forms.Label();
            this.lbl_LeadApplicant = new System.Windows.Forms.Label();
            this.gb_Governance = new System.Windows.Forms.GroupBox();
            this.chkb_ISO27001 = new System.Windows.Forms.CheckBox();
            this.chkb_DSPT = new System.Windows.Forms.CheckBox();
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.lbl_Faculty = new System.Windows.Forms.Label();
            this.mtb_ProjectedEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ProjectedEndDate = new System.Windows.Forms.Label();
            this.cb_DATRAG = new System.Windows.Forms.ComboBox();
            this.lbl_DATRAG = new System.Windows.Forms.Label();
            this.lbl_pClassification = new System.Windows.Forms.Label();
            this.cb_pClassification = new System.Windows.Forms.ComboBox();
            this.gb_Platform = new System.Windows.Forms.GroupBox();
            this.chkb_Azure = new System.Windows.Forms.CheckBox();
            this.chkb_IRC = new System.Windows.Forms.CheckBox();
            this.chkb_SEED = new System.Windows.Forms.CheckBox();
            this.lbl_PI_NewUser = new System.Windows.Forms.Label();
            this.lbl_LeadApplicant_NewUser = new System.Windows.Forms.Label();
            this.cb_PI = new System.Windows.Forms.ComboBox();
            this.cb_LeadApplicant = new System.Windows.Forms.ComboBox();
            this.lbl_ProjectAdd = new System.Windows.Forms.Label();
            this.tb_PortfolioNo = new System.Windows.Forms.TextBox();
            this.lbl_PortfolioNo = new System.Windows.Forms.Label();
            this.gb_Governance.SuspendLayout();
            this.gb_Platform.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtb_pStartDateValue
            // 
            this.mtb_pStartDateValue.Location = new System.Drawing.Point(421, 76);
            this.mtb_pStartDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pStartDateValue.Mask = "00/00/0000";
            this.mtb_pStartDateValue.Name = "mtb_pStartDateValue";
            this.mtb_pStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pStartDateValue.TabIndex = 19;
            this.mtb_pStartDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_pStartDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // mtb_pEndDateValue
            // 
            this.mtb_pEndDateValue.Location = new System.Drawing.Point(421, 104);
            this.mtb_pEndDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pEndDateValue.Mask = "00/00/0000";
            this.mtb_pEndDateValue.Name = "mtb_pEndDateValue";
            this.mtb_pEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pEndDateValue.TabIndex = 21;
            this.mtb_pEndDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_pEndDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // lbl_pEndDate
            // 
            this.lbl_pEndDate.AutoSize = true;
            this.lbl_pEndDate.Location = new System.Drawing.Point(365, 107);
            this.lbl_pEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pEndDate.Name = "lbl_pEndDate";
            this.lbl_pEndDate.Size = new System.Drawing.Size(52, 13);
            this.lbl_pEndDate.TabIndex = 20;
            this.lbl_pEndDate.Text = "End Date";
            // 
            // lbl_pStartDate
            // 
            this.lbl_pStartDate.AutoSize = true;
            this.lbl_pStartDate.Location = new System.Drawing.Point(362, 79);
            this.lbl_pStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStartDate.Name = "lbl_pStartDate";
            this.lbl_pStartDate.Size = new System.Drawing.Size(55, 13);
            this.lbl_pStartDate.TabIndex = 18;
            this.lbl_pStartDate.Text = "Start Date";
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(212, 186);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(105, 13);
            this.lbl_pPI.TabIndex = 14;
            this.lbl_pPI.Text = "Principal Investigator";
            // 
            // cb_pStage
            // 
            this.cb_pStage.FormattingEnabled = true;
            this.cb_pStage.Location = new System.Drawing.Point(76, 182);
            this.cb_pStage.Margin = new System.Windows.Forms.Padding(2);
            this.cb_pStage.Name = "cb_pStage";
            this.cb_pStage.Size = new System.Drawing.Size(124, 21);
            this.cb_pStage.TabIndex = 17;
            // 
            // lbl_pStage
            // 
            this.lbl_pStage.AutoSize = true;
            this.lbl_pStage.Location = new System.Drawing.Point(32, 186);
            this.lbl_pStage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStage.Name = "lbl_pStage";
            this.lbl_pStage.Size = new System.Drawing.Size(35, 13);
            this.lbl_pStage.TabIndex = 15;
            this.lbl_pStage.Text = "Stage";
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(119, 32);
            this.tb_pNameValue.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.Size = new System.Drawing.Size(379, 20);
            this.tb_pNameValue.TabIndex = 13;
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(10, 35);
            this.lbl_pName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(63, 13);
            this.lbl_pName.TabIndex = 12;
            this.lbl_pName.Text = "Project Title";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(438, 234);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(56, 24);
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(377, 234);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(56, 24);
            this.btn_Create.TabIndex = 23;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // mtb_ProjectedStartDateValue
            // 
            this.mtb_ProjectedStartDateValue.Location = new System.Drawing.Point(279, 76);
            this.mtb_ProjectedStartDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ProjectedStartDateValue.Mask = "00/00/0000";
            this.mtb_ProjectedStartDateValue.Name = "mtb_ProjectedStartDateValue";
            this.mtb_ProjectedStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_ProjectedStartDateValue.TabIndex = 62;
            this.mtb_ProjectedStartDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_ProjectedStartDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // lbl_ProjectedStartDate
            // 
            this.lbl_ProjectedStartDate.AutoSize = true;
            this.lbl_ProjectedStartDate.Location = new System.Drawing.Point(220, 73);
            this.lbl_ProjectedStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProjectedStartDate.Name = "lbl_ProjectedStartDate";
            this.lbl_ProjectedStartDate.Size = new System.Drawing.Size(55, 26);
            this.lbl_ProjectedStartDate.TabIndex = 61;
            this.lbl_ProjectedStartDate.Text = "Projected \r\nStart Date";
            // 
            // lbl_LeadApplicant
            // 
            this.lbl_LeadApplicant.AutoSize = true;
            this.lbl_LeadApplicant.Location = new System.Drawing.Point(239, 162);
            this.lbl_LeadApplicant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LeadApplicant.Name = "lbl_LeadApplicant";
            this.lbl_LeadApplicant.Size = new System.Drawing.Size(78, 13);
            this.lbl_LeadApplicant.TabIndex = 59;
            this.lbl_LeadApplicant.Text = "Lead Applicant";
            // 
            // gb_Governance
            // 
            this.gb_Governance.Controls.Add(this.chkb_ISO27001);
            this.gb_Governance.Controls.Add(this.chkb_DSPT);
            this.gb_Governance.Location = new System.Drawing.Point(110, 73);
            this.gb_Governance.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Governance.Name = "gb_Governance";
            this.gb_Governance.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Governance.Size = new System.Drawing.Size(90, 62);
            this.gb_Governance.TabIndex = 51;
            this.gb_Governance.TabStop = false;
            this.gb_Governance.Text = "Governance";
            // 
            // chkb_ISO27001
            // 
            this.chkb_ISO27001.AutoSize = true;
            this.chkb_ISO27001.Location = new System.Drawing.Point(4, 17);
            this.chkb_ISO27001.Margin = new System.Windows.Forms.Padding(2);
            this.chkb_ISO27001.Name = "chkb_ISO27001";
            this.chkb_ISO27001.Size = new System.Drawing.Size(74, 17);
            this.chkb_ISO27001.TabIndex = 17;
            this.chkb_ISO27001.Text = "ISO27001";
            this.chkb_ISO27001.UseVisualStyleBackColor = true;
            // 
            // chkb_DSPT
            // 
            this.chkb_DSPT.AutoSize = true;
            this.chkb_DSPT.Location = new System.Drawing.Point(4, 38);
            this.chkb_DSPT.Margin = new System.Windows.Forms.Padding(2);
            this.chkb_DSPT.Name = "chkb_DSPT";
            this.chkb_DSPT.Size = new System.Drawing.Size(81, 17);
            this.chkb_DSPT.TabIndex = 18;
            this.chkb_DSPT.Text = "NHS DSPT";
            this.chkb_DSPT.UseVisualStyleBackColor = true;
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Faculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(321, 208);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(173, 21);
            this.cb_Faculty.TabIndex = 58;
            // 
            // lbl_Faculty
            // 
            this.lbl_Faculty.AutoSize = true;
            this.lbl_Faculty.Location = new System.Drawing.Point(276, 211);
            this.lbl_Faculty.Name = "lbl_Faculty";
            this.lbl_Faculty.Size = new System.Drawing.Size(41, 13);
            this.lbl_Faculty.TabIndex = 57;
            this.lbl_Faculty.Text = "Faculty";
            // 
            // mtb_ProjectedEndDateValue
            // 
            this.mtb_ProjectedEndDateValue.Location = new System.Drawing.Point(279, 104);
            this.mtb_ProjectedEndDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ProjectedEndDateValue.Mask = "00/00/0000";
            this.mtb_ProjectedEndDateValue.Name = "mtb_ProjectedEndDateValue";
            this.mtb_ProjectedEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_ProjectedEndDateValue.TabIndex = 56;
            this.mtb_ProjectedEndDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_ProjectedEndDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // lbl_ProjectedEndDate
            // 
            this.lbl_ProjectedEndDate.AutoSize = true;
            this.lbl_ProjectedEndDate.Location = new System.Drawing.Point(220, 101);
            this.lbl_ProjectedEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProjectedEndDate.Name = "lbl_ProjectedEndDate";
            this.lbl_ProjectedEndDate.Size = new System.Drawing.Size(55, 26);
            this.lbl_ProjectedEndDate.TabIndex = 55;
            this.lbl_ProjectedEndDate.Text = "Projected \r\nEnd Date";
            // 
            // cb_DATRAG
            // 
            this.cb_DATRAG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_DATRAG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_DATRAG.FormattingEnabled = true;
            this.cb_DATRAG.Location = new System.Drawing.Point(421, 6);
            this.cb_DATRAG.Name = "cb_DATRAG";
            this.cb_DATRAG.Size = new System.Drawing.Size(76, 21);
            this.cb_DATRAG.TabIndex = 54;
            // 
            // lbl_DATRAG
            // 
            this.lbl_DATRAG.AutoSize = true;
            this.lbl_DATRAG.Location = new System.Drawing.Point(360, 9);
            this.lbl_DATRAG.Name = "lbl_DATRAG";
            this.lbl_DATRAG.Size = new System.Drawing.Size(55, 13);
            this.lbl_DATRAG.TabIndex = 53;
            this.lbl_DATRAG.Text = "DAT RAG";
            // 
            // lbl_pClassification
            // 
            this.lbl_pClassification.AutoSize = true;
            this.lbl_pClassification.Location = new System.Drawing.Point(2, 211);
            this.lbl_pClassification.Name = "lbl_pClassification";
            this.lbl_pClassification.Size = new System.Drawing.Size(68, 13);
            this.lbl_pClassification.TabIndex = 52;
            this.lbl_pClassification.Text = "Classification";
            // 
            // cb_pClassification
            // 
            this.cb_pClassification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pClassification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pClassification.FormattingEnabled = true;
            this.cb_pClassification.Location = new System.Drawing.Point(76, 208);
            this.cb_pClassification.Name = "cb_pClassification";
            this.cb_pClassification.Size = new System.Drawing.Size(124, 21);
            this.cb_pClassification.TabIndex = 50;
            // 
            // gb_Platform
            // 
            this.gb_Platform.Controls.Add(this.chkb_Azure);
            this.gb_Platform.Controls.Add(this.chkb_IRC);
            this.gb_Platform.Controls.Add(this.chkb_SEED);
            this.gb_Platform.Location = new System.Drawing.Point(13, 73);
            this.gb_Platform.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Platform.Name = "gb_Platform";
            this.gb_Platform.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Platform.Size = new System.Drawing.Size(68, 79);
            this.gb_Platform.TabIndex = 49;
            this.gb_Platform.TabStop = false;
            this.gb_Platform.Text = "Platform";
            // 
            // chkb_Azure
            // 
            this.chkb_Azure.AutoSize = true;
            this.chkb_Azure.Location = new System.Drawing.Point(4, 17);
            this.chkb_Azure.Margin = new System.Windows.Forms.Padding(2);
            this.chkb_Azure.Name = "chkb_Azure";
            this.chkb_Azure.Size = new System.Drawing.Size(53, 17);
            this.chkb_Azure.TabIndex = 19;
            this.chkb_Azure.Text = "Azure";
            this.chkb_Azure.UseVisualStyleBackColor = true;
            // 
            // chkb_IRC
            // 
            this.chkb_IRC.AutoSize = true;
            this.chkb_IRC.Location = new System.Drawing.Point(4, 38);
            this.chkb_IRC.Margin = new System.Windows.Forms.Padding(2);
            this.chkb_IRC.Name = "chkb_IRC";
            this.chkb_IRC.Size = new System.Drawing.Size(44, 17);
            this.chkb_IRC.TabIndex = 17;
            this.chkb_IRC.Text = "IRC";
            this.chkb_IRC.UseVisualStyleBackColor = true;
            // 
            // chkb_SEED
            // 
            this.chkb_SEED.AutoSize = true;
            this.chkb_SEED.Location = new System.Drawing.Point(4, 59);
            this.chkb_SEED.Margin = new System.Windows.Forms.Padding(2);
            this.chkb_SEED.Name = "chkb_SEED";
            this.chkb_SEED.Size = new System.Drawing.Size(55, 17);
            this.chkb_SEED.TabIndex = 18;
            this.chkb_SEED.Text = "SEED";
            this.chkb_SEED.UseVisualStyleBackColor = true;
            // 
            // lbl_PI_NewUser
            // 
            this.lbl_PI_NewUser.AutoSize = true;
            this.lbl_PI_NewUser.Location = new System.Drawing.Point(499, 186);
            this.lbl_PI_NewUser.Name = "lbl_PI_NewUser";
            this.lbl_PI_NewUser.Size = new System.Drawing.Size(36, 13);
            this.lbl_PI_NewUser.TabIndex = 63;
            this.lbl_PI_NewUser.Text = "new...";
            this.lbl_PI_NewUser.Click += new System.EventHandler(this.btn_UserAdd_Click);
            // 
            // lbl_LeadApplicant_NewUser
            // 
            this.lbl_LeadApplicant_NewUser.AutoSize = true;
            this.lbl_LeadApplicant_NewUser.Location = new System.Drawing.Point(499, 162);
            this.lbl_LeadApplicant_NewUser.Name = "lbl_LeadApplicant_NewUser";
            this.lbl_LeadApplicant_NewUser.Size = new System.Drawing.Size(36, 13);
            this.lbl_LeadApplicant_NewUser.TabIndex = 64;
            this.lbl_LeadApplicant_NewUser.Text = "new...";
            this.lbl_LeadApplicant_NewUser.Click += new System.EventHandler(this.btn_UserAdd_Click);
            // 
            // cb_PI
            // 
            this.cb_PI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PI.FormattingEnabled = true;
            this.cb_PI.Location = new System.Drawing.Point(321, 182);
            this.cb_PI.Name = "cb_PI";
            this.cb_PI.Size = new System.Drawing.Size(173, 21);
            this.cb_PI.TabIndex = 66;
            // 
            // cb_LeadApplicant
            // 
            this.cb_LeadApplicant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_LeadApplicant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_LeadApplicant.FormattingEnabled = true;
            this.cb_LeadApplicant.Location = new System.Drawing.Point(321, 158);
            this.cb_LeadApplicant.Name = "cb_LeadApplicant";
            this.cb_LeadApplicant.Size = new System.Drawing.Size(173, 21);
            this.cb_LeadApplicant.TabIndex = 65;
            // 
            // lbl_ProjectAdd
            // 
            this.lbl_ProjectAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectAdd.Location = new System.Drawing.Point(12, 6);
            this.lbl_ProjectAdd.Name = "lbl_ProjectAdd";
            this.lbl_ProjectAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ProjectAdd.Size = new System.Drawing.Size(327, 20);
            this.lbl_ProjectAdd.TabIndex = 67;
            this.lbl_ProjectAdd.Text = "Add new project";
            this.lbl_ProjectAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_PortfolioNo
            // 
            this.tb_PortfolioNo.Location = new System.Drawing.Point(76, 157);
            this.tb_PortfolioNo.Name = "tb_PortfolioNo";
            this.tb_PortfolioNo.Size = new System.Drawing.Size(124, 20);
            this.tb_PortfolioNo.TabIndex = 68;
            // 
            // lbl_PortfolioNo
            // 
            this.lbl_PortfolioNo.AutoSize = true;
            this.lbl_PortfolioNo.Location = new System.Drawing.Point(8, 160);
            this.lbl_PortfolioNo.Name = "lbl_PortfolioNo";
            this.lbl_PortfolioNo.Size = new System.Drawing.Size(62, 13);
            this.lbl_PortfolioNo.TabIndex = 69;
            this.lbl_PortfolioNo.Text = "Portfolio No";
            // 
            // frm_ProjectAdd
            // 
            this.AcceptButton = this.btn_Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(540, 265);
            this.Controls.Add(this.tb_PortfolioNo);
            this.Controls.Add(this.lbl_PortfolioNo);
            this.Controls.Add(this.lbl_ProjectAdd);
            this.Controls.Add(this.cb_PI);
            this.Controls.Add(this.cb_LeadApplicant);
            this.Controls.Add(this.lbl_LeadApplicant_NewUser);
            this.Controls.Add(this.lbl_PI_NewUser);
            this.Controls.Add(this.mtb_ProjectedStartDateValue);
            this.Controls.Add(this.lbl_ProjectedStartDate);
            this.Controls.Add(this.lbl_LeadApplicant);
            this.Controls.Add(this.gb_Governance);
            this.Controls.Add(this.cb_Faculty);
            this.Controls.Add(this.lbl_Faculty);
            this.Controls.Add(this.mtb_ProjectedEndDateValue);
            this.Controls.Add(this.lbl_ProjectedEndDate);
            this.Controls.Add(this.cb_DATRAG);
            this.Controls.Add(this.lbl_DATRAG);
            this.Controls.Add(this.lbl_pClassification);
            this.Controls.Add(this.cb_pClassification);
            this.Controls.Add(this.gb_Platform);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.mtb_pStartDateValue);
            this.Controls.Add(this.mtb_pEndDateValue);
            this.Controls.Add(this.lbl_pEndDate);
            this.Controls.Add(this.lbl_pStartDate);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.cb_pStage);
            this.Controls.Add(this.lbl_pStage);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_ProjectAdd";
            this.Text = "Create New Project";
            this.gb_Governance.ResumeLayout(false);
            this.gb_Governance.PerformLayout();
            this.gb_Platform.ResumeLayout(false);
            this.gb_Platform.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mtb_pStartDateValue;
        private System.Windows.Forms.MaskedTextBox mtb_pEndDateValue;
        private System.Windows.Forms.Label lbl_pEndDate;
        private System.Windows.Forms.Label lbl_pStartDate;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.ComboBox cb_pStage;
        private System.Windows.Forms.Label lbl_pStage;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.MaskedTextBox mtb_ProjectedStartDateValue;
        private System.Windows.Forms.Label lbl_ProjectedStartDate;
        private System.Windows.Forms.Label lbl_LeadApplicant;
        private System.Windows.Forms.GroupBox gb_Governance;
        private System.Windows.Forms.CheckBox chkb_ISO27001;
        private System.Windows.Forms.CheckBox chkb_DSPT;
        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Label lbl_Faculty;
        private System.Windows.Forms.MaskedTextBox mtb_ProjectedEndDateValue;
        private System.Windows.Forms.Label lbl_ProjectedEndDate;
        private System.Windows.Forms.ComboBox cb_DATRAG;
        private System.Windows.Forms.Label lbl_DATRAG;
        private System.Windows.Forms.Label lbl_pClassification;
        private System.Windows.Forms.ComboBox cb_pClassification;
        private System.Windows.Forms.GroupBox gb_Platform;
        private System.Windows.Forms.CheckBox chkb_Azure;
        private System.Windows.Forms.CheckBox chkb_IRC;
        private System.Windows.Forms.CheckBox chkb_SEED;
        private System.Windows.Forms.Label lbl_PI_NewUser;
        private System.Windows.Forms.Label lbl_LeadApplicant_NewUser;
        private System.Windows.Forms.ComboBox cb_PI;
        private System.Windows.Forms.ComboBox cb_LeadApplicant;
        private System.Windows.Forms.Label lbl_ProjectAdd;
        private System.Windows.Forms.TextBox tb_PortfolioNo;
        private System.Windows.Forms.Label lbl_PortfolioNo;
    }
}