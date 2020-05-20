namespace CMS
{
    partial class frm_HomePage
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
            this.btn_GoToDataIO = new System.Windows.Forms.Button();
            this.btn_GoToProjects = new System.Windows.Forms.Button();
            this.btn_DSAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GoToDataIO
            // 
            this.btn_GoToDataIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToDataIO.Location = new System.Drawing.Point(472, 162);
            this.btn_GoToDataIO.Name = "btn_GoToDataIO";
            this.btn_GoToDataIO.Size = new System.Drawing.Size(145, 63);
            this.btn_GoToDataIO.TabIndex = 0;
            this.btn_GoToDataIO.Text = "Data I/O Requests";
            this.btn_GoToDataIO.UseVisualStyleBackColor = true;
            this.btn_GoToDataIO.Click += new System.EventHandler(this.btn_GoToDataIO_Click);
            // 
            // btn_GoToProjects
            // 
            this.btn_GoToProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToProjects.Location = new System.Drawing.Point(163, 162);
            this.btn_GoToProjects.Name = "btn_GoToProjects";
            this.btn_GoToProjects.Size = new System.Drawing.Size(145, 63);
            this.btn_GoToProjects.TabIndex = 1;
            this.btn_GoToProjects.Text = "Project\r\nDetails";
            this.btn_GoToProjects.UseVisualStyleBackColor = true;
            this.btn_GoToProjects.Click += new System.EventHandler(this.btn_GoToProjects_Click);
            // 
            // btn_DSAs
            // 
            this.btn_DSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAs.Location = new System.Drawing.Point(472, 281);
            this.btn_DSAs.Name = "btn_DSAs";
            this.btn_DSAs.Size = new System.Drawing.Size(145, 63);
            this.btn_DSAs.TabIndex = 2;
            this.btn_DSAs.Text = "Add DSA";
            this.btn_DSAs.UseVisualStyleBackColor = true;
            this.btn_DSAs.Click += new System.EventHandler(this.btn_DSAs_Click);
            // 
            // frm_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_DSAs);
            this.Controls.Add(this.btn_GoToProjects);
            this.Controls.Add(this.btn_GoToDataIO);
            this.Name = "frm_HomePage";
            this.Text = "frm_HomePage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GoToDataIO;
        private System.Windows.Forms.Button btn_GoToProjects;
        private System.Windows.Forms.Button btn_DSAs;
    }
}