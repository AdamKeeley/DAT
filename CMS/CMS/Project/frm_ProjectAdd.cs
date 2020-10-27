using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;

namespace CMS
{
    public partial class frm_ProjectAdd : Form
    {
        /// <summary>
        /// Constructor - receives parameter ds_Project that contains the DataSources for ComboBox options, passes it 
        /// on to a method that generates a new project number and sets the ComboBox DataSources
        /// </summary>
        /// <param name="ds_Project"></param>
        public frm_ProjectAdd()
        {
            InitializeComponent();
            setTabIndex();
            set_ProjectAdd();
        }

        DataSet ds_Project;
        public string pNumber;

        /// <summary>
        /// Uses methods in Project class to query SQL tblProjects for largest integer component of ProjectNumber 
        /// and increment it by 1 with a 'P' and leading zero prefix.
        /// </summary>
        /// <returns></returns>
        public string getNewProjectNumber()
        {
            Project Projects = new Project();
            int pNumInt = Projects.getLastProjectNumber() + 1;
            pNumber = Projects.getNewProjectNumber(pNumInt);
            return pNumber;
        }

        /// <summary>
        /// Method to fill class member DataSet (ds_Project) and assign the tables it contains to form controls
        /// </summary>
        private void set_ProjectAdd()
        {
            //instantiate new Project type object that contains project methods
            Project Projects = new Project();

            ds_Project = Projects.getProjectsDataSet();

            //bind DataSource to comboboxes
            DataView DATRAGItems = new DataView(ds_Project.Tables["tlkRAG"]);
            DATRAGItems.RowFilter = "[ValidTo] is null";
            cb_DATRAG.DataSource = DATRAGItems;
            cb_DATRAG.ValueMember = "ragID";
            cb_DATRAG.DisplayMember = "ragDescription";
            cb_DATRAG.SelectedIndex = -1;

            DataView pStageItems = new DataView(ds_Project.Tables["tlkStage"]);
            pStageItems.RowFilter = "[ValidTo] is null";
            cb_pStage.DataSource = pStageItems;
            cb_pStage.ValueMember = "StageID";
            cb_pStage.DisplayMember = "pStageDescription";
            cb_pStage.SelectedIndex = -1;

            DataView pClassificationItems = new DataView(ds_Project.Tables["tlkClassification"]);
            pClassificationItems.RowFilter = "[ValidTo] is null";
            cb_pClassification.DataSource = pClassificationItems;
            cb_pClassification.ValueMember = "classificationID";
            cb_pClassification.DisplayMember = "classificationDescription";
            cb_pClassification.SelectedIndex = -1;

            cb_LeadApplicant.DataSource = ds_Project.Tables["tlkLeadApplicant"];
            cb_LeadApplicant.ValueMember = "UserNumber";
            cb_LeadApplicant.DisplayMember = "FullName";
            cb_LeadApplicant.SelectedIndex = -1;

            cb_PI.DataSource = ds_Project.Tables["tlkPI"];
            cb_PI.ValueMember = "UserNumber";
            cb_PI.DisplayMember = "FullName";
            cb_PI.SelectedIndex = -1;

            DataView facultyItems = new DataView(ds_Project.Tables["tlkFaculty"]);
            facultyItems.RowFilter = "[ValidTo] is null";
            cb_Faculty.DataSource = facultyItems;
            cb_Faculty.ValueMember = "facultyID";
            cb_Faculty.DisplayMember = "facultyDescription";
            cb_Faculty.SelectedIndex = -1;
        }

