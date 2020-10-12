using DataControlsLib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        /// <summary>
        /// Used to prevent sending command to SQL database if password validation fails.
        /// </summary>
        private bool validate = false;

        /// <summary>
        /// Establishes initial values of form controls.
        /// </summary>
        private void setControls()
        {
            lbl_ChangePasswordFor.Text = $"Change password for {SQL_Stuff.credential.UserId}";
            lbl_ChangePasswordValidation.Text = $"";
        }

        /// <summary>
        /// Method to validate password complexity policy is adhered to and both entered passwords match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validatePasswords(object sender, EventArgs e)
        {
            lbl_ChangePasswordValidation.Text = $"";

            if (tb_NewPassword1.TextLength < 8)
            {
                lbl_ChangePasswordValidation.Text = $"Password too short";
                validate = false;
            }

            else if (tb_NewPassword1.Text.Any(char.IsUpper) == false || tb_NewPassword1.Text.Any(char.IsLower) == false || tb_NewPassword1.Text.Any(char.IsDigit) == false)
            {
                lbl_ChangePasswordValidation.Text = $"Password must contain upper case, lower case and numerals.";
                validate = false;
            }
            
            else if (tb_NewPassword2.TextLength > 0 & tb_NewPassword1.Text != tb_NewPassword2.Text)
            {
                lbl_ChangePasswordValidation.Text = $"Entered passwords do not match";
                validate = false;
            }

            else if (tb_NewPassword1.Text == tb_NewPassword2.Text)
            {
                validate = true;
            }
        }

        /// <summary>
        /// Executes a stored procedure on database server to change password, using credentials used at 
        /// login and new password entered by user on this form.
        /// </summary>
        /// <returns>true on success, false on fail</returns>
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
                qryChangePassword.CommandText = $"exec dbo.sp_changePassword @username, @newPwd, @oldPwd";
                qryChangePassword.Parameters.Add("@username", SqlDbType.VarChar, 25).Value = SQL_Stuff.credential.UserId;
                qryChangePassword.Parameters.Add("@newPwd", SqlDbType.VarChar, 25).Value = tb_NewPassword1.Text;
                qryChangePassword.Parameters.Add("@oldPwd", SqlDbType.VarChar, 25).Value = oldPwd;

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
