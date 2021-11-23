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
    public partial class frm_ProjectKristalEdit : Form
    {
        public frm_ProjectKristalEdit(int KristalID, int KristalRef, int GrantStage, DataTable tlkGrantStage)
        {
            InitializeComponent();
            setTabIndex();
            setKristalEdit(KristalID, KristalRef, GrantStage, tlkGrantStage);
        }

        int currentKristalID;
        int currentKristalRef;
        int currentGrantStageID;

        public void setKristalEdit(int KristalID, int KristalRef, int GrantStageID, DataTable tlkGrantStage)
        {
            currentKristalID = KristalID;
            currentKristalRef = KristalRef;
            currentGrantStageID = GrantStageID;

            try
            {
                lbl_KristalRefValue.Text = (string)KristalRef.ToString();

                //set controls values
                DataView GrantStages = new DataView(tlkGrantStage);
                GrantStages.RowFilter = "[ValidTo] is null";
                cb_GrantStage.DataSource = GrantStages;
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                cb_GrantStage.SelectedValue = GrantStageID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setKristalEdit of class frm_ProjectKristalEdit has failed" + Environment.NewLine + ex.Message);
            }
        }

        public bool updateKristalStage(int KristalRef, int currentGrantStageID)
        {
            int newGrantStageID = (int)cb_GrantStage.SelectedValue;
            //if app stage changed 
            if (newGrantStageID != currentGrantStageID)
            {
                Project project = new Project();
                //logically delete current record from dbo.tblKristal
                if (project.deleteKristal(currentKristalID))
                {
                    //insert new record to dbo.tblKristal
                    project.insertKristal(KristalRef, newGrantStageID);
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

            lbl_KristalRef.TabIndex = ++x;
            lbl_KristalRefValue.TabIndex = ++x;
            lbl_AppStage.TabIndex = ++x;
            cb_GrantStage.TabIndex = ++x;
            btn_KristalEdit_OK.TabIndex = ++x;
            btn_KristalEdit_Cancel.TabIndex = ++x;
        }

        private void btn_KristalEdit_OK_Click(object sender, EventArgs e)
        {

            if (updateKristalStage(currentKristalRef, currentGrantStageID))
                this.Close();
        }

        private void btn_KristalEdit_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
