using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.DSAs
{
    public partial class frm_DsaProjectAdd : Form
    {
        private frm_DsaAdd dsaFrm = null;

        public frm_DsaProjectAdd(Form parentForm)
        {
            dsaFrm = parentForm as frm_DsaAdd;
            InitializeComponent();
            FillProjectTable();
        }

        DSA dsa = new DSA();

        private void FillProjectTable()
        {
            dgv_ProjectList.DataSource = dsa.CreateDsasProjectsView(this.dsaFrm.ds);
            dgv_ProjectList.Columns["Project"].Width = 80;
            dgv_ProjectList.Columns["Title"].Width = 375;
            dgv_ProjectList.RowHeadersWidth = 15;
        }

        private void frm_DsaProjectAdd_Load(object sender, EventArgs e)
        {
            dgv_ProjectList.ClearSelection();
        }

        private void btn_ConfirmProject_Click(object sender, EventArgs e)
        {
            // Guide user to select a row
            if (dgv_ProjectList.SelectedRows.Count != 1)
            {
                MessageBox.Show(
                    text: "Select one row in the table to add a project.\n",
                    caption: "No row selected",
                    buttons: MessageBoxButtons.OK
                );
                return;
            }
            // Validate their choice is intentional
            DialogResult confirm = MessageBox.Show(
                text: $"Are you sure you want to link project " +
                      $"{dgv_ProjectList.SelectedRows[0].Cells["Project"].Value} " +
                      $"to this DSA?",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel
            );
            if (confirm == DialogResult.Cancel)
            {
                return;
            }

            // If amendment is valid and intended, populate amendment DGV on parent form
            this.dsaFrm.Projects.Rows.Add( dgv_ProjectList.SelectedRows[0].Cells["Project"].Value.ToString() );

            this.Close();
        }
    }
}
