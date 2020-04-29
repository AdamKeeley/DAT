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
    public partial class frm_ProjectAdd : Form
    {
        /// <summary>
        /// Constructor - receives parameter ds_Project that contains the DataSources for ComboBox options, passes it 
        /// on to a method that generates a new project number and sets the ComboBox DataSources
        /// </summary>
        /// <param name="ds_Project"></param>
        public frm_ProjectAdd(DataSet ds_Project)
        {
            InitializeComponent();
            set_frmProjectAdd(ds_Project);
        }

        /// <summary>
        /// Method to generate new project number and set DataSources to the ComboBoxes.
        /// Uses DataSet parameter (ds_Project) that contains ComboBox DataSources for drop down options
        /// </summary>
        /// <param name="ds_Project"></param>
        private void set_frmProjectAdd(DataSet ds_Project)
        {
            //instantiate new Project type object that contains project methods
            var Projects = new Project();

            //generate new pNumber and put it into a variable
            int pNumInt = Projects.getLastProjectNumber() + 1;
            string pNumber = Projects.getNewProjectNumber(pNumInt);
            //populate pNumber
            lbl_NewProjectNumber.Text = pNumber;

            //bind DataSource to comboboxes
            cb_DATRAG.DataSource = ds_Project.Tables["tlkRAG"];
            cb_DATRAG.ValueMember = "ragID";
            cb_DATRAG.DisplayMember = "ragDescription";
            cb_DATRAG.SelectedIndex = -1;
            cb_pStage.DataSource = ds_Project.Tables["tlkStage"];
            cb_pStage.ValueMember = "StageID";
            cb_pStage.DisplayMember = "pStageDescription";
            cb_pStage.SelectedIndex = -1;
            cb_pClassification.DataSource = ds_Project.Tables["tlkClassification"];
            cb_pClassification.ValueMember = "classificationID";
            cb_pClassification.DisplayMember = "classificationDescription";
            cb_pClassification.SelectedIndex = -1;
            cb_LeadApplicant.DataSource = ds_Project.Tables["tlkLeadApplicant"];
            cb_LeadApplicant.ValueMember = "UserID";
            cb_LeadApplicant.DisplayMember = "FullName";
            cb_LeadApplicant.SelectedIndex = -1;
            cb_PI.DataSource = ds_Project.Tables["tlkPI"];
            cb_PI.ValueMember = "UserID";
            cb_PI.DisplayMember = "FullName";
            cb_PI.SelectedIndex = -1;           
            cb_Faculty.DataSource = ds_Project.Tables["tlkFaculty"];
            cb_Faculty.ValueMember = "facultyID";
            cb_Faculty.DisplayMember = "facultyDescription";
            cb_Faculty.SelectedIndex = -1;
        }

        /// <summary>
        /// Method to create a new project record using values entered in form.
        /// Assigns control values to variables, checks dates are dates and passes them as parameters to 
        /// the insertProject(...) method of the Projects class.
        /// </summary>
        private void insertNewProject()
        {
            //populate variables with values held in form controls
            string      pNumber             = lbl_NewProjectNumber.Text;
            string      pName               = tb_pNameValue.Text;
            int?        pStage              = null;
            int?        pClassification     = null;
            int?        pDATRAG             = null;
            DateTime?   pProjectedStartDate = null;
            DateTime?   pProjectedEndDate   = null;
            DateTime?   pStartDate          = null;
            DateTime?   pEndDate            = null;
            int?        pPI                 = null;
            int?        pLeadApplicant      = null;
            int?        pFaculty            = null;
            bool        pDSPT               = chkb_DSPT.Checked;
            bool        pISO                = chkb_ISO27001.Checked;
            bool        pAzure              = chkb_Azure.Checked;
            bool        IRC                 = chkb_IRC.Checked;
            bool        SEED                = chkb_SEED.Checked;

            if (cb_pStage.SelectedIndex > -1)
                pStage = int.Parse(cb_pStage.SelectedValue.ToString());
            if (cb_pClassification.SelectedIndex > -1)
                pClassification = int.Parse(cb_pClassification.SelectedValue.ToString());
            if (cb_DATRAG.SelectedIndex > -1)
                pDATRAG = int.Parse(cb_DATRAG.SelectedValue.ToString());
            if (cb_LeadApplicant.SelectedIndex > -1)
                pLeadApplicant = int.Parse(cb_LeadApplicant.SelectedValue.ToString());
            if (cb_PI.SelectedIndex > -1)
                pPI = int.Parse(cb_PI.SelectedValue.ToString());
            if (cb_Faculty.SelectedIndex > -1)
                pFaculty = int.Parse(cb_Faculty.SelectedValue.ToString());

            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_ProjectedStartDateValue.Text != "" & mtb_ProjectedStartDateValue.Text != "  /  /")
            {
                try
                {
                    pProjectedStartDate = Convert.ToDateTime(mtb_ProjectedStartDateValue.Text);
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
                    pProjectedEndDate = Convert.ToDateTime(mtb_ProjectedEndDateValue.Text);
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
                    pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
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
                    pEndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid End Date");
                    dateCheck = false;
                }
            }

            if (dateCheck == true)
            {
                //instantiate new Project type object that contains methods to update db
                var Projects = new Project();

                //insert new record
                Projects.insertProject(pNumber, pName, pStage, pClassification, pDATRAG
                    , pProjectedStartDate, pProjectedEndDate, pStartDate, pEndDate, pPI
                    , pLeadApplicant, pFaculty, pDSPT, pISO, pAzure, IRC, SEED);

                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            insertNewProject();
        }
    }
}
