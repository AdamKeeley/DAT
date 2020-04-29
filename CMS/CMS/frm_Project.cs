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
    public partial class frm_Project : Form
    {
        /// <summary>
        /// Constructor - Runs each time form is loaded.
        /// Fills the DataSet (ds_Project), populates the project detail variables and sets the form control values.
        /// Currently gets the parameter pNumber from Program Main, eventually will get from parent form.
        /// </summary>
        /// <param name="pNumber"></param>
        public frm_Project(string pNumber)
        {
            InitializeComponent();
            fillProjectsDataSet();
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
            setTabIndex();
        }

        /// <summary>
        /// The dataset that stores all project details and related tables.
        /// Populated by fillProjectsDataSet() in this class, which calls method getProjectsDataSet() from Project class.
        /// Values obtained from SQL Server.
        /// Populated when form loads and refreshed when project updated.
        /// </summary>
        DataSet ds_Project;

        /*
         * Class variables to hold current project details.
         * Populated by fillCurrentProjectVariables() in this class, which calls getProjectToList(pNumber, ds_Project) from Projects class.
         * Values obtained from in memory dataset (ds_Project).
         * Populated when form loads and refreshed when project updated or selected project changed
         */
        int         current_pID;
        string      current_pNumber;
        string      current_pName;
        int?        current_pStage;
        int?        current_pClassification;
        int?        current_pDATRAG;
        DateTime?   current_pProjectedStartDate;
        DateTime?   current_pProjectedEndDate;
        DateTime?   current_pStartDate;
        DateTime?   current_pEndDate;
        string      current_pPI;
        string      current_pLeadApplicant;
        int?        current_pFaculty;
        bool        current_pDSPT;
        bool        current_pISO;
        bool        current_pAzure;
        bool        current_IRC;
        bool        current_SEED;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillProjectsDataSet()
        {
            var Projects = new Project();
            ds_Project = Projects.getProjectsDataSet();
        }

        /// <summary>
        /// Method to assign values to class variables that hold current project details.
        /// Creates new Project class object and uses parameter pNumber with class DataSet (ds_Project) to 
        /// populate a new list using method from Project class: getProjectToList(pNumber, ds_Project).
        /// Values taken from this list and assigned to class variables.
        /// !
        /// Uses index referencing so be careful with ordering!
        /// !
        /// </summary>
        /// <param name="pNumber"></param>
        private void fillCurrentProjectVariables(string pNumber)
        {
            try
            {
                //instantiate new Project type object that contains project methods
                var Projects = new Project();
                //populate list of project details
                List<object> lst_ProjectDetails = Projects.getProjectToList(pNumber, ds_Project);

                //put project details into form variable members for use by this and other methods
                current_pID                 = (int)lst_ProjectDetails[0];
                current_pNumber             = (string)lst_ProjectDetails[1];
                current_pName               = (string)lst_ProjectDetails[2];
                current_pStage              = (int?)lst_ProjectDetails[3];
                current_pClassification     = (int?)lst_ProjectDetails[4];
                current_pDATRAG             = (int?)lst_ProjectDetails[5];
                current_pProjectedStartDate = (DateTime?)lst_ProjectDetails[6];
                current_pProjectedEndDate   = (DateTime?)lst_ProjectDetails[7];
                current_pStartDate          = (DateTime?)lst_ProjectDetails[8];
                current_pEndDate            = (DateTime?)lst_ProjectDetails[9];
                current_pPI                 = (string)lst_ProjectDetails[10];
                current_pLeadApplicant      = (string)lst_ProjectDetails[11];
                current_pFaculty            = (int?)lst_ProjectDetails[12];
                current_pDSPT               = (bool)lst_ProjectDetails[13];
                current_pISO                = (bool)lst_ProjectDetails[14];
                current_pAzure              = (bool)lst_ProjectDetails[15];
                current_IRC                 = (bool)lst_ProjectDetails[16];
                current_SEED                = (bool)lst_ProjectDetails[17];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method fillCurrentProjectVariables of class frm_Projects has failed" + Environment.NewLine + Environment.NewLine + ex);
                //throw;
            }
        }

        /// <summary>
        /// Method to get project details from class DataSet (ds_Project) and assign values to form controls.
        /// Combo boxes are assigned DataSources, Value & Display members to populate drop down options.
        /// Finally uses method from this class (setPlatformGroupBoxColour) to set colour of platform indicator.
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
                cb_pNumberValue.Text                    = current_pNumber;
                tb_pNameValue.Text                      = current_pName;
                cb_pStage.DataSource                    = ds_Project.Tables["tlkStage"];
                cb_pStage.ValueMember                   = "StageID";
                cb_pStage.DisplayMember                 = "pStageDescription";
                if (current_pStage == null)
                    cb_pStage.SelectedIndex = -1;
                else
                    cb_pStage.SelectedValue             = current_pStage;
                cb_pClassification.DataSource           = ds_Project.Tables["tlkClassification"];
                cb_pClassification.ValueMember          = "classificationID";
                cb_pClassification.DisplayMember        = "classificationDescription";
                if (current_pClassification == null)
                    cb_pClassification.SelectedIndex = -1;
                else
                    cb_pClassification.SelectedValue    = current_pClassification;
                cb_DATRAG.DataSource                    = ds_Project.Tables["tlkRAG"];
                cb_DATRAG.ValueMember                   = "ragID";
                cb_DATRAG.DisplayMember                 = "ragDescription";
                if (current_pDATRAG == null)
                    cb_DATRAG.SelectedIndex = -1;
                else
                    cb_DATRAG.SelectedValue             = current_pDATRAG;
                mtb_ProjectedStartDateValue.Text        = current_pProjectedStartDate.ToString();
                mtb_ProjectedEndDateValue.Text          = current_pProjectedEndDate.ToString();
                mtb_pStartDateValue.Text                = current_pStartDate.ToString();
                mtb_pEndDateValue.Text                  = current_pEndDate.ToString();
                tb_pPIValue.Text                        = current_pPI;
                tb_pLeadApplicantValue.Text             = current_pLeadApplicant;
                cb_Faculty.DataSource                   = ds_Project.Tables["tlkFaculty"];
                cb_Faculty.ValueMember                  = "facultyID";
                cb_Faculty.DisplayMember                = "facultyDescription";
                if (current_pFaculty == null)
                    cb_Faculty.SelectedIndex = -1;
                else
                    cb_Faculty.SelectedValue            = current_pFaculty;
                chkb_ISO27001.Checked                   = current_pISO;
                chkb_DSPT.Checked                       = current_pDSPT;
                chkb_Azure.Checked                      = current_pAzure;
                chkb_IRC.Checked                        = current_IRC;
                chkb_SEED.Checked                       = current_SEED;
                
                //setPlatformGroupBoxColour(chkb_IRC.Checked, chkb_SEED.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectDetails of class frm_Projects has failed" + Environment.NewLine + ex);
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
            dgv_pNotes.Columns["Note"].Width = 290;
            dgv_pNotes.Columns["Created Date"].Width = 80;
            dgv_pNotes.Columns["Created By"].Width = 80;
            dgv_pNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_pNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

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
            tb_pLeadApplicantValue.TabIndex = 16;
            tb_pPIValue.TabIndex = 17;
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
        /// Gets values from form, assigns them to variables (new_xxxx) and checks if they're different to those 
        /// in class variables (current_xxxx) and that dates are valid.
        /// If no difference then no action, if invalid dates then no action and MessageBox feedback. 
        /// Creates new Project class object and first checks if record loaded to form is latest project record 
        /// in database, using parameter pNumber and class variable current_pID.
        /// If not latest record then no action and MessageBox feedback (asking to refresh form and try again).
        /// Logically deletes current record in database using deleteProject method from Project class.
        /// Inserts new record to database using insertProject method from Project class and values assigned to 
        /// new_xxxx variables.
        /// Refreshes the class DataSet (ds_Project), assigns new values to class variables (current_xxxx) and 
        /// resets form controls in the same manner as at form load.
        /// </summary>
        /// <param name="pNumber"></param>
        private void updateProject(string pNumber)
        {
            //populate variables with values held in form controls to compare to current project values
            string      new_pName               = tb_pNameValue.Text;
            int?        new_pStage              = null;
            int?        new_pClassification     = null;
            int?        new_pDATRAG             = null;
            DateTime?   new_pProjectedStartDate = null;
            DateTime?   new_pProjectedEndDate   = null;
            DateTime?   new_pStartDate          = null;
            DateTime?   new_pEndDate            = null;
            string      new_pPI                 = tb_pPIValue.Text;
            string      new_pLeadApplicant      = tb_pLeadApplicantValue.Text;
            int?        new_pFaculty            = null;
            bool        new_pDSPT               = chkb_DSPT.Checked;
            bool        new_pISO                = chkb_ISO27001.Checked; 
            bool        new_pAzure              = chkb_Azure.Checked;
            bool        new_IRC                 = chkb_IRC.Checked;
            bool        new_SEED                = chkb_SEED.Checked;

            if (cb_pStage.SelectedIndex > -1)
                new_pStage                      = int.Parse(cb_pStage.SelectedValue.ToString());
            if (cb_pClassification.SelectedIndex > -1)
                new_pClassification             = int.Parse(cb_pClassification.SelectedValue.ToString());
            if (cb_DATRAG.SelectedIndex > -1)
                new_pDATRAG                     = int.Parse(cb_DATRAG.SelectedValue.ToString());
            if (cb_Faculty.SelectedIndex > -1)
                new_pFaculty                    = int.Parse(cb_Faculty.SelectedValue.ToString());
            
            //dates are fuckey
            bool dateCheck = true;
            if (mtb_ProjectedStartDateValue.Text != "" & mtb_ProjectedStartDateValue.Text != "  /  /")
            {
                try
                {
                    new_pProjectedStartDate = Convert.ToDateTime(mtb_ProjectedStartDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Projected Start Date");
                    dateCheck = false;
                }
            }
            if (mtb_ProjectedEndDateValue.Text != "" & mtb_ProjectedEndDateValue.Text != "  /  /")
            {
                try
                {
                    new_pProjectedEndDate = Convert.ToDateTime(mtb_ProjectedEndDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Projected End Date");
                    dateCheck = false;
                }
            }
            if (mtb_pStartDateValue.Text != "" & mtb_pStartDateValue.Text != "  /  /")
            {
                try
                {
                    new_pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Start Date");
                    dateCheck = false;
                }
            }
            if (mtb_pEndDateValue.Text != "" & mtb_pEndDateValue.Text != "  /  /")
            {
                try
                {
                    new_pEndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid End Date");
                    dateCheck = false;
                }
            }

            //check to see if any changes have been made, no need to update if none.
            //if changes are made then update local variables with change and set changesMade flag to true
            bool changesMade;
            if (current_pName != new_pName)
                changesMade = true; 
            else if (current_pStage != new_pStage)
                changesMade = true; 
            else if (current_pClassification != new_pClassification)
                changesMade = true; 
            else if (current_pDATRAG != new_pDATRAG)
                changesMade = true; 
            else if (current_pProjectedStartDate != new_pProjectedStartDate)
                changesMade = true; 
            else if (current_pProjectedEndDate != new_pProjectedEndDate)
                changesMade = true; 
            else if (current_pStartDate != new_pStartDate)
                changesMade = true; 
            else if (current_pEndDate != new_pEndDate)
                changesMade = true; 
            else if (current_pPI != new_pPI)
                changesMade = true; 
            else if (current_pLeadApplicant != new_pLeadApplicant)
                changesMade = true; 
            else if (current_pFaculty != new_pFaculty)
                changesMade = true; 
            else if (current_pDSPT != new_pDSPT)
                changesMade = true; 
            else if (current_pISO != new_pISO)
                changesMade = true; 
            else if (current_pAzure != new_pAzure)
                changesMade = true; 
            else if (current_IRC != new_IRC)
                changesMade = true; 
            else if (current_SEED != new_SEED)
                changesMade = true; 
            else
                changesMade = false;

            if (changesMade == true & dateCheck == true)
            {
                //instantiate new Project type object that contains methods to update db
                var Projects = new Project();
                //check that record currently displayed is current record in database before updating anything
                if (Projects.checkCurrentRecord(pNumber, current_pID) == true)
                {
                    //update existing project - first perform logical delete then insert new record
                    Projects.deleteProject(current_pID);
                    Projects.insertProject(pNumber, new_pName, new_pStage, new_pClassification, new_pDATRAG
                        , new_pProjectedStartDate, new_pProjectedEndDate, new_pStartDate, new_pEndDate, new_pPI
                        , new_pLeadApplicant, new_pFaculty, new_pDSPT, new_pISO, new_pAzure, new_IRC, new_SEED);
                    //refresh dataset (ds_Projects) and form variable and control values
                    fillProjectsDataSet();
                    fillCurrentProjectVariables(pNumber);
                    setProjectDetails(pNumber);
                    setProjectNotes(pNumber);
                    MessageBox.Show($"Project details updated for {pNumber}");
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
            setProjectNotes(pNumber);
        }
    }
}
