using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DataControlsLib.DataModels;

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
        UserModel mdl_CurrentUser;

        private void fillUsersDataSet()
        {
            var Users = new User();
            ds_User = Users.getUsersDataSet();
        }

        /// <summary>
        /// Method to assign values to class variables that hold current user details.
        /// Creates new User class object and uses parameter UserNumber with class DataSet (ds_User) to 
        /// populate UserModel (mdl)currentUser) using method from User class: getUser(UserNumber, ds_User).
        /// </summary>
        /// <param name="UserNumber"></param>
        private void fillCurrentUserVariables(int UserNumber)
        {
            try
            {
                //instantiate new User type object that contains User methods
                var User = new User();
                //populate class variables of UserModel
                mdl_CurrentUser = User.getUser(UserNumber, ds_User);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method fillCurrentProjectVariables of class frm_Projects has failed" + Environment.NewLine + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to get user details from UserModel (mdl_CurrentUser) and assign values to form controls.
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
                if (mdl_CurrentUser.Status == null)
                    cb_UserStatus.SelectedIndex = -1;
                else
                    cb_UserStatus.SelectedValue = mdl_CurrentUser.Status;
                cb_UserTitle.DataSource = ds_User.Tables["tlkTitle"];
                cb_UserTitle.ValueMember = "TitleID";
                cb_UserTitle.DisplayMember = "TitleDescription";
                if (mdl_CurrentUser.Title == null)
                    cb_UserTitle.SelectedIndex = -1;
                else
                    cb_UserTitle.SelectedValue = mdl_CurrentUser.Title;
                foreach (DataRow t in ds_User.Tables["tlkTitle"].Select($"TitleID = {mdl_CurrentUser.Title}"))
                {
                    current_TitleText = t["TitleDescription"].ToString();
                }
                lbl_FullName.Text = $"{current_TitleText} {mdl_CurrentUser.LastName}, {mdl_CurrentUser.FirstName}";
                tb_FirstName.Text = mdl_CurrentUser.FirstName;
                tb_LastName.Text = mdl_CurrentUser.LastName;
                tb_UserName.Text = mdl_CurrentUser.UserName;
                tb_Email.Text = mdl_CurrentUser.Email;
                tb_Phone.Text = mdl_CurrentUser.Phone;
                tb_Organisation.Text = mdl_CurrentUser.Organisation;
                mtb_UserStartDate.Text = mdl_CurrentUser.StartDate.ToString();
                mtb_UserEndDate.Text = mdl_CurrentUser.EndDate.ToString();
                mtb_IRCAgreement.Text = mdl_CurrentUser.IRCAgreement.ToString();
                mtb_ISET.Text = mdl_CurrentUser.ISET.ToString();
                mtb_ISAT.Text = mdl_CurrentUser.ISAT.ToString();
                mtb_SAFE.Text = mdl_CurrentUser.SAFE.ToString();
                if(mdl_CurrentUser.TokenSerial > 0)
                    nud_TokenSerial.Value = mdl_CurrentUser.TokenSerial.Value;
                mtb_TokenIssued.Text = mdl_CurrentUser.TokenIssued.ToString();
                mtb_TokenReturned.Text = mdl_CurrentUser.TokenReturned.ToString();

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

        /// <summary>
        /// Populates DataGridView (dgv_uProjects) with project numbers and names of all projects user is a 
        /// member of from DataTable tblUserProject in DataSet ds_User.
        /// </summary>
        /// <param name="UserNumber"></param>
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
        /// Gets values from form, assigns them to member variables of new UserModel (mdl_NewUser). 
        /// Compares new UserModel against current User Model and hecks that dates are valid.
        /// If no difference then no action, if invalid dates then no action and MessageBox feedback. 
        /// Creates new User class object and first checks if record loaded to form is latest user record 
        /// in database, using parameter UserNumber and current user UserID.
        /// If not latest record then no action and MessageBox feedback (asking to refresh form and try again).
        /// Inserts new record to database using insertUser method from User class and values contained in 
        /// new user model.
        /// Logically deletes current record in database using deleteUser method from User class.
        /// Refreshes the class DataSet (ds_User), assigns new values to current user model (mdl_CurrentUser) and 
        /// resets form controls in the same manner as at form load.
        /// </summary>
        /// <param name="UserNumber"></param>
        private bool updateUser(int UserNumber)
        {
            bool success = false;
            UserModel mdl_NewUser = new UserModel();

            mdl_NewUser.UserNumber = UserNumber;
            if (cb_UserStatus.SelectedIndex > -1)
                mdl_NewUser.Status = int.Parse(cb_UserStatus.SelectedValue.ToString());
            if (cb_UserTitle.SelectedIndex > -1)
                mdl_NewUser.Title = int.Parse(cb_UserTitle.SelectedValue.ToString());
            mdl_NewUser.FirstName = tb_FirstName.Text;
            mdl_NewUser.LastName = tb_LastName.Text;
            mdl_NewUser.Email = tb_Email.Text;
            mdl_NewUser.Phone = tb_Phone.Text;
            mdl_NewUser.UserName = tb_UserName.Text;
            mdl_NewUser.Organisation = tb_Organisation.Text;
            if (nud_TokenSerial.Value > 0)
                mdl_NewUser.TokenSerial = (int)(nud_TokenSerial.Value);

            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_UserStartDate.Text != "" & mtb_UserStartDate.Text != "  /  /")
            {
                try
                {
                    mdl_NewUser.StartDate = Convert.ToDateTime(mtb_UserStartDate.Text);
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
                    mdl_NewUser.EndDate = Convert.ToDateTime(mtb_UserEndDate.Text);
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
                    mdl_NewUser.IRCAgreement = Convert.ToDateTime(mtb_IRCAgreement.Text);
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
                    mdl_NewUser.ISET = Convert.ToDateTime(mtb_ISET.Text);
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
                    mdl_NewUser.ISAT = Convert.ToDateTime(mtb_ISAT.Text);
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
                    mdl_NewUser.SAFE = Convert.ToDateTime(mtb_SAFE.Text);
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
                    mdl_NewUser.TokenIssued = Convert.ToDateTime(mtb_TokenIssued.Text);
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
                    mdl_NewUser.TokenReturned = Convert.ToDateTime(mtb_TokenReturned.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Token Returned Date");
                    dateCheck = false;
                }
            }

            //instantiate new User type object that contains methods to update db
            User Users = new User();

            //Check required fields have an entry
            if (Users.requiredFields(mdl_NewUser) == false)
            {
                return success;
            }

            //check to see if any changes have been made, no need to update if none.
            if (mdl_CurrentUser == mdl_NewUser)
            {
                return success;
            }

            if (dateCheck == true)
            {
                //check that record currently displayed is current record in database before updating anything
                if (Users.checkCurrentRecord(UserNumber, mdl_CurrentUser.UserID) == true)
                {
                    //update existing user - first perform insert new record, if success returned = true then logical delete
                    if (Users.insertUser(mdl_NewUser))
                    {
                        Users.deleteUser(mdl_CurrentUser.UserID);
                    }

                    //refresh dataset (ds_User) and form variable and control values
                    fillUsersDataSet();
                    fillCurrentUserVariables(UserNumber);
                    setUserDetails(UserNumber);
                    setUserNotes(UserNumber);
                    setUserProjects(UserNumber);

                    success = true;
                }
            }
            return success;
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
                    //throw;
                }
            }
        }

        /// <summary>
        /// Passes each selected ProjectNumber in the Research Team DataGridView (dgv_ProjectUsers) and the current 
        /// UserNumber through to the deleteUserProject method of the Users class. 
        /// Removes them from the DataGridView rather than refreshing whole DataSet/Form.
        /// </summary>
        private void removeUserProject()
        {
            int rowCount = dgv_UserProjects.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (rowCount > 0)
            {
                List<int> removedProjects = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    int rowIndex            = dgv_UserProjects.SelectedRows[i].Index;
                    string ProjectNumber    = dgv_UserProjects.Rows[rowIndex].Cells["Project Number"].Value.ToString();

                    User Users = new User();
                    DialogResult removeProject = MessageBox.Show($"Remove project {ProjectNumber} from user record?", "", MessageBoxButtons.YesNo);
                    if (removeProject == DialogResult.Yes)
                    {
                        Users.deleteUserProject(mdl_CurrentUser.UserNumber, ProjectNumber);
                        removedProjects.Add(rowIndex);
                    }
                }
                foreach (int rowIndex in removedProjects)
                {
                    dgv_UserProjects.Rows.RemoveAt(rowIndex);
                }
            }
        }


        private void btn_InsertUserNote_Click(object sender, EventArgs e)
        {
            addUserNote(mdl_CurrentUser.UserNumber);
        }

        private void btn_UserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserRefresh_Click(object sender, EventArgs e)
        {
            fillUsersDataSet();
            fillCurrentUserVariables(mdl_CurrentUser.UserNumber);
            setUserDetails(mdl_CurrentUser.UserNumber);
            setUserProjects(mdl_CurrentUser.UserNumber);
            setUserNotes(mdl_CurrentUser.UserNumber);
        }

        private void btn_UserApply_Click(object sender, EventArgs e)
        {
            //update user details
            updateUser(mdl_CurrentUser.UserNumber);
        }

        private void btn_UserOK_Click(object sender, EventArgs e)
        {
            //update user details
            if (updateUser(mdl_CurrentUser.UserNumber) == true)
                this.Close();
        }

        private void btn_ProjectUserRemove_Click(object sender, EventArgs e)
        {
            removeUserProject();
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

        private void btn_ProjectUserAdd_Click(object sender, EventArgs e)
        {
            frm_UserProjectAdd UserProjectAdd = new frm_UserProjectAdd(mdl_CurrentUser.UserNumber, ds_User);
            UserProjectAdd.FormClosing += new FormClosingEventHandler(this.UserProjectAdd_FormClosing);
            UserProjectAdd.Show();
        }

        private void UserProjectAdd_FormClosing(object sender, FormClosingEventArgs e)
        {

            fillUsersDataSet();
            setUserProjects(mdl_CurrentUser.UserNumber);

        }

        private void btn_UserAdd_Click(object sender, EventArgs e)
        {
            frm_UserAdd UserAdd = new frm_UserAdd();
            UserAdd.Show();
        }
    }
}
