using System;
using System.Data;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectUserAdd : Form
    {
        public frm_ProjectUserAdd(string pNumber, DataSet ds_prj)
        {
            InitializeComponent();
            setTabIndex();
            setVariablesAndControl(pNumber, ds_prj);
        }

        string ProjectNumber;
        DataSet ds_Project;

        /// <summary>
        /// Method to generate set DataSource to the ComboBox.
        /// Uses DataSet parameter (ds_Project) that contains ComboBox DataSource for drop down options
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="ds_prj"></param>
        private void setVariablesAndControl(string pNumber, DataSet ds_prj)
        {
            try
            {
                //set variables
                ProjectNumber = pNumber;
                ds_Project = ds_prj;

                //set controls values
                cb_Researcher.DataSource = ds_prj.Tables["tblUser"];
                cb_Researcher.ValueMember = "UserNumber";
                cb_Researcher.DisplayMember = "FullName";
                cb_Researcher.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setControlValues of class frm_ProjectUserAdd has failed" + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Calls method from Users class to check active record doesn't already exist in tblUserProject.
        /// Inserts new record if not.
        /// </summary>
        private void addProjectUser()
        {
            int UserNumber = (int)cb_Researcher.SelectedValue;

            User Users = new User();
            if (Users.checkUserProject(UserNumber, ProjectNumber))
            {
                Users.insertUserProject(UserNumber, ProjectNumber);
                MessageBox.Show("User added");
            }
        }

        /// <summary>
        /// Each control on form assigned a tab index.
        /// If any controls are added/removed it's easier to change here than on actual form!
        /// </summary>
        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            x = 0;

            cb_Researcher.TabIndex = ++x;
            btn_UserProjectAdd_Add.TabIndex = ++x;
            btn_UserProjectAdd_Cancel.TabIndex = ++x;
        }

        private void btn_UserProjectAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserProjectAdd_Add_Click(object sender, EventArgs e)
        {
            addProjectUser();
            this.Close();
        }
    }
}
