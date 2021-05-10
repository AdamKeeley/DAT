namespace CMS.FileTransfers
{
    partial class frm_FileListAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FileListAdd));
            this.btn_AddToTransfer = new System.Windows.Forms.Button();
            this.lbl_AddFilesInstructions = new System.Windows.Forms.Label();
            this.tb_FilesList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_AddToTransfer
            // 
            this.btn_AddToTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddToTransfer.Location = new System.Drawing.Point(95, 12);
            this.btn_AddToTransfer.Name = "btn_AddToTransfer";
            this.btn_AddToTransfer.Size = new System.Drawing.Size(256, 39);
            this.btn_AddToTransfer.TabIndex = 0;
            this.btn_AddToTransfer.Text = "Add Files To Transfer Record";
            this.btn_AddToTransfer.UseVisualStyleBackColor = true;
            this.btn_AddToTransfer.Click += new System.EventHandler(this.btn_AddToTransfer_Click);
            // 
            // lbl_AddFilesInstructions
            // 
            this.lbl_AddFilesInstructions.AutoSize = true;
            this.lbl_AddFilesInstructions.Location = new System.Drawing.Point(12, 76);
            this.lbl_AddFilesInstructions.Name = "lbl_AddFilesInstructions";
            this.lbl_AddFilesInstructions.Size = new System.Drawing.Size(392, 17);
            this.lbl_AddFilesInstructions.TabIndex = 2;
            this.lbl_AddFilesInstructions.Text = "Drag and drop list of file names, each on a new line, into box:";
            // 
            // tb_FilesList
            // 
            this.tb_FilesList.AcceptsReturn = true;
            this.tb_FilesList.AllowDrop = true;
            this.tb_FilesList.Location = new System.Drawing.Point(12, 96);
            this.tb_FilesList.Multiline = true;
            this.tb_FilesList.Name = "tb_FilesList";
            this.tb_FilesList.Size = new System.Drawing.Size(438, 246);
            this.tb_FilesList.TabIndex = 3;
            // 
            // frm_FileListAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 354);
            this.Controls.Add(this.tb_FilesList);
            this.Controls.Add(this.lbl_AddFilesInstructions);
            this.Controls.Add(this.btn_AddToTransfer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FileListAdd";
            this.Text = "Add Files List to Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddToTransfer;
        private System.Windows.Forms.Label lbl_AddFilesInstructions;
        private System.Windows.Forms.TextBox tb_FilesList;
    }
}