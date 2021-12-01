using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CMS.RIDM;
using DataControlsLib.DataModels;

namespace CMS
{
    public partial class frm_Kristal : Form
    {
        public frm_Kristal(mdl_Kristal mdl_Kristal)
        {
            InitializeComponent();
            setTabIndex();
            setKristal(mdl_Kristal);
            setKristalProjects();
            setKristalNotes();
        }

        mdl_Kristal current_Kristal;
        DataSet ds_Kristal;

        public void setKristal(mdl_Kristal mdl_Kristal)
        {
            try
            {
                current_Kristal = mdl_Kristal;
                Kristal kristal = new Kristal();
                ds_Kristal = kristal.getKristalDataSet();

                lbl_KristalRefValue.Text = current_Kristal.KristalRef.ToString();

                DataView GrantStages = new DataView(ds_Kristal.Tables["tlkGrantStage"]);
                GrantStages.RowFilter = "[ValidTo] is null";
                cb_GrantStage.DataSource = GrantStages;
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                cb_GrantStage.SelectedValue = current_Kristal.GrantStageID;

                tb_KristalName.Text = current_Kristal.KristalName;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setKristalEdit of class frm_ProjectKristalEdit has failed" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
        }


        public void setKristalProjects()
        {
            //populate DataGridView (dgv_KristalProjects) from DataTable (ds_Kristal.Tables["tblProjectKristal"])
            //create new DataTable (dt_dgv_KristalProjects) that just contains columns of interest
            DataTable dt_dgv_KristalProjects = new DataTable();
            dt_dgv_KristalProjects.Columns.Add("ProjectKristalID");
            dt_dgv_KristalProjects.Columns.Add("Project Number");
            dt_dgv_KristalProjects.Columns.Add("Project Name");
            dt_dgv_KristalProjects.Columns.Add("PI");
            dt_dgv_KristalProjects.Columns.Add("Lead Applicant");
            dt_dgv_KristalProjects.Columns.Add("Faculty");
            dt_dgv_KristalProjects.Columns.Add("Portfolio Number");

            //iterate through each user in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow kRow in ds_Kristal.Tables["tblProjectKristal"].Select($"KristalRef = '{current_Kristal.KristalRef}'"))
            {
                row = dt_dgv_KristalProjects.NewRow();

                row["ProjectKristalID"] = kRow["ProjectKristalID"];
                row["Project Number"] = kRow["ProjectNumber"];
                foreach (DataRow kp in kRow.GetParentRows("Kristal_Project"))
                {
                    row["Project Name"] = (string)kp["ProjectName"];
                    row["PI"] = (string)kp["PI"];
                    row["Lead Applicant"] = (string)kp["LeadApplicant"];
                    row["Faculty"] = (string)kp["Faculty"];
                    row["Portfolio Number"] = (string)kp["PortfolioNumber"];
                }
                dt_dgv_KristalProjects.Rows.Add(row);
            }
            dgv_KristalProjects.DataSource = dt_dgv_KristalProjects;
            dgv_KristalProjects.Sort(dgv_KristalProjects.Columns["Project Number"], ListSortDirection.Ascending);
            dgv_KristalProjects.Columns["ProjectKristalID"].Visible = false;
            dgv_KristalProjects.Columns["Project Number"].Width = 50;
            dgv_KristalProjects.Columns["Project Name"].Width = 250;
            dgv_KristalProjects.Columns["PI"].Width = 120;
            dgv_KristalProjects.Columns["Lead Applicant"].Width = 120;
            dgv_KristalProjects.Columns["Faculty"].Width = 150;
            dgv_KristalProjects.Columns["Portfolio Number"].Width = 50;
        }

        public bool updateKristal(mdl_Kristal currentKristal)
        {
            mdl_Kristal newKristal = new mdl_Kristal();

            try
            {
                newKristal.KristalRef = currentKristal.KristalRef;
                newKristal.GrantStageID = (int)cb_GrantStage.SelectedValue;
                newKristal.KristalName = tb_KristalName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid details." + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            //if details remain same, do nothing
            if (currentKristal == newKristal)
            {
                return true;
            }

            //if details changed, update
            if (newKristal != currentKristal)
            {
                Kristal kristal = new Kristal();
                //logically delete current record from dbo.tblKristal
                if (kristal.deleteKristal(current_Kristal.KristalID))
                {
                    //insert new record to dbo.tblKristal
                    kristal.insertKristal(newKristal);
                    current_Kristal = newKristal;
                    return true;
                }
            }
            return false;
        }

        private void removeProjectKristal()
        {
            int rowCount = dgv_KristalProjects.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (rowCount > 0)
            {
                List<int> removedRefs = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    int rowIndex = dgv_KristalProjects.SelectedRows[i].Index;
                    int projectKristalID = Convert.ToInt32(dgv_KristalProjects.Rows[rowIndex].Cells["ProjectKristalID"].Value);
                    string pNumber = dgv_KristalProjects.Rows[rowIndex].Cells["Project Number"].Value.ToString();

                    DialogResult removeRef = MessageBox.Show($"Remove {pNumber} from grant record?", "", MessageBoxButtons.YesNo);
                    if (removeRef == DialogResult.Yes)
                    {
                        Kristal kristal = new Kristal();
                        kristal.deleteProjectKristal(projectKristalID);
                        removedRefs.Add(rowIndex);
                    }
                }
                foreach (int rowIndex in removedRefs)
                {
                    dgv_KristalProjects.Rows.RemoveAt(rowIndex);
                }
            }
        }

        /// <summary>
        /// Method to add a note to a project record.
        /// If the textbox control tb_NewProjectNote is not empty the entered value is inserted into a table within 
        /// the SQL Server database.
        /// Assigns the contents of tb_NewProjectNote to a variable (newProjectNote), creates a new Project class 
        /// object and passes the parameter pNumber and variable newProjectNote to a method it contains (insertProjectNote).
        /// Refreshes class DataSet (ds_Project) and datagrid view before clearing the contents of the text box (tb_NewProjectNote).
        /// </summary>
        /// <param name="pNumber"></param>
        private void addKristalNote(int kristalRef)
        {
            string newKristalNote;

            if (tb_NewKristalNote.Text != "")
            {
                try
                {
                    //place the new note text into the string variable (newProjectNote)
                    newKristalNote = tb_NewKristalNote.Text;
                    //instantiate new Project type object that contains methods to update db
                    Kristal kristal = new Kristal();
                    //add the note to the SQL table
                    kristal.insertKristalNote(kristalRef, newKristalNote);
                    //refresh the DataSet (ds_Project)
                    ds_Kristal = kristal.getKristalDataSet();
                    //repopulate the DataGridView (dgv_pNotes)
                    setKristalNotes();
                    //clear the textbox control
                    tb_NewKristalNote.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add new note" + Environment.NewLine + ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Method to get grant notes from class DataSet (ds_Kristal) and assign to DataGridView on form (dgv_KristalNotes).
        /// Creates a new DataTable (dt_dgv_KristalNotes), adds records to it row by row from DataSet using parameter kristalRef and then 
        /// fills the DataGridView.
        /// Sizes columns to fit expected data.
        /// </summary>
        private void setKristalNotes()
        {
            string filter = $"KristalRef = '{current_Kristal.KristalRef}'";

            /*
            //Used if enabling search function for notes
            string filterNotes = $"KristalNote like '%{tb_searchNotes.Text}%'";
            if (tb_searchNotes.Text != "")
            {
                filter += $" AND {filterNotes}";
            }
            */

            //populate DataGridView (dgv_KristalNotes) from DataTable (ds_Kristal.Tables["tblKristalNotes"])
            //create new DataTable (dt_dgv_KristalNotes) that just contains columns of interest
            DataTable dt_dgv_KristalNotes = new DataTable();
            dt_dgv_KristalNotes.Columns.Add("Note");
            DataColumn CreatedDate = new DataColumn("Created Date");
            CreatedDate.DataType = System.Type.GetType("System.DateTime");
            dt_dgv_KristalNotes.Columns.Add(CreatedDate);
            dt_dgv_KristalNotes.Columns.Add("Created By");
            //iterate through each project note in source DataTable and add to newly created DataTable
            DataRow row;
            foreach (DataRow nRow in ds_Kristal.Tables["tblKristalNotes"].Select(filter))
            {
                row = dt_dgv_KristalNotes.NewRow();
                row["Note"] = nRow["KristalNote"];
                row["Created Date"] = nRow["Created"];
                row["Created By"] = nRow["CreatedBy"];
                dt_dgv_KristalNotes.Rows.Add(row);
            }
            dgv_KristalNotes.DataSource = dt_dgv_KristalNotes;

            //format DataGridView (dgv_pNotes) column widths etc.
            dgv_KristalNotes.Columns["Note"].Width = 300;
            dgv_KristalNotes.Columns["Created Date"].Width = 80;
            dgv_KristalNotes.Columns["Created By"].Width = 50;
            dgv_KristalNotes.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_KristalNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_KristalNotes.Sort(dgv_KristalNotes.Columns["Created Date"], ListSortDirection.Descending);
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

            cb_GrantStage.TabIndex = ++x;
            tb_KristalName.TabIndex = ++x;
            
            btn_Kristal_AddProject.TabIndex = ++x;
            btn_Kristal_RemoveProject.TabIndex = ++x;

            tb_NewKristalNote.TabIndex = ++x;
            btn_Kristal_InsertKristalNote.TabIndex = ++x;

            btn_Kristal_Create.TabIndex = ++x;
            btn_Kristal_Refresh.TabIndex = ++x;
            btn_Kristal_Apply.TabIndex = ++x;
            btn_Kristal_OK.TabIndex = ++x;
            btn_Kristal_Cancel.TabIndex = ++x;
        }

        private void dgv_KristalProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    string pNumber = dgv_KristalProjects.Rows[r].Cells["Project Number"].Value.ToString();
                    frm_Project Project = new frm_Project(pNumber);
                    Project.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to see project details." + Environment.NewLine + ex.Message);
                }
            }
        }

        private void btn_Kristal_Create_Click(object sender, EventArgs e)
        {
            using (frm_KristalAdd kristalAdd = new frm_KristalAdd())
            {
                kristalAdd.ShowDialog();
            }
        }

        private void btn_Kristal_Refresh_Click(object sender, EventArgs e)
        {
            setKristal(current_Kristal);
            setKristalProjects();
            setKristalNotes();
        }

        private void btn_Kristal_Apply_Click(object sender, EventArgs e)
        {
            updateKristal(current_Kristal);
        }

        private void btn_Kristal_OK_Click(object sender, EventArgs e)
        {
            if (updateKristal(current_Kristal))
                this.Close();
        }

        private void btn_Kristal_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Kristal_AddProject_Click(object sender, EventArgs e)
        {
            using (frm_KristalProjectAdd kristalProjectAdd = new frm_KristalProjectAdd(current_Kristal.KristalRef))
            {
                kristalProjectAdd.ShowDialog();
                setKristal(current_Kristal);
                setKristalProjects();
            }
        }

        private void btn_Kristal_RemoveProject_Click(object sender, EventArgs e)
        {
            removeProjectKristal();
        }

        private void btn_Kristal_InsertKristalNote_Click(object sender, EventArgs e)
        {
            addKristalNote(current_Kristal.KristalRef);
        }
    }
}
