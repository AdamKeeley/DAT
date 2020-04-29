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
    public partial class frm_ProjectAll : Form
    {
        public frm_ProjectAll()
        {
            InitializeComponent();
            fillProjectsDataSet();
            setControlDataSource();
            fillDataGridView();
        }

        DataSet ds_Project;

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
                //set controls values
                cb_pStage.DataSource = ds_Project.Tables["tlkStage"];
                cb_pStage.ValueMember = "StageID";
                cb_pStage.DisplayMember = "pStageDescription";
                cb_pStage.SelectedIndex = -1;
                cb_pClassification.DataSource = ds_Project.Tables["tlkClassification"];
                cb_pClassification.ValueMember = "classificationID";
                cb_pClassification.DisplayMember = "classificationDescription";
                cb_pClassification.SelectedIndex = -1;
                cb_DATRAG.DataSource = ds_Project.Tables["tlkRAG"];
                cb_DATRAG.ValueMember = "ragID";
                cb_DATRAG.DisplayMember = "ragDescription";
                cb_DATRAG.SelectedIndex = -1;
                cb_Faculty.DataSource = ds_Project.Tables["tlkFaculty"];
                cb_Faculty.ValueMember = "facultyID";
                cb_Faculty.DisplayMember = "facultyDescription";
                cb_Faculty.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setControlDataSource of class frm_ProjectAll has failed" + Environment.NewLine + Environment.NewLine + ex);
                throw;
            }
        }

        private void fillDataGridView()
        {
            string filterProjectName        = $"ProjectName like '%{tb_pNameValue.Text}%'";
            string filterStage              = $"Stage = {cb_pStage.SelectedValue}";
            string filterClassification     = $"Classification = {cb_pClassification.SelectedValue}";
            string filterDATRAG             = $"DATRAG = {cb_DATRAG.SelectedValue}";
            string filterLeadApplicant      = $"LeadApplicant like '%{tb_pLeadApplicantValue.Text}%'";
            string filterPI                 = $"PI like '%{tb_pPIValue.Text}%'";
            string filterFaculty            = $"Faculty = {cb_Faculty.SelectedValue}";
            string filterAll                = "ProjectNumber like '%'";

            if (tb_pNameValue.Text != "")
                filterAll = filterAll + " AND " + filterProjectName;
            if (cb_pStage.SelectedIndex > -1)
                filterAll = filterAll + " AND " + filterStage;
            if (cb_pClassification.SelectedIndex > -1)
                filterAll = filterAll + " AND " + filterClassification;
            if (cb_DATRAG.SelectedIndex > -1)
                filterAll = filterAll + " AND " + filterDATRAG;
            if (tb_pLeadApplicantValue.Text != "")
                filterAll = filterAll + " AND " + filterLeadApplicant;
            if (tb_pPIValue.Text != "")
                filterAll = filterAll + " AND " + filterPI;
            if (cb_Faculty.SelectedIndex > -1)
                filterAll = filterAll + " AND " + filterFaculty;

            DataTable dt_dgv_ProjectList = new DataTable();
            dt_dgv_ProjectList.Columns.Add("Project Number");
            dt_dgv_ProjectList.Columns.Add("Project Name");
            dt_dgv_ProjectList.Columns.Add("Stage");
            dt_dgv_ProjectList.Columns.Add("Classification");
            dt_dgv_ProjectList.Columns.Add("DATRAG");
            dt_dgv_ProjectList.Columns.Add("Lead Applicant");
            dt_dgv_ProjectList.Columns.Add("PI");
            dt_dgv_ProjectList.Columns.Add("Faculty");

            DataRow row;
            foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Select(filterAll))
            {
                row = dt_dgv_ProjectList.NewRow();
                row["Project Number"] = pRow["ProjectNumber"];
                row["Project Name"] = pRow["ProjectName"];
                foreach (DataRow sRow in pRow.GetParentRows("Project_Stage"))
                {
                    row["Stage"] = sRow["pStageDescription"];
                }
                foreach (DataRow cRow in pRow.GetParentRows("Project_Classification"))
                {
                    row["Classification"] = cRow["classificationDescription"];
                }
                foreach (DataRow dRow in pRow.GetParentRows("Project_DATRAG"))
                {
                    row["DATRAG"] = dRow["ragDescription"];
                }
                row["Lead Applicant"] = pRow["LeadApplicant"];
                row["PI"] = pRow["PI"];
                foreach (DataRow fRow in pRow.GetParentRows("Project_Faculty"))
                {
                    row["Faculty"] = fRow["facultyDescription"];
                }

                dt_dgv_ProjectList.Rows.Add(row);
            }

            dgv_ProjectList.DataSource = dt_dgv_ProjectList;
            dgv_ProjectList.Sort(dgv_ProjectList.Columns["Project Number"], ListSortDirection.Descending);

            dgv_ProjectList.Columns["Project Number"].Width = 50;
            dgv_ProjectList.Columns["Project Name"].Width = 240;
            dgv_ProjectList.Columns["Stage"].Width = 70;
            dgv_ProjectList.Columns["Classification"].Width = 90;
            dgv_ProjectList.Columns["DATRAG"].Width = 60;
            dgv_ProjectList.Columns["Lead Applicant"].Width = 120;
            dgv_ProjectList.Columns["PI"].Width = 120;
            dgv_ProjectList.Columns["Faculty"].Width = 180;
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
                catch (Exception)
                {
                    MessageBox.Show("Please double click on a data row to see project details.");
                }
            }
        }

        private void searchItemAdded(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void clearSearch(object sender, EventArgs e)
        {
            cb_DATRAG.SelectedIndex = -1;
            tb_pNameValue.Clear();
            cb_pStage.SelectedIndex = -1;
            cb_pClassification.SelectedIndex = -1;
            cb_DATRAG.SelectedIndex = -1;
            tb_pLeadApplicantValue.Clear();
            tb_pPIValue.Clear();
            cb_Faculty.SelectedIndex = -1;

            fillDataGridView();
        }

        private void open_frm_ProjectAdd(object sender, EventArgs e)
        {
            frm_ProjectAdd ProjectAdd = new frm_ProjectAdd(ds_Project);
            ProjectAdd.FormClosing += new FormClosingEventHandler(this.refreshPage);
            ProjectAdd.Show();
        }

        private void refreshPage(object sender, EventArgs e)
        {
            fillProjectsDataSet();
            setControlDataSource();
            fillDataGridView();
        }

    }
}
