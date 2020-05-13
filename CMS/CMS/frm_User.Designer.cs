namespace CMS
{
    partial class frm_User
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
            this.cb_UserStatus = new System.Windows.Forms.ComboBox();
            this.lbl_UserStatus = new System.Windows.Forms.Label();
            this.cb_UserTitle = new System.Windows.Forms.ComboBox();
            this.lbl_UserTitle = new System.Windows.Forms.Label();
            this.tb_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.tb_LastName = new System.Windows.Forms.TextBox();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tb_Phone = new System.Windows.Forms.TextBox();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.tb_Organisation = new System.Windows.Forms.TextBox();
            this.lbl_Organisation = new System.Windows.Forms.Label();
            this.mtb_UserStartDate = new System.Windows.Forms.MaskedTextBox();
            this.mtb_UserEndDate = new System.Windows.Forms.MaskedTextBox();
            this.lbl_EndDate = new System.Windows.Forms.Label();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.mtb_IRCAgreement = new System.Windows.Forms.MaskedTextBox();
            this.mtb_ISET = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ISET = new System.Windows.Forms.Label();
            this.lbl_IRCAgreement = new System.Windows.Forms.Label();
            this.mtb_ISAT = new System.Windows.Forms.MaskedTextBox();
            this.mtb_SAFE = new System.Windows.Forms.MaskedTextBox();
            this.lbl_SAFE = new System.Windows.Forms.Label();
            this.lbl_ISAT = new System.Windows.Forms.Label();
            this.lbl_TokenSerial = new System.Windows.Forms.Label();
            this.mtb_TokenIssued = new System.Windows.Forms.MaskedTextBox();
            this.mtb_TokenReturned = new System.Windows.Forms.MaskedTextBox();
            this.lbl_TokenReturned = new System.Windows.Forms.Label();
            this.lbl_TokenIssued = new System.Windows.Forms.Label();
            this.btn_InsertUserNote = new System.Windows.Forms.Button();
            this.tb_NewUserNote = new System.Windows.Forms.TextBox();
            this.dgv_UserNotes = new System.Windows.Forms.DataGridView();
            this.gb_UserProjects = new System.Windows.Forms.GroupBox();
            this.dgv_UserProjects = new System.Windows.Forms.DataGridView();
            this.btn_ProjectUserRemove = new System.Windows.Forms.Button();
            this.btn_ProjectUserAdd = new System.Windows.Forms.Button();
            this.btn_UserRefresh = new System.Windows.Forms.Button();
            this.btn_NewUser = new System.Windows.Forms.Button();
            this.btn_UserApply = new System.Windows.Forms.Button();
            this.btn_UserOK = new System.Windows.Forms.Button();
            this.btn_UserCancel = new System.Windows.Forms.Button();
            this.gb_MFA = new System.Windows.Forms.GroupBox();
            this.nud_TokenSerial = new System.Windows.Forms.NumericUpDown();
            this.gb_Training = new System.Windows.Forms.GroupBox();
            this.gb_UserDetail = new System.Windows.Forms.GroupBox();
            this.lbl_FullName = new System.Windows.Forms.Label();
            this.gb_UserNotes = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserNotes)).BeginInit();
            this.gb_UserProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserProjects)).BeginInit();
            this.gb_MFA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TokenSerial)).BeginInit();
            this.gb_Training.SuspendLayout();
            this.gb_UserDetail.SuspendLayout();
            this.gb_UserNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_UserStatus
            // 
            this.cb_UserStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_UserStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UserStatus.FormattingEnabled = true;
            this.cb_UserStatus.Location = new System.Drawing.Point(75, 19);
            this.cb_UserStatus.Name = "cb_UserStatus";
            this.cb_UserStatus.Size = new System.Drawing.Size(76, 21);
            this.cb_UserStatus.TabIndex = 25;
            // 
            // lbl_UserStatus
            // 
            this.lbl_UserStatus.AutoSize = true;
            this.lbl_UserStatus.Location = new System.Drawing.Point(6, 22);
            this.lbl_UserStatus.Name = "lbl_UserStatus";
            this.lbl_UserStatus.Size = new System.Drawing.Size(37, 13);
            this.lbl_UserStatus.TabIndex = 24;
            this.lbl_UserStatus.Text = "Status";
            // 
            // cb_UserTitle
            // 
            this.cb_UserTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_UserTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UserTitle.FormattingEnabled = true;
            this.cb_UserTitle.Location = new System.Drawing.Point(75, 46);
            this.cb_UserTitle.Name = "cb_UserTitle";
            this.cb_UserTitle.Size = new System.Drawing.Size(76, 21);
            this.cb_UserTitle.TabIndex = 27;
            // 
            // lbl_UserTitle
            // 
            this.lbl_UserTitle.AutoSize = true;
            this.lbl_UserTitle.Location = new System.Drawing.Point(6, 49);
            this.lbl_UserTitle.Name = "lbl_UserTitle";
            this.lbl_UserTitle.Size = new System.Drawing.Size(27, 13);
            this.lbl_UserTitle.TabIndex = 26;
            this.lbl_UserTitle.Text = "Title";
            // 
            // tb_FirstName
            // 
            this.tb_FirstName.Location = new System.Drawing.Point(217, 46);
            this.tb_FirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_FirstName.MaxLength = 50;
            this.tb_FirstName.Name = "tb_FirstName";
            this.tb_FirstName.Size = new System.Drawing.Size(120, 20);
            this.tb_FirstName.TabIndex = 29;
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Location = new System.Drawing.Point(156, 50);
            this.lbl_FirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_FirstName.TabIndex = 28;
            this.lbl_FirstName.Text = "First Name";
            // 
            // tb_LastName
            // 
            this.tb_LastName.Location = new System.Drawing.Point(217, 70);
            this.tb_LastName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_LastName.MaxLength = 50;
            this.tb_LastName.Name = "tb_LastName";
            this.tb_LastName.Size = new System.Drawing.Size(120, 20);
            this.tb_LastName.TabIndex = 31;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(155, 75);
            this.lbl_LastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_LastName.TabIndex = 30;
            this.lbl_LastName.Text = "Last Name";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(217, 118);
            this.tb_Email.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Email.MaxLength = 255;
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(120, 20);
            this.tb_Email.TabIndex = 33;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(181, 121);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 32;
            this.lbl_Email.Text = "Email";
            // 
            // tb_Phone
            // 
            this.tb_Phone.Location = new System.Drawing.Point(411, 118);
            this.tb_Phone.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Phone.MaxLength = 15;
            this.tb_Phone.Name = "tb_Phone";
            this.tb_Phone.Size = new System.Drawing.Size(75, 20);
            this.tb_Phone.TabIndex = 35;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Location = new System.Drawing.Point(364, 121);
            this.lbl_Phone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(38, 13);
            this.lbl_Phone.TabIndex = 34;
            this.lbl_Phone.Text = "Phone";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(75, 118);
            this.tb_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_UserName.MaxLength = 12;
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(75, 20);
            this.tb_UserName.TabIndex = 37;
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(6, 121);
            this.lbl_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(60, 13);
            this.lbl_UserName.TabIndex = 36;
            this.lbl_UserName.Text = "User Name";
            // 
            // tb_Organisation
            // 
            this.tb_Organisation.Location = new System.Drawing.Point(75, 142);
            this.tb_Organisation.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Organisation.MaxLength = 255;
            this.tb_Organisation.Name = "tb_Organisation";
            this.tb_Organisation.Size = new System.Drawing.Size(262, 20);
            this.tb_Organisation.TabIndex = 39;
            // 
            // lbl_Organisation
            // 
            this.lbl_Organisation.AutoSize = true;
            this.lbl_Organisation.Location = new System.Drawing.Point(6, 145);
            this.lbl_Organisation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Organisation.Name = "lbl_Organisation";
            this.lbl_Organisation.Size = new System.Drawing.Size(66, 13);
            this.lbl_Organisation.TabIndex = 38;
            this.lbl_Organisation.Text = "Organisation";
            // 
            // mtb_UserStartDate
            // 
            this.mtb_UserStartDate.Location = new System.Drawing.Point(409, 46);
            this.mtb_UserStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_UserStartDate.Mask = "00/00/0000";
            this.mtb_UserStartDate.Name = "mtb_UserStartDate";
            this.mtb_UserStartDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_UserStartDate.TabIndex = 41;
            this.mtb_UserStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_UserEndDate
            // 
            this.mtb_UserEndDate.Location = new System.Drawing.Point(410, 70);
            this.mtb_UserEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_UserEndDate.Mask = "00/00/0000";
            this.mtb_UserEndDate.Name = "mtb_UserEndDate";
            this.mtb_UserEndDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_UserEndDate.TabIndex = 43;
            this.mtb_UserEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.AutoSize = true;
            this.lbl_EndDate.Location = new System.Drawing.Point(354, 73);
            this.lbl_EndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(52, 13);
            this.lbl_EndDate.TabIndex = 42;
            this.lbl_EndDate.Text = "End Date";
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.AutoSize = true;
            this.lbl_StartDate.Location = new System.Drawing.Point(350, 49);
            this.lbl_StartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(55, 13);
            this.lbl_StartDate.TabIndex = 40;
            this.lbl_StartDate.Text = "Start Date";
            // 
            // mtb_IRCAgreement
            // 
            this.mtb_IRCAgreement.Location = new System.Drawing.Point(94, 18);
            this.mtb_IRCAgreement.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_IRCAgreement.Mask = "00/00/0000";
            this.mtb_IRCAgreement.Name = "mtb_IRCAgreement";
            this.mtb_IRCAgreement.Size = new System.Drawing.Size(76, 20);
            this.mtb_IRCAgreement.TabIndex = 45;
            this.mtb_IRCAgreement.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_ISET
            // 
            this.mtb_ISET.Location = new System.Drawing.Point(94, 42);
            this.mtb_ISET.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ISET.Mask = "00/00/0000";
            this.mtb_ISET.Name = "mtb_ISET";
            this.mtb_ISET.Size = new System.Drawing.Size(76, 20);
            this.mtb_ISET.TabIndex = 47;
            this.mtb_ISET.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_ISET
            // 
            this.lbl_ISET.AutoSize = true;
            this.lbl_ISET.Location = new System.Drawing.Point(5, 45);
            this.lbl_ISET.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ISET.Name = "lbl_ISET";
            this.lbl_ISET.Size = new System.Drawing.Size(31, 13);
            this.lbl_ISET.TabIndex = 46;
            this.lbl_ISET.Text = "ISET";
            // 
            // lbl_IRCAgreement
            // 
            this.lbl_IRCAgreement.AutoSize = true;
            this.lbl_IRCAgreement.Location = new System.Drawing.Point(5, 21);
            this.lbl_IRCAgreement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_IRCAgreement.Name = "lbl_IRCAgreement";
            this.lbl_IRCAgreement.Size = new System.Drawing.Size(79, 13);
            this.lbl_IRCAgreement.TabIndex = 44;
            this.lbl_IRCAgreement.Text = "IRC Agreement";
            // 
            // mtb_ISAT
            // 
            this.mtb_ISAT.Location = new System.Drawing.Point(94, 66);
            this.mtb_ISAT.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ISAT.Mask = "00/00/0000";
            this.mtb_ISAT.Name = "mtb_ISAT";
            this.mtb_ISAT.Size = new System.Drawing.Size(76, 20);
            this.mtb_ISAT.TabIndex = 49;
            this.mtb_ISAT.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_SAFE
            // 
            this.mtb_SAFE.Location = new System.Drawing.Point(94, 90);
            this.mtb_SAFE.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_SAFE.Mask = "00/00/0000";
            this.mtb_SAFE.Name = "mtb_SAFE";
            this.mtb_SAFE.Size = new System.Drawing.Size(76, 20);
            this.mtb_SAFE.TabIndex = 51;
            this.mtb_SAFE.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_SAFE
            // 
            this.lbl_SAFE.AutoSize = true;
            this.lbl_SAFE.Location = new System.Drawing.Point(5, 93);
            this.lbl_SAFE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SAFE.Name = "lbl_SAFE";
            this.lbl_SAFE.Size = new System.Drawing.Size(34, 13);
            this.lbl_SAFE.TabIndex = 50;
            this.lbl_SAFE.Text = "SAFE";
            // 
            // lbl_ISAT
            // 
            this.lbl_ISAT.AutoSize = true;
            this.lbl_ISAT.Location = new System.Drawing.Point(5, 69);
            this.lbl_ISAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ISAT.Name = "lbl_ISAT";
            this.lbl_ISAT.Size = new System.Drawing.Size(31, 13);
            this.lbl_ISAT.TabIndex = 48;
            this.lbl_ISAT.Text = "ISAT";
            // 
            // lbl_TokenSerial
            // 
            this.lbl_TokenSerial.AutoSize = true;
            this.lbl_TokenSerial.Location = new System.Drawing.Point(5, 21);
            this.lbl_TokenSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TokenSerial.Name = "lbl_TokenSerial";
            this.lbl_TokenSerial.Size = new System.Drawing.Size(67, 13);
            this.lbl_TokenSerial.TabIndex = 52;
            this.lbl_TokenSerial.Text = "Token Serial";
            // 
            // mtb_TokenIssued
            // 
            this.mtb_TokenIssued.Location = new System.Drawing.Point(94, 42);
            this.mtb_TokenIssued.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_TokenIssued.Mask = "00/00/0000";
            this.mtb_TokenIssued.Name = "mtb_TokenIssued";
            this.mtb_TokenIssued.Size = new System.Drawing.Size(76, 20);
            this.mtb_TokenIssued.TabIndex = 55;
            this.mtb_TokenIssued.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_TokenReturned
            // 
            this.mtb_TokenReturned.Location = new System.Drawing.Point(94, 66);
            this.mtb_TokenReturned.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_TokenReturned.Mask = "00/00/0000";
            this.mtb_TokenReturned.Name = "mtb_TokenReturned";
            this.mtb_TokenReturned.Size = new System.Drawing.Size(76, 20);
            this.mtb_TokenReturned.TabIndex = 57;
            this.mtb_TokenReturned.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_TokenReturned
            // 
            this.lbl_TokenReturned.AutoSize = true;
            this.lbl_TokenReturned.Location = new System.Drawing.Point(5, 69);
            this.lbl_TokenReturned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TokenReturned.Name = "lbl_TokenReturned";
            this.lbl_TokenReturned.Size = new System.Drawing.Size(85, 13);
            this.lbl_TokenReturned.TabIndex = 56;
            this.lbl_TokenReturned.Text = "Token Returned";
            // 
            // lbl_TokenIssued
            // 
            this.lbl_TokenIssued.AutoSize = true;
            this.lbl_TokenIssued.Location = new System.Drawing.Point(5, 45);
            this.lbl_TokenIssued.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TokenIssued.Name = "lbl_TokenIssued";
            this.lbl_TokenIssued.Size = new System.Drawing.Size(72, 13);
            this.lbl_TokenIssued.TabIndex = 54;
            this.lbl_TokenIssued.Text = "Token Issued";
            // 
            // btn_InsertUserNote
            // 
            this.btn_InsertUserNote.Location = new System.Drawing.Point(443, 18);
            this.btn_InsertUserNote.Margin = new System.Windows.Forms.Padding(2);
            this.btn_InsertUserNote.Name = "btn_InsertUserNote";
            this.btn_InsertUserNote.Size = new System.Drawing.Size(55, 40);
            this.btn_InsertUserNote.TabIndex = 59;
            this.btn_InsertUserNote.Text = "Add Note";
            this.btn_InsertUserNote.UseVisualStyleBackColor = true;
            this.btn_InsertUserNote.Click += new System.EventHandler(this.btn_InsertUserNote_Click);
            // 
            // tb_NewUserNote
            // 
            this.tb_NewUserNote.Location = new System.Drawing.Point(5, 18);
            this.tb_NewUserNote.Margin = new System.Windows.Forms.Padding(2);
            this.tb_NewUserNote.MaxLength = 8000;
            this.tb_NewUserNote.Multiline = true;
            this.tb_NewUserNote.Name = "tb_NewUserNote";
            this.tb_NewUserNote.Size = new System.Drawing.Size(433, 40);
            this.tb_NewUserNote.TabIndex = 58;
            // 
            // dgv_UserNotes
            // 
            this.dgv_UserNotes.AllowUserToAddRows = false;
            this.dgv_UserNotes.AllowUserToDeleteRows = false;
            this.dgv_UserNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserNotes.Location = new System.Drawing.Point(5, 62);
            this.dgv_UserNotes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_UserNotes.Name = "dgv_UserNotes";
            this.dgv_UserNotes.ReadOnly = true;
            this.dgv_UserNotes.RowHeadersVisible = false;
            this.dgv_UserNotes.RowTemplate.Height = 24;
            this.dgv_UserNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserNotes.Size = new System.Drawing.Size(494, 150);
            this.dgv_UserNotes.TabIndex = 60;
            this.dgv_UserNotes.TabStop = false;
            // 
            // gb_UserProjects
            // 
            this.gb_UserProjects.Controls.Add(this.dgv_UserProjects);
            this.gb_UserProjects.Controls.Add(this.btn_ProjectUserRemove);
            this.gb_UserProjects.Controls.Add(this.btn_ProjectUserAdd);
            this.gb_UserProjects.Location = new System.Drawing.Point(517, 12);
            this.gb_UserProjects.Name = "gb_UserProjects";
            this.gb_UserProjects.Size = new System.Drawing.Size(191, 174);
            this.gb_UserProjects.TabIndex = 0;
            this.gb_UserProjects.TabStop = false;
            this.gb_UserProjects.Text = "Projects";
            // 
            // dgv_UserProjects
            // 
            this.dgv_UserProjects.AllowUserToAddRows = false;
            this.dgv_UserProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserProjects.ColumnHeadersVisible = false;
            this.dgv_UserProjects.Location = new System.Drawing.Point(8, 19);
            this.dgv_UserProjects.Name = "dgv_UserProjects";
            this.dgv_UserProjects.ReadOnly = true;
            this.dgv_UserProjects.RowHeadersVisible = false;
            this.dgv_UserProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserProjects.Size = new System.Drawing.Size(170, 115);
            this.dgv_UserProjects.TabIndex = 41;
            this.dgv_UserProjects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserProjects_CellDoubleClick);
            // 
            // btn_ProjectUserRemove
            // 
            this.btn_ProjectUserRemove.Location = new System.Drawing.Point(96, 140);
            this.btn_ProjectUserRemove.Name = "btn_ProjectUserRemove";
            this.btn_ProjectUserRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectUserRemove.TabIndex = 43;
            this.btn_ProjectUserRemove.Text = "Remove";
            this.btn_ProjectUserRemove.UseVisualStyleBackColor = true;
            this.btn_ProjectUserRemove.Click += new System.EventHandler(this.btn_ProjectUserRemove_Click);
            // 
            // btn_ProjectUserAdd
            // 
            this.btn_ProjectUserAdd.Location = new System.Drawing.Point(16, 140);
            this.btn_ProjectUserAdd.Name = "btn_ProjectUserAdd";
            this.btn_ProjectUserAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectUserAdd.TabIndex = 42;
            this.btn_ProjectUserAdd.Text = "Add";
            this.btn_ProjectUserAdd.UseVisualStyleBackColor = true;
            this.btn_ProjectUserAdd.Click += new System.EventHandler(this.btn_ProjectUserAdd_Click);
            // 
            // btn_UserRefresh
            // 
            this.btn_UserRefresh.Location = new System.Drawing.Point(451, 422);
            this.btn_UserRefresh.Name = "btn_UserRefresh";
            this.btn_UserRefresh.Size = new System.Drawing.Size(75, 23);
            this.btn_UserRefresh.TabIndex = 66;
            this.btn_UserRefresh.Text = "Refresh";
            this.btn_UserRefresh.UseVisualStyleBackColor = true;
            this.btn_UserRefresh.Click += new System.EventHandler(this.btn_UserRefresh_Click);
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Location = new System.Drawing.Point(206, 422);
            this.btn_NewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(90, 24);
            this.btn_NewUser.TabIndex = 65;
            this.btn_NewUser.Text = "Create User";
            this.btn_NewUser.UseVisualStyleBackColor = true;
            // 
            // btn_UserApply
            // 
            this.btn_UserApply.Location = new System.Drawing.Point(531, 421);
            this.btn_UserApply.Margin = new System.Windows.Forms.Padding(2);
            this.btn_UserApply.Name = "btn_UserApply";
            this.btn_UserApply.Size = new System.Drawing.Size(56, 24);
            this.btn_UserApply.TabIndex = 62;
            this.btn_UserApply.Text = "Apply";
            this.btn_UserApply.UseVisualStyleBackColor = true;
            this.btn_UserApply.Click += new System.EventHandler(this.btn_UserApply_Click);
            // 
            // btn_UserOK
            // 
            this.btn_UserOK.Location = new System.Drawing.Point(592, 421);
            this.btn_UserOK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_UserOK.Name = "btn_UserOK";
            this.btn_UserOK.Size = new System.Drawing.Size(56, 24);
            this.btn_UserOK.TabIndex = 63;
            this.btn_UserOK.Text = "OK";
            this.btn_UserOK.UseVisualStyleBackColor = true;
            this.btn_UserOK.Click += new System.EventHandler(this.btn_UserOK_Click);
            // 
            // btn_UserCancel
            // 
            this.btn_UserCancel.Location = new System.Drawing.Point(652, 421);
            this.btn_UserCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_UserCancel.Name = "btn_UserCancel";
            this.btn_UserCancel.Size = new System.Drawing.Size(56, 24);
            this.btn_UserCancel.TabIndex = 64;
            this.btn_UserCancel.Text = "Cancel";
            this.btn_UserCancel.UseVisualStyleBackColor = true;
            this.btn_UserCancel.Click += new System.EventHandler(this.btn_UserCancel_Click);
            // 
            // gb_MFA
            // 
            this.gb_MFA.Controls.Add(this.nud_TokenSerial);
            this.gb_MFA.Controls.Add(this.lbl_TokenSerial);
            this.gb_MFA.Controls.Add(this.lbl_TokenIssued);
            this.gb_MFA.Controls.Add(this.lbl_TokenReturned);
            this.gb_MFA.Controls.Add(this.mtb_TokenIssued);
            this.gb_MFA.Controls.Add(this.mtb_TokenReturned);
            this.gb_MFA.Location = new System.Drawing.Point(12, 318);
            this.gb_MFA.Name = "gb_MFA";
            this.gb_MFA.Size = new System.Drawing.Size(183, 98);
            this.gb_MFA.TabIndex = 0;
            this.gb_MFA.TabStop = false;
            this.gb_MFA.Text = "MFA Token";
            // 
            // nud_TokenSerial
            // 
            this.nud_TokenSerial.InterceptArrowKeys = false;
            this.nud_TokenSerial.Location = new System.Drawing.Point(93, 19);
            this.nud_TokenSerial.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.nud_TokenSerial.Name = "nud_TokenSerial";
            this.nud_TokenSerial.Size = new System.Drawing.Size(77, 20);
            this.nud_TokenSerial.TabIndex = 67;
            // 
            // gb_Training
            // 
            this.gb_Training.Controls.Add(this.lbl_IRCAgreement);
            this.gb_Training.Controls.Add(this.mtb_IRCAgreement);
            this.gb_Training.Controls.Add(this.mtb_ISET);
            this.gb_Training.Controls.Add(this.lbl_ISET);
            this.gb_Training.Controls.Add(this.mtb_ISAT);
            this.gb_Training.Controls.Add(this.lbl_ISAT);
            this.gb_Training.Controls.Add(this.mtb_SAFE);
            this.gb_Training.Controls.Add(this.lbl_SAFE);
            this.gb_Training.Location = new System.Drawing.Point(12, 192);
            this.gb_Training.Name = "gb_Training";
            this.gb_Training.Size = new System.Drawing.Size(183, 120);
            this.gb_Training.TabIndex = 0;
            this.gb_Training.TabStop = false;
            this.gb_Training.Text = "Training";
            // 
            // gb_UserDetail
            // 
            this.gb_UserDetail.Controls.Add(this.lbl_FullName);
            this.gb_UserDetail.Controls.Add(this.cb_UserStatus);
            this.gb_UserDetail.Controls.Add(this.lbl_UserTitle);
            this.gb_UserDetail.Controls.Add(this.lbl_UserStatus);
            this.gb_UserDetail.Controls.Add(this.lbl_UserName);
            this.gb_UserDetail.Controls.Add(this.cb_UserTitle);
            this.gb_UserDetail.Controls.Add(this.lbl_LastName);
            this.gb_UserDetail.Controls.Add(this.lbl_FirstName);
            this.gb_UserDetail.Controls.Add(this.tb_FirstName);
            this.gb_UserDetail.Controls.Add(this.lbl_Email);
            this.gb_UserDetail.Controls.Add(this.tb_UserName);
            this.gb_UserDetail.Controls.Add(this.lbl_Organisation);
            this.gb_UserDetail.Controls.Add(this.lbl_StartDate);
            this.gb_UserDetail.Controls.Add(this.lbl_Phone);
            this.gb_UserDetail.Controls.Add(this.mtb_UserEndDate);
            this.gb_UserDetail.Controls.Add(this.tb_Email);
            this.gb_UserDetail.Controls.Add(this.mtb_UserStartDate);
            this.gb_UserDetail.Controls.Add(this.lbl_EndDate);
            this.gb_UserDetail.Controls.Add(this.tb_Phone);
            this.gb_UserDetail.Controls.Add(this.tb_LastName);
            this.gb_UserDetail.Controls.Add(this.tb_Organisation);
            this.gb_UserDetail.Location = new System.Drawing.Point(12, 12);
            this.gb_UserDetail.Name = "gb_UserDetail";
            this.gb_UserDetail.Size = new System.Drawing.Size(499, 174);
            this.gb_UserDetail.TabIndex = 0;
            this.gb_UserDetail.TabStop = false;
            this.gb_UserDetail.Text = "User Detail";
            // 
            // lbl_FullName
            // 
            this.lbl_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FullName.Location = new System.Drawing.Point(159, 15);
            this.lbl_FullName.Name = "lbl_FullName";
            this.lbl_FullName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_FullName.Size = new System.Drawing.Size(327, 20);
            this.lbl_FullName.TabIndex = 32;
            this.lbl_FullName.Text = "Title LastName, FirstName";
            this.lbl_FullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_UserNotes
            // 
            this.gb_UserNotes.Controls.Add(this.tb_NewUserNote);
            this.gb_UserNotes.Controls.Add(this.dgv_UserNotes);
            this.gb_UserNotes.Controls.Add(this.btn_InsertUserNote);
            this.gb_UserNotes.Location = new System.Drawing.Point(201, 192);
            this.gb_UserNotes.Name = "gb_UserNotes";
            this.gb_UserNotes.Size = new System.Drawing.Size(507, 224);
            this.gb_UserNotes.TabIndex = 0;
            this.gb_UserNotes.TabStop = false;
            this.gb_UserNotes.Text = "Notes";
            // 
            // frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 456);
            this.Controls.Add(this.gb_UserNotes);
            this.Controls.Add(this.gb_UserDetail);
            this.Controls.Add(this.gb_Training);
            this.Controls.Add(this.gb_MFA);
            this.Controls.Add(this.btn_UserRefresh);
            this.Controls.Add(this.btn_NewUser);
            this.Controls.Add(this.btn_UserApply);
            this.Controls.Add(this.btn_UserOK);
            this.Controls.Add(this.btn_UserCancel);
            this.Controls.Add(this.gb_UserProjects);
            this.Name = "frm_User";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "User";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserNotes)).EndInit();
            this.gb_UserProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserProjects)).EndInit();
            this.gb_MFA.ResumeLayout(false);
            this.gb_MFA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TokenSerial)).EndInit();
            this.gb_Training.ResumeLayout(false);
            this.gb_Training.PerformLayout();
            this.gb_UserDetail.ResumeLayout(false);
            this.gb_UserDetail.PerformLayout();
            this.gb_UserNotes.ResumeLayout(false);
            this.gb_UserNotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_UserStatus;
        private System.Windows.Forms.Label lbl_UserStatus;
        private System.Windows.Forms.ComboBox cb_UserTitle;
        private System.Windows.Forms.Label lbl_UserTitle;
        private System.Windows.Forms.TextBox tb_FirstName;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.TextBox tb_LastName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tb_Phone;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.TextBox tb_Organisation;
        private System.Windows.Forms.Label lbl_Organisation;
        private System.Windows.Forms.MaskedTextBox mtb_UserStartDate;
        private System.Windows.Forms.MaskedTextBox mtb_UserEndDate;
        private System.Windows.Forms.Label lbl_EndDate;
        private System.Windows.Forms.Label lbl_StartDate;
        private System.Windows.Forms.MaskedTextBox mtb_IRCAgreement;
        private System.Windows.Forms.MaskedTextBox mtb_ISET;
        private System.Windows.Forms.Label lbl_ISET;
        private System.Windows.Forms.Label lbl_IRCAgreement;
        private System.Windows.Forms.MaskedTextBox mtb_ISAT;
        private System.Windows.Forms.MaskedTextBox mtb_SAFE;
        private System.Windows.Forms.Label lbl_SAFE;
        private System.Windows.Forms.Label lbl_ISAT;
        private System.Windows.Forms.Label lbl_TokenSerial;
        private System.Windows.Forms.MaskedTextBox mtb_TokenIssued;
        private System.Windows.Forms.MaskedTextBox mtb_TokenReturned;
        private System.Windows.Forms.Label lbl_TokenReturned;
        private System.Windows.Forms.Label lbl_TokenIssued;
        private System.Windows.Forms.Button btn_InsertUserNote;
        private System.Windows.Forms.TextBox tb_NewUserNote;
        private System.Windows.Forms.DataGridView dgv_UserNotes;
        private System.Windows.Forms.GroupBox gb_UserProjects;
        private System.Windows.Forms.DataGridView dgv_UserProjects;
        private System.Windows.Forms.Button btn_ProjectUserRemove;
        private System.Windows.Forms.Button btn_ProjectUserAdd;
        private System.Windows.Forms.Button btn_UserRefresh;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Button btn_UserApply;
        private System.Windows.Forms.Button btn_UserOK;
        private System.Windows.Forms.Button btn_UserCancel;
        private System.Windows.Forms.GroupBox gb_MFA;
        private System.Windows.Forms.GroupBox gb_Training;
        private System.Windows.Forms.GroupBox gb_UserDetail;
        private System.Windows.Forms.Label lbl_FullName;
        private System.Windows.Forms.GroupBox gb_UserNotes;
        private System.Windows.Forms.NumericUpDown nud_TokenSerial;
    }
}