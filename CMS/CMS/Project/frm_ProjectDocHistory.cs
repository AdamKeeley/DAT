using DataControlsLib;
using DataControlsLib.DataModels;
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
            setTabIndex();
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
            dt_dgv_DocumentHistory.Columns.Add("DocumentID");
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
                    row["DocumentID"] = tRow["DocumentID"];
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
            dgv_ProjectDocHistory.Columns["DocumentID"].Visible = false;
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
                    mdl_ProjectDoc mdl_ProjectDoc = new mdl_ProjectDoc();

                    int current_pdID = int.Parse(r.Cells["pdID"].Value.ToString());
                    mdl_ProjectDoc.ProjectNumber = projectNumber;
                    mdl_ProjectDoc.DocumentType = int.Parse(r.Cells["DocumentID"].Value.ToString());
                    mdl_ProjectDoc.DocumentType_Desc = r.Cells["Document Type"].Value.ToString();
                    mdl_ProjectDoc.VersionNumber = Decimal.Parse(r.Cells["Version"].Value.ToString());
                    if (r.Cells["Submitted"].Value.ToString().Length > 0)
                        mdl_ProjectDoc.Submitted = DateTime.Parse(r.Cells["Submitted"].Value.ToString());
                    mdl_ProjectDoc.Accepted = DateTime.Now;

                    DialogResult acceptProjectDoc = MessageBox.Show($"Accept version {mdl_ProjectDoc.VersionNumber} of the {mdl_ProjectDoc.DocumentType_Desc}?", "", MessageBoxButtons.YesNo);
                    if (acceptProjectDoc == DialogResult.Yes)
                    {
                        
                        Project projects = new Project();
                        // insert new record
                        if (projects.insertNewDoc(mdl_ProjectDoc) == true)
                        {
                            // update valid to of current record
                            if (projects.deleteProjectDocument(current_pdID) == true)
                                r.Cells["Accepted"].Value = DateTime.Now;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document record.");
            }
        }

        //delete document
        private void deleteProjectDocument()
        {
            if (dgv_ProjectDocHistory.Rows.Count > 0 & dgv_ProjectDocHistory.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgv_ProjectDocHistory.SelectedRows)
                {
                    mdl_ProjectDoc mdl_ProjectDoc = new mdl_ProjectDoc();

                    int current_pdID = int.Parse(r.Cells["pdID"].Value.ToString());
                    mdl_ProjectDoc.DocumentType_Desc = r.Cells["Document Type"].Value.ToString();
                    mdl_ProjectDoc.VersionNumber = Decimal.Parse(r.Cells["Version"].Value.ToString());

                    DialogResult acceptProjectDoc = MessageBox.Show($"Delete version {mdl_ProjectDoc.VersionNumber} of the {mdl_ProjectDoc.DocumentType_Desc}?", "", MessageBoxButtons.YesNo);
                    if (acceptProjectDoc == DialogResult.Yes)
                    {
                        Project projects = new Project();
                        // update valid to of current record
                        if (projects.deleteProjectDocument(current_pdID) == true)
                            dgv_ProjectDocHistory.Rows.RemoveAt(r.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document record.");
            }
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

            btn_ProjectDocAdd.TabIndex = ++x;
            btn_ProjectDocAccept.TabIndex = ++x;
            btn_ProjectDocDelete.TabIndex = ++x;
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
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = SQL_Stuff.conString;
                    conn.Credential = SQL_Stuff.credential;
                    using (conn)
                    {
                        SQL_Stuff.getDataTable(conn, ds_Projects, "tblProjectDocument",
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

        private void btn_ProjectDocDelete_Click(object sender, EventArgs e)
        {
            deleteProjectDocument();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
