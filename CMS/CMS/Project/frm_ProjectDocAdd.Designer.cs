namespace CMS
{
    partial class frm_ProjectDocAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectDocAdd));
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.lbl_ProjectNumber = new System.Windows.Forms.Label();
            this.cb_DocType = new System.Windows.Forms.ComboBox();
            this.lbl_DocType = new System.Windows.Forms.Label();
            this.lbl_DocVersion = new System.Windows.Forms.Label();
            this.nud_DocVersion = new System.Windows.Forms.NumericUpDown();
            this.lbl_DocSubmitted = new System.Windows.Forms.Label();
            this.mtb_DocSubmitted = new System.Windows.Forms.MaskedTextBox();
            this.mtb_DocAccepted = new System.Windows.Forms.MaskedTextBox();
            this.lbl_DocAccepted = new System.Windows.Forms.Label();
            this.btn_DocAddCreate = new System.Windows.Forms.Button();
            this.btn_DocAddCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DocVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectName.Location = new System.Drawing.Point(94, 9);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(292, 55);
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
            // cb_DocType
            // 
            this.cb_DocType.FormattingEnabled = true;
            this.cb_DocType.Location = new System.Drawing.Point(101, 61);
            this.cb_DocType.Name = "cb_DocType";
            this.cb_DocType.Size = new System.Drawing.Size(204, 21);
            this.cb_DocType.TabIndex = 8;
            this.cb_DocType.SelectedIndexChanged += new System.EventHandler(this.cb_DocType_SelectedIndexChanged);
            // 
            // lbl_DocType
            // 
            this.lbl_DocType.AutoSize = true;
            this.lbl_DocType.Location = new System.Drawing.Point(12, 64);
            this.lbl_DocType.Name = "lbl_DocType";
            this.lbl_DocType.Size = new System.Drawing.Size(83, 13);
            this.lbl_DocType.TabIndex = 9;
            this.lbl_DocType.Text = "Document Type";
            // 
            // lbl_DocVersion
            // 
            this.lbl_DocVersion.AutoSize = true;
            this.lbl_DocVersion.Location = new System.Drawing.Point(12, 90);
            this.lbl_DocVersion.Name = "lbl_DocVersion";
            this.lbl_DocVersion.Size = new System.Drawing.Size(42, 13);
            this.lbl_DocVersion.TabIndex = 10;
            this.lbl_DocVersion.Text = "Version";
            // 
            // nud_DocVersion
            // 
            this.nud_DocVersion.DecimalPlaces = 2;
            this.nud_DocVersion.Location = new System.Drawing.Point(101, 88);
            this.nud_DocVersion.Name = "nud_DocVersion";
            this.nud_DocVersion.Size = new System.Drawing.Size(120, 20);
            this.nud_DocVersion.TabIndex = 11;
            this.nud_DocVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_DocSubmitted
            // 
            this.lbl_DocSubmitted.AutoSize = true;
            this.lbl_DocSubmitted.Location = new System.Drawing.Point(12, 116);
            this.lbl_DocSubmitted.Name = "lbl_DocSubmitted";
            this.lbl_DocSubmitted.Size = new System.Drawing.Size(54, 13);
            this.lbl_DocSubmitted.TabIndex = 12;
            this.lbl_DocSubmitted.Text = "Submitted";
            // 
            // mtb_DocSubmitted
            // 
            this.mtb_DocSubmitted.Location = new System.Drawing.Point(101, 113);
            this.mtb_DocSubmitted.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_DocSubmitted.Mask = "00/00/0000";
            this.mtb_DocSubmitted.Name = "mtb_DocSubmitted";
            this.mtb_DocSubmitted.Size = new System.Drawing.Size(76, 20);
            this.mtb_DocSubmitted.TabIndex = 37;
            this.mtb_DocSubmitted.ValidatingType = typeof(System.DateTime);
            this.mtb_DocSubmitted.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // mtb_DocAccepted
            // 
            this.mtb_DocAccepted.Location = new System.Drawing.Point(101, 137);
            this.mtb_DocAccepted.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_DocAccepted.Mask = "00/00/0000";
            this.mtb_DocAccepted.Name = "mtb_DocAccepted";
            this.mtb_DocAccepted.Size = new System.Drawing.Size(76, 20);
            this.mtb_DocAccepted.TabIndex = 38;
            this.mtb_DocAccepted.ValidatingType = typeof(System.DateTime);
            this.mtb_DocAccepted.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // lbl_DocAccepted
            // 
            this.lbl_DocAccepted.AutoSize = true;
            this.lbl_DocAccepted.Location = new System.Drawing.Point(12, 140);
            this.lbl_DocAccepted.Name = "lbl_DocAccepted";
            this.lbl_DocAccepted.Size = new System.Drawing.Size(53, 13);
            this.lbl_DocAccepted.TabIndex = 39;
            this.lbl_DocAccepted.Text = "Accepted";
            // 
            // btn_DocAddCreate
            // 
            this.btn_DocAddCreate.Location = new System.Drawing.Point(230, 134);
            this.btn_DocAddCreate.Name = "btn_DocAddCreate";
            this.btn_DocAddCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_DocAddCreate.TabIndex = 40;
            this.btn_DocAddCreate.Text = "Create";
            this.btn_DocAddCreate.UseVisualStyleBackColor = true;
            this.btn_DocAddCreate.Click += new System.EventHandler(this.btn_DocAddCreate_click);
            // 
            // btn_DocAddCancel
            // 
            this.btn_DocAddCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_DocAddCancel.Location = new System.Drawing.Point(311, 134);
            this.btn_DocAddCancel.Name = "btn_DocAddCancel";
            this.btn_DocAddCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_DocAddCancel.TabIndex = 41;
            this.btn_DocAddCancel.Text = "Cancel";
            this.btn_DocAddCancel.UseVisualStyleBackColor = true;
            this.btn_DocAddCancel.Click += new System.EventHandler(this.btn_DocAddCancel_click);
            // 
            // frm_ProjectDocAdd
            // 
            this.AcceptButton = this.btn_DocAddCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_DocAddCancel;
            this.ClientSize = new System.Drawing.Size(398, 166);
            this.Controls.Add(this.btn_DocAddCancel);
            this.Controls.Add(this.btn_DocAddCreate);
            this.Controls.Add(this.lbl_DocAccepted);
            this.Controls.Add(this.mtb_DocAccepted);
            this.Controls.Add(this.mtb_DocSubmitted);
            this.Controls.Add(this.lbl_DocSubmitted);
            this.Controls.Add(this.nud_DocVersion);
            this.Controls.Add(this.lbl_DocVersion);
            this.Controls.Add(this.lbl_DocType);
            this.Controls.Add(this.cb_DocType);
            this.Controls.Add(this.lbl_ProjectName);
            this.Controls.Add(this.lbl_ProjectNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ProjectDocAdd";
            this.Text = "frm_ProjectDocAdd";
            ((System.ComponentModel.ISupportInitialize)(this.nud_DocVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.Label lbl_ProjectNumber;
        private System.Windows.Forms.ComboBox cb_DocType;
        private System.Windows.Forms.Label lbl_DocType;
        private System.Windows.Forms.Label lbl_DocVersion;
        private System.Windows.Forms.NumericUpDown nud_DocVersion;
        private System.Windows.Forms.Label lbl_DocSubmitted;
        private System.Windows.Forms.MaskedTextBox mtb_DocSubmitted;
        private System.Windows.Forms.MaskedTextBox mtb_DocAccepted;
        private System.Windows.Forms.Label lbl_DocAccepted;
        private System.Windows.Forms.Button btn_DocAddCreate;
        private System.Windows.Forms.Button btn_DocAddCancel;
    }
}