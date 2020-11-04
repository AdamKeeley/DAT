namespace CMS
{
    partial class frm_ProjectUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectUserAdd));
            this.cb_Researcher = new System.Windows.Forms.ComboBox();
            this.lbl_Researcher = new System.Windows.Forms.Label();
            this.btn_UserProjectAdd_Add = new System.Windows.Forms.Button();
            this.btn_UserProjectAdd_Cancel = new System.Windows.Forms.Button();
            this.lbl_NewUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_Researcher
            // 
            this.cb_Researcher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Researcher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Researcher.FormattingEnabled = true;
            this.cb_Researcher.Location = new System.Drawing.Point(93, 6);
            this.cb_Researcher.Name = "cb_Researcher";
            this.cb_Researcher.Size = new System.Drawing.Size(173, 21);
            this.cb_Researcher.TabIndex = 39;
            // 
            // lbl_Researcher
            // 
            this.lbl_Researcher.AutoSize = true;
            this.lbl_Researcher.Location = new System.Drawing.Point(11, 9);
            this.lbl_Researcher.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Researcher.Name = "lbl_Researcher";
            this.lbl_Researcher.Size = new System.Drawing.Size(62, 13);
            this.lbl_Researcher.TabIndex = 38;
            this.lbl_Researcher.Text = "Researcher";
            // 
            // btn_UserProjectAdd_Add
            // 
            this.btn_UserProjectAdd_Add.Location = new System.Drawing.Point(166, 33);
            this.btn_UserProjectAdd_Add.Name = "btn_UserProjectAdd_Add";
            this.btn_UserProjectAdd_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_UserProjectAdd_Add.TabIndex = 41;
            this.btn_UserProjectAdd_Add.Text = "Add";
            this.btn_UserProjectAdd_Add.UseVisualStyleBackColor = true;
            this.btn_UserProjectAdd_Add.Click += new System.EventHandler(this.btn_UserProjectAdd_Add_Click);
            // 
            // btn_UserProjectAdd_Cancel
            // 
            this.btn_UserProjectAdd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_UserProjectAdd_Cancel.Location = new System.Drawing.Point(247, 33);
            this.btn_UserProjectAdd_Cancel.Name = "btn_UserProjectAdd_Cancel";
            this.btn_UserProjectAdd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_UserProjectAdd_Cancel.TabIndex = 40;
            this.btn_UserProjectAdd_Cancel.Text = "Cancel";
            this.btn_UserProjectAdd_Cancel.UseVisualStyleBackColor = true;
            this.btn_UserProjectAdd_Cancel.Click += new System.EventHandler(this.btn_UserProjectAdd_Cancel_Click);
            // 
            // lbl_NewUser
            // 
            this.lbl_NewUser.AutoSize = true;
            this.lbl_NewUser.Location = new System.Drawing.Point(272, 9);
            this.lbl_NewUser.Name = "lbl_NewUser";
            this.lbl_NewUser.Size = new System.Drawing.Size(59, 13);
            this.lbl_NewUser.TabIndex = 52;
            this.lbl_NewUser.Text = "new user...";
            this.lbl_NewUser.Click += new System.EventHandler(this.lbl_NewUser_Click);
            // 
            // frm_ProjectUserAdd
            // 
            this.AcceptButton = this.btn_UserProjectAdd_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_UserProjectAdd_Cancel;
            this.ClientSize = new System.Drawing.Size(334, 70);
            this.Controls.Add(this.lbl_NewUser);
            this.Controls.Add(this.btn_UserProjectAdd_Add);
            this.Controls.Add(this.btn_UserProjectAdd_Cancel);
            this.Controls.Add(this.cb_Researcher);
            this.Controls.Add(this.lbl_Researcher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ProjectUserAdd";
            this.Text = "Add User to a Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Researcher;
        private System.Windows.Forms.Label lbl_Researcher;
        private System.Windows.Forms.Button btn_UserProjectAdd_Add;
        private System.Windows.Forms.Button btn_UserProjectAdd_Cancel;
        private System.Windows.Forms.Label lbl_NewUser;
    }
}