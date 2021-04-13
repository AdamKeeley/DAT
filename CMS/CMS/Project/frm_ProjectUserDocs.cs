using DataControlsLib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectUserDocs : Form
    {
        public frm_ProjectUserDocs(string pNumber, string pName)
        {
            InitializeComponent();
            //setTabIndex();
            setProjectUserDocs(pNumber, pName);
        }

        private void setProjectUserDocs(string pNumber, string pName)
        {
            lbl_ProjectNumber.Text = pNumber;
            lbl_ProjectName.Text = pName;

            DataSet ds_ProjectUserDocs = new DataSet();
            try
            {
                //use the central connection string from the SQL_Stuff class
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SQL_Stuff.getDataTable(conn, ds_ProjectUserDocs, "tblProjectUserDocs",
                        $"exec dbo.sp_UserDocStatusByProject '{pNumber}'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate ds_ProjectUserDocs DataSet" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            DataTable dt_dgv_ProjectUserDocs = new DataTable();

            dt_dgv_ProjectUserDocs.Columns.Add("User Status");
            dt_dgv_ProjectUserDocs.Columns.Add("Name");
            dt_dgv_ProjectUserDocs.Columns.Add("SEED Confidentiality Agreement");
            dt_dgv_ProjectUserDocs.Columns.Add("IRC User Agreement");
            dt_dgv_ProjectUserDocs.Columns.Add("LASER User Agreement");
            dt_dgv_ProjectUserDocs.Columns.Add("Information Security Essentials");
            dt_dgv_ProjectUserDocs.Columns.Add("Information Security Advanced");
            dt_dgv_ProjectUserDocs.Columns.Add("SAFE Researcher Training");

            DataRow row;
            foreach (DataRow upRow in ds_ProjectUserDocs.Tables["tblProjectUserDocs"].Rows)
            {
                row = dt_dgv_ProjectUserDocs.NewRow();
                row["User Status"] = upRow["User Status"];
                row["Name"] = upRow["Name"];
                row["SEED Confidentiality Agreement"] = upRow["SEED Confidentiality Agreement"];
                row["IRC User Agreement"] = upRow["IRC User Agreement"];
                row["LASER User Agreement"] = upRow["LASER User Agreement"];
                row["Information Security Essentials"] = upRow["Information Security Essentials"];
                row["Information Security Advanced"] = upRow["Information Security Advanced"];
                row["SAFE Researcher Training"] = upRow["SAFE Researcher Training"];
                dt_dgv_ProjectUserDocs.Rows.Add(row);
            }
            dt_dgv_ProjectUserDocs.DefaultView.Sort = "Name Asc";
            dt_dgv_ProjectUserDocs = dt_dgv_ProjectUserDocs.DefaultView.ToTable();

            dgv_ProjectUserDocs.DataSource = dt_dgv_ProjectUserDocs;

            dgv_ProjectUserDocs.Columns["User Status"].Width = 50;
            dgv_ProjectUserDocs.Columns["Name"].Width = 150;
            dgv_ProjectUserDocs.Columns["SEED Confidentiality Agreement"].Width = 100;
            dgv_ProjectUserDocs.Columns["IRC User Agreement"].Width = 100;
            dgv_ProjectUserDocs.Columns["LASER User Agreement"].Width = 100;
            dgv_ProjectUserDocs.Columns["Information Security Essentials"].Width = 100;
            dgv_ProjectUserDocs.Columns["Information Security Advanced"].Width = 100;
            dgv_ProjectUserDocs.Columns["SAFE Researcher Training"].Width = 100;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
