namespace CMS
{
    partial class frm_DsaDataOwnerAdd
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
            this.tb_NewDataOwnerName = new System.Windows.Forms.TextBox();
            this.btn_NewDataOwner = new System.Windows.Forms.Button();
            this.gb_DataOwners = new System.Windows.Forms.GroupBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dgv_DataOwners = new System.Windows.Forms.DataGridView();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.gb_AddDataOwner = new System.Windows.Forms.GroupBox();
            this.cb_RebrandingOfOldName = new System.Windows.Forms.ComboBox();
            this.lbl_RebrandingOfOldName = new System.Windows.Forms.Label();
            this.lbl_NewDataOwnerName = new System.Windows.Forms.Label();
            this.gb_DataOwners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataOwners)).BeginInit();
            this.gb_AddDataOwner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_NewDataOwnerName
            // 
            this.tb_NewDataOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_NewDataOwnerName.Location = new System.Drawing.Point(231, 24);
            this.tb_NewDataOwnerName.Name = "tb_NewDataOwnerName";
            this.tb_NewDataOwnerName.Size = new System.Drawing.Size(367, 27);
            this.tb_NewDataOwnerName.TabIndex = 0;
            // 
            // btn_NewDataOwner
            // 
            this.btn_NewDataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewDataOwner.Location = new System.Drawing.Point(482, 106);
            this.btn_NewDataOwner.Name = "btn_NewDataOwner";
            this.btn_NewDataOwner.Size = new System.Drawing.Size(199, 33);
            this.btn_NewDataOwner.TabIndex = 1;
            this.btn_NewDataOwner.Text = "Add Data Owner";
            this.btn_NewDataOwner.UseVisualStyleBackColor = true;
            this.btn_NewDataOwner.Click += new System.EventHandler(this.btn_NewDataOwner_Click);
            // 
            // gb_DataOwners
            // 
            this.gb_DataOwners.Controls.Add(this.btn_Search);
            this.gb_DataOwners.Controls.Add(this.dgv_DataOwners);
            this.gb_DataOwners.Controls.Add(this.tb_Search);
            this.gb_DataOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataOwners.Location = new System.Drawing.Point(39, 168);
            this.gb_DataOwners.Name = "gb_DataOwners";
            this.gb_DataOwners.Size = new System.Drawing.Size(724, 335);
            this.gb_DataOwners.TabIndex = 2;
            this.gb_DataOwners.TabStop = false;
            this.gb_DataOwners.Text = "List of Existing Data Owners";
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(482, 27);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(199, 32);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dgv_DataOwners
            // 
            this.dgv_DataOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataOwners.Location = new System.Drawing.Point(6, 68);
            this.dgv_DataOwners.Name = "dgv_DataOwners";
            this.dgv_DataOwners.RowHeadersWidth = 51;
            this.dgv_DataOwners.RowTemplate.Height = 24;
            this.dgv_DataOwners.Size = new System.Drawing.Size(711, 261);
            this.dgv_DataOwners.TabIndex = 0;
            // 
            // tb_Search
            // 
            this.tb_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.Location = new System.Drawing.Point(59, 29);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(367, 27);
            this.tb_Search.TabIndex = 3;
            // 
            // gb_AddDataOwner
            // 
            this.gb_AddDataOwner.Controls.Add(this.cb_RebrandingOfOldName);
            this.gb_AddDataOwner.Controls.Add(this.lbl_RebrandingOfOldName);
            this.gb_AddDataOwner.Controls.Add(this.lbl_NewDataOwnerName);
            this.gb_AddDataOwner.Controls.Add(this.btn_NewDataOwner);
            this.gb_AddDataOwner.Controls.Add(this.tb_NewDataOwnerName);
            this.gb_AddDataOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_AddDataOwner.Location = new System.Drawing.Point(39, 12);
            this.gb_AddDataOwner.Name = "gb_AddDataOwner";
            this.gb_AddDataOwner.Size = new System.Drawing.Size(724, 150);
            this.gb_AddDataOwner.TabIndex = 3;
            this.gb_AddDataOwner.TabStop = false;
            this.gb_AddDataOwner.Text = "New Data Owner";
            // 
            // cb_RebrandingOfOldName
            // 
            this.cb_RebrandingOfOldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_RebrandingOfOldName.FormattingEnabled = true;
            this.cb_RebrandingOfOldName.Location = new System.Drawing.Point(231, 71);
            this.cb_RebrandingOfOldName.Name = "cb_RebrandingOfOldName";
            this.cb_RebrandingOfOldName.Size = new System.Drawing.Size(222, 28);
            this.cb_RebrandingOfOldName.TabIndex = 4;
            // 
            // lbl_RebrandingOfOldName
            // 
            this.lbl_RebrandingOfOldName.AutoSize = true;
            this.lbl_RebrandingOfOldName.Location = new System.Drawing.Point(19, 64);
            this.lbl_RebrandingOfOldName.Name = "lbl_RebrandingOfOldName";
            this.lbl_RebrandingOfOldName.Size = new System.Drawing.Size(157, 40);
            this.lbl_RebrandingOfOldName.TabIndex = 3;
            this.lbl_RebrandingOfOldName.Text = "Rebranding of Old\r\nData Owner Name?";
            // 
            // lbl_NewDataOwnerName
            // 
            this.lbl_NewDataOwnerName.AutoSize = true;
            this.lbl_NewDataOwnerName.Location = new System.Drawing.Point(19, 24);
            this.lbl_NewDataOwnerName.Name = "lbl_NewDataOwnerName";
            this.lbl_NewDataOwnerName.Size = new System.Drawing.Size(148, 20);
            this.lbl_NewDataOwnerName.TabIndex = 2;
            this.lbl_NewDataOwnerName.Text = "Data Owner Name";
            // 
            // frm_DsaDataOwnerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.gb_AddDataOwner);
            this.Controls.Add(this.gb_DataOwners);
            this.Name = "frm_DsaDataOwnerAdd";
            this.Text = "Add a New Data Owner";
            this.gb_DataOwners.ResumeLayout(false);
            this.gb_DataOwners.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataOwners)).EndInit();
            this.gb_AddDataOwner.ResumeLayout(false);
            this.gb_AddDataOwner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_NewDataOwnerName;
        private System.Windows.Forms.Button btn_NewDataOwner;
        private System.Windows.Forms.GroupBox gb_DataOwners;
        private System.Windows.Forms.DataGridView dgv_DataOwners;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.GroupBox gb_AddDataOwner;
        private System.Windows.Forms.ComboBox cb_RebrandingOfOldName;
        private System.Windows.Forms.Label lbl_RebrandingOfOldName;
        private System.Windows.Forms.Label lbl_NewDataOwnerName;
    }
}