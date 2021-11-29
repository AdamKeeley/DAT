namespace CMS
{
    partial class frm_KristalEdit
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
            this.lbl_KristalRef = new System.Windows.Forms.Label();
            this.cb_GrantStage = new System.Windows.Forms.ComboBox();
            this.lbl_AppStage = new System.Windows.Forms.Label();
            this.lbl_KristalRefValue = new System.Windows.Forms.Label();
            this.btn_KristalEdit_OK = new System.Windows.Forms.Button();
            this.btn_KristalEdit_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_KristalRef
            // 
            this.lbl_KristalRef.AutoSize = true;
            this.lbl_KristalRef.Location = new System.Drawing.Point(12, 17);
            this.lbl_KristalRef.Name = "lbl_KristalRef";
            this.lbl_KristalRef.Size = new System.Drawing.Size(88, 13);
            this.lbl_KristalRef.TabIndex = 49;
            this.lbl_KristalRef.Text = "Kristal Reference";
            // 
            // cb_GrantStage
            // 
            this.cb_GrantStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_GrantStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_GrantStage.FormattingEnabled = true;
            this.cb_GrantStage.Location = new System.Drawing.Point(131, 36);
            this.cb_GrantStage.Name = "cb_GrantStage";
            this.cb_GrantStage.Size = new System.Drawing.Size(143, 21);
            this.cb_GrantStage.TabIndex = 48;
            // 
            // lbl_AppStage
            // 
            this.lbl_AppStage.AutoSize = true;
            this.lbl_AppStage.Location = new System.Drawing.Point(12, 39);
            this.lbl_AppStage.Name = "lbl_AppStage";
            this.lbl_AppStage.Size = new System.Drawing.Size(90, 13);
            this.lbl_AppStage.TabIndex = 47;
            this.lbl_AppStage.Text = "Application Stage";
            // 
            // lbl_KristalRefValue
            // 
            this.lbl_KristalRefValue.AutoSize = true;
            this.lbl_KristalRefValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KristalRefValue.Location = new System.Drawing.Point(127, 9);
            this.lbl_KristalRefValue.Name = "lbl_KristalRefValue";
            this.lbl_KristalRefValue.Size = new System.Drawing.Size(60, 24);
            this.lbl_KristalRefValue.TabIndex = 50;
            this.lbl_KristalRefValue.Text = "label1";
            // 
            // btn_KristalEdit_OK
            // 
            this.btn_KristalEdit_OK.Location = new System.Drawing.Point(112, 63);
            this.btn_KristalEdit_OK.Name = "btn_KristalEdit_OK";
            this.btn_KristalEdit_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_KristalEdit_OK.TabIndex = 51;
            this.btn_KristalEdit_OK.Text = "OK";
            this.btn_KristalEdit_OK.UseVisualStyleBackColor = true;
            this.btn_KristalEdit_OK.Click += new System.EventHandler(this.btn_KristalEdit_OK_Click);
            // 
            // btn_KristalEdit_Cancel
            // 
            this.btn_KristalEdit_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_KristalEdit_Cancel.Location = new System.Drawing.Point(199, 63);
            this.btn_KristalEdit_Cancel.Name = "btn_KristalEdit_Cancel";
            this.btn_KristalEdit_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_KristalEdit_Cancel.TabIndex = 52;
            this.btn_KristalEdit_Cancel.Text = "Cancel";
            this.btn_KristalEdit_Cancel.UseVisualStyleBackColor = true;
            this.btn_KristalEdit_Cancel.Click += new System.EventHandler(this.btn_KristalEdit_Cancel_Click);
            // 
            // frm_ProjectKristalEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_KristalEdit_Cancel;
            this.ClientSize = new System.Drawing.Size(286, 97);
            this.Controls.Add(this.btn_KristalEdit_Cancel);
            this.Controls.Add(this.btn_KristalEdit_OK);
            this.Controls.Add(this.lbl_KristalRefValue);
            this.Controls.Add(this.lbl_KristalRef);
            this.Controls.Add(this.cb_GrantStage);
            this.Controls.Add(this.lbl_AppStage);
            this.Name = "frm_ProjectKristalEdit";
            this.Text = "Edit Kristal Stage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_KristalRef;
        private System.Windows.Forms.ComboBox cb_GrantStage;
        private System.Windows.Forms.Label lbl_AppStage;
        private System.Windows.Forms.Label lbl_KristalRefValue;
        private System.Windows.Forms.Button btn_KristalEdit_OK;
        private System.Windows.Forms.Button btn_KristalEdit_Cancel;
    }
}