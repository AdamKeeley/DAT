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
    public partial class frm_ProjectPlatformInfoAdd : Form
    {
        public frm_ProjectPlatformInfoAdd(string pNumber, DataSet ds_prj)
        {
            InitializeComponent();
            setTabIndex();
            setProjectPlatformInfoAdd(pNumber, ds_prj);
        }

        string projectNumber;

        private void setProjectPlatformInfoAdd(string pNumber, DataSet ds_prj)
        {
            try
            {
                //set variables
                projectNumber = pNumber;

                //set controls values
                DataView PlatformItems = new DataView(ds_prj.Tables["tlkPlatformInfo"]);
                PlatformItems.RowFilter = "[ValidTo] is null";
                cb_PlatformItem.DataSource = PlatformItems;
                cb_PlatformItem.ValueMember = "PlatformInfoID";
                cb_PlatformItem.DisplayMember = "PlatformInfoDescription";
                cb_PlatformItem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setProjectPlatformInfoAdd of class frm_ProjectPlatformInfoAdd has failed" + Environment.NewLine + ex.Message);
            }
        }

        private bool addProjectPlatformInfo()
        {
            int PlatformInfoID = (int)cb_PlatformItem.SelectedValue;
            string PlatformInfoDescription = tb_PlatformItemDescription.Text;

            Project Projects = new Project();
            if (PlatformInfoDescription.Length > 0)
            {
                if (Projects.insertProjectPlatformInfo(projectNumber, PlatformInfoID, PlatformInfoDescription) == true)
                {
                    MessageBox.Show("Item added");
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a Project Platform Info Description.");
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

            cb_PlatformItem.TabIndex = ++x;
            tb_PlatformItemDescription.TabIndex = ++x;
            btn_ProjectPlatformInfoAdd_Add.TabIndex = ++x;
            btn_ProjectPlatformInfo_Cancel.TabIndex = ++x;
        }

        private void btn_ProjectPlatformInfoAdd_Add_Click(object sender, EventArgs e)
        {
            if (addProjectPlatformInfo() == true)
                this.Close();
        }

        private void btn_ProjectPlatformInfo_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
