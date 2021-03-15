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
    public partial class frm_AssetGroupAdd : Form
    {
        // Constructor takes parent frm_DataTransferAdd making its public members available here
        private frm_FileTransfersAdd ftFrm = null;
        public frm_AssetGroupAdd(Form parentForm)
        {
            ftFrm = parentForm as frm_FileTransfersAdd;
            InitializeComponent();
            SetControls();
        }

        public void SetControls()
        {
            // Fill files listbox with contents of dgv_FilesList from parent form
            lbx_Files.DataSource = this.ftFrm.FilesList.Rows.OfType<DataGridViewRow>()
                .Select(r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value.ToString()))
                .SelectMany(x => x)
                .ToList();
            lbx_Files.SelectionMode = SelectionMode.MultiExtended;
            lbx_Files.SelectedIndex = -1;

            // Fill assets dropdown with existing assets for chosen project
            string prj = this.ftFrm.SelectedPrj;
            cb_AssetName.DataSource = this.ftFrm.AssetsTbl.AsEnumerable()
                .Where(a => prj == null || prj == a.Field<string>("Project"))
                .Select(a => a.Field<string>("AssetName"))
                .ToList();
            cb_AssetName.SelectedIndex = -1;
            cb_AssetName.MaxLength = 500;
        }

        private void btn_AddAsset_Click(object sender, EventArgs e)
        {
            if (cb_AssetName.Text.NullIfEmpty() == null)
            {
                MessageBox.Show("Enter an asset name to add a new asset group.\n", "Asset Name Missing", MessageBoxButtons.OK);
                return;
            }

            // Add row(s) to assets DGV in parent form for every file in new asset
            foreach (string fn in lbx_Files.SelectedItems.Cast<string>())
            {
                this.ftFrm.AssetsList.Rows.Add(new string[] { cb_AssetName.Text, fn });
            }

            this.Close();
        }
    }
}
