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
    public partial class frm_FileListAdd : Form
    {
        // Constructor takes parent frm_DataTransferAdd making its public members available here
        private frm_FileTransfersAdd ftFrm = null;
        public frm_FileListAdd(Form parentForm)
        {
            ftFrm = parentForm as frm_FileTransfersAdd;
            InitializeComponent();
        }

        private void btn_AddToTransfer_Click(object sender, EventArgs e)
        {
            if (tb_FilesList.Text.NullIfEmpty() == null)
            {
                MessageBox.Show("Enter list of files to add to transfer record.\n", "No files added", MessageBoxButtons.OK);
                return;
            }

            // Convert multi-line textbox input into List<string>
            List<string> flInput = new List<string>(
                tb_FilesList.Text.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));

            // Add row(s) to fileslist DGV in parent form for every file/row in the list box
            this.ftFrm.FilesList.DataSource = flInput.Select(f => new { FileName = f }).ToList();
            this.ftFrm.FilesList.Columns["FileName"].Width = 356;
            this.ftFrm.FilesList.RowHeadersWidth = 10;
            // Update text box on parent form showing the number of files included
            this.ftFrm.NumFiles = String.Format("{0} files", flInput.Count);

            this.Close();
        }
    }
}
