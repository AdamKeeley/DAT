namespace CMS.DataTracking
{
    partial class frm_DataTransferAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DataTransferAdd));
            this.gb_Request = new System.Windows.Forms.GroupBox();
            this.cb_Project = new System.Windows.Forms.ComboBox();
            this.lbl_Project = new System.Windows.Forms.Label();
            this.lbl_RequestType = new System.Windows.Forms.Label();
            this.cb_RequestType = new System.Windows.Forms.ComboBox();
            this.lbl_RequestedBy = new System.Windows.Forms.Label();
            this.cb_RequestedBy = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_RequesterNotes = new System.Windows.Forms.Label();
            this.gb_Review = new System.Windows.Forms.GroupBox();
            this.lbl_NewUser = new System.Windows.Forms.Label();
            this.lbl_ReviewedBy = new System.Windows.Forms.Label();
            this.cb_ReviewedBy = new System.Windows.Forms.ComboBox();
            this.dtp_ReviewDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_ReviewDate = new System.Windows.Forms.Label();
            this.lbl_ReviewNotes = new System.Windows.Forms.Label();
            this.tb_ReviewNotes = new System.Windows.Forms.TextBox();
            this.tb_TransferFrom = new System.Windows.Forms.TextBox();
            this.tb_TransferTo = new System.Windows.Forms.TextBox();
            this.lbl_TransferFrom = new System.Windows.Forms.Label();
            this.lbl_TransferTo = new System.Windows.Forms.Label();
            this.gb_Files = new System.Windows.Forms.GroupBox();
            this.gb_Transfer = new System.Windows.Forms.GroupBox();
            this.gb_Assets = new System.Windows.Forms.GroupBox();
            this.gb_Rejections = new System.Windows.Forms.GroupBox();
            this.lbl_DsaReviewed = new System.Windows.Forms.Label();
            this.cb_DsaReviewed = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_TransferMethod = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_NewDSA = new System.Windows.Forms.Label();
            this.dgv_FilesList = new System.Windows.Forms.DataGridView();
            this.btn_AddFiles = new System.Windows.Forms.Button();
            this.btn_AddAsset = new System.Windows.Forms.Button();
            this.dgv_Assets = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_Rejections = new System.Windows.Forms.DataGridView();
            this.lbl_VreFilePath = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_RepoFilePath = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.gb_Request.SuspendLayout();
            this.gb_Review.SuspendLayout();
            this.gb_Files.SuspendLayout();
            this.gb_Transfer.SuspendLayout();
            this.gb_Assets.SuspendLayout();
            this.gb_Rejections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FilesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Assets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rejections)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Request
            // 
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
            // cb_Project
            // 
            this.cb_Project.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Project.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Project.FormattingEnabled = true;
            this.cb_Project.Location = new System.Drawing.Point(145, 31);
            this.cb_Project.Name = "cb_Project";
            this.cb_Project.Size = new System.Drawing.Size(156, 24);
            this.cb_Project.TabIndex = 0;
            // 
            // lbl_Project
            // 
            this.lbl_Project.AutoSize = true;
            this.lbl_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Project.Location = new System.Drawing.Point(33, 34);
            this.lbl_Project.Name = "lbl_Project";
            this.lbl_Project.Size = new System.Drawing.Size(106, 17);
            this.lbl_Project.TabIndex = 1;
            this.lbl_Project.Text = "Project Number";
            // 
            // lbl_RequestType
            // 
            this.lbl_RequestType.AutoSize = true;
            this.lbl_RequestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequestType.Location = new System.Drawing.Point(42, 62);
            this.lbl_RequestType.Name = "lbl_RequestType";
            this.lbl_RequestType.Size = new System.Drawing.Size(97, 17);
            this.lbl_RequestType.TabIndex = 3;
            this.lbl_RequestType.Text = "Request Type";
            // 
            // cb_RequestType
            // 
            this.cb_RequestType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_RequestType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_RequestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_RequestType.FormattingEnabled = true;
            this.cb_RequestType.Location = new System.Drawing.Point(145, 60);
            this.cb_RequestType.Name = "cb_RequestType";
            this.cb_RequestType.Size = new System.Drawing.Size(156, 24);
            this.cb_RequestType.TabIndex = 2;
            // 
            // lbl_RequestedBy
            // 
            this.lbl_RequestedBy.AutoSize = true;
            this.lbl_RequestedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequestedBy.Location = new System.Drawing.Point(42, 91);
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
            this.cb_RequestedBy.Location = new System.Drawing.Point(145, 89);
            this.cb_RequestedBy.Name = "cb_RequestedBy";
            this.cb_RequestedBy.Size = new System.Drawing.Size(156, 24);
            this.cb_RequestedBy.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.AllowDrop = true;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 120);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 80);
            this.textBox1.TabIndex = 6;
            // 
            // lbl_RequesterNotes
            // 
            this.lbl_RequesterNotes.AutoSize = true;
            this.lbl_RequesterNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RequesterNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_RequesterNotes.Location = new System.Drawing.Point(55, 120);
            this.lbl_RequesterNotes.Name = "lbl_RequesterNotes";
            this.lbl_RequesterNotes.Size = new System.Drawing.Size(84, 34);
            this.lbl_RequesterNotes.TabIndex = 7;
            this.lbl_RequesterNotes.Text = "Requester\'s\r\nNote";
            this.lbl_RequesterNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_Review
            // 
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
            // lbl_NewUser
            // 
            this.lbl_NewUser.AutoSize = true;
            this.lbl_NewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewUser.Location = new System.Drawing.Point(307, 92);
            this.lbl_NewUser.Name = "lbl_NewUser";
            this.lbl_NewUser.Size = new System.Drawing.Size(77, 17);
            this.lbl_NewUser.TabIndex = 8;
            this.lbl_NewUser.Text = "new user...";
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
            // gb_Transfer
            // 
            this.gb_Transfer.Controls.Add(this.lbl_RepoFilePath);
            this.gb_Transfer.Controls.Add(this.textBox3);
            this.gb_Transfer.Controls.Add(this.lbl_VreFilePath);
            this.gb_Transfer.Controls.Add(this.textBox2);
            this.gb_Transfer.Controls.Add(this.lbl_TransferMethod);
            this.gb_Transfer.Controls.Add(this.comboBox1);
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
            // gb_Assets
            // 
            this.gb_Assets.Controls.Add(this.btn_AddAsset);
            this.gb_Assets.Controls.Add(this.dgv_Assets);
            this.gb_Assets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Assets.Location = new System.Drawing.Point(544, 348);
            this.gb_Assets.Name = "gb_Assets";
            this.gb_Assets.Size = new System.Drawing.Size(512, 180);
            this.gb_Assets.TabIndex = 3;
            this.gb_Assets.TabStop = false;
            this.gb_Assets.Text = "Assets";
            // 
            // gb_Rejections
            // 
            this.gb_Rejections.Controls.Add(this.button2);
            this.gb_Rejections.Controls.Add(this.dgv_Rejections);
            this.gb_Rejections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Rejections.Location = new System.Drawing.Point(544, 534);
            this.gb_Rejections.Name = "gb_Rejections";
            this.gb_Rejections.Size = new System.Drawing.Size(512, 180);
            this.gb_Rejections.TabIndex = 4;
            this.gb_Rejections.TabStop = false;
            this.gb_Rejections.Text = "Rejections";
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
            // cb_DsaReviewed
            // 
            this.cb_DsaReviewed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_DsaReviewed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_DsaReviewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_DsaReviewed.FormattingEnabled = true;
            this.cb_DsaReviewed.Location = new System.Drawing.Point(129, 176);
            this.cb_DsaReviewed.Name = "cb_DsaReviewed";
            this.cb_DsaReviewed.Size = new System.Drawing.Size(362, 24);
            this.cb_DsaReviewed.TabIndex = 13;
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
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(513, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 24);
            this.comboBox1.TabIndex = 15;
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
            // 
            // dgv_FilesList
            // 
            this.dgv_FilesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FilesList.Location = new System.Drawing.Point(11, 60);
            this.dgv_FilesList.Name = "dgv_FilesList";
            this.dgv_FilesList.RowHeadersWidth = 51;
            this.dgv_FilesList.RowTemplate.Height = 24;
            this.dgv_FilesList.Size = new System.Drawing.Size(481, 340);
            this.dgv_FilesList.TabIndex = 0;
            // 
            // btn_AddFiles
            // 
            this.btn_AddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFiles.Location = new System.Drawing.Point(145, 21);
            this.btn_AddFiles.Name = "btn_AddFiles";
            this.btn_AddFiles.Size = new System.Drawing.Size(192, 32);
            this.btn_AddFiles.TabIndex = 1;
            this.btn_AddFiles.Text = "Add Files To List";
            this.btn_AddFiles.UseVisualStyleBackColor = true;
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
            // 
            // dgv_Assets
            // 
            this.dgv_Assets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Assets.Location = new System.Drawing.Point(10, 52);
            this.dgv_Assets.Name = "dgv_Assets";
            this.dgv_Assets.RowHeadersWidth = 51;
            this.dgv_Assets.RowTemplate.Height = 24;
            this.dgv_Assets.Size = new System.Drawing.Size(489, 119);
            this.dgv_Assets.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(152, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reject Files";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dgv_Rejections
            // 
            this.dgv_Rejections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rejections.Location = new System.Drawing.Point(10, 52);
            this.dgv_Rejections.Name = "dgv_Rejections";
            this.dgv_Rejections.RowHeadersWidth = 51;
            this.dgv_Rejections.RowTemplate.Height = 24;
            this.dgv_Rejections.Size = new System.Drawing.Size(489, 119);
            this.dgv_Rejections.TabIndex = 4;
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
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(157, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 22);
            this.textBox2.TabIndex = 17;
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
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(633, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(344, 22);
            this.textBox3.TabIndex = 19;
            // 
            // frm_DataTransferAdd
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
            this.Name = "frm_DataTransferAdd";
            this.Text = "Add File Transfer Record";
            this.gb_Request.ResumeLayout(false);
            this.gb_Request.PerformLayout();
            this.gb_Review.ResumeLayout(false);
            this.gb_Review.PerformLayout();
            this.gb_Files.ResumeLayout(false);
            this.gb_Transfer.ResumeLayout(false);
            this.gb_Transfer.PerformLayout();
            this.gb_Assets.ResumeLayout(false);
            this.gb_Rejections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FilesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Assets)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gb_Assets;
        private System.Windows.Forms.GroupBox gb_Rejections;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_AddFiles;
        private System.Windows.Forms.DataGridView dgv_FilesList;
        private System.Windows.Forms.Button btn_AddAsset;
        private System.Windows.Forms.DataGridView dgv_Assets;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv_Rejections;
        private System.Windows.Forms.Label lbl_RepoFilePath;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbl_VreFilePath;
        private System.Windows.Forms.TextBox textBox2;
    }
}