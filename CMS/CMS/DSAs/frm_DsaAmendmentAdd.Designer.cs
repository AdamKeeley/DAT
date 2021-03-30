namespace CMS.DSAs
{
    partial class frm_DsaAmendmentAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DsaAmendmentAdd));
            this.dgv_AmendmentList = new System.Windows.Forms.DataGridView();
            this.btn_ConfirmAmendment = new System.Windows.Forms.Button();
            this.lbl_AmendmentList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_AmendmentList
            // 
            this.dgv_AmendmentList.AllowUserToAddRows = false;
            this.dgv_AmendmentList.AllowUserToDeleteRows = false;
            this.dgv_AmendmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AmendmentList.Location = new System.Drawing.Point(13, 60);
            this.dgv_AmendmentList.MultiSelect = false;
            this.dgv_AmendmentList.Name = "dgv_AmendmentList";
            this.dgv_AmendmentList.ReadOnly = true;
            this.dgv_AmendmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AmendmentList.Size = new System.Drawing.Size(596, 233);
            this.dgv_AmendmentList.TabIndex = 0;
            // 
            // btn_ConfirmAmendment
            // 
            this.btn_ConfirmAmendment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConfirmAmendment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConfirmAmendment.Location = new System.Drawing.Point(230, 10);
            this.btn_ConfirmAmendment.Name = "btn_ConfirmAmendment";
            this.btn_ConfirmAmendment.Size = new System.Drawing.Size(177, 29);
            this.btn_ConfirmAmendment.TabIndex = 1;
            this.btn_ConfirmAmendment.Text = "Confirm Amendment";
            this.btn_ConfirmAmendment.UseVisualStyleBackColor = true;
            this.btn_ConfirmAmendment.Click += new System.EventHandler(this.btn_ConfirmAmendment_Click);
            // 
            // lbl_AmendmentList
            // 
            this.lbl_AmendmentList.AutoSize = true;
            this.lbl_AmendmentList.Location = new System.Drawing.Point(13, 44);
            this.lbl_AmendmentList.Name = "lbl_AmendmentList";
            this.lbl_AmendmentList.Size = new System.Drawing.Size(466, 13);
            this.lbl_AmendmentList.TabIndex = 2;
            this.lbl_AmendmentList.Text = "Select the original DSA below then confirm the amendment to update the amendment " +
    "DSA record";
            // 
            // frm_DsaAmendmentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 300);
            this.Controls.Add(this.lbl_AmendmentList);
            this.Controls.Add(this.btn_ConfirmAmendment);
            this.Controls.Add(this.dgv_AmendmentList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_DsaAmendmentAdd";
            this.Text = "Make DSA Record Amend Older DSA";
            this.Load += new System.EventHandler(this.frm_DsaAmendmentAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AmendmentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_AmendmentList;
        private System.Windows.Forms.Button btn_ConfirmAmendment;
        private System.Windows.Forms.Label lbl_AmendmentList;
    }
}