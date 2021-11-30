using System;
using System.Data;
using System.Windows.Forms;
using CMS.RIDM;
using DataControlsLib.DataModels;

namespace CMS
{
    public partial class frm_Kristal : Form
    {
        public frm_Kristal(mdl_Kristal mdl_Kristal, DataTable tlkGrantStage)
        {
            InitializeComponent();
            setTabIndex();
            setKristal(mdl_Kristal, tlkGrantStage);
        }

        mdl_Kristal current_Kristal;

        public void setKristal(mdl_Kristal mdl_Kristal, DataTable tlkGrantStage)
        {
            try
            {
                current_Kristal = mdl_Kristal;

                lbl_KristalRefValue.Text = (string)current_Kristal.KristalRef.ToString();

                DataView GrantStages = new DataView(tlkGrantStage);
                GrantStages.RowFilter = "[ValidTo] is null";
                cb_GrantStage.DataSource = GrantStages;
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                cb_GrantStage.SelectedValue = current_Kristal.GrantStageID;

                tb_KristalName.Text = current_Kristal.KristalName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setKristalEdit of class frm_ProjectKristalEdit has failed" + Environment.NewLine + ex.Message);
            }
        }

        public void setKristalDGV()
        {

        }

        public bool updateKristal(int KristalRef, int currentGrantStageID)
        {
            int newGrantStageID = 0;
            try
            {
                newGrantStageID = (int)cb_GrantStage.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a valid Application Stage");
            }

            //if app stage changed 
            if (newGrantStageID > 0 & newGrantStageID != currentGrantStageID)
            {
                Kristal kristal = new Kristal();
                //logically delete current record from dbo.tblKristal
                if (kristal.deleteKristal(current_Kristal.KristalID))
                {
                    //insert new record to dbo.tblKristal
                    kristal.insertKristal(KristalRef, newGrantStageID);
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

            if (updateKristal(current_Kristal.KristalRef, current_Kristal.GrantStageID))
                this.Close();
        }

        private void btn_Kristal_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
