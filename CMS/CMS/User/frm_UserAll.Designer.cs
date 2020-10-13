namespace CMS
{
    partial class frm_UserAll
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
            this.lbl_UserTitle = new System.Windows.Forms.Label();
            this.lbl_UserStatus = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.cb_UserTitle = new System.Windows.Forms.ComboBox();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.tb_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.lbl_Organisation = new System.Windows.Forms.Label();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_LastName = new System.Windows.Forms.TextBox();
            this.tb_Organisation = new System.Windows.Forms.TextBox();
            this.dgv_UserList = new System.Windows.Forms.DataGridView();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_ClearSearch = new System.Windows.Forms.Button();
            this.btn_NewUser = new System.Windows.Forms.Button();
            this.lbl_recordCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_UserStatus
            // 
            this.cb_UserStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_UserStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UserStatus.FormattingEnabled = true;
            this.cb_UserStatus.Location = new System.Drawing.Point(280, 6);
            this.cb_UserStatus.Name = "cb_UserStatus";
            this.cb_UserStatus.Size = new System.Drawing.Size(76, 21);
            this.cb_UserStatus.TabIndex = 25;
            this.cb_UserStatus.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_UserTitle
            // 
            this.lbl_UserTitle.AutoSize = true;
            this.lbl_UserTitle.Location = new System.Drawing.Point(211, 36);
            this.lbl_UserTitle.Name = "lbl_UserTitle";
            this.lbl_UserTitle.Size = new System.Drawing.Size(27, 13);
            this.lbl_UserTitle.TabIndex = 26;
            this.lbl_UserTitle.Text = "Title";
            // 
            // lbl_UserStatus
            // 
            this.lbl_UserStatus.AutoSize = true;
            this.lbl_UserStatus.Location = new System.Drawing.Point(211, 9);
            this.lbl_UserStatus.Name = "lbl_UserStatus";
            this.lbl_UserStatus.Size = new System.Drawing.Size(37, 13);
            this.lbl_UserStatus.TabIndex = 24;
            this.lbl_UserStatus.Text = "Status";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(211, 108);
            this.lbl_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(60, 13);
            this.lbl_UserName.TabIndex = 36;
            this.lbl_UserName.Text = "User Name";
            // 
            // cb_UserTitle
            // 
            this.cb_UserTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_UserTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UserTitle.FormattingEnabled = true;
            this.cb_UserTitle.Location = new System.Drawing.Point(280, 33);
            this.cb_UserTitle.Name = "cb_UserTitle";
            this.cb_UserTitle.Size = new System.Drawing.Size(76, 21);
            this.cb_UserTitle.TabIndex = 27;
            this.cb_UserTitle.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(360, 62);
            this.lbl_LastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_LastName.TabIndex = 30;
            this.lbl_LastName.Text = "Last Name";
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Location = new System.Drawing.Point(361, 37);
            this.lbl_FirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_FirstName.TabIndex = 28;
            this.lbl_FirstName.Text = "First Name";
            // 
            // tb_FirstName
            // 
            this.tb_FirstName.Location = new System.Drawing.Point(422, 33);
            this.tb_FirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_FirstName.MaxLength = 50;
            this.tb_FirstName.Name = "tb_FirstName";
            this.tb_FirstName.Size = new System.Drawing.Size(120, 20);
            this.tb_FirstName.TabIndex = 29;
            this.tb_FirstName.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(386, 108);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 32;
            this.lbl_Email.Text = "Email";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(280, 105);
            this.tb_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_UserName.MaxLength = 12;
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(75, 20);
            this.tb_UserName.TabIndex = 37;
            this.tb_UserName.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // lbl_Organisation
            // 
            this.lbl_Organisation.AutoSize = true;
            this.lbl_Organisation.Location = new System.Drawing.Point(211, 132);
            this.lbl_Organisation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Organisation.Name = "lbl_Organisation";
            this.lbl_Organisation.Size = new System.Drawing.Size(66, 13);
            this.lbl_Organisation.TabIndex = 38;
            this.lbl_Organisation.Text = "Organisation";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(422, 105);
            this.tb_Email.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Email.MaxLength = 255;
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(120, 20);
            this.tb_Email.TabIndex = 33;
            this.tb_Email.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // tb_LastName
            // 
            this.tb_LastName.Location = new System.Drawing.Point(422, 57);
            this.tb_LastName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_LastName.MaxLength = 50;
            this.tb_LastName.Name = "tb_LastName";
            this.tb_LastName.Size = new System.Drawing.Size(120, 20);
            this.tb_LastName.TabIndex = 31;
            this.tb_LastName.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // tb_Organisation
            // 
            this.tb_Organisation.Location = new System.Drawing.Point(280, 129);
            this.tb_Organisation.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Organisation.MaxLength = 255;
            this.tb_Organisation.Name = "tb_Organisation";
            this.tb_Organisation.Size = new System.Drawing.Size(262, 20);
            this.tb_Organisation.TabIndex = 39;
            this.tb_Organisation.TextChanged += new System.EventHandler(this.searchItemAdded);
            // 
            // dgv_UserList
            // 
            this.dgv_UserList.AllowUserToAddRows = false;
            this.dgv_UserList.AllowUserToDeleteRows = false;
            this.dgv_UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserList.Location = new System.Drawing.Point(13, 154);
            this.dgv_UserList.Name = "dgv_UserList";
            this.dgv_UserList.ReadOnly = true;
            this.dgv_UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserList.Size = new System.Drawing.Size(810, 285);
            this.dgv_UserList.TabIndex = 40;
            this.dgv_UserList.TabStop = false;
            this.dgv_UserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserList_CellDoubleClick);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(731, 68);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(91, 23);
            this.btn_Refresh.TabIndex = 72;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.refreshPage);
            // 
            // btn_ClearSearch
            // 
            this.btn_ClearSearch.Location = new System.Drawing.Point(732, 97);
            this.btn_ClearSearch.Name = "btn_ClearSearch";
            this.btn_ClearSearch.Size = new System.Drawing.Size(90, 23);
            this.btn_ClearSearch.TabIndex = 71;
            this.btn_ClearSearch.Text = "Clear Search";
            this.btn_ClearSearch.UseVisualStyleBackColor = true;
            this.btn_ClearSearch.Click += new System.EventHandler(this.clearSearch);
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Location = new System.Drawing.Point(733, 125);
            this.btn_NewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(90, 24);
            this.btn_NewUser.TabIndex = 70;
            this.btn_NewUser.Text = "Create User";
            this.btn_NewUser.UseVisualStyleBackColor = true;
            this.btn_NewUser.Click += new System.EventHandler(this.open_frm_UserAdd);
            // 
            // lbl_recordCount
            // 
            this.lbl_recordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_recordCount.Location = new System.Drawing.Point(722, 442);
            this.lbl_recordCount.Name = "lbl_recordCount";
            this.lbl_recordCount.Size = new System.Drawing.Size(100, 23);
            this.lbl_recordCount.TabIndex = 73;
            this.lbl_recordCount.Text = "# records";
            this.lbl_recordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_UserAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 471);
            this.Controls.Add(this.lbl_recordCount);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_ClearSearch);
            this.Controls.Add(this.btn_NewUser);
            this.Controls.Add(this.dgv_UserList);
            this.Controls.Add(this.cb_UserStatus);
            this.Controls.Add(this.lbl_UserTitle);
            this.Controls.Add(this.lbl_UserStatus);
            this.Controls.Add(this.tb_Organisation);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.tb_LastName);
            this.Controls.Add(this.cb_UserTitle);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.lbl_LastName);
            this.Controls.Add(this.lbl_Organisation);
            this.Controls.Add(this.lbl_FirstName);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.tb_FirstName);
            this.Controls.Add(this.lbl_Email);
            this.Name = "frm_UserAll";
            this.Text = "LIDA Users";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_UserStatus;
        private System.Windows.Forms.Label lbl_UserTitle;
        private System.Windows.Forms.Label lbl_UserStatus;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.ComboBox cb_UserTitle;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.TextBox tb_FirstName;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label lbl_Organisation;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_LastName;
        private System.Windows.Forms.TextBox tb_Organisation;
        private System.Windows.Forms.DataGridView dgv_UserList;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_ClearSearch;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Label lbl_recordCount;
    }
}