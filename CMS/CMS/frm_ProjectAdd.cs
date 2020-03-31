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
            this.cb_DATRAG.DataSource = ds_Project.Tables["tlkRAG"];
            this.cb_DATRAG.ValueMember = "ragID";
            this.cb_DATRAG.DisplayMember = "ragDescription";
            this.cb_pStage.DataSource = ds_Project.Tables["tlkStage"];
            this.cb_pStage.ValueMember = "StageID";
            this.cb_pStage.DisplayMember = "pStageDescription";
            this.cb_pClassification.DataSource = ds_Project.Tables["tlkClassification"];
            this.cb_pClassification.ValueMember = "classificationID";
            this.cb_pClassification.DisplayMember = "classificationDescription";
            this.cb_Faculty.DataSource = ds_Project.Tables["tlkFaculty"];
            this.cb_Faculty.ValueMember = "facultyID";
            this.cb_Faculty.DisplayMember = "facultyDescription";
        }

        /// <summary>
        /// Method to create a new project record using values entered in form.
        /// Assigns control values to variables, checks dates are dates and passes them as parameters to 
        /// the insertProject(...) method of the Projects class.
        /// </summary>
        private void insertNewProject()
        {
            //populate variables with values held in form controls to compare to current project values
            string      pNumber             = lbl_NewProjectNumber.Text;
            string      pName               = tb_pNameValue.Text;
            int         pStage              = int.Parse(cb_pStage.SelectedValue.ToString());
            int         pClassification     = int.Parse(cb_pClassification.SelectedValue.ToString());
            int         pDATRAG             = int.Parse(cb_DATRAG.SelectedValue.ToString());
            DateTime?   pProjectedStartDate = null;
            DateTime?   pProjectedEndDate   = null;
            DateTime?   pStartDate          = null;
            DateTime?   pEndDate            = null;
            string      pPI                 = tb_pPIValue.Text;
            string      pLeadApplicant      = tb_pLeadApplicantValue.Text;
            int         pFaculty            = int.Parse(cb_Faculty.SelectedValue.ToString());
            bool        pDSPT               = chkb_DSPT.Checked;
            bool        pISO                = chkb_ISO27001.Checked;
            bool        pAzure              = chkb_Azure.Checked;
            bool        IRC                 = chkb_IRC.Checked;
            bool        SEED                = chkb_SEED.Checked;

            //dates are fuckey
            bool dateCheck = true;
            if (mtb_ProjectedStartDateValue.Text != "" & mtb_ProjectedStartDateValue.Text != "  /  /")
            {
                try
                {
                    pProjectedStartDate = Convert.ToDateTime(mtb_ProjectedStartDateValue.Text);
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
                    pProjectedEndDate = Convert.ToDateTime(mtb_ProjectedEndDateValue.Text);
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
                    pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
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
                    pEndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                    dateCheck = true;
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
                MessageBox.Show($"Project details updated for {pNumber}");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            insertNewProject();
            this.Close();
        }
    }
}
