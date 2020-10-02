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

        private void setConnection()
        {
            //set SQL connection string
            SQL_Stuff.getString();

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
                this.Close();
        }
    }
}
