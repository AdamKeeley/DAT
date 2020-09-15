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
    public partial class frm_ProjectDocHistory : Form
    {
        public frm_ProjectDocHistory(string pNumber, DataSet ds_prj, int docType)
        {
            InitializeComponent();
            setControls(pNumber, ds_prj, docType);
        }

        private void setControls(string pNumber, DataSet ds_prj, int docType)
        {
            //set labels
            lbl_ProjectNumber.Text = pNumber;
            foreach (DataRow pRow in ds_prj.Tables["tblProjects"].Select($"ProjectNumber = '{pNumber}'"))
            {
                lbl_ProjectName.Text = pRow["ProjectName"].ToString();
            }

            //set data grid view
            DataTable dt_dgv_DocumentHistory = new DataTable();

            dt_dgv_DocumentHistory.Columns.Add("pdID");
            dt_dgv_DocumentHistory.Columns.Add("Document Type");
            dt_dgv_DocumentHistory.Columns.Add("Version");
            dt_dgv_DocumentHistory.Columns.Add("Submitted");
            dt_dgv_DocumentHistory.Columns.Add("Accepted");

            // Set the scope of returned data dependant on which button was clicked
            string qry;
            if (docType == 0)
            {
                qry = $"ProjectNumber = '{pNumber}'";
                this.Text = $"All Document History";
            }
            else
            { 
                qry = $"ProjectNumber = '{pNumber}' AND DocumentType = {docType}";
                foreach (DataRow r in ds_prj.Tables["tlkDocuments"].Select($"DocumentID = {docType}"))
                {
                    this.Text = r["DocumentDescription"] + $" Document History";
                }
            }

            DataRow row;
            foreach (DataRow hRow in ds_prj.Tables["tblProjectDocument"].Select(qry))
            {
                row = dt_dgv_DocumentHistory.NewRow();
                row["pdID"] = hRow["pdID"];
                foreach (DataRow tRow in hRow.GetParentRows("ProjectDocument_Document"))
                {
                    row["Document Type"] = tRow["DocumentDescription"];
                }
                row["Version"] = hRow["VersionNumber"];
                row["Submitted"] = hRow["Submitted"];
                row["Accepted"] = hRow["Accepted"];

                dt_dgv_DocumentHistory.Rows.Add(row);
            }

            dgv_ProjectDocHistory.DataSource = dt_dgv_DocumentHistory;
            dgv_ProjectDocHistory.Sort(dgv_ProjectDocHistory.Columns["Submitted"], ListSortDirection.Descending);
            dgv_ProjectDocHistory.Columns["pdID"].Visible = false;
            dgv_ProjectDocHistory.Columns["Document Type"].Width = 140;
            dgv_ProjectDocHistory.Columns["Version"].Width = 70;
            dgv_ProjectDocHistory.Columns["Submitted"].Width = 80;
            dgv_ProjectDocHistory.Columns["Accepted"].Width = 80;
        }

        //accept document
        private void acceptProjectDocument()
        {
            if (dgv_ProjectDocHistory.Rows.Count > 0 & dgv_ProjectDocHistory.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgv_ProjectDocHistory.SelectedRows)
                {
                    int pdID = int.Parse(r.Cells["pdID"].Value.ToString());
                    string pdVersion = r.Cells["Version"].Value.ToString();
                    string pdDocType = r.Cells["Document Type"].Value.ToString();

                    DialogResult acceptProjectDoc = MessageBox.Show($"Accept version {pdVersion} of the {pdDocType}?", "", MessageBoxButtons.YesNo);
                    if (acceptProjectDoc == DialogResult.Yes)
                    {
                        Project projects = new Project();
                        if (projects.acceptProjectDocument(pdID) == true)
                            r.Cells["Accepted"].Value = DateTime.Now;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document record.");
            }
        }

        //add document
        private void addProjectDocument()
        {

        }

        private void btn_ProjectDocAccept_click(object sender, EventArgs e)
        {
            acceptProjectDocument();
        }
    }
}
