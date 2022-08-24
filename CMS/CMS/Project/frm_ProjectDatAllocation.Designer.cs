namespace CMS
{
    partial class frm_ProjectDatAllocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectDatAllocation));
            this.lbl_FromDate = new System.Windows.Forms.Label();
            this.lbl_ToDate = new System.Windows.Forms.Label();
            this.mtb_pEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.mtb_pStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.lbl_DatAllocation = new System.Windows.Forms.Label();
            this.nud_DatAllocation = new System.Windows.Forms.NumericUpDown();
            this.dgv_projectDatAllocation = new System.Windows.Forms.DataGridView();
            this.btn_Project_ProjectDatAllocation_Remove = new System.Windows.Forms.Button();
            this.btn_Project_ProjectDatAllocation_Add = new System.Windows.Forms.Button();
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.gb_NewDatAllocation = new System.Windows.Forms.GroupBox();
            this.btn_Project_ProjectDatAllocation_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DatAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectDatAllocation)).BeginInit();
            this.gb_NewDatAllocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_FromDate
            // 
            this.lbl_FromDate.AutoSize = true;
            this.lbl_FromDate.Location = new System.Drawing.Point(5, 21);
            this.lbl_FromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FromDate.Name = "lbl_FromDate";
            this.lbl_FromDate.Size = new System.Drawing.Size(56, 13);
            this.lbl_FromDate.TabIndex = 10;
            this.lbl_FromDate.Text = "From Date";
            // 
            // lbl_ToDate
            // 
            this.lbl_ToDate.AutoSize = true;
            this.lbl_ToDate.Location = new System.Drawing.Point(5, 49);
            this.lbl_ToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ToDate.Name = "lbl_ToDate";
            this.lbl_ToDate.Size = new System.Drawing.Size(46, 13);
            this.lbl_ToDate.TabIndex = 12;
            this.lbl_ToDate.Text = "To Date";
            // 
            // mtb_pEndDateValue
            // 
            this.mtb_pEndDateValue.Location = new System.Drawing.Point(79, 46);
            this.mtb_pEndDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pEndDateValue.Mask = "00/00/0000";
            this.mtb_pEndDateValue.Name = "mtb_pEndDateValue";
            this.mtb_pEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pEndDateValue.TabIndex = 13;
            this.mtb_pEndDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_pStartDateValue
            // 
            this.mtb_pStartDateValue.Location = new System.Drawing.Point(79, 18);
            this.mtb_pStartDateValue.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_pStartDateValue.Mask = "00/00/0000";
            this.mtb_pStartDateValue.Name = "mtb_pStartDateValue";
            this.mtb_pStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pStartDateValue.TabIndex = 11;
            this.mtb_pStartDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // lbl_DatAllocation
            // 
            this.lbl_DatAllocation.AutoSize = true;
            this.lbl_DatAllocation.Location = new System.Drawing.Point(6, 73);
            this.lbl_DatAllocation.Name = "lbl_DatAllocation";
            this.lbl_DatAllocation.Size = new System.Drawing.Size(67, 13);
            this.lbl_DatAllocation.TabIndex = 15;
            this.lbl_DatAllocation.Text = "FTE Percent";
            // 
            // nud_DatAllocation
            // 
            this.nud_DatAllocation.DecimalPlaces = 1;
            this.nud_DatAllocation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nud_DatAllocation.Location = new System.Drawing.Point(79, 71);
            this.nud_DatAllocation.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.nud_DatAllocation.Name = "nud_DatAllocation";
            this.nud_DatAllocation.Size = new System.Drawing.Size(76, 20);
            this.nud_DatAllocation.TabIndex = 14;
            this.nud_DatAllocation.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // dgv_projectDatAllocation
            // 
            this.dgv_projectDatAllocation.AllowUserToAddRows = false;
            this.dgv_projectDatAllocation.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_projectDatAllocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_projectDatAllocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_projectDatAllocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_projectDatAllocation.Location = new System.Drawing.Point(48, 135);
            this.dgv_projectDatAllocation.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_projectDatAllocation.Name = "dgv_projectDatAllocation";
            this.dgv_projectDatAllocation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_projectDatAllocation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_projectDatAllocation.RowHeadersVisible = false;
            this.dgv_projectDatAllocation.RowTemplate.Height = 24;
            this.dgv_projectDatAllocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_projectDatAllocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_projectDatAllocation.Size = new System.Drawing.Size(245, 100);
            this.dgv_projectDatAllocation.TabIndex = 16;
            this.dgv_projectDatAllocation.TabStop = false;
            // 
            // btn_Project_ProjectDatAllocation_Remove
            // 
            this.btn_Project_ProjectDatAllocation_Remove.Location = new System.Drawing.Point(48, 240);
            this.btn_Project_ProjectDatAllocation_Remove.Name = "btn_Project_ProjectDatAllocation_Remove";
            this.btn_Project_ProjectDatAllocation_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Remove.TabIndex = 46;
            this.btn_Project_ProjectDatAllocation_Remove.Text = "Remove";
            this.btn_Project_ProjectDatAllocation_Remove.UseVisualStyleBackColor = true;
            // 
            // btn_Project_ProjectDatAllocation_Add
            // 
            this.btn_Project_ProjectDatAllocation_Add.Location = new System.Drawing.Point(161, 71);
            this.btn_Project_ProjectDatAllocation_Add.Name = "btn_Project_ProjectDatAllocation_Add";
            this.btn_Project_ProjectDatAllocation_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Add.TabIndex = 45;
            this.btn_Project_ProjectDatAllocation_Add.Text = "Add";
            this.btn_Project_ProjectDatAllocation_Add.UseVisualStyleBackColor = true;
            // 
            // lbl_pNumber
            // 
            this.lbl_pNumber.AutoSize = true;
            this.lbl_pNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pNumber.Location = new System.Drawing.Point(11, 9);
            this.lbl_pNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pNumber.Name = "lbl_pNumber";
            this.lbl_pNumber.Size = new System.Drawing.Size(112, 18);
            this.lbl_pNumber.TabIndex = 47;
            this.lbl_pNumber.Text = "Project Number";
            // 
            // gb_NewDatAllocation
            // 
            this.gb_NewDatAllocation.Controls.Add(this.lbl_FromDate);
            this.gb_NewDatAllocation.Controls.Add(this.mtb_pStartDateValue);
            this.gb_NewDatAllocation.Controls.Add(this.mtb_pEndDateValue);
            this.gb_NewDatAllocation.Controls.Add(this.lbl_ToDate);
            this.gb_NewDatAllocation.Controls.Add(this.btn_Project_ProjectDatAllocation_Add);
            this.gb_NewDatAllocation.Controls.Add(this.lbl_DatAllocation);
            this.gb_NewDatAllocation.Controls.Add(this.nud_DatAllocation);
            this.gb_NewDatAllocation.Location = new System.Drawing.Point(48, 30);
            this.gb_NewDatAllocation.Name = "gb_NewDatAllocation";
            this.gb_NewDatAllocation.Size = new System.Drawing.Size(245, 100);
            this.gb_NewDatAllocation.TabIndex = 50;
            this.gb_NewDatAllocation.TabStop = false;
            // 
            // btn_Project_ProjectDatAllocation_Close
            // 
            this.btn_Project_ProjectDatAllocation_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Project_ProjectDatAllocation_Close.Location = new System.Drawing.Point(218, 240);
            this.btn_Project_ProjectDatAllocation_Close.Name = "btn_Project_ProjectDatAllocation_Close";
            this.btn_Project_ProjectDatAllocation_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Close.TabIndex = 51;
            this.btn_Project_ProjectDatAllocation_Close.Text = "Close";
            this.btn_Project_ProjectDatAllocation_Close.UseVisualStyleBackColor = true;
            // 
            // frm_ProjectDatAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Project_ProjectDatAllocation_Close;
            this.ClientSize = new System.Drawing.Size(348, 278);
            this.Controls.Add(this.btn_Project_ProjectDatAllocation_Close);
            this.Controls.Add(this.gb_NewDatAllocation);
            this.Controls.Add(this.lbl_pNumber);
            this.Controls.Add(this.btn_Project_ProjectDatAllocation_Remove);
            this.Controls.Add(this.dgv_projectDatAllocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ProjectDatAllocation";
            this.Text = "Project Dat Allocation (% FTE)";
            ((System.ComponentModel.ISupportInitialize)(this.nud_DatAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectDatAllocation)).EndInit();
            this.gb_NewDatAllocation.ResumeLayout(false);
            this.gb_NewDatAllocation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_FromDate;
        private System.Windows.Forms.Label lbl_ToDate;
        private System.Windows.Forms.MaskedTextBox mtb_pEndDateValue;
        private System.Windows.Forms.MaskedTextBox mtb_pStartDateValue;
        private System.Windows.Forms.Label lbl_DatAllocation;
        private System.Windows.Forms.NumericUpDown nud_DatAllocation;
        private System.Windows.Forms.DataGridView dgv_projectDatAllocation;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Remove;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Add;
        private System.Windows.Forms.Label lbl_pNumber;
        private System.Windows.Forms.GroupBox gb_NewDatAllocation;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Close;
    }
}