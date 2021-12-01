namespace CMS.RIDM
{
    partial class frm_KristalProjectAdd
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
            this.btn_UserProjectAdd_Add = new System.Windows.Forms.Button();
            this.btn_UserProjectAdd_Cancel = new System.Windows.Forms.Button();
            this.cb_pNumberValue = new System.Windows.Forms.ComboBox();
            this.tb_pNameValue = new System.Windows.Forms.TextBox();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.lbl_pNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_UserProjectAdd_Add
            // 
            this.btn_UserProjectAdd_Add.Location = new System.Drawing.Point(351, 56);
            this.btn_UserProjectAdd_Add.Name = "btn_UserProjectAdd_Add";
            this.btn_UserProjectAdd_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_UserProjectAdd_Add.TabIndex = 15;
            this.btn_UserProjectAdd_Add.Text = "Add";
            this.btn_UserProjectAdd_Add.UseVisualStyleBackColor = true;
            this.btn_UserProjectAdd_Add.Click += new System.EventHandler(this.btn_UserProjectAdd_Add_Click);
            // 
            // btn_UserProjectAdd_Cancel
            // 
            this.btn_UserProjectAdd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_UserProjectAdd_Cancel.Location = new System.Drawing.Point(432, 56);
            this.btn_UserProjectAdd_Cancel.Name = "btn_UserProjectAdd_Cancel";
            this.btn_UserProjectAdd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_UserProjectAdd_Cancel.TabIndex = 14;
            this.btn_UserProjectAdd_Cancel.Text = "Cancel";
            this.btn_UserProjectAdd_Cancel.UseVisualStyleBackColor = true;
            this.btn_UserProjectAdd_Cancel.Click += new System.EventHandler(this.btn_UserProjectAdd_Cancel_Click);
            // 
            // cb_pNumberValue
            // 
            this.cb_pNumberValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pNumberValue.FormattingEnabled = true;
            this.cb_pNumberValue.Location = new System.Drawing.Point(120, 7);
            this.cb_pNumberValue.Margin = new System.Windows.Forms.Padding(2);
            this.cb_pNumberValue.Name = "cb_pNumberValue";
            this.cb_pNumberValue.Size = new System.Drawing.Size(92, 21);
            this.cb_pNumberValue.TabIndex = 11;
            this.cb_pNumberValue.SelectedValueChanged += new System.EventHandler(this.cb_pNumberValue_SelectionChanged);
            // 
            // tb_pNameValue
            // 
            this.tb_pNameValue.Location = new System.Drawing.Point(120, 31);
            this.tb_pNameValue.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pNameValue.MaxLength = 100;
            this.tb_pNameValue.Name = "tb_pNameValue";
            this.tb_pNameValue.ReadOnly = true;
            this.tb_pNameValue.Size = new System.Drawing.Size(387, 20);
            this.tb_pNameValue.TabIndex = 13;
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(12, 34);
            this.lbl_pName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(63, 13);
            this.lbl_pName.TabIndex = 12;
            this.lbl_pName.Text = "Project Title";
            // 
            // lbl_pNumber
            // 
            this.lbl_pNumber.AutoSize = true;
            this.lbl_pNumber.Location = new System.Drawing.Point(11, 9);
            this.lbl_pNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pNumber.Name = "lbl_pNumber";
            this.lbl_pNumber.Size = new System.Drawing.Size(80, 13);
            this.lbl_pNumber.TabIndex = 10;
            this.lbl_pNumber.Text = "Project Number";
            // 
            // frm_KristalProjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_UserProjectAdd_Cancel;
            this.ClientSize = new System.Drawing.Size(517, 89);
            this.Controls.Add(this.btn_UserProjectAdd_Add);
            this.Controls.Add(this.btn_UserProjectAdd_Cancel);
            this.Controls.Add(this.cb_pNumberValue);
            this.Controls.Add(this.tb_pNameValue);
            this.Controls.Add(this.lbl_pName);
            this.Controls.Add(this.lbl_pNumber);
            this.Name = "frm_KristalProjectAdd";
            this.Text = "Add Project to Grant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_UserProjectAdd_Add;
        private System.Windows.Forms.Button btn_UserProjectAdd_Cancel;
        private System.Windows.Forms.ComboBox cb_pNumberValue;
        private System.Windows.Forms.TextBox tb_pNameValue;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.Label lbl_pNumber;
    }
}