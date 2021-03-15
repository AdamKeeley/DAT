using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CMS.FileTransfers;
using CMS.DSAs;
using CMS.Login;
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
            checkVersion();
            setTFTD();
        }

        /// <summary>
        /// Release date of the current version of this application. 
        /// Used by checkVersion method to compare to values in dbo.versioning 
        /// </summary>
        DateTime thisRelease = new DateTime(2020, 12, 11);

        /// <summary>
        /// Opens frm_Login, from which the credentials to access the database are captured. Persists the form until 
        /// either a successful login or user cancels (closing application).
        /// </summary>
        private void setCredentials()
        {
            using (frm_Login Login = new frm_Login())
            {
                while (Login.loggedIn == false & Login.loginCancel == false)
                {
                    Login.ShowDialog();
                }
                
                if (Login.loginCancel == true)
                    Environment.Exit(0);
                
                lbl_LoggedInAs.Text = SQL_Stuff.credential.UserId;
            }
        }

        /// <summary>
        /// Queries dbo.versioning for latest [ValidFrom] date and compares it to thisRelease variable in this class.
        /// If date in table is after date in class variable, informs user that newer version is available.
        /// </summary>
        private void checkVersion()
        {
            DateTime latestRelease;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryCheckVersion = new SqlCommand();
                    qryCheckVersion.Connection = conn;
                    qryCheckVersion.CommandText = $"select max(ValidFrom) from dbo.versioning where ValidTo is null";

                    conn.Open();
                    latestRelease = (DateTime)qryCheckVersion.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return;
            }

            // Open new form as dialog to provide url to latest release
            if (latestRelease > thisRelease)
            {
                using (frm_NewRelease frm_NewRelease = new frm_NewRelease(latestRelease))
                {
                    frm_NewRelease.ShowDialog();
                }
            }
        }


        /// <summary>
        /// Silly cliche I couldn't resist. Displays a 'Thought For The Day' on home page, selected at randon from 
        /// a table in the database. Catches (and ignores) all exceptions for little consequence of failure.
        /// </summary>
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
            catch (Exception)
            {
                return;
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

            gb_Projects.TabIndex        = ++x;
            btn_GoToProjects.TabIndex   = ++x;
            btn_AddProject.TabIndex     = ++x;

            gb_Users.TabIndex           = ++x;
            btn_GoToUsers.TabIndex      = ++x;
            btn_AddUser.TabIndex        = ++x;

            gb_DSAs.TabIndex            = ++x;
            btn_DSAsView.TabIndex       = ++x;
            btn_DSAs.TabIndex           = ++x;

            gb_DataTracking.TabIndex    = ++x;
            btn_GoToDataIO.TabIndex     = ++x;
        }

        private void btn_GoToProjects_Click(object sender, EventArgs e)
        {
            frm_ProjectAll ProjectAllForm = new frm_ProjectAll();
            ProjectAllForm.Show();
        }

        private void btn_GoToDataIO_Click(object sender, EventArgs e)
        {
            frm_FileTransfersView FileTransferForm = new frm_FileTransfersView();
            FileTransferForm.Show();
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

        private void btn_AddTransfer_Click(object sender, EventArgs e)
        {
            frm_FileTransfersAdd DataTransferAddForm = new frm_FileTransfersAdd();
            DataTransferAddForm.Show();
        }

        private void btn_DSAsView_Click(object sender, EventArgs e)
        {
            frm_DsasView DsaViewForm = new frm_DsasView();
            DsaViewForm.Show();
        }
    }
}
