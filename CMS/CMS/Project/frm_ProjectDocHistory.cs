using DataControlsLib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectDocHistory : Form
    {
        public frm_ProjectDocHistory(string pNumber, DataSet ds_prj, int docType)
        {
            InitializeComponent();
            setProjectDocHistory(pNumber, ds_prj, docType);
        }

        string projectNumber;
        DataSet ds_Projects;
        int documentType;

        private void setProjectDocHistory(string pNumber, DataSet ds_prj, int docType)
        {
            // set member variables
            projectNumber = pNumber;
            ds_Projects = ds_prj;
            documentType = docType;

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
            dt_dgv_DocumentHistory.DefaultView.Sort = "Document Type Asc, Version Desc";
            dt_dgv_DocumentHistory = dt_dgv_DocumentHistory.DefaultView.ToTable();

            dgv_ProjectDocHistory.DataSource = dt_dgv_DocumentHistory;
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

        private void btn_ProjectDocAccept_click(object sender, EventArgs e)
        {
            acceptProjectDocument();
        }
        
        private void btn_ProjectDocAdd_click(object sender, EventArgs e)
        {
            using (frm_ProjectDocAdd addProjectDoc = new frm_ProjectDocAdd(projectNumber, ds_Projects, documentType))
            {
                addProjectDoc.ShowDialog();

                try
                {
                    ds_Projects.Tables["tblProjectDocument"].Clear();
                    //use the central connection string from the SQL_Stuff class
                    SQL_Stuff conString = new SQL_Stuff();
                    using (SqlConnection connection = new SqlConnection(conString.getString()))
                    {
                        GetDB.GetDataTable(connection, ds_Projects, "tblProjectDocument",
                        $"select * from [dbo].[tblProjectDocument]" +
                        $"where [ValidTo] is null");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to refresh tblProjectDocument" + Environment.NewLine + Environment.NewLine + ex.Message);
                }

                setProjectDocHistory(projectNumber, ds_Projects, documentType);
            }
        }
    }
}
