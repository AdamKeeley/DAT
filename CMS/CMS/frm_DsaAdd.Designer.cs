namespace CMS
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
            this.cb_ExistingDataOwner = new System.Windows.Forms.ComboBox();
            this.gb_DataOwner = new System.Windows.Forms.GroupBox();
            this.btn_NewDataOwner = new System.Windows.Forms.Button();
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
            this.lbl_AmendmentHelp = new System.Windows.Forms.Label();
            this.dgv_AmendmentOf = new System.Windows.Forms.DataGridView();
            this.gb_GovernanceReq = new System.Windows.Forms.GroupBox();
            this.chkb_ISO27001 = new System.Windows.Forms.CheckBox();
            this.chkb_DSPT = new System.Windows.Forms.CheckBox();
            this.gb_Notes = new System.Windows.Forms.GroupBox();
            this.dgv_AddNote = new System.Windows.Forms.DataGridView();
            this.btn_AddNote = new System.Windows.Forms.Button();
            this.tb_AddNote = new System.Windows.Forms.TextBox();
            this.gb_Project = new System.Windows.Forms.GroupBox();
            this.lbx_ProjectsList = new System.Windows.Forms.ListBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gb_Dates = new System.Windows.Forms.GroupBox();
            this.gb_DataOwner.SuspendLayout();
            this.gb_DsaFileDetails.SuspendLayout();
            this.gb_AmendmentOf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentOf)).BeginInit();
            this.gb_GovernanceReq.SuspendLayout();
            this.gb_Notes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddNote)).BeginInit();
            this.gb_Project.SuspendLayout();
            this.gb_Dates.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ExistingDataOwner
            // 
            this.cb_ExistingDataOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ExistingDataOwner.FormattingEnabled = true;
            this.cb_ExistingDataOwner.Location = new System.Drawing.Point(10, 26);
            this.cb_ExistingDataOwner.Name = "cb_ExistingDataOwner";
            this.cb_ExistingDataOwner.Size = new System.Drawing.Size(368, 28);
            this.cb_ExistingDataOwner.TabIndex = 1;
            // 
            // gb_DataOwner
            // 
            this.gb_DataOwner.Controls.Add(this.btn_NewDataOwner);
            this.gb_DataOwner.Controls.Add(this.cb_ExistingDataOwner);
            this.gb_DataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataOwner.Location = new System.Drawing.Point(12, 12);
            this.gb_DataOwner.Name = "gb_DataOwner";
            this.gb_DataOwner.Size = new System.Drawing.Size(384, 104);
            this.gb_DataOwner.TabIndex = 2;
            this.gb_DataOwner.TabStop = false;
            this.gb_DataOwner.Text = "Data Owner";
            // 
            // btn_NewDataOwner
            // 
            this.btn_NewDataOwner.Location = new System.Drawing.Point(56, 60);
            this.btn_NewDataOwner.Name = "btn_NewDataOwner";
            this.btn_NewDataOwner.Size = new System.Drawing.Size(266, 37);
            this.btn_NewDataOwner.TabIndex = 2;
            this.btn_NewDataOwner.Text = "Add New Data Owner to List";
            this.btn_NewDataOwner.UseVisualStyleBackColor = true;
            this.btn_NewDataOwner.Click += new System.EventHandler(this.btn_NewDataOwner_Click);
            // 
            // gb_DsaFileDetails
            // 
            this.gb_DsaFileDetails.Controls.Add(this.tb_FilePath);
            this.gb_DsaFileDetails.Controls.Add(this.lbl_FilePath);
            this.gb_DsaFileDetails.Controls.Add(this.tb_FileName);
            this.gb_DsaFileDetails.Controls.Add(this.lbl_FileName);
            this.gb_DsaFileDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DsaFileDetails.Location = new System.Drawing.Point(431, 12);
            this.gb_DsaFileDetails.Name = "gb_DsaFileDetails";
            this.gb_DsaFileDetails.Size = new System.Drawing.Size(561, 104);
            this.gb_DsaFileDetails.TabIndex = 3;
            this.gb_DsaFileDetails.TabStop = false;
            this.gb_DsaFileDetails.Text = "File Details";
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.Location = new System.Drawing.Point(145, 65);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.Size = new System.Drawing.Size(405, 27);
            this.tb_FilePath.TabIndex = 3;
            // 
            // lbl_FilePath
            // 
            this.lbl_FilePath.AutoSize = true;
            this.lbl_FilePath.Location = new System.Drawing.Point(17, 68);
            this.lbl_FilePath.Name = "lbl_FilePath";
            this.lbl_FilePath.Size = new System.Drawing.Size(75, 20);
            this.lbl_FilePath.TabIndex = 2;
            this.lbl_FilePath.Text = "File Path";
            // 
            // tb_FileName
            // 
            this.tb_FileName.Location = new System.Drawing.Point(145, 24);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.Size = new System.Drawing.Size(405, 27);
            this.tb_FileName.TabIndex = 1;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(17, 27);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(85, 20);
            this.lbl_FileName.TabIndex = 0;
            this.lbl_FileName.Text = "File Name";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Checked = false;
            this.dtp_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_StartDate.Location = new System.Drawing.Point(194, 19);
            this.dtp_StartDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_StartDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.ShowCheckBox = true;
            this.dtp_StartDate.Size = new System.Drawing.Size(226, 27);
            this.dtp_StartDate.TabIndex = 4;
            // 
            // dtp_ExpiryDate
            // 
            this.dtp_ExpiryDate.Checked = false;
            this.dtp_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ExpiryDate.Location = new System.Drawing.Point(686, 19);
            this.dtp_ExpiryDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_ExpiryDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_ExpiryDate.Name = "dtp_ExpiryDate";
            this.dtp_ExpiryDate.ShowCheckBox = true;
            this.dtp_ExpiryDate.Size = new System.Drawing.Size(226, 27);
            this.dtp_ExpiryDate.TabIndex = 5;
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.AutoSize = true;
            this.lbl_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StartDate.Location = new System.Drawing.Point(77, 23);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(86, 20);
            this.lbl_StartDate.TabIndex = 6;
            this.lbl_StartDate.Text = "Start Date";
            // 
            // lbl_ExpiryDate
            // 
            this.lbl_ExpiryDate.AutoSize = true;
            this.lbl_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExpiryDate.Location = new System.Drawing.Point(560, 25);
            this.lbl_ExpiryDate.Name = "lbl_ExpiryDate";
            this.lbl_ExpiryDate.Size = new System.Drawing.Size(96, 20);
            this.lbl_ExpiryDate.TabIndex = 7;
            this.lbl_ExpiryDate.Text = "Expiry Date";
            // 
            // gb_AmendmentOf
            // 
            this.gb_AmendmentOf.Controls.Add(this.lbl_AmendmentHelp);
            this.gb_AmendmentOf.Controls.Add(this.dgv_AmendmentOf);
            this.gb_AmendmentOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_AmendmentOf.Location = new System.Drawing.Point(12, 175);
            this.gb_AmendmentOf.Name = "gb_AmendmentOf";
            this.gb_AmendmentOf.Size = new System.Drawing.Size(980, 246);
            this.gb_AmendmentOf.TabIndex = 8;
            this.gb_AmendmentOf.TabStop = false;
            this.gb_AmendmentOf.Text = "Amendment of Previous DSA";
            // 
            // lbl_AmendmentHelp
            // 
            this.lbl_AmendmentHelp.AutoSize = true;
            this.lbl_AmendmentHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AmendmentHelp.Location = new System.Drawing.Point(7, 18);
            this.lbl_AmendmentHelp.Name = "lbl_AmendmentHelp";
            this.lbl_AmendmentHelp.Size = new System.Drawing.Size(551, 17);
            this.lbl_AmendmentHelp.TabIndex = 1;
            this.lbl_AmendmentHelp.Text = "If this DSA amends an original agreement, select the row below containing the ori" +
    "ginal:";
            // 
            // dgv_AmendmentOf
            // 
            this.dgv_AmendmentOf.AllowUserToAddRows = false;
            this.dgv_AmendmentOf.AllowUserToDeleteRows = false;
            this.dgv_AmendmentOf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AmendmentOf.Location = new System.Drawing.Point(6, 38);
            this.dgv_AmendmentOf.Name = "dgv_AmendmentOf";
            this.dgv_AmendmentOf.ReadOnly = true;
            this.dgv_AmendmentOf.RowHeadersWidth = 51;
            this.dgv_AmendmentOf.RowTemplate.Height = 24;
            this.dgv_AmendmentOf.Size = new System.Drawing.Size(968, 201);
            this.dgv_AmendmentOf.TabIndex = 0;
            // 
            // gb_GovernanceReq
            // 
            this.gb_GovernanceReq.Controls.Add(this.chkb_ISO27001);
            this.gb_GovernanceReq.Controls.Add(this.chkb_DSPT);
            this.gb_GovernanceReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_GovernanceReq.Location = new System.Drawing.Point(12, 426);
            this.gb_GovernanceReq.Name = "gb_GovernanceReq";
            this.gb_GovernanceReq.Size = new System.Drawing.Size(322, 80);
            this.gb_GovernanceReq.TabIndex = 9;
            this.gb_GovernanceReq.TabStop = false;
            this.gb_GovernanceReq.Text = "Governance Requirements";
            // 
            // chkb_ISO27001
            // 
            this.chkb_ISO27001.AutoSize = true;
            this.chkb_ISO27001.Location = new System.Drawing.Point(30, 49);
            this.chkb_ISO27001.Name = "chkb_ISO27001";
            this.chkb_ISO27001.Size = new System.Drawing.Size(104, 24);
            this.chkb_ISO27001.TabIndex = 1;
            this.chkb_ISO27001.Text = "ISO27001";
            this.chkb_ISO27001.UseVisualStyleBackColor = true;
            // 
            // chkb_DSPT
            // 
            this.chkb_DSPT.AutoSize = true;
            this.chkb_DSPT.Location = new System.Drawing.Point(30, 24);
            this.chkb_DSPT.Name = "chkb_DSPT";
            this.chkb_DSPT.Size = new System.Drawing.Size(76, 24);
            this.chkb_DSPT.TabIndex = 0;
            this.chkb_DSPT.Text = "DSPT";
            this.chkb_DSPT.UseVisualStyleBackColor = true;
            // 
            // gb_Notes
            // 
            this.gb_Notes.Controls.Add(this.dgv_AddNote);
            this.gb_Notes.Controls.Add(this.btn_AddNote);
            this.gb_Notes.Controls.Add(this.tb_AddNote);
            this.gb_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Notes.Location = new System.Drawing.Point(356, 426);
            this.gb_Notes.Name = "gb_Notes";
            this.gb_Notes.Size = new System.Drawing.Size(636, 242);
            this.gb_Notes.TabIndex = 10;
            this.gb_Notes.TabStop = false;
            this.gb_Notes.Text = "Notes";
            // 
            // dgv_AddNote
            // 
            this.dgv_AddNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AddNote.Location = new System.Drawing.Point(13, 122);
            this.dgv_AddNote.Name = "dgv_AddNote";
            this.dgv_AddNote.RowHeadersWidth = 51;
            this.dgv_AddNote.RowTemplate.Height = 24;
            this.dgv_AddNote.Size = new System.Drawing.Size(609, 108);
            this.dgv_AddNote.TabIndex = 2;
            // 
            // btn_AddNote
            // 
            this.btn_AddNote.Location = new System.Drawing.Point(543, 26);
            this.btn_AddNote.Name = "btn_AddNote";
            this.btn_AddNote.Size = new System.Drawing.Size(79, 76);
            this.btn_AddNote.TabIndex = 1;
            this.btn_AddNote.Text = "Add Note";
            this.btn_AddNote.UseVisualStyleBackColor = true;
            this.btn_AddNote.Click += new System.EventHandler(this.btn_AddNote_Click);
            // 
            // tb_AddNote
            // 
            this.tb_AddNote.Location = new System.Drawing.Point(13, 26);
            this.tb_AddNote.Multiline = true;
            this.tb_AddNote.Name = "tb_AddNote";
            this.tb_AddNote.Size = new System.Drawing.Size(513, 76);
            this.tb_AddNote.TabIndex = 0;
            // 
            // gb_Project
            // 
            this.gb_Project.Controls.Add(this.lbx_ProjectsList);
            this.gb_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Project.Location = new System.Drawing.Point(12, 526);
            this.gb_Project.Name = "gb_Project";
            this.gb_Project.Size = new System.Drawing.Size(322, 142);
            this.gb_Project.TabIndex = 11;
            this.gb_Project.TabStop = false;
            this.gb_Project.Text = "Link With Project(s)";
            // 
            // lbx_ProjectsList
            // 
            this.lbx_ProjectsList.FormattingEnabled = true;
            this.lbx_ProjectsList.ItemHeight = 20;
            this.lbx_ProjectsList.Location = new System.Drawing.Point(10, 27);
            this.lbx_ProjectsList.Name = "lbx_ProjectsList";
            this.lbx_ProjectsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbx_ProjectsList.Size = new System.Drawing.Size(306, 104);
            this.lbx_ProjectsList.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(888, 675);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(103, 34);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(779, 675);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(103, 34);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // gb_Dates
            // 
            this.gb_Dates.Controls.Add(this.dtp_StartDate);
            this.gb_Dates.Controls.Add(this.lbl_StartDate);
            this.gb_Dates.Controls.Add(this.lbl_ExpiryDate);
            this.gb_Dates.Controls.Add(this.dtp_ExpiryDate);
            this.gb_Dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Dates.Location = new System.Drawing.Point(12, 118);
            this.gb_Dates.Name = "gb_Dates";
            this.gb_Dates.Size = new System.Drawing.Size(980, 53);
            this.gb_Dates.TabIndex = 14;
            this.gb_Dates.TabStop = false;
            this.gb_Dates.Text = "Dates";
            // 
            // frm_DsaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 717);
            this.Controls.Add(this.gb_Dates);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gb_Project);
            this.Controls.Add(this.gb_Notes);
            this.Controls.Add(this.gb_GovernanceReq);
            this.Controls.Add(this.gb_AmendmentOf);
            this.Controls.Add(this.gb_DsaFileDetails);
            this.Controls.Add(this.gb_DataOwner);
            this.Name = "frm_DsaAdd";
            this.Text = "Add a New DSA";
            this.gb_DataOwner.ResumeLayout(false);
            this.gb_DsaFileDetails.ResumeLayout(false);
            this.gb_DsaFileDetails.PerformLayout();
            this.gb_AmendmentOf.ResumeLayout(false);
            this.gb_AmendmentOf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentOf)).EndInit();
            this.gb_GovernanceReq.ResumeLayout(false);
            this.gb_GovernanceReq.PerformLayout();
            this.gb_Notes.ResumeLayout(false);
            this.gb_Notes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddNote)).EndInit();
            this.gb_Project.ResumeLayout(false);
            this.gb_Dates.ResumeLayout(false);
            this.gb_Dates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_ExistingDataOwner;
        private System.Windows.Forms.GroupBox gb_DataOwner;
        private System.Windows.Forms.Button btn_NewDataOwner;
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
        private System.Windows.Forms.Label lbl_AmendmentHelp;
        private System.Windows.Forms.DataGridView dgv_AmendmentOf;
        private System.Windows.Forms.GroupBox gb_GovernanceReq;
        private System.Windows.Forms.CheckBox chkb_ISO27001;
        private System.Windows.Forms.CheckBox chkb_DSPT;
        private System.Windows.Forms.GroupBox gb_Notes;
        private System.Windows.Forms.DataGridView dgv_AddNote;
        private System.Windows.Forms.Button btn_AddNote;
        private System.Windows.Forms.TextBox tb_AddNote;
        private System.Windows.Forms.GroupBox gb_Project;
        private System.Windows.Forms.ListBox lbx_ProjectsList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox gb_Dates;
    }
}