using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib;

namespace CMS.FileTransfers
{
    public partial class frm_FileRejectionsAdd : Form
    {
        private frm_FileTransfersAdd ftFrm = null;
        public frm_FileRejectionsAdd(Form parentForm)
        {
            ftFrm = parentForm as frm_FileTransfersAdd;
            InitializeComponent();
            FillFilesList();
        }

        // Fill files listbox with contents of dgv_FilesList from parent form
        public void FillFilesList()
        {
            lbx_Files.DataSource = this.ftFrm.FilesList.Rows.OfType<DataGridViewRow>()
                .Select(r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value.ToString()))
                .SelectMany(x => x)
                .ToList();
            lbx_Files.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btn_AddRejection_Click(object sender, EventArgs e)
        {
            if (tb_Reason.Text.NullIfEmpty() == null)
            {
                MessageBox.Show("Must include reason for rejection to reject file(s).", "Add Rejection Reason", MessageBoxButtons.OK);
                return;
            }

            // Add row(s) to rejections DGV in parent form for every file in new rejection list
            foreach (string fn in lbx_Files.SelectedItems.Cast<string>())
            {
                this.ftFrm.RejectionsList.Rows.Add(new string[] { tb_Reason.Text, fn });
            }

            this.Close();
        }
    }
}
