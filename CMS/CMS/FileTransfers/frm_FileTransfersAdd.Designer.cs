namespace CMS.FileTransfers
{
    partial class frm_FileTransfersAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FileTransfersAdd));
            this.gb_Request = new System.Windows.Forms.GroupBox();
            this.lbl_NewUser = new System.Windows.Forms.Label();
            this.lbl_RequesterNotes = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_RequestedBy = new System.Windows.Forms.Label();
            this.cb_RequestedBy = new System.Windows.Forms.ComboBox();
            this.lbl_RequestType = new System.Windows.Forms.Label();
            this.cb_RequestType = new System.Windows.Forms.ComboBox();
            this.lbl_Project = new System.Windows.Forms.Label();
            this.cb_Project = new System.Windows.Forms.ComboBox();
            this.gb_Review = new System.Windows.Forms.GroupBox();
            this.chkb_OldDSAs = new System.Windows.Forms.CheckBox();
            this.lbl_NewDSA = new System.Windows.Forms.Label();
            this.lbl_DsaReviewed = new System.Windows.Forms.Label();
            this.lbl_ReviewNotes = new System.Windows.Forms.Label();
            this.cb_DsaReviewed = new System.Windows.Forms.ComboBox();
            this.tb_ReviewNotes = new System.Windows.Forms.TextBox();
            this.lbl_ReviewDate = new System.Windows.Forms.Label();
            this.dtp_ReviewDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_ReviewedBy = new System.Windows.Forms.Label();
            this.cb_ReviewedBy = new System.Windows.Forms.ComboBox();
            this.tb_TransferFrom = new System.Windows.Forms.TextBox();
            this.tb_TransferTo = new System.Windows.Forms.TextBox();
            this.lbl_TransferFrom = new System.Windows.Forms.Label();
            this.lbl_TransferTo = new System.Windows.Forms.Label();
            this.gb_Files = new System.Windows.Forms.GroupBox();
            this.btn_AddFiles = new System.Windows.Forms.Button();
            this.dgv_FilesList = new System.Windows.Forms.DataGridView();
            this.gb_Transfer = new System.Windows.Forms.GroupBox();
            this.lbl_RepoFilePath = new System.Windows.Forms.Label();
            this.tb_RepoDir = new System.Windows.Forms.TextBox();
            this.lbl_VreFilePath = new System.Windows.Forms.Label();
            this.tb_VreDir = new System.Windows.Forms.TextBox();
            this.lbl_TransferMethod = new System.Windows.Forms.Label();
            this.cb_TransferMethod = new System.Windows.Forms.ComboBox();
            this.gb_Assets = new System.Windows.Forms.GroupBox();
            this.btn_AddAsset = new System.Windows.Forms.Button();
            this.dgv_Assets = new System.Windows.Forms.DataGridView();
            this.gb_Rejections = new System.Windows.Forms.GroupBox();
            this.btn_Rejections = new System.Windows.Forms.Button();
            this.dgv_Rejections = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_VRE = new System.Windows.Forms.Label();
            this.cb_VRE = new System.Windows.Forms.ComboBox();
            this.lbl_NumFiles = new System.Windows.Forms.Label();
            this.gb_Request.SuspendLayout();
            this.gb_Review.SuspendLayout();
            this.gb_Files.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FilesList)).BeginInit();
            this.gb_Transfer.SuspendLayout();
            this.gb_Assets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Assets)).BeginInit();
            this.gb_Rejections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rejections)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Request
            // 
            this.gb_Request.Controls.Add(this.lbl_VRE);
            this.gb_Request.Controls.Add(this.cb_VRE);
            this.gb_Request.Controls.Add(this.lbl_NewUser);
            this.gb_Request.Controls.Add(this.lbl_RequesterNotes);
            this.gb_Request.Controls.Add(this.textBox1);
            this.gb_Request.Controls.Add(this.lbl_RequestedBy);
            this.gb_Request.Controls.Add(this.cb_RequestedBy);
            this.gb_Request.Controls.Add(this.lbl_RequestType);
            this.gb_Request.Controls.Add(this.cb_RequestType);
            this.gb_Request.Controls.Add(this.lbl_Project);
            this.gb_Request.Controls.Add(this.cb_Project);
            this.gb_Request.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Request.Location = new System.Drawing.Point(12, 12);
            this.gb_Request.Name = "gb_Request";
            this.gb_Request.Size = new System.Drawing.Size(512, 232);
            this.gb_Request.TabIndex = 0;
            this.gb_Request.TabStop = false;
            this.gb_Request.Text = "Request";
            // 
            // lbl_NewUser
            // 
            this.lbl_NewUser.AutoSize = true;
            this.lbl_NewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewUser.Location = new System.Drawing.Point(307, 116);
            this.lbl_NewUser.Name = "lbl_NewUser";
            this.lbl_NewUser.Size = new System.Drawing.Size(77, 17);
            this.lbl_NewUser.TabIndex = 8;
            this.lbl_NewUser.Text = "new user...";
            this.lbl_NewUser.Click += new System.EventHandler(this.lbl_NewUser_Click);
            // 
            // lbl_RequesterNotes
            // 
            this.lbl_RequesterNotes.AutoSize = true;
            this.lbl_RequesterNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequesterNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_RequesterNotes.Location = new System.Drawing.Point(55, 144);
            this.lbl_RequesterNotes.Name = "lbl_RequesterNotes";
            this.lbl_RequesterNotes.Size = new System.Drawing.Size(84, 34);
            this.lbl_RequesterNotes.TabIndex = 7;
            this.lbl_RequesterNotes.Text = "Requester\'s\r\nNote";
            this.lbl_RequesterNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.AllowDrop = true;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 144);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 80);
            this.textBox1.TabIndex = 6;
            // 
            // lbl_RequestedBy
            // 
            this.lbl_RequestedBy.AutoSize = true;
            this.lbl_RequestedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequestedBy.Location = new System.Drawing.Point(42, 115);
            this.lbl_RequestedBy.Name = "lbl_RequestedBy";
            this.lbl_RequestedBy.Size = new System.Drawing.Size(97, 17);
            this.lbl_RequestedBy.TabIndex = 5;
            this.lbl_RequestedBy.Text = "Requested By";
            // 
            // cb_RequestedBy
            // 
            this.cb_RequestedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_RequestedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_RequestedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_RequestedBy.FormattingEnabled = true;
            this.cb_RequestedBy.Location = new System.Drawing.Point(145, 113);
            this.cb_RequestedBy.Name = "cb_RequestedBy";
            this.cb_RequestedBy.Size = new System.Drawing.Size(156, 24);
            this.cb_RequestedBy.TabIndex = 4;
            // 
            // lbl_RequestType
            // 
            this.lbl_RequestType.AutoSize = true;
            this.lbl_RequestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequestType.Location = new System.Drawing.Point(42, 86);
            this.lbl_RequestType.Name = "lbl_RequestType";
            this.lbl_RequestType.Size = new System.Drawing.Size(97, 17);
            this.lbl_RequestType.TabIndex = 3;
            this.lbl_RequestType.Text = "Request Type";
            // 
            // cb_RequestType
            // 
            this.cb_RequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_RequestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_RequestType.FormattingEnabled = true;
            this.cb_RequestType.Location = new System.Drawing.Point(145, 84);
            this.cb_RequestType.Name = "cb_RequestType";
            this.cb_RequestType.Size = new System.Drawing.Size(156, 24);
            this.cb_RequestType.TabIndex = 2;
            this.cb_RequestType.SelectedValueChanged += new System.EventHandler(this.cb_RequestType_SelectedValueChanged);
            // 
            // lbl_Project
            // 
            this.lbl_Project.AutoSize = true;
            this.lbl_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Project.Location = new System.Drawing.Point(33, 27);
            this.lbl_Project.Name = "lbl_Project";
            this.lbl_Project.Size = new System.Drawing.Size(106, 17);
            this.lbl_Project.TabIndex = 1;
            this.lbl_Project.Text = "Project Number";
            // 
            // cb_Project
            // 
            this.cb_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Project.FormattingEnabled = true;
            this.cb_Project.Location = new System.Drawing.Point(145, 24);
            this.cb_Project.Name = "cb_Project";
            this.cb_Project.Size = new System.Drawing.Size(156, 24);
            this.cb_Project.TabIndex = 0;
            this.cb_Project.SelectedValueChanged += new System.EventHandler(this.cb_Project_SelectedValueChanged);
            // 
            // gb_Review
            // 
            this.gb_Review.Controls.Add(this.chkb_OldDSAs);
            this.gb_Review.Controls.Add(this.lbl_NewDSA);
            this.gb_Review.Controls.Add(this.lbl_DsaReviewed);
            this.gb_Review.Controls.Add(this.lbl_ReviewNotes);
            this.gb_Review.Controls.Add(this.cb_DsaReviewed);
            this.gb_Review.Controls.Add(this.tb_ReviewNotes);
            this.gb_Review.Controls.Add(this.lbl_ReviewDate);
            this.gb_Review.Controls.Add(this.dtp_ReviewDate);
            this.gb_Review.Controls.Add(this.lbl_ReviewedBy);
            this.gb_Review.Controls.Add(this.cb_ReviewedBy);
            this.gb_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Review.Location = new System.Drawing.Point(544, 12);
            this.gb_Review.Name = "gb_Review";
            this.gb_Review.Size = new System.Drawing.Size(512, 232);
            this.gb_Review.TabIndex = 1;
            this.gb_Review.TabStop = false;
            this.gb_Review.Text = "Review";
            // 
            // chkb_OldDSAs
            // 
            this.chkb_OldDSAs.AutoSize = true;
            this.chkb_OldDSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_OldDSAs.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkb_OldDSAs.Location = new System.Drawing.Point(342, 202);
            this.chkb_OldDSAs.Name = "chkb_OldDSAs";
            this.chkb_OldDSAs.Size = new System.Drawing.Size(149, 21);
            this.chkb_OldDSAs.TabIndex = 15;
            this.chkb_OldDSAs.Text = "Exclude old DSAs?";
            this.chkb_OldDSAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkb_OldDSAs.UseVisualStyleBackColor = true;
            this.chkb_OldDSAs.CheckedChanged += new System.EventHandler(this.chkb_OldDSAs_CheckedChanged);
            // 
            // lbl_NewDSA
            // 
            this.lbl_NewDSA.AutoSize = true;
            this.lbl_NewDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewDSA.Location = new System.Drawing.Point(126, 202);
            this.lbl_NewDSA.Name = "lbl_NewDSA";
            this.lbl_NewDSA.Size = new System.Drawing.Size(77, 17);
            this.lbl_NewDSA.TabIndex = 9;
            this.lbl_NewDSA.Text = "new DSA...";
            this.lbl_NewDSA.Click += new System.EventHandler(this.lbl_NewDSA_Click);
            // 
            // lbl_DsaReviewed
            // 
            this.lbl_DsaReviewed.AutoSize = true;
            this.lbl_DsaReviewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DsaReviewed.Location = new System.Drawing.Point(23, 179);
            this.lbl_DsaReviewed.Name = "lbl_DsaReviewed";
            this.lbl_DsaReviewed.Size = new System.Drawing.Size(101, 17);
            this.lbl_DsaReviewed.TabIndex = 14;
            this.lbl_DsaReviewed.Text = "DSA Reviewed";
            // 
            // lbl_ReviewNotes
            // 
            this.lbl_ReviewNotes.AutoSize = true;
            this.lbl_ReviewNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReviewNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ReviewNotes.Location = new System.Drawing.Point(49, 89);
            this.lbl_ReviewNotes.Name = "lbl_ReviewNotes";
            this.lbl_ReviewNotes.Size = new System.Drawing.Size(76, 34);
            this.lbl_ReviewNotes.TabIndex = 14;
            this.lbl_ReviewNotes.Text = "Reviewer\'s\r\nNote";
            this.lbl_ReviewNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_DsaReviewed
            // 
            this.cb_DsaReviewed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DsaReviewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_DsaReviewed.FormattingEnabled = true;
            this.cb_DsaReviewed.Location = new System.Drawing.Point(129, 176);
            this.cb_DsaReviewed.Name = "cb_DsaReviewed";
            this.cb_DsaReviewed.Size = new System.Drawing.Size(362, 24);
            this.cb_DsaReviewed.TabIndex = 13;
            // 
            // tb_ReviewNotes
            // 
            this.tb_ReviewNotes.AcceptsReturn = true;
            this.tb_ReviewNotes.AcceptsTab = true;
            this.tb_ReviewNotes.AllowDrop = true;
            this.tb_ReviewNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ReviewNotes.Location = new System.Drawing.Point(129, 89);
            this.tb_ReviewNotes.Multiline = true;
            this.tb_ReviewNotes.Name = "tb_ReviewNotes";
            this.tb_ReviewNotes.Size = new System.Drawing.Size(362, 80);
            this.tb_ReviewNotes.TabIndex = 13;
            // 
            // lbl_ReviewDate
            // 
            this.lbl_ReviewDate.AutoSize = true;
            this.lbl_ReviewDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReviewDate.Location = new System.Drawing.Point(21, 62);
            this.lbl_ReviewDate.Name = "lbl_ReviewDate";
            this.lbl_ReviewDate.Size = new System.Drawing.Size(103, 17);
            this.lbl_ReviewDate.TabIndex = 12;
            this.lbl_ReviewDate.Text = "Date Reviewed";
            // 
            // dtp_ReviewDate
            // 
            this.dtp_ReviewDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ReviewDate.Location = new System.Drawing.Point(129, 61);
            this.dtp_ReviewDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_ReviewDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_ReviewDate.Name = "dtp_ReviewDate";
            this.dtp_ReviewDate.Size = new System.Drawing.Size(156, 22);
            this.dtp_ReviewDate.TabIndex = 11;
            this.dtp_ReviewDate.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // lbl_ReviewedBy
            // 
            this.lbl_ReviewedBy.AutoSize = true;
            this.lbl_ReviewedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReviewedBy.Location = new System.Drawing.Point(34, 34);
            this.lbl_ReviewedBy.Name = "lbl_ReviewedBy";
            this.lbl_ReviewedBy.Size = new System.Drawing.Size(89, 17);
            this.lbl_ReviewedBy.TabIndex = 10;
            this.lbl_ReviewedBy.Text = "Reviewed By";
            // 
            // cb_ReviewedBy
            // 
            this.cb_ReviewedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_ReviewedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ReviewedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ReviewedBy.FormattingEnabled = true;
            this.cb_ReviewedBy.Location = new System.Drawing.Point(129, 32);
            this.cb_ReviewedBy.Name = "cb_ReviewedBy";
            this.cb_ReviewedBy.Size = new System.Drawing.Size(156, 24);
            this.cb_ReviewedBy.TabIndex = 9;
            // 
            // tb_TransferFrom
            // 
            this.tb_TransferFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TransferFrom.Location = new System.Drawing.Point(110, 28);
            this.tb_TransferFrom.Name = "tb_TransferFrom";
            this.tb_TransferFrom.Size = new System.Drawing.Size(271, 22);
            this.tb_TransferFrom.TabIndex = 9;
            // 
            // tb_TransferTo
            // 
            this.tb_TransferTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TransferTo.Location = new System.Drawing.Point(760, 28);
            this.tb_TransferTo.Name = "tb_TransferTo";
            this.tb_TransferTo.Size = new System.Drawing.Size(271, 22);
            this.tb_TransferTo.TabIndex = 10;
            // 
            // lbl_TransferFrom
            // 
            this.lbl_TransferFrom.AutoSize = true;
            this.lbl_TransferFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TransferFrom.Location = new System.Drawing.Point(8, 31);
            this.lbl_TransferFrom.Name = "lbl_TransferFrom";
            this.lbl_TransferFrom.Size = new System.Drawing.Size(98, 17);
            this.lbl_TransferFrom.TabIndex = 11;
            this.lbl_TransferFrom.Text = "Transfer From";
            // 
            // lbl_TransferTo
            // 
            this.lbl_TransferTo.AutoSize = true;
            this.lbl_TransferTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TransferTo.Location = new System.Drawing.Point(673, 31);
            this.lbl_TransferTo.Name = "lbl_TransferTo";
            this.lbl_TransferTo.Size = new System.Drawing.Size(83, 17);
            this.lbl_TransferTo.TabIndex = 12;
            this.lbl_TransferTo.Text = "Transfer To";
            // 
            // gb_Files
            // 
            this.gb_Files.Controls.Add(this.lbl_NumFiles);
            this.gb_Files.Controls.Add(this.btn_AddFiles);
            this.gb_Files.Controls.Add(this.dgv_FilesList);
            this.gb_Files.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Files.Location = new System.Drawing.Point(12, 348);
            this.gb_Files.Name = "gb_Files";
            this.gb_Files.Size = new System.Drawing.Size(512, 411);
            this.gb_Files.TabIndex = 2;
            this.gb_Files.TabStop = false;
            this.gb_Files.Text = "Files";
            // 
            // btn_AddFiles
            // 
            this.btn_AddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFiles.Location = new System.Drawing.Point(58, 22);
            this.btn_AddFiles.Name = "btn_AddFiles";
            this.btn_AddFiles.Size = new System.Drawing.Size(192, 32);
            this.btn_AddFiles.TabIndex = 1;
            this.btn_AddFiles.Text = "Add Files To List";
            this.btn_AddFiles.UseVisualStyleBackColor = true;
            this.btn_AddFiles.Click += new System.EventHandler(this.btn_AddFiles_Click);
            // 
            // dgv_FilesList
            // 
            this.dgv_FilesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FilesList.Location = new System.Drawing.Point(11, 60);
            this.dgv_FilesList.Name = "dgv_FilesList";
            this.dgv_FilesList.RowHeadersWidth = 51;
            this.dgv_FilesList.RowTemplate.Height = 24;
            this.dgv_FilesList.Size = new System.Drawing.Size(490, 340);
            this.dgv_FilesList.TabIndex = 0;
            // 
            // gb_Transfer
            // 
            this.gb_Transfer.Controls.Add(this.lbl_RepoFilePath);
            this.gb_Transfer.Controls.Add(this.tb_RepoDir);
            this.gb_Transfer.Controls.Add(this.lbl_VreFilePath);
            this.gb_Transfer.Controls.Add(this.tb_VreDir);
            this.gb_Transfer.Controls.Add(this.lbl_TransferMethod);
            this.gb_Transfer.Controls.Add(this.cb_TransferMethod);
            this.gb_Transfer.Controls.Add(this.lbl_TransferTo);
            this.gb_Transfer.Controls.Add(this.lbl_TransferFrom);
            this.gb_Transfer.Controls.Add(this.tb_TransferFrom);
            this.gb_Transfer.Controls.Add(this.tb_TransferTo);
            this.gb_Transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Transfer.Location = new System.Drawing.Point(12, 250);
            this.gb_Transfer.Name = "gb_Transfer";
            this.gb_Transfer.Size = new System.Drawing.Size(1044, 92);
            this.gb_Transfer.TabIndex = 3;
            this.gb_Transfer.TabStop = false;
            this.gb_Transfer.Text = "Transfer";
            // 
            // lbl_RepoFilePath
            // 
            this.lbl_RepoFilePath.AutoSize = true;
            this.lbl_RepoFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RepoFilePath.Location = new System.Drawing.Point(531, 62);
            this.lbl_RepoFilePath.Name = "lbl_RepoFilePath";
            this.lbl_RepoFilePath.Size = new System.Drawing.Size(101, 17);
            this.lbl_RepoFilePath.TabIndex = 20;
            this.lbl_RepoFilePath.Text = "Repo File Path";
            // 
            // tb_RepoDir
            // 
            this.tb_RepoDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RepoDir.Location = new System.Drawing.Point(633, 59);
            this.tb_RepoDir.Name = "tb_RepoDir";
            this.tb_RepoDir.Size = new System.Drawing.Size(344, 22);
            this.tb_RepoDir.TabIndex = 19;
            // 
            // lbl_VreFilePath
            // 
            this.lbl_VreFilePath.AutoSize = true;
            this.lbl_VreFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VreFilePath.Location = new System.Drawing.Point(55, 62);
            this.lbl_VreFilePath.Name = "lbl_VreFilePath";
            this.lbl_VreFilePath.Size = new System.Drawing.Size(95, 17);
            this.lbl_VreFilePath.TabIndex = 18;
            this.lbl_VreFilePath.Text = "VRE File Path";
            // 
            // tb_VreDir
            // 
            this.tb_VreDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_VreDir.Location = new System.Drawing.Point(157, 59);
            this.tb_VreDir.Name = "tb_VreDir";
            this.tb_VreDir.Size = new System.Drawing.Size(344, 22);
            this.tb_VreDir.TabIndex = 17;
            // 
            // lbl_TransferMethod
            // 
            this.lbl_TransferMethod.AutoSize = true;
            this.lbl_TransferMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TransferMethod.Location = new System.Drawing.Point(396, 31);
            this.lbl_TransferMethod.Name = "lbl_TransferMethod";
            this.lbl_TransferMethod.Size = new System.Drawing.Size(113, 17);
            this.lbl_TransferMethod.TabIndex = 16;
            this.lbl_TransferMethod.Text = "Transfer Method";
            // 
            // cb_TransferMethod
            // 
            this.cb_TransferMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TransferMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_TransferMethod.FormattingEnabled = true;
            this.cb_TransferMethod.Location = new System.Drawing.Point(513, 28);
            this.cb_TransferMethod.Name = "cb_TransferMethod";
            this.cb_TransferMethod.Size = new System.Drawing.Size(138, 24);
            this.cb_TransferMethod.TabIndex = 15;
            // 
            // gb_Assets
            // 
            this.gb_Assets.Controls.Add(this.btn_AddAsset);
            this.gb_Assets.Controls.Add(this.dgv_Assets);
            this.gb_Assets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Assets.Location = new System.Drawing.Point(544, 348);
            this.gb_Assets.Name = "gb_Assets";
            this.gb_Assets.Size = new System.Drawing.Size(512, 203);
            this.gb_Assets.TabIndex = 3;
            this.gb_Assets.TabStop = false;
            this.gb_Assets.Text = "Assets";
            // 
            // btn_AddAsset
            // 
            this.btn_AddAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAsset.Location = new System.Drawing.Point(127, 16);
            this.btn_AddAsset.Name = "btn_AddAsset";
            this.btn_AddAsset.Size = new System.Drawing.Size(245, 32);
            this.btn_AddAsset.TabIndex = 3;
            this.btn_AddAsset.Text = "Assign Files To Asset Group";
            this.btn_AddAsset.UseVisualStyleBackColor = true;
            this.btn_AddAsset.Click += new System.EventHandler(this.btn_AddAsset_Click);
            // 
            // dgv_Assets
            // 
            this.dgv_Assets.AllowUserToAddRows = false;
            this.dgv_Assets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Assets.Location = new System.Drawing.Point(10, 52);
            this.dgv_Assets.Name = "dgv_Assets";
            this.dgv_Assets.RowHeadersWidth = 51;
            this.dgv_Assets.RowTemplate.Height = 24;
            this.dgv_Assets.Size = new System.Drawing.Size(489, 145);
            this.dgv_Assets.TabIndex = 2;
            // 
            // gb_Rejections
            // 
            this.gb_Rejections.Controls.Add(this.btn_Rejections);
            this.gb_Rejections.Controls.Add(this.dgv_Rejections);
            this.gb_Rejections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Rejections.Location = new System.Drawing.Point(544, 557);
            this.gb_Rejections.Name = "gb_Rejections";
            this.gb_Rejections.Size = new System.Drawing.Size(512, 157);
            this.gb_Rejections.TabIndex = 4;
            this.gb_Rejections.TabStop = false;
            this.gb_Rejections.Text = "Rejections";
            // 
            // btn_Rejections
            // 
            this.btn_Rejections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Rejections.Location = new System.Drawing.Point(152, 16);
            this.btn_Rejections.Name = "btn_Rejections";
            this.btn_Rejections.Size = new System.Drawing.Size(192, 32);
            this.btn_Rejections.TabIndex = 5;
            this.btn_Rejections.Text = "Reject Files";
            this.btn_Rejections.UseVisualStyleBackColor = true;
            this.btn_Rejections.Click += new System.EventHandler(this.btn_Rejections_Click);
            // 
            // dgv_Rejections
            // 
            this.dgv_Rejections.AllowUserToAddRows = false;
            this.dgv_Rejections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rejections.Location = new System.Drawing.Point(10, 52);
            this.dgv_Rejections.Name = "dgv_Rejections";
            this.dgv_Rejections.RowHeadersWidth = 51;
            this.dgv_Rejections.RowTemplate.Height = 24;
            this.dgv_Rejections.Size = new System.Drawing.Size(489, 97);
            this.dgv_Rejections.TabIndex = 4;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(937, 720);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(119, 39);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(797, 720);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(119, 39);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_VRE
            // 
            this.lbl_VRE.AutoSize = true;
            this.lbl_VRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VRE.Location = new System.Drawing.Point(49, 57);
            this.lbl_VRE.Name = "lbl_VRE";
            this.lbl_VRE.Size = new System.Drawing.Size(90, 17);
            this.lbl_VRE.TabIndex = 10;
            this.lbl_VRE.Text = "VRE Number";
            // 
            // cb_VRE
            // 
            this.cb_VRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_VRE.FormattingEnabled = true;
            this.cb_VRE.Location = new System.Drawing.Point(145, 54);
            this.cb_VRE.Name = "cb_VRE";
            this.cb_VRE.Size = new System.Drawing.Size(156, 24);
            this.cb_VRE.TabIndex = 9;
            // 
            // lbl_NumFiles
            // 
            this.lbl_NumFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_NumFiles.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_NumFiles.Location = new System.Drawing.Point(256, 16);
            this.lbl_NumFiles.Name = "lbl_NumFiles";
            this.lbl_NumFiles.Size = new System.Drawing.Size(245, 38);
            this.lbl_NumFiles.TabIndex = 2;
            this.lbl_NumFiles.Text = "0 files";
            this.lbl_NumFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_FileTransfersAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 769);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gb_Rejections);
            this.Controls.Add(this.gb_Assets);
            this.Controls.Add(this.gb_Transfer);
            this.Controls.Add(this.gb_Files);
            this.Controls.Add(this.gb_Review);
            this.Controls.Add(this.gb_Request);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FileTransfersAdd";
            this.Text = "Add File Transfer Record";
            this.gb_Request.ResumeLayout(false);
            this.gb_Request.PerformLayout();
            this.gb_Review.ResumeLayout(false);
            this.gb_Review.PerformLayout();
            this.gb_Files.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FilesList)).EndInit();
            this.gb_Transfer.ResumeLayout(false);
            this.gb_Transfer.PerformLayout();
            this.gb_Assets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Assets)).EndInit();
            this.gb_Rejections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rejections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Request;
        private System.Windows.Forms.ComboBox cb_Project;
        private System.Windows.Forms.Label lbl_RequestType;
        private System.Windows.Forms.ComboBox cb_RequestType;
        private System.Windows.Forms.Label lbl_Project;
        private System.Windows.Forms.Label lbl_RequestedBy;
        private System.Windows.Forms.ComboBox cb_RequestedBy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_RequesterNotes;
        private System.Windows.Forms.GroupBox gb_Review;
        private System.Windows.Forms.Label lbl_NewUser;
        private System.Windows.Forms.DateTimePicker dtp_ReviewDate;
        private System.Windows.Forms.Label lbl_ReviewedBy;
        private System.Windows.Forms.ComboBox cb_ReviewedBy;
        private System.Windows.Forms.Label lbl_NewDSA;
        private System.Windows.Forms.Label lbl_DsaReviewed;
        private System.Windows.Forms.Label lbl_ReviewNotes;
        private System.Windows.Forms.ComboBox cb_DsaReviewed;
        private System.Windows.Forms.TextBox tb_ReviewNotes;
        private System.Windows.Forms.Label lbl_ReviewDate;
        private System.Windows.Forms.TextBox tb_TransferFrom;
        private System.Windows.Forms.TextBox tb_TransferTo;
        private System.Windows.Forms.Label lbl_TransferFrom;
        private System.Windows.Forms.Label lbl_TransferTo;
        private System.Windows.Forms.GroupBox gb_Files;
        private System.Windows.Forms.GroupBox gb_Transfer;
        private System.Windows.Forms.Label lbl_TransferMethod;
        private System.Windows.Forms.ComboBox cb_TransferMethod;
        private System.Windows.Forms.GroupBox gb_Assets;
        private System.Windows.Forms.GroupBox gb_Rejections;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_AddFiles;
        private System.Windows.Forms.DataGridView dgv_FilesList;
        private System.Windows.Forms.Button btn_AddAsset;
        private System.Windows.Forms.DataGridView dgv_Assets;
        private System.Windows.Forms.Button btn_Rejections;
        private System.Windows.Forms.DataGridView dgv_Rejections;
        private System.Windows.Forms.Label lbl_RepoFilePath;
        private System.Windows.Forms.TextBox tb_RepoDir;
        private System.Windows.Forms.Label lbl_VreFilePath;
        private System.Windows.Forms.TextBox tb_VreDir;
        private System.Windows.Forms.CheckBox chkb_OldDSAs;
        private System.Windows.Forms.Label lbl_VRE;
        private System.Windows.Forms.ComboBox cb_VRE;
        private System.Windows.Forms.Label lbl_NumFiles;
    }
}