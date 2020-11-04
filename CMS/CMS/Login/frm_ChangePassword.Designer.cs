namespace CMS.Login
{
    partial class frm_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePassword));
            this.tb_NewPassword1 = new System.Windows.Forms.TextBox();
            this.lbl_NewPassword1 = new System.Windows.Forms.Label();
            this.lbl_ChangePasswordFor = new System.Windows.Forms.Label();
            this.lbl_NewPassword2 = new System.Windows.Forms.Label();
            this.tb_NewPassword2 = new System.Windows.Forms.TextBox();
            this.btn_ChangePasswordCancel = new System.Windows.Forms.Button();
            this.btn_ChangePasswordOK = new System.Windows.Forms.Button();
            this.lbl_ChangePasswordValidation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_NewPassword1
            // 
            this.tb_NewPassword1.Location = new System.Drawing.Point(109, 51);
            this.tb_NewPassword1.Name = "tb_NewPassword1";
            this.tb_NewPassword1.PasswordChar = '*';
            this.tb_NewPassword1.Size = new System.Drawing.Size(201, 20);
            this.tb_NewPassword1.TabIndex = 3;
            this.tb_NewPassword1.UseSystemPasswordChar = true;
            this.tb_NewPassword1.Leave += new System.EventHandler(this.validatePasswords);
            // 
            // lbl_NewPassword1
            // 
            this.lbl_NewPassword1.AutoSize = true;
            this.lbl_NewPassword1.Location = new System.Drawing.Point(12, 54);
            this.lbl_NewPassword1.Name = "lbl_NewPassword1";
            this.lbl_NewPassword1.Size = new System.Drawing.Size(78, 13);
            this.lbl_NewPassword1.TabIndex = 2;
            this.lbl_NewPassword1.Text = "New Password";
            // 
            // lbl_ChangePasswordFor
            // 
            this.lbl_ChangePasswordFor.AutoSize = true;
            this.lbl_ChangePasswordFor.Location = new System.Drawing.Point(12, 9);
            this.lbl_ChangePasswordFor.Name = "lbl_ChangePasswordFor";
            this.lbl_ChangePasswordFor.Size = new System.Drawing.Size(110, 13);
            this.lbl_ChangePasswordFor.TabIndex = 1;
            this.lbl_ChangePasswordFor.Text = "Change password for ";
            // 
            // lbl_NewPassword2
            // 
            this.lbl_NewPassword2.AutoSize = true;
            this.lbl_NewPassword2.Location = new System.Drawing.Point(12, 80);
            this.lbl_NewPassword2.Name = "lbl_NewPassword2";
            this.lbl_NewPassword2.Size = new System.Drawing.Size(91, 13);
            this.lbl_NewPassword2.TabIndex = 4;
            this.lbl_NewPassword2.Text = "Repeat Password";
            // 
            // tb_NewPassword2
            // 
            this.tb_NewPassword2.Location = new System.Drawing.Point(109, 77);
            this.tb_NewPassword2.Name = "tb_NewPassword2";
            this.tb_NewPassword2.PasswordChar = '*';
            this.tb_NewPassword2.Size = new System.Drawing.Size(201, 20);
            this.tb_NewPassword2.TabIndex = 5;
            this.tb_NewPassword2.UseSystemPasswordChar = true;
            this.tb_NewPassword2.Leave += new System.EventHandler(this.validatePasswords);
            // 
            // btn_ChangePasswordCancel
            // 
            this.btn_ChangePasswordCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ChangePasswordCancel.Location = new System.Drawing.Point(154, 103);
            this.btn_ChangePasswordCancel.Name = "btn_ChangePasswordCancel";
            this.btn_ChangePasswordCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ChangePasswordCancel.TabIndex = 6;
            this.btn_ChangePasswordCancel.Text = "Cancel";
            this.btn_ChangePasswordCancel.UseVisualStyleBackColor = true;
            this.btn_ChangePasswordCancel.Click += new System.EventHandler(this.btn_ChangePasswordCancel_Click);
            // 
            // btn_ChangePasswordOK
            // 
            this.btn_ChangePasswordOK.Location = new System.Drawing.Point(235, 103);
            this.btn_ChangePasswordOK.Name = "btn_ChangePasswordOK";
            this.btn_ChangePasswordOK.Size = new System.Drawing.Size(75, 23);
            this.btn_ChangePasswordOK.TabIndex = 7;
            this.btn_ChangePasswordOK.Text = "OK";
            this.btn_ChangePasswordOK.UseVisualStyleBackColor = true;
            this.btn_ChangePasswordOK.Click += new System.EventHandler(this.btn_ChangePasswordOK_Click);
            // 
            // lbl_ChangePasswordValidation
            // 
            this.lbl_ChangePasswordValidation.AutoSize = true;
            this.lbl_ChangePasswordValidation.ForeColor = System.Drawing.Color.Red;
            this.lbl_ChangePasswordValidation.Location = new System.Drawing.Point(12, 32);
            this.lbl_ChangePasswordValidation.Name = "lbl_ChangePasswordValidation";
            this.lbl_ChangePasswordValidation.Size = new System.Drawing.Size(53, 13);
            this.lbl_ChangePasswordValidation.TabIndex = 8;
            this.lbl_ChangePasswordValidation.Text = "Validation";
            // 
            // frm_ChangePassword
            // 
            this.AcceptButton = this.btn_ChangePasswordOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ChangePasswordCancel;
            this.ClientSize = new System.Drawing.Size(321, 134);
            this.Controls.Add(this.lbl_ChangePasswordValidation);
            this.Controls.Add(this.btn_ChangePasswordOK);
            this.Controls.Add(this.btn_ChangePasswordCancel);
            this.Controls.Add(this.tb_NewPassword2);
            this.Controls.Add(this.lbl_NewPassword2);
            this.Controls.Add(this.lbl_ChangePasswordFor);
            this.Controls.Add(this.tb_NewPassword1);
            this.Controls.Add(this.lbl_NewPassword1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ChangePassword";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_NewPassword1;
        private System.Windows.Forms.Label lbl_NewPassword1;
        private System.Windows.Forms.Label lbl_ChangePasswordFor;
        private System.Windows.Forms.Label lbl_NewPassword2;
        private System.Windows.Forms.TextBox tb_NewPassword2;
        private System.Windows.Forms.Button btn_ChangePasswordCancel;
        private System.Windows.Forms.Button btn_ChangePasswordOK;
        private System.Windows.Forms.Label lbl_ChangePasswordValidation;
    }
}