using DataControlsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Login
{
    public partial class frm_ChangePassword : Form
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
            setControls();
        }

        private bool validate = false;

        private void setControls()
        {
            lbl_ChangePasswordFor.Text = $"Change password for {SQL_Stuff.credential.UserId}";
            lbl_ChangePasswordValidation.Text = $"";
        }

        private void validatePasswords(object sender, EventArgs e)
        {
            if (tb_NewPassword1.TextLength < 8)
            {
                lbl_ChangePasswordValidation.Text = $"Password too short";
                validate = false;
            }
            
            else if (tb_NewPassword2.TextLength > 0 & tb_NewPassword1.Text != tb_NewPassword2.Text)
            {
                lbl_ChangePasswordValidation.Text = $"Entered passwords do not match";
                validate = false;
            }

            else if (tb_NewPassword1.Text == tb_NewPassword2.Text)
            {
                lbl_ChangePasswordValidation.Text = $"";
                validate = true;
            }
        }

        private bool changePassword()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                string oldPwd = new System.Net.NetworkCredential(string.Empty, SQL_Stuff.credential.Password).Password;
                SqlCommand qryChangePassword = new SqlCommand();
                qryChangePassword.Connection = conn;
                qryChangePassword.CommandText = $"alter user {SQL_Stuff.credential.UserId} with password = '{tb_NewPassword1.Text}' old_password = '{oldPwd}'";
                try
                {
                    conn.Open();
                    qryChangePassword.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Password change failed for user {SQL_Stuff.credential.UserId}" + Environment.NewLine + ex.Message);
                    return false;
                }
            }

        }

        private void btn_ChangePasswordCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChangePasswordOK_Click(object sender, EventArgs e)
        {
            if (validate == true)
                if (changePassword() == true)
                    this.Close();
        }
    }
}
