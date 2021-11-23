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
        public frm_ProjectKristalEdit(int KristalRef, int GrantStage, DataTable tlkGrantStage)
        {
            InitializeComponent();
            setTabIndex();
            setKristalEdit(KristalRef, GrantStage, tlkGrantStage);
        }

        public void setKristalEdit(int KristalRef, int GrantStage, DataTable tlkGrantStage)
        {
            try
            {
                lbl_KristalRefValue.Text = (string)KristalRef.ToString();

                //set controls values
                DataView GrantStages = new DataView(tlkGrantStage);
                GrantStages.RowFilter = "[ValidTo] is null";
                cb_GrantStage.DataSource = GrantStages;
                cb_GrantStage.ValueMember = "GrantStageID";
                cb_GrantStage.DisplayMember = "GrantStageDescription";
                //cb_GrantStage.SelectedIndex = -1;
                cb_GrantStage.SelectedValue = GrantStage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Method setKristalEdit of class frm_ProjectKristalEdit has failed" + Environment.NewLine + ex.Message);
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

            lbl_KristalRef.TabIndex = ++x;
            lbl_KristalRefValue.TabIndex = ++x;
            lbl_AppStage.TabIndex = ++x;
            cb_GrantStage.TabIndex = ++x;
            btn_KristalEdit_OK.TabIndex = ++x;
            btn_KristalEdit_Cancel.TabIndex = ++x;
        }
    }
}
