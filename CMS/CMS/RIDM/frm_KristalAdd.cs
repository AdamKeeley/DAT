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
        public frm_ProjectKristalAdd()
        {
            InitializeComponent();
            setTabIndex();
            fillKristalDataSet();
            setProjectKristalAdd();
        }

        public DataSet ds_kristal;
        public int newKristalRef;

        private void fillKristalDataSet()
        {
            Kristal kristal = new Kristal();
            ds_kristal = kristal.getKristalDataSet();
        }

        private void setProjectKristalAdd()
        {
            try
            {
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

        private bool addKristal()
        {
            if (cb_GrantStage.SelectedIndex > -1)
            {
                mdl_Kristal newKristal = new mdl_Kristal();
                newKristal.GrantStageID = (int)cb_GrantStage.SelectedValue;
                newKristal.KristalName = tb_KristalName.Text;

                int testRef;

                if (int.TryParse(tb_KristalRef.Text, out testRef))
                {
                    newKristal.KristalRef = testRef;
                    
                    if (newKristal.KristalRef > 0)
                    { Kristal kristal = new Kristal();
                        if (kristal.insertKristal(newKristal) == true)
                        {
                            MessageBox.Show("Item added");
                            newKristalRef = newKristal.KristalRef;
                            return true;
                        }
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

            tb_KristalRef.TabIndex = ++x;
            cb_GrantStage.TabIndex = ++x;
            btn_ProjectKristalAdd_Add.TabIndex = ++x;
            btn_ProjectKristalAdd_Cancel.TabIndex = ++x;
        }

        private void btn_KristalAdd_Add_Click(object sender, EventArgs e)
        {
            if (addKristal() == true)
                this.Close();
        }

        private void btn_ProjectKristalAdd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
