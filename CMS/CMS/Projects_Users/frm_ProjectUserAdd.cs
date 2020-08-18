using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectUserAdd : Form
    {
        public frm_ProjectUserAdd(string pNumber, DataSet ds_prj)
        {
            InitializeComponent();
            setVariablesAndControl(pNumber, ds_prj);
        }

        string ProjectNumber;
        DataSet ds_Project;

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
