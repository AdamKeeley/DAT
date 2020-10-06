using CMS.Login;
using DataControlsLib;
using System;
using System.Data.SqlClient;
using System.Security;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used to control behaviour of parent form.
        /// </summary>
        public bool loggedIn = false;
        /// <summary>
        /// Used to control behaviour of parent form.
        /// </summary>
        public bool loginCancel = false;

        /// <summary>
        /// Calls static method to populate static variable with SQL connection string. 
        /// Captures username and password from form controls to store in static variable (SQL_Stuff.credential).
        /// </summary>
        private void setConnection()
        {
            //set SQL connection string
            SQL_Stuff.setString();

            //set SQL Credentials
            string usr = tb_UserName.Text;
            SecureString pwd = new SecureString();

            if (tb_Password.Text != "")
            {
                foreach (char c in tb_Password.Text)
                {
                    pwd.AppendChar(c);
                }
            }
            pwd.MakeReadOnly();
            
            SQL_Stuff.credential = new SqlCredential(usr, pwd);
        }

        /// <summary>
        /// Attempts to connect to database and run simple select query. 
        /// </summary>
        /// <returns>true on success, false on fail</returns>
        public bool testConnection()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                SqlCommand qryTestConnection = new SqlCommand();
                qryTestConnection.Connection = conn;
                qryTestConnection.CommandText = "select 1";
                try
                {
                    conn.Open();
                    qryTestConnection.ExecuteScalar();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Connection to database could not be established" + Environment.NewLine + e.Message);
                    return false;
                }
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            setConnection();
            if (testConnection() == true)
            {
                loggedIn = true;
                this.Close();
            }
        }

        private void btn_LoginCancel_Click(object sender, EventArgs e)
        {
            loginCancel = true;
            this.Close();
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            setConnection();
            if (testConnection() == true)
            {
                using (frm_ChangePassword changePassword = new frm_ChangePassword())
                {
                    changePassword.ShowDialog();
                    tb_Password.Clear();
                }
            }
        }
    }
}
