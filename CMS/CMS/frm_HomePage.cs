using System;
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
            frm_ProjectAdd ProjectAddForm = new frm_ProjectAdd();
            ProjectAddForm.Show();
        }

        private void btn_GoToUser_Click(object sender, EventArgs e)
        {
            frm_UserAll UserAll = new frm_UserAll();
            UserAll.Show();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            frm_UserAdd UserAdd = new frm_UserAdd();
            UserAdd.Show();
        }

        private void btn_DataOwnerAdd_Click(object sender, EventArgs e)
        {
            frm_DsaDataOwnerAdd DataOwnerAddForm = new frm_DsaDataOwnerAdd();
            DataOwnerAddForm.Show();
        }
    }
}
