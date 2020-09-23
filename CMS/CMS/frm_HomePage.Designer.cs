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
            this.gb_DSAs = new System.Windows.Forms.GroupBox();
            this.btn_DataOwnerAdd = new System.Windows.Forms.Button();
            this.btn_DSAsUpdate = new System.Windows.Forms.Button();
            this.btn_DSAsView = new System.Windows.Forms.Button();
            this.gb_Users = new System.Windows.Forms.GroupBox();
            this.btn_GoToUsers = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.btn_GoToDataIO.Location = new System.Drawing.Point(22, 30);
            this.btn_GoToDataIO.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GoToDataIO.Name = "btn_GoToDataIO";
            this.btn_GoToDataIO.Size = new System.Drawing.Size(165, 28);
            this.btn_GoToDataIO.TabIndex = 0;
            this.btn_GoToDataIO.Text = "View Data I/O Requests";
            this.btn_GoToDataIO.UseVisualStyleBackColor = true;
            this.btn_GoToDataIO.Click += new System.EventHandler(this.btn_GoToDataIO_Click);
            // 
            // btn_GoToProjects
            // 
            this.btn_GoToProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToProjects.Location = new System.Drawing.Point(22, 31);
            this.btn_GoToProjects.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GoToProjects.Name = "btn_GoToProjects";
            this.btn_GoToProjects.Size = new System.Drawing.Size(165, 28);
            this.btn_GoToProjects.TabIndex = 1;
            this.btn_GoToProjects.Text = "View Projects";
            this.btn_GoToProjects.UseVisualStyleBackColor = true;
            this.btn_GoToProjects.Click += new System.EventHandler(this.btn_GoToProjects_Click);
            // 
            // btn_DSAs
            // 
            this.btn_DSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAs.Location = new System.Drawing.Point(22, 62);
            this.btn_DSAs.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DSAs.Name = "btn_DSAs";
            this.btn_DSAs.Size = new System.Drawing.Size(165, 28);
            this.btn_DSAs.TabIndex = 2;
            this.btn_DSAs.Text = "Add a New DSA";
            this.btn_DSAs.UseVisualStyleBackColor = true;
            this.btn_DSAs.Click += new System.EventHandler(this.btn_DSAs_Click);
            // 
            // gb_Projects
            // 
            this.gb_Projects.Controls.Add(this.btn_AddProject);
            this.gb_Projects.Controls.Add(this.btn_GoToProjects);
            this.gb_Projects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Projects.Location = new System.Drawing.Point(11, 71);
            this.gb_Projects.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Projects.Name = "gb_Projects";
            this.gb_Projects.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Projects.Size = new System.Drawing.Size(209, 114);
            this.gb_Projects.TabIndex = 3;
            this.gb_Projects.TabStop = false;
            this.gb_Projects.Text = "Projects";
            // 
            // btn_AddProject
            // 
            this.btn_AddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddProject.Location = new System.Drawing.Point(22, 64);
            this.btn_AddProject.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AddProject.Name = "btn_AddProject";
            this.btn_AddProject.Size = new System.Drawing.Size(165, 28);
            this.btn_AddProject.TabIndex = 2;
            this.btn_AddProject.Text = "Add New Project";
            this.btn_AddProject.UseVisualStyleBackColor = true;
            this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
            // 
            // gb_DataTracking
            // 
            this.gb_DataTracking.Controls.Add(this.btn_GoToDataIO);
            this.gb_DataTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DataTracking.Location = new System.Drawing.Point(224, 189);
            this.gb_DataTracking.Margin = new System.Windows.Forms.Padding(2);
            this.gb_DataTracking.Name = "gb_DataTracking";
            this.gb_DataTracking.Padding = new System.Windows.Forms.Padding(2);
            this.gb_DataTracking.Size = new System.Drawing.Size(209, 81);
            this.gb_DataTracking.TabIndex = 4;
            this.gb_DataTracking.TabStop = false;
            this.gb_DataTracking.Text = "Data Tracking";
            // 
            // gb_DSAs
            // 
            this.gb_DSAs.Controls.Add(this.btn_DataOwnerAdd);
            this.gb_DSAs.Controls.Add(this.btn_DSAsUpdate);
            this.gb_DSAs.Controls.Add(this.btn_DSAsView);
            this.gb_DSAs.Controls.Add(this.btn_DSAs);
            this.gb_DSAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_DSAs.Location = new System.Drawing.Point(11, 189);
            this.gb_DSAs.Margin = new System.Windows.Forms.Padding(2);
            this.gb_DSAs.Name = "gb_DSAs";
            this.gb_DSAs.Padding = new System.Windows.Forms.Padding(2);
            this.gb_DSAs.Size = new System.Drawing.Size(209, 172);
            this.gb_DSAs.TabIndex = 5;
            this.gb_DSAs.TabStop = false;
            this.gb_DSAs.Text = "DSAs";
            // 
            // btn_DataOwnerAdd
            // 
            this.btn_DataOwnerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DataOwnerAdd.Location = new System.Drawing.Point(22, 126);
            this.btn_DataOwnerAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DataOwnerAdd.Name = "btn_DataOwnerAdd";
            this.btn_DataOwnerAdd.Size = new System.Drawing.Size(165, 28);
            this.btn_DataOwnerAdd.TabIndex = 5;
            this.btn_DataOwnerAdd.Text = "Add a New Data Owner";
            this.btn_DataOwnerAdd.UseVisualStyleBackColor = true;
            this.btn_DataOwnerAdd.Click += new System.EventHandler(this.btn_DataOwnerAdd_Click);
            // 
            // btn_DSAsUpdate
            // 
            this.btn_DSAsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAsUpdate.Location = new System.Drawing.Point(22, 94);
            this.btn_DSAsUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DSAsUpdate.Name = "btn_DSAsUpdate";
            this.btn_DSAsUpdate.Size = new System.Drawing.Size(165, 28);
            this.btn_DSAsUpdate.TabIndex = 4;
            this.btn_DSAsUpdate.Text = "Update a DSA record";
            this.btn_DSAsUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_DSAsView
            // 
            this.btn_DSAsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSAsView.Location = new System.Drawing.Point(22, 30);
            this.btn_DSAsView.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DSAsView.Name = "btn_DSAsView";
            this.btn_DSAsView.Size = new System.Drawing.Size(165, 28);
            this.btn_DSAsView.TabIndex = 3;
            this.btn_DSAsView.Text = "View DSAs";
            this.btn_DSAsView.UseVisualStyleBackColor = true;
            // 
            // gb_Users
            // 
            this.gb_Users.Controls.Add(this.btn_GoToUsers);
            this.gb_Users.Controls.Add(this.btn_AddUser);
            this.gb_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Users.Location = new System.Drawing.Point(224, 71);
            this.gb_Users.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Users.Name = "gb_Users";
            this.gb_Users.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Users.Size = new System.Drawing.Size(209, 114);
            this.gb_Users.TabIndex = 6;
            this.gb_Users.TabStop = false;
            this.gb_Users.Text = "Users";
            // 
            // btn_GoToUsers
            // 
            this.btn_GoToUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoToUsers.Location = new System.Drawing.Point(22, 31);
            this.btn_GoToUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GoToUsers.Name = "btn_GoToUsers";
            this.btn_GoToUsers.Size = new System.Drawing.Size(165, 28);
            this.btn_GoToUsers.TabIndex = 4;
            this.btn_GoToUsers.Text = "View Users";
            this.btn_GoToUsers.UseVisualStyleBackColor = true;
            this.btn_GoToUsers.Click += new System.EventHandler(this.btn_GoToUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Location = new System.Drawing.Point(22, 64);
            this.btn_AddUser.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(165, 28);
            this.btn_AddUser.TabIndex = 3;
            this.btn_AddUser.Text = "Add New User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 54);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frm_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_Users);
            this.Controls.Add(this.gb_DSAs);
            this.Controls.Add(this.gb_DataTracking);
            this.Controls.Add(this.gb_Projects);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_HomePage";
            this.Text = "DAT CMS";
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
        private System.Windows.Forms.Button btn_DataOwnerAdd;
        private System.Windows.Forms.Button btn_DSAsUpdate;
        private System.Windows.Forms.Button btn_DSAsView;
        private System.Windows.Forms.Button btn_GoToUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}