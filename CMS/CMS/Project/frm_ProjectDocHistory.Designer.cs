namespace CMS
{
    partial class frm_ProjectDocHistory
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
            this.lbl_ProjectNumber = new System.Windows.Forms.Label();
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.btn_ProjectDocAdd = new System.Windows.Forms.Button();
            this.dgv_ProjectDocHistory = new System.Windows.Forms.DataGridView();
            this.btn_ProjectDocAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectDocHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProjectNumber
            // 
            this.lbl_ProjectNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectNumber.Location = new System.Drawing.Point(12, 9);
            this.lbl_ProjectNumber.Name = "lbl_ProjectNumber";
            this.lbl_ProjectNumber.Size = new System.Drawing.Size(75, 55);
            this.lbl_ProjectNumber.TabIndex = 0;
            this.lbl_ProjectNumber.Text = "Project Number";
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectName.Location = new System.Drawing.Point(93, 9);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(211, 55);
            this.lbl_ProjectName.TabIndex = 1;
            this.lbl_ProjectName.Text = "Project Name";
            // 
            // btn_ProjectDocAdd
            // 
            this.btn_ProjectDocAdd.Location = new System.Drawing.Point(310, 9);
            this.btn_ProjectDocAdd.Name = "btn_ProjectDocAdd";
            this.btn_ProjectDocAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectDocAdd.TabIndex = 2;
            this.btn_ProjectDocAdd.Text = "Add Document";
            this.btn_ProjectDocAdd.UseVisualStyleBackColor = true;
            // 
            // dgv_ProjectDocHistory
            // 
            this.dgv_ProjectDocHistory.AllowUserToAddRows = false;
            this.dgv_ProjectDocHistory.AllowUserToDeleteRows = false;
            this.dgv_ProjectDocHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProjectDocHistory.Location = new System.Drawing.Point(12, 67);
            this.dgv_ProjectDocHistory.Name = "dgv_ProjectDocHistory";
            this.dgv_ProjectDocHistory.ReadOnly = true;
            this.dgv_ProjectDocHistory.Size = new System.Drawing.Size(373, 150);
            this.dgv_ProjectDocHistory.TabIndex = 3;
            // 
            // btn_ProjectDocAccept
            // 
            this.btn_ProjectDocAccept.Location = new System.Drawing.Point(310, 38);
            this.btn_ProjectDocAccept.Name = "btn_ProjectDocAccept";
            this.btn_ProjectDocAccept.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectDocAccept.TabIndex = 4;
            this.btn_ProjectDocAccept.Text = "Accept Document";
            this.btn_ProjectDocAccept.UseVisualStyleBackColor = true;
            // 
            // frm_ProjectDocHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 231);
            this.Controls.Add(this.btn_ProjectDocAccept);
            this.Controls.Add(this.dgv_ProjectDocHistory);
            this.Controls.Add(this.btn_ProjectDocAdd);
            this.Controls.Add(this.lbl_ProjectName);
            this.Controls.Add(this.lbl_ProjectNumber);
            this.Name = "frm_ProjectDocHistory";
            this.Text = "frm_ProjectDocHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectDocHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProjectNumber;
        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.Button btn_ProjectDocAdd;
        private System.Windows.Forms.DataGridView dgv_ProjectDocHistory;
        private System.Windows.Forms.Button btn_ProjectDocAccept;
    }
}