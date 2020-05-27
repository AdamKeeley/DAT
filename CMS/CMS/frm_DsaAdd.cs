using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib.DataModels;
using DataControlsLib.ViewModels;

namespace CMS
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

            // Create view of DSAs. Needs DSA table to left outer join with itself to get name of previous DSA versions.
            IEnumerable<DsaBasicsViewModel> dsaQuery =
                from dsa in ds.Tables["tblDsas"].AsEnumerable()
                join own in ds.Tables["tblDsaDataOwners"].AsEnumerable() on dsa.Field<int>("DataOwner") equals own.Field<int>("doID")
                join dsa2 in ds.Tables["tblDsas"].AsEnumerable() on dsa.Field<int?>("AmendmentOf") equals dsa2.Field<int>("DsaID") into dsa2tmp
                from dsa2 in dsa2tmp.DefaultIfEmpty()
                select new DsaBasicsViewModel
                {
                    DataOwner = own.Field<string>("DataOwnerName"),
                    StartDate = dsa.Field<DateTime?>("StartDate"),
                    ExpiryDate = dsa.Field<DateTime?>("ExpiryDate"),
                    DsaName = dsa.Field<string>("DsaName"),
                    FilePath = dsa.Field<string>("DsaFileLoc"),
                    AmendmentOf = (dsa2 == null) ? null : dsa2.Field<string>("DsaName"),
                    DSPT = dsa.Field<bool>("DSPT"),
                    ISO27001 = dsa.Field<bool>("ISO27001")
                };
            dgv_AmendmentOf.DataSource = dsaQuery.ToList();

            dgv_AmendmentOf.Columns["DataOwner"].Width = 120;
            dgv_AmendmentOf.Columns["StartDate"].Width = 85;
            dgv_AmendmentOf.Columns["ExpiryDate"].Width = 85;
            dgv_AmendmentOf.Columns["DsaName"].Width = 140;
            dgv_AmendmentOf.Columns["AmendmentOf"].Width = 140;
            dgv_AmendmentOf.Columns["DSPT"].Width = 75;
            dgv_AmendmentOf.Columns["ISO27001"].Width = 75;

            // Data owners list, first removing old rebranded names to avoid continued use of multiple names
            FillDataOwnersList();

            dsaNotes.Columns.Add("Notes", typeof(string));
            dgv_AddNote.DataSource = dsaNotes;
            dgv_AddNote.Columns["Notes"].Width = 400;
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

        public void CollectInputs()
        {
            // Put control selections into data model objects ready for passing to DB put method
            throw new NotImplementedException();
        }

        private void btn_AddNote_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_AddNote.Text))
            {
                dsaNotes.Rows.Add(tb_AddNote.Text);
            }
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
    }
}
