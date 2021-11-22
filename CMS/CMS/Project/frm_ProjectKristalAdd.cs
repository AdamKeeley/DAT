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
    public partial class frm_ProjectKristalAdd : Form
    {
        public frm_ProjectKristalAdd(string ProjectNumber, DataSet ds_Project)
        {
            InitializeComponent();
            setTabIndex();
            setProjectPlatformInfoAdd(ProjectNumber, ds_Project);
        }

        string projectNumber;

        private void setProjectPlatformInfoAdd(string pNumber, DataSet ds_prj)
        {
            try
            {
                //set variables
                projectNumber = pNumber;

                //set controls values
                DataView GrantStages = new DataView(ds_prj.Tables["tlkGrantStage"]);
                GrantStages.RowFilter = "[ValidTo] is null";
                cb_GrantStage.DataSource = GrantStages;
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                cb_GrantStage.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectPlatformInfoAdd of class frm_ProjectPlatformInfoAdd has failed" + Environment.NewLine + ex.Message);
            }
        }

        private bool addProjectKristal()
        {
            if (cb_GrantStage.SelectedIndex > -1)
            {
                int GrantStageID = (int)cb_GrantStage.SelectedValue;
                int KristalRef = int.Parse(tb_KristalRef.Text);

                Project Projects = new Project();
                if (KristalRef > 0)
                {
                    if (Projects.insertProjectKristalReference(projectNumber, GrantStageID, KristalRef) == true)
                    {
                        MessageBox.Show("Item added");
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a Kristal Reference.");
                }
            }
            else
            {
                MessageBox.Show("Please select an application stage.");
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

            lbl_KristalRef.TabIndex = ++x;
            lbl_AppStage.TabIndex = ++x;
            tb_KristalRef.TabIndex = ++x;
            cb_GrantStage.TabIndex = ++x;
            btn_ProjectKristalAdd_Add.TabIndex = ++x;
            btn_ProjectKristalAdd_Cancel.TabIndex = ++x;
        }

        private void btn_ProjectKristalAdd_Add_Click(object sender, EventArgs e)
        {
            if (addProjectKristal() == true)
                this.Close();
        }

        private void btn_ProjectKristalAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
