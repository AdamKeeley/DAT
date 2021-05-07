namespace CMS.FileTransfers
{
    partial class frm_FileTransfersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FileTransfersView));
            this.dgv_DataIOHistory = new System.Windows.Forms.DataGridView();
            this.lbl_DateFromFilter = new System.Windows.Forms.Label();
            this.gb_DataIOHistoryFilterOptions = new System.Windows.Forms.GroupBox();
            this.gb_TransferMethodFilter = new System.Windows.Forms.GroupBox();
            this.chkb_TransferOther = new System.Windows.Forms.CheckBox();
            this.chkb_TransferBiscom = new System.Windows.Forms.CheckBox();
            this.lbl_DsaFilter = new System.Windows.Forms.Label();
            this.cb_DsaFilter = new System.Windows.Forms.ComboBox();
            this.lbl_DataOwnerFilter = new System.Windows.Forms.Label();
            this.cb_DataOwnerFilter = new System.Windows.Forms.ComboBox();
            this.gb_RequestTypeFilter = new System.Windows.Forms.GroupBox();
            this.chkb_ChangeTypeDelete = new System.Windows.Forms.CheckBox();
            this.chkb_ChangeTypeExport = new System.Windows.Forms.CheckBox();
            this.chkb_ChangeTypeImport = new System.Windows.Forms.CheckBox();
            this.dtp_DateToFilter = new System.Windows.Forms.DateTimePicker();
            this.lbl_DateToFilter = new System.Windows.Forms.Label();
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
            this.gb_TransferMethodFilter.SuspendLayout();
            this.gb_RequestTypeFilter.SuspendLayout();
            this.gb_ChangeAcceptedFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DataIOHistory
            // 
            this.dgv_DataIOHistory.AllowUserToAddRows = false;
            this.dgv_DataIOHistory.AllowUserToDeleteRows = false;
            this.dgv_DataIOHistory.AllowUserToOrderColumns = true;
            this.dgv_DataIOHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataIOHistory.Location = new System.Drawing.Point(8, 225);
            this.dgv_DataIOHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_DataIOHistory.Name = "dgv_DataIOHistory";
            this.dgv_DataIOHistory.ReadOnly = true;
            this.dgv_DataIOHistory.RowHeadersWidth = 51;
            this.dgv_DataIOHistory.RowTemplate.Height = 24;
            this.dgv_DataIOHistory.Size = new System.Drawing.Size(772, 413);
            this.dgv_DataIOHistory.TabIndex = 0;
            // 
            // lbl_DateFromFilter
            // 
            this.lbl_DateFromFilter.AutoSize = true;
            this.lbl_DateFromFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DateFromFilter.Location = new System.Drawing.Point(464, 113);
            this.lbl_DateFromFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DateFromFilter.Name = "lbl_DateFromFilter";
            this.lbl_DateFromFilter.Size = new System.Drawing.Size(38, 34);
            this.lbl_DateFromFilter.TabIndex = 2;
            this.lbl_DateFromFilter.Text = "Date\r\nfrom";
            this.lbl_DateFromFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_DataIOHistoryFilterOptions
            // 
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.gb_TransferMethodFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_DsaFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.cb_DsaFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_DataOwnerFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.cb_DataOwnerFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.gb_RequestTypeFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.dtp_DateToFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_DateToFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.gb_ChangeAcceptedFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_FilePathFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.tb_FilePathFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_ProjectFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.cb_ProjectFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.dtp_DateFromFilter);
            this.gb_DataIOHistoryFilterOptions.Controls.Add(this.lbl_DateFromFilter);
            this.gb_DataIOHistoryFilterOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataIOHistoryFilterOptions.Location = new System.Drawing.Point(10, 10);
            this.gb_DataIOHistoryFilterOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_DataIOHistoryFilterOptions.Name = "gb_DataIOHistoryFilterOptions";
            this.gb_DataIOHistoryFilterOptions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_DataIOHistoryFilterOptions.Size = new System.Drawing.Size(677, 211);
            this.gb_DataIOHistoryFilterOptions.TabIndex = 3;
            this.gb_DataIOHistoryFilterOptions.TabStop = false;
            this.gb_DataIOHistoryFilterOptions.Text = "Filter I/O history by";
            // 
            // gb_TransferMethodFilter
            // 
            this.gb_TransferMethodFilter.Controls.Add(this.chkb_TransferOther);
            this.gb_TransferMethodFilter.Controls.Add(this.chkb_TransferBiscom);
            this.gb_TransferMethodFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_TransferMethodFilter.Location = new System.Drawing.Point(299, 116);
            this.gb_TransferMethodFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_TransferMethodFilter.Name = "gb_TransferMethodFilter";
            this.gb_TransferMethodFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_TransferMethodFilter.Size = new System.Drawing.Size(134, 83);
            this.gb_TransferMethodFilter.TabIndex = 10;
            this.gb_TransferMethodFilter.TabStop = false;
            this.gb_TransferMethodFilter.Text = "Transfer method";
            // 
            // chkb_TransferOther
            // 
            this.chkb_TransferOther.AutoSize = true;
            this.chkb_TransferOther.Checked = true;
            this.chkb_TransferOther.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_TransferOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_TransferOther.Location = new System.Drawing.Point(13, 52);
            this.chkb_TransferOther.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_TransferOther.Name = "chkb_TransferOther";
            this.chkb_TransferOther.Size = new System.Drawing.Size(66, 21);
            this.chkb_TransferOther.TabIndex = 1;
            this.chkb_TransferOther.Tag = "0";
            this.chkb_TransferOther.Text = "Other";
            this.chkb_TransferOther.UseVisualStyleBackColor = true;
            // 
            // chkb_TransferBiscom
            // 
            this.chkb_TransferBiscom.AutoSize = true;
            this.chkb_TransferBiscom.Checked = true;
            this.chkb_TransferBiscom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_TransferBiscom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_TransferBiscom.Location = new System.Drawing.Point(13, 23);
            this.chkb_TransferBiscom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_TransferBiscom.Name = "chkb_TransferBiscom";
            this.chkb_TransferBiscom.Size = new System.Drawing.Size(105, 21);
            this.chkb_TransferBiscom.TabIndex = 0;
            this.chkb_TransferBiscom.Tag = "1";
            this.chkb_TransferBiscom.Text = "SFT Biscom";
            this.chkb_TransferBiscom.UseVisualStyleBackColor = true;
            // 
            // lbl_DsaFilter
            // 
            this.lbl_DsaFilter.AutoSize = true;
            this.lbl_DsaFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DsaFilter.Location = new System.Drawing.Point(357, 35);
            this.lbl_DsaFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DsaFilter.Name = "lbl_DsaFilter";
            this.lbl_DsaFilter.Size = new System.Drawing.Size(36, 17);
            this.lbl_DsaFilter.TabIndex = 15;
            this.lbl_DsaFilter.Text = "DSA";
            this.lbl_DsaFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_DsaFilter
            // 
            this.cb_DsaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DsaFilter.FormattingEnabled = true;
            this.cb_DsaFilter.Location = new System.Drawing.Point(397, 32);
            this.cb_DsaFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_DsaFilter.Name = "cb_DsaFilter";
            this.cb_DsaFilter.Size = new System.Drawing.Size(265, 24);
            this.cb_DsaFilter.TabIndex = 14;
            // 
            // lbl_DataOwnerFilter
            // 
            this.lbl_DataOwnerFilter.AutoSize = true;
            this.lbl_DataOwnerFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataOwnerFilter.Location = new System.Drawing.Point(23, 64);
            this.lbl_DataOwnerFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DataOwnerFilter.Name = "lbl_DataOwnerFilter";
            this.lbl_DataOwnerFilter.Size = new System.Drawing.Size(46, 34);
            this.lbl_DataOwnerFilter.TabIndex = 13;
            this.lbl_DataOwnerFilter.Text = "Data\r\nowner";
            this.lbl_DataOwnerFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_DataOwnerFilter
            // 
            this.cb_DataOwnerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DataOwnerFilter.FormattingEnabled = true;
            this.cb_DataOwnerFilter.Location = new System.Drawing.Point(74, 70);
            this.cb_DataOwnerFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_DataOwnerFilter.Name = "cb_DataOwnerFilter";
            this.cb_DataOwnerFilter.Size = new System.Drawing.Size(163, 24);
            this.cb_DataOwnerFilter.TabIndex = 12;
            // 
            // gb_RequestTypeFilter
            // 
            this.gb_RequestTypeFilter.Controls.Add(this.chkb_ChangeTypeDelete);
            this.gb_RequestTypeFilter.Controls.Add(this.chkb_ChangeTypeExport);
            this.gb_RequestTypeFilter.Controls.Add(this.chkb_ChangeTypeImport);
            this.gb_RequestTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_RequestTypeFilter.Location = new System.Drawing.Point(17, 157);
            this.gb_RequestTypeFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_RequestTypeFilter.Name = "gb_RequestTypeFilter";
            this.gb_RequestTypeFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_RequestTypeFilter.Size = new System.Drawing.Size(229, 49);
            this.gb_RequestTypeFilter.TabIndex = 10;
            this.gb_RequestTypeFilter.TabStop = false;
            this.gb_RequestTypeFilter.Text = "I/O request type";
            // 
            // chkb_ChangeTypeDelete
            // 
            this.chkb_ChangeTypeDelete.AutoSize = true;
            this.chkb_ChangeTypeDelete.Checked = true;
            this.chkb_ChangeTypeDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ChangeTypeDelete.Location = new System.Drawing.Point(154, 21);
            this.chkb_ChangeTypeDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_ChangeTypeDelete.Name = "chkb_ChangeTypeDelete";
            this.chkb_ChangeTypeDelete.Size = new System.Drawing.Size(71, 21);
            this.chkb_ChangeTypeDelete.TabIndex = 2;
            this.chkb_ChangeTypeDelete.Text = "Delete";
            this.chkb_ChangeTypeDelete.UseVisualStyleBackColor = true;
            // 
            // chkb_ChangeTypeExport
            // 
            this.chkb_ChangeTypeExport.AutoSize = true;
            this.chkb_ChangeTypeExport.Checked = true;
            this.chkb_ChangeTypeExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ChangeTypeExport.Location = new System.Drawing.Point(80, 22);
            this.chkb_ChangeTypeExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_ChangeTypeExport.Name = "chkb_ChangeTypeExport";
            this.chkb_ChangeTypeExport.Size = new System.Drawing.Size(70, 21);
            this.chkb_ChangeTypeExport.TabIndex = 1;
            this.chkb_ChangeTypeExport.Text = "Export";
            this.chkb_ChangeTypeExport.UseVisualStyleBackColor = true;
            // 
            // chkb_ChangeTypeImport
            // 
            this.chkb_ChangeTypeImport.AutoSize = true;
            this.chkb_ChangeTypeImport.Checked = true;
            this.chkb_ChangeTypeImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeTypeImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ChangeTypeImport.Location = new System.Drawing.Point(13, 22);
            this.chkb_ChangeTypeImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_ChangeTypeImport.Name = "chkb_ChangeTypeImport";
            this.chkb_ChangeTypeImport.Size = new System.Drawing.Size(69, 21);
            this.chkb_ChangeTypeImport.TabIndex = 0;
            this.chkb_ChangeTypeImport.Text = "Import";
            this.chkb_ChangeTypeImport.UseVisualStyleBackColor = true;
            // 
            // dtp_DateToFilter
            // 
            this.dtp_DateToFilter.CustomFormat = "";
            this.dtp_DateToFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateToFilter.Location = new System.Drawing.Point(505, 159);
            this.dtp_DateToFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_DateToFilter.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_DateToFilter.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtp_DateToFilter.Name = "dtp_DateToFilter";
            this.dtp_DateToFilter.Size = new System.Drawing.Size(157, 22);
            this.dtp_DateToFilter.TabIndex = 11;
            this.dtp_DateToFilter.Value = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            // 
            // lbl_DateToFilter
            // 
            this.lbl_DateToFilter.AutoSize = true;
            this.lbl_DateToFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DateToFilter.Location = new System.Drawing.Point(464, 153);
            this.lbl_DateToFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DateToFilter.Name = "lbl_DateToFilter";
            this.lbl_DateToFilter.Size = new System.Drawing.Size(38, 34);
            this.lbl_DateToFilter.TabIndex = 10;
            this.lbl_DateToFilter.Text = "Date\r\nto";
            this.lbl_DateToFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_ChangeAcceptedFilter
            // 
            this.gb_ChangeAcceptedFilter.Controls.Add(this.chkb_ChangeAccepted0);
            this.gb_ChangeAcceptedFilter.Controls.Add(this.chkb_ChangeAccepted1);
            this.gb_ChangeAcceptedFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ChangeAcceptedFilter.Location = new System.Drawing.Point(17, 104);
            this.gb_ChangeAcceptedFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_ChangeAcceptedFilter.Name = "gb_ChangeAcceptedFilter";
            this.gb_ChangeAcceptedFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_ChangeAcceptedFilter.Size = new System.Drawing.Size(229, 49);
            this.gb_ChangeAcceptedFilter.TabIndex = 9;
            this.gb_ChangeAcceptedFilter.TabStop = false;
            this.gb_ChangeAcceptedFilter.Text = "I/O request approval";
            // 
            // chkb_ChangeAccepted0
            // 
            this.chkb_ChangeAccepted0.AutoSize = true;
            this.chkb_ChangeAccepted0.Checked = true;
            this.chkb_ChangeAccepted0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkb_ChangeAccepted0.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ChangeAccepted0.Location = new System.Drawing.Point(133, 22);
            this.chkb_ChangeAccepted0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_ChangeAccepted0.Name = "chkb_ChangeAccepted0";
            this.chkb_ChangeAccepted0.Size = new System.Drawing.Size(86, 21);
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
            this.chkb_ChangeAccepted1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkb_ChangeAccepted1.Location = new System.Drawing.Point(13, 22);
            this.chkb_ChangeAccepted1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkb_ChangeAccepted1.Name = "chkb_ChangeAccepted1";
            this.chkb_ChangeAccepted1.Size = new System.Drawing.Size(91, 21);
            this.chkb_ChangeAccepted1.TabIndex = 0;
            this.chkb_ChangeAccepted1.Tag = "1";
            this.chkb_ChangeAccepted1.Text = "Approved";
            this.chkb_ChangeAccepted1.UseVisualStyleBackColor = true;
            // 
            // lbl_FilePathFilter
            // 
            this.lbl_FilePathFilter.AutoSize = true;
            this.lbl_FilePathFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilePathFilter.Location = new System.Drawing.Point(296, 63);
            this.lbl_FilePathFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FilePathFilter.Name = "lbl_FilePathFilter";
            this.lbl_FilePathFilter.Size = new System.Drawing.Size(97, 34);
            this.lbl_FilePathFilter.TabIndex = 7;
            this.lbl_FilePathFilter.Text = "Directory path\r\nto asset file";
            this.lbl_FilePathFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_FilePathFilter
            // 
            this.tb_FilePathFilter.Location = new System.Drawing.Point(397, 69);
            this.tb_FilePathFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_FilePathFilter.Name = "tb_FilePathFilter";
            this.tb_FilePathFilter.Size = new System.Drawing.Size(265, 22);
            this.tb_FilePathFilter.TabIndex = 6;
            // 
            // lbl_ProjectFilter
            // 
            this.lbl_ProjectFilter.AutoSize = true;
            this.lbl_ProjectFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectFilter.Location = new System.Drawing.Point(14, 26);
            this.lbl_ProjectFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProjectFilter.Name = "lbl_ProjectFilter";
            this.lbl_ProjectFilter.Size = new System.Drawing.Size(56, 34);
            this.lbl_ProjectFilter.TabIndex = 5;
            this.lbl_ProjectFilter.Text = "Project\r\nnumber";
            this.lbl_ProjectFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_ProjectFilter
            // 
            this.cb_ProjectFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProjectFilter.FormattingEnabled = true;
            this.cb_ProjectFilter.Location = new System.Drawing.Point(74, 32);
            this.cb_ProjectFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_ProjectFilter.Name = "cb_ProjectFilter";
            this.cb_ProjectFilter.Size = new System.Drawing.Size(98, 24);
            this.cb_ProjectFilter.TabIndex = 4;
            // 
            // dtp_DateFromFilter
            // 
            this.dtp_DateFromFilter.CustomFormat = "";
            this.dtp_DateFromFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateFromFilter.Location = new System.Drawing.Point(505, 120);
            this.dtp_DateFromFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_DateFromFilter.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_DateFromFilter.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_DateFromFilter.Name = "dtp_DateFromFilter";
            this.dtp_DateFromFilter.Size = new System.Drawing.Size(157, 22);
            this.dtp_DateFromFilter.TabIndex = 3;
            this.dtp_DateFromFilter.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // btn_NewImportRequest
            // 
            this.btn_NewImportRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewImportRequest.Location = new System.Drawing.Point(710, 16);
            this.btn_NewImportRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_NewImportRequest.Name = "btn_NewImportRequest";
            this.btn_NewImportRequest.Size = new System.Drawing.Size(70, 46);
            this.btn_NewImportRequest.TabIndex = 4;
            this.btn_NewImportRequest.Text = "New Import";
            this.btn_NewImportRequest.UseVisualStyleBackColor = true;
            this.btn_NewImportRequest.Click += new System.EventHandler(this.btn_NewImportRequest_Click);
            // 
            // btn_RefreshAssetsHistoryView
            // 
            this.btn_RefreshAssetsHistoryView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RefreshAssetsHistoryView.Location = new System.Drawing.Point(710, 79);
            this.btn_RefreshAssetsHistoryView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_RefreshAssetsHistoryView.Name = "btn_RefreshAssetsHistoryView";
            this.btn_RefreshAssetsHistoryView.Size = new System.Drawing.Size(70, 45);
            this.btn_RefreshAssetsHistoryView.TabIndex = 5;
            this.btn_RefreshAssetsHistoryView.Text = "Refresh search";
            this.btn_RefreshAssetsHistoryView.UseVisualStyleBackColor = true;
            this.btn_RefreshAssetsHistoryView.Click += new System.EventHandler(this.btn_RefreshAssetsHistoryView_Click);
            // 
            // frm_FileTransfersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 649);
            this.Controls.Add(this.btn_RefreshAssetsHistoryView);
            this.Controls.Add(this.btn_NewImportRequest);
            this.Controls.Add(this.gb_DataIOHistoryFilterOptions);
            this.Controls.Add(this.dgv_DataIOHistory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FileTransfersView";
            this.Text = "View File Transfers Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataIOHistory)).EndInit();
            this.gb_DataIOHistoryFilterOptions.ResumeLayout(false);
            this.gb_DataIOHistoryFilterOptions.PerformLayout();
            this.gb_TransferMethodFilter.ResumeLayout(false);
            this.gb_TransferMethodFilter.PerformLayout();
            this.gb_RequestTypeFilter.ResumeLayout(false);
            this.gb_RequestTypeFilter.PerformLayout();
            this.gb_ChangeAcceptedFilter.ResumeLayout(false);
            this.gb_ChangeAcceptedFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataIOHistory;
        private System.Windows.Forms.Label lbl_DateFromFilter;
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
        private System.Windows.Forms.Label lbl_DateToFilter;
        private System.Windows.Forms.GroupBox gb_RequestTypeFilter;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeExport;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeImport;
        private System.Windows.Forms.CheckBox chkb_ChangeAccepted0;
        private System.Windows.Forms.CheckBox chkb_ChangeAccepted1;
        private System.Windows.Forms.CheckBox chkb_ChangeTypeDelete;
        private System.Windows.Forms.Label lbl_DataOwnerFilter;
        private System.Windows.Forms.ComboBox cb_DataOwnerFilter;
        private System.Windows.Forms.Label lbl_DsaFilter;
        private System.Windows.Forms.ComboBox cb_DsaFilter;
        private System.Windows.Forms.GroupBox gb_TransferMethodFilter;
        private System.Windows.Forms.CheckBox chkb_TransferOther;
        private System.Windows.Forms.CheckBox chkb_TransferBiscom;
    }
}