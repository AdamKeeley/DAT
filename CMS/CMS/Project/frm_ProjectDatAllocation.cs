using DataControlsLib;
using DataControlsLib.DataModels;
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
    public partial class frm_ProjectDatAllocation : Form
    {
        public frm_ProjectDatAllocation(string pNumber, DataSet ds_prj)
        {
            InitializeComponent();
            setTabIndex();
            refreshDatAllocationForm(pNumber, ds_prj);
        }

        string ProjectNumber;
        
        private void refreshDatAllocationForm(string pNumber, DataSet ds_Project)
        {
            // Clear controls
            mtb_FromDate.Clear();
            mtb_ToDate.Clear();
            nud_DatAllocation.Value = decimal.Parse(nud_DatAllocation.Minimum.ToString());

            ProjectNumber = pNumber;
            string filter = $"ProjectNumber = '{pNumber}'";

            //populate DataGridView (dgv_projectDatAllocation) from DataTable (ds_Project.Tables["tblProjectDatAllocation"])
            //create new DataTable (dt_dgv_projectDatAllocation) that just contains columns and records of interest
            DataTable dt_dgv_projectDatAllocation = new DataTable();
            
            DataColumn FromDate = new DataColumn("From Date");
            FromDate.DataType = System.Type.GetType("System.DateTime");
            dt_dgv_projectDatAllocation.Columns.Add(FromDate);
            DataColumn ToDate = new DataColumn("To Date");
            ToDate.DataType = System.Type.GetType("System.DateTime");
            dt_dgv_projectDatAllocation.Columns.Add(ToDate);
            dt_dgv_projectDatAllocation.Columns.Add("FTE");

            //iterate through each entry in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_Project.Tables["tblProjectDatAllocation"].Select(filter))
            {
                row = dt_dgv_projectDatAllocation.NewRow();
                row["From Date"] = nRow["FromDate"];
                row["To Date"] = nRow["ToDate"];
                row["FTE"] = nRow["FTE"];
                dt_dgv_projectDatAllocation.Rows.Add(row);
            }
            dgv_projectDatAllocation.DataSource = dt_dgv_projectDatAllocation;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_projectDatAllocation.Columns["From Date"].Width = 81;
            dgv_projectDatAllocation.Columns["To Date"].Width = 81;
            dgv_projectDatAllocation.Columns["FTE"].Width = 81;
            dgv_projectDatAllocation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_projectDatAllocation.Sort(dgv_projectDatAllocation.Columns["From Date"], ListSortDirection.Descending);
        }

        private mdl_ProjectDatAllocation fillProjectDatAllocationModel()
        {
            mdl_ProjectDatAllocation mdl_PDA = new mdl_ProjectDatAllocation();

            mdl_PDA.ProjectNumber = ProjectNumber;
            
            if (mtb_FromDate.Text != "" & mtb_FromDate.Text != "  /  /")
            {
                try
                {
                    mdl_PDA.FromDate = Convert.ToDateTime(mtb_FromDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid From Date");
                }
            }
            if (mtb_ToDate.Text != "" & mtb_ToDate.Text != "  /  /")
            {
                try
                {
                    mdl_PDA.ToDate = Convert.ToDateTime(mtb_ToDate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid To Date");
                }
            }

            mdl_PDA.FTE = nud_DatAllocation.Value;

            return mdl_PDA;
        }

        private bool checkRequiredFields(mdl_ProjectDatAllocation mdl_PDA)
        {
            if (mdl_PDA.FromDate == default(DateTime))
            {
                MessageBox.Show("Please enter valid From Date");
                if (mdl_PDA.ToDate == default(DateTime))
                {
                    MessageBox.Show("Please enter valid To Date");
                    return false;
                }
            }
            return true;
        }

        private void insertNewDatAllocation()
        {
            Project Project = new Project();
            mdl_ProjectDatAllocation mdl_PDA = fillProjectDatAllocationModel();

            //Check fields have valid entries and fill project document model
            if (checkRequiredFields(mdl_PDA) == true)
            {
                //Add record to SQL db, close form on success
                if (Project.insertDatAllocation(mdl_PDA) == true)
                {
                    refreshDatAllocationForm(ProjectNumber, Project.getProjectsDataSet());
                }

            }
        }

        private void removeDatAllocation()
        {

        }

        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            x = 0;

            gb_NewDatAllocation.TabIndex = ++x;
            mtb_FromDate.TabIndex = ++x;
            mtb_ToDate.TabIndex = ++x;
            nud_DatAllocation.TabIndex = ++x;
            btn_Project_ProjectDatAllocation_Add.TabIndex = ++x;

            btn_Project_ProjectDatAllocation_Remove.TabIndex = ++x;
            btn_Project_ProjectDatAllocation_Close.TabIndex = ++x;
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

        private void btn_Project_ProjectDatAllocation_Add_Click(object sender, EventArgs e)
        {
            insertNewDatAllocation();
        }
    }
}
