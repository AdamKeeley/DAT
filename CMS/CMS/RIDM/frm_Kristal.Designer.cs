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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tb_NewKristalNote = new System.Windows.Forms.TextBox();
            this.dgv_KristalNotes = new System.Windows.Forms.DataGridView();
            this.btn_Kristal_InsertKristalNote = new System.Windows.Forms.Button();
            this.btn_Kristal_Create = new System.Windows.Forms.Button();
            this.btn_Kristal_Refresh = new System.Windows.Forms.Button();
            this.btn_Kristal_Apply = new System.Windows.Forms.Button();
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.lbl_Faculty = new System.Windows.Forms.Label();
            this.cb_PI = new System.Windows.Forms.ComboBox();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.cb_Location = new System.Windows.Forms.ComboBox();
            this.lbl_Location = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalNotes)).BeginInit();
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
            this.btn_Kristal_OK.Location = new System.Drawing.Point(289, 456);
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
            this.btn_Kristal_Cancel.Location = new System.Drawing.Point(370, 456);
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
            this.dgv_KristalProjects.Location = new System.Drawing.Point(15, 113);
            this.dgv_KristalProjects.Name = "dgv_KristalProjects";
            this.dgv_KristalProjects.ReadOnly = true;
            this.dgv_KristalProjects.RowHeadersVisible = false;
            this.dgv_KristalProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KristalProjects.Size = new System.Drawing.Size(430, 120);
            this.dgv_KristalProjects.TabIndex = 82;
            this.dgv_KristalProjects.TabStop = false;
            this.dgv_KristalProjects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KristalProjects_CellDoubleClick);
            // 
            // btn_Kristal_AddProject
            // 
            this.btn_Kristal_AddProject.Location = new System.Drawing.Point(289, 239);
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
            this.btn_Kristal_RemoveProject.Location = new System.Drawing.Point(370, 239);
            this.btn_Kristal_RemoveProject.Name = "btn_Kristal_RemoveProject";
            this.btn_Kristal_RemoveProject.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_RemoveProject.TabIndex = 84;
            this.btn_Kristal_RemoveProject.Text = "Remove Project";
            this.btn_Kristal_RemoveProject.UseVisualStyleBackColor = true;
            this.btn_Kristal_RemoveProject.Click += new System.EventHandler(this.btn_Kristal_RemoveProject_Click);
            // 
            // tb_NewKristalNote
            // 
            this.tb_NewKristalNote.Location = new System.Drawing.Point(15, 267);
            this.tb_NewKristalNote.Margin = new System.Windows.Forms.Padding(2);
            this.tb_NewKristalNote.MaxLength = 8000;
            this.tb_NewKristalNote.Multiline = true;
            this.tb_NewKristalNote.Name = "tb_NewKristalNote";
            this.tb_NewKristalNote.Size = new System.Drawing.Size(371, 40);
            this.tb_NewKristalNote.TabIndex = 85;
            // 
            // dgv_KristalNotes
            // 
            this.dgv_KristalNotes.AllowUserToAddRows = false;
            this.dgv_KristalNotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_KristalNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_KristalNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_KristalNotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_KristalNotes.Location = new System.Drawing.Point(15, 311);
            this.dgv_KristalNotes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_KristalNotes.Name = "dgv_KristalNotes";
            this.dgv_KristalNotes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_KristalNotes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_KristalNotes.RowHeadersVisible = false;
            this.dgv_KristalNotes.RowTemplate.Height = 24;
            this.dgv_KristalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_KristalNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KristalNotes.Size = new System.Drawing.Size(430, 140);
            this.dgv_KristalNotes.TabIndex = 87;
            this.dgv_KristalNotes.TabStop = false;
            // 
            // btn_Kristal_InsertKristalNote
            // 
            this.btn_Kristal_InsertKristalNote.Location = new System.Drawing.Point(390, 267);
            this.btn_Kristal_InsertKristalNote.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Kristal_InsertKristalNote.Name = "btn_Kristal_InsertKristalNote";
            this.btn_Kristal_InsertKristalNote.Size = new System.Drawing.Size(55, 40);
            this.btn_Kristal_InsertKristalNote.TabIndex = 86;
            this.btn_Kristal_InsertKristalNote.Text = "Add Note";
            this.btn_Kristal_InsertKristalNote.UseVisualStyleBackColor = true;
            this.btn_Kristal_InsertKristalNote.Click += new System.EventHandler(this.btn_Kristal_InsertKristalNote_Click);
            // 
            // btn_Kristal_Create
            // 
            this.btn_Kristal_Create.Location = new System.Drawing.Point(15, 456);
            this.btn_Kristal_Create.Name = "btn_Kristal_Create";
            this.btn_Kristal_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_Create.TabIndex = 90;
            this.btn_Kristal_Create.Text = "Create";
            this.btn_Kristal_Create.UseVisualStyleBackColor = true;
            this.btn_Kristal_Create.Click += new System.EventHandler(this.btn_Kristal_Create_Click);
            // 
            // btn_Kristal_Refresh
            // 
            this.btn_Kristal_Refresh.Location = new System.Drawing.Point(127, 456);
            this.btn_Kristal_Refresh.Name = "btn_Kristal_Refresh";
            this.btn_Kristal_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_Refresh.TabIndex = 91;
            this.btn_Kristal_Refresh.Text = "Refresh";
            this.btn_Kristal_Refresh.UseVisualStyleBackColor = true;
            this.btn_Kristal_Refresh.Click += new System.EventHandler(this.btn_Kristal_Refresh_Click);
            // 
            // btn_Kristal_Apply
            // 
            this.btn_Kristal_Apply.Location = new System.Drawing.Point(208, 456);
            this.btn_Kristal_Apply.Name = "btn_Kristal_Apply";
            this.btn_Kristal_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Kristal_Apply.TabIndex = 92;
            this.btn_Kristal_Apply.Text = "Apply";
            this.btn_Kristal_Apply.UseVisualStyleBackColor = true;
            this.btn_Kristal_Apply.Click += new System.EventHandler(this.btn_Kristal_Apply_Click);
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Faculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(272, 86);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(173, 21);
            this.cb_Faculty.TabIndex = 94;
            // 
            // lbl_Faculty
            // 
            this.lbl_Faculty.AutoSize = true;
            this.lbl_Faculty.Location = new System.Drawing.Point(225, 89);
            this.lbl_Faculty.Name = "lbl_Faculty";
            this.lbl_Faculty.Size = new System.Drawing.Size(41, 13);
            this.lbl_Faculty.TabIndex = 93;
            this.lbl_Faculty.Text = "Faculty";
            // 
            // cb_PI
            // 
            this.cb_PI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_PI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PI.FormattingEnabled = true;
            this.cb_PI.Location = new System.Drawing.Point(34, 59);
            this.cb_PI.Name = "cb_PI";
            this.cb_PI.Size = new System.Drawing.Size(173, 21);
            this.cb_PI.TabIndex = 96;
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(12, 62);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(17, 13);
            this.lbl_pPI.TabIndex = 95;
            this.lbl_pPI.Text = "PI";
            // 
            // cb_Location
            // 
            this.cb_Location.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_Location.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Location.FormattingEnabled = true;
            this.cb_Location.Location = new System.Drawing.Point(272, 59);
            this.cb_Location.Name = "cb_Location";
            this.cb_Location.Size = new System.Drawing.Size(173, 21);
            this.cb_Location.TabIndex = 98;
            // 
            // lbl_Location
            // 
            this.lbl_Location.AutoSize = true;
            this.lbl_Location.Location = new System.Drawing.Point(218, 62);
            this.lbl_Location.Name = "lbl_Location";
            this.lbl_Location.Size = new System.Drawing.Size(48, 13);
            this.lbl_Location.TabIndex = 97;
            this.lbl_Location.Text = "Location";
            // 
            // frm_Kristal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Kristal_Cancel;
            this.ClientSize = new System.Drawing.Size(458, 485);
            this.Controls.Add(this.cb_Location);
            this.Controls.Add(this.lbl_Location);
            this.Controls.Add(this.cb_PI);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.cb_Faculty);
            this.Controls.Add(this.lbl_Faculty);
            this.Controls.Add(this.btn_Kristal_Apply);
            this.Controls.Add(this.btn_Kristal_Refresh);
            this.Controls.Add(this.btn_Kristal_Create);
            this.Controls.Add(this.tb_NewKristalNote);
            this.Controls.Add(this.dgv_KristalNotes);
            this.Controls.Add(this.btn_Kristal_InsertKristalNote);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KristalNotes)).EndInit();
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
        private System.Windows.Forms.TextBox tb_NewKristalNote;
        private System.Windows.Forms.DataGridView dgv_KristalNotes;
        private System.Windows.Forms.Button btn_Kristal_InsertKristalNote;
        private System.Windows.Forms.Button btn_Kristal_Create;
        private System.Windows.Forms.Button btn_Kristal_Refresh;
        private System.Windows.Forms.Button btn_Kristal_Apply;
        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Label lbl_Faculty;
        private System.Windows.Forms.ComboBox cb_PI;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.ComboBox cb_Location;
        private System.Windows.Forms.Label lbl_Location;
    }
}