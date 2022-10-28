using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.RIDM
{
    public partial class frm_KristalProjectAdd : Form
    {
        public frm_KristalProjectAdd(int KristalNumber)
        {
            InitializeComponent();
            setTabIndex();
            setVariablesAndControl(KristalNumber);
        }

        int kristalNumber;
        DataSet ds_prj;

        private void setVariablesAndControl(int KristalNumber)
        {
            try
            {
                //set variables
                Project project = new Project();
                ds_prj = project.getProjectsDataSet();

                kristalNumber = KristalNumber;

                //set controls values
                cb_pNumberValue.DataSource = ds_prj.Tables["tblProjects"];
                cb_pNumberValue.ValueMember = "pID";
                cb_pNumberValue.DisplayMember = "ProjectNumber";
                cb_pNumberValue.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setVariablesAndControl of class frm_KristalProjectAdd has failed" + Environment.NewLine + ex);
                throw;
            }
        }

        private void setProjectName()
        {
            string ProjectNumber = cb_pNumberValue.Text;
            foreach (DataRow r in ds_prj.Tables["tblProjects"].Select($"ProjectNumber = '{ProjectNumber}'"))
            {
                tb_pNameValue.Text = r["ProjectName"].ToString();
            }
        }

        private bool addKristalProject()
        {
            string ProjectNumber = cb_pNumberValue.Text;

            Kristal kristal = new Kristal();
            return kristal.insertProjectKristal(ProjectNumber, kristalNumber);
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

            cb_pNumberValue.TabIndex = ++x;
            btn_UserProjectAdd_Add.TabIndex = ++x;
            btn_UserProjectAdd_Cancel.TabIndex = ++x;
        }

        private void cb_pNumberValue_SelectionChanged(object sender, EventArgs e)
        {
            setProjectName();
        }

        private void btn_UserProjectAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UserProjectAdd_Add_Click(object sender, EventArgs e)
        {
            if (addKristalProject() == true)
                this.Close();
        }
    }
}
