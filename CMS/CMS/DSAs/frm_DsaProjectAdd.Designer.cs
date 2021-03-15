namespace CMS.DSAs
{
    partial class frm_DsaProjectAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DsaProjectAdd));
            this.lbl_ProjectList = new System.Windows.Forms.Label();
            this.btn_ConfirmProject = new System.Windows.Forms.Button();
            this.dgv_ProjectList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProjectList
            // 
            this.lbl_ProjectList.AutoSize = true;
            this.lbl_ProjectList.Location = new System.Drawing.Point(17, 52);
            this.lbl_ProjectList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ProjectList.Name = "lbl_ProjectList";
            this.lbl_ProjectList.Size = new System.Drawing.Size(235, 17);
            this.lbl_ProjectList.TabIndex = 5;
            this.lbl_ProjectList.Text = "Select a project to link with the DSA:";
            // 
            // btn_ConfirmProject
            // 
            this.btn_ConfirmProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConfirmProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConfirmProject.Location = new System.Drawing.Point(251, 12);
            this.btn_ConfirmProject.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ConfirmProject.Name = "btn_ConfirmProject";
            this.btn_ConfirmProject.Size = new System.Drawing.Size(159, 36);
            this.btn_ConfirmProject.TabIndex = 4;
            this.btn_ConfirmProject.Text = "Add Project";
            this.btn_ConfirmProject.UseVisualStyleBackColor = true;
            this.btn_ConfirmProject.Click += new System.EventHandler(this.btn_ConfirmProject_Click);
            // 
            // dgv_ProjectList
            // 
            this.dgv_ProjectList.AllowUserToAddRows = false;
            this.dgv_ProjectList.AllowUserToDeleteRows = false;
            this.dgv_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProjectList.Location = new System.Drawing.Point(13, 73);
            this.dgv_ProjectList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ProjectList.MultiSelect = false;
            this.dgv_ProjectList.Name = "dgv_ProjectList";
            this.dgv_ProjectList.ReadOnly = true;
            this.dgv_ProjectList.RowHeadersWidth = 51;
            this.dgv_ProjectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProjectList.Size = new System.Drawing.Size(631, 287);
            this.dgv_ProjectList.TabIndex = 3;
            // 
            // frm_DsaProjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 369);
            this.Controls.Add(this.lbl_ProjectList);
            this.Controls.Add(this.btn_ConfirmProject);
            this.Controls.Add(this.dgv_ProjectList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_DsaProjectAdd";
            this.Text = "Link DSAs With Projects";
            this.Load += new System.EventHandler(this.frm_DsaProjectAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProjectList;
        private System.Windows.Forms.Button btn_ConfirmProject;
        private System.Windows.Forms.DataGridView dgv_ProjectList;
    }
}