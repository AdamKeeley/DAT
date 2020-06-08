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
using DataControlsLib.DataModels;
using DataControlsLib.ViewModels;

namespace CMS.DSAs
{
    public partial class frm_DsaAdd : Form
    {
        public frm_DsaAdd()
        {
            InitializeComponent();
            PopulateDsaDataset();
            SetInitialControls();
        }

        private DataSet ds;
        DataTable dsaNotes = new DataTable();

        DsaModel dsasInsertData = new DsaModel();
        List<DsaNoteModel> dsaNotesInsertData = new List<DsaNoteModel>();
        List<DsasProjectsModel> dsasProjectsInsertData = new List<DsasProjectsModel>();


        public void PopulateDsaDataset()
        {
            try
            {
                DSA dsa = new DSA();
                ds = dsa.GetDsaData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get DSA data from the database." + Environment.NewLine +
                                ex.Message + Environment.NewLine +
                                Environment.NewLine +
                                ex.StackTrace);
            }
        }

        public void SetInitialControls()
        {
            dtp_StartDate.Value = DateTime.Now.Date;
            dtp_ExpiryDate.Value = DateTime.Now.Date;

            List<string> projNumbers = ds.Tables["tblProject"].AsEnumerable()
                .OrderBy(p => p.Field<string>("ProjectNumber"))
                .Select(p => p.Field<string>("ProjectNumber"))
                .ToList();
            projNumbers.Insert(0, "");
            lbx_ProjectsList.DataSource = projNumbers;

            chkb_IsAmendment.Checked = false;
            dgv_AmendmentOf.DataSource = null;
            dgv_AmendmentOf.Enabled = false;

            FillDataOwnersList();

            dsaNotes.Columns.Add("Notes", typeof(string));
            dgv_AddNote.DataSource = dsaNotes;
            dgv_AddNote.Columns["Notes"].Width = 375;
        }

        private void FillDataOwnersList()
        {
            List<int> rebrands = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => t.Field<int?>("RebrandOf") != null)
                .Select(t => new List<int> { t.Field<int?>("RebrandOf").GetValueOrDefault() })
                .Distinct().SelectMany(x => x).ToList();
            List<string> dataOwners = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => !rebrands.Contains(t.Field<int>("doID")))
                .OrderBy(p => p.Field<string>("DataOwnerName"))
                .Select(p => p.Field<string>("DataOwnerName"))
                .ToList();
            dataOwners.Insert(0, "");
            cb_ExistingDataOwner.DataSource = dataOwners;
        }

        private void chkb_IsAmendment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_IsAmendment.Checked)
            {
                dgv_AmendmentOf.Enabled = true;

                // Create view of DSAs. Needs DSA table to left outer join with itself to get name of previous DSA versions.
                IEnumerable<DsaBasicsViewModel> dsaQuery =
                    from dsa in ds.Tables["tblDsas"].AsEnumerable()
                    join own in ds.Tables["tblDsaDataOwners"].AsEnumerable() on dsa.Field<int>("DataOwner") equals own.Field<int>("doID")
                    join dsa2 in ds.Tables["tblDsas"].AsEnumerable() on dsa.Field<int?>("AmendmentOf") equals dsa2.Field<int>("DsaID") into dsa2tmp
                    from dsa2 in dsa2tmp.DefaultIfEmpty()
                    select new DsaBasicsViewModel
                    {
                        DsaID = dsa.Field<int>("DsaID"),
                        DataOwner = own.Field<string>("DataOwnerName"),
                        StartDate = dsa.Field<DateTime?>("StartDate"),
                        ExpiryDate = dsa.Field<DateTime?>("ExpiryDate"),
                        DsaName = dsa.Field<string>("DsaName"),
                        FilePath = dsa.Field<string>("DsaFileLoc"),
                        AmendmentOf = dsa2?.Field<string>("DsaName"),
                        DSPT = dsa.Field<bool>("DSPT"),
                        ISO27001 = dsa.Field<bool>("ISO27001"),
                        RequiresEncryption = dsa.Field<bool>("RequiresEncryption"),
                        NoRemoteAccess = dsa.Field<bool>("NoRemoteAccess")
                    };
                dgv_AmendmentOf.DataSource = dsaQuery.ToList();

                dgv_AmendmentOf.Columns["DsaID"].Width = 50;
                dgv_AmendmentOf.Columns["DataOwner"].Width = 120;
                dgv_AmendmentOf.Columns["StartDate"].Width = 85;
                dgv_AmendmentOf.Columns["ExpiryDate"].Width = 85;
                dgv_AmendmentOf.Columns["DsaName"].Width = 140;
                dgv_AmendmentOf.Columns["AmendmentOf"].Width = 140;
                dgv_AmendmentOf.Columns["DSPT"].Width = 75;
                dgv_AmendmentOf.Columns["ISO27001"].Width = 75;
                dgv_AmendmentOf.Columns["RequiresEncryption"].Width = 140;
                dgv_AmendmentOf.Columns["NoRemoteAccess"].Width = 125;
            }
            else
            {
                dgv_AmendmentOf.DataSource = null;
                dgv_AmendmentOf.Enabled = false;
            }
        }

        private void btn_AddNote_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_AddNote.Text))
            {
                dsaNotes.Rows.Add(tb_AddNote.Text);
            }
            tb_AddNote.Text = null;
        }

        private void btn_NewDataOwner_Click(object sender, EventArgs e)
        {
            frm_DsaDataOwnerAdd DataOwnerAdd = new frm_DsaDataOwnerAdd();
            DataOwnerAdd.FormClosing += new FormClosingEventHandler(this.UpdateDataOwnerControls);
            DataOwnerAdd.Show();
        }

        private void UpdateDataOwnerControls(object sender, EventArgs e)
        {
            PopulateDsaDataset();
            FillDataOwnersList();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool hasRequiredInputs = ValidateDsaInputs();

            if (!hasRequiredInputs)
            {
                return;
            }

            if (ConfirmationMsg() == DialogResult.Cancel)
            {
                return;
            }

            CollectDsaInputs();

            DSA dsa = new DSA();
            bool insertSuccessful = dsa.PutDsaData(dsasInsertData, dsaNotesInsertData, dsasProjectsInsertData);

            if (insertSuccessful)
            {
                MessageBox.Show("Successfully added new DSA record.\n", "DSA Added", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private bool ValidateDsaInputs()
        {
            if (String.IsNullOrWhiteSpace(tb_FileName.Text))
            {
                MessageBox.Show(
                    text: "You haven't given a File Name for the DSA, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            if (String.IsNullOrWhiteSpace(tb_FilePath.Text))
            {
                MessageBox.Show(
                    text: "You haven't specified the File Path where the DSA file is stored, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            if (String.IsNullOrWhiteSpace(cb_ExistingDataOwner.SelectedItem.ToString()))
            {
                MessageBox.Show(
                    text: "You haven't specified a data owner, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            return true;
        }

        private void CollectDsaInputs()
        {
            int dataOwnerIndex = (
                    from own in ds.Tables["tblDsaDataOwners"].AsEnumerable()
                    where own.Field<string>("DataOwnerName") == cb_ExistingDataOwner.SelectedItem.ToString()
                    select own.Field<int>("doID")
                ).ToList().FirstOrDefault();

            int? amendmentOfID = null;
            if (chkb_IsAmendment.Checked)
            {
                amendmentOfID = (int?)dgv_AmendmentOf.SelectedRows[0].Cells["DsaID"].Value;
            }

            dsasInsertData.DataOwner = dataOwnerIndex;
            dsasInsertData.AmendmentOf = amendmentOfID;
            dsasInsertData.DsaName = tb_FileName.Text;
            dsasInsertData.DsaFileLoc = tb_FilePath.Text;
            dsasInsertData.StartDate = dtp_StartDate.Checked ? dtp_StartDate?.Value.Date : null;
            dsasInsertData.ExpiryDate = dtp_ExpiryDate.Checked ? dtp_ExpiryDate?.Value.Date : null;
            dsasInsertData.DSPT = chkb_DSPT.Checked;
            dsasInsertData.ISO27001 = chkb_ISO27001.Checked;
            dsasInsertData.RequiresEncryption = chkb_Encryption.Checked;
            dsasInsertData.NoRemoteAccess = chkb_NoRemoteAccess.Checked;
            dsasInsertData.DateAdded = DateTime.Now;
            dsasInsertData.LastUpdated = null;

            foreach(DataGridViewRow dr in dgv_AddNote.Rows)
            {
                dsaNotesInsertData.Add(new DsaNoteModel { 
                    Note = dr.Cells["Notes"].Value.ToString()
                });
            }

            dsasProjectsInsertData = lbx_ProjectsList.SelectedItems.Cast<string>()
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .Select(prj => new DsasProjectsModel { Project = prj }).ToList();
        }

        private DialogResult ConfirmationMsg()
        {
            string resp = "You are about to create a new DSA record with the following details:\n\n";

            resp += $"Data owner: {cb_ExistingDataOwner.SelectedItem}\n";
            resp += $"File name: {tb_FileName.Text}\n";
            resp += $"File path: {tb_FilePath.Text}\n";
            resp += $"Start date: { (dtp_StartDate.Checked ? dtp_StartDate?.Value.Date.ToString("yyyy-MM-dd") : "NOT SPECIFIED") }\n";
            resp += $"Expiry date: { (dtp_ExpiryDate.Checked ? dtp_ExpiryDate?.Value.Date.ToString("yyyy-MM-dd") : "NOT SPECIFIED") }\n";

            if (chkb_IsAmendment.Checked)
            {
                DataGridViewRow row = dgv_AmendmentOf.SelectedRows[0];
                resp += $"Amends \"{row.Cells["DsaName"].Value}\" agreement with {row.Cells["DataOwner"].Value}\n";
            }
            else
            {
                resp += "Is an original agreement.\n";
            }

            resp += $"Requires DSPT? { (chkb_DSPT.Checked ? "Yes" : "No") }\n";
            resp += $"Requires ISO27001? { (chkb_ISO27001.Checked ? "Yes" : "No") }\n";
            resp += $"Requires encryption? { (chkb_Encryption.Checked ? "Yes" : "No") }\n";
            resp += $"Requires on-site (i.e., prohibits remote access)? { (chkb_NoRemoteAccess.Checked ? "Yes" : "No") }\n";

            List<string> projSelections = lbx_ProjectsList.SelectedItems.Cast<string>().ToList();
            resp += "Associated projects:\n";
            if (projSelections.Count == 1 && String.IsNullOrWhiteSpace(projSelections[0]))
            {
                resp += "NONE\n";
            }
            else
            {
                resp += "";
                foreach (string item in projSelections.Where(s => !String.IsNullOrWhiteSpace(s)))
                {
                    resp += $"{item}\n";
                }
            }

            resp += $"Number of notes: {dgv_AddNote.Rows.Count}\n\n";

            resp += "Are you sure you want to create this DSA?";

            DialogResult confirmation = MessageBox.Show(text: resp, caption: "Confirmation", buttons: MessageBoxButtons.OKCancel);
            return confirmation;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
