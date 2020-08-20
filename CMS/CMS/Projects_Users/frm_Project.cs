using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib.DataModels;

namespace CMS
{
    public partial class frm_Project : Form
    {
        /// <summary>
        /// Constructor - Runs each time form is loaded.
        /// Fills the DataSet (ds_Project), populates the ProjectModel class variables and sets the form 
        /// control values.
        /// Parameter pNumber passed from parent form.
        /// </summary>
        /// <param name="pNumber"></param>
        public frm_Project(string pNumber)
        {
            InitializeComponent();
            fillProjectsDataSet();
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectUsers(pNumber);
            setProjectNotes(pNumber);
            setTabIndex();
        }

        /// <summary>
        /// The dataset that stores all project details and related tables.
        /// Populated by fillProjectsDataSet() in this class, which calls method getProjectsDataSet() from Project class.
        /// Values obtained from SQL Server.
        /// </summary>
        DataSet ds_Project;

        /// <summary>
        /// Class instance containing variables that describe a single project.
        /// </summary>
        ProjectModel mdl_CurrentProject;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillProjectsDataSet()
        {
            var Projects = new Project();
            ds_Project = Projects.getProjectsDataSet();
        }

        /// <summary>
        /// Method to assign current project values to project data model (mdl_CurrentProject).
        /// Creates new Project class object and uses parameter pNumber with class DataSet (ds_Project) to 
        /// populate using method from Project class: getProject(pNumber, ds_Project).
        /// </summary>
        /// <param name="pNumber"></param>
        private void fillCurrentProjectVariables(string pNumber)
        {
            try
            {
                //instantiate new Project type object that contains project methods
                var Projects = new Project();
                //populate list of project details
                mdl_CurrentProject = Projects.getProject(pNumber, ds_Project);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method fillCurrentProjectVariables of class frm_Projects has failed" + Environment.NewLine + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to assign values to form controls from mdl_CurrentProject.
        /// Combo boxes are assigned DataSources, Value & Display members to populate drop down 
        /// options from class DataSet (ds_Project)
        /// </summary>
        /// <param name="pNumber"></param>
        private void setProjectDetails(string pNumber)
        {
            try
            {
                //set controls values
                cb_pNumberValue.DataSource              = ds_Project.Tables["tblProjects"];
                cb_pNumberValue.ValueMember             = "pID";
                cb_pNumberValue.DisplayMember           = "ProjectNumber";
                cb_pNumberValue.Text                    = pNumber;
                tb_pNameValue.Text                      = mdl_CurrentProject.ProjectName;
                cb_pStage.DataSource                    = ds_Project.Tables["tlkStage"];
                cb_pStage.ValueMember                   = "StageID";
                cb_pStage.DisplayMember                 = "pStageDescription";
                if (mdl_CurrentProject.Stage == null)
                    cb_pStage.SelectedIndex = -1;
                else
                    cb_pStage.SelectedValue             = mdl_CurrentProject.Stage;
                cb_pClassification.DataSource           = ds_Project.Tables["tlkClassification"];
                cb_pClassification.ValueMember          = "classificationID";
                cb_pClassification.DisplayMember        = "classificationDescription";
                if (mdl_CurrentProject.Classification == null)
                    cb_pClassification.SelectedIndex = -1;
                else
                    cb_pClassification.SelectedValue    = mdl_CurrentProject.Classification;
                cb_DATRAG.DataSource                    = ds_Project.Tables["tlkRAG"];
                cb_DATRAG.ValueMember                   = "ragID";
                cb_DATRAG.DisplayMember                 = "ragDescription";
                if (mdl_CurrentProject.DATRAG == null)
                    cb_DATRAG.SelectedIndex = -1;
                else
                    cb_DATRAG.SelectedValue             = mdl_CurrentProject.DATRAG;
                mtb_ProjectedStartDateValue.Text        = mdl_CurrentProject.ProjectedStartDate.ToString();
                mtb_ProjectedEndDateValue.Text          = mdl_CurrentProject.ProjectedEndDate.ToString();
                mtb_pStartDateValue.Text                = mdl_CurrentProject.StartDate.ToString();
                mtb_pEndDateValue.Text                  = mdl_CurrentProject.EndDate.ToString();
                cb_LeadApplicant.DataSource             = ds_Project.Tables["tlkLeadApplicant"];
                cb_LeadApplicant.ValueMember            = "UserNumber";
                cb_LeadApplicant.DisplayMember          = "FullName";
                if (mdl_CurrentProject.LeadApplicant == null)
                    cb_LeadApplicant.SelectedIndex = -1;
                else cb_LeadApplicant.SelectedValue     = mdl_CurrentProject.LeadApplicant;
                cb_PI.DataSource = ds_Project.Tables["tlkPI"];
                cb_PI.ValueMember = "UserNumber";
                cb_PI.DisplayMember = "FullName";
                if (mdl_CurrentProject.PI == null)
                    cb_PI.SelectedIndex = -1;
                else cb_PI.SelectedValue = mdl_CurrentProject.PI;
                cb_Faculty.DataSource                   = ds_Project.Tables["tlkFaculty"];
                cb_Faculty.ValueMember                  = "facultyID";
                cb_Faculty.DisplayMember                = "facultyDescription";
                if (mdl_CurrentProject.Faculty == null)
                    cb_Faculty.SelectedIndex = -1;
                else
                    cb_Faculty.SelectedValue            = mdl_CurrentProject.Faculty;
                chkb_ISO27001.Checked                   = mdl_CurrentProject.ISO27001;
                chkb_DSPT.Checked                       = mdl_CurrentProject.DSPT;
                chkb_Azure.Checked                      = mdl_CurrentProject.Azure;
                chkb_IRC.Checked                        = mdl_CurrentProject.IRC;
                chkb_SEED.Checked                       = mdl_CurrentProject.SEED;
                
                //setPlatformGroupBoxColour(chkb_IRC.Checked, chkb_SEED.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectDetails of class frm_Project has failed" + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to get project notes from class DataSet (ds_Project) and assign to DataGridView on form (dgv_pNotes).
        /// Creates a new DataTable (dt_dgv_pNotes), adds records to it row by row from DataSet using parameter pNumber and then 
        /// fills the DataGridView.
        /// Sizes columns to fit expected data.
        /// </summary>
        /// <param name="pNumber"></param>
        private void setProjectNotes(string pNumber)
        {
            //populate DataGridView (dgv_pNotes) from DataTable (ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_pNotes) that just contains columns of interest
            DataTable dt_dgv_pNotes = new DataTable();
            dt_dgv_pNotes.Columns.Add("Note");
            dt_dgv_pNotes.Columns.Add("Created Date");
            dt_dgv_pNotes.Columns.Add("Created By");
            //iterate through each project note in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_Project.Tables["tblProjectNotes"].Select($"ProjectNumber = '{pNumber}'"))
            {
                row = dt_dgv_pNotes.NewRow();
                row["Note"] = nRow["pNote"];
                row["Created Date"] = nRow["Created"];
                row["Created By"] = nRow["CreatedBy"];
                dt_dgv_pNotes.Rows.Add(row);
            }
            dgv_pNotes.DataSource = dt_dgv_pNotes;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_pNotes.Columns["Note"].Width = 330;
            dgv_pNotes.Columns["Created Date"].Width = 80;
            dgv_pNotes.Columns["Created By"].Width = 80;
            dgv_pNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_pNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_pNotes.Sort(dgv_pNotes.Columns["Created Date"], ListSortDirection.Descending);
        }

        /// <summary>
        /// Method to get project users from class DataSet (ds_Project) and assign to DataGridView on form 
        /// (dgv_ProjectUsers). Creates a new DataTable (dt_dgv_pNotes), adds records to it row by row from 
        /// DataSet using parameter pNumber and DataRelation (UserProject_User) and then fills the DataGridView.
        /// Sizes columns to fit expected data length, not actual.
        /// </summary>
        /// <param name="pNumber"></param>
        private void setProjectUsers(string pNumber)
        {
            //populate DataGridView (dgv_ProjectUsers) from DataTable (ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_pUsers) that just contains columns of interest
            DataTable dt_dgv_pUsers = new DataTable();
            dt_dgv_pUsers.Columns.Add("Full Name");
            dt_dgv_pUsers.Columns.Add("User Number");

            //iterate through each user in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow uRow in ds_Project.Tables["tblUserProject"].Select($"ProjectNumber = '{pNumber}'"))
            {
                row = dt_dgv_pUsers.NewRow();
                foreach (DataRow u in uRow.GetParentRows("UserProject_User"))
                {
                    row["Full Name"] = (string)u["FullName"];
                    row["User Number"] = (int)u["UserNumber"];
                }
                dt_dgv_pUsers.Rows.Add(row);
            }
            dgv_ProjectUsers.DataSource = dt_dgv_pUsers;
            dgv_ProjectUsers.Sort(dgv_ProjectUsers.Columns["Full Name"], ListSortDirection.Ascending);
            dgv_ProjectUsers.Columns["User Number"].Visible = false;
            dgv_ProjectUsers.Columns["Full Name"].Width = 155;
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

            cb_pNumberValue.TabIndex = 0;
            cb_DATRAG.TabIndex = 1;
            tb_pNameValue.TabIndex = 2;
            gb_Platform.TabIndex = 3;
            chkb_Azure.TabIndex = 4;
            chkb_IRC.TabIndex = 5;
            chkb_SEED.TabIndex = 6;
            gb_Governance.TabIndex = 7;
            chkb_ISO27001.TabIndex = 8;
            chkb_DSPT.TabIndex = 9;
            mtb_ProjectedStartDateValue.TabIndex = 10;
            mtb_ProjectedEndDateValue.TabIndex = 11;
            mtb_pStartDateValue.TabIndex = 12;
            mtb_pEndDateValue.TabIndex = 13;
            cb_pStage.TabIndex = 14;
            cb_pClassification.TabIndex = 15;
            cb_LeadApplicant.TabIndex = 16;
            cb_PI.TabIndex = 17;
            cb_Faculty.TabIndex = 18;
            tb_NewProjectNote.TabIndex = 19;
            btn_InsertProjectNote.TabIndex = 20;
            btn_Refresh.TabIndex = 21;
            btn_ProjectApply.TabIndex = 22;
            btn_ProjectOK.TabIndex = 23;
            btn_ProjectCancel.TabIndex = 24;
            btn_NewProject.TabIndex = 25;
            btn_Projects.TabIndex = 26;
            btn_Users.TabIndex = 27;
            btn_documents.TabIndex = 28;
            btn_Platform.TabIndex = 29;
        }

        /// <summary>
        /// Method to change the colour of platform group box (gb_Platform) depending on which check boxes are checked.
        /// Not entirely confident in the utility of this with more than two platforms...
        /// </summary>
        /// <param name="IRC"></param>
        /// <param name="SEED"></param>
        private void setPlatformGroupBoxColour(bool IRC, bool SEED)
        {
            if (IRC == true & SEED == true)
            {
                this.gb_Platform.BackColor = System.Drawing.Color.MediumPurple;
            }
            else if (IRC == true & SEED == false)
            {
                this.gb_Platform.BackColor = System.Drawing.Color.Salmon;
            }
            else if (IRC == false & SEED == true)
            {
                this.gb_Platform.BackColor = System.Drawing.Color.PaleTurquoise;
            }
            else this.gb_Platform.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// Method to update project details in SQL Server database.
        /// Gets values from form, assigns them to project data model (mdl_NewProject) class variables, 
        /// checks dates are valid before comparing new data model with current data model.
        /// If no difference then no action, if invalid dates then no action and MessageBox feedback. 
        /// Creates new Project class object and first checks if record loaded to form is latest project record 
        /// in database, using parameter pNumber and class variable current_pID.
        /// If not latest record then no action and MessageBox feedback (asking to refresh form and try again).
        /// Inserts new record to database using insertProject method from Project class and values 
        /// contained in mdl_NewProject.
        /// On insert success logically deletes current record in database using deleteProject method from Project class.
        /// Refreshes the class DataSet (ds_Project), assigns new values to current project data model 
        /// (mdl_CurrentProject) and resets form controls in the same manner as at form load.
        /// </summary>
        /// <param name="pNumber"></param>
        private void updateProject(string pNumber)
        {
            ProjectModel mdl_NewProject = new ProjectModel();

            mdl_NewProject.ProjectNumber        = pNumber;
            mdl_NewProject.ProjectName          = tb_pNameValue.Text;
            mdl_NewProject.DSPT                 = chkb_DSPT.Checked;
            mdl_NewProject.ISO27001             = chkb_ISO27001.Checked;
            mdl_NewProject.Azure                = chkb_Azure.Checked;
            mdl_NewProject.IRC                  = chkb_IRC.Checked;
            mdl_NewProject.SEED                 = chkb_SEED.Checked;

            if (cb_pStage.SelectedIndex > -1)
                mdl_NewProject.Stage            = int.Parse(cb_pStage.SelectedValue.ToString());
            if (cb_pClassification.SelectedIndex > -1)
                mdl_NewProject.Classification   = int.Parse(cb_pClassification.SelectedValue.ToString());
            if (cb_DATRAG.SelectedIndex > -1)
                mdl_NewProject.DATRAG           = int.Parse(cb_DATRAG.SelectedValue.ToString());
            if (cb_Faculty.SelectedIndex > -1)
                mdl_NewProject.Faculty          = int.Parse(cb_Faculty.SelectedValue.ToString());
            if (cb_LeadApplicant.SelectedIndex > -1)
                mdl_NewProject.LeadApplicant    = int.Parse(cb_LeadApplicant.SelectedValue.ToString());
            if (cb_PI.SelectedIndex > -1)
                mdl_NewProject.PI               = int.Parse(cb_PI.SelectedValue.ToString());

            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_ProjectedStartDateValue.Text != "" & mtb_ProjectedStartDateValue.Text != "  /  /")
            {
                try
                {
                    mdl_NewProject.ProjectedStartDate = Convert.ToDateTime(mtb_ProjectedStartDateValue.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Projected Start Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_ProjectedEndDateValue.Text != "" & mtb_ProjectedEndDateValue.Text != "  /  /")
            {
                try
                {
                    mdl_NewProject.ProjectedEndDate = Convert.ToDateTime(mtb_ProjectedEndDateValue.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Projected End Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_pStartDateValue.Text != "" & mtb_pStartDateValue.Text != "  /  /")
            {
                try
                {
                    mdl_NewProject.StartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Start Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_pEndDateValue.Text != "" & mtb_pEndDateValue.Text != "  /  /")
            {
                try
                {
                    mdl_NewProject.EndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid End Date");
                    dateCheck = false;
                }
            }

            //check to see if any changes have been made, no need to update if none.
            bool changesMade = mdl_NewProject != mdl_CurrentProject;
            
            if (changesMade == true & dateCheck == true)
            {
                //instantiate new Project type object that contains methods to update db
                var Projects = new Project();
                //check that record currently displayed is current record in database before updating anything
                if (Projects.checkCurrentRecord(pNumber, mdl_CurrentProject.pID) == true)
                {
                    //update existing project - first perform insert new record, if success returned = true then logical delete
                    if (Projects.insertProject(mdl_NewProject))
                    {
                        Projects.deleteProject(mdl_CurrentProject.pID);
                    }

                    //refresh dataset (ds_Projects) and form variable and control values
                    fillProjectsDataSet();
                    fillCurrentProjectVariables(pNumber);
                    setProjectDetails(pNumber);
                    setProjectNotes(pNumber);
                    setProjectUsers(pNumber);
                }
            }
        }

        /// <summary>
        /// Method to add a note to a project record.
        /// If the textbox control tb_NewProjectNote is not empty the entered value is inserted into a table within 
        /// the SQL Server database.
        /// Assigns the contents of tb_NewProjectNote to a variable (newProjectNote), creates a new Project class 
        /// object and passes the parameter pNumber and variable newProjectNote to a method it contains (insertProjectNote).
        /// Refreshes class DataSet (ds_Project) and datagrid view before clearing the contents of the text box (tb_NewProjectNote).
        /// </summary>
        /// <param name="pNumber"></param>
        private void addProjectNote(string pNumber)
        {
            string newProjectNote;

            if (tb_NewProjectNote.Text != "")
            {
                try
                {
                    //place the new note text into the string variable (newProjectNote)
                    newProjectNote = tb_NewProjectNote.Text;
                    //instantiate new Project type object that contains methods to update db
                    var Projects = new Project();
                    //add the note to the SQL table
                    Projects.insertProjectNote(pNumber, newProjectNote);
                    //refresh the DataSet (ds_Project)
                    ds_Project = Projects.getProjectsDataSet();
                    //repopulate the DataGridView (dgv_pNotes)
                    setProjectNotes(pNumber);
                    //clear the textbox control
                    tb_NewProjectNote.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add new note" + Environment.NewLine + ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Passes each selected UserNumber in the Research Team DataGridView (dgv_ProjectUsers) and the current 
        /// ProjectNumber through to the deleteUserProject method of the Users class. 
        /// Removes them from the DataGridView rather than refreshing whole DataSet/Form.
        /// </summary>
        private void removeProjectUser()
        {
            int rowCount = dgv_ProjectUsers.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (rowCount > 0)
            {
                List<int> removedUsers = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    int rowIndex = dgv_ProjectUsers.SelectedRows[i].Index;
                    int UserNumber = Convert.ToInt32(dgv_ProjectUsers.Rows[rowIndex].Cells["User Number"].Value);
                    string FullName = dgv_ProjectUsers.Rows[rowIndex].Cells["Full Name"].Value.ToString();

                    User Users = new User();
                    DialogResult removeProject = MessageBox.Show($"Remove {FullName} from project record?", "", MessageBoxButtons.YesNo);
                    if (removeProject == DialogResult.Yes)
                    {
                        Users.deleteUserProject(UserNumber, mdl_CurrentProject.ProjectNumber);
                        removedUsers.Add(rowIndex);
                    }
                }
                foreach (int rowIndex in removedUsers)
                {
                    dgv_ProjectUsers.Rows.RemoveAt(rowIndex);
                }
            }
        }



        private void btn_InsertProjectNote_Click(object sender, EventArgs e)
        {
            string pNumber = cb_pNumberValue.Text;
            addProjectNote(pNumber);
        }

        private void cb_pNumberValue_SelectionChanged(object sender, EventArgs e)
        {
            string pNumber = cb_pNumberValue.Text;
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
            setProjectUsers(pNumber);
        }

        private void btn_ProjectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ProjectApply_Click(object sender, EventArgs e)
        {
            //get project number
            string pNumber = cb_pNumberValue.Text;
            //update project details
            updateProject(pNumber);
        }

        private void btn_ProjectOK_Click(object sender, EventArgs e)
        {
            //get project number
            string pNumber = cb_pNumberValue.Text;
            //update project details
            updateProject(pNumber);

            this.Close();
        }

        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            frm_ProjectAdd ProjectAdd = new frm_ProjectAdd(ds_Project);
            ProjectAdd.FormClosing += new FormClosingEventHandler(this.ProjectAdd_FormClosing);
            ProjectAdd.Show();
        }

        private void btn_ProjectUserRemove_Click(object sender, EventArgs e)
        {
            removeProjectUser();
        }

        /// <summary>
        /// Populate this form with largest ProjectNumber details after frm_ProjectAdd closes, whether a new project was created or not.
        /// Relies on frm_ProjectAdd opening with the following code to add a form closing event that calls this method:
        /// "ProjectAdd.FormClosing += new FormClosingEventHandler(this.ProjectAdd_FormClosing);"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Projects = new Project();
            int pNumInt = Projects.getLastProjectNumber();
            string pNumber = Projects.getNewProjectNumber(pNumInt);

            fillProjectsDataSet();
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            string pNumber = cb_pNumberValue.Text;
            fillProjectsDataSet();
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectUsers(pNumber);
            setProjectNotes(pNumber);
        }

        private void dgv_ProjectUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    int UserNumber = Convert.ToInt32(dgv_ProjectUsers.Rows[r].Cells["User Number"].Value);
                    frm_User User = new frm_User(UserNumber);
                    User.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to see user details." + Environment.NewLine + ex);
                }
            }
        }

        private void btn_ProjectUserAdd_Click(object sender, EventArgs e)
        {
            frm_ProjectUserAdd ProjectUserAdd = new frm_ProjectUserAdd(mdl_CurrentProject.ProjectNumber, ds_Project);
            ProjectUserAdd.FormClosing += new FormClosingEventHandler(this.ProjectUserAdd_FormClosing);
            ProjectUserAdd.Show();
        }

        private void ProjectUserAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            fillProjectsDataSet();
            fillCurrentProjectVariables(mdl_CurrentProject.ProjectNumber);
            setProjectDetails(mdl_CurrentProject.ProjectNumber);
            setProjectUsers(mdl_CurrentProject.ProjectNumber);
            setProjectNotes(mdl_CurrentProject.ProjectNumber);
        }


    }
}
