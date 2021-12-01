using System;
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
            //dgv_KristalProjects.Columns["User Number"].Visible = false;
            dgv_KristalProjects.Columns["Project Number"].Width = 50;
            dgv_KristalProjects.Columns["Project Name"].Width = 155;
            dgv_KristalProjects.Columns["PI"].Width = 155;
            dgv_KristalProjects.Columns["Lead Applicant"].Width = 155;
            dgv_KristalProjects.Columns["Faculty"].Width = 75;
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
                    return true;
                }
            }
            return false;
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
            btn_Kristal_OK.TabIndex = ++x;
            btn_Kristal_Cancel.TabIndex = ++x;
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
    }
}
