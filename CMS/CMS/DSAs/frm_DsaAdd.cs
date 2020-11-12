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
        DSA dsa = new DSA();

        public void PopulateDsaDataset()
        {
            try
            {
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
            dtp_DestroyDate.Value = DateTime.Now.Date;

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
            cb_ExistingDataOwner.DataSource = dsa.CollectDataOwnersList(ds);
        }

        private void chkb_IsAmendment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_IsAmendment.Checked)
            {
                dgv_AmendmentOf.Enabled = true;
                dgv_AmendmentOf.DataSource = dsa.CreateDsasBasicView(ds);
                dgv_AmendmentOf.Columns["DsaID"].Width = 50;
                dgv_AmendmentOf.Columns["DataOwner"].Width = 120;
                dgv_AmendmentOf.Columns["StartDate"].Width = 85;
                dgv_AmendmentOf.Columns["ExpiryDate"].Width = 85;
                dgv_AmendmentOf.Columns["DataDestructionDate"].Width = 140;
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
            bool hasRequiredInputs = dsa.ValidateInputs(
                fileName: tb_FileName.Text, 
                filePath: tb_FilePath.Text, 
                dataOwner: cb_ExistingDataOwner.SelectedItem.ToString()
            );

            if (!hasRequiredInputs)
            {
                return;
            }

            if (ConfirmationMsg() == DialogResult.Cancel)
            {
                return;
            }

            dsasInsertData = dsa.CollectDsasForInsert(
                ds: ds,
                dataOwner: cb_ExistingDataOwner.SelectedItem.ToString(),
                isAmendment: chkb_IsAmendment.Checked,
                dgvAmendment: dgv_AmendmentOf,
                fileName: tb_FileName.Text,
                filePath: tb_FilePath.Text,
                startDate: dtp_StartDate.Checked ? dtp_StartDate?.Value.Date : null,
                expiryDate: dtp_ExpiryDate.Checked ? dtp_ExpiryDate?.Value.Date : null,
                destroyDate: dtp_DestroyDate.Checked ? dtp_DestroyDate?.Value.Date : null, // Add dtp_destroyDate form element
                ownerEmail: tb_OwnerEmail.Text, // Add tb_ownerEmail form element
                dspt: chkb_DSPT.Checked,
                iso27001: chkb_ISO27001.Checked,
                encryption: chkb_Encryption.Checked,
                remote: chkb_NoRemoteAccess.Checked
            );

            dsaNotesInsertData = dsa.CollectDsaNotesForInsert(
                dgvNotes: dgv_AddNote
            );

            dsasProjectsInsertData = dsa.CollectDsaProjectsForInsert(
                projects: lbx_ProjectsList.SelectedItems.Cast<string>()
            );

            bool insertSuccessful = dsa.PutDsaData(dsasInsertData, dsaNotesInsertData, dsasProjectsInsertData);

            if (insertSuccessful)
            {
                MessageBox.Show("Successfully added new DSA record.\n", "DSA Added", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private DialogResult ConfirmationMsg()
        {
            string resp = "You are about to create a new DSA record with the following details:\n\n";

            resp += $"Data owner: {cb_ExistingDataOwner.SelectedItem}\n";
            resp += $"Primary contact: {tb_OwnerEmail.Text}\n";
            resp += $"File name: {tb_FileName.Text}\n";
            resp += $"File path: {tb_FilePath.Text}\n";
            resp += $"Start date: { (dtp_StartDate.Checked ? dtp_StartDate?.Value.Date.ToString("yyyy-MM-dd") : "NOT SPECIFIED") }\n";
            resp += $"Expiry date: { (dtp_ExpiryDate.Checked ? dtp_ExpiryDate?.Value.Date.ToString("yyyy-MM-dd") : "NOT SPECIFIED") }\n";
            resp += $"Data destruction date: { (dtp_DestroyDate.Checked ? dtp_DestroyDate?.Value.Date.ToString("yyyy-MM-dd") : "NOT SPECIFIED") }\n";

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
