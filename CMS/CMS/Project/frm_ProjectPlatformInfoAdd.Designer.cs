namespace CMS
{
    partial class frm_ProjectPlatformInfoAdd
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
            this.lbl_PlatformItem = new System.Windows.Forms.Label();
            this.cb_PlatformItem = new System.Windows.Forms.ComboBox();
            this.lbl_PlatformItemDescription = new System.Windows.Forms.Label();
            this.tb_PlatformItemDescription = new System.Windows.Forms.TextBox();
            this.btn_ProjectPlatformInfoAdd_Add = new System.Windows.Forms.Button();
            this.btn_ProjectPlatformInfo_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_PlatformItem
            // 
            this.lbl_PlatformItem.AutoSize = true;
            this.lbl_PlatformItem.Location = new System.Drawing.Point(7, 15);
            this.lbl_PlatformItem.Name = "lbl_PlatformItem";
            this.lbl_PlatformItem.Size = new System.Drawing.Size(68, 13);
            this.lbl_PlatformItem.TabIndex = 0;
            this.lbl_PlatformItem.Text = "Platform Item";
            // 
            // cb_PlatformItem
            // 
            this.cb_PlatformItem.FormattingEnabled = true;
            this.cb_PlatformItem.Location = new System.Drawing.Point(81, 12);
            this.cb_PlatformItem.Name = "cb_PlatformItem";
            this.cb_PlatformItem.Size = new System.Drawing.Size(121, 21);
            this.cb_PlatformItem.TabIndex = 1;
            // 
            // lbl_PlatformItemDescription
            // 
            this.lbl_PlatformItemDescription.AutoSize = true;
            this.lbl_PlatformItemDescription.Location = new System.Drawing.Point(15, 42);
            this.lbl_PlatformItemDescription.Name = "lbl_PlatformItemDescription";
            this.lbl_PlatformItemDescription.Size = new System.Drawing.Size(60, 13);
            this.lbl_PlatformItemDescription.TabIndex = 2;
            this.lbl_PlatformItemDescription.Text = "Description";
            // 
            // tb_PlatformItemDescription
            // 
            this.tb_PlatformItemDescription.Location = new System.Drawing.Point(81, 39);
            this.tb_PlatformItemDescription.Name = "tb_PlatformItemDescription";
            this.tb_PlatformItemDescription.Size = new System.Drawing.Size(300, 20);
            this.tb_PlatformItemDescription.TabIndex = 3;
            // 
            // btn_ProjectPlatformInfoAdd_Add
            // 
            this.btn_ProjectPlatformInfoAdd_Add.Location = new System.Drawing.Point(225, 65);
            this.btn_ProjectPlatformInfoAdd_Add.Name = "btn_ProjectPlatformInfoAdd_Add";
            this.btn_ProjectPlatformInfoAdd_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectPlatformInfoAdd_Add.TabIndex = 43;
            this.btn_ProjectPlatformInfoAdd_Add.Text = "Add";
            this.btn_ProjectPlatformInfoAdd_Add.UseVisualStyleBackColor = true;
            this.btn_ProjectPlatformInfoAdd_Add.Click += new System.EventHandler(this.btn_ProjectPlatformInfoAdd_Add_Click);
            // 
            // btn_ProjectPlatformInfo_Cancel
            // 
            this.btn_ProjectPlatformInfo_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ProjectPlatformInfo_Cancel.Location = new System.Drawing.Point(306, 65);
            this.btn_ProjectPlatformInfo_Cancel.Name = "btn_ProjectPlatformInfo_Cancel";
            this.btn_ProjectPlatformInfo_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectPlatformInfo_Cancel.TabIndex = 42;
            this.btn_ProjectPlatformInfo_Cancel.Text = "Cancel";
            this.btn_ProjectPlatformInfo_Cancel.UseVisualStyleBackColor = true;
            this.btn_ProjectPlatformInfo_Cancel.Click += new System.EventHandler(this.btn_ProjectPlatformInfo_Cancel_Click);
            // 
            // frm_ProjectPlatformInfoAdd
            // 
            this.AcceptButton = this.btn_ProjectPlatformInfoAdd_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ProjectPlatformInfo_Cancel;
            this.ClientSize = new System.Drawing.Size(394, 100);
            this.Controls.Add(this.btn_ProjectPlatformInfoAdd_Add);
            this.Controls.Add(this.btn_ProjectPlatformInfo_Cancel);
            this.Controls.Add(this.tb_PlatformItemDescription);
            this.Controls.Add(this.lbl_PlatformItemDescription);
            this.Controls.Add(this.cb_PlatformItem);
            this.Controls.Add(this.lbl_PlatformItem);
            this.Name = "frm_ProjectPlatformInfoAdd";
            this.Text = "Add Project Platform Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PlatformItem;
        private System.Windows.Forms.ComboBox cb_PlatformItem;
        private System.Windows.Forms.Label lbl_PlatformItemDescription;
        private System.Windows.Forms.TextBox tb_PlatformItemDescription;
        private System.Windows.Forms.Button btn_ProjectPlatformInfoAdd_Add;
        private System.Windows.Forms.Button btn_ProjectPlatformInfo_Cancel;
    }
}