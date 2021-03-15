namespace CMS.FileTransfers
{
    partial class frm_FileRejectionsAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FileRejectionsAdd));
            this.btn_AddRejection = new System.Windows.Forms.Button();
            this.lbl_Files = new System.Windows.Forms.Label();
            this.lbx_Files = new System.Windows.Forms.ListBox();
            this.tb_Reason = new System.Windows.Forms.TextBox();
            this.lbl_Reason = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_AddRejection
            // 
            this.btn_AddRejection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddRejection.Location = new System.Drawing.Point(144, 12);
            this.btn_AddRejection.Name = "btn_AddRejection";
            this.btn_AddRejection.Size = new System.Drawing.Size(263, 41);
            this.btn_AddRejection.TabIndex = 3;
            this.btn_AddRejection.Text = "Reject Files";
            this.btn_AddRejection.UseVisualStyleBackColor = true;
            this.btn_AddRejection.Click += new System.EventHandler(this.btn_AddRejection_Click);
            // 
            // lbl_Files
            // 
            this.lbl_Files.AutoSize = true;
            this.lbl_Files.Location = new System.Drawing.Point(13, 139);
            this.lbl_Files.Name = "lbl_Files";
            this.lbl_Files.Size = new System.Drawing.Size(218, 17);
            this.lbl_Files.TabIndex = 5;
            this.lbl_Files.Text = "File(s) to reject for reason above:";
            // 
            // lbx_Files
            // 
            this.lbx_Files.FormattingEnabled = true;
            this.lbx_Files.ItemHeight = 16;
            this.lbx_Files.Location = new System.Drawing.Point(12, 162);
            this.lbx_Files.Name = "lbx_Files";
            this.lbx_Files.Size = new System.Drawing.Size(531, 356);
            this.lbx_Files.TabIndex = 4;
            // 
            // tb_Reason
            // 
            this.tb_Reason.Location = new System.Drawing.Point(12, 77);
            this.tb_Reason.Multiline = true;
            this.tb_Reason.Name = "tb_Reason";
            this.tb_Reason.Size = new System.Drawing.Size(531, 59);
            this.tb_Reason.TabIndex = 6;
            // 
            // lbl_Reason
            // 
            this.lbl_Reason.AutoSize = true;
            this.lbl_Reason.Location = new System.Drawing.Point(13, 56);
            this.lbl_Reason.Name = "lbl_Reason";
            this.lbl_Reason.Size = new System.Drawing.Size(119, 17);
            this.lbl_Reason.TabIndex = 7;
            this.lbl_Reason.Text = "Rejection reason:";
            // 
            // frm_FileRejections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 530);
            this.Controls.Add(this.lbl_Reason);
            this.Controls.Add(this.tb_Reason);
            this.Controls.Add(this.btn_AddRejection);
            this.Controls.Add(this.lbl_Files);
            this.Controls.Add(this.lbx_Files);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FileRejections";
            this.Text = "Reject File Transfers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddRejection;
        private System.Windows.Forms.Label lbl_Files;
        private System.Windows.Forms.ListBox lbx_Files;
        private System.Windows.Forms.TextBox tb_Reason;
        private System.Windows.Forms.Label lbl_Reason;
    }
}