        /// <summary>
        /// Method to create a new project record using values entered in form.
        /// Assigns control values to ProjectModel class variables, 
        /// checks dates are dates and passes them as parameters to 
        /// the insertProject(...) method of the Projects class.
        /// </summary>
        /// <returns>true on successful insert, false on fail</returns>
        private bool insertNewProject()
        {
            //generate new pNumber and put it into class variable, can be used within 
            //this method/class but also to feed back to parent form.
            pNumber = getNewProjectNumber();
            mdl_Project mdl_Project = new mdl_Project();

            //populate ProjectModel class variables with values held in form controls
            mdl_Project.ProjectNumber      = pNumber;
            mdl_Project.ProjectName        = tb_pNameValue.Text;
            mdl_Project.PortfolioNumber    = tb_PortfolioNo.Text;
            mdl_Project.DSPT               = chkb_DSPT.Checked;
            mdl_Project.ISO27001           = chkb_ISO27001.Checked;
            mdl_Project.LASER              = chkb_LASER.Checked;
            mdl_Project.IRC                = chkb_IRC.Checked;
            mdl_Project.SEED               = chkb_SEED.Checked;

            if (cb_pStage.SelectedIndex > -1)
            {
                mdl_Project.Stage = int.Parse(cb_pStage.SelectedValue.ToString());
                mdl_Project.Stage_Desc = cb_pStage.Text;
            }
            if (cb_pClassification.SelectedIndex > -1)
            {
                mdl_Project.Classification = int.Parse(cb_pClassification.SelectedValue.ToString());
                mdl_Project.Classification_Desc = cb_pClassification.Text;
            }
            if (cb_DATRAG.SelectedIndex > -1)
            {
                mdl_Project.DATRAG = int.Parse(cb_DATRAG.SelectedValue.ToString());
                mdl_Project.DATRAG_Desc = cb_DATRAG.Text;
            }
            if (cb_LeadApplicant.SelectedIndex > -1)
            {
                mdl_Project.LeadApplicant = int.Parse(cb_LeadApplicant.SelectedValue.ToString());
                mdl_Project.LeadApplicant_Desc = cb_LeadApplicant.Text;
            }
            if (cb_PI.SelectedIndex > -1)
            {
                mdl_Project.PI = int.Parse(cb_PI.SelectedValue.ToString());
                mdl_Project.PI_Desc = cb_PI.Text;
            }
            if (cb_Faculty.SelectedIndex > -1)
            {
                mdl_Project.Faculty = int.Parse(cb_Faculty.SelectedValue.ToString());
                mdl_Project.Faculty_Desc = cb_Faculty.Text;
            }

            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_ProjectedStartDateValue.Text != "" & mtb_ProjectedStartDateValue.Text != "  /  /")
            {
                try
                {
                    mdl_Project.ProjectedStartDate = Convert.ToDateTime(mtb_ProjectedStartDateValue.Text);
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
                    mdl_Project.ProjectedEndDate = Convert.ToDateTime(mtb_ProjectedEndDateValue.Text);
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
                    mdl_Project.StartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
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
                    mdl_Project.EndDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
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
            if (Projects.requiredFields(mdl_Project) == false)
            {
                return false;
            }

            if (dateCheck == true)
            {
                if (confirmationBox(mdl_Project) == DialogResult.OK)
                {
                    //insert new record
                    if (Projects.insertProject(mdl_Project) == true)
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
        private DialogResult confirmationBox(mdl_Project mdl_Project)
        {
            // tabs and newlines align and break up displayed information for ease of review
            string reviewProjectDetails = $"Create new project with these details?" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"DATRAG:\t\t\t{mdl_Project.DATRAG_Desc}" + Environment.NewLine;
            reviewProjectDetails += $"Project Name:\t\t{mdl_Project.ProjectName}" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"DSPT:\t\t\t{mdl_Project.DSPT}" + Environment.NewLine;
            reviewProjectDetails += $"ISO27001:\t\t{mdl_Project.ISO27001}" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"Projected Start Date:\t{mdl_Project.ProjectedStartDate}" + Environment.NewLine;
            reviewProjectDetails += $"Projected End Date:\t{mdl_Project.ProjectedEndDate}" + Environment.NewLine;
            reviewProjectDetails += $"Start Date:\t\t{mdl_Project.StartDate}" + Environment.NewLine;
            reviewProjectDetails += $"End Date:\t\t{mdl_Project.EndDate}" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"LASER:\t\t\t{mdl_Project.LASER}" + Environment.NewLine;
            reviewProjectDetails += $"IRC:\t\t\t{mdl_Project.IRC}" + Environment.NewLine;
            reviewProjectDetails += $"SEED:\t\t\t{mdl_Project.SEED}" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"Portfolio Number:\t\t{mdl_Project.PortfolioNumber}" + Environment.NewLine;
            reviewProjectDetails += $"Stage:\t\t\t{mdl_Project.Stage_Desc}" + Environment.NewLine;
            reviewProjectDetails += $"Classification:\t\t{mdl_Project.Classification_Desc}" + Environment.NewLine + Environment.NewLine;

            reviewProjectDetails += $"PI:\t\t\t{mdl_Project.PI_Desc}" + Environment.NewLine;
            reviewProjectDetails += $"Lead Applicant:\t\t{mdl_Project.LeadApplicant_Desc}" + Environment.NewLine;
            reviewProjectDetails += $"Faculty:\t\t\t{mdl_Project.Faculty_Desc}" + Environment.NewLine + Environment.NewLine;

            DialogResult confirm = MessageBox.Show(
                text: reviewProjectDetails
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

            x = 0;

            cb_DATRAG.TabIndex = ++x;
            tb_pNameValue.TabIndex = ++x;
 
            gb_Governance.TabIndex = ++x;
            chkb_ISO27001.TabIndex = ++x;
            chkb_DSPT.TabIndex = ++x;

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

            lbl_NewUser.TabIndex = ++x;
            cb_LeadApplicant.TabIndex = ++x;
            cb_PI.TabIndex = ++x;
            cb_Faculty.TabIndex = ++x;
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

        private void btn_UserAdd_Click(object sender, EventArgs e)
        {
            using (frm_UserAdd UserAdd = new frm_UserAdd())
            {
                UserAdd.ShowDialog();
                if (UserAdd.userAdded == true)
                {
                    set_ProjectAdd();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (insertNewProject() == true)
                this.Close();
        }
    }
}
