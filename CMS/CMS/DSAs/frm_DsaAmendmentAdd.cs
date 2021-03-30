using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib.ViewModels;

namespace CMS.DSAs
{
    public partial class frm_DsaAmendmentAdd : Form
    {
        private frm_DsaAdd dsaFrm = null;
        public frm_DsaAmendmentAdd(Form parentForm)
        {
            dsaFrm = parentForm as frm_DsaAdd;
            InitializeComponent();
            FillAmendmentTable();
        }

        DSA dsa = new DSA();

        private void FillAmendmentTable()
        {
            dgv_AmendmentList.DataSource = dsa.CreateDsasBasicView(this.dsaFrm.ds);
            dgv_AmendmentList.RowHeadersWidth = 15;
            dgv_AmendmentList.Columns["DocumentID"].Width = 80;
            dgv_AmendmentList.Columns["DataOwner"].Width = 120;
            dgv_AmendmentList.Columns["StartDate"].Width = 85;
            dgv_AmendmentList.Columns["ExpiryDate"].Width = 85;
            dgv_AmendmentList.Columns["DataDestructionDate"].Width = 140;
            dgv_AmendmentList.Columns["DsaName"].Width = 140;
            dgv_AmendmentList.Columns["AmendmentOf"].Width = 140;
            dgv_AmendmentList.Columns["DSPT"].Width = 75;
            dgv_AmendmentList.Columns["ISO27001"].Width = 75;
            dgv_AmendmentList.Columns["RequiresEncryption"].Width = 140;
            dgv_AmendmentList.Columns["NoRemoteAccess"].Width = 125;
        }

        private void frm_DsaAmendmentAdd_Load(object sender, EventArgs e)
        {
            dgv_AmendmentList.ClearSelection();
        }

        private void btn_ConfirmAmendment_Click(object sender, EventArgs e)
        {
            // Guide user to select a row
            if (dgv_AmendmentList.SelectedRows.Count != 1)
            {
                MessageBox.Show(
                    text: "Select one row in the table to add an amendment.\n",
                    caption: "No row selected",
                    buttons: MessageBoxButtons.OK
                );
                return;
            }
            // Validate their choice is intentional
            DialogResult confirm = MessageBox.Show(
                text: $"Are you sure you want to create an amendment of DSA DocumentID = " +
                      $"{dgv_AmendmentList.SelectedRows[0].Cells["DocumentID"].Value}?",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel
            );
            if (confirm == DialogResult.Cancel)
            {
                return;
            }

            // If amendment is valid and intended, populate amendment DGV on parent form
            int? chosenID = (int?)dgv_AmendmentList.SelectedRows[0].Cells["DocumentID"].Value;
            List<DsaBasicsViewModel> choice = dgv_AmendmentList.DataSource as List<DsaBasicsViewModel>;
            choice = choice.Where(r => r.DocumentID == chosenID).ToList();

            this.dsaFrm.Amendment.DataSource = choice;
            this.dsaFrm.Amendment.Columns["DocumentID"].Width = 80;
            this.dsaFrm.Amendment.Columns["DataOwner"].Width = 120;
            this.dsaFrm.Amendment.Columns["StartDate"].Width = 85;
            this.dsaFrm.Amendment.Columns["ExpiryDate"].Width = 85;
            this.dsaFrm.Amendment.Columns["DataDestructionDate"].Width = 140;
            this.dsaFrm.Amendment.Columns["DsaName"].Width = 140;
            this.dsaFrm.Amendment.Columns["AmendmentOf"].Width = 140;
            this.dsaFrm.Amendment.Columns["DSPT"].Width = 75;
            this.dsaFrm.Amendment.Columns["ISO27001"].Width = 75;
            this.dsaFrm.Amendment.Columns["RequiresEncryption"].Width = 140;
            this.dsaFrm.Amendment.Columns["NoRemoteAccess"].Width = 125;
            this.dsaFrm.Amendment.RowHeadersWidth = 15;

            this.Close();
        }
    }
}
