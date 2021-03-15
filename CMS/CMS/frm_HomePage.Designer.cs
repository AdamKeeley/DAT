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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HomePage));
            this.btn_GoToDataIO = new System.Windows.Forms.Button();
            this.btn_GoToProjects = new System.Windows.Forms.Button();
            this.btn_DSAs = new System.Windows.Forms.Button();
            this.gb_Projects = new System.Windows.Forms.GroupBox();
            this.btn_AddProject = new System.Windows.Forms.Button();
            this.gb_DataTracking = new System.Windows.Forms.GroupBox();
            this.btn_AddTransfer = new System.Windows.Forms.Button();
            this.gb_DSAs = new System.Windows.Forms.GroupBox();
            this.btn_DSAsView = new System.Windows.Forms.Button();
            this.gb_Users = new System.Windows.Forms.GroupBox();
            this.btn_GoToUsers = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_TFTD = new System.Windows.Forms.Label();
            this.lbl_LoggedInAs = new System.Windows.Forms.Label();
            this.gb_Projects.SuspendLayout();
            this.gb_DataTracking.SuspendLayout();
            this.gb_DSAs.SuspendLayout();
            this.gb_Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GoToDataIO
            // 
            this.btn_GoToDataIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToDataIO.Location = new System.Drawing.Point(29, 37);
            this.btn_GoToDataIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GoToDataIO.Name = "btn_GoToDataIO";
            this.btn_GoToDataIO.Size = new System.Drawing.Size(220, 34);
            this.btn_GoToDataIO.TabIndex = 0;
            this.btn_GoToDataIO.Text = "View File Transfers";
            this.btn_GoToDataIO.UseVisualStyleBackColor = true;
            this.btn_GoToDataIO.Click += new System.EventHandler(this.btn_GoToDataIO_Click);
            // 
            // btn_GoToProjects
            // 
            this.btn_GoToProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToProjects.Location = new System.Drawing.Point(29, 38);
            this.btn_GoToProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GoToProjects.Name = "btn_GoToProjects";
            this.btn_GoToProjects.Size = new System.Drawing.Size(220, 34);
            this.btn_GoToProjects.TabIndex = 1;
            this.btn_GoToProjects.Text = "View Projects";
            this.btn_GoToProjects.UseVisualStyleBackColor = true;
            this.btn_GoToProjects.Click += new System.EventHandler(this.btn_GoToProjects_Click);
            // 
            // btn_DSAs
            // 
            this.btn_DSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAs.Location = new System.Drawing.Point(29, 76);
            this.btn_DSAs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DSAs.Name = "btn_DSAs";
            this.btn_DSAs.Size = new System.Drawing.Size(220, 34);
            this.btn_DSAs.TabIndex = 2;
            this.btn_DSAs.Text = "Add New DSA";
            this.btn_DSAs.UseVisualStyleBackColor = true;
            this.btn_DSAs.Click += new System.EventHandler(this.btn_DSAs_Click);
            // 
            // gb_Projects
            // 
            this.gb_Projects.Controls.Add(this.btn_AddProject);
            this.gb_Projects.Controls.Add(this.btn_GoToProjects);
            this.gb_Projects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Projects.Location = new System.Drawing.Point(15, 87);
            this.gb_Projects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Projects.Name = "gb_Projects";
            this.gb_Projects.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Projects.Size = new System.Drawing.Size(279, 140);
            this.gb_Projects.TabIndex = 3;
            this.gb_Projects.TabStop = false;
            this.gb_Projects.Text = "Projects";
            // 
            // btn_AddProject
            // 
            this.btn_AddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddProject.Location = new System.Drawing.Point(29, 79);
            this.btn_AddProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddProject.Name = "btn_AddProject";
            this.btn_AddProject.Size = new System.Drawing.Size(220, 34);
            this.btn_AddProject.TabIndex = 2;
            this.btn_AddProject.Text = "Add New Project";
            this.btn_AddProject.UseVisualStyleBackColor = true;
            this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
            // 
            // gb_DataTracking
            // 
            this.gb_DataTracking.Controls.Add(this.btn_AddTransfer);
            this.gb_DataTracking.Controls.Add(this.btn_GoToDataIO);
            this.gb_DataTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataTracking.Location = new System.Drawing.Point(299, 233);
            this.gb_DataTracking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DataTracking.Name = "gb_DataTracking";
            this.gb_DataTracking.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DataTracking.Size = new System.Drawing.Size(279, 137);
            this.gb_DataTracking.TabIndex = 4;
            this.gb_DataTracking.TabStop = false;
            this.gb_DataTracking.Text = "File Transfers";
            // 
            // btn_AddTransfer
            // 
            this.btn_AddTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddTransfer.Location = new System.Drawing.Point(29, 75);
            this.btn_AddTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddTransfer.Name = "btn_AddTransfer";
            this.btn_AddTransfer.Size = new System.Drawing.Size(220, 34);
            this.btn_AddTransfer.TabIndex = 1;
            this.btn_AddTransfer.Text = "Add File Transfer";
            this.btn_AddTransfer.UseVisualStyleBackColor = true;
            this.btn_AddTransfer.Click += new System.EventHandler(this.btn_AddTransfer_Click);
            // 
            // gb_DSAs
            // 
            this.gb_DSAs.Controls.Add(this.btn_DSAsView);
            this.gb_DSAs.Controls.Add(this.btn_DSAs);
            this.gb_DSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DSAs.Location = new System.Drawing.Point(15, 233);
            this.gb_DSAs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DSAs.Name = "gb_DSAs";
            this.gb_DSAs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_DSAs.Size = new System.Drawing.Size(279, 137);
            this.gb_DSAs.TabIndex = 5;
            this.gb_DSAs.TabStop = false;
            this.gb_DSAs.Text = "DSAs";
            // 
            // btn_DSAsView
            // 
            this.btn_DSAsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAsView.Location = new System.Drawing.Point(29, 37);
            this.btn_DSAsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DSAsView.Name = "btn_DSAsView";
            this.btn_DSAsView.Size = new System.Drawing.Size(220, 34);
            this.btn_DSAsView.TabIndex = 3;
            this.btn_DSAsView.Text = "View DSAs";
            this.btn_DSAsView.UseVisualStyleBackColor = true;
            this.btn_DSAsView.Click += new System.EventHandler(this.btn_DSAsView_Click);
            // 
            // gb_Users
            // 
            this.gb_Users.Controls.Add(this.btn_GoToUsers);
            this.gb_Users.Controls.Add(this.btn_AddUser);
            this.gb_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Users.Location = new System.Drawing.Point(299, 87);
            this.gb_Users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Users.Name = "gb_Users";
            this.gb_Users.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_Users.Size = new System.Drawing.Size(279, 140);
            this.gb_Users.TabIndex = 6;
            this.gb_Users.TabStop = false;
            this.gb_Users.Text = "Users";
            // 
            // btn_GoToUsers
            // 
            this.btn_GoToUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToUsers.Location = new System.Drawing.Point(29, 38);
            this.btn_GoToUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GoToUsers.Name = "btn_GoToUsers";
            this.btn_GoToUsers.Size = new System.Drawing.Size(220, 34);
            this.btn_GoToUsers.TabIndex = 4;
            this.btn_GoToUsers.Text = "View Users";
            this.btn_GoToUsers.UseVisualStyleBackColor = true;
            this.btn_GoToUsers.Click += new System.EventHandler(this.btn_GoToUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Location = new System.Drawing.Point(29, 79);
            this.btn_AddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(220, 34);
            this.btn_AddUser.TabIndex = 3;
            this.btn_AddUser.Text = "Add New User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 66);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_TFTD
            // 
            this.lbl_TFTD.Location = new System.Drawing.Point(300, 335);
            this.lbl_TFTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TFTD.Name = "lbl_TFTD";
            this.lbl_TFTD.Size = new System.Drawing.Size(277, 81);
            this.lbl_TFTD.TabIndex = 8;
            this.lbl_TFTD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_LoggedInAs
            // 
            this.lbl_LoggedInAs.Location = new System.Drawing.Point(299, 416);
            this.lbl_LoggedInAs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LoggedInAs.Name = "lbl_LoggedInAs";
            this.lbl_LoggedInAs.Size = new System.Drawing.Size(279, 28);
            this.lbl_LoggedInAs.TabIndex = 9;
            this.lbl_LoggedInAs.Text = "UserName";
            this.lbl_LoggedInAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 458);
            this.Controls.Add(this.lbl_LoggedInAs);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_Users);
            this.Controls.Add(this.gb_DSAs);
            this.Controls.Add(this.gb_DataTracking);
            this.Controls.Add(this.gb_Projects);
            this.Controls.Add(this.lbl_TFTD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_HomePage";
            this.Text = "PRISM";
            this.gb_Projects.ResumeLayout(false);
            this.gb_DataTracking.ResumeLayout(false);
            this.gb_DSAs.ResumeLayout(false);
            this.gb_Users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GoToDataIO;
        private System.Windows.Forms.Button btn_GoToProjects;
        private System.Windows.Forms.Button btn_DSAs;
        private System.Windows.Forms.GroupBox gb_Projects;
        private System.Windows.Forms.GroupBox gb_DataTracking;
        private System.Windows.Forms.GroupBox gb_DSAs;
        private System.Windows.Forms.Button btn_AddProject;
        private System.Windows.Forms.GroupBox gb_Users;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_DSAsView;
        private System.Windows.Forms.Button btn_GoToUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_TFTD;
        private System.Windows.Forms.Label lbl_LoggedInAs;
        private System.Windows.Forms.Button btn_AddTransfer;
    }
}