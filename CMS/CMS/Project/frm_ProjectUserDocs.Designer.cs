namespace CMS
{
    partial class frm_ProjectUserDocs
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
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.lbl_ProjectNumber = new System.Windows.Forms.Label();
            this.dgv_ProjectUserDocs = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectUserDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectName.Location = new System.Drawing.Point(93, 9);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(211, 55);
            this.lbl_ProjectName.TabIndex = 7;
            this.lbl_ProjectName.Text = "Project Name";
            // 
            // lbl_ProjectNumber
            // 
            this.lbl_ProjectNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectNumber.Location = new System.Drawing.Point(12, 9);
            this.lbl_ProjectNumber.Name = "lbl_ProjectNumber";
            this.lbl_ProjectNumber.Size = new System.Drawing.Size(75, 55);
            this.lbl_ProjectNumber.TabIndex = 6;
            this.lbl_ProjectNumber.Text = "Project Number";
            // 
            // dgv_ProjectUserDocs
            // 
            this.dgv_ProjectUserDocs.AllowUserToAddRows = false;
            this.dgv_ProjectUserDocs.AllowUserToDeleteRows = false;
            this.dgv_ProjectUserDocs.AllowUserToOrderColumns = true;
            this.dgv_ProjectUserDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProjectUserDocs.Location = new System.Drawing.Point(13, 68);
            this.dgv_ProjectUserDocs.Name = "dgv_ProjectUserDocs";
            this.dgv_ProjectUserDocs.ReadOnly = true;
            this.dgv_ProjectUserDocs.Size = new System.Drawing.Size(480, 300);
            this.dgv_ProjectUserDocs.TabIndex = 8;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(417, 375);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_ProjectUserDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 406);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgv_ProjectUserDocs);
            this.Controls.Add(this.lbl_ProjectName);
            this.Controls.Add(this.lbl_ProjectNumber);
            this.Name = "frm_ProjectUserDocs";
            this.Text = "frm_ProjectUserDocs";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectUserDocs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.Label lbl_ProjectNumber;
        private System.Windows.Forms.DataGridView dgv_ProjectUserDocs;
        private System.Windows.Forms.Button btn_OK;
    }
}