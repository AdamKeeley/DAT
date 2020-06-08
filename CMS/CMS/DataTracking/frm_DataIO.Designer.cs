namespace CMS.DataTracking
{
    partial class frm_DataIO
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
            this.dgv_DataIOHistory = new System.Windows.Forms.DataGridView();
            this.lbl_ChangeDateFilter = new System.Windows.Forms.Label();
            this.gb_DataIOHistoryFilterOptions = new System.Windows.Forms.GroupBox();
            this.gb_ChangeTypeFilter = new System.Windows.Forms.GroupBox();
            this.chkb_ChangeTypeDelete = new System.Windows.Forms.CheckBox();
            this.chkb_ChangeTypeExport = new System.Windows.Forms.CheckBox();
            this.chkb_ChangeTypeImport = new System.Windows.Forms.CheckBox();
            this.dtp_DateToFilter = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_ChangeAcceptedFilter = new System.Windows.Forms.GroupBox();
            this.chkb_ChangeAccepted0 = new System.Windows.Forms.CheckBox();
            this.chkb_ChangeAccepted1 = new System.Windows.Forms.CheckBox();
            this.lbl_FilePathFilter = new System.Windows.Forms.Label();
            this.tb_FilePathFilter = new System.Windows.Forms.TextBox();
            this.lbl_ProjectFilter = new System.Windows.Forms.Label();
            this.cb_ProjectFilter = new System.Windows.Forms.ComboBox();
            this.dtp_DateFromFilter = new System.Windows.Forms.DateTimePicker();
            this.btn_NewImportRequest = new System.Windows.Forms.Button();
            this.btn_RefreshAssetsHistoryView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataIOHistory)).BeginInit();
            this.gb_DataIOHistoryFilterOptions.SuspendLayout();
            this.gb_ChangeTypeFilter.SuspendLayout();
            this.gb_ChangeAcceptedFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DataIOHistory
            // 
            this.dgv_DataIOHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataIOHistory.Location = new System.Drawing.Point(12, 159);
            this.dgv_DataIOHistory.Name = "dgv_DataIOHistory";
            this.dgv_DataIOHistory.RowHeadersWidth = 51;
            this.dgv_DataIOHistory.RowTemplate.Height = 24;
            this.dgv_DataIOHistory.Size = new System.Drawing.Size(1038, 391);
            this.dgv_DataIOHistory.TabIndex = 0;
            // 
            // lbl_ChangeDateFilter
            // 
            this.lbl_ChangeDateFilter.AutoSize = true;
            this.lbl_ChangeDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChangeDateFilter.Location = new System.Drawing.Point(254, 34);
            this.lbl_ChangeDateFilter.Name = "lbl_ChangeDateFilter";
            this.lbl_ChangeDateFilter.Size = new System.Drawing.Size(84, 20);
            this.lbl_ChangeDateFilter.TabIndex = 2;
            this.lbl_ChangeDateFilter.Text = "Date from";
            this.lbl_ChangeDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_DataIOHistoryFilterOptions
            // 
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.gb_ChangeTypeFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.dtp_DateToFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.label1);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.gb_ChangeAcceptedFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_FilePathFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.tb_FilePathFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_ProjectFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.cb_ProjectFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.dtp_DateFromFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_ChangeDateFilter);
            this.gb_DataIOHistoryFilterOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataIOHistoryFilterOptions.Location = new System.Drawing.Point(12, 12);
            this.gb_DataIOHistoryFilterOptions.Name = "gb_DataIOHistoryFilterOptions";
            this.gb_DataIOHistoryFilterOptions.Size = new System.Drawing.Size(879, 141);
            this.gb_DataIOHistoryFilterOptions.TabIndex = 3;
            this.gb_DataIOHistoryFilterOptions.TabStop = false;
            this.gb_DataIOHistoryFilterOptions.Text = "Filter I/O history by";
            // 
            // gb_ChangeTypeFilter
            // 
            this.gb_ChangeTypeFilter.Controls.Add(this.chkb_ChangeTypeDelete);
            this.gb_ChangeTypeFilter.Controls.Add(this.chkb_ChangeTypeExport);
            this.gb_ChangeTypeFilter.Controls.Add(this.chkb_ChangeTypeImport);
            this.gb_ChangeTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ChangeTypeFilter.Location = new System.Drawing.Point(378, 74);
            this.gb_ChangeTypeFilter.Name = "gb_ChangeTypeFilter";
            this.gb_ChangeTypeFilter.Size = new System.Drawing.Size(268, 61);
            this.gb_ChangeTypeFilter.TabIndex = 10;
            this.gb_ChangeTypeFilter.TabStop = false;
            this.gb_ChangeTypeFilter.Text = "I/O request type";
            // 
            // chkb_ChangeTypeDelete
            // 
            this.chkb_ChangeTypeDelete.AutoSize = true;
            this.chkb_ChangeTypeDelete.Checked = true;
            this.chkb_ChangeTypeDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeDelete.Location = new System.Drawing.Point(185, 27);
            this.chkb_ChangeTypeDelete.Name = "chkb_ChangeTypeDelete";
            this.chkb_ChangeTypeDelete.Size = new System.Drawing.Size(80, 24);
            this.chkb_ChangeTypeDelete.TabIndex = 2;
            this.chkb_ChangeTypeDelete.Text = "Delete";
            this.chkb_ChangeTypeDelete.UseVisualStyleBackColor = true;
            // 
            // chkb_ChangeTypeExport
            // 
            this.chkb_ChangeTypeExport.AutoSize = true;
            this.chkb_ChangeTypeExport.Checked = true;
            this.chkb_ChangeTypeExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeExport.Location = new System.Drawing.Point(100, 27);
            this.chkb_ChangeTypeExport.Name = "chkb_ChangeTypeExport";
            this.chkb_ChangeTypeExport.Size = new System.Drawing.Size(79, 24);
            this.chkb_ChangeTypeExport.TabIndex = 1;
            this.chkb_ChangeTypeExport.Text = "Export";
            this.chkb_ChangeTypeExport.UseVisualStyleBackColor = true;
            // 
            // chkb_ChangeTypeImport
            // 
            this.chkb_ChangeTypeImport.AutoSize = true;
            this.chkb_ChangeTypeImport.Checked = true;
            this.chkb_ChangeTypeImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeImport.Location = new System.Drawing.Point(16, 27);
            this.chkb_ChangeTypeImport.Name = "chkb_ChangeTypeImport";
            this.chkb_ChangeTypeImport.Size = new System.Drawing.Size(78, 24);
            this.chkb_ChangeTypeImport.TabIndex = 0;
            this.chkb_ChangeTypeImport.Text = "Import";
            this.chkb_ChangeTypeImport.UseVisualStyleBackColor = true;
            // 
            // dtp_DateToFilter
            // 
            this.dtp_DateToFilter.CustomFormat = "";
            this.dtp_DateToFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateToFilter.Location = new System.Drawing.Point(649, 27);
            this.dtp_DateToFilter.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_DateToFilter.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtp_DateToFilter.Name = "dtp_DateToFilter";
            this.dtp_DateToFilter.Size = new System.Drawing.Size(190, 27);
            this.dtp_DateToFilter.TabIndex = 11;
            this.dtp_DateToFilter.Value = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_ChangeAcceptedFilter
            // 
            this.gb_ChangeAcceptedFilter.Controls.Add(this.chkb_ChangeAccepted0);
            this.gb_ChangeAcceptedFilter.Controls.Add(this.chkb_ChangeAccepted1);
            this.gb_ChangeAcceptedFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ChangeAcceptedFilter.Location = new System.Drawing.Point(652, 74);
            this.gb_ChangeAcceptedFilter.Name = "gb_ChangeAcceptedFilter";
            this.gb_ChangeAcceptedFilter.Size = new System.Drawing.Size(221, 61);
            this.gb_ChangeAcceptedFilter.TabIndex = 9;
            this.gb_ChangeAcceptedFilter.TabStop = false;
            this.gb_ChangeAcceptedFilter.Text = "I/O request approval";
            // 
            // chkb_ChangeAccepted0
            // 
            this.chkb_ChangeAccepted0.AutoSize = true;
            this.chkb_ChangeAccepted0.Checked = true;
            this.chkb_ChangeAccepted0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeAccepted0.Location = new System.Drawing.Point(123, 27);
            this.chkb_ChangeAccepted0.Name = "chkb_ChangeAccepted0";
            this.chkb_ChangeAccepted0.Size = new System.Drawing.Size(97, 24);
            this.chkb_ChangeAccepted0.TabIndex = 1;
            this.chkb_ChangeAccepted0.Tag = "0";
            this.chkb_ChangeAccepted0.Text = "Rejected";
            this.chkb_ChangeAccepted0.UseVisualStyleBackColor = true;
            // 
            // chkb_ChangeAccepted1
            // 
            this.chkb_ChangeAccepted1.AutoSize = true;
            this.chkb_ChangeAccepted1.Checked = true;
            this.chkb_ChangeAccepted1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeAccepted1.Location = new System.Drawing.Point(16, 27);
            this.chkb_ChangeAccepted1.Name = "chkb_ChangeAccepted1";
            this.chkb_ChangeAccepted1.Size = new System.Drawing.Size(101, 24);
            this.chkb_ChangeAccepted1.TabIndex = 0;
            this.chkb_ChangeAccepted1.Tag = "1";
            this.chkb_ChangeAccepted1.Text = "Approved";
            this.chkb_ChangeAccepted1.UseVisualStyleBackColor = true;
            // 
            // lbl_FilePathFilter
            // 
            this.lbl_FilePathFilter.AutoSize = true;
            this.lbl_FilePathFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilePathFilter.Location = new System.Drawing.Point(6, 82);
            this.lbl_FilePathFilter.Name = "lbl_FilePathFilter";
            this.lbl_FilePathFilter.Size = new System.Drawing.Size(115, 40);
            this.lbl_FilePathFilter.TabIndex = 7;
            this.lbl_FilePathFilter.Text = "Directory path\r\nto asset file";
            this.lbl_FilePathFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_FilePathFilter
            // 
            this.tb_FilePathFilter.Location = new System.Drawing.Point(127, 89);
            this.tb_FilePathFilter.Name = "tb_FilePathFilter";
            this.tb_FilePathFilter.Size = new System.Drawing.Size(230, 27);
            this.tb_FilePathFilter.TabIndex = 6;
            // 
            // lbl_ProjectFilter
            // 
            this.lbl_ProjectFilter.AutoSize = true;
            this.lbl_ProjectFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectFilter.Location = new System.Drawing.Point(6, 32);
            this.lbl_ProjectFilter.Name = "lbl_ProjectFilter";
            this.lbl_ProjectFilter.Size = new System.Drawing.Size(65, 40);
            this.lbl_ProjectFilter.TabIndex = 5;
            this.lbl_ProjectFilter.Text = "Project\r\nnumber";
            this.lbl_ProjectFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_ProjectFilter
            // 
            this.cb_ProjectFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProjectFilter.FormattingEnabled = true;
            this.cb_ProjectFilter.Location = new System.Drawing.Point(77, 39);
            this.cb_ProjectFilter.Name = "cb_ProjectFilter";
            this.cb_ProjectFilter.Size = new System.Drawing.Size(121, 28);
            this.cb_ProjectFilter.TabIndex = 4;
            // 
            // dtp_DateFromFilter
            // 
            this.dtp_DateFromFilter.CustomFormat = "";
            this.dtp_DateFromFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateFromFilter.Location = new System.Drawing.Point(344, 27);
            this.dtp_DateFromFilter.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_DateFromFilter.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtp_DateFromFilter.Name = "dtp_DateFromFilter";
            this.dtp_DateFromFilter.Size = new System.Drawing.Size(190, 27);
            this.dtp_DateFromFilter.TabIndex = 3;
            this.dtp_DateFromFilter.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // btn_NewImportRequest
            // 
            this.btn_NewImportRequest.Location = new System.Drawing.Point(897, 22);
            this.btn_NewImportRequest.Name = "btn_NewImportRequest";
            this.btn_NewImportRequest.Size = new System.Drawing.Size(153, 40);
            this.btn_NewImportRequest.TabIndex = 4;
            this.btn_NewImportRequest.Text = "New Import";
            this.btn_NewImportRequest.UseVisualStyleBackColor = true;
            // 
            // btn_RefreshAssetsHistoryView
            // 
            this.btn_RefreshAssetsHistoryView.Location = new System.Drawing.Point(897, 113);
            this.btn_RefreshAssetsHistoryView.Name = "btn_RefreshAssetsHistoryView";
            this.btn_RefreshAssetsHistoryView.Size = new System.Drawing.Size(153, 40);
            this.btn_RefreshAssetsHistoryView.TabIndex = 5;
            this.btn_RefreshAssetsHistoryView.Text = "Refresh search";
            this.btn_RefreshAssetsHistoryView.UseVisualStyleBackColor = true;
            this.btn_RefreshAssetsHistoryView.Click += new System.EventHandler(this.btn_RefreshAssetsHistoryView_Click);
            // 
            // frm_DataIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 562);
            this.Controls.Add(this.btn_RefreshAssetsHistoryView);
            this.Controls.Add(this.btn_NewImportRequest);
            this.Controls.Add(this.gb_DataIOHistoryFilterOptions);
            this.Controls.Add(this.dgv_DataIOHistory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DataIO";
            this.Text = "Data Assets I/O History";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataIOHistory)).EndInit();
            this.gb_DataIOHistoryFilterOptions.ResumeLayout(false);
            this.gb_DataIOHistoryFilterOptions.PerformLayout();
            this.gb_ChangeTypeFilter.ResumeLayout(false);
            this.gb_ChangeTypeFilter.PerformLayout();
            this.gb_ChangeAcceptedFilter.ResumeLayout(false);
            this.gb_ChangeAcceptedFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataIOHistory;
        private System.Windows.Forms.Label lbl_ChangeDateFilter;
        private System.Windows.Forms.GroupBox gb_DataIOHistoryFilterOptions;
        private System.Windows.Forms.Label lbl_FilePathFilter;
        private System.Windows.Forms.TextBox tb_FilePathFilter;
        private System.Windows.Forms.Label lbl_ProjectFilter;
        private System.Windows.Forms.ComboBox cb_ProjectFilter;
        private System.Windows.Forms.DateTimePicker dtp_DateFromFilter;
        private System.Windows.Forms.GroupBox gb_ChangeAcceptedFilter;
        private System.Windows.Forms.Button btn_NewImportRequest;
        private System.Windows.Forms.Button btn_RefreshAssetsHistoryView;
        private System.Windows.Forms.DateTimePicker dtp_DateToFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_ChangeTypeFilter;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeExport;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeImport;
        private System.Windows.Forms.CheckBox chkb_ChangeAccepted0;
        private System.Windows.Forms.CheckBox chkb_ChangeAccepted1;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeDelete;
    }
}