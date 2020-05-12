using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_User : Form
    {
        public frm_User(int UserNumber)
        {
            InitializeComponent();
            nud_TokenSerial.Controls.RemoveAt(0);
            fillUsersDataSet();
            fillCurrentUserVariables(UserNumber);
            setUserDetails(UserNumber);
            setUserProjects(UserNumber);
            setUserNotes(UserNumber);
            setTabIndex();
        }

        DataSet ds_User;

        int         current_UserID;
        int         current_UserNumber;
        int?        current_Status;
        int?        current_Title;
        string      current_FirstName;
        string      current_LastName;
        string      current_Email;
        string      current_Phone;
        string      current_UserName;
        string      current_Organisation;
        DateTime?   current_StartDate;
        DateTime?   current_EndDate;
        bool        current_Priviledged;
        DateTime?   current_IRCAgreement;
        DateTime?   current_ISET;
        DateTime?   current_ISAT;
        DateTime?   current_SAFE;
        long?       current_TokenSerial;
        DateTime?   current_TokenIssued;
        DateTime?   current_TokenReturned;

        private void fillUsersDataSet()
        {
            var Users = new User();
            ds_User = Users.getUsersDataSet();
        }

        /// <summary>
        /// Method to assign values to class variables that hold current user details.
        /// Creates new User class object and uses parameter UserNumber with class DataSet (ds_User) to 
        /// populate a new list using method from User class: getUserToList(UserNumber, ds_User).
        /// Values taken from this list and assigned to class variables.
        /// !
        /// Uses index referencing so be careful with ordering!
        /// !
        /// </summary>
        /// <param name="UserNumber"></param>
        private void fillCurrentUserVariables(int UserNumber)
        {
            try
            {
                //instantiate new User type object that contains User methods
                var User = new User();
                //populate list of user details
                List<object> lst_UserDetails = User.getUserToList(UserNumber, ds_User);

                //put user details into form variable members for use by other methods
                current_UserID         = (int)lst_UserDetails[0];
                current_UserNumber     = (int)lst_UserDetails[1];
                current_Status         = (int?)lst_UserDetails[2];
                current_Title          = (int?)lst_UserDetails[3];
                current_FirstName      = (string)lst_UserDetails[4];
                current_LastName       = (string)lst_UserDetails[5];
                current_Email          = (string)lst_UserDetails[6];
                current_Phone          = (string)lst_UserDetails[7];
                current_UserName       = (string)lst_UserDetails[8];
                current_Organisation   = (string)lst_UserDetails[9];
                current_StartDate      = (DateTime?)lst_UserDetails[10];
                current_EndDate        = (DateTime?)lst_UserDetails[11];
                current_Priviledged    = (bool)lst_UserDetails[12];
                current_IRCAgreement   = (DateTime?)lst_UserDetails[13];
                current_ISET           = (DateTime?)lst_UserDetails[14];
                current_ISAT           = (DateTime?)lst_UserDetails[15];
                current_SAFE           = (DateTime?)lst_UserDetails[16];
                current_TokenSerial    = (long?)lst_UserDetails[17];
                current_TokenIssued    = (DateTime?)lst_UserDetails[18];
                current_TokenReturned  = (DateTime?)lst_UserDetails[19];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method fillCurrentProjectVariables of class frm_Projects has failed" + Environment.NewLine + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to get user details from class DataSet (ds_User) and assign values to form controls.
        /// Combo boxes are assigned DataSources, Value & Display members to populate drop down options.
        /// </summary>
        /// <param name="UserNumber"></param>
        private void setUserDetails(int UserNumber)
        {
            try
            {
                string current_TitleText = "";
                //set controls values
                cb_UserStatus.DataSource = ds_User.Tables["tlkUserStatus"];
                cb_UserStatus.ValueMember = "StatusID";
                cb_UserStatus.DisplayMember = "StatusDescription";
                if (current_Status == null)
                    cb_UserStatus.SelectedIndex = -1;
                else
                    cb_UserStatus.SelectedValue = current_Status;
                cb_UserTitle.DataSource = ds_User.Tables["tlkTitle"];
                cb_UserTitle.ValueMember = "TitleID";
                cb_UserTitle.DisplayMember = "TitleDescription";
                if (current_Title == null)
                    cb_UserTitle.SelectedIndex = -1;
                else
                    cb_UserTitle.SelectedValue = current_Title;
                foreach (DataRow t in ds_User.Tables["tlkTitle"].Select($"TitleID = {current_Title}"))
                {
                    current_TitleText = t["TitleDescription"].ToString();
                }
                lbl_FullName.Text = $"{current_TitleText} {current_LastName}, {current_FirstName}";
                tb_FirstName.Text = current_FirstName;
                tb_LastName.Text = current_LastName;
                tb_UserName.Text = current_UserName;
                tb_Email.Text = current_Email;
                tb_Phone.Text = current_Phone;
                tb_Organisation.Text = current_Organisation;
                mtb_UserStartDate.Text = current_StartDate.ToString();
                mtb_UserEndDate.Text = current_EndDate.ToString();
                mtb_IRCAgreement.Text = current_IRCAgreement.ToString();
                mtb_ISET.Text = current_ISET.ToString();
                mtb_ISAT.Text = current_ISAT.ToString();
                mtb_SAFE.Text = current_SAFE.ToString();
                if(current_TokenSerial > 0)
                    nud_TokenSerial.Value = current_TokenSerial.Value;
                mtb_TokenIssued.Text = current_TokenIssued.ToString();
                mtb_TokenReturned.Text = current_TokenReturned.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setUserDetails of class frm_User has failed" + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to get user notes from class DataSet (ds_User) and assign to DataGridView on form (dgv_UserNotes).
        /// Creates a new DataTable (dt_dgv_uNotes), adds records to it row by row from DataSet using parameter UserNumber and then 
        /// fills the DataGridView.
        /// Sizes columns to fit expected data.
        /// </summary>
        /// <param name="UserNumber"></param>
        private void setUserNotes(int UserNumber)
        {
            //populate DataGridView (dgv_pNotes) from DataTable (ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_pNotes) that just contains columns of interest
            DataTable dt_dgv_uNotes = new DataTable();
            dt_dgv_uNotes.Columns.Add("Note");
            dt_dgv_uNotes.Columns.Add("Created Date");
            dt_dgv_uNotes.Columns.Add("Created By");
            //iterate through each project note in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_User.Tables["tblUserNotes"].Select($"UserNumber = '{UserNumber}'"))
            {
                row = dt_dgv_uNotes.NewRow();
                row["Note"] = nRow["uNote"];
                row["Created Date"] = nRow["Created"];
                row["Created By"] = nRow["CreatedBy"];
                dt_dgv_uNotes.Rows.Add(row);
            }
            dgv_UserNotes.DataSource = dt_dgv_uNotes;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_UserNotes.Columns["Note"].Width = 330;
            dgv_UserNotes.Columns["Created Date"].Width = 80;
            dgv_UserNotes.Columns["Created By"].Width = 80;
            dgv_UserNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_UserNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_UserNotes.Sort(dgv_UserNotes.Columns["Created Date"], ListSortDirection.Descending);
        }

        private void setUserProjects(int UserNumber)
        {
            //populate DataGridView (dgv_uProjects) from DataTable (ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_uProjects) that just contains columns of interest
            DataTable dt_dgv_uProjects = new DataTable();
            dt_dgv_uProjects.Columns.Add("Project Number");
            dt_dgv_uProjects.Columns.Add("Project Name");

            //iterate through each user in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow uRow in ds_User.Tables["tblUserProject"].Select($"UserNumber = '{UserNumber}'"))
            {
                row = dt_dgv_uProjects.NewRow();
                foreach (DataRow u in uRow.GetParentRows("UserProject_Project"))
                {
                    row["Project Number"] = (string)u["ProjectNumber"];
                    row["Project Name"] = (string)u["ProjectName"];
                }
                dt_dgv_uProjects.Rows.Add(row);
            }
            dgv_UserProjects.DataSource = dt_dgv_uProjects;
            dgv_UserProjects.Sort(dgv_UserProjects.Columns["Project Number"], ListSortDirection.Ascending);
            dgv_UserProjects.Columns["Project Number"].Width = 40;
            dgv_UserProjects.Columns["Project Name"].Width = 130;
        }

        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            gb_UserDetail.TabIndex = 0;
            cb_UserStatus.TabIndex = 1;
            cb_UserTitle.TabIndex = 2;
            tb_FirstName.TabIndex = 3;
            tb_LastName.TabIndex = 4;
            tb_UserName.TabIndex = 5;
            tb_Email.TabIndex = 6;
            tb_Phone.TabIndex = 7;
            tb_Organisation.TabIndex = 8;
            mtb_UserStartDate.TabIndex = 9;
            mtb_UserEndDate.TabIndex = 10;

            gb_Training.TabIndex = 11;
            mtb_IRCAgreement.TabIndex = 12;
            mtb_ISET.TabIndex = 13;
            mtb_ISAT.TabIndex = 14;
            mtb_SAFE.TabIndex = 15;

            gb_MFA.TabIndex = 16;
            nud_TokenSerial.TabIndex = 17;
            mtb_TokenIssued.TabIndex = 18;
            mtb_TokenReturned.TabIndex = 19;

            gb_UserNotes.TabIndex = 20;
            tb_NewUserNote.TabIndex = 21;
            btn_InsertUserNote.TabIndex = 22;
            btn_UserRefresh.TabIndex = 23;
            btn_UserApply.TabIndex = 24;
            btn_UserOK.TabIndex = 25;
            btn_UserCancel.TabIndex = 26;
            btn_NewUser.TabIndex = 27;

            gb_UserProjects.TabIndex = 28;
            btn_ProjectUserAdd.TabIndex = 29;
            btn_ProjectUserRemove.TabIndex = 30;
        }

        /// <summary>
        /// Method to update user details in SQL Server database.
        /// Gets values from form, assigns them to variables (new_xxxx) and checks if they're different to those 
        /// in class variables (current_xxxx) and that dates are valid.
        /// If no difference then no action, if invalid dates then no action and MessageBox feedback. 
        /// Creates new User class object and first checks if record loaded to form is latest user record 
        /// in database, using parameter UserNumber and class variable current_UserID.
        /// If not latest record then no action and MessageBox feedback (asking to refresh form and try again).
        /// Inserts new record to database using insertUser method from User class and values assigned to 
        /// new_xxxx variables.
        /// Logically deletes current record in database using deleteUser method from User class.
        /// Refreshes the class DataSet (ds_User), assigns new values to class variables (current_xxxx) and 
        /// resets form controls in the same manner as at form load.
        /// </summary>
        /// <param name="UserNumber"></param>
        private void updateUser(int UserNumber)
        {
            int?        new_Status          = null;
            int?        new_Title           = null;
            string      new_FirstName       = tb_FirstName.Text;
            string      new_LastName        = tb_LastName.Text;
            string      new_Email           = tb_Email.Text;
            string      new_Phone           = tb_Phone.Text;
            string      new_UserName        = tb_UserName.Text;
            string      new_Organisation    = tb_Organisation.Text;
            DateTime?   new_StartDate       = null;
            DateTime?   new_EndDate         = null;
            DateTime?   new_IRCAgreement    = null;
            DateTime?   new_ISET            = null;
            DateTime?   new_ISAT            = null;
            DateTime?   new_SAFE            = null;
            long?       new_TokenSerial     = null;
            DateTime?   new_TokenIssued     = null;
            DateTime?   new_TokenReturned   = null;

            if (cb_UserStatus.SelectedIndex > -1)
                new_Status = int.Parse(cb_UserStatus.SelectedValue.ToString());
            if (cb_UserTitle.SelectedIndex > -1)
                new_Title = int.Parse(cb_UserTitle.SelectedValue.ToString());
            if (nud_TokenSerial.Value > 0)
                new_TokenSerial = (int)(nud_TokenSerial.Value);

            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_UserStartDate.Text != "" & mtb_UserStartDate.Text != "  /  /")
            {
                try
                {
                    new_StartDate = Convert.ToDateTime(mtb_UserStartDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid User Start Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_UserEndDate.Text != "" & mtb_UserEndDate.Text != "  /  /")
            {
                try
                {
                    new_EndDate = Convert.ToDateTime(mtb_UserEndDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid User End Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_IRCAgreement.Text != "" & mtb_IRCAgreement.Text != "  /  /")
            {
                try
                {
                    new_IRCAgreement = Convert.ToDateTime(mtb_IRCAgreement.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid IRC Agreement Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_ISET.Text != "" & mtb_ISET.Text != "  /  /")
            {
                try
                {
                    new_ISET = Convert.ToDateTime(mtb_ISET.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid ISET Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_ISAT.Text != "" & mtb_ISAT.Text != "  /  /")
            {
                try
                {
                    new_ISAT = Convert.ToDateTime(mtb_ISAT.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid ISAT Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_SAFE.Text != "" & mtb_SAFE.Text != "  /  /")
            {
                try
                {
                    new_SAFE = Convert.ToDateTime(mtb_SAFE.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid SAFE Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_TokenIssued.Text != "" & mtb_TokenIssued.Text != "  /  /")
            {
                try
                {
                    new_TokenIssued = Convert.ToDateTime(mtb_TokenIssued.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Token Issued Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_TokenReturned.Text != "" & mtb_TokenReturned.Text != "  /  /")
            {
                try
                {
                    new_TokenReturned = Convert.ToDateTime(mtb_TokenReturned.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Token Returned Date");
                    dateCheck = false;
                }
            }

            //check to see if any changes have been made, no need to update if none.
            //if changes are made then update local variables with change and set changesMade flag to true
            bool changesMade;

            if (current_Status != new_Status)
                changesMade = true;
            else if (current_Title != new_Title)
                changesMade = true;
            else if (current_FirstName != new_FirstName)
                changesMade = true;
            else if (current_LastName != new_LastName)
                changesMade = true;
            else if (current_Email != new_Email)
                changesMade = true;
            else if (current_Phone != new_Phone)
                changesMade = true;
            else if (current_UserName != new_UserName)
                changesMade = true;
            else if (current_Organisation != new_Organisation)
                changesMade = true;
            else if (current_StartDate != new_StartDate)
                changesMade = true;
            else if (current_EndDate != new_EndDate)
                changesMade = true;
            else if (current_IRCAgreement != new_IRCAgreement)
                changesMade = true;
            else if (current_ISET != new_ISET)
                changesMade = true;
            else if (current_ISAT != new_ISAT)
                changesMade = true;
            else if (current_SAFE != new_SAFE)
                changesMade = true;
            else if (current_TokenSerial != new_TokenSerial)
                changesMade = true;
            else if (current_TokenIssued != new_TokenIssued)
                changesMade = true;
            else if (current_TokenReturned != new_TokenReturned)
                changesMade = true;
            else
                changesMade = false;

            if (changesMade == true & dateCheck == true)
            {
                //instantiate new User type object that contains methods to update db
                var Users = new User();
                //check that record currently displayed is current record in database before updating anything
                if (Users.checkCurrentRecord(UserNumber, current_UserID) == true)
                {
                    //update existing user - first perform insert new record, if success returned = true then logical delete
                    if (Users.insertUser(UserNumber, new_Status, new_Title, new_FirstName, new_LastName, new_Email, new_Phone
                        , new_UserName, new_Organisation, new_StartDate, new_EndDate, new_IRCAgreement, new_ISET, new_ISAT
                        , new_SAFE, new_TokenSerial, new_TokenIssued, new_TokenReturned))
                    {
                        Users.deleteUser(current_UserID);
                    }

                    //refresh dataset (ds_User) and form variable and control values
                    fillUsersDataSet();
                    fillCurrentUserVariables(UserNumber);
                    setUserDetails(UserNumber);
                    setUserNotes(UserNumber);
                    setUserProjects(UserNumber);
                }
            }
        }

        /// <summary>
        /// Method to add a note to a user record.
        /// If the textbox control tb_NewUserNote is not empty the entered value is inserted into a table within 
        /// the SQL Server database.
        /// Assigns the contents of tb_NewUserNote to a variable (newUserNote), creates a new User class 
        /// object and passes the parameter UserNumber and variable newUserNote to a method it contains (insertUserNote).
        /// Refreshes class DataSet (ds_User) and datagrid view before clearing the contents of the text box (tb_NewUserNote).
        /// </summary>
        /// <param name="UserNumber"></param>
        private void addUserNote(int UserNumber)
        {
            string newUserNote;

            if (tb_NewUserNote.Text != "")
            {
                try
                {
                    //place the new note text into the string variable (newProjectNote)
                    newUserNote = tb_NewUserNote.Text;
                    //instantiate new Project type object that contains methods to update db
                    var Users = new User();
                    //add the note to the SQL table
                    Users.insertUserNote(UserNumber, newUserNote);
                    //refresh the DataSet (ds_Project)
                    ds_User = Users.getUsersDataSet();
                    //repopulate the DataGridView (dgv_pNotes)
                    setUserNotes(UserNumber);
                    //clear the textbox control
                    tb_NewUserNote.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add new note" + Environment.NewLine + Environment.NewLine + ex);
                    throw;
                }
            }
        }


        private void btn_InsertUserNote_Click(object sender, EventArgs e)
        {
            addUserNote(current_UserNumber);
        }

        private void btn_UserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserRefresh_Click(object sender, EventArgs e)
        {
            fillUsersDataSet();
            fillCurrentUserVariables(current_UserNumber);
            setUserDetails(current_UserNumber);
            setUserProjects(current_UserNumber);
            setUserNotes(current_UserNumber);
        }

        private void btn_UserApply_Click(object sender, EventArgs e)
        {
            //update user details
            updateUser(current_UserNumber);
        }

        private void btn_UserOK_Click(object sender, EventArgs e)
        {
            //update user details
            updateUser(current_UserNumber);
            this.Close();
        }

        private void dgv_UserProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    string pNumber = dgv_UserProjects.Rows[r].Cells["Project Number"].Value.ToString();
                    frm_Project Project = new frm_Project(pNumber);
                    Project.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please double click on a data row to see project details.");
                }
            }
        }

    }
}
