namespace CMS
{
    partial class frm_ProjectAdd
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
            this.mtb_pStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.mtb_pEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_pEndDate = new System.Windows.Forms.Label();
            this.lbl_pStartDate = new System.Windows.Forms.Label();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.tb_pPIValue = new System.Windows.Forms.TextBox();
            this.cb_pStage = new System.Windows.Forms.ComboBox();
            this.lbl_pStage = new System.Windows.Forms.Label();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.lbl_NewProjectNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mtb_pStartDateValue
            // 
            this.mtb_pStartDateValue.Location = new System.Drawing.Point(158, 122);
            this.mtb_pStartDateValue.Mask = "00/00/0000";
            this.mtb_pStartDateValue.Name = "mtb_pStartDateValue";
            this.mtb_pStartDateValue.Size = new System.Drawing.Size(100, 22);
            this.mtb_pStartDateValue.TabIndex = 19;
            this.mtb_pStartDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_pEndDateValue
            // 
            this.mtb_pEndDateValue.Location = new System.Drawing.Point(158, 150);
            this.mtb_pEndDateValue.Mask = "00/00/0000";
            this.mtb_pEndDateValue.Name = "mtb_pEndDateValue";
            this.mtb_pEndDateValue.Size = new System.Drawing.Size(100, 22);
            this.mtb_pEndDateValue.TabIndex = 21;
            this.mtb_pEndDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_pEndDate
            // 
            this.lbl_pEndDate.AutoSize = true;
            this.lbl_pEndDate.Location = new System.Drawing.Point(12, 154);
            this.lbl_pEndDate.Name = "lbl_pEndDate";
            this.lbl_pEndDate.Size = new System.Drawing.Size(67, 17);
            this.lbl_pEndDate.TabIndex = 20;
            this.lbl_pEndDate.Text = "End Date";
            // 
            // lbl_pStartDate
            // 
            this.lbl_pStartDate.AutoSize = true;
            this.lbl_pStartDate.Location = new System.Drawing.Point(13, 125);
            this.lbl_pStartDate.Name = "lbl_pStartDate";
            this.lbl_pStartDate.Size = new System.Drawing.Size(72, 17);
            this.lbl_pStartDate.TabIndex = 18;
            this.lbl_pStartDate.Text = "Start Date";
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(13, 68);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(139, 17);
            this.lbl_pPI.TabIndex = 14;
            this.lbl_pPI.Text = "Principal Investigator";
            // 
            // tb_pPIValue
            // 
            this.tb_pPIValue.Location = new System.Drawing.Point(158, 64);
            this.tb_pPIValue.Name = "tb_pPIValue";
            this.tb_pPIValue.Size = new System.Drawing.Size(229, 22);
            this.tb_pPIValue.TabIndex = 16;
            // 
            // cb_pStage
            // 
            this.cb_pStage.FormattingEnabled = true;
            this.cb_pStage.Location = new System.Drawing.Point(158, 92);
            this.cb_pStage.Name = "cb_pStage";
            this.cb_pStage.Size = new System.Drawing.Size(121, 24);
            this.cb_pStage.TabIndex = 17;
            // 
            // lbl_pStage
            // 
            this.lbl_pStage.AutoSize = true;
            this.lbl_pStage.Location = new System.Drawing.Point(13, 95);
            this.lbl_pStage.Name = "lbl_pStage";
            this.lbl_pStage.Size = new System.Drawing.Size(45, 17);
            this.lbl_pStage.TabIndex = 15;
            this.lbl_pStage.Text = "Stage";
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(158, 36);
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.Size = new System.Drawing.Size(229, 22);
            this.tb_pNameValue.TabIndex = 13;
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(13, 39);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(83, 17);
            this.lbl_pName.TabIndex = 12;
            this.lbl_pName.Text = "Project Title";
            // 
            // lbl_pNumber
            // 
            this.lbl_pNumber.AutoSize = true;
            this.lbl_pNumber.Location = new System.Drawing.Point(12, 9);
            this.lbl_pNumber.Name = "lbl_pNumber";
            this.lbl_pNumber.Size = new System.Drawing.Size(106, 17);
            this.lbl_pNumber.TabIndex = 10;
            this.lbl_pNumber.Text = "Project Number";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(312, 197);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(231, 197);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 30);
            this.btn_Create.TabIndex = 23;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // lbl_NewProjectNumber
            // 
            this.lbl_NewProjectNumber.AutoSize = true;
            this.lbl_NewProjectNumber.Location = new System.Drawing.Point(155, 9);
            this.lbl_NewProjectNumber.Name = "lbl_NewProjectNumber";
            this.lbl_NewProjectNumber.Size = new System.Drawing.Size(137, 17);
            this.lbl_NewProjectNumber.TabIndex = 24;
            this.lbl_NewProjectNumber.Text = "New Project Number";
            // 
            // frm_ProjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 239);
            this.Controls.Add(this.lbl_NewProjectNumber);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.mtb_pStartDateValue);
            this.Controls.Add(this.mtb_pEndDateValue);
            this.Controls.Add(this.lbl_pEndDate);
            this.Controls.Add(this.lbl_pStartDate);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.tb_pPIValue);
            this.Controls.Add(this.cb_pStage);
            this.Controls.Add(this.lbl_pStage);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Controls.Add(this.lbl_pNumber);
            this.Name = "frm_ProjectAdd";
            this.Text = "Create New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mtb_pStartDateValue;
        private System.Windows.Forms.MaskedTextBox mtb_pEndDateValue;
        private System.Windows.Forms.Label lbl_pEndDate;
        private System.Windows.Forms.Label lbl_pStartDate;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.TextBox tb_pPIValue;
        private System.Windows.Forms.ComboBox cb_pStage;
        private System.Windows.Forms.Label lbl_pStage;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.Label lbl_pNumber;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label lbl_NewProjectNumber;
    }
}