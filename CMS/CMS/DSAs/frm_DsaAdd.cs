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

        public frm_DsaAdd(int id)
        {
            InitializeComponent();
            PopulateDsaDataset();
            SetInitialControls();
            InputDsaInfo(id);
        }

        DSA dsa = new DSA();
        public DataSet ds;
        mdl_Dsas dsaRecord = new mdl_Dsas();

        DataTable dsaNotes = new DataTable();

        mdl_Dsas dsasInsertData = new mdl_Dsas();
        List<mdl_DsaNotes> dsaNotesInsertData = new List<mdl_DsaNotes>();
        List<mdl_DsasProjects> dsasProjectsInsertData = new List<mdl_DsasProjects>();

        public DataGridView Amendment
        {
            get { return dgv_AmendmentOf; }
            set { dgv_AmendmentOf = value; }
        }

        public DataGridView Projects
        {
            get { return dgv_DsasProjects; }
            set { dgv_DsasProjects = value; }
        }

        public bool insertSuccessful = false;

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

            chkb_OldDataOwners.Checked = true;
            FillDataOwnersList();

            dgv_DsasProjects.ColumnCount = 1;
            dgv_DsasProjects.Columns[0].Name = "Project";
            dgv_DsasProjects.Columns["Project"].Width = 246;
            dgv_DsasProjects.RowHeadersWidth = 15;

            dsaNotes.Columns.Add("Notes", typeof(string));
            dsaNotes.Columns.Add("Created", typeof(DateTime));
            //dsaNotes.Columns.Add("CreatedBy", typeof(string));
            dgv_AddNote.DataSource = dsaNotes;
            dgv_AddNote.Columns["Notes"].Width = 266;
            dgv_AddNote.Columns["Created"].Width = 100;
            //dgv_AddNote.Columns["CreatedBy"].Width = 100;
            dgv_AddNote.RowHeadersWidth = 15;
        }

        public void InputDsaInfo(int id)
        {
            dsaRecord = dsa.GetDsaRecord(ds, id);
            List<string> dsaPrjList = dsa.GetDsaProjectsList(ds, id);
            List<mdl_DsaNotes> dsaNotesHistory = dsa.GetDsaNotes(ds, id);

            int isRebranded = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(r => r.Field<int?>("RebrandOf") == dsaRecord.DataOwner)
                .Select(x => x.Field<int?>("RebrandOf"))
                .ToList()
                .Count;

            if (isRebranded > 0)
            {
                chkb_OldDataOwners.Checked = false;
                FillDataOwnersList();
            }

            cb_ExistingDataOwner.SelectedValue = dsaRecord.DataOwner;

            tb_OwnerEmail.Text = dsaRecord.AgreementOwnerEmail;
            tb_FileName.Text = dsaRecord.DsaName;
            tb_FilePath.Text = dsaRecord.DsaFileLoc;

            if (dsaRecord.StartDate.HasValue)
            {
                dtp_StartDate.Checked = true;
                dtp_StartDate.Value = dsaRecord.StartDate.HasValue ? (DateTime)dsaRecord.StartDate : DateTime.Now.Date;
            }
            if (dsaRecord.ExpiryDate.HasValue)
            {
                dtp_ExpiryDate.Checked = true;
                dtp_ExpiryDate.Value = dsaRecord.ExpiryDate.HasValue ? (DateTime)dsaRecord.ExpiryDate : DateTime.Now.Date;
            }
            if (dsaRecord.DataDestructionDate.HasValue)
            {
                dtp_DestroyDate.Checked = true;
                dtp_DestroyDate.Value = dsaRecord.DataDestructionDate.HasValue ? (DateTime)dsaRecord.DataDestructionDate : DateTime.Now.Date;
            }

            if (dsaRecord.AmendmentOf.HasValue)
            {
                dgv_AmendmentOf.DataSource = dsa.CreateDsasBasicView(ds).Where(x => x.DocumentID == dsaRecord.AmendmentOf).ToList();
                dgv_AmendmentOf.Columns["DocumentID"].Width = 80;
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
                dgv_AmendmentOf.RowHeadersWidth = 15;
            }

            chkb_DSPT.Checked = dsaRecord.DSPT ?? false;
            chkb_ISO27001.Checked = dsaRecord.ISO27001 ?? false;
            chkb_Encryption.Checked = dsaRecord.RequiresEncryption ?? false;
            chkb_NoRemoteAccess.Checked = dsaRecord.NoRemoteAccess ?? false;

            foreach (string prj in dsaPrjList)
            {
                dgv_DsasProjects.Rows.Add(prj);
            }

            foreach (mdl_DsaNotes n in dsaNotesHistory)
            {
                //dsaNotes.Rows.Add(n.Note, n.Created, n.CreatedBy);
                dsaNotes.Rows.Add(n.Note, n.Created);
            }
        }

        private void FillDataOwnersList()
        {
            cb_ExistingDataOwner.DataSource = dsa.CollectDataOwnersList(ds, chkb_OldDataOwners.Checked);
            cb_ExistingDataOwner.ValueMember = "doID";
            cb_ExistingDataOwner.DisplayMember = "DataOwnerName";
        }

        private void chkb_OldDataOwners_CheckedChanged(object sender, EventArgs e)
        {
            FillDataOwnersList();
        }

        private void btn_AddNote_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_AddNote.Text))
            {
                dsaNotes.Rows.Add(tb_AddNote.Text, DateTime.Now); // Add DB user
            }
            tb_AddNote.Text = null;
        }

        private void lbl_NewDataOwner_Click(object sender, EventArgs e)
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

        private void btn_AddAmendment_Click(object sender, EventArgs e)
        {
            frm_DsaAmendmentAdd frmAmendment = new frm_DsaAmendmentAdd(this);
            frmAmendment.Show();
        }
        private void btn_ProjectAdd_Click(object sender, EventArgs e)
        {
            frm_DsaProjectAdd frmProj = new frm_DsaProjectAdd(this);
            frmProj.Show();
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

            if (dsaRecord.ID == 0 && ConfirmationMsg() == DialogResult.Cancel)
            {
                return;
            }

            dsasInsertData = dsa.CollectDsasForInsert(
                ds: ds,
                dataOwner: (int)cb_ExistingDataOwner.SelectedValue,
                isAmendment: dgv_AmendmentOf.Rows.Count == 1,
                dgvAmendment: dgv_AmendmentOf,
                fileName: tb_FileName.Text,
                filePath: tb_FilePath.Text,
                startDate: dtp_StartDate.Checked ? dtp_StartDate?.Value.Date : null,
                expiryDate: dtp_ExpiryDate.Checked ? dtp_ExpiryDate?.Value.Date : null,
                destroyDate: dtp_DestroyDate.Checked ? dtp_DestroyDate?.Value.Date : null, 
                ownerEmail: tb_OwnerEmail.Text, 
                dspt: chkb_DSPT.Checked,
                iso27001: chkb_ISO27001.Checked,
                encryption: chkb_Encryption.Checked,
                remote: chkb_NoRemoteAccess.Checked
            );

            if (dsaRecord != null && dsaRecord.ID > 0)
            {
                dsasInsertData.ID = dsaRecord.ID;
            }

            dsaNotesInsertData = dsa.CollectDsaNotesForInsert(
                dgvNotes: dgv_AddNote,
                ds: ds,
                rcrd: dsaRecord
            );

            dsasProjectsInsertData = dsa.CollectDsaProjectsForInsert(
                ds: ds,
                rcrd: dsaRecord,
                projects: dgv_DsasProjects.Rows.OfType<DataGridViewRow>()
                            .Select(r => r.Cells["Project"])
                            .Select(c => c.Value.ToString())
            );

            insertSuccessful = dsa.PutDsaData(dsasInsertData, dsaNotesInsertData, dsasProjectsInsertData, dsaRecord);

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

            if (dgv_AmendmentOf.Rows.Count > 0)
            {
                resp += $"Amends \"{dgv_AmendmentOf.SelectedRows[0].Cells["DsaName"].Value}\" agreement\n";
            }
            else
            {
                resp += "Is an original agreement.\n";
            }

            resp += $"Requires DSPT? { (chkb_DSPT.Checked ? "Yes" : "No") }\n";
            resp += $"Requires ISO27001? { (chkb_ISO27001.Checked ? "Yes" : "No") }\n";
            resp += $"Requires encryption? { (chkb_Encryption.Checked ? "Yes" : "No") }\n";
            resp += $"Requires on-site (i.e., prohibits remote access)? { (chkb_NoRemoteAccess.Checked ? "Yes" : "No") }\n";

            List<string> projSelections = dsa.GetDsaProjectsList(ds, dsaRecord == null ? -1 : dsaRecord.ID);
            
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
