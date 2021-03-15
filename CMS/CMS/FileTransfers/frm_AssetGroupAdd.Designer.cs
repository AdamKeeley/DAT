namespace CMS.FileTransfers
{
    partial class frm_AssetGroupAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssetGroupAdd));
            this.lbx_Files = new System.Windows.Forms.ListBox();
            this.lbl_Files = new System.Windows.Forms.Label();
            this.btn_AddAsset = new System.Windows.Forms.Button();
            this.cb_AssetName = new System.Windows.Forms.ComboBox();
            this.lbl_AssetName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbx_Files
            // 
            this.lbx_Files.FormattingEnabled = true;
            this.lbx_Files.ItemHeight = 16;
            this.lbx_Files.Location = new System.Drawing.Point(12, 162);
            this.lbx_Files.Name = "lbx_Files";
            this.lbx_Files.Size = new System.Drawing.Size(531, 356);
            this.lbx_Files.TabIndex = 0;
            // 
            // lbl_Files
            // 
            this.lbl_Files.AutoSize = true;
            this.lbl_Files.Location = new System.Drawing.Point(13, 139);
            this.lbl_Files.Name = "lbl_Files";
            this.lbl_Files.Size = new System.Drawing.Size(163, 17);
            this.lbl_Files.TabIndex = 1;
            this.lbl_Files.Text = "File transfer(s) in review:";
            // 
            // btn_AddAsset
            // 
            this.btn_AddAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAsset.Location = new System.Drawing.Point(145, 12);
            this.btn_AddAsset.Name = "btn_AddAsset";
            this.btn_AddAsset.Size = new System.Drawing.Size(263, 41);
            this.btn_AddAsset.TabIndex = 2;
            this.btn_AddAsset.Text = "Add Selected Files To Asset";
            this.btn_AddAsset.UseVisualStyleBackColor = true;
            this.btn_AddAsset.Click += new System.EventHandler(this.btn_AddAsset_Click);
            // 
            // cb_AssetName
            // 
            this.cb_AssetName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_AssetName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_AssetName.FormattingEnabled = true;
            this.cb_AssetName.Location = new System.Drawing.Point(16, 97);
            this.cb_AssetName.Name = "cb_AssetName";
            this.cb_AssetName.Size = new System.Drawing.Size(527, 24);
            this.cb_AssetName.TabIndex = 3;
            // 
            // lbl_AssetName
            // 
            this.lbl_AssetName.AutoSize = true;
            this.lbl_AssetName.Location = new System.Drawing.Point(16, 74);
            this.lbl_AssetName.Name = "lbl_AssetName";
            this.lbl_AssetName.Size = new System.Drawing.Size(362, 17);
            this.lbl_AssetName.TabIndex = 4;
            this.lbl_AssetName.Text = "Select existing asset from list or type in new asset name:";
            // 
            // frm_AssetGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 530);
            this.Controls.Add(this.lbl_AssetName);
            this.Controls.Add(this.cb_AssetName);
            this.Controls.Add(this.btn_AddAsset);
            this.Controls.Add(this.lbl_Files);
            this.Controls.Add(this.lbx_Files);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AssetGroupAdd";
            this.Text = "Add Asset Group To Transfer Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_Files;
        private System.Windows.Forms.Label lbl_Files;
        private System.Windows.Forms.Button btn_AddAsset;
        private System.Windows.Forms.ComboBox cb_AssetName;
        private System.Windows.Forms.Label lbl_AssetName;
    }
}