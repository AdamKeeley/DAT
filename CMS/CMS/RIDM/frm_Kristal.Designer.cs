namespace CMS
{
    partial class frm_Kristal
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
            this.lbl_KristalRef = new System.Windows.Forms.Label();
            this.cb_GrantStage = new System.Windows.Forms.ComboBox();
            this.lbl_AppStage = new System.Windows.Forms.Label();
            this.lbl_KristalRefValue = new System.Windows.Forms.Label();
            this.btn_Kristal_OK = new System.Windows.Forms.Button();
            this.btn_Kristal_Cancel = new System.Windows.Forms.Button();
            this.tb_KristalName = new System.Windows.Forms.TextBox();
            this.lbl_KristalName = new System.Windows.Forms.Label();
            this.dgv_KristalProjects = new System.Windows.Forms.DataGridView();
            this.btn_Kristal_AddProject = new System.Windows.Forms.Button();
            this.btn_Kristal_RemoveProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_KristalRef
            // 
            this.lbl_KristalRef.AutoSize = true;
            this.lbl_KristalRef.Location = new System.Drawing.Point(12, 9);
            this.lbl_KristalRef.Name = "lbl_KristalRef";
            this.lbl_KristalRef.Size = new System.Drawing.Size(88, 13);
            this.lbl_KristalRef.TabIndex = 49;
            this.lbl_KristalRef.Text = "Kristal Reference";
            // 
            // cb_GrantStage
            // 
            this.cb_GrantStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_GrantStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_GrantStage.FormattingEnabled = true;
            this.cb_GrantStage.Location = new System.Drawing.Point(300, 6);
            this.cb_GrantStage.Name = "cb_GrantStage";
            this.cb_GrantStage.Size = new System.Drawing.Size(145, 21);
            this.cb_GrantStage.TabIndex = 48;
            // 
            // lbl_AppStage
            // 
            this.lbl_AppStage.AutoSize = true;
            this.lbl_AppStage.Location = new System.Drawing.Point(204, 9);
            this.lbl_AppStage.Name = "lbl_AppStage";
            this.lbl_AppStage.Size = new System.Drawing.Size(90, 13);
            this.lbl_AppStage.TabIndex = 47;
            this.lbl_AppStage.Text = "Application Stage";
            // 
            // lbl_KristalRefValue
            // 
            this.lbl_KristalRefValue.AutoSize = true;
            this.lbl_KristalRefValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KristalRefValue.Location = new System.Drawing.Point(106, 3);
            this.lbl_KristalRefValue.Name = "lbl_KristalRefValue";
            this.lbl_KristalRefValue.Size = new System.Drawing.Size(60, 24);
            this.lbl_KristalRefValue.TabIndex = 50;
            this.lbl_KristalRefValue.Text = "label1";
            // 
            // btn_Kristal_OK
            // 
            this.btn_Kristal_OK.Location = new System.Drawing.Point(289, 215);
            this.btn_Kristal_OK.Name = "btn_Kristal_OK";
            this.btn_Kristal_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_OK.TabIndex = 51;
            this.btn_Kristal_OK.Text = "OK";
            this.btn_Kristal_OK.UseVisualStyleBackColor = true;
            this.btn_Kristal_OK.Click += new System.EventHandler(this.btn_Kristal_OK_Click);
            // 
            // btn_Kristal_Cancel
            // 
            this.btn_Kristal_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Kristal_Cancel.Location = new System.Drawing.Point(370, 215);
            this.btn_Kristal_Cancel.Name = "btn_Kristal_Cancel";
            this.btn_Kristal_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_Cancel.TabIndex = 52;
            this.btn_Kristal_Cancel.Text = "Cancel";
            this.btn_Kristal_Cancel.UseVisualStyleBackColor = true;
            this.btn_Kristal_Cancel.Click += new System.EventHandler(this.btn_Kristal_Cancel_Click);
            // 
            // tb_KristalName
            // 
            this.tb_KristalName.Location = new System.Drawing.Point(110, 33);
            this.tb_KristalName.Name = "tb_KristalName";
            this.tb_KristalName.Size = new System.Drawing.Size(335, 20);
            this.tb_KristalName.TabIndex = 81;
            // 
            // lbl_KristalName
            // 
            this.lbl_KristalName.AutoSize = true;
            this.lbl_KristalName.Location = new System.Drawing.Point(12, 36);
            this.lbl_KristalName.Name = "lbl_KristalName";
            this.lbl_KristalName.Size = new System.Drawing.Size(66, 13);
            this.lbl_KristalName.TabIndex = 80;
            this.lbl_KristalName.Text = "Kristal Name";
            // 
            // dgv_KristalProjects
            // 
            this.dgv_KristalProjects.AllowUserToAddRows = false;
            this.dgv_KristalProjects.AllowUserToDeleteRows = false;
            this.dgv_KristalProjects.AllowUserToOrderColumns = true;
            this.dgv_KristalProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KristalProjects.Location = new System.Drawing.Point(15, 59);
            this.dgv_KristalProjects.Name = "dgv_KristalProjects";
            this.dgv_KristalProjects.ReadOnly = true;
            this.dgv_KristalProjects.RowHeadersVisible = false;
            this.dgv_KristalProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KristalProjects.Size = new System.Drawing.Size(430, 150);
            this.dgv_KristalProjects.TabIndex = 82;
            this.dgv_KristalProjects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KristalProjects_CellDoubleClick);
            // 
            // btn_Kristal_AddProject
            // 
            this.btn_Kristal_AddProject.Location = new System.Drawing.Point(15, 215);
            this.btn_Kristal_AddProject.Name = "btn_Kristal_AddProject";
            this.btn_Kristal_AddProject.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_AddProject.TabIndex = 83;
            this.btn_Kristal_AddProject.Text = "Add Project";
            this.btn_Kristal_AddProject.UseVisualStyleBackColor = true;
            this.btn_Kristal_AddProject.Click += new System.EventHandler(this.btn_Kristal_AddProject_Click);
            // 
            // btn_Kristal_RemoveProject
            // 
            this.btn_Kristal_RemoveProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Kristal_RemoveProject.Location = new System.Drawing.Point(96, 215);
            this.btn_Kristal_RemoveProject.Name = "btn_Kristal_RemoveProject";
            this.btn_Kristal_RemoveProject.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_RemoveProject.TabIndex = 84;
            this.btn_Kristal_RemoveProject.Text = "Remove Project";
            this.btn_Kristal_RemoveProject.UseVisualStyleBackColor = true;
            this.btn_Kristal_RemoveProject.Click += new System.EventHandler(this.btn_Kristal_RemoveProject_Click);
            // 
            // frm_Kristal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Kristal_Cancel;
            this.ClientSize = new System.Drawing.Size(457, 250);
            this.Controls.Add(this.btn_Kristal_RemoveProject);
            this.Controls.Add(this.btn_Kristal_AddProject);
            this.Controls.Add(this.dgv_KristalProjects);
            this.Controls.Add(this.tb_KristalName);
            this.Controls.Add(this.lbl_KristalName);
            this.Controls.Add(this.btn_Kristal_Cancel);
            this.Controls.Add(this.btn_Kristal_OK);
            this.Controls.Add(this.lbl_KristalRefValue);
            this.Controls.Add(this.lbl_KristalRef);
            this.Controls.Add(this.cb_GrantStage);
            this.Controls.Add(this.lbl_AppStage);
            this.Name = "frm_Kristal";
            this.Text = "Grant details";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_KristalRef;
        private System.Windows.Forms.ComboBox cb_GrantStage;
        private System.Windows.Forms.Label lbl_AppStage;
        private System.Windows.Forms.Label lbl_KristalRefValue;
        private System.Windows.Forms.Button btn_Kristal_OK;
        private System.Windows.Forms.Button btn_Kristal_Cancel;
        private System.Windows.Forms.TextBox tb_KristalName;
        private System.Windows.Forms.Label lbl_KristalName;
        private System.Windows.Forms.DataGridView dgv_KristalProjects;
        private System.Windows.Forms.Button btn_Kristal_AddProject;
        private System.Windows.Forms.Button btn_Kristal_RemoveProject;
    }
}