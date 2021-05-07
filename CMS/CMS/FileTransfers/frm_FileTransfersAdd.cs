using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ookii.Dialogs.WinForms;
using DataControlsLib;
using DataControlsLib.DataModels;
using DataControlsLib.ViewModels;
using CMS.DSAs;

namespace CMS.FileTransfers
{
    public partial class frm_FileTransfersAdd : Form
    {
        public frm_FileTransfersAdd()
        {
            InitializeComponent();
            setTabIndex();
            PopulateIODataset();
            SetControls();
        }

        private FileTransfer io = new FileTransfer();
        private DataSet ds;

        // Expose certain controls as public properties to enable communication between forms
        public DataGridView FilesList
        {
            get { return dgv_FilesList; }
            set { dgv_FilesList.DataSource = value; }
        }
        public string SelectedPrj
        {
            get { return cb_Project.SelectedItem.ToString().NullIfEmpty(); }
            // No set - read only
        }
        public DataTable AssetsTbl
        {
            get { return ds.Tables["tblAssetGroups"]; }
            // No set - read only
        }
        public DataGridView AssetsList
        {
            get { return dgv_Assets; }
            set { dgv_Assets = value; }
        }
        public DataGridView RejectionsList
        {
            get { return dgv_Rejections; }
            set { dgv_Rejections = value; }
        }

        public bool insertSuccessful = false;

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

            cb_Project.TabIndex = ++x;
            cb_VRE.TabIndex = ++x;
            cb_RequestType.TabIndex = ++x;
            cb_RequestedBy.TabIndex = ++x;
            lbl_NewUser.TabIndex = ++x;
            tb_RequestNotes.TabIndex = ++x;

            cb_ReviewedBy.TabIndex = ++x;
            dtp_ReviewDate.TabIndex = ++x;
            tb_ReviewNotes.TabIndex = ++x;
            cb_DsaReviewed.TabIndex = ++x;
            lbl_NewDSA.TabIndex = ++x;
            chkb_OldDSAs.TabIndex = ++x;

            tb_TransferFrom.TabIndex = ++x;
            cb_TransferMethod.TabIndex = ++x;
            tb_TransferTo.TabIndex = ++x;
            tb_VreDir.TabIndex = ++x;
            tb_RepoDir.TabIndex = ++x;

            btn_AddFiles.TabIndex = ++x;
            btn_AddAsset.TabIndex = ++x;
            btn_Rejections.TabIndex = ++x;
        }

        public void PopulateIODataset()
        {
            try
            {
                ds = io.GetAssetsHistoryDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get assets history data from the database." + Environment.NewLine +
                                ex.Message + Environment.NewLine +
                                Environment.NewLine +
                                ex.StackTrace);
            }
        }

        public void SetControls()
        {
            // Fill project dropdown
            List<string> projNumbers = ds.Tables["tblProject"].AsEnumerable()
                .OrderBy(p => p.Field<string>("ProjectNumber"))
                .Select(p => p.Field<string>("ProjectNumber"))
                .ToList();
            projNumbers.Insert(0, "");
            cb_Project.DataSource = projNumbers;

            // Fill VRE number dropdown
            FillVreNumberControl();

            // Fill request type dropdown
            cb_RequestType.DataSource = ds.Tables["tlkTransferRequestTypes"].AsEnumerable()
                .Select(rt => rt.Field<string>("RequestTypeLabel")).ToList();

            // Control use of TranserFrom and TransferTo based on request type
            SetTransferControls();

            // Fill requested by dropdown
            FillRequestedByControl();

            // Fill reviewed by dropdown. Get Users where ValidTo=null & Status=1 & Priviledged=1
            cb_ReviewedBy.DataSource = ds.Tables["tblUser"].AsEnumerable()
                .Where(u => u.Field<DateTime?>("ValidTo") == null && u.Field<int?>("Status") == 1 && u.Field<bool>("Priviledged"))
                .OrderBy(u => u.Field<string>("LastName"))
                .Select(u => u.Field<string>("LastName") + ", " + u.Field<string>("FirstName"))
                .ToList();
            cb_ReviewedBy.SelectedIndex = -1;

            // Set default reviewed date to be today
            dtp_ReviewDate.Value = DateTime.Now.Date;

            // Fill DSA reviewed dropdown
            chkb_OldDSAs.Checked = true;
            FillDsaReviewedControl();

            // Fill transfer method dropdown
            cb_TransferMethod.DataSource = ds.Tables["tlkFileTransferMethods"].AsEnumerable()
                .Select(rt => rt.Field<string>("MethodLabel")).ToList();

            // Add columns to the assets list DGV
            dgv_Assets.ColumnCount = 2;
            dgv_Assets.Columns[0].Name = "AssetName";
            dgv_Assets.Columns[1].Name = "FileName";
            dgv_Assets.Columns["AssetName"].Width = 200;
            dgv_Assets.Columns["FileName"].Width = 200;
            dgv_Assets.RowHeadersWidth = 10;

            // Add columns to the assets list DGV
            dgv_Rejections.ColumnCount = 2;
            dgv_Rejections.Columns[0].Name = "RejectionReason";
            dgv_Rejections.Columns[1].Name = "FileName";
            dgv_Rejections.Columns["RejectionReason"].Width = 200;
            dgv_Rejections.Columns["FileName"].Width = 200;
            dgv_Rejections.RowHeadersWidth = 10;
        }

        private void SetTransferControls()
        {
            if (cb_RequestType.Text == "")
            {
                tb_TransferFrom.Enabled = false;
                tb_TransferTo.Enabled = false;
            } 
            else if (cb_RequestType.Text == "Import")
            {
                tb_TransferFrom.Enabled = true;
                tb_TransferTo.Enabled = false;
            }
            else if (cb_RequestType.Text == "Export")
            {
                tb_TransferFrom.Enabled = false;
                tb_TransferTo.Enabled = true;
            }
        }

        private void FillVreNumberControl()
        {
            List<string> vres = io.GetVreNumbers(ds, cb_Project.Text.NullIfEmpty());
            cb_VRE.DataSource = vres;
            // If selected project has only one VRE, autocomplete the VRE selection
            if (vres.Count == 1)
            {
                cb_VRE.SelectedIndex = 0;
            }
            else
            {
                cb_VRE.SelectedIndex = -1;
            }
        }

        private void FillRequestedByControl()
        {
            cb_RequestedBy.DataSource = io.GetRequesters(ds, prj: cb_Project.Text.NullIfEmpty());
            cb_RequestedBy.ValueMember = "UserNumber";
            cb_RequestedBy.DisplayMember = "FullName";
            cb_RequestedBy.SelectedIndex = -1;
        }

        private void FillDsaReviewedControl()
        {
            cb_DsaReviewed.DataSource = io.GetDsas(ds, cb_Project.Text.NullIfEmpty(), chkb_OldDSAs.Checked);
            cb_DsaReviewed.ValueMember = "DocumentID";
            cb_DsaReviewed.DisplayMember = "DsaName";
            cb_DsaReviewed.SelectedIndex = -1;
        }

        private void cb_Project_SelectedValueChanged(object sender, EventArgs e)
        {
            FillVreNumberControl();
            FillRequestedByControl();
            FillDsaReviewedControl();
        }

        private void cb_RequestType_SelectedValueChanged(object sender, EventArgs e)
        {
            SetTransferControls();
        }

        private void chkb_OldDSAs_CheckedChanged(object sender, EventArgs e)
        {
            FillDsaReviewedControl();
        }

        private void lbl_NewUser_Click(object sender, EventArgs e)
        {
            using (frm_UserAdd UserAdd = new frm_UserAdd())
            {
                UserAdd.ShowDialog();
                if (UserAdd.userAdded == true)
                {
                    // Query DB again for updated users list
                    io.RefreshUsersData(ds);
                    // Refresh Requested By dropdown to include new user
                    FillRequestedByControl();
                }
            }
        }

        private void lbl_NewDSA_Click(object sender, EventArgs e)
        {
            using (frm_DsaAdd DsaAdd = new frm_DsaAdd())
            {
                DsaAdd.ShowDialog();
                if (DsaAdd.insertSuccessful == true)
                {
                    // Query DB again for updated DSAs list
                    io.RefreshDsasData(ds);
                    // Refresh DSA Reviewed dropdown to include new DSA
                    FillDsaReviewedControl();
                }
            }
        }

        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            // Open Folder Browser Dialog Control to get filenames within a chosen folder
            IEnumerable<string> files;
            VistaFolderBrowserDialog dirBrwsr = new VistaFolderBrowserDialog
            {
                //Description = "Select a folder containing the file(s) you want to transfer.",
                ShowNewFolderButton = true
            };

            DialogResult res = dirBrwsr.ShowDialog();
            if (res == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(dirBrwsr.SelectedPath))
                    {
                        // Recursively find all files within chosen dir, then convert to relative paths
                        files = Directory.EnumerateFiles(dirBrwsr.SelectedPath, "*", SearchOption.AllDirectories);
                        files = files.Select(f => f.Replace(dirBrwsr.SelectedPath + "\\", ""));
                        // Put relative file paths in data grid view with column FileName
                        dgv_FilesList.DataSource = files.Select(f => new { FileName = f }).ToList();
                        dgv_FilesList.Columns["FileName"].Width = 356;
                        dgv_FilesList.RowHeadersWidth = 10;

                        lbl_NumFiles.Text = String.Format("{0} files", files.ToList().Count);
                    }
                    else
                    {
                        dgv_FilesList.DataSource =  null;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: Folder could not be read. Probably does not exist or is not accessible." + 
                                    Environment.NewLine + ex.Message + Environment.NewLine +
                                    Environment.NewLine + ex.StackTrace);
                }
            }
        }

        private void btn_AddAsset_Click(object sender, EventArgs e)
        {
            frm_AssetGroupAdd newAsset = new frm_AssetGroupAdd(this);
            newAsset.Show();
        }

        private void btn_Rejections_Click(object sender, EventArgs e)
        {
            frm_FileRejectionsAdd newReject = new frm_FileRejectionsAdd(this);
            newReject.Show();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            // Validate inputs against DB requirements
            bool inputsvalid = io.ValidateTransferInput(
                prj: SelectedPrj,
                vre: cb_VRE.Text,
                rt: cb_RequestType.Text,
                rq: cb_RequestedBy.Text,
                rv: cb_ReviewedBy.Text,
                dsa: cb_DsaReviewed.Text,
                tm: cb_TransferMethod.Text,
                fc: FilesList.RowCount
            );

            if (!inputsvalid)
            {
                return;
            }

            insertSuccessful = io.PutTransferRecords(
                ds: ds,
                prj: SelectedPrj,
                vre: cb_VRE.Text,
                rt: cb_RequestType.Text,
                rq: cb_RequestedBy.Text,
                rqn: tb_RequestNotes.Text.NullIfEmpty(),
                rv: cb_ReviewedBy.Text,
                rd: dtp_ReviewDate.Value.Date,
                rvn: tb_ReviewNotes.Text.NullIfEmpty(),
                assets: AssetsList,
                files: FilesList,
                vreDir: tb_VreDir.Text.NullIfEmpty(),
                repoDir: tb_RepoDir.Text.NullIfEmpty(),
                tm: cb_TransferMethod.Text,
                tf: tb_TransferFrom.Text.NullIfEmpty(),
                tt: tb_TransferTo.Text.NullIfEmpty(),
                dsa: cb_DsaReviewed.Text,
                rej: RejectionsList
            );

            if (insertSuccessful)
            {
                MessageBox.Show("Successfully added new file transfer record(s).\n", "File transfer(s) Added", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
