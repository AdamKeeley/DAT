using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.DataTracking;
using CMS.DSAs;

namespace CMS
{
    public partial class frm_HomePage : Form
    {
        public frm_HomePage()
        {
            InitializeComponent();
        }

        private void btn_GoToProjects_Click(object sender, EventArgs e)
        {
            frm_ProjectAll ProjectAllForm = new frm_ProjectAll();
            ProjectAllForm.Show();
        }

        private void btn_GoToDataIO_Click(object sender, EventArgs e)
        {
            frm_DataIO DataIOForm = new frm_DataIO();
            DataIOForm.Show();
        }

        private void btn_DSAs_Click(object sender, EventArgs e)
        {
            frm_DsaAdd DsaForm = new frm_DsaAdd();
            DsaForm.Show();
        }

        private void btn_AddProject_Click(object sender, EventArgs e)
        {
            var Projects = new Project();
            frm_ProjectAdd ProjectAddForm = new frm_ProjectAdd(Projects.getProjectsDataSet());
            ProjectAddForm.Show();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            // Must pass user number int to form constructor, which depends on project?
            //frm_User UserForm = new frm_User();
            //UserForm.Show();
        }

        private void btn_DataOwnerAdd_Click(object sender, EventArgs e)
        {
            frm_DsaDataOwnerAdd DataOwnerAddForm = new frm_DsaDataOwnerAdd();
            DataOwnerAddForm.Show();
        }
    }
}
