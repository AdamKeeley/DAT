namespace CMS
{
    partial class frm_ProjectCostings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectCostings));
            this.dgv_projectDatAllocation = new System.Windows.Forms.DataGridView();
            this.btn_Project_ProjectDatAllocation_Remove = new System.Windows.Forms.Button();
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.btn_Project_ProjectDatAllocation_Close = new System.Windows.Forms.Button();
            this.cb_CostingType = new System.Windows.Forms.ComboBox();
            this.lbl_CostingType = new System.Windows.Forms.Label();
            this.dgv_ProjectCostings = new System.Windows.Forms.DataGridView();
            this.lbl_CostedFromDate = new System.Windows.Forms.Label();
            this.mtb_CostedFromDate = new System.Windows.Forms.MaskedTextBox();
            this.mtb_CostedToDate = new System.Windows.Forms.MaskedTextBox();
            this.lbl_CostedToDate = new System.Windows.Forms.Label();
            this.mtb_DateCosted = new System.Windows.Forms.MaskedTextBox();
            this.lbl_DateCosted = new System.Windows.Forms.Label();
            this.btn_LaserCosting_Remove = new System.Windows.Forms.Button();
            this.lbl_ComputeAmount = new System.Windows.Forms.Label();
            this.lbl_ItsSupportAmount = new System.Windows.Forms.Label();
            this.lbl_FixedInfraAmount = new System.Windows.Forms.Label();
            this.tb_ComputeAmount = new System.Windows.Forms.TextBox();
            this.tb_ItsSupportAmount = new System.Windows.Forms.TextBox();
            this.tb_FixedInfraAmount = new System.Windows.Forms.TextBox();
            this.btn_LaserCosting_Add = new System.Windows.Forms.Button();
            this.gb_LaserCosts = new System.Windows.Forms.GroupBox();
            this.gb_DatSupport = new System.Windows.Forms.GroupBox();
            this.gb_NewDatAllocation = new System.Windows.Forms.GroupBox();
            this.lbl_FromDate = new System.Windows.Forms.Label();
            this.mtb_FromDate = new System.Windows.Forms.MaskedTextBox();
            this.mtb_ToDate = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ToDate = new System.Windows.Forms.Label();
            this.btn_Project_ProjectDatAllocation_Add = new System.Windows.Forms.Button();
            this.lbl_DatAllocation = new System.Windows.Forms.Label();
            this.nud_DatAllocation = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectDatAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectCostings)).BeginInit();
            this.gb_LaserCosts.SuspendLayout();
            this.gb_DatSupport.SuspendLayout();
            this.gb_NewDatAllocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DatAllocation)).BeginInit();
            this.SuspendLayout();
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
            this.dgv_projectDatAllocation.Location = new System.Drawing.Point(6, 124);
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
            this.btn_Project_ProjectDatAllocation_Remove.Location = new System.Drawing.Point(6, 229);
            this.btn_Project_ProjectDatAllocation_Remove.Name = "btn_Project_ProjectDatAllocation_Remove";
            this.btn_Project_ProjectDatAllocation_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Remove.TabIndex = 46;
            this.btn_Project_ProjectDatAllocation_Remove.Text = "Remove";
            this.btn_Project_ProjectDatAllocation_Remove.UseVisualStyleBackColor = true;
            this.btn_Project_ProjectDatAllocation_Remove.Click += new System.EventHandler(this.btn_Project_ProjectDatAllocation_Remove_Click);
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
            // btn_Project_ProjectDatAllocation_Close
            // 
            this.btn_Project_ProjectDatAllocation_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Project_ProjectDatAllocation_Close.Location = new System.Drawing.Point(731, 296);
            this.btn_Project_ProjectDatAllocation_Close.Name = "btn_Project_ProjectDatAllocation_Close";
            this.btn_Project_ProjectDatAllocation_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Close.TabIndex = 51;
            this.btn_Project_ProjectDatAllocation_Close.Text = "Close";
            this.btn_Project_ProjectDatAllocation_Close.UseVisualStyleBackColor = true;
            // 
            // cb_CostingType
            // 
            this.cb_CostingType.FormattingEnabled = true;
            this.cb_CostingType.Location = new System.Drawing.Point(77, 23);
            this.cb_CostingType.Name = "cb_CostingType";
            this.cb_CostingType.Size = new System.Drawing.Size(121, 21);
            this.cb_CostingType.TabIndex = 52;
            // 
            // lbl_CostingType
            // 
            this.lbl_CostingType.AutoSize = true;
            this.lbl_CostingType.Location = new System.Drawing.Point(6, 26);
            this.lbl_CostingType.Name = "lbl_CostingType";
            this.lbl_CostingType.Size = new System.Drawing.Size(65, 13);
            this.lbl_CostingType.TabIndex = 53;
            this.lbl_CostingType.Text = "Costing type";
            // 
            // dgv_ProjectCostings
            // 
            this.dgv_ProjectCostings.AllowUserToAddRows = false;
            this.dgv_ProjectCostings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ProjectCostings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ProjectCostings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ProjectCostings.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_ProjectCostings.Location = new System.Drawing.Point(5, 124);
            this.dgv_ProjectCostings.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ProjectCostings.Name = "dgv_ProjectCostings";
            this.dgv_ProjectCostings.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ProjectCostings.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_ProjectCostings.RowHeadersVisible = false;
            this.dgv_ProjectCostings.RowTemplate.Height = 24;
            this.dgv_ProjectCostings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ProjectCostings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProjectCostings.Size = new System.Drawing.Size(519, 100);
            this.dgv_ProjectCostings.TabIndex = 54;
            this.dgv_ProjectCostings.TabStop = false;
            // 
            // lbl_CostedFromDate
            // 
            this.lbl_CostedFromDate.AutoSize = true;
            this.lbl_CostedFromDate.Location = new System.Drawing.Point(5, 52);
            this.lbl_CostedFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CostedFromDate.Name = "lbl_CostedFromDate";
            this.lbl_CostedFromDate.Size = new System.Drawing.Size(56, 13);
            this.lbl_CostedFromDate.TabIndex = 46;
            this.lbl_CostedFromDate.Text = "From Date";
            // 
            // mtb_CostedFromDate
            // 
            this.mtb_CostedFromDate.Location = new System.Drawing.Point(77, 49);
            this.mtb_CostedFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_CostedFromDate.Mask = "00/00/0000";
            this.mtb_CostedFromDate.Name = "mtb_CostedFromDate";
            this.mtb_CostedFromDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_CostedFromDate.TabIndex = 47;
            this.mtb_CostedFromDate.ValidatingType = typeof(System.DateTime);
            this.mtb_CostedFromDate.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // mtb_CostedToDate
            // 
            this.mtb_CostedToDate.Location = new System.Drawing.Point(77, 73);
            this.mtb_CostedToDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_CostedToDate.Mask = "00/00/0000";
            this.mtb_CostedToDate.Name = "mtb_CostedToDate";
            this.mtb_CostedToDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_CostedToDate.TabIndex = 47;
            this.mtb_CostedToDate.ValidatingType = typeof(System.DateTime);
            this.mtb_CostedToDate.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // lbl_CostedToDate
            // 
            this.lbl_CostedToDate.AutoSize = true;
            this.lbl_CostedToDate.Location = new System.Drawing.Point(5, 76);
            this.lbl_CostedToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CostedToDate.Name = "lbl_CostedToDate";
            this.lbl_CostedToDate.Size = new System.Drawing.Size(46, 13);
            this.lbl_CostedToDate.TabIndex = 46;
            this.lbl_CostedToDate.Text = "To Date";
            // 
            // mtb_DateCosted
            // 
            this.mtb_DateCosted.Location = new System.Drawing.Point(344, 21);
            this.mtb_DateCosted.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_DateCosted.Mask = "00/00/0000";
            this.mtb_DateCosted.Name = "mtb_DateCosted";
            this.mtb_DateCosted.Size = new System.Drawing.Size(76, 20);
            this.mtb_DateCosted.TabIndex = 56;
            this.mtb_DateCosted.ValidatingType = typeof(System.DateTime);
            this.mtb_DateCosted.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // lbl_DateCosted
            // 
            this.lbl_DateCosted.AutoSize = true;
            this.lbl_DateCosted.Location = new System.Drawing.Point(272, 23);
            this.lbl_DateCosted.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DateCosted.Name = "lbl_DateCosted";
            this.lbl_DateCosted.Size = new System.Drawing.Size(65, 13);
            this.lbl_DateCosted.TabIndex = 55;
            this.lbl_DateCosted.Text = "Date costed";
            // 
            // btn_LaserCosting_Remove
            // 
            this.btn_LaserCosting_Remove.Location = new System.Drawing.Point(5, 229);
            this.btn_LaserCosting_Remove.Name = "btn_LaserCosting_Remove";
            this.btn_LaserCosting_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_LaserCosting_Remove.TabIndex = 57;
            this.btn_LaserCosting_Remove.Text = "Remove";
            this.btn_LaserCosting_Remove.UseVisualStyleBackColor = true;
            // 
            // lbl_ComputeAmount
            // 
            this.lbl_ComputeAmount.AutoSize = true;
            this.lbl_ComputeAmount.Location = new System.Drawing.Point(251, 47);
            this.lbl_ComputeAmount.Name = "lbl_ComputeAmount";
            this.lbl_ComputeAmount.Size = new System.Drawing.Size(87, 13);
            this.lbl_ComputeAmount.TabIndex = 58;
            this.lbl_ComputeAmount.Text = "Compute amount";
            // 
            // lbl_ItsSupportAmount
            // 
            this.lbl_ItsSupportAmount.AutoSize = true;
            this.lbl_ItsSupportAmount.Location = new System.Drawing.Point(237, 74);
            this.lbl_ItsSupportAmount.Name = "lbl_ItsSupportAmount";
            this.lbl_ItsSupportAmount.Size = new System.Drawing.Size(100, 13);
            this.lbl_ItsSupportAmount.TabIndex = 59;
            this.lbl_ItsSupportAmount.Text = "ITS support amount";
            // 
            // lbl_FixedInfraAmount
            // 
            this.lbl_FixedInfraAmount.AutoSize = true;
            this.lbl_FixedInfraAmount.Location = new System.Drawing.Point(203, 100);
            this.lbl_FixedInfraAmount.Name = "lbl_FixedInfraAmount";
            this.lbl_FixedInfraAmount.Size = new System.Drawing.Size(134, 13);
            this.lbl_FixedInfraAmount.TabIndex = 60;
            this.lbl_FixedInfraAmount.Text = "Fixed infrastructure amount";
            // 
            // tb_ComputeAmount
            // 
            this.tb_ComputeAmount.Location = new System.Drawing.Point(344, 46);
            this.tb_ComputeAmount.Name = "tb_ComputeAmount";
            this.tb_ComputeAmount.Size = new System.Drawing.Size(100, 20);
            this.tb_ComputeAmount.TabIndex = 65;
            this.tb_ComputeAmount.Text = "£0.00";
            this.tb_ComputeAmount.Click += new System.EventHandler(this.enter_TextBox);
            this.tb_ComputeAmount.TextChanged += new System.EventHandler(this.textChanged_TextBox_Currency);
            // 
            // tb_ItsSupportAmount
            // 
            this.tb_ItsSupportAmount.Location = new System.Drawing.Point(344, 72);
            this.tb_ItsSupportAmount.Name = "tb_ItsSupportAmount";
            this.tb_ItsSupportAmount.Size = new System.Drawing.Size(100, 20);
            this.tb_ItsSupportAmount.TabIndex = 66;
            this.tb_ItsSupportAmount.Text = "£0.00";
            this.tb_ItsSupportAmount.Click += new System.EventHandler(this.enter_TextBox);
            this.tb_ItsSupportAmount.TextChanged += new System.EventHandler(this.textChanged_TextBox_Currency);
            // 
            // tb_FixedInfraAmount
            // 
            this.tb_FixedInfraAmount.Location = new System.Drawing.Point(343, 98);
            this.tb_FixedInfraAmount.Name = "tb_FixedInfraAmount";
            this.tb_FixedInfraAmount.Size = new System.Drawing.Size(100, 20);
            this.tb_FixedInfraAmount.TabIndex = 67;
            this.tb_FixedInfraAmount.Text = "£0.00";
            this.tb_FixedInfraAmount.Click += new System.EventHandler(this.enter_TextBox);
            this.tb_FixedInfraAmount.TextChanged += new System.EventHandler(this.textChanged_TextBox_Currency);
            // 
            // btn_LaserCosting_Add
            // 
            this.btn_LaserCosting_Add.Location = new System.Drawing.Point(449, 96);
            this.btn_LaserCosting_Add.Name = "btn_LaserCosting_Add";
            this.btn_LaserCosting_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_LaserCosting_Add.TabIndex = 46;
            this.btn_LaserCosting_Add.Text = "Add";
            this.btn_LaserCosting_Add.UseVisualStyleBackColor = true;
            // 
            // gb_LaserCosts
            // 
            this.gb_LaserCosts.Controls.Add(this.cb_CostingType);
            this.gb_LaserCosts.Controls.Add(this.btn_LaserCosting_Add);
            this.gb_LaserCosts.Controls.Add(this.lbl_CostingType);
            this.gb_LaserCosts.Controls.Add(this.tb_FixedInfraAmount);
            this.gb_LaserCosts.Controls.Add(this.mtb_CostedFromDate);
            this.gb_LaserCosts.Controls.Add(this.tb_ItsSupportAmount);
            this.gb_LaserCosts.Controls.Add(this.dgv_ProjectCostings);
            this.gb_LaserCosts.Controls.Add(this.tb_ComputeAmount);
            this.gb_LaserCosts.Controls.Add(this.lbl_CostedFromDate);
            this.gb_LaserCosts.Controls.Add(this.lbl_FixedInfraAmount);
            this.gb_LaserCosts.Controls.Add(this.lbl_CostedToDate);
            this.gb_LaserCosts.Controls.Add(this.lbl_ItsSupportAmount);
            this.gb_LaserCosts.Controls.Add(this.mtb_CostedToDate);
            this.gb_LaserCosts.Controls.Add(this.lbl_ComputeAmount);
            this.gb_LaserCosts.Controls.Add(this.lbl_DateCosted);
            this.gb_LaserCosts.Controls.Add(this.btn_LaserCosting_Remove);
            this.gb_LaserCosts.Controls.Add(this.mtb_DateCosted);
            this.gb_LaserCosts.Location = new System.Drawing.Point(12, 30);
            this.gb_LaserCosts.Name = "gb_LaserCosts";
            this.gb_LaserCosts.Size = new System.Drawing.Size(529, 260);
            this.gb_LaserCosts.TabIndex = 68;
            this.gb_LaserCosts.TabStop = false;
            this.gb_LaserCosts.Text = "LASER Costs (Items 1a)";
            // 
            // gb_DatSupport
            // 
            this.gb_DatSupport.Controls.Add(this.gb_NewDatAllocation);
            this.gb_DatSupport.Controls.Add(this.dgv_projectDatAllocation);
            this.gb_DatSupport.Controls.Add(this.btn_Project_ProjectDatAllocation_Remove);
            this.gb_DatSupport.Location = new System.Drawing.Point(547, 30);
            this.gb_DatSupport.Name = "gb_DatSupport";
            this.gb_DatSupport.Size = new System.Drawing.Size(259, 260);
            this.gb_DatSupport.TabIndex = 69;
            this.gb_DatSupport.TabStop = false;
            this.gb_DatSupport.Text = "DAT Support (Items 1b)";
            // 
            // gb_NewDatAllocation
            // 
            this.gb_NewDatAllocation.Controls.Add(this.lbl_FromDate);
            this.gb_NewDatAllocation.Controls.Add(this.mtb_FromDate);
            this.gb_NewDatAllocation.Controls.Add(this.mtb_ToDate);
            this.gb_NewDatAllocation.Controls.Add(this.lbl_ToDate);
            this.gb_NewDatAllocation.Controls.Add(this.btn_Project_ProjectDatAllocation_Add);
            this.gb_NewDatAllocation.Controls.Add(this.lbl_DatAllocation);
            this.gb_NewDatAllocation.Controls.Add(this.nud_DatAllocation);
            this.gb_NewDatAllocation.Location = new System.Drawing.Point(6, 19);
            this.gb_NewDatAllocation.Name = "gb_NewDatAllocation";
            this.gb_NewDatAllocation.Size = new System.Drawing.Size(245, 100);
            this.gb_NewDatAllocation.TabIndex = 50;
            this.gb_NewDatAllocation.TabStop = false;
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
            // mtb_FromDate
            // 
            this.mtb_FromDate.Location = new System.Drawing.Point(79, 18);
            this.mtb_FromDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_FromDate.Mask = "00/00/0000";
            this.mtb_FromDate.Name = "mtb_FromDate";
            this.mtb_FromDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_FromDate.TabIndex = 11;
            this.mtb_FromDate.ValidatingType = typeof(System.DateTime);
            this.mtb_FromDate.Click += new System.EventHandler(this.enter_MaskedTextBox);
            // 
            // mtb_ToDate
            // 
            this.mtb_ToDate.Location = new System.Drawing.Point(79, 46);
            this.mtb_ToDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtb_ToDate.Mask = "00/00/0000";
            this.mtb_ToDate.Name = "mtb_ToDate";
            this.mtb_ToDate.Size = new System.Drawing.Size(76, 20);
            this.mtb_ToDate.TabIndex = 13;
            this.mtb_ToDate.ValidatingType = typeof(System.DateTime);
            this.mtb_ToDate.Click += new System.EventHandler(this.enter_MaskedTextBox);
            this.mtb_ToDate.Enter += new System.EventHandler(this.enter_MaskedTextBox);
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
            // btn_Project_ProjectDatAllocation_Add
            // 
            this.btn_Project_ProjectDatAllocation_Add.Location = new System.Drawing.Point(161, 71);
            this.btn_Project_ProjectDatAllocation_Add.Name = "btn_Project_ProjectDatAllocation_Add";
            this.btn_Project_ProjectDatAllocation_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Project_ProjectDatAllocation_Add.TabIndex = 45;
            this.btn_Project_ProjectDatAllocation_Add.Text = "Add";
            this.btn_Project_ProjectDatAllocation_Add.UseVisualStyleBackColor = true;
            this.btn_Project_ProjectDatAllocation_Add.Click += new System.EventHandler(this.btn_Project_ProjectDatAllocation_Add_Click);
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
            // frm_ProjectCostings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Project_ProjectDatAllocation_Close;
            this.ClientSize = new System.Drawing.Size(814, 327);
            this.Controls.Add(this.gb_DatSupport);
            this.Controls.Add(this.gb_LaserCosts);
            this.Controls.Add(this.btn_Project_ProjectDatAllocation_Close);
            this.Controls.Add(this.lbl_pNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ProjectCostings";
            this.Text = "Project Costings";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectDatAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectCostings)).EndInit();
            this.gb_LaserCosts.ResumeLayout(false);
            this.gb_LaserCosts.PerformLayout();
            this.gb_DatSupport.ResumeLayout(false);
            this.gb_NewDatAllocation.ResumeLayout(false);
            this.gb_NewDatAllocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DatAllocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_projectDatAllocation;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Remove;
        private System.Windows.Forms.Label lbl_pNumber;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Close;
        private System.Windows.Forms.ComboBox cb_CostingType;
        private System.Windows.Forms.Label lbl_CostingType;
        private System.Windows.Forms.DataGridView dgv_ProjectCostings;
        private System.Windows.Forms.Label lbl_CostedFromDate;
        private System.Windows.Forms.MaskedTextBox mtb_CostedFromDate;
        private System.Windows.Forms.MaskedTextBox mtb_CostedToDate;
        private System.Windows.Forms.Label lbl_CostedToDate;
        private System.Windows.Forms.MaskedTextBox mtb_DateCosted;
        private System.Windows.Forms.Label lbl_DateCosted;
        private System.Windows.Forms.Button btn_LaserCosting_Remove;
        private System.Windows.Forms.Label lbl_ComputeAmount;
        private System.Windows.Forms.Label lbl_ItsSupportAmount;
        private System.Windows.Forms.Label lbl_FixedInfraAmount;
        private System.Windows.Forms.TextBox tb_ComputeAmount;
        private System.Windows.Forms.TextBox tb_ItsSupportAmount;
        private System.Windows.Forms.TextBox tb_FixedInfraAmount;
        private System.Windows.Forms.Button btn_LaserCosting_Add;
        private System.Windows.Forms.GroupBox gb_LaserCosts;
        private System.Windows.Forms.GroupBox gb_DatSupport;
        private System.Windows.Forms.GroupBox gb_NewDatAllocation;
        private System.Windows.Forms.Label lbl_FromDate;
        private System.Windows.Forms.MaskedTextBox mtb_FromDate;
        private System.Windows.Forms.MaskedTextBox mtb_ToDate;
        private System.Windows.Forms.Label lbl_ToDate;
        private System.Windows.Forms.Button btn_Project_ProjectDatAllocation_Add;
        private System.Windows.Forms.Label lbl_DatAllocation;
        private System.Windows.Forms.NumericUpDown nud_DatAllocation;
    }
}