using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;

namespace CMS
{
    public partial class frm_UserAdd : Form
    {
        public frm_UserAdd()
        {
            InitializeComponent();
            setTabIndex();
            nud_TokenSerial.Controls.RemoveAt(0);
            fillUserDataSet();
            setUserAdd();
        }

        DataSet ds_User;
        public bool userAdded = false;

        /// <summary>
        /// Fills class member DataSet (ds_User).
        /// </summary>
        private void fillUserDataSet()
        {
            User Users = new User();
            ds_User = Users.getUsersDataSet();
        }

        /// <summary>
        /// Method to get user details from UserModel (mdl_CurrentUser) and assign values to form controls.
        /// Combo boxes are assigned DataSources, Value & Display members to populate drop down options.
        /// </summary>
        private void setUserAdd()
        {
            try
            {
                //set controls values
                DataView dv_UserStatus = new DataView(ds_User.Tables["tlkUserStatus"]);
                dv_UserStatus.RowFilter = $"[ValidTo] is null";
                cb_UserStatus.DataSource = dv_UserStatus;
                cb_UserStatus.ValueMember = "StatusID";
                cb_UserStatus.DisplayMember = "StatusDescription";
                cb_UserStatus.SelectedIndex = -1;
                DataView dv_Title = new DataView(ds_User.Tables["tlkTitle"]);
                dv_Title.RowFilter = $"[ValidTo] is null";
                cb_UserTitle.DataSource = dv_Title;
                cb_UserTitle.ValueMember = "TitleID";
                cb_UserTitle.DisplayMember = "TitleDescription";
                cb_UserTitle.SelectedIndex = -1;
                nud_TokenSerial.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method set_UserAdd of class frm_UserAdd has failed" + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Takes values from form controls, checks dates are dates, calls confirmationBox 
        /// to present them for review and inserts into SQL database if confirmed.
        /// </summary>
        private bool insertNewUser()
        {
            User Users = new User();
            mdl_User mdl_User = new mdl_User();

            //put control values into UserModel
            mdl_User.UserNumber     = Users.getLastUserNumber() + 1;
            if (cb_UserStatus.SelectedIndex > -1)
            {
                mdl_User.Status     = int.Parse(cb_UserStatus.SelectedValue.ToString());
                mdl_User.Status_Desc = cb_UserStatus.Text;
            }
            if (cb_UserTitle.SelectedIndex > -1)
            {
                mdl_User.Title      = int.Parse(cb_UserTitle.SelectedValue.ToString());
                mdl_User.Title_Desc = cb_UserTitle.Text;
            }              
            mdl_User.FirstName      = tb_FirstName.Text;
            mdl_User.LastName       = tb_LastName.Text;
            mdl_User.Email          = tb_Email.Text;
            mdl_User.Phone          = tb_Phone.Text;
            mdl_User.UserName       = tb_UserName.Text;
            mdl_User.Organisation   = tb_Organisation.Text;
            if (nud_TokenSerial.Value > 0)
                mdl_User.TokenSerial    = (long)nud_TokenSerial.Value;
            
            // Dates are fuckey
            bool dateCheck = true;

            if (dateCheck == true & mtb_UserStartDate.Text != "" & mtb_UserStartDate.Text != "  /  /")
            {
                try
                {
                    mdl_User.StartDate = Convert.ToDateTime(mtb_UserStartDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Start Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_UserEndDate.Text != "" & mtb_UserEndDate.Text != "  /  /")
            {
                try
                {
                    mdl_User.EndDate = Convert.ToDateTime(mtb_UserEndDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid End Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_IRCAgreement.Text != "" & mtb_IRCAgreement.Text != "  /  /")
            {
                try
                {
                    mdl_User.IRCAgreement = Convert.ToDateTime(mtb_IRCAgreement.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid IRC Agreement Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_ISET.Text != "" & mtb_ISET.Text != "  /  /")
            {
                try
                {
                    mdl_User.ISET = Convert.ToDateTime(mtb_ISET.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid ISET Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_ISAT.Text != "" & mtb_ISAT.Text != "  /  /")
            {
                try
                {
                    mdl_User.ISAT = Convert.ToDateTime(mtb_ISAT.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid ISAT Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_SAFE.Text != "" & mtb_SAFE.Text != "  /  /")
            {
                try
                {
                    mdl_User.SAFE = Convert.ToDateTime(mtb_SAFE.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid SAFE Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_TokenIssued.Text != "" & mtb_TokenIssued.Text != "  /  /")
            {
                try
                {
                    mdl_User.TokenIssued = Convert.ToDateTime(mtb_TokenIssued.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Token Issued Date.");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_TokenReturned.Text != "" & mtb_TokenReturned.Text != "  /  /")
            {
                try
                {
                    mdl_User.TokenReturned = Convert.ToDateTime(mtb_TokenReturned.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Token Returned Date.");
                    dateCheck = false;
                }
            }

            //Check required fields have an entry
            if (Users.requiredFields(mdl_User) == false)
            {
                return false;
            }

            //Check if user already exists
            if (Users.userExists(mdl_User, ds_User.Tables["tblUser"]) == true)
            {
                MessageBox.Show("New user not added.");
                return false;
            }

            if (dateCheck == true)
            {
                if (confirmationBox(mdl_User) == DialogResult.OK)
                {
                    //insert new record
                    if (Users.insertUser(mdl_User) == true)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Takes the UserModel and constructs a string that is presented via a MessageBox for 
        /// review of entered details. Returns which button was clicked.
        /// </summary>
        /// <param name="mdl_User"></param>
        /// <returns></returns>
        private DialogResult confirmationBox(mdl_User mdl_User)
        {
            // tabs and newlines align and break up displayed information for ease of review
            string reviewUserDetails = $"Create new user with these details?" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"Status:\t\t{mdl_User.Status_Desc}" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"Title:\t\t{mdl_User.Title_Desc}" + Environment.NewLine;
            reviewUserDetails += $"FirstName:\t{mdl_User.FirstName}" + Environment.NewLine;
            reviewUserDetails += $"LastName:\t{mdl_User.LastName}" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"Email:\t\t{mdl_User.Email}" + Environment.NewLine;
            reviewUserDetails += $"Phone:\t\t{mdl_User.Phone}" + Environment.NewLine;
            reviewUserDetails += $"UserName:\t{mdl_User.UserName}" + Environment.NewLine;
            reviewUserDetails += $"Organisation:\t{mdl_User.Organisation}" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"StartDate:\t\t{mdl_User.StartDate}" + Environment.NewLine;
            reviewUserDetails += $"EndDate:\t\t{mdl_User.EndDate}" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"IRCAgreement:\t{mdl_User.IRCAgreement}" + Environment.NewLine;
            reviewUserDetails += $"ISET:\t\t{mdl_User.ISET}" + Environment.NewLine;
            reviewUserDetails += $"ISAT:\t\t{mdl_User.ISAT}" + Environment.NewLine;
            reviewUserDetails += $"SAFE:\t\t{mdl_User.SAFE}" + Environment.NewLine + Environment.NewLine;
            reviewUserDetails += $"TokenSerial:\t{mdl_User.TokenSerial}" + Environment.NewLine;
            reviewUserDetails += $"TokenIssued:\t{mdl_User.TokenIssued}" + Environment.NewLine;
            reviewUserDetails += $"TokenReturned:\t{mdl_User.TokenReturned}" + Environment.NewLine;

            DialogResult confirm = MessageBox.Show(
                text: reviewUserDetails
                , caption: "Confirmation"
                , buttons: MessageBoxButtons.OKCancel);

            return confirm;
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

            gb_UserDetail.TabIndex = ++x;
            cb_UserStatus.TabIndex = ++x;
            cb_UserTitle.TabIndex = ++x;
            tb_FirstName.TabIndex = ++x;
            tb_LastName.TabIndex = ++x;
            mtb_UserStartDate.TabIndex = ++x;
            mtb_UserEndDate.TabIndex = ++x;
            tb_UserName.TabIndex = ++x;
            tb_Email.TabIndex = ++x;
            tb_Phone.TabIndex = ++x;
            tb_Organisation.TabIndex = ++x;

            gb_Training.TabIndex = ++x;
            mtb_IRCAgreement.TabIndex = ++x;
            mtb_ISET.TabIndex = ++x;
            mtb_ISAT.TabIndex = ++x;
            mtb_SAFE.TabIndex = ++x;

            gb_MFA.TabIndex = ++x;
            nud_TokenSerial.TabIndex = ++x;
            mtb_TokenIssued.TabIndex = ++x;
            mtb_TokenReturned.TabIndex = ++x;

            btn_UserOK.TabIndex = ++x;
            btn_UserCancel.TabIndex = ++x;
        }

        /// <summary>
        /// Prevent the cursor from being positioned in the middle of an empty masked textbox when 
        /// the user clicks in it. Get's a reference to target control and passes it through to method in 
        /// static helper class.
        /// To be called by the OnClick event of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter_MaskedTextBox(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                MaskedTextBox maskedtextBox_Target = (MaskedTextBox)Controls.Find(((Control)sender).Name, true).First();
                Static_Helper.enter_MaskedTextBox(maskedtextBox_Target);
            }
        }

        private void btn_UserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserOK_Click(object sender, EventArgs e)
        {
            if (insertNewUser() == true)
            {
                userAdded = true;
                this.Close();
            }
        }
    }
}
