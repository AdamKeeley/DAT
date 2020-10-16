using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectAll : Form
    {
        public frm_ProjectAll()
        {
            InitializeComponent();
            setTabIndex();
            fillProjectsDataSet();
            setControlDataSource();
            fillDataGridView();
        }

        DataSet ds_Project;
        bool textChanged = true;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillProjectsDataSet()
        {
            var Projects = new Project();
            ds_Project = Projects.getProjectsDataSet();
        }

        private void setControlDataSource()
        {
            try
            {
                //Setting DataSource and SelectedIndex triggers the TextChanged event, which is set to run 
                //searchItemAdded method. This boolean flag prevents the method from running fillDataGridView 12 times
                textChanged = false;

                //Only display VRE numbers that are present in the PlatformInfoID column of the ProjectPlatformInfo table
                DataTable dt_VreNumber = new DataTable();
                dt_VreNumber.Columns.Add("ProjectNumber");
                dt_VreNumber.Columns.Add("VRENumber");
                dt_VreNumber.DefaultView.Sort = "VRENumber";
                DataRow vreRow;
                foreach (DataRow pRow in ds_Project.Tables["tblProjectPlatformInfo"].Select("[PlatformInfoID] = 1"))
                {
                    vreRow = dt_VreNumber.NewRow();
                    vreRow["ProjectNumber"] = pRow["ProjectNumber"];
                    vreRow["VRENumber"] = pRow["ProjectPlatformInfo"];
                    dt_VreNumber.Rows.Add(vreRow);
                }

                //Only display portfolio numbers that are present in the PortfolioNumber column of the Project table
                DataTable dt_PortfolioNo = new DataTable();
                dt_PortfolioNo.Columns.Add("ProjectNumber");
                dt_PortfolioNo.Columns.Add("PortfolioNumber");
                dt_PortfolioNo.DefaultView.Sort = "PortfolioNumber";
                DataRow ptRow;
                foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Select("[PortfolioNumber] is not null"))
                {
                    ptRow = dt_PortfolioNo.NewRow();
                    ptRow["ProjectNumber"] = pRow["ProjectNumber"];
                    ptRow["PortfolioNumber"] = pRow["PortfolioNumber"];
                    dt_PortfolioNo.Rows.Add(ptRow);
                }

                //Only display names that are present in the LeadApplicant column of the Project table
                DataTable dt_LeadApplicants = new DataTable();
                dt_LeadApplicants.Columns.Add("UserID");
                dt_LeadApplicants.Columns.Add("FullName");
                dt_LeadApplicants.DefaultView.Sort = "FullName";
                DataRow lRow;
                foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Select("[LeadApplicant] is not null"))
                {
                    lRow = dt_LeadApplicants.NewRow();
                    lRow["UserID"] = pRow["LeadApplicant"];
                    foreach (DataRow r in pRow.GetParentRows("Project_LeadApplicant"))
                    {
                        lRow["FullName"] = r["FullName"];
                    }
                    dt_LeadApplicants.Rows.Add(lRow);
                }

                //Only display names that are present in the PI column of the Project table
                DataTable dt_PIs = new DataTable();
                dt_PIs.Columns.Add("UserID");
                dt_PIs.Columns.Add("FullName");
                dt_PIs.DefaultView.Sort = "FullName";
                DataRow piRow;
                foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Select("[PI] is not null"))
                {
                    piRow = dt_PIs.NewRow();
                    piRow["UserID"] = pRow["PI"];
                    foreach (DataRow r in pRow.GetParentRows("Project_PI"))
                    {
                        piRow["FullName"] = r["FullName"];
                    }
                    dt_PIs.Rows.Add(piRow);
                }

                //set controls values
                cb_VreNumber.DataSource = dt_VreNumber.DefaultView.ToTable(true, "ProjectNumber", "VRENumber");
                cb_VreNumber.ValueMember = "ProjectNumber";
                cb_VreNumber.DisplayMember = "VRENumber";
                cb_VreNumber.SelectedIndex = -1;              
                cb_DATRAG.DataSource = ds_Project.Tables["tlkRAG"];
                cb_DATRAG.ValueMember = "ragID";
                cb_DATRAG.DisplayMember = "ragDescription";
                cb_DATRAG.SelectedIndex = -1;
                cb_PortfolioNo.DataSource = dt_PortfolioNo.DefaultView.ToTable(true, "ProjectNumber", "PortfolioNumber");
                cb_PortfolioNo.ValueMember = "ProjectNumber";
                cb_PortfolioNo.DisplayMember = "PortfolioNumber";
                cb_PortfolioNo.SelectedIndex = -1;
                cb_pStage.DataSource = ds_Project.Tables["tlkStage"];
                cb_pStage.ValueMember = "StageID";
                cb_pStage.DisplayMember = "pStageDescription";
                cb_pStage.SelectedIndex = -1;
                cb_pClassification.DataSource = ds_Project.Tables["tlkClassification"];
                cb_pClassification.ValueMember = "classificationID";
                cb_pClassification.DisplayMember = "classificationDescription";
                cb_pClassification.SelectedIndex = -1;
                cb_LeadApplicant.DataSource = dt_LeadApplicants.DefaultView.ToTable(true, "UserID", "FullName"); 
                cb_LeadApplicant.ValueMember = "UserID";
                cb_LeadApplicant.DisplayMember = "FullName";
                cb_LeadApplicant.SelectedIndex = -1;
                cb_PI.DataSource = dt_PIs.DefaultView.ToTable(true, "UserID", "FullName"); 
                cb_PI.ValueMember = "UserID";
                cb_PI.DisplayMember = "FullName";
                cb_PI.SelectedIndex = -1;
                cb_Faculty.DataSource = ds_Project.Tables["tlkFaculty"];
                cb_Faculty.ValueMember = "facultyID";
                cb_Faculty.DisplayMember = "facultyDescription";
                cb_Faculty.SelectedIndex = -1;
                
                textChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setControlDataSource of class frm_ProjectAll has failed" + Environment.NewLine + Environment.NewLine + ex);
                //throw;
            }
        }

        private void fillDataGridView()
        {
            string filterAll                = "ProjectNumber like '%'";
            string filterVreNumber          = $"VreNumber like '%{cb_VreNumber.Text}%'";
            string filterProjectName        = $"ProjectName like '%{tb_pNameValue.Text}%'";
            string filterPortfolioNumber    = $"PortfolioNumber like '%{cb_PortfolioNo.Text}%'";
            string filterStage              = $"Stage = '{cb_pStage.Text}'";
            string filterClassification     = $"Classification = '{cb_pClassification.Text}'";
            string filterDATRAG             = $"DATRAG = '{cb_DATRAG.Text}'";
            string filterLeadApplicant      = $"LeadApplicant like '%{cb_LeadApplicant.Text}%'";
            string filterPI                 = $"PI like '%{cb_PI.Text}%'";
            string filterFaculty            = $"Faculty = '{cb_Faculty.Text}'";

            if (cb_VreNumber.Text != "")
                filterAll += " AND " + filterVreNumber;
            if (tb_pNameValue.Text != "")
                filterAll += " AND " + filterProjectName;
            if (cb_PortfolioNo.Text != "")
                filterAll += " AND " + filterPortfolioNumber;
            if (cb_pStage.SelectedIndex > -1)
                filterAll += " AND " + filterStage;
            if (cb_pClassification.SelectedIndex > -1)
                filterAll += " AND " + filterClassification;
            if (cb_DATRAG.SelectedIndex > -1)
                filterAll += " AND " + filterDATRAG;
            if (cb_LeadApplicant.SelectedIndex > -1)
                filterAll += " AND " + filterLeadApplicant;
            if (cb_PI.SelectedIndex > -1)
                filterAll += " AND " + filterPI;
            if (cb_Faculty.SelectedIndex > -1)
                filterAll += " AND " + filterFaculty;

            //DataTable to fill with de-normalised text values of all projects
            DataTable dt_ProjectList = new DataTable();
            dt_ProjectList.Columns.Add("ProjectNumber");
            dt_ProjectList.Columns.Add("ProjectName");
            dt_ProjectList.Columns.Add("VreNumber");
            dt_ProjectList.Columns.Add("PortfolioNumber");
            dt_ProjectList.Columns.Add("Stage");
            dt_ProjectList.Columns.Add("Classification");
            dt_ProjectList.Columns.Add("DATRAG");
            dt_ProjectList.Columns.Add("LeadApplicant");
            dt_ProjectList.Columns.Add("PI");
            dt_ProjectList.Columns.Add("Faculty");

            DataRow a_row;
            foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Rows)
            {
                a_row = dt_ProjectList.NewRow();

                //concatenate VreNumbers into single string by creatig a list and joining with seperator
                List<string> vreNo = new List<string>();
                foreach (DataRow vRow in ds_Project.Tables["tblProjectPlatformInfo"].Select($"[PlatformInfoID] = 1 and [ProjectNumber] = '{pRow["ProjectNumber"]}'"))
                {
                    vreNo.Add(vRow["ProjectPlatformInfo"].ToString());
                }
                a_row["VreNumber"] = string.Join(";", vreNo);
                
                a_row["ProjectNumber"] = pRow["ProjectNumber"];
                a_row["ProjectName"] = pRow["ProjectName"];
                a_row["PortfolioNumber"] = pRow["PortfolioNumber"];
                foreach (DataRow sRow in pRow.GetParentRows("Project_Stage"))
                {
                    a_row["Stage"] = sRow["pStageDescription"];
                }
                foreach (DataRow cRow in pRow.GetParentRows("Project_Classification"))
                {
                    a_row["Classification"] = cRow["classificationDescription"];
                }
                foreach (DataRow dRow in pRow.GetParentRows("Project_DATRAG"))
                {
                    a_row["DATRAG"] = dRow["ragDescription"];
                }
                foreach (DataRow lRow in pRow.GetParentRows("Project_LeadApplicant"))
                {
                    a_row["LeadApplicant"] = lRow["FullName"];
                }
                foreach (DataRow piRow in pRow.GetParentRows("Project_PI"))
                {
                    a_row["PI"] = piRow["FullName"];
                }
                foreach (DataRow fRow in pRow.GetParentRows("Project_Faculty"))
                {
                    a_row["Faculty"] = fRow["facultyDescription"];
                }

                dt_ProjectList.Rows.Add(a_row);
            }

            //DataTable to fill with filtered project list and display in DataGridView
            DataTable dt_dgv_ProjectList = new DataTable();
            dt_dgv_ProjectList.Columns.Add("Project Number");
            dt_dgv_ProjectList.Columns.Add("Project Name");
            dt_dgv_ProjectList.Columns.Add("VRE Number");
            dt_dgv_ProjectList.Columns.Add("Portfolio Number"); 
            dt_dgv_ProjectList.Columns.Add("Stage");
            dt_dgv_ProjectList.Columns.Add("Classification");
            dt_dgv_ProjectList.Columns.Add("DATRAG");
            dt_dgv_ProjectList.Columns.Add("Lead Applicant");
            dt_dgv_ProjectList.Columns.Add("PI");
            dt_dgv_ProjectList.Columns.Add("Faculty");

            DataRow f_row;
            foreach (DataRow pRow in dt_ProjectList.Select(filterAll))
            {
                f_row = dt_dgv_ProjectList.NewRow();
                f_row["Project Number"] = pRow["ProjectNumber"];
                f_row["Project Name"] = pRow["ProjectName"];
                f_row["VRE Number"] = pRow["VreNumber"];
                f_row["Portfolio Number"] = pRow["PortfolioNumber"];
                f_row["Stage"] = pRow["Stage"];
                f_row["Classification"] = pRow["Classification"];
                f_row["DATRAG"] = pRow["DATRAG"];
                f_row["Lead Applicant"] = pRow["LeadApplicant"];
                f_row["PI"] = pRow["PI"];
                f_row["Faculty"] = pRow["Faculty"];

                dt_dgv_ProjectList.Rows.Add(f_row);
            }

            dgv_ProjectList.DataSource = dt_dgv_ProjectList;
            dgv_ProjectList.Sort(dgv_ProjectList.Columns["Project Number"], ListSortDirection.Descending);

            dgv_ProjectList.Columns["Project Number"].Width = 50;
            dgv_ProjectList.Columns["Project Name"].Width = 260;
            dgv_ProjectList.Columns["VRE Number"].Width = 50;
            dgv_ProjectList.Columns["Portfolio Number"].Width = 50;
            dgv_ProjectList.Columns["Stage"].Width = 70;
            dgv_ProjectList.Columns["Classification"].Width = 90;
            dgv_ProjectList.Columns["DATRAG"].Width = 60;
            dgv_ProjectList.Columns["Lead Applicant"].Width = 120;
            dgv_ProjectList.Columns["PI"].Width = 120;
            dgv_ProjectList.Columns["Faculty"].Width = 180;

            lbl_recordCount.Text = dt_dgv_ProjectList.Rows.Count.ToString() + " records";
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

            cb_VreNumber.TabIndex = ++x;
            cb_DATRAG.TabIndex = ++x;
            tb_pNameValue.TabIndex = ++x;

            cb_PortfolioNo.TabIndex = ++x;
            cb_pStage.TabIndex = ++x;
            cb_pClassification.TabIndex = ++x;
            cb_LeadApplicant.TabIndex = ++x;
            cb_PI.TabIndex = ++x;
            cb_Faculty.TabIndex = ++x;

            btn_Refresh.TabIndex = ++x;
            btn_ClearSearch.TabIndex = ++x;
            btn_NewProject.TabIndex = ++x;

        }

        private void dgv_ProjectList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    string pNumber = dgv_ProjectList.Rows[r].Cells["Project Number"].Value.ToString();
                    frm_Project Project = new frm_Project(pNumber);
                    Project.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to see project details." + Environment.NewLine + ex);
                }
            }
        }

        private void searchItemAdded(object sender, EventArgs e)
        {
            if (textChanged == true)
            fillDataGridView();
        }

        private void clearSearch(object sender, EventArgs e)
        {
            cb_VreNumber.ResetText();
            cb_VreNumber.SelectedIndex = -1;
            cb_DATRAG.SelectedIndex = -1;
            tb_pNameValue.Clear();
            cb_PortfolioNo.ResetText();
            cb_PortfolioNo.SelectedIndex = -1;
            cb_pStage.SelectedIndex = -1;
            cb_pClassification.SelectedIndex = -1;
            cb_DATRAG.SelectedIndex = -1;
            cb_LeadApplicant.SelectedIndex = -1;
            cb_PI.SelectedIndex = -1;
            cb_Faculty.SelectedIndex = -1;

            fillDataGridView();
        }

        private void open_frm_ProjectAdd(object sender, EventArgs e)
        {
            using (frm_ProjectAdd ProjectAdd = new frm_ProjectAdd())
            {
                ProjectAdd.ShowDialog();
                string ProjectNumber = ProjectAdd.pNumber;

                if (string.IsNullOrWhiteSpace(ProjectNumber) == false)
                {
                    refreshPage(ProjectAdd, e);
                }
            }
        }

        private void refreshPage(object sender, EventArgs e)
        {
            fillProjectsDataSet();
            setControlDataSource();
            fillDataGridView();
        }

    }
}
