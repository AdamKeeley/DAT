using CMS.RIDM;
using DataControlsLib.DataModels;
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
        public frm_ProjectKristalAdd(string pNumber)
        {
            InitializeComponent();
            setTabIndex();
            fillKristalDataSet();
            setProjectKristalAdd(pNumber);
        }

        DataSet ds_kristal;
        string projectNumber;

        private void fillKristalDataSet()
        {
            Kristal kristal = new Kristal();
            ds_kristal = kristal.getKristalDataSet();
        }

        private void setProjectKristalAdd(string pNumber)
        {
            try
            {
                projectNumber = pNumber;

                //set controls values
                DataView GrantStages = new DataView(ds_kristal.Tables["tlkGrantStage"]);
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
            btn_ProjectKristalAdd_Add.TabIndex = ++x;
            btn_ProjectKristalAdd_Cancel.TabIndex = ++x;
        }


        private bool addProjectKristal()
        {
            if (cb_GrantStage.SelectedIndex > -1)
            {
                mdl_Kristal newKristal = new mdl_Kristal();
                newKristal.GrantStageID = (int)cb_GrantStage.SelectedValue;
                newKristal.KristalName = tb_KristalName.Text;

                int testRef;

                // if KristalRef is an integer
                if (int.TryParse(tb_KristalRef.Text, out testRef))
                {
                    newKristal.KristalRef = testRef;

                    if (newKristal.KristalRef > 0)
                    {
                        Kristal kristal = new Kristal();
                        kristal.insertProjectKristalReference(projectNumber, newKristal);
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

        private void prepopulateControlsIfRefExists(object sender, EventArgs e)
        {
            int testRef;

            // if KristalRef is an integer
            if (int.TryParse(tb_KristalRef.Text, out testRef))
            {
                if (ds_kristal.Tables["tblKristal"].Select($"KristalRef = {testRef}").Length > 0)
                {
                    foreach (DataRow kRow in ds_kristal.Tables["tblKristal"].Select($"KristalRef = {testRef}"))
                    {
                        cb_GrantStage.SelectedValue = kRow["GrantStageID"];
                        tb_KristalName.Text = kRow["KristalName"].ToString();
                    }
                }
            }
        }

        private void btn_ProjectKristalAdd_Add_Click(object sender, EventArgs e)
        {
            if (addProjectKristal() == true)
                this.Close();
        }

        private void btn_ProjectProjectKristalAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
