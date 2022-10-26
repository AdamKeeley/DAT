using DataControlsLib;
using DataControlsLib.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectCostings : Form
    {
        public frm_ProjectCostings(string pNumber, DataSet ds_prj)
        {
            InitializeComponent();
            setTabIndex();
            refreshProjectCostingsForm(pNumber, ds_prj);
        }

        string ProjectNumber;
        
        private void refreshProjectCostingsForm(string pNumber, DataSet ds_Project)
        {
            //set controls
            lbl_pNumber.Text = pNumber;
            cb_CostingType.DataSource = ds_Project.Tables["tlkCostingType"];
            cb_CostingType.ValueMember = "CostingTypeId";
            cb_CostingType.DisplayMember = "CostingTypeDescription";

            // Clear controls
            cb_CostingType.SelectedIndex = -1;
            mtb_DateCosted.Clear();
            mtb_FromDate.Clear();
            mtb_ToDate.Clear();
            tb_ComputeAmount.Text = "£0.00";
            tb_ItsSupportAmount.Text = "£0.00";
            tb_FixedInfraAmount.Text = "£0.00";
            mtb_FromDate.Clear();
            mtb_ToDate.Clear();
            nud_DatAllocation.Value = decimal.Parse(nud_DatAllocation.Minimum.ToString());

            ProjectNumber = pNumber;

            populateDatAllocationDGV(pNumber, ds_Project);
            populateProjectCostingsDGV(pNumber, ds_Project);
        }

        private void populateDatAllocationDGV (string pNumber, DataSet ds_Project)
        {
            string filter = $"ProjectNumber = '{pNumber}'";

            //populate DataGridView (dgv_projectDatAllocation) from DataTable (ds_Project.Tables["tblProjectDatAllocation"])
            //create new DataTable (dt_dgv_projectDatAllocation) that just contains columns and records of interest
            DataTable dt_dgv_projectDatAllocation = new DataTable();

            dt_dgv_projectDatAllocation.Columns.Add("PDAId");
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
                row["PDAId"] = nRow["ProjectDatAllocationId"];
                row["From Date"] = nRow["FromDate"];
                row["To Date"] = nRow["ToDate"];
                row["FTE"] = nRow["FTE"];
                dt_dgv_projectDatAllocation.Rows.Add(row);
            }
            dgv_projectDatAllocation.DataSource = dt_dgv_projectDatAllocation;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_projectDatAllocation.Columns["PDAId"].Visible = false;
            dgv_projectDatAllocation.Columns["From Date"].Width = 81;
            dgv_projectDatAllocation.Columns["To Date"].Width = 81;
            dgv_projectDatAllocation.Columns["FTE"].Width = 81;
            dgv_projectDatAllocation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_projectDatAllocation.Sort(dgv_projectDatAllocation.Columns["From Date"], ListSortDirection.Descending);
        }

        private void populateProjectCostingsDGV(string pNumber, DataSet ds_Project)
        {
            string filter = $"ProjectNumber = '{pNumber}'";

            //populate DataGridView (dgv_ProjectCostings) from DataTable (ds_Project.Tables["tblProjectCostings"])
            //create new DataTable (dt_dgv_ProjectCostings) that just contains columns and records of interest
            DataTable dt_dgv_ProjectCostings = new DataTable();

            dt_dgv_ProjectCostings.Columns.Add("ProjectCostingsId");
            dt_dgv_ProjectCostings.Columns.Add("Costing Type");
            DataColumn FromDate = new DataColumn("From Date");
            FromDate.DataType = Type.GetType("System.DateTime");
            dt_dgv_ProjectCostings.Columns.Add(FromDate);
            DataColumn ToDate = new DataColumn("To Date");
            ToDate.DataType = Type.GetType("System.DateTime");
            dt_dgv_ProjectCostings.Columns.Add(ToDate);
            dt_dgv_ProjectCostings.Columns.Add("Laser Compute");
            dt_dgv_ProjectCostings.Columns.Add("ITS Support");
            dt_dgv_ProjectCostings.Columns.Add("Fixed Infrastructure");

            //iterate through each entry in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_Project.Tables["tblProjectCostings"].Select(filter))
            {
                row = dt_dgv_ProjectCostings.NewRow();
                row["ProjectCostingsId"] = nRow["ProjectCostingsId"];

                foreach (DataRow c in nRow.GetParentRows("ProjectCostings_CostingType"))
                {
                    row["Costing Type"] = c["CostingTypeDescription"];
                }
                

                row["From Date"] = nRow["FromDate"];
                row["To Date"] = nRow["ToDate"];
                row["Laser Compute"] = nRow["LaserCompute"];
                row["ITS Support"] = nRow["ItsSupport"];
                row["Fixed Infrastructure"] = nRow["FixedInfra"];
                dt_dgv_ProjectCostings.Rows.Add(row);
            }
            dgv_ProjectCostings.DataSource = dt_dgv_ProjectCostings;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_ProjectCostings.Columns["ProjectCostingsId"].Visible = false;
            dgv_ProjectCostings.Columns["Costing Type"].Width = 100;
            dgv_ProjectCostings.Columns["From Date"].Width = 81;
            dgv_ProjectCostings.Columns["To Date"].Width = 81;
            dgv_ProjectCostings.Columns["Laser Compute"].Width = 81;
            dgv_ProjectCostings.Columns["ITS Support"].Width = 81;
            dgv_ProjectCostings.Columns["Fixed Infrastructure"].Width = 81;
            dgv_ProjectCostings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_ProjectCostings.Sort(dgv_ProjectCostings.Columns["From Date"], ListSortDirection.Descending);
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
                    //MessageBox.Show("Please enter valid From Date");
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
                    //MessageBox.Show("Please enter valid To Date");
                }
            }

            mdl_PDA.FTE = nud_DatAllocation.Value;

            return mdl_PDA;
        }

        private bool checkRequiredFields(mdl_ProjectDatAllocation mdl_PDA)
        {
            // Check dates are present
            if (mdl_PDA.FromDate == default(DateTime))
            {
                MessageBox.Show("Please enter valid From Date");
                return false;
            }
            if (mdl_PDA.ToDate == default(DateTime))
            {
                MessageBox.Show("Please enter valid To Date");
                return false;
            }
            // Check chronology
            if (mdl_PDA.FromDate >= mdl_PDA.ToDate)
            {
                MessageBox.Show("From Date must be before To Date");
                return false;
            }

            // Check overlapping allocations
            foreach (DataGridViewRow row in dgv_projectDatAllocation.Rows)
            {
                if ( (mdl_PDA.FromDate >= Convert.ToDateTime(row.Cells["From Date"].Value.ToString()) 
                    && mdl_PDA.FromDate <= Convert.ToDateTime(row.Cells["To Date"].Value.ToString()) )
                    | ( mdl_PDA.ToDate <= Convert.ToDateTime(row.Cells["To Date"].Value.ToString()) 
                    && mdl_PDA.ToDate >= Convert.ToDateTime(row.Cells["From Date"].Value.ToString()) ) )
                {
                    MessageBox.Show("Entered period of DAT support coincides with existing period");
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
                    refreshProjectCostingsForm(ProjectNumber, Project.getProjectsDataSet());
                }
            }
        }

        private void removeDatAllocation()
        {
            if (dgv_projectDatAllocation.Rows.Count > 0 & dgv_projectDatAllocation.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgv_projectDatAllocation.SelectedRows)
                {
                    mdl_ProjectDatAllocation mdl_PDA = new mdl_ProjectDatAllocation();

                    int current_PDAId = int.Parse(r.Cells["PDAId"].Value.ToString());
                    mdl_PDA.FromDate = Convert.ToDateTime(r.Cells["From Date"].Value);
                    mdl_PDA.ToDate = Convert.ToDateTime(r.Cells["To Date"].Value);
                    
                    DialogResult acceptProjectDoc = MessageBox.Show($"Delete DAT Allocation for period {mdl_PDA.FromDate.ToShortDateString()} to {mdl_PDA.ToDate.ToShortDateString()}?", "", MessageBoxButtons.YesNo);
                    if (acceptProjectDoc == DialogResult.Yes)
                    {
                        Project projects = new Project();
                        // update valid to of current record
                        if (projects.deleteDatAllocation(current_PDAId) == true)
                            dgv_projectDatAllocation.Rows.RemoveAt(r.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document record.");
            }
        }

        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            x = 0;

            gb_LaserCosts.TabIndex = ++x;
            cb_CostingType.TabIndex = ++x;
            mtb_DateCosted.TabIndex = ++x;
            mtb_CostedFromDate.TabIndex = ++x;
            mtb_CostedToDate.TabIndex = ++x;
            tb_ComputeAmount.TabIndex = ++x;
            tb_ItsSupportAmount.TabIndex = ++x;
            tb_FixedInfraAmount.TabIndex = ++x;
            btn_LaserCosting_Add.TabIndex = ++x;
            btn_LaserCosting_Remove.TabIndex = ++x;

            gb_DatSupport.TabIndex = ++x;
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

        /// <summary>
        /// Prevent the cursor from being positioned in the middle of an empty textbox when 
        /// the user clicks in it. Get's a reference to target control and passes it through to method in 
        /// static helper class.
        /// To be called by the OnClick event of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter_TextBox(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox_Target = (TextBox)Controls.Find(((Control)sender).Name, true).First();
                Static_Helper.enter_TextBox(textBox_Target);
            }
        }

        /// <summary>
        /// Get's a reference to target control and passes it through to method in static helper class.
        /// To be called by the TextChanged event of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textChanged_TextBox_Currency(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox_Target = (TextBox)Controls.Find(((Control)sender).Name, true).First();
                Static_Helper.textChanged_TextBox_Currency(textBox_Target);
            }
        }

        private void btn_Project_ProjectDatAllocation_Add_Click(object sender, EventArgs e)
        {
            insertNewDatAllocation();
        }

        private void btn_Project_ProjectDatAllocation_Remove_Click(object sender, EventArgs e)
        {
            removeDatAllocation();
        }
    }
}
