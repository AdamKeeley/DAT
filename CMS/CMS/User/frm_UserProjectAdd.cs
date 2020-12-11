using System;
using System.Data;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_UserProjectAdd : Form
    {
        public frm_UserProjectAdd(int uNumber, DataSet ds_User)
        {
            InitializeComponent();
            setTabIndex();
            setVariablesAndControl(uNumber, ds_User);
        }

        int UserNumber;
        DataSet ds;

        private void setVariablesAndControl(int uNumber, DataSet ds_User)
        {
            try
            {
                //set variables
                UserNumber = uNumber;
                ds = ds_User;

                //set controls values
                cb_pNumberValue.DataSource = ds_User.Tables["tblProjects"];
                cb_pNumberValue.ValueMember = "pID";
                cb_pNumberValue.DisplayMember = "ProjectNumber";
                cb_pNumberValue.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setControlValues of class frm_UserProjectAdd has failed" + Environment.NewLine + ex);
                throw;
            }
        }

        private void setProjectName()
        {
            string ProjectNumber = cb_pNumberValue.Text;
            foreach (DataRow r in ds.Tables["tblProjects"].Select($"ProjectNumber = '{ProjectNumber}'"))
            {
                tb_pNameValue.Text = r["ProjectName"].ToString();
            }
        }

        private bool addUserProject()
        {
            string ProjectNumber = cb_pNumberValue.Text;

            User Users = new User();
            if (Users.checkUserProject(UserNumber, ProjectNumber))
            {
                Users.insertUserProject(UserNumber, ProjectNumber);
                MessageBox.Show("Project added");
                return true;
            }
            else
            {
                MessageBox.Show("Project already present on User record.");
                return false;
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

            cb_pNumberValue.TabIndex = ++x;
            btn_UserProjectAdd_Add.TabIndex = ++x;
            btn_UserProjectAdd_Cancel.TabIndex = ++x;
        }

        private void cb_pNumberValue_SelectionChanged(object sender, EventArgs e)
        {
            setProjectName();
        }

        private void btn_UserProjectAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserProjectAdd_Add_Click(object sender, EventArgs e)
        {
            if(addUserProject() == true)
                this.Close();
        }
    }
}
