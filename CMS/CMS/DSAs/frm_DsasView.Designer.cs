namespace CMS.DSAs
{
    partial class frm_DsasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DsasView));
            this.dgv_Dsas = new System.Windows.Forms.DataGridView();
            this.lbl_Help = new System.Windows.Forms.Label();
            this.btn_NewDSA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dsas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Dsas
            // 
            this.dgv_Dsas.AllowUserToAddRows = false;
            this.dgv_Dsas.AllowUserToDeleteRows = false;
            this.dgv_Dsas.AllowUserToOrderColumns = true;
            this.dgv_Dsas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Dsas.Location = new System.Drawing.Point(12, 41);
            this.dgv_Dsas.MultiSelect = false;
            this.dgv_Dsas.Name = "dgv_Dsas";
            this.dgv_Dsas.ReadOnly = true;
            this.dgv_Dsas.RowHeadersWidth = 51;
            this.dgv_Dsas.RowTemplate.Height = 24;
            this.dgv_Dsas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Dsas.Size = new System.Drawing.Size(1083, 397);
            this.dgv_Dsas.TabIndex = 0;
            this.dgv_Dsas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Dsas_CellDoubleClick);
            // 
            // lbl_Help
            // 
            this.lbl_Help.AutoSize = true;
            this.lbl_Help.Location = new System.Drawing.Point(12, 21);
            this.lbl_Help.Name = "lbl_Help";
            this.lbl_Help.Size = new System.Drawing.Size(515, 17);
            this.lbl_Help.TabIndex = 1;
            this.lbl_Help.Text = "Double click a DSA from the list below to view the record and update it if needed" +
    ":";
            // 
            // btn_NewDSA
            // 
            this.btn_NewDSA.Location = new System.Drawing.Point(879, 5);
            this.btn_NewDSA.Name = "btn_NewDSA";
            this.btn_NewDSA.Size = new System.Drawing.Size(216, 30);
            this.btn_NewDSA.TabIndex = 2;
            this.btn_NewDSA.Text = "Create New DSA";
            this.btn_NewDSA.UseVisualStyleBackColor = true;
            this.btn_NewDSA.Click += new System.EventHandler(this.btn_NewDSA_Click);
            // 
            // frm_DsasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 450);
            this.Controls.Add(this.btn_NewDSA);
            this.Controls.Add(this.lbl_Help);
            this.Controls.Add(this.dgv_Dsas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_DsasView";
            this.Text = "List of Data Sharing Agreements";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dsas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Dsas;
        private System.Windows.Forms.Label lbl_Help;
        private System.Windows.Forms.Button btn_NewDSA;
    }
}