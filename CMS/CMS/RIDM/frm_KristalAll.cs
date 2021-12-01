using DataControlsLib;
using DataControlsLib.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CMS.RIDM
{
    public partial class frm_KristalAll : Form
    {
        public frm_KristalAll()
        {
            InitializeComponent();
            setTabIndex();
            fillKristalDataSet();
            setControlDataSource();
            fillDataGridView();
        }

        DataSet ds_Kristal;
        bool textChanged = true;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillKristalDataSet()
        {
            Kristal kristal = new Kristal();
            //var kristal = new Kristal();
            ds_Kristal = kristal.getKristalDataSet();
        }


        private void setControlDataSource()
        {
            try
            {

                //Setting DataSource and SelectedIndex triggers the TextChanged event, which is set to run 
                //searchItemAdded method. This boolean flag prevents the method from running fillDataGridView 12 times
                textChanged = false;

                //only display grant stages that are present in the GrantStage column of the Kristal table
                DataTable dt_GrantStage = new DataTable();
                dt_GrantStage.Columns.Add("GrantStageID");
                dt_GrantStage.Columns.Add("GrantStageDescription");
                dt_GrantStage.Columns.Add("StageNumber");
                dt_GrantStage.DefaultView.Sort = "StageNumber";
                DataRow grantStageRow;
                foreach (DataRow gsRow in ds_Kristal.Tables["tblKristal"].Select("[GrantStageID] is not null"))
                {
                    grantStageRow = dt_GrantStage.NewRow();
                    grantStageRow["GrantStageID"] = gsRow["GrantStageID"];
                    foreach (DataRow r in gsRow.GetParentRows("Kristal_GrantStage"))
                    {
                        grantStageRow["GrantStageDescription"] = r["GrantStageDescription"];
                        grantStageRow["StageNumber"] = r["StageNumber"];
                    }
                    dt_GrantStage.Rows.Add(grantStageRow);
                }

                cb_GrantStage.DataSource = dt_GrantStage.DefaultView.ToTable(true, "GrantStageID", "GrantStageDescription");
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                cb_GrantStage.SelectedIndex = -1;

                textChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setControlDataSource of class frm_ProjectAll has failed" + Environment.NewLine + Environment.NewLine + ex);
            }
        }


        private void fillDataGridView()
        {
            string filterKristalRef         = $"KristalRef like '%{tb_KristalRef.Text}%'";
            string filterKristalName        = $"KristalName like '%{tb_KristalName.Text}%'";
            string filterGrantStage         = $"GrantStage = '{cb_GrantStage.Text}'";

            // Create list and add above filter clauses if appropriate, 
            // before concatenating to single string seperated with " AND "
            List<string> filter = new List<string>();

            if (tb_KristalRef.Text != "")
                filter.Add(filterKristalRef);
            if (tb_KristalName.Text != "")
                filter.Add(filterKristalName);
            if (cb_GrantStage.SelectedIndex > -1)
                filter.Add(filterGrantStage);
            string filterAll = string.Join(" AND ", filter);

            /*
             * So the columns that would be useful for me to see are 'Project Name', 'Kristal Ref', 'Portfolio Number', 'Grant stage', 'PI', 'Faculty'
             */

            //DataTable to fill with de-normalised text values of all projects
            DataTable dt_KristalList = new DataTable();
            dt_KristalList.Columns.Add("KristalRef");
            dt_KristalList.Columns.Add("KristalName");
            dt_KristalList.Columns.Add("GrantStage");
            dt_KristalList.Columns.Add("ProjectNumber");

            DataRow a_row;
            foreach (DataRow pRow in ds_Kristal.Tables["tblKristal"].Rows)
            {
                a_row = dt_KristalList.NewRow();

                a_row["KristalRef"] = pRow["KristalRef"];
                a_row["KristalName"] = pRow["KristalName"];
                foreach (DataRow sRow in pRow.GetParentRows("Kristal_GrantStage"))
                {
                    a_row["GrantStage"] = sRow["GrantStageDescription"];
                }
                //concatenate Project numbers into single string by creating a list and joining with seperator
                List<string> ProjectNumber = new List<string>();
                foreach (DataRow kRow in ds_Kristal.Tables["tblProjectKristal"].Select($"[KristalRef] = '{pRow["KristalRef"]}'"))
                {
                    ProjectNumber.Add(kRow["ProjectNumber"].ToString());
                }
                ProjectNumber.Sort();
                a_row["ProjectNumber"] = string.Join(";", ProjectNumber);

                dt_KristalList.Rows.Add(a_row);
            }

            //DataTable to fill with filtered project list and display in DataGridView
            DataTable dt_dgv_KristalList = new DataTable();
            dt_dgv_KristalList.Columns.Add("Kristal Ref");
            dt_dgv_KristalList.Columns.Add("Kristal Name");
            dt_dgv_KristalList.Columns.Add("Grant Stage");
            dt_dgv_KristalList.Columns.Add("Project Number");

            DataRow f_row;
            foreach (DataRow kRow in dt_KristalList.DefaultView.ToTable(true, "KristalRef", "KristalName", "GrantStage", "ProjectNumber").Select(filterAll))
            {
                f_row = dt_dgv_KristalList.NewRow();
                f_row["Kristal Ref"] = kRow["KristalRef"];
                f_row["Kristal Name"] = kRow["KristalName"];
                f_row["Grant Stage"] = kRow["GrantStage"];
                f_row["Project Number"] = kRow["ProjectNumber"];

                dt_dgv_KristalList.Rows.Add(f_row);
            }

            dgv_KristalList.DataSource = dt_dgv_KristalList;
            dgv_KristalList.Sort(dgv_KristalList.Columns["Kristal Ref"], ListSortDirection.Descending);

            dgv_KristalList.Columns["Kristal Ref"].Width = 50;
            dgv_KristalList.Columns["Kristal Name"].Width = 250;
            dgv_KristalList.Columns["Grant Stage"].Width = 75;
            dgv_KristalList.Columns["Project Number"].Width = 70;

            dgv_KristalList.DoubleBuffered(true);

            lbl_recordCount.Text = dt_dgv_KristalList.Rows.Count.ToString() + " records";
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

            tb_KristalRef.TabIndex = ++x;
            cb_GrantStage.TabIndex = ++x;
            tb_KristalName.TabIndex = ++x;

            btn_Refresh.TabIndex = ++x;
            btn_ClearSearch.TabIndex = ++x;
            btn_NewGrant.TabIndex = ++x;

        }

        private void searchItemAddedKristalAll(object sender, EventArgs e)
        {
            if (textChanged == true)
                fillDataGridView();
        }

        private void clearSearch(object sender, EventArgs e)
        {
            tb_KristalRef.Clear();
            tb_KristalName.Clear();
            cb_GrantStage.ResetText();
            cb_GrantStage.SelectedIndex = -1;

            fillDataGridView();
        }

        private void refreshPage(object sender, EventArgs e)
        {
            fillKristalDataSet();
            setControlDataSource();
            fillDataGridView();
        }

        private void open_frm_KristalAdd(object sender, EventArgs e)
        {
            using (frm_KristalAdd kristalAdd = new frm_KristalAdd())
            {
                kristalAdd.ShowDialog();
                int KristalRef = kristalAdd.newKristalRef;

                if (KristalRef > 0)
                {
                    refreshPage(kristalAdd, e);
                }
            }
        }

        private void dgv_KristalList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    Kristal kristal = new Kristal();
                    mdl_Kristal mdl_Kristal = new mdl_Kristal();

                    mdl_Kristal = kristal.fetchCurrentKristal(Convert.ToInt32(dgv_KristalList.Rows[r].Cells["Kristal Ref"].Value));

                    DataTable tlkGrantStage = ds_Kristal.Tables["tlkGrantStage"];

                    using (frm_Kristal Kristal = new frm_Kristal(mdl_Kristal, tlkGrantStage))
                    {
                        Kristal.ShowDialog();
                        fillKristalDataSet();
                        setControlDataSource();
                        fillDataGridView();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to see Kristal details." + Environment.NewLine + ex.Message);
                }
            }
        }
    }
}
