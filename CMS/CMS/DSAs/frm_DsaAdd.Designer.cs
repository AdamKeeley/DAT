namespace CMS.DSAs
{
    partial class frm_DsaAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DsaAdd));
            this.cb_ExistingDataOwner = new System.Windows.Forms.ComboBox();
            this.gb_DataOwner = new System.Windows.Forms.GroupBox();
            this.chkb_OldDataOwners = new System.Windows.Forms.CheckBox();
            this.lbl_NewDataOwner = new System.Windows.Forms.Label();
            this.tb_OwnerEmail = new System.Windows.Forms.TextBox();
            this.lbl_OwnerEmail = new System.Windows.Forms.Label();
            this.gb_DsaFileDetails = new System.Windows.Forms.GroupBox();
            this.tb_FilePath = new System.Windows.Forms.TextBox();
            this.lbl_FilePath = new System.Windows.Forms.Label();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.lbl_ExpiryDate = new System.Windows.Forms.Label();
            this.gb_AmendmentOf = new System.Windows.Forms.GroupBox();
            this.btn_AddAmendment = new System.Windows.Forms.Button();
            this.dgv_AmendmentOf = new System.Windows.Forms.DataGridView();
            this.gb_GovernanceReq = new System.Windows.Forms.GroupBox();
            this.chkb_NoRemoteAccess = new System.Windows.Forms.CheckBox();
            this.chkb_Encryption = new System.Windows.Forms.CheckBox();
            this.chkb_ISO27001 = new System.Windows.Forms.CheckBox();
            this.chkb_DSPT = new System.Windows.Forms.CheckBox();
            this.gb_Notes = new System.Windows.Forms.GroupBox();
            this.dgv_AddNote = new System.Windows.Forms.DataGridView();
            this.btn_AddNote = new System.Windows.Forms.Button();
            this.tb_AddNote = new System.Windows.Forms.TextBox();
            this.gb_Project = new System.Windows.Forms.GroupBox();
            this.dgv_DsasProjects = new System.Windows.Forms.DataGridView();
            this.btn_ProjectAdd = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gb_Dates = new System.Windows.Forms.GroupBox();
            this.lbl_DestroyDate = new System.Windows.Forms.Label();
            this.dtp_DestroyDate = new System.Windows.Forms.DateTimePicker();
            this.gb_DataOwner.SuspendLayout();
            this.gb_DsaFileDetails.SuspendLayout();
            this.gb_AmendmentOf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentOf)).BeginInit();
            this.gb_GovernanceReq.SuspendLayout();
            this.gb_Notes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddNote)).BeginInit();
            this.gb_Project.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsasProjects)).BeginInit();
            this.gb_Dates.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ExistingDataOwner
            // 
            this.cb_ExistingDataOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ExistingDataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ExistingDataOwner.FormattingEnabled = true;
            this.cb_ExistingDataOwner.Location = new System.Drawing.Point(101, 26);
            this.cb_ExistingDataOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ExistingDataOwner.Name = "cb_ExistingDataOwner";
            this.cb_ExistingDataOwner.Size = new System.Drawing.Size(408, 25);
            this.cb_ExistingDataOwner.TabIndex = 1;
            // 
            // gb_DataOwner
            // 
            this.gb_DataOwner.Controls.Add(this.chkb_OldDataOwners);
            this.gb_DataOwner.Controls.Add(this.lbl_NewDataOwner);
            this.gb_DataOwner.Controls.Add(this.tb_OwnerEmail);
            this.gb_DataOwner.Controls.Add(this.lbl_OwnerEmail);
            this.gb_DataOwner.Controls.Add(this.cb_ExistingDataOwner);
            this.gb_DataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataOwner.Location = new System.Drawing.Point(12, 12);
            this.gb_DataOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DataOwner.Name = "gb_DataOwner";
            this.gb_DataOwner.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DataOwner.Size = new System.Drawing.Size(520, 103);
            this.gb_DataOwner.TabIndex = 2;
            this.gb_DataOwner.TabStop = false;
            this.gb_DataOwner.Text = "Data Owner";
            // 
            // chkb_OldDataOwners
            // 
            this.chkb_OldDataOwners.AutoSize = true;
            this.chkb_OldDataOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_OldDataOwners.Location = new System.Drawing.Point(8, 57);
            this.chkb_OldDataOwners.Margin = new System.Windows.Forms.Padding(4);
            this.chkb_OldDataOwners.Name = "chkb_OldDataOwners";
            this.chkb_OldDataOwners.Size = new System.Drawing.Size(115, 38);
            this.chkb_OldDataOwners.TabIndex = 6;
            this.chkb_OldDataOwners.Text = "Exclude old\r\ndata owners?";
            this.chkb_OldDataOwners.UseVisualStyleBackColor = true;
            this.chkb_OldDataOwners.CheckedChanged += new System.EventHandler(this.chkb_OldDataOwners_CheckedChanged);
            // 
            // lbl_NewDataOwner
            // 
            this.lbl_NewDataOwner.AutoSize = true;
            this.lbl_NewDataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewDataOwner.Location = new System.Drawing.Point(7, 19);
            this.lbl_NewDataOwner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NewDataOwner.Name = "lbl_NewDataOwner";
            this.lbl_NewDataOwner.Size = new System.Drawing.Size(90, 34);
            this.lbl_NewDataOwner.TabIndex = 5;
            this.lbl_NewDataOwner.Text = "new\r\ndata owner...";
            this.lbl_NewDataOwner.Click += new System.EventHandler(this.lbl_NewDataOwner_Click);
            // 
            // tb_OwnerEmail
            // 
            this.tb_OwnerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_OwnerEmail.Location = new System.Drawing.Point(260, 64);
            this.tb_OwnerEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_OwnerEmail.Name = "tb_OwnerEmail";
            this.tb_OwnerEmail.Size = new System.Drawing.Size(249, 23);
            this.tb_OwnerEmail.TabIndex = 4;
            // 
            // lbl_OwnerEmail
            // 
            this.lbl_OwnerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OwnerEmail.Location = new System.Drawing.Point(135, 57);
            this.lbl_OwnerEmail.Name = "lbl_OwnerEmail";
            this.lbl_OwnerEmail.Size = new System.Drawing.Size(120, 34);
            this.lbl_OwnerEmail.TabIndex = 3;
            this.lbl_OwnerEmail.Text = "DSA Contact\'s\r\nEmail Address";
            this.lbl_OwnerEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_DsaFileDetails
            // 
            this.gb_DsaFileDetails.Controls.Add(this.tb_FilePath);
            this.gb_DsaFileDetails.Controls.Add(this.lbl_FilePath);
            this.gb_DsaFileDetails.Controls.Add(this.tb_FileName);
            this.gb_DsaFileDetails.Controls.Add(this.lbl_FileName);
            this.gb_DsaFileDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DsaFileDetails.Location = new System.Drawing.Point(537, 14);
            this.gb_DsaFileDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DsaFileDetails.Name = "gb_DsaFileDetails";
            this.gb_DsaFileDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DsaFileDetails.Size = new System.Drawing.Size(503, 103);
            this.gb_DsaFileDetails.TabIndex = 3;
            this.gb_DsaFileDetails.TabStop = false;
            this.gb_DsaFileDetails.Text = "File Details";
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_FilePath.Location = new System.Drawing.Point(84, 65);
            this.tb_FilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.Size = new System.Drawing.Size(404, 23);
            this.tb_FilePath.TabIndex = 3;
            // 
            // lbl_FilePath
            // 
            this.lbl_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilePath.Location = new System.Drawing.Point(13, 66);
            this.lbl_FilePath.Name = "lbl_FilePath";
            this.lbl_FilePath.Size = new System.Drawing.Size(65, 21);
            this.lbl_FilePath.TabIndex = 2;
            this.lbl_FilePath.Text = "File Path";
            this.lbl_FilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_FileName
            // 
            this.tb_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_FileName.Location = new System.Drawing.Point(84, 23);
            this.tb_FileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.Size = new System.Drawing.Size(404, 23);
            this.tb_FileName.TabIndex = 1;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.Location = new System.Drawing.Point(4, 26);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(75, 16);
            this.lbl_FileName.TabIndex = 0;
            this.lbl_FileName.Text = "File Name";
            this.lbl_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Checked = false;
            this.dtp_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_StartDate.Location = new System.Drawing.Point(83, 17);
            this.dtp_StartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_StartDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_StartDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.ShowCheckBox = true;
            this.dtp_StartDate.Size = new System.Drawing.Size(225, 23);
            this.dtp_StartDate.TabIndex = 4;
            // 
            // dtp_ExpiryDate
            // 
            this.dtp_ExpiryDate.Checked = false;
            this.dtp_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ExpiryDate.Location = new System.Drawing.Point(392, 17);
            this.dtp_ExpiryDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_ExpiryDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_ExpiryDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_ExpiryDate.Name = "dtp_ExpiryDate";
            this.dtp_ExpiryDate.ShowCheckBox = true;
            this.dtp_ExpiryDate.Size = new System.Drawing.Size(225, 23);
            this.dtp_ExpiryDate.TabIndex = 5;
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StartDate.Location = new System.Drawing.Point(24, 21);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(53, 17);
            this.lbl_StartDate.TabIndex = 6;
            this.lbl_StartDate.Text = "Start Date";
            this.lbl_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ExpiryDate
            // 
            this.lbl_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExpiryDate.Location = new System.Drawing.Point(332, 21);
            this.lbl_ExpiryDate.Name = "lbl_ExpiryDate";
            this.lbl_ExpiryDate.Size = new System.Drawing.Size(55, 17);
            this.lbl_ExpiryDate.TabIndex = 7;
            this.lbl_ExpiryDate.Text = "Expiry Date";
            this.lbl_ExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_AmendmentOf
            // 
            this.gb_AmendmentOf.Controls.Add(this.btn_AddAmendment);
            this.gb_AmendmentOf.Controls.Add(this.dgv_AmendmentOf);
            this.gb_AmendmentOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_AmendmentOf.Location = new System.Drawing.Point(6, 225);
            this.gb_AmendmentOf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_AmendmentOf.Name = "gb_AmendmentOf";
            this.gb_AmendmentOf.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_AmendmentOf.Size = new System.Drawing.Size(1028, 153);
            this.gb_AmendmentOf.TabIndex = 8;
            this.gb_AmendmentOf.TabStop = false;
            this.gb_AmendmentOf.Text = "Amendment";
            // 
            // btn_AddAmendment
            // 
            this.btn_AddAmendment.Location = new System.Drawing.Point(334, 15);
            this.btn_AddAmendment.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AddAmendment.Name = "btn_AddAmendment";
            this.btn_AddAmendment.Size = new System.Drawing.Size(357, 28);
            this.btn_AddAmendment.TabIndex = 3;
            this.btn_AddAmendment.Text = "Make this DSA amend an older DSA";
            this.btn_AddAmendment.UseVisualStyleBackColor = true;
            this.btn_AddAmendment.Click += new System.EventHandler(this.btn_AddAmendment_Click);
            // 
            // dgv_AmendmentOf
            // 
            this.dgv_AmendmentOf.AllowUserToAddRows = false;
            this.dgv_AmendmentOf.AllowUserToDeleteRows = false;
            this.dgv_AmendmentOf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AmendmentOf.Location = new System.Drawing.Point(7, 49);
            this.dgv_AmendmentOf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_AmendmentOf.MultiSelect = false;
            this.dgv_AmendmentOf.Name = "dgv_AmendmentOf";
            this.dgv_AmendmentOf.ReadOnly = true;
            this.dgv_AmendmentOf.RowHeadersWidth = 51;
            this.dgv_AmendmentOf.RowTemplate.Height = 24;
            this.dgv_AmendmentOf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AmendmentOf.Size = new System.Drawing.Size(1015, 96);
            this.dgv_AmendmentOf.TabIndex = 0;
            // 
            // gb_GovernanceReq
            // 
            this.gb_GovernanceReq.Controls.Add(this.chkb_NoRemoteAccess);
            this.gb_GovernanceReq.Controls.Add(this.chkb_Encryption);
            this.gb_GovernanceReq.Controls.Add(this.chkb_ISO27001);
            this.gb_GovernanceReq.Controls.Add(this.chkb_DSPT);
            this.gb_GovernanceReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_GovernanceReq.Location = new System.Drawing.Point(12, 175);
            this.gb_GovernanceReq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_GovernanceReq.Name = "gb_GovernanceReq";
            this.gb_GovernanceReq.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_GovernanceReq.Size = new System.Drawing.Size(1028, 46);
            this.gb_GovernanceReq.TabIndex = 9;
            this.gb_GovernanceReq.TabStop = false;
            this.gb_GovernanceReq.Text = "Governance";
            // 
            // chkb_NoRemoteAccess
            // 
            this.chkb_NoRemoteAccess.AutoSize = true;
            this.chkb_NoRemoteAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_NoRemoteAccess.Location = new System.Drawing.Point(804, 20);
            this.chkb_NoRemoteAccess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkb_NoRemoteAccess.Name = "chkb_NoRemoteAccess";
            this.chkb_NoRemoteAccess.Size = new System.Drawing.Size(144, 21);
            this.chkb_NoRemoteAccess.TabIndex = 3;
            this.chkb_NoRemoteAccess.Text = "No remote access";
            this.chkb_NoRemoteAccess.UseVisualStyleBackColor = true;
            // 
            // chkb_Encryption
            // 
            this.chkb_Encryption.AutoSize = true;
            this.chkb_Encryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_Encryption.Location = new System.Drawing.Point(525, 20);
            this.chkb_Encryption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkb_Encryption.Name = "chkb_Encryption";
            this.chkb_Encryption.Size = new System.Drawing.Size(154, 21);
            this.chkb_Encryption.TabIndex = 2;
            this.chkb_Encryption.Text = "Encryption required";
            this.chkb_Encryption.UseVisualStyleBackColor = true;
            // 
            // chkb_ISO27001
            // 
            this.chkb_ISO27001.AutoSize = true;
            this.chkb_ISO27001.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ISO27001.Location = new System.Drawing.Point(317, 20);
            this.chkb_ISO27001.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkb_ISO27001.Name = "chkb_ISO27001";
            this.chkb_ISO27001.Size = new System.Drawing.Size(93, 21);
            this.chkb_ISO27001.TabIndex = 1;
            this.chkb_ISO27001.Text = "ISO27001";
            this.chkb_ISO27001.UseVisualStyleBackColor = true;
            // 
            // chkb_DSPT
            // 
            this.chkb_DSPT.AutoSize = true;
            this.chkb_DSPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_DSPT.Location = new System.Drawing.Point(83, 20);
            this.chkb_DSPT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkb_DSPT.Name = "chkb_DSPT";
            this.chkb_DSPT.Size = new System.Drawing.Size(100, 21);
            this.chkb_DSPT.TabIndex = 0;
            this.chkb_DSPT.Text = "NHS DSPT";
            this.chkb_DSPT.UseVisualStyleBackColor = true;
            // 
            // gb_Notes
            // 
            this.gb_Notes.Controls.Add(this.dgv_AddNote);
            this.gb_Notes.Controls.Add(this.btn_AddNote);
            this.gb_Notes.Controls.Add(this.tb_AddNote);
            this.gb_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Notes.Location = new System.Drawing.Point(6, 383);
            this.gb_Notes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Notes.Name = "gb_Notes";
            this.gb_Notes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Notes.Size = new System.Drawing.Size(657, 257);
            this.gb_Notes.TabIndex = 10;
            this.gb_Notes.TabStop = false;
            this.gb_Notes.Text = "Notes";
            // 
            // dgv_AddNote
            // 
            this.dgv_AddNote.AllowUserToAddRows = false;
            this.dgv_AddNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AddNote.Location = new System.Drawing.Point(6, 85);
            this.dgv_AddNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_AddNote.Name = "dgv_AddNote";
            this.dgv_AddNote.ReadOnly = true;
            this.dgv_AddNote.RowHeadersWidth = 51;
            this.dgv_AddNote.RowTemplate.Height = 24;
            this.dgv_AddNote.Size = new System.Drawing.Size(644, 166);
            this.dgv_AddNote.TabIndex = 2;
            // 
            // btn_AddNote
            // 
            this.btn_AddNote.Location = new System.Drawing.Point(571, 20);
            this.btn_AddNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddNote.Name = "btn_AddNote";
            this.btn_AddNote.Size = new System.Drawing.Size(79, 61);
            this.btn_AddNote.TabIndex = 1;
            this.btn_AddNote.Text = "Add Note";
            this.btn_AddNote.UseVisualStyleBackColor = true;
            this.btn_AddNote.Click += new System.EventHandler(this.btn_AddNote_Click);
            // 
            // tb_AddNote
            // 
            this.tb_AddNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_AddNote.Location = new System.Drawing.Point(6, 20);
            this.tb_AddNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_AddNote.Multiline = true;
            this.tb_AddNote.Name = "tb_AddNote";
            this.tb_AddNote.Size = new System.Drawing.Size(559, 60);
            this.tb_AddNote.TabIndex = 0;
            // 
            // gb_Project
            // 
            this.gb_Project.Controls.Add(this.dgv_DsasProjects);
            this.gb_Project.Controls.Add(this.btn_ProjectAdd);
            this.gb_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Project.Location = new System.Drawing.Point(669, 383);
            this.gb_Project.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Project.Name = "gb_Project";
            this.gb_Project.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Project.Size = new System.Drawing.Size(365, 219);
            this.gb_Project.TabIndex = 11;
            this.gb_Project.TabStop = false;
            this.gb_Project.Text = "Associated Project(s)";
            // 
            // dgv_DsasProjects
            // 
            this.dgv_DsasProjects.AllowUserToAddRows = false;
            this.dgv_DsasProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DsasProjects.Location = new System.Drawing.Point(8, 72);
            this.dgv_DsasProjects.Name = "dgv_DsasProjects";
            this.dgv_DsasProjects.ReadOnly = true;
            this.dgv_DsasProjects.RowHeadersWidth = 51;
            this.dgv_DsasProjects.RowTemplate.Height = 24;
            this.dgv_DsasProjects.Size = new System.Drawing.Size(351, 138);
            this.dgv_DsasProjects.TabIndex = 2;
            // 
            // btn_ProjectAdd
            // 
            this.btn_ProjectAdd.Location = new System.Drawing.Point(91, 31);
            this.btn_ProjectAdd.Name = "btn_ProjectAdd";
            this.btn_ProjectAdd.Size = new System.Drawing.Size(171, 35);
            this.btn_ProjectAdd.TabIndex = 1;
            this.btn_ProjectAdd.Text = "Assign Project";
            this.btn_ProjectAdd.UseVisualStyleBackColor = true;
            this.btn_ProjectAdd.Click += new System.EventHandler(this.btn_ProjectAdd_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(893, 606);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(148, 34);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(739, 606);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(149, 34);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // gb_Dates
            // 
            this.gb_Dates.Controls.Add(this.lbl_DestroyDate);
            this.gb_Dates.Controls.Add(this.dtp_DestroyDate);
            this.gb_Dates.Controls.Add(this.dtp_StartDate);
            this.gb_Dates.Controls.Add(this.lbl_StartDate);
            this.gb_Dates.Controls.Add(this.lbl_ExpiryDate);
            this.gb_Dates.Controls.Add(this.dtp_ExpiryDate);
            this.gb_Dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Dates.Location = new System.Drawing.Point(12, 118);
            this.gb_Dates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Dates.Name = "gb_Dates";
            this.gb_Dates.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Dates.Size = new System.Drawing.Size(1028, 53);
            this.gb_Dates.TabIndex = 14;
            this.gb_Dates.TabStop = false;
            this.gb_Dates.Text = "Dates";
            // 
            // lbl_DestroyDate
            // 
            this.lbl_DestroyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DestroyDate.Location = new System.Drawing.Point(647, 21);
            this.lbl_DestroyDate.Name = "lbl_DestroyDate";
            this.lbl_DestroyDate.Size = new System.Drawing.Size(121, 17);
            this.lbl_DestroyDate.TabIndex = 9;
            this.lbl_DestroyDate.Text = "Data Destruction Date";
            this.lbl_DestroyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtp_DestroyDate
            // 
            this.dtp_DestroyDate.Checked = false;
            this.dtp_DestroyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DestroyDate.Location = new System.Drawing.Point(773, 17);
            this.dtp_DestroyDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_DestroyDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_DestroyDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_DestroyDate.Name = "dtp_DestroyDate";
            this.dtp_DestroyDate.ShowCheckBox = true;
            this.dtp_DestroyDate.Size = new System.Drawing.Size(225, 23);
            this.dtp_DestroyDate.TabIndex = 8;
            // 
            // frm_DsaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(1051, 647);
            this.Controls.Add(this.gb_Dates);
            this.Controls.Add(this.gb_GovernanceReq);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gb_Project);
            this.Controls.Add(this.gb_Notes);
            this.Controls.Add(this.gb_DsaFileDetails);
            this.Controls.Add(this.gb_DataOwner);
            this.Controls.Add(this.gb_AmendmentOf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_DsaAdd";
            this.Text = "DSA Record";
            this.gb_DataOwner.ResumeLayout(false);
            this.gb_DataOwner.PerformLayout();
            this.gb_DsaFileDetails.ResumeLayout(false);
            this.gb_DsaFileDetails.PerformLayout();
            this.gb_AmendmentOf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentOf)).EndInit();
            this.gb_GovernanceReq.ResumeLayout(false);
            this.gb_GovernanceReq.PerformLayout();
            this.gb_Notes.ResumeLayout(false);
            this.gb_Notes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddNote)).EndInit();
            this.gb_Project.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsasProjects)).EndInit();
            this.gb_Dates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_ExistingDataOwner;
        private System.Windows.Forms.GroupBox gb_DataOwner;
        private System.Windows.Forms.GroupBox gb_DsaFileDetails;
        private System.Windows.Forms.TextBox tb_FilePath;
        private System.Windows.Forms.Label lbl_FilePath;
        private System.Windows.Forms.TextBox tb_FileName;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.DateTimePicker dtp_ExpiryDate;
        private System.Windows.Forms.Label lbl_StartDate;
        private System.Windows.Forms.Label lbl_ExpiryDate;
        private System.Windows.Forms.GroupBox gb_AmendmentOf;
        private System.Windows.Forms.DataGridView dgv_AmendmentOf;
        private System.Windows.Forms.GroupBox gb_GovernanceReq;
        private System.Windows.Forms.CheckBox chkb_ISO27001;
        private System.Windows.Forms.CheckBox chkb_DSPT;
        private System.Windows.Forms.GroupBox gb_Notes;
        private System.Windows.Forms.DataGridView dgv_AddNote;
        private System.Windows.Forms.Button btn_AddNote;
        private System.Windows.Forms.TextBox tb_AddNote;
        private System.Windows.Forms.GroupBox gb_Project;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox gb_Dates;
        private System.Windows.Forms.CheckBox chkb_NoRemoteAccess;
        private System.Windows.Forms.CheckBox chkb_Encryption;
        private System.Windows.Forms.TextBox tb_OwnerEmail;
        private System.Windows.Forms.Label lbl_OwnerEmail;
        private System.Windows.Forms.Label lbl_DestroyDate;
        private System.Windows.Forms.DateTimePicker dtp_DestroyDate;
        private System.Windows.Forms.Label lbl_NewDataOwner;
        private System.Windows.Forms.CheckBox chkb_OldDataOwners;
        private System.Windows.Forms.Button btn_AddAmendment;
        private System.Windows.Forms.DataGridView dgv_DsasProjects;
        private System.Windows.Forms.Button btn_ProjectAdd;
    }
}