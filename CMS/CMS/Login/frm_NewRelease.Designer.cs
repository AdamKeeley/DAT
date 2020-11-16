namespace CMS.Login
{
    partial class frm_NewRelease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewRelease));
            this.lbl_NewRelease1 = new System.Windows.Forms.Label();
            this.lbl_NewRelease2 = new System.Windows.Forms.Label();
            this.btn_frm_NewReleaseClose = new System.Windows.Forms.Button();
            this.lnk_NewReleaseUrl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_NewRelease1
            // 
            this.lbl_NewRelease1.AutoSize = true;
            this.lbl_NewRelease1.Location = new System.Drawing.Point(12, 9);
            this.lbl_NewRelease1.Name = "lbl_NewRelease1";
            this.lbl_NewRelease1.Size = new System.Drawing.Size(211, 13);
            this.lbl_NewRelease1.TabIndex = 1;
            this.lbl_NewRelease1.Text = "There is a newer version of Prism available.";
            // 
            // lbl_NewRelease2
            // 
            this.lbl_NewRelease2.AutoSize = true;
            this.lbl_NewRelease2.Location = new System.Drawing.Point(12, 22);
            this.lbl_NewRelease2.Name = "lbl_NewRelease2";
            this.lbl_NewRelease2.Size = new System.Drawing.Size(327, 13);
            this.lbl_NewRelease2.TabIndex = 2;
            this.lbl_NewRelease2.Text = "Please navigate to the following url and download the latest release:";
            // 
            // btn_frm_NewReleaseClose
            // 
            this.btn_frm_NewReleaseClose.Location = new System.Drawing.Point(261, 103);
            this.btn_frm_NewReleaseClose.Name = "btn_frm_NewReleaseClose";
            this.btn_frm_NewReleaseClose.Size = new System.Drawing.Size(75, 23);
            this.btn_frm_NewReleaseClose.TabIndex = 0;
            this.btn_frm_NewReleaseClose.Text = "Close";
            this.btn_frm_NewReleaseClose.UseVisualStyleBackColor = true;
            this.btn_frm_NewReleaseClose.Click += new System.EventHandler(this.btn_frm_NewReleaseClose_Click);
            // 
            // lnk_NewReleaseUrl
            // 
            this.lnk_NewReleaseUrl.Location = new System.Drawing.Point(12, 48);
            this.lnk_NewReleaseUrl.Name = "lnk_NewReleaseUrl";
            this.lnk_NewReleaseUrl.Size = new System.Drawing.Size(324, 52);
            this.lnk_NewReleaseUrl.TabIndex = 3;
            this.lnk_NewReleaseUrl.TabStop = true;
            this.lnk_NewReleaseUrl.Text = "URL for latest release could not be found.";
            this.lnk_NewReleaseUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_NewReleaseUrl_LinkClicked);
            // 
            // frm_NewRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 135);
            this.Controls.Add(this.lnk_NewReleaseUrl);
            this.Controls.Add(this.lbl_NewRelease2);
            this.Controls.Add(this.lbl_NewRelease1);
            this.Controls.Add(this.btn_frm_NewReleaseClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_NewRelease";
            this.Text = "New Version Available";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_NewRelease1;
        private System.Windows.Forms.Label lbl_NewRelease2;
        private System.Windows.Forms.Button btn_frm_NewReleaseClose;
        private System.Windows.Forms.LinkLabel lnk_NewReleaseUrl;
    }
}