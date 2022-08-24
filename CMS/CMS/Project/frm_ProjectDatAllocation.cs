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

        private void refreshDatAllocationForm(string pNumber, DataSet ds_Project)
        {
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

        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            x = 0;

            gb_NewDatAllocation.TabIndex = ++x;
            mtb_pStartDateValue.TabIndex = ++x;
            mtb_pEndDateValue.TabIndex = ++x;
            nud_DatAllocation.TabIndex = ++x;
            btn_Project_ProjectDatAllocation_Add.TabIndex = ++x;

            btn_Project_ProjectDatAllocation_Remove.TabIndex = ++x;
            btn_Project_ProjectDatAllocation_Close.TabIndex = ++x;
        }
    }
}
