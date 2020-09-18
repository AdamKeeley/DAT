using System.Collections.Generic;

namespace CMS
{
    partial class frm_Project
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
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pStage = new System.Windows.Forms.Label();
            this.cb_pStage = new System.Windows.Forms.ComboBox();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.lbl_pStartDate = new System.Windows.Forms.Label();
            this.lbl_pEndDate = new System.Windows.Forms.Label();
            this.dgv_pNotes = new System.Windows.Forms.DataGridView();
            this.mtb_pEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.mtb_pStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.tb_NewProjectNote = new System.Windows.Forms.TextBox();
            this.btn_InsertProjectNote = new System.Windows.Forms.Button();
            this.cb_pNumberValue = new System.Windows.Forms.ComboBox();
            this.btn_ProjectCancel = new System.Windows.Forms.Button();
            this.btn_ProjectOK = new System.Windows.Forms.Button();
            this.btn_ProjectApply = new System.Windows.Forms.Button();
            this.btn_NewProject = new System.Windows.Forms.Button();
            this.chkb_IRC = new System.Windows.Forms.CheckBox();
            this.chkb_SEED = new System.Windows.Forms.CheckBox();
            this.gb_Platform = new System.Windows.Forms.GroupBox();
            this.chkb_Azure = new System.Windows.Forms.CheckBox();
            this.cb_pClassification = new System.Windows.Forms.ComboBox();
            this.lbl_pClassification = new System.Windows.Forms.Label();
            this.lbl_DATRAG = new System.Windows.Forms.Label();
            this.cb_DATRAG = new System.Windows.Forms.ComboBox();
            this.mtb_ProjectedEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ProjectedEndDate = new System.Windows.Forms.Label();
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.lbl_Faculty = new System.Windows.Forms.Label();
            this.gb_Governance = new System.Windows.Forms.GroupBox();
            this.chkb_ISO27001 = new System.Windows.Forms.CheckBox();
            this.chkb_DSPT = new System.Windows.Forms.CheckBox();
            this.btn_Users = new System.Windows.Forms.Button();
            this.btn_Projects = new System.Windows.Forms.Button();
            this.btn_Documents = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Platform = new System.Windows.Forms.Button();
            this.lbl_LeadApplicant = new System.Windows.Forms.Label();
            this.mtb_ProjectedStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ProjectedStartDate = new System.Windows.Forms.Label();
            this.cb_LeadApplicant = new System.Windows.Forms.ComboBox();
            this.cb_PI = new System.Windows.Forms.ComboBox();
            this.dgv_ProjectUsers = new System.Windows.Forms.DataGridView();
            this.btn_ProjectUserAdd = new System.Windows.Forms.Button();
            this.btn_ProjectUserRemove = new System.Windows.Forms.Button();
            this.gb_ProjectUsers = new System.Windows.Forms.GroupBox();
            this.gb_ProjectNotes = new System.Windows.Forms.GroupBox();
            this.gb_KeyDates = new System.Windows.Forms.GroupBox();
            this.gb_ProjectDocuments = new System.Windows.Forms.GroupBox();
            this.btn_AllDocs = new System.Windows.Forms.Button();
            this.btn_RA = new System.Windows.Forms.Button();
            this.btn_DMP = new System.Windows.Forms.Button();
            this.btn_Proposal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pNotes)).BeginInit();
            this.gb_Platform.SuspendLayout();
            this.gb_Governance.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectUsers)).BeginInit();
            this.gb_ProjectUsers.SuspendLayout();
            this.gb_ProjectNotes.SuspendLayout();
            this.gb_KeyDates.SuspendLayout();
            this.gb_ProjectDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_pNumber
            // 
            this.lbl_pNumber.AutoSize = true;
            this.lbl_pNumber.Location = new System.Drawing.Point(124, 9);
            this.lbl_pNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pNumber.Name = "lbl_pNumber";
            this.lbl_pNumber.Size = new System.Drawing.Size(80, 13);
            this.lbl_pNumber.TabIndex = 0;
            this.lbl_pNumber.Text = "Project Number";
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(125, 34);
            this.lbl_pName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(63, 13);
            this.lbl_pName.TabIndex = 2;
            this.lbl_pName.Text = "Project Title";
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(233, 31);
            this.tb_pNameValue.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pNameValue.MaxLength = 100;
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.Size = new System.Drawing.Size(387, 20);
            this.tb_pNameValue.TabIndex = 3;
            // 
            // lbl_pStage
            // 
            this.lbl_pStage.AutoSize = true;
            this.lbl_pStage.Location = new System.Drawing.Point(161, 175);
            this.lbl_pStage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStage.Name = "lbl_pStage";
            this.lbl_pStage.Size = new System.Drawing.Size(35, 13);
            this.lbl_pStage.TabIndex = 4;
            this.lbl_pStage.Text = "Stage";
            // 
            // cb_pStage
            // 
            this.cb_pStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pStage.FormattingEnabled = true;
            this.cb_pStage.Location = new System.Drawing.Point(202, 172);
            this.cb_pStage.Margin = new System.Windows.Forms.Padding(2);
            this.cb_pStage.Name = "cb_pStage";
            this.cb_pStage.Size = new System.Drawing.Size(124, 21);
            this.cb_pStage.TabIndex = 5;
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(338, 176);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(105, 13);
            this.lbl_pPI.TabIndex = 4;
            this.lbl_pPI.Text = "Principal Investigator";
            // 
            // lbl_pStartDate
            // 
            this.lbl_pStartDate.AutoSize = true;
            this.lbl_pStartDate.Location = new System.Drawing.Point(145, 21);
            this.lbl_pStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStartDate.Name = "lbl_pStartDate";
            this.lbl_pStartDate.Size = new System.Drawing.Size(55, 13);
            this.lbl_pStartDate.TabIndex = 6;
            this.lbl_pStartDate.Text = "Start Date";
            // 
            // lbl_pEndDate
            // 
            this.lbl_pEndDate.AutoSize = true;
            this.lbl_pEndDate.Location = new System.Drawing.Point(148, 49);
            this.lbl_pEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pEndDate.Name = "lbl_pEndDate";
            this.lbl_pEndDate.Size = new System.Drawing.Size(52, 13);
            this.lbl_pEndDate.TabIndex = 8;
            this.lbl_pEndDate.Text = "End Date";
            // 
            // dgv_pNotes
            // 
            this.dgv_pNotes.AllowUserToAddRows = false;
            this.dgv_pNotes.AllowUserToDeleteRows = false;
            this.dgv_pNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pNotes.Location = new System.Drawing.Point(5, 62);
            this.dgv_pNotes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_pNotes.Name = "dgv_pNotes";
            this.dgv_pNotes.ReadOnly = true;
            this.dgv_pNotes.RowHeadersVisible = false;
            this.dgv_pNotes.RowTemplate.Height = 24;
            this.dgv_pNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_pNotes.Size = new System.Drawing.Size(494, 150);
            this.dgv_pNotes.TabIndex = 12;
            this.dgv_pNotes.TabStop = false;
            // 
            // mtb_pEndDateValue
            // 
            this.mtb_pEndDateValue.Location = new System.Drawing.Point(204, 46);
            this.mtb_pEndDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pEndDateValue.Mask = "00/00/0000";
            this.mtb_pEndDateValue.Name = "mtb_pEndDateValue";
            this.mtb_pEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pEndDateValue.TabIndex = 9;
            this.mtb_pEndDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_pEndDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // mtb_pStartDateValue
            // 
            this.mtb_pStartDateValue.Location = new System.Drawing.Point(204, 18);
            this.mtb_pStartDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pStartDateValue.Mask = "00/00/0000";
            this.mtb_pStartDateValue.Name = "mtb_pStartDateValue";
            this.mtb_pStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pStartDateValue.TabIndex = 7;
            this.mtb_pStartDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_pStartDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // tb_NewProjectNote
            // 
            this.tb_NewProjectNote.Location = new System.Drawing.Point(5, 18);
            this.tb_NewProjectNote.Margin = new System.Windows.Forms.Padding(2);
            this.tb_NewProjectNote.MaxLength = 8000;
            this.tb_NewProjectNote.Multiline = true;
            this.tb_NewProjectNote.Name = "tb_NewProjectNote";
            this.tb_NewProjectNote.Size = new System.Drawing.Size(433, 40);
            this.tb_NewProjectNote.TabIndex = 10;
            // 
            // btn_InsertProjectNote
            // 
            this.btn_InsertProjectNote.Location = new System.Drawing.Point(443, 18);
            this.btn_InsertProjectNote.Margin = new System.Windows.Forms.Padding(2);
            this.btn_InsertProjectNote.Name = "btn_InsertProjectNote";
            this.btn_InsertProjectNote.Size = new System.Drawing.Size(55, 40);
            this.btn_InsertProjectNote.TabIndex = 11;
            this.btn_InsertProjectNote.Text = "Add Note";
            this.btn_InsertProjectNote.UseVisualStyleBackColor = true;
            this.btn_InsertProjectNote.Click += new System.EventHandler(this.btn_InsertProjectNote_Click);
            // 
            // cb_pNumberValue
            // 
            this.cb_pNumberValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pNumberValue.FormattingEnabled = true;
            this.cb_pNumberValue.Location = new System.Drawing.Point(233, 7);
            this.cb_pNumberValue.Margin = new System.Windows.Forms.Padding(2);
            this.cb_pNumberValue.Name = "cb_pNumberValue";
            this.cb_pNumberValue.Size = new System.Drawing.Size(92, 21);
            this.cb_pNumberValue.TabIndex = 1;
            this.cb_pNumberValue.SelectionChangeCommitted += new System.EventHandler(this.cb_pNumberValue_SelectionChanged);
            // 
            // btn_ProjectCancel
            // 
            this.btn_ProjectCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ProjectCancel.Location = new System.Drawing.Point(763, 448);
            this.btn_ProjectCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ProjectCancel.Name = "btn_ProjectCancel";
            this.btn_ProjectCancel.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectCancel.TabIndex = 15;
            this.btn_ProjectCancel.Text = "Cancel";
            this.btn_ProjectCancel.UseVisualStyleBackColor = true;
            this.btn_ProjectCancel.Click += new System.EventHandler(this.btn_ProjectCancel_Click);
            // 
            // btn_ProjectOK
            // 
            this.btn_ProjectOK.Location = new System.Drawing.Point(703, 448);
            this.btn_ProjectOK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ProjectOK.Name = "btn_ProjectOK";
            this.btn_ProjectOK.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectOK.TabIndex = 14;
            this.btn_ProjectOK.Text = "OK";
            this.btn_ProjectOK.UseVisualStyleBackColor = true;
            this.btn_ProjectOK.Click += new System.EventHandler(this.btn_ProjectOK_Click);
            // 
            // btn_ProjectApply
            // 
            this.btn_ProjectApply.Location = new System.Drawing.Point(642, 448);
            this.btn_ProjectApply.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ProjectApply.Name = "btn_ProjectApply";
            this.btn_ProjectApply.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectApply.TabIndex = 13;
            this.btn_ProjectApply.Text = "Apply";
            this.btn_ProjectApply.UseVisualStyleBackColor = true;
            this.btn_ProjectApply.Click += new System.EventHandler(this.btn_ProjectApply_Click);
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Location = new System.Drawing.Point(132, 448);
            this.btn_NewProject.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(90, 24);
            this.btn_NewProject.TabIndex = 16;
            this.btn_NewProject.Text = "Create Project";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.btn_NewProject_Click);
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
            // gb_Platform
            // 
            this.gb_Platform.Controls.Add(this.chkb_Azure);
            this.gb_Platform.Controls.Add(this.chkb_IRC);
            this.gb_Platform.Controls.Add(this.chkb_SEED);
            this.gb_Platform.Location = new System.Drawing.Point(136, 67);
            this.gb_Platform.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Platform.Name = "gb_Platform";
            this.gb_Platform.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Platform.Size = new System.Drawing.Size(68, 79);
            this.gb_Platform.TabIndex = 19;
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
            // cb_pClassification
            // 
            this.cb_pClassification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pClassification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pClassification.FormattingEnabled = true;
            this.cb_pClassification.Location = new System.Drawing.Point(202, 198);
            this.cb_pClassification.Name = "cb_pClassification";
            this.cb_pClassification.Size = new System.Drawing.Size(124, 21);
            this.cb_pClassification.TabIndex = 20;
            // 
            // lbl_pClassification
            // 
            this.lbl_pClassification.AutoSize = true;
            this.lbl_pClassification.Location = new System.Drawing.Point(128, 201);
            this.lbl_pClassification.Name = "lbl_pClassification";
            this.lbl_pClassification.Size = new System.Drawing.Size(68, 13);
            this.lbl_pClassification.TabIndex = 21;
            this.lbl_pClassification.Text = "Classification";
            // 
            // lbl_DATRAG
            // 
            this.lbl_DATRAG.AutoSize = true;
            this.lbl_DATRAG.Location = new System.Drawing.Point(483, 8);
            this.lbl_DATRAG.Name = "lbl_DATRAG";
            this.lbl_DATRAG.Size = new System.Drawing.Size(55, 13);
            this.lbl_DATRAG.TabIndex = 22;
            this.lbl_DATRAG.Text = "DAT RAG";
            // 
            // cb_DATRAG
            // 
            this.cb_DATRAG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_DATRAG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_DATRAG.FormattingEnabled = true;
            this.cb_DATRAG.Location = new System.Drawing.Point(544, 5);
            this.cb_DATRAG.Name = "cb_DATRAG";
            this.cb_DATRAG.Size = new System.Drawing.Size(76, 21);
            this.cb_DATRAG.TabIndex = 23;
            // 
            // mtb_ProjectedEndDateValue
            // 
            this.mtb_ProjectedEndDateValue.Location = new System.Drawing.Point(63, 46);
            this.mtb_ProjectedEndDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ProjectedEndDateValue.Mask = "00/00/0000";
            this.mtb_ProjectedEndDateValue.Name = "mtb_ProjectedEndDateValue";
            this.mtb_ProjectedEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_ProjectedEndDateValue.TabIndex = 25;
            this.mtb_ProjectedEndDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_ProjectedEndDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // lbl_ProjectedEndDate
            // 
            this.lbl_ProjectedEndDate.AutoSize = true;
            this.lbl_ProjectedEndDate.Location = new System.Drawing.Point(4, 43);
            this.lbl_ProjectedEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProjectedEndDate.Name = "lbl_ProjectedEndDate";
            this.lbl_ProjectedEndDate.Size = new System.Drawing.Size(55, 26);
            this.lbl_ProjectedEndDate.TabIndex = 24;
            this.lbl_ProjectedEndDate.Text = "Projected \r\nEnd Date";
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Faculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(447, 198);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(173, 21);
            this.cb_Faculty.TabIndex = 27;
            // 
            // lbl_Faculty
            // 
            this.lbl_Faculty.AutoSize = true;
            this.lbl_Faculty.Location = new System.Drawing.Point(402, 201);
            this.lbl_Faculty.Name = "lbl_Faculty";
            this.lbl_Faculty.Size = new System.Drawing.Size(41, 13);
            this.lbl_Faculty.TabIndex = 26;
            this.lbl_Faculty.Text = "Faculty";
            // 
            // gb_Governance
            // 
            this.gb_Governance.Controls.Add(this.chkb_ISO27001);
            this.gb_Governance.Controls.Add(this.chkb_DSPT);
            this.gb_Governance.Location = new System.Drawing.Point(233, 67);
            this.gb_Governance.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Governance.Name = "gb_Governance";
            this.gb_Governance.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Governance.Size = new System.Drawing.Size(90, 62);
            this.gb_Governance.TabIndex = 20;
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
            // btn_Users
            // 
            this.btn_Users.Location = new System.Drawing.Point(3, 49);
            this.btn_Users.Name = "btn_Users";
            this.btn_Users.Size = new System.Drawing.Size(75, 23);
            this.btn_Users.TabIndex = 28;
            this.btn_Users.Text = "Users";
            this.btn_Users.UseVisualStyleBackColor = true;
            // 
            // btn_Projects
            // 
            this.btn_Projects.Location = new System.Drawing.Point(3, 3);
            this.btn_Projects.Name = "btn_Projects";
            this.btn_Projects.Size = new System.Drawing.Size(75, 23);
            this.btn_Projects.TabIndex = 29;
            this.btn_Projects.Text = "All Projects";
            this.btn_Projects.UseVisualStyleBackColor = true;
            // 
            // btn_Documents
            // 
            this.btn_Documents.Location = new System.Drawing.Point(3, 78);
            this.btn_Documents.Name = "btn_Documents";
            this.btn_Documents.Size = new System.Drawing.Size(75, 23);
            this.btn_Documents.TabIndex = 30;
            this.btn_Documents.Text = "Documents";
            this.btn_Documents.UseVisualStyleBackColor = true;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(562, 449);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 31;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Platform);
            this.panel1.Controls.Add(this.btn_Projects);
            this.panel1.Controls.Add(this.btn_Users);
            this.panel1.Controls.Add(this.btn_Documents);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 139);
            this.panel1.TabIndex = 32;
            // 
            // btn_Platform
            // 
            this.btn_Platform.Location = new System.Drawing.Point(3, 108);
            this.btn_Platform.Name = "btn_Platform";
            this.btn_Platform.Size = new System.Drawing.Size(75, 23);
            this.btn_Platform.TabIndex = 31;
            this.btn_Platform.Text = "Platform";
            this.btn_Platform.UseVisualStyleBackColor = true;
            // 
            // lbl_LeadApplicant
            // 
            this.lbl_LeadApplicant.AutoSize = true;
            this.lbl_LeadApplicant.Location = new System.Drawing.Point(365, 152);
            this.lbl_LeadApplicant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LeadApplicant.Name = "lbl_LeadApplicant";
            this.lbl_LeadApplicant.Size = new System.Drawing.Size(78, 13);
            this.lbl_LeadApplicant.TabIndex = 33;
            this.lbl_LeadApplicant.Text = "Lead Applicant";
            // 
            // mtb_ProjectedStartDateValue
            // 
            this.mtb_ProjectedStartDateValue.Location = new System.Drawing.Point(63, 18);
            this.mtb_ProjectedStartDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ProjectedStartDateValue.Mask = "00/00/0000";
            this.mtb_ProjectedStartDateValue.Name = "mtb_ProjectedStartDateValue";
            this.mtb_ProjectedStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_ProjectedStartDateValue.TabIndex = 36;
            this.mtb_ProjectedStartDateValue.ValidatingType = typeof(System.DateTime);
            this.mtb_ProjectedStartDateValue.Click += new System.EventHandler(this.enter_TextBox);
            // 
            // lbl_ProjectedStartDate
            // 
            this.lbl_ProjectedStartDate.AutoSize = true;
            this.lbl_ProjectedStartDate.Location = new System.Drawing.Point(4, 15);
            this.lbl_ProjectedStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProjectedStartDate.Name = "lbl_ProjectedStartDate";
            this.lbl_ProjectedStartDate.Size = new System.Drawing.Size(55, 26);
            this.lbl_ProjectedStartDate.TabIndex = 35;
            this.lbl_ProjectedStartDate.Text = "Projected \r\nStart Date";
            // 
            // cb_LeadApplicant
            // 
            this.cb_LeadApplicant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_LeadApplicant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_LeadApplicant.FormattingEnabled = true;
            this.cb_LeadApplicant.Location = new System.Drawing.Point(447, 149);
            this.cb_LeadApplicant.Name = "cb_LeadApplicant";
            this.cb_LeadApplicant.Size = new System.Drawing.Size(173, 21);
            this.cb_LeadApplicant.TabIndex = 37;
            // 
            // cb_PI
            // 
            this.cb_PI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PI.FormattingEnabled = true;
            this.cb_PI.Location = new System.Drawing.Point(447, 173);
            this.cb_PI.Name = "cb_PI";
            this.cb_PI.Size = new System.Drawing.Size(173, 21);
            this.cb_PI.TabIndex = 39;
            // 
            // dgv_ProjectUsers
            // 
            this.dgv_ProjectUsers.AllowUserToAddRows = false;
            this.dgv_ProjectUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProjectUsers.ColumnHeadersVisible = false;
            this.dgv_ProjectUsers.Location = new System.Drawing.Point(16, 19);
            this.dgv_ProjectUsers.Name = "dgv_ProjectUsers";
            this.dgv_ProjectUsers.ReadOnly = true;
            this.dgv_ProjectUsers.RowHeadersVisible = false;
            this.dgv_ProjectUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ProjectUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProjectUsers.Size = new System.Drawing.Size(155, 160);
            this.dgv_ProjectUsers.TabIndex = 41;
            this.dgv_ProjectUsers.TabStop = false;
            this.dgv_ProjectUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ProjectUsers_CellDoubleClick);
            // 
            // btn_ProjectUserAdd
            // 
            this.btn_ProjectUserAdd.Location = new System.Drawing.Point(16, 185);
            this.btn_ProjectUserAdd.Name = "btn_ProjectUserAdd";
            this.btn_ProjectUserAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectUserAdd.TabIndex = 42;
            this.btn_ProjectUserAdd.Text = "Add";
            this.btn_ProjectUserAdd.UseVisualStyleBackColor = true;
            this.btn_ProjectUserAdd.Click += new System.EventHandler(this.btn_ProjectUserAdd_Click);
            // 
            // btn_ProjectUserRemove
            // 
            this.btn_ProjectUserRemove.Location = new System.Drawing.Point(96, 185);
            this.btn_ProjectUserRemove.Name = "btn_ProjectUserRemove";
            this.btn_ProjectUserRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectUserRemove.TabIndex = 43;
            this.btn_ProjectUserRemove.Text = "Remove";
            this.btn_ProjectUserRemove.UseVisualStyleBackColor = true;
            this.btn_ProjectUserRemove.Click += new System.EventHandler(this.btn_ProjectUserRemove_Click);
            // 
            // gb_ProjectUsers
            // 
            this.gb_ProjectUsers.Controls.Add(this.dgv_ProjectUsers);
            this.gb_ProjectUsers.Controls.Add(this.btn_ProjectUserRemove);
            this.gb_ProjectUsers.Controls.Add(this.btn_ProjectUserAdd);
            this.gb_ProjectUsers.Location = new System.Drawing.Point(634, 5);
            this.gb_ProjectUsers.Name = "gb_ProjectUsers";
            this.gb_ProjectUsers.Size = new System.Drawing.Size(185, 214);
            this.gb_ProjectUsers.TabIndex = 45;
            this.gb_ProjectUsers.TabStop = false;
            this.gb_ProjectUsers.Text = "Research Team";
            // 
            // gb_ProjectNotes
            // 
            this.gb_ProjectNotes.Controls.Add(this.tb_NewProjectNote);
            this.gb_ProjectNotes.Controls.Add(this.dgv_pNotes);
            this.gb_ProjectNotes.Controls.Add(this.btn_InsertProjectNote);
            this.gb_ProjectNotes.Location = new System.Drawing.Point(127, 225);
            this.gb_ProjectNotes.Name = "gb_ProjectNotes";
            this.gb_ProjectNotes.Size = new System.Drawing.Size(506, 218);
            this.gb_ProjectNotes.TabIndex = 46;
            this.gb_ProjectNotes.TabStop = false;
            this.gb_ProjectNotes.Text = "Notes";
            // 
            // gb_KeyDates
            // 
            this.gb_KeyDates.Controls.Add(this.lbl_ProjectedStartDate);
            this.gb_KeyDates.Controls.Add(this.lbl_pStartDate);
            this.gb_KeyDates.Controls.Add(this.lbl_pEndDate);
            this.gb_KeyDates.Controls.Add(this.mtb_pEndDateValue);
            this.gb_KeyDates.Controls.Add(this.mtb_pStartDateValue);
            this.gb_KeyDates.Controls.Add(this.lbl_ProjectedEndDate);
            this.gb_KeyDates.Controls.Add(this.mtb_ProjectedEndDateValue);
            this.gb_KeyDates.Controls.Add(this.mtb_ProjectedStartDateValue);
            this.gb_KeyDates.Location = new System.Drawing.Point(341, 56);
            this.gb_KeyDates.Name = "gb_KeyDates";
            this.gb_KeyDates.Size = new System.Drawing.Size(287, 73);
            this.gb_KeyDates.TabIndex = 47;
            this.gb_KeyDates.TabStop = false;
            this.gb_KeyDates.Text = "Key Dates";
            // 
            // gb_ProjectDocuments
            // 
            this.gb_ProjectDocuments.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gb_ProjectDocuments.Controls.Add(this.btn_AllDocs);
            this.gb_ProjectDocuments.Controls.Add(this.btn_RA);
            this.gb_ProjectDocuments.Controls.Add(this.btn_DMP);
            this.gb_ProjectDocuments.Controls.Add(this.btn_Proposal);
            this.gb_ProjectDocuments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gb_ProjectDocuments.Location = new System.Drawing.Point(639, 225);
            this.gb_ProjectDocuments.Name = "gb_ProjectDocuments";
            this.gb_ProjectDocuments.Size = new System.Drawing.Size(180, 218);
            this.gb_ProjectDocuments.TabIndex = 48;
            this.gb_ProjectDocuments.TabStop = false;
            this.gb_ProjectDocuments.Text = "Project Documents";
            // 
            // btn_AllDocs
            // 
            this.btn_AllDocs.Location = new System.Drawing.Point(99, 135);
            this.btn_AllDocs.Name = "btn_AllDocs";
            this.btn_AllDocs.Size = new System.Drawing.Size(75, 23);
            this.btn_AllDocs.TabIndex = 49;
            this.btn_AllDocs.Text = "All Docs";
            this.btn_AllDocs.UseVisualStyleBackColor = true;
            this.btn_AllDocs.Click += new System.EventHandler(this.btn_AllDocs_Click);
            // 
            // btn_RA
            // 
            this.btn_RA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_RA.Location = new System.Drawing.Point(4, 77);
            this.btn_RA.Name = "btn_RA";
            this.btn_RA.Size = new System.Drawing.Size(170, 23);
            this.btn_RA.TabIndex = 2;
            this.btn_RA.Text = "Risk Assessment";
            this.btn_RA.UseVisualStyleBackColor = false;
            this.btn_RA.Click += new System.EventHandler(this.btn_RA_Click);
            // 
            // btn_DMP
            // 
            this.btn_DMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_DMP.Location = new System.Drawing.Point(6, 48);
            this.btn_DMP.Name = "btn_DMP";
            this.btn_DMP.Size = new System.Drawing.Size(170, 23);
            this.btn_DMP.TabIndex = 1;
            this.btn_DMP.Text = "DMP";
            this.btn_DMP.UseVisualStyleBackColor = false;
            this.btn_DMP.Click += new System.EventHandler(this.btn_DMP_Click);
            // 
            // btn_Proposal
            // 
            this.btn_Proposal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Proposal.Location = new System.Drawing.Point(6, 19);
            this.btn_Proposal.Name = "btn_Proposal";
            this.btn_Proposal.Size = new System.Drawing.Size(170, 23);
            this.btn_Proposal.TabIndex = 0;
            this.btn_Proposal.Text = "IRC Proposal";
            this.btn_Proposal.UseVisualStyleBackColor = false;
            this.btn_Proposal.Click += new System.EventHandler(this.btn_Proposal_Click);
            // 
            // frm_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ProjectCancel;
            this.ClientSize = new System.Drawing.Size(828, 480);
            this.Controls.Add(this.gb_ProjectDocuments);
            this.Controls.Add(this.gb_KeyDates);
            this.Controls.Add(this.gb_ProjectNotes);
            this.Controls.Add(this.gb_ProjectUsers);
            this.Controls.Add(this.cb_PI);
            this.Controls.Add(this.cb_LeadApplicant);
            this.Controls.Add(this.lbl_LeadApplicant);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.gb_Governance);
            this.Controls.Add(this.cb_Faculty);
            this.Controls.Add(this.lbl_Faculty);
            this.Controls.Add(this.cb_DATRAG);
            this.Controls.Add(this.lbl_DATRAG);
            this.Controls.Add(this.lbl_pClassification);
            this.Controls.Add(this.cb_pClassification);
            this.Controls.Add(this.gb_Platform);
            this.Controls.Add(this.btn_NewProject);
            this.Controls.Add(this.btn_ProjectApply);
            this.Controls.Add(this.btn_ProjectOK);
            this.Controls.Add(this.btn_ProjectCancel);
            this.Controls.Add(this.cb_pNumberValue);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.cb_pStage);
            this.Controls.Add(this.lbl_pStage);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Controls.Add(this.lbl_pNumber);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Project";
            this.Text = "Project Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pNotes)).EndInit();
            this.gb_Platform.ResumeLayout(false);
            this.gb_Platform.PerformLayout();
            this.gb_Governance.ResumeLayout(false);
            this.gb_Governance.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectUsers)).EndInit();
            this.gb_ProjectUsers.ResumeLayout(false);
            this.gb_ProjectNotes.ResumeLayout(false);
            this.gb_ProjectNotes.PerformLayout();
            this.gb_KeyDates.ResumeLayout(false);
            this.gb_KeyDates.PerformLayout();
            this.gb_ProjectDocuments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pNumber;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pStage;
        private System.Windows.Forms.ComboBox cb_pStage;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.Label lbl_pStartDate;
        private System.Windows.Forms.Label lbl_pEndDate;
        private System.Windows.Forms.DataGridView dgv_pNotes;
        private System.Windows.Forms.MaskedTextBox mtb_pEndDateValue;
        private System.Windows.Forms.MaskedTextBox mtb_pStartDateValue;
        private System.Windows.Forms.TextBox tb_NewProjectNote;
        private System.Windows.Forms.Button btn_InsertProjectNote;
        private System.Windows.Forms.ComboBox cb_pNumberValue;
        private System.Windows.Forms.Button btn_ProjectCancel;
        private System.Windows.Forms.Button btn_ProjectOK;
        private System.Windows.Forms.Button btn_ProjectApply;
        private System.Windows.Forms.Button btn_NewProject;
        private System.Windows.Forms.CheckBox chkb_IRC;
        private System.Windows.Forms.CheckBox chkb_SEED;
        private System.Windows.Forms.GroupBox gb_Platform;
        private System.Windows.Forms.ComboBox cb_pClassification;
        private System.Windows.Forms.Label lbl_pClassification;
        private System.Windows.Forms.Label lbl_DATRAG;
        private System.Windows.Forms.ComboBox cb_DATRAG;
        private System.Windows.Forms.MaskedTextBox mtb_ProjectedEndDateValue;
        private System.Windows.Forms.Label lbl_ProjectedEndDate;
        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Label lbl_Faculty;
        private System.Windows.Forms.GroupBox gb_Governance;
        private System.Windows.Forms.CheckBox chkb_ISO27001;
        private System.Windows.Forms.CheckBox chkb_DSPT;
        private System.Windows.Forms.Button btn_Users;
        private System.Windows.Forms.Button btn_Projects;
        private System.Windows.Forms.Button btn_Documents;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkb_Azure;
        private System.Windows.Forms.Label lbl_LeadApplicant;
        private System.Windows.Forms.MaskedTextBox mtb_ProjectedStartDateValue;
        private System.Windows.Forms.Label lbl_ProjectedStartDate;
        private System.Windows.Forms.Button btn_Platform;
        private System.Windows.Forms.ComboBox cb_LeadApplicant;
        private System.Windows.Forms.ComboBox cb_PI;
        private System.Windows.Forms.DataGridView dgv_ProjectUsers;
        private System.Windows.Forms.Button btn_ProjectUserAdd;
        private System.Windows.Forms.Button btn_ProjectUserRemove;
        private System.Windows.Forms.GroupBox gb_ProjectUsers;
        private System.Windows.Forms.GroupBox gb_ProjectNotes;
        private System.Windows.Forms.GroupBox gb_KeyDates;
        private System.Windows.Forms.GroupBox gb_ProjectDocuments;
        private System.Windows.Forms.Button btn_RA;
        private System.Windows.Forms.Button btn_DMP;
        private System.Windows.Forms.Button btn_Proposal;
        private System.Windows.Forms.Button btn_AllDocs;
    }
}