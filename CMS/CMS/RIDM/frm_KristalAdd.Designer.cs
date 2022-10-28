namespace CMS
{
    partial class frm_KristalAdd
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
            this.btn_ProjectKristalAdd_Add = new System.Windows.Forms.Button();
            this.btn_ProjectKristalAdd_Cancel = new System.Windows.Forms.Button();
            this.lbl_KristalRef = new System.Windows.Forms.Label();
            this.cb_GrantStage = new System.Windows.Forms.ComboBox();
            this.lbl_AppStage = new System.Windows.Forms.Label();
            this.tb_KristalRef = new System.Windows.Forms.TextBox();
            this.tb_KristalName = new System.Windows.Forms.TextBox();
            this.lbl_KristalName = new System.Windows.Forms.Label();
            this.cb_Location = new System.Windows.Forms.ComboBox();
            this.lbl_Location = new System.Windows.Forms.Label();
            this.cb_PI = new System.Windows.Forms.ComboBox();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.lbl_Faculty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ProjectKristalAdd_Add
            // 
            this.btn_ProjectKristalAdd_Add.Location = new System.Drawing.Point(289, 113);
            this.btn_ProjectKristalAdd_Add.Name = "btn_ProjectKristalAdd_Add";
            this.btn_ProjectKristalAdd_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectKristalAdd_Add.TabIndex = 49;
            this.btn_ProjectKristalAdd_Add.Text = "Add";
            this.btn_ProjectKristalAdd_Add.UseVisualStyleBackColor = true;
            this.btn_ProjectKristalAdd_Add.Click += new System.EventHandler(this.btn_KristalAdd_Add_Click);
            // 
            // btn_ProjectKristalAdd_Cancel
            // 
            this.btn_ProjectKristalAdd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ProjectKristalAdd_Cancel.Location = new System.Drawing.Point(370, 113);
            this.btn_ProjectKristalAdd_Cancel.Name = "btn_ProjectKristalAdd_Cancel";
            this.btn_ProjectKristalAdd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectKristalAdd_Cancel.TabIndex = 48;
            this.btn_ProjectKristalAdd_Cancel.Text = "Cancel";
            this.btn_ProjectKristalAdd_Cancel.UseVisualStyleBackColor = true;
            this.btn_ProjectKristalAdd_Cancel.Click += new System.EventHandler(this.btn_ProjectKristalAdd_Cancel_Click);
            // 
            // lbl_KristalRef
            // 
            this.lbl_KristalRef.AutoSize = true;
            this.lbl_KristalRef.Location = new System.Drawing.Point(12, 9);
            this.lbl_KristalRef.Name = "lbl_KristalRef";
            this.lbl_KristalRef.Size = new System.Drawing.Size(88, 13);
            this.lbl_KristalRef.TabIndex = 46;
            this.lbl_KristalRef.Text = "Kristal Reference";
            // 
            // cb_GrantStage
            // 
            this.cb_GrantStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_GrantStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_GrantStage.FormattingEnabled = true;
            this.cb_GrantStage.Location = new System.Drawing.Point(301, 6);
            this.cb_GrantStage.Name = "cb_GrantStage";
            this.cb_GrantStage.Size = new System.Drawing.Size(145, 21);
            this.cb_GrantStage.TabIndex = 45;
            // 
            // lbl_AppStage
            // 
            this.lbl_AppStage.AutoSize = true;
            this.lbl_AppStage.Location = new System.Drawing.Point(205, 9);
            this.lbl_AppStage.Name = "lbl_AppStage";
            this.lbl_AppStage.Size = new System.Drawing.Size(90, 13);
            this.lbl_AppStage.TabIndex = 44;
            this.lbl_AppStage.Text = "Application Stage";
            // 
            // tb_KristalRef
            // 
            this.tb_KristalRef.Location = new System.Drawing.Point(108, 7);
            this.tb_KristalRef.Name = "tb_KristalRef";
            this.tb_KristalRef.Size = new System.Drawing.Size(89, 20);
            this.tb_KristalRef.TabIndex = 50;
            this.tb_KristalRef.TextChanged += new System.EventHandler(this.prepopulateControlsIfRefExists);
            // 
            // tb_KristalName
            // 
            this.tb_KristalName.Location = new System.Drawing.Point(111, 33);
            this.tb_KristalName.Name = "tb_KristalName";
            this.tb_KristalName.Size = new System.Drawing.Size(335, 20);
            this.tb_KristalName.TabIndex = 79;
            // 
            // lbl_KristalName
            // 
            this.lbl_KristalName.AutoSize = true;
            this.lbl_KristalName.Location = new System.Drawing.Point(12, 36);
            this.lbl_KristalName.Name = "lbl_KristalName";
            this.lbl_KristalName.Size = new System.Drawing.Size(66, 13);
            this.lbl_KristalName.TabIndex = 78;
            this.lbl_KristalName.Text = "Kristal Name";
            // 
            // cb_Location
            // 
            this.cb_Location.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Location.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Location.FormattingEnabled = true;
            this.cb_Location.Location = new System.Drawing.Point(272, 59);
            this.cb_Location.Name = "cb_Location";
            this.cb_Location.Size = new System.Drawing.Size(173, 21);
            this.cb_Location.TabIndex = 104;
            // 
            // lbl_Location
            // 
            this.lbl_Location.AutoSize = true;
            this.lbl_Location.Location = new System.Drawing.Point(218, 62);
            this.lbl_Location.Name = "lbl_Location";
            this.lbl_Location.Size = new System.Drawing.Size(48, 13);
            this.lbl_Location.TabIndex = 103;
            this.lbl_Location.Text = "Location";
            // 
            // cb_PI
            // 
            this.cb_PI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PI.FormattingEnabled = true;
            this.cb_PI.Location = new System.Drawing.Point(34, 59);
            this.cb_PI.Name = "cb_PI";
            this.cb_PI.Size = new System.Drawing.Size(173, 21);
            this.cb_PI.TabIndex = 102;
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(12, 62);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(17, 13);
            this.lbl_pPI.TabIndex = 101;
            this.lbl_pPI.Text = "PI";
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Faculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(272, 86);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(173, 21);
            this.cb_Faculty.TabIndex = 100;
            // 
            // lbl_Faculty
            // 
            this.lbl_Faculty.AutoSize = true;
            this.lbl_Faculty.Location = new System.Drawing.Point(225, 89);
            this.lbl_Faculty.Name = "lbl_Faculty";
            this.lbl_Faculty.Size = new System.Drawing.Size(41, 13);
            this.lbl_Faculty.TabIndex = 99;
            this.lbl_Faculty.Text = "Faculty";
            // 
            // frm_KristalAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ProjectKristalAdd_Cancel;
            this.ClientSize = new System.Drawing.Size(458, 146);
            this.Controls.Add(this.cb_Location);
            this.Controls.Add(this.lbl_Location);
            this.Controls.Add(this.cb_PI);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.cb_Faculty);
            this.Controls.Add(this.lbl_Faculty);
            this.Controls.Add(this.tb_KristalName);
            this.Controls.Add(this.lbl_KristalName);
            this.Controls.Add(this.tb_KristalRef);
            this.Controls.Add(this.btn_ProjectKristalAdd_Add);
            this.Controls.Add(this.btn_ProjectKristalAdd_Cancel);
            this.Controls.Add(this.lbl_KristalRef);
            this.Controls.Add(this.cb_GrantStage);
            this.Controls.Add(this.lbl_AppStage);
            this.Name = "frm_KristalAdd";
            this.Text = "Add Kristal Ref";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjectKristalAdd_Add;
        private System.Windows.Forms.Button btn_ProjectKristalAdd_Cancel;
        private System.Windows.Forms.Label lbl_KristalRef;
        private System.Windows.Forms.ComboBox cb_GrantStage;
        private System.Windows.Forms.Label lbl_AppStage;
        private System.Windows.Forms.TextBox tb_KristalRef;
        private System.Windows.Forms.TextBox tb_KristalName;
        private System.Windows.Forms.Label lbl_KristalName;
        private System.Windows.Forms.ComboBox cb_Location;
        private System.Windows.Forms.Label lbl_Location;
        private System.Windows.Forms.ComboBox cb_PI;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Label lbl_Faculty;
    }
}