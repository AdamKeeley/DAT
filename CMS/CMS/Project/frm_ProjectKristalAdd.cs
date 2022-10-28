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
        public int newKristalNumber;

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

                cb_PI.DataSource = ds_kristal.Tables["tblUser"];
                cb_PI.ValueMember = "UserNumber";
                cb_PI.DisplayMember = "FullName";
                cb_PI.SelectedIndex = -1;

                cb_Location.DataSource = ds_kristal.Tables["tlkLocation"];
                cb_Location.ValueMember = "locationID";
                cb_Location.DisplayMember = "locationDescription";
                cb_Location.SelectedIndex = -1;

                cb_Faculty.DataSource = ds_kristal.Tables["tlkFaculty"];
                cb_Faculty.ValueMember = "facultyID";
                cb_Faculty.DisplayMember = "facultyDescription";
                cb_Faculty.SelectedIndex = -1;
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
                newKristal.PI = (int?)cb_PI.SelectedValue;
                newKristal.Location = (int?)cb_Location.SelectedValue;
                newKristal.Faculty = (int?)cb_Faculty.SelectedValue;

                int testRef;

                // if KristalRef is an integer
                if (int.TryParse(tb_KristalRef.Text, out testRef))
                {
                    newKristal.KristalRef = testRef;

                    if (newKristal.KristalRef > 0)
                    {
                        Kristal kristal = new Kristal();
                        
                        // fetch existing KristalNumber (from already prepopulated values) or assign new
                        if (newKristalNumber > 0)
                        {
                            newKristal.KristalNumber = newKristalNumber;
                        }
                        else
                        {
                            newKristal.KristalNumber = kristal.getLastKristalNumber() + 1;
                        }

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

            // Don't search for or prepopulate 'unknown' Kristal Refs (999999)
            if (tb_KristalRef.Text != "999999")
            {
                // if KristalRef is an integer
                if (int.TryParse(tb_KristalRef.Text, out testRef))
                {
                    if (ds_kristal.Tables["tblKristal"].Select($"KristalRef = {testRef}").Length > 0)
                    {
                        foreach (DataRow kRow in ds_kristal.Tables["tblKristal"].Select($"KristalRef = {testRef}"))
                        {
                            cb_GrantStage.SelectedValue = kRow["GrantStageID"];
                            tb_KristalName.Text = kRow["KristalName"].ToString();
                            newKristalNumber = Convert.ToInt32(kRow["KristalNumber"].ToString());
                            cb_PI.SelectedValue = kRow["PI"];
                            cb_Location.SelectedValue = kRow["Location"];
                            cb_Faculty.SelectedValue = kRow["Faculty"];
                        }
                    }
                    else
                    {
                        cb_GrantStage.SelectedValue = -1;
                        tb_KristalName.Clear();
                        cb_PI.SelectedValue = -1;
                        cb_Location.SelectedValue = -1;
                        cb_Faculty.SelectedValue = -1;
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
