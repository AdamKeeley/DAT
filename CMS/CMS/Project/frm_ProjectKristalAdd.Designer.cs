namespace CMS
{
    partial class frm_ProjectKristalAdd
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
            this.SuspendLayout();
            // 
            // btn_ProjectKristalAdd_Add
            // 
            this.btn_ProjectKristalAdd_Add.Location = new System.Drawing.Point(95, 65);
            this.btn_ProjectKristalAdd_Add.Name = "btn_ProjectKristalAdd_Add";
            this.btn_ProjectKristalAdd_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectKristalAdd_Add.TabIndex = 49;
            this.btn_ProjectKristalAdd_Add.Text = "Add";
            this.btn_ProjectKristalAdd_Add.UseVisualStyleBackColor = true;
            this.btn_ProjectKristalAdd_Add.Click += new System.EventHandler(this.btn_ProjectKristalAdd_Add_Click);
            // 
            // btn_ProjectKristalAdd_Cancel
            // 
            this.btn_ProjectKristalAdd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ProjectKristalAdd_Cancel.Location = new System.Drawing.Point(176, 65);
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
            this.lbl_KristalRef.Location = new System.Drawing.Point(12, 14);
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
            this.cb_GrantStage.Location = new System.Drawing.Point(108, 38);
            this.cb_GrantStage.Name = "cb_GrantStage";
            this.cb_GrantStage.Size = new System.Drawing.Size(143, 21);
            this.cb_GrantStage.TabIndex = 45;
            // 
            // lbl_AppStage
            // 
            this.lbl_AppStage.AutoSize = true;
            this.lbl_AppStage.Location = new System.Drawing.Point(12, 41);
            this.lbl_AppStage.Name = "lbl_AppStage";
            this.lbl_AppStage.Size = new System.Drawing.Size(90, 13);
            this.lbl_AppStage.TabIndex = 44;
            this.lbl_AppStage.Text = "Application Stage";
            // 
            // tb_KristalRef
            // 
            this.tb_KristalRef.Location = new System.Drawing.Point(108, 12);
            this.tb_KristalRef.Name = "tb_KristalRef";
            this.tb_KristalRef.Size = new System.Drawing.Size(143, 20);
            this.tb_KristalRef.TabIndex = 50;
            // 
            // frm_ProjectKristalAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ProjectKristalAdd_Cancel;
            this.ClientSize = new System.Drawing.Size(263, 96);
            this.Controls.Add(this.tb_KristalRef);
            this.Controls.Add(this.btn_ProjectKristalAdd_Add);
            this.Controls.Add(this.btn_ProjectKristalAdd_Cancel);
            this.Controls.Add(this.lbl_KristalRef);
            this.Controls.Add(this.cb_GrantStage);
            this.Controls.Add(this.lbl_AppStage);
            this.Name = "frm_ProjectKristalAdd";
            this.Text = "Add Kristal Ref to Project";
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
    }
}