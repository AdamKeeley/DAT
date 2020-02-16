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
        public frm_Project(string pNumber)
        {
            InitializeComponent();
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
        }

        //method to get project details from data bucket and assign to form controls
        private void setProjectDetails(string pNumber)
        {
            //instantiate new Project type object that contains details of all projects
            var Projects = new Project();
            //populate list of project details
            List<string> lst_ProjectDetails = Projects.getProjectToList(pNumber);
            //set controls values
            this.tb_pNameValue.Text = lst_ProjectDetails[1];
            this.cb_pStage.DataSource = Projects.ds_Project.Tables["tlkStage"];
            this.cb_pStage.ValueMember = "StageID";
            this.cb_pStage.DisplayMember = "pStageDescription";
            this.cb_pStage.Text = lst_ProjectDetails[2];
            this.tb_pPIValue.Text = lst_ProjectDetails[3];
            this.mtb_pStartDateValue.Text = lst_ProjectDetails[4];
            this.mtb_pEndDateValue.Text = lst_ProjectDetails[5];
            this.cb_pNumberValue.DataSource = Projects.ds_Project.Tables["tblProjects"];
            this.cb_pNumberValue.ValueMember = "pID";
            this.cb_pNumberValue.DisplayMember = "pNumber";
            this.cb_pNumberValue.Text = lst_ProjectDetails[0];
        }

        //method to get project notes from data bucket and assign to DataGridView
        private void setProjectNotes(string pNumber)
        {
            //instantiate new Project type object that contains details of all projects
            var Projects = new Project();

            //populate DataGridView (dgv_pNotes) from DataTable (Projects.ds_Project.Tables["tblProjectNotes"])
            //create new DataTable (dt_dgv_pNotes) that just contains columns of interest
            DataTable dt_dgv_pNotes = new DataTable();
            dt_dgv_pNotes.Columns.Add("Note");
            dt_dgv_pNotes.Columns.Add("Created");
            dt_dgv_pNotes.Columns.Add("Created By");
            //iterate through each project note in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in Projects.ds_Project.Tables["tblProjectNotes"].Select($"pNumber = '{pNumber}'"))
            {
                row = dt_dgv_pNotes.NewRow();
                row["Note"] = nRow["pNote"];
                row["Created"] = nRow["Created"];
                row["Created By"] = nRow["CreatedBy"];
                dt_dgv_pNotes.Rows.Add(row);
            }
            dgv_pNotes.DataSource = dt_dgv_pNotes;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_pNotes.Columns["Note"].Width = 290;
            dgv_pNotes.Columns["Created"].Width = 80;
            dgv_pNotes.Columns["Created By"].Width = 80;
            dgv_pNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_pNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        //method to check dates are dates
        private bool validateEnteredDateValues()
        {
            bool dateValidity = true;
            DateTime? pStartDate = null;
            DateTime? pEndDate = null;
            string enteredDate;
            //dates are fuckey
            if (mtb_pStartDateValue.Text != "" & mtb_pStartDateValue.Text != "  /  /")
            {
                try
                {
                    pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
                }
                catch (Exception)
                {
                    enteredDate = mtb_pStartDateValue.Text;
                    MessageBox.Show($"Unable to convert Start Date '{enteredDate}' to valid DateTime");
                    dateValidity = false;
                }
            }
            if (mtb_pEndDateValue.Text != "" & mtb_pEndDateValue.Text != "  /  /")
            {
                try
                {
                    pEndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                }
                catch (Exception)
                {
                    enteredDate = mtb_pEndDateValue.Text;
                    MessageBox.Show($"Unable to convert End Date '{enteredDate}' to valid DateTime");
                    dateValidity = false;
                }
            }
            return dateValidity;
        }

        //method to update project details; gets values from form, logically deletes current record and inserts new
        private void updateProject(string pNumber)
        {
            //dates are fuckey
            bool dateValidity = validateEnteredDateValues();

            if (dateValidity == true)
            {
                string new_pName = tb_pNameValue.Text;
                int new_pStage = int.Parse(cb_pStage.SelectedValue.ToString());
                string new_pPI = tb_pPIValue.Text;
                DateTime? new_pStartDate = null;
                DateTime? new_pEndDate = null;
                if (mtb_pStartDateValue.Text != "" & mtb_pStartDateValue.Text != "  /  /")
                {
                    new_pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
                }
                if (mtb_pEndDateValue.Text != "" & mtb_pEndDateValue.Text != "  /  /")
                {
                    new_pEndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                }

                //instantiate new Project type object that contains details of all projects and methods to update db
                var Projects = new Project();

                DataRow[] dr_CurrentProject;
                dr_CurrentProject = Projects.ds_Project.Tables["tblProjects"].Select($"pNumber = '{pNumber}' and ValidTo is null");

                string current_pName = dr_CurrentProject[0]["pName"].ToString();
                int current_pStage = (int)dr_CurrentProject[0]["pStage"];
                string current_pPI = dr_CurrentProject[0]["pPI"].ToString();
                //dates are fuckey
                DateTime? current_pStartDate = null;
                if (dr_CurrentProject[0]["pStartDate"].ToString() != "")
                    current_pStartDate = Convert.ToDateTime(dr_CurrentProject[0]["pStartDate"]);
                DateTime? current_pEndDate = null;
                if (dr_CurrentProject[0]["pEndDate"].ToString() != "")
                    current_pEndDate = Convert.ToDateTime(dr_CurrentProject[0]["pEndDate"]);

                //check to see if any changes have been made, no need to update if none
                bool changesMade;
                if (current_pName != new_pName)
                    changesMade = true;
                else if (current_pStage != new_pStage)
                    changesMade = true;
                else if (current_pPI != new_pPI)
                    changesMade = true;
                else if (current_pStartDate != new_pStartDate)
                    changesMade = true;
                else if (current_pEndDate != new_pEndDate)
                    changesMade = true;
                else
                    changesMade = false;

                if (changesMade == true)
                {
                    //update existing project - first perform logical delete then insert new record
                    Projects.deleteProject(pNumber);
                    Projects.insertProject(pNumber, new_pName, new_pStage, new_pPI, new_pStartDate, new_pEndDate);

                    MessageBox.Show($"Project details updated for {pNumber}");
                }
            }
        }

        //clear form
        private void clearForm()
        {
            //clear values from form
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    ComboBox cmbobox = (ComboBox)control;
                    cmbobox.Text = string.Empty;
                }
                else if (control is MaskedTextBox)
                {
                    MaskedTextBox mtb = (MaskedTextBox)control;
                    mtb.Text = string.Empty;
                }
                else if (control is DataGridView)
                {
                    DataGridView dgv = (DataGridView)control;
                    dgv.DataSource = null;
                }
            }
        }

        //method to add project note
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
                    Projects.ds_Project = Projects.getProjectsDataSet();
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
            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
        }

        //close form affecting no change to records
        private void btn_ProjectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //update project details and keep form open
        private void btn_ProjectApply_Click(object sender, EventArgs e)
        {
            //get project number
            string pNumber = cb_pNumberValue.Text;
            //update project details
            updateProject(pNumber);
        }

        //update project details and close form
        private void btn_ProjectOK_Click(object sender, EventArgs e)
        {
            //get project number
            string pNumber = cb_pNumberValue.Text;
            //update project details
            updateProject(pNumber);

            this.Close();
        }

        //open form to insert a new project record 
        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            frm_ProjectAdd ProjectAdd = new frm_ProjectAdd();
            ProjectAdd.FormClosing += new FormClosingEventHandler(this.ProjectAdd_FormClosing);
            ProjectAdd.Show();
        }

        private void ProjectAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Projects = new Project();

            string pNumber = Projects.getLastProjectNumber();

            setProjectDetails(pNumber);
            setProjectNotes(pNumber);
        }
    }
}
