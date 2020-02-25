using System.Collections.Generic;

namespace CMS
{
    partial class frm_Project
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
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pStage = new System.Windows.Forms.Label();
            this.cb_pStage = new System.Windows.Forms.ComboBox();
            this.tb_pPIValue = new System.Windows.Forms.TextBox();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.lbl_pStartDate = new System.Windows.Forms.Label();
            this.lbl_pEndDate = new System.Windows.Forms.Label();
            this.dgv_pNotes = new System.Windows.Forms.DataGridView();
            this.mtb_pEndDateValue = new System.Windows.Forms.MaskedTextBox();
            this.mtb_pStartDateValue = new System.Windows.Forms.MaskedTextBox();
            this.tb_NewProjectNote = new System.Windows.Forms.TextBox();
            this.btn_InsertProjectNote = new System.Windows.Forms.Button();
            this.cb_pNumberValue = new System.Windows.Forms.ComboBox();
            this.btn_ProjectCancel = new System.Windows.Forms.Button();
            this.btn_ProjectOK = new System.Windows.Forms.Button();
            this.btn_ProjectApply = new System.Windows.Forms.Button();
            this.btn_NewProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_pNumber
            // 
            this.lbl_pNumber.AutoSize = true;
            this.lbl_pNumber.Location = new System.Drawing.Point(9, 12);
            this.lbl_pNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pNumber.Name = "lbl_pNumber";
            this.lbl_pNumber.Size = new System.Drawing.Size(80, 13);
            this.lbl_pNumber.TabIndex = 0;
            this.lbl_pNumber.Text = "Project Number";
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(10, 37);
            this.lbl_pName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(63, 13);
            this.lbl_pName.TabIndex = 2;
            this.lbl_pName.Text = "Project Title";
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(118, 34);
            this.tb_pNameValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.Size = new System.Drawing.Size(376, 20);
            this.tb_pNameValue.TabIndex = 3;
            // 
            // lbl_pStage
            // 
            this.lbl_pStage.AutoSize = true;
            this.lbl_pStage.Location = new System.Drawing.Point(10, 82);
            this.lbl_pStage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStage.Name = "lbl_pStage";
            this.lbl_pStage.Size = new System.Drawing.Size(35, 13);
            this.lbl_pStage.TabIndex = 4;
            this.lbl_pStage.Text = "Stage";
            // 
            // cb_pStage
            // 
            this.cb_pStage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_pStage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pStage.FormattingEnabled = true;
            this.cb_pStage.Location = new System.Drawing.Point(118, 80);
            this.cb_pStage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_pStage.Name = "cb_pStage";
            this.cb_pStage.Size = new System.Drawing.Size(92, 21);
            this.cb_pStage.TabIndex = 5;
            // 
            // tb_pPIValue
            // 
            this.tb_pPIValue.Location = new System.Drawing.Point(118, 57);
            this.tb_pPIValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_pPIValue.Name = "tb_pPIValue";
            this.tb_pPIValue.Size = new System.Drawing.Size(173, 20);
            this.tb_pPIValue.TabIndex = 5;
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(10, 60);
            this.lbl_pPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(105, 13);
            this.lbl_pPI.TabIndex = 4;
            this.lbl_pPI.Text = "Principal Investigator";
            // 
            // lbl_pStartDate
            // 
            this.lbl_pStartDate.AutoSize = true;
            this.lbl_pStartDate.Location = new System.Drawing.Point(295, 60);
            this.lbl_pStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pStartDate.Name = "lbl_pStartDate";
            this.lbl_pStartDate.Size = new System.Drawing.Size(55, 13);
            this.lbl_pStartDate.TabIndex = 6;
            this.lbl_pStartDate.Text = "Start Date";
            // 
            // lbl_pEndDate
            // 
            this.lbl_pEndDate.AutoSize = true;
            this.lbl_pEndDate.Location = new System.Drawing.Point(294, 84);
            this.lbl_pEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pEndDate.Name = "lbl_pEndDate";
            this.lbl_pEndDate.Size = new System.Drawing.Size(52, 13);
            this.lbl_pEndDate.TabIndex = 8;
            this.lbl_pEndDate.Text = "End Date";
            // 
            // dgv_pNotes
            // 
            this.dgv_pNotes.AllowUserToAddRows = false;
            this.dgv_pNotes.AllowUserToDeleteRows = false;
            this.dgv_pNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pNotes.Location = new System.Drawing.Point(11, 154);
            this.dgv_pNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_pNotes.Name = "dgv_pNotes";
            this.dgv_pNotes.ReadOnly = true;
            this.dgv_pNotes.RowTemplate.Height = 24;
            this.dgv_pNotes.Size = new System.Drawing.Size(482, 180);
            this.dgv_pNotes.TabIndex = 12;
            this.dgv_pNotes.TabStop = false;
            // 
            // mtb_pEndDateValue
            // 
            this.mtb_pEndDateValue.Location = new System.Drawing.Point(353, 80);
            this.mtb_pEndDateValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtb_pEndDateValue.Mask = "00/00/0000";
            this.mtb_pEndDateValue.Name = "mtb_pEndDateValue";
            this.mtb_pEndDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pEndDateValue.TabIndex = 9;
            this.mtb_pEndDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_pStartDateValue
            // 
            this.mtb_pStartDateValue.Location = new System.Drawing.Point(353, 57);
            this.mtb_pStartDateValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtb_pStartDateValue.Mask = "00/00/0000";
            this.mtb_pStartDateValue.Name = "mtb_pStartDateValue";
            this.mtb_pStartDateValue.Size = new System.Drawing.Size(76, 20);
            this.mtb_pStartDateValue.TabIndex = 7;
            this.mtb_pStartDateValue.ValidatingType = typeof(System.DateTime);
            // 
            // tb_NewProjectNote
            // 
            this.tb_NewProjectNote.Location = new System.Drawing.Point(12, 109);
            this.tb_NewProjectNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_NewProjectNote.MaxLength = 8000;
            this.tb_NewProjectNote.Multiline = true;
            this.tb_NewProjectNote.Name = "tb_NewProjectNote";
            this.tb_NewProjectNote.Size = new System.Drawing.Size(421, 41);
            this.tb_NewProjectNote.TabIndex = 10;
            // 
            // btn_InsertProjectNote
            // 
            this.btn_InsertProjectNote.Location = new System.Drawing.Point(437, 109);
            this.btn_InsertProjectNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_InsertProjectNote.Name = "btn_InsertProjectNote";
            this.btn_InsertProjectNote.Size = new System.Drawing.Size(56, 20);
            this.btn_InsertProjectNote.TabIndex = 11;
            this.btn_InsertProjectNote.Text = "Add Note";
            this.btn_InsertProjectNote.UseVisualStyleBackColor = true;
            this.btn_InsertProjectNote.Click += new System.EventHandler(this.btn_InsertProjectNote_Click);
            // 
            // cb_pNumberValue
            // 
            this.cb_pNumberValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pNumberValue.FormattingEnabled = true;
            this.cb_pNumberValue.Location = new System.Drawing.Point(118, 10);
            this.cb_pNumberValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_pNumberValue.Name = "cb_pNumberValue";
            this.cb_pNumberValue.Size = new System.Drawing.Size(92, 21);
            this.cb_pNumberValue.TabIndex = 1;
            this.cb_pNumberValue.SelectionChangeCommitted += new System.EventHandler(this.cb_pNumberValue_SelectionChanged);
            // 
            // btn_ProjectCancel
            // 
            this.btn_ProjectCancel.Location = new System.Drawing.Point(437, 340);
            this.btn_ProjectCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ProjectCancel.Name = "btn_ProjectCancel";
            this.btn_ProjectCancel.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectCancel.TabIndex = 15;
            this.btn_ProjectCancel.Text = "Cancel";
            this.btn_ProjectCancel.UseVisualStyleBackColor = true;
            this.btn_ProjectCancel.Click += new System.EventHandler(this.btn_ProjectCancel_Click);
            // 
            // btn_ProjectOK
            // 
            this.btn_ProjectOK.Location = new System.Drawing.Point(376, 340);
            this.btn_ProjectOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ProjectOK.Name = "btn_ProjectOK";
            this.btn_ProjectOK.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectOK.TabIndex = 14;
            this.btn_ProjectOK.Text = "OK";
            this.btn_ProjectOK.UseVisualStyleBackColor = true;
            this.btn_ProjectOK.Click += new System.EventHandler(this.btn_ProjectOK_Click);
            // 
            // btn_ProjectApply
            // 
            this.btn_ProjectApply.Location = new System.Drawing.Point(316, 340);
            this.btn_ProjectApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ProjectApply.Name = "btn_ProjectApply";
            this.btn_ProjectApply.Size = new System.Drawing.Size(56, 24);
            this.btn_ProjectApply.TabIndex = 13;
            this.btn_ProjectApply.Text = "Apply";
            this.btn_ProjectApply.UseVisualStyleBackColor = true;
            this.btn_ProjectApply.Click += new System.EventHandler(this.btn_ProjectApply_Click);
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Location = new System.Drawing.Point(12, 340);
            this.btn_NewProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(90, 24);
            this.btn_NewProject.TabIndex = 16;
            this.btn_NewProject.Text = "Create Project";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.btn_NewProject_Click);
            // 
            // frm_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 368);
            this.Controls.Add(this.btn_NewProject);
            this.Controls.Add(this.btn_ProjectApply);
            this.Controls.Add(this.btn_ProjectOK);
            this.Controls.Add(this.btn_ProjectCancel);
            this.Controls.Add(this.cb_pNumberValue);
            this.Controls.Add(this.btn_InsertProjectNote);
            this.Controls.Add(this.tb_NewProjectNote);
            this.Controls.Add(this.mtb_pStartDateValue);
            this.Controls.Add(this.mtb_pEndDateValue);
            this.Controls.Add(this.dgv_pNotes);
            this.Controls.Add(this.lbl_pEndDate);
            this.Controls.Add(this.lbl_pStartDate);
            this.Controls.Add(this.lbl_pPI);
            this.Controls.Add(this.tb_pPIValue);
            this.Controls.Add(this.cb_pStage);
            this.Controls.Add(this.lbl_pStage);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Controls.Add(this.lbl_pNumber);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frm_Project";
            this.Text = "Project Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pNumber;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pStage;
        private System.Windows.Forms.ComboBox cb_pStage;
        private System.Windows.Forms.TextBox tb_pPIValue;
        private System.Windows.Forms.Label lbl_pPI;
        private System.Windows.Forms.Label lbl_pStartDate;
        private System.Windows.Forms.Label lbl_pEndDate;
        private System.Windows.Forms.DataGridView dgv_pNotes;
        private System.Windows.Forms.MaskedTextBox mtb_pEndDateValue;
        private System.Windows.Forms.MaskedTextBox mtb_pStartDateValue;
        private System.Windows.Forms.TextBox tb_NewProjectNote;
        private System.Windows.Forms.Button btn_InsertProjectNote;
        private System.Windows.Forms.ComboBox cb_pNumberValue;
        private System.Windows.Forms.Button btn_ProjectCancel;
        private System.Windows.Forms.Button btn_ProjectOK;
        private System.Windows.Forms.Button btn_ProjectApply;
        private System.Windows.Forms.Button btn_NewProject;
    }
}