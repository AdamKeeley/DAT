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
    public partial class frm_DsasView : Form
    {
        public frm_DsasView()
        {
            InitializeComponent();
            PopulateDsaDataset();
            FillGridView();
        }

        private DataSet ds;
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

        public void FillGridView()
        {
            dgv_Dsas.DataSource = dsa.CreateDsasBasicView(ds);
            dgv_Dsas.RowHeadersWidth = 15;
            dgv_Dsas.Columns["DocumentID"].Width = 45;
            dgv_Dsas.Columns["DataOwner"].Width = 130;
            dgv_Dsas.Columns["StartDate"].Width = 85;
            dgv_Dsas.Columns["ExpiryDate"].Width = 85;
            dgv_Dsas.Columns["DataDestructionDate"].Width = 120;
            dgv_Dsas.Columns["DsaName"].Width = 160;
            dgv_Dsas.Columns["AmendmentOf"].Width = 140;
            dgv_Dsas.Columns["DSPT"].Width = 75;
            dgv_Dsas.Columns["ISO27001"].Width = 75;
            dgv_Dsas.Columns["RequiresEncryption"].Width = 115;
            dgv_Dsas.Columns["NoRemoteAccess"].Width = 100;
        }

        private void RefreshView(object sender, EventArgs e)
        {
            PopulateDsaDataset();
            FillGridView();
        }

        private void btn_NewDSA_Click(object sender, EventArgs e)
        {
            frm_DsaAdd newDsa = new frm_DsaAdd();
            newDsa.FormClosing += new FormClosingEventHandler(this.RefreshView);
            newDsa.Show();
        }

        private void dgv_Dsas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    int docID = (int)dgv_Dsas.Rows[r].Cells["DocumentID"].Value;
                    frm_DsaAdd editDsa = new frm_DsaAdd(docID);
                    editDsa.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please double click on a data row to open DSA record." + Environment.NewLine + ex);
                }
            }
        }
    }
}
