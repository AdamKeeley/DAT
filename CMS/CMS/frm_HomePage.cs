using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CMS.DataTracking;
using CMS.DSAs;
using DataControlsLib;

namespace CMS
{
    public partial class frm_HomePage : Form
    {
        public frm_HomePage()
        {
            InitializeComponent();
            setTabIndex();
            setCredentials();
            setTFTD();
        }

        private void setCredentials()
        {
            using (frm_Login Login = new frm_Login())
            {
                Login.ShowDialog();

            }
        }

        private void setTFTD()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryGetTFTD = new SqlCommand();
                    qryGetTFTD.Connection = conn;
                    qryGetTFTD.CommandText =$"select top 1 tftd from dbo.tlkTFTD order by newid()";
                    conn.Open();
                    lbl_TFTD.Text = (string)qryGetTFTD.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            gb_Projects.TabIndex        = 0;
            btn_GoToProjects.TabIndex   = 1;
            btn_AddProject.TabIndex     = 2;
            
            gb_Users.TabIndex           = 3;
            btn_GoToUsers.TabIndex      = 4;
            btn_AddUser.TabIndex        = 5;

            gb_DSAs.TabIndex            = 6;
            btn_DSAsView.TabIndex       = 7;
            btn_DSAs.TabIndex           = 8;
            btn_DSAsUpdate.TabIndex     = 9;
            btn_DataOwnerAdd.TabIndex   = 10;

            gb_DataTracking.TabIndex    = 11;
            btn_GoToDataIO.TabIndex     = 12;
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
