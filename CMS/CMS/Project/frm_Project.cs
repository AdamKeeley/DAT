using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataControlsLib;
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
            setTabIndex();
            fillProjectsDataSet();
            refreshProjectForm(pNumber);
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
        mdl_Project mdl_CurrentProject;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillProjectsDataSet()
        {
            var Projects = new Project();
            ds_Project = Projects.getProjectsDataSet();
        }

        /// <summary>
        /// Runs through methods to populate form controls with project details.
        /// Does not refresh DataSet.
        /// </summary>
        /// <param name="pNumber"></param>
        private void refreshProjectForm(string pNumber)
        {
            fillCurrentProjectVariables(pNumber);
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
            setProjectPlatformInfo(pNumber);
            setProjectUsers(pNumber);
            changeDocButtonColour(pNumber);
            setDatTime(pNumber);
            setProjectKristalRef(pNumber);
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
                Project Projects = new Project();
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
                tb_PortfolioNo.Text                     = mdl_CurrentProject.PortfolioNumber;

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

                setProjectLeadUsers();

                cb_Faculty.DataSource                   = ds_Project.Tables["tlkFaculty"];
                cb_Faculty.ValueMember                  = "facultyID";
                cb_Faculty.DisplayMember                = "facultyDescription";
                if (mdl_CurrentProject.Faculty == null)
                    cb_Faculty.SelectedIndex = -1;
                else
                    cb_Faculty.SelectedValue            = mdl_CurrentProject.Faculty;
                
                chkb_ISO27001.Checked                   = mdl_CurrentProject.ISO27001;
                chkb_DSPT.Checked                       = mdl_CurrentProject.DSPT;
                chkb_LIDA.Checked                       = mdl_CurrentProject.LIDA;
                chkb_LASER.Checked                      = mdl_CurrentProject.LASER;
                chkb_IRC.Checked                        = mdl_CurrentProject.IRC;
                chkb_SEED.Checked                       = mdl_CurrentProject.SEED;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectDetails of class frm_Project has failed" + Environment.NewLine + ex);
                //throw;
            }
        }

        private void setProjectLeadUsers()
        {
            try
            {
                cb_LeadApplicant.DataSource = ds_Project.Tables["tlkLeadApplicant"];
                cb_LeadApplicant.ValueMember = "UserNumber";
                cb_LeadApplicant.DisplayMember = "FullName";
                if (mdl_CurrentProject.LeadApplicant == null)
                    cb_LeadApplicant.SelectedIndex = -1;
                else cb_LeadApplicant.SelectedValue = mdl_CurrentProject.LeadApplicant;

                cb_PI.DataSource = ds_Project.Tables["tlkPI"];
                cb_PI.ValueMember = "UserNumber";
                cb_PI.DisplayMember = "FullName";
                if (mdl_CurrentProject.PI == null)
                    cb_PI.SelectedIndex = -1;
                else cb_PI.SelectedValue = mdl_CurrentProject.PI;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectLeadUsers of class frm_Project has failed" + Environment.NewLine + ex);
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
            string filter = $"ProjectNumber = '{pNumber}'";
            string filterNotes = $"pNote like '%{tb_searchNotes.Text}%'";
            if (tb_searchNotes.Text != "")
            {
                filter += $" AND {filterNotes}";
            }
            
            //populate DataGridView (dgv_pNotes) from DataTable (ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_pNotes) that just contains columns of interest
            DataTable dt_dgv_pNotes = new DataTable();
            dt_dgv_pNotes.Columns.Add("Note");
            DataColumn CreatedDate = new DataColumn("Created Date");
            CreatedDate.DataType = System.Type.GetType("System.DateTime");
            dt_dgv_pNotes.Columns.Add(CreatedDate);            
            dt_dgv_pNotes.Columns.Add("Created By");
            //iterate through each project note in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_Project.Tables["tblProjectNotes"].Select(filter))
            {
                row = dt_dgv_pNotes.NewRow();
                row["Note"] = nRow["pNote"];
                row["Created Date"] = nRow["Created"];
                row["Created By"] = nRow["CreatedBy"];
                dt_dgv_pNotes.Rows.Add(row);
            }
            dgv_pNotes.DataSource = dt_dgv_pNotes;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_pNotes.Columns["Note"].Width = 511;
            dgv_pNotes.Columns["Created Date"].Width = 81;
            dgv_pNotes.Columns["Created By"].Width = 81;
            dgv_pNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_pNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_pNotes.Sort(dgv_pNotes.Columns["Created Date"], ListSortDirection.Descending);
        }

        private void searchItemAddedNotes(object sender, EventArgs e)
        {
            setProjectNotes(mdl_CurrentProject.ProjectNumber);
        }

        private void setProjectPlatformInfo(string pNumber)
        {
            //populate DataGridView (dgv_PlatformDetails) from DataTable (ds_Project.Tables["tblProjectPlatformInfo"])
            //create new DataTable (dt_dgv_PlatformDetails) that just contains columns of interest
            DataTable dt_dgv_PlatformDetails = new DataTable();
            dt_dgv_PlatformDetails.Columns.Add("ProjectPlatformInfoID");
            dt_dgv_PlatformDetails.Columns.Add("Item");
            dt_dgv_PlatformDetails.Columns.Add("Info");

            //iterate through each record in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow plRow in ds_Project.Tables["tblProjectPlatformInfo"].Select($"ProjectNumber = '{pNumber}'"))
            {
                row = dt_dgv_PlatformDetails.NewRow();
                row["ProjectPlatformInfoID"] = (int)plRow["ProjectPlatformInfoID"];
                foreach (DataRow platformInfoRow in plRow.GetParentRows("ProjectPlatformInfo_PlatformInfo"))
                {
                    row["Item"] = (string)platformInfoRow["PlatformInfoDescription"];
                }
                row["Info"] = (string)plRow["ProjectPlatformInfo"];
                dt_dgv_PlatformDetails.Rows.Add(row);
            }
            dgv_PlatformDetails.DataSource = dt_dgv_PlatformDetails;
            dgv_PlatformDetails.Columns["ProjectPlatformInfoID"].Visible = false;
            dgv_PlatformDetails.Sort(dgv_PlatformDetails.Columns["Item"], ListSortDirection.Descending);
            dgv_PlatformDetails.Columns["Item"].Width = 120;
            dgv_PlatformDetails.Columns["Info"].Width = 260;
        }

        private void setProjectKristalRef(string pNumber)
        {
            //populate DataGridView (dgv_KristalRef) from DataTable (ds_Project.Tables["tblProjectKristalRef"])
            //create new DataTable (dt_dgv_KristalRef) that just contains columns of interest
            DataTable dt_dgv_KristalRef = new DataTable();
            dt_dgv_KristalRef.Columns.Add("ProjectKristalID");
            dt_dgv_KristalRef.Columns.Add("Kristal Ref");
            dt_dgv_KristalRef.Columns.Add("KristalStageID");
            dt_dgv_KristalRef.Columns.Add("Stage");

            //iterate through each record in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow krRow in ds_Project.Tables["tblProjectKristal"].Select($"ProjectNumber = '{pNumber}'"))
            {
                row = dt_dgv_KristalRef.NewRow();
                row["ProjectKristalID"] = (int)krRow["ProjectKristalID"];
                row["Kristal Ref"] = (decimal)krRow["KristalRef"];
                row["KristalStageID"] = (int)krRow["GrantStageID"];
                foreach (DataRow grantStageRow in krRow.GetParentRows("ProjectKristal_GrantStage"))
                {
                    row["Stage"] = (string)grantStageRow["GrantStageDescription"];
                }
                dt_dgv_KristalRef.Rows.Add(row);
            }
            dgv_KristalRef.DataSource = dt_dgv_KristalRef;
            dgv_KristalRef.Columns["ProjectKristalID"].Visible = false;
            dgv_KristalRef.Columns["KristalStageID"].Visible = false;
            dgv_KristalRef.Sort(dgv_KristalRef.Columns["Kristal Ref"], ListSortDirection.Descending);
            dgv_KristalRef.Columns["Kristal Ref"].Width = 60;
            dgv_KristalRef.Columns["Stage"].Width = 90;
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
            //populate DataGridView (dgv_ProjectUsers) from DataTable (ds_Project.Tables["tblUserProject"])
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

        private void setDatTime(string pNumber)
        {
            //create new DataTable that just contains columns of interest
            DataTable dt_dgv_DatHours = new DataTable();
            dt_dgv_DatHours.Columns.Add("Period");
            dt_dgv_DatHours.Columns.Add("DAT Hours");

            DataRow row;
            foreach (DataRow dhRow in ds_Project.Tables["tblDatHours"].Select($"ProjectNumber = '{pNumber}'"))
            {
                row = dt_dgv_DatHours.NewRow();
                row["Period"] = "This Month";
                row["DAT Hours"] = dhRow["ThisMonth"];
                dt_dgv_DatHours.Rows.Add(row);
                row = dt_dgv_DatHours.NewRow();
                row["Period"] = "Last 6 Month";
                row["DAT Hours"] = dhRow["Last6Month"];
                dt_dgv_DatHours.Rows.Add(row);
                row = dt_dgv_DatHours.NewRow();
                row["Period"] = "Last 12 Month";
                row["DAT Hours"] = dhRow["Last12Month"];
                dt_dgv_DatHours.Rows.Add(row);
                row = dt_dgv_DatHours.NewRow();
                row["Period"] = "All Time";
                row["DAT Hours"] = dhRow["AllTime"];
                dt_dgv_DatHours.Rows.Add(row);
            }
            dgv_DatHours.DataSource = dt_dgv_DatHours;
            dgv_DatHours.Columns["Period"].Width = 100;
            dgv_DatHours.Columns["Period"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_DatHours.Columns["DAT Hours"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Changes colour of 'specific' Project Document buttons depending on whether that document type 
        /// has been submitted or accepted; basic RAG.
        /// </summary>
        /// <param name="pNumber"></param>
        private void changeDocButtonColour(string pNumber)
        {
            btn_Proposal.BackColor = System.Drawing.Color.LightSalmon;
            btn_DMP.BackColor = System.Drawing.Color.LightSalmon;
            btn_RA.BackColor = System.Drawing.Color.LightSalmon;

            foreach (DataRow dRow in ds_Project.Tables["tblDocsAccepted"].Select($"ProjectNumber = '{pNumber}' "))
            {
                DateTime? acceptedDate = dRow["maxAccepted"] == DBNull.Value ? null : (DateTime?)dRow["maxAccepted"];

                if (int.Parse(dRow["DocumentID"].ToString()) == 1)
                {
                    if (acceptedDate != null)
                        btn_Proposal.BackColor = System.Drawing.Color.PaleGreen;
                    else btn_Proposal.BackColor = System.Drawing.Color.Khaki;
                }
                if (int.Parse(dRow["DocumentID"].ToString()) == 2)
                {
                    if (acceptedDate != null)
                        btn_DMP.BackColor = System.Drawing.Color.PaleGreen;
                    else btn_DMP.BackColor = System.Drawing.Color.Khaki;
                }
                if (int.Parse(dRow["DocumentID"].ToString()) == 3)
                {
                    if (acceptedDate != null)
                        btn_RA.BackColor = System.Drawing.Color.PaleGreen;
                    else btn_RA.BackColor = System.Drawing.Color.Khaki;
                }
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

            cb_pNumberValue.TabIndex = ++x;
            cb_DATRAG.TabIndex = ++x;
            tb_pNameValue.TabIndex = ++x;

            gb_Governance.TabIndex = ++x;
            chkb_ISO27001.TabIndex = ++x;
            chkb_DSPT.TabIndex = ++x;

            chkb_LIDA.TabIndex = ++x;

            gb_KeyDates.TabIndex = ++x;
            mtb_ProjectedStartDateValue.TabIndex = ++x;
            mtb_ProjectedEndDateValue.TabIndex = ++x;
            mtb_pStartDateValue.TabIndex = ++x;
            mtb_pEndDateValue.TabIndex = ++x;

            gb_Platform.TabIndex = ++x;
            chkb_LASER.TabIndex = ++x;
            chkb_IRC.TabIndex = ++x;
            chkb_SEED.TabIndex = ++x;

            tb_PortfolioNo.TabIndex = ++x;
            cb_pStage.TabIndex = ++x;
            cb_pClassification.TabIndex = ++x;
            cb_LeadApplicant.TabIndex = ++x;
            cb_PI.TabIndex = ++x;
            cb_Faculty.TabIndex = ++x;

            gb_PlatformDetails.TabIndex = ++x;
            btn_PlatformDetailsAdd.TabIndex = ++x;
            btn_PlatformDetailsRemove.TabIndex = ++x;

            gb_ProjectUsers.TabIndex = ++x;
            btn_ProjectUserAdd.TabIndex = ++x;
            btn_ProjectUserRemove.TabIndex = ++x;

            gb_ProjectDocuments.TabIndex = ++x;
            btn_Proposal.TabIndex = ++x;
            btn_DMP.TabIndex = ++x;
            btn_RA.TabIndex = ++x;
            btn_AllDocs.TabIndex = ++x;

            gb_ProjectNotes.TabIndex = ++x;
            tb_NewProjectNote.TabIndex = ++x;
            btn_InsertProjectNote.TabIndex = ++x;
            tb_searchNotes.TabIndex = ++x;

            gb_DatTime.TabIndex = ++x;
            nud_DatHoursSpent.TabIndex = ++x;
            btn_DatHoursAdd.TabIndex = ++x;

            btn_NewProject.TabIndex = ++x;
            btn_Refresh.TabIndex = ++x;
            btn_ProjectApply.TabIndex = ++x;
            btn_ProjectOK.TabIndex = ++x;
            btn_ProjectCancel.TabIndex = ++x;
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
        /// Form control values assigned to ProjectModel while checking dates are valid, checks for 
        /// mandatory fields, compares with current record values (no change no update) and primary 
        /// key (not latest record no update).
        /// Updates record via insert & logical delete before refreshing DataSet and form controls.
        /// </summary>
        /// <param name="pNumber"></param>
        private bool updateProject(string pNumber)
        {
            bool success = false;
            mdl_Project mdl_NewProject = new mdl_Project();

            mdl_NewProject.ProjectNumber        = pNumber;
            mdl_NewProject.ProjectName          = tb_pNameValue.Text;
            if (tb_PortfolioNo.Text.Length > 0)
                mdl_NewProject.PortfolioNumber  = tb_PortfolioNo.Text;
            mdl_NewProject.DSPT                 = chkb_DSPT.Checked;
            mdl_NewProject.ISO27001             = chkb_ISO27001.Checked;
            mdl_NewProject.LIDA                 = chkb_LIDA.Checked;
            mdl_NewProject.LASER                = chkb_LASER.Checked;
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

            //instantiate new Project type object that contains methods to update db
            Project Projects = new Project();

            //Check required fields have an entry
            if (Projects.requiredFields(mdl_NewProject) == false)
            {
                return success = false;
            }

            //check to see if any changes have been made, no need to update if none.
            if (mdl_NewProject == mdl_CurrentProject)
            {
                return success = true;
            }

            if (dateCheck == true)
            {
                //check that record currently displayed is current record in database before updating anything
                if (Projects.checkCurrentRecord(pNumber, mdl_CurrentProject.pID) == true)
                {
                    //update existing project - first perform insert new record, if success returned = true then logical delete
                    if (Projects.insertProject(mdl_NewProject) == true)
                    {
                        Projects.deleteProject(mdl_CurrentProject.pID);

                        //refresh dataset (ds_Projects) and form variable and control values
                        fillProjectsDataSet();
                        refreshProjectForm(pNumber);

                        success = true;
                    }
                }
            }
            return success;
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

        private void removeProjectPlatformInfo()
        {
            int rowCount = dgv_PlatformDetails.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (rowCount > 0)
            {
                List<int> removedPlatformInfo = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    int rowIndex = dgv_PlatformDetails.SelectedRows[i].Index;
                    int projectPlatformInfoID = Convert.ToInt32(dgv_PlatformDetails.Rows[rowIndex].Cells["ProjectPlatformInfoID"].Value);
                    string projectPlatformItem = dgv_PlatformDetails.Rows[rowIndex].Cells["Item"].Value.ToString();

                    Project Projects = new Project();
                    DialogResult removeInfo = MessageBox.Show($"Remove {projectPlatformItem} from project record?", "", MessageBoxButtons.YesNo);
                    if (removeInfo == DialogResult.Yes)
                    {
                        if(Projects.deleteProjectPlatformInfo(projectPlatformInfoID) == true)
                            removedPlatformInfo.Add(rowIndex);
                    }
                }
                foreach (int rowIndex in removedPlatformInfo)
                {
                    dgv_PlatformDetails.Rows.RemoveAt(rowIndex);
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

        private void removeProjectKristal()
        {
            int rowCount = dgv_KristalRef.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (rowCount > 0)
            {
                List<int> removedRefs = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    int rowIndex = dgv_KristalRef.SelectedRows[i].Index;
                    int projectKristalID = Convert.ToInt32(dgv_KristalRef.Rows[rowIndex].Cells["ProjectKristalID"].Value);
                    string kristalRef = dgv_KristalRef.Rows[rowIndex].Cells["Kristal Ref"].Value.ToString();

                    DialogResult removeRef = MessageBox.Show($"Remove {kristalRef} from project record?", "", MessageBoxButtons.YesNo);
                    if (removeRef == DialogResult.Yes)
                    {
                        Project Projects = new Project();
                        Projects.deleteProjectKristal(projectKristalID);
                        removedRefs.Add(rowIndex);
                    }
                }
                foreach (int rowIndex in removedRefs)
                {
                    dgv_KristalRef.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private void openProjectDocHistory(int docType)
        {
            using (frm_ProjectDocHistory ProjectDocHistory = new frm_ProjectDocHistory(mdl_CurrentProject.ProjectNumber, ds_Project, docType))
            {
                ProjectDocHistory.ShowDialog();

                fillProjectsDataSet();
                refreshProjectForm(mdl_CurrentProject.ProjectNumber);
            }
        }

        private void addDatTimeSpent()
        {
            decimal DatHours = nud_DatHoursSpent.Value;
            string pNumber = mdl_CurrentProject.ProjectNumber;
            if (DatHours > 0)
            {
                Project projects = new Project();
                if (projects.insertDatTime(pNumber, DatHours) == true)
                {
                    MessageBox.Show($"Added {DatHours} hours to project {pNumber}.");
                    nud_DatHoursSpent.Value = 0;
                    fillProjectsDataSet();
                    refreshProjectForm(pNumber);
                }
            }
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

        /// <summary>
        /// Removes expired selectable items from a combobox. 
        /// Get's a reference to target combobox and passes it through to method in static helper class 
        /// that removes expired items. 
        /// To be triggered on Focus Enter event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combobox_RemoveLegacyItems(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                // get combobox name
                ComboBox combobox_Target = (ComboBox)Controls.Find(((Control)sender).Name, true).First();
                // pass reference to combobox through to method that removes expired items.
                Static_Helper.combobox_RemoveLegacyItems(combobox_Target);
            }
        }

        private void lbl_NewUser_Click(object sender, EventArgs e)
        {
            using (frm_UserAdd UserAdd = new frm_UserAdd())
            {
                UserAdd.ShowDialog();
                if (UserAdd.userAdded == true)
                {
                    // Need to just refresh user datasources and controls bound to them, not entire dataset & form.
                    Project project = new Project();
                    // First refresh dataset
                    ds_Project = project.refreshProjectUserTables(ds_Project);
                    // Then refresh data bindings
                    setProjectLeadUsers();
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
            refreshProjectForm(pNumber);
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
            if (updateProject(pNumber) == true)
                this.Close();
        }

        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            using (frm_ProjectAdd ProjectAdd = new frm_ProjectAdd())
            {
                ProjectAdd.ShowDialog();
                string ProjectNumber = ProjectAdd.pNumber;

                // Refreshes this form if new project number is generated (at project creation)
                if (string.IsNullOrWhiteSpace(ProjectNumber) == false)
                {
                    fillProjectsDataSet();
                    refreshProjectForm(ProjectNumber);
                }
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            string pNumber = cb_pNumberValue.Text;
            fillProjectsDataSet();
            refreshProjectForm(pNumber);
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
                    MessageBox.Show("Please double click on a data row to see user details." + Environment.NewLine + ex.Message);
                }
            }
        }

        private void btn_ProjectUserAdd_Click(object sender, EventArgs e)
        {
            using (frm_ProjectUserAdd ProjectUserAdd = new frm_ProjectUserAdd(mdl_CurrentProject.ProjectNumber, ds_Project))
            {
                ProjectUserAdd.ShowDialog();
                fillProjectsDataSet();
                refreshProjectForm(mdl_CurrentProject.ProjectNumber);
            }
        }

        private void btn_ProjectUserRemove_Click(object sender, EventArgs e)
        {
            removeProjectUser();
        }

        private void btn_PlatformDetailsAdd_Click(object sender, EventArgs e)
        {
            using (frm_ProjectPlatformInfoAdd ProjectPlatformInfoAdd = new frm_ProjectPlatformInfoAdd(mdl_CurrentProject.ProjectNumber, ds_Project))
            {
                ProjectPlatformInfoAdd.ShowDialog();
                fillProjectsDataSet();
                refreshProjectForm(mdl_CurrentProject.ProjectNumber);
            }
        }

        private void btn_DatTimeAdd_Click(object sender, EventArgs e)
        {
            addDatTimeSpent();
        }

        private void btn_PlatformDetailsRemove_Click(object sender, EventArgs e)
        {
            removeProjectPlatformInfo();
        }

        private void btn_AllDocs_Click(object sender, EventArgs e)
        {
            //Passing through DocumentID = 0; does not represent any DocType in SQL db will be treated as wildcard
            openProjectDocHistory(0);
        }

        private void btn_Proposal_Click(object sender, EventArgs e)
        {
            //Passing through DocumentID = 1; corresponds to Project Proposal in SQL db
            openProjectDocHistory(1);
        }

        private void btn_DMP_Click(object sender, EventArgs e)
        {
            //Passing through DocumentID = 2; corresponds to DMP in SQL db
            openProjectDocHistory(2);
        }

        private void btn_RA_Click(object sender, EventArgs e)
        {
            //Passing through DocumentID = 3; corresponds to Risk Assessment in SQL db
            openProjectDocHistory(3);
        }

        private void btn_UserDocs_Click(object sender, EventArgs e)
        {
            using(frm_ProjectUserDocs frm_pud = new frm_ProjectUserDocs(mdl_CurrentProject.ProjectNumber, mdl_CurrentProject.ProjectName))
            {
                frm_pud.ShowDialog();
            }
        }

        private void btn_KristalAdd_Click(object sender, EventArgs e)
        {
            using (frm_ProjectKristalAdd ProjectKristalAdd = new frm_ProjectKristalAdd(mdl_CurrentProject.ProjectNumber, ds_Project))
            {
                ProjectKristalAdd.ShowDialog();
                fillProjectsDataSet();
                refreshProjectForm(mdl_CurrentProject.ProjectNumber);
            }
        }

        private void btn_KristalRemove_Click(object sender, EventArgs e)
        {
            removeProjectKristal();
        }

        private void dgv_KristalRef_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    int KristalRef = Convert.ToInt32(dgv_KristalRef.Rows[r].Cells["Kristal Ref"].Value);
                    int GrantStage = Convert.ToInt32(dgv_KristalRef.Rows[r].Cells["KristalStageID"].Value);
                    DataTable tlkGrantStage = ds_Project.Tables["tlkGrantStage"];
                    frm_ProjectKristalEdit KristalEdit = new frm_ProjectKristalEdit(KristalRef, GrantStage, tlkGrantStage);
                    KristalEdit.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to see Kristal details." + Environment.NewLine + ex.Message);
                }
            }
        }
    }
}
