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

            IEnumerable<DsaBasicsViewModel> dsaQuery =
                from dsa in ds.Tables["tblDsas"].AsEnumerable()
                join own in ds.Tables["tblDsaDataOwners"].AsEnumerable() on dsa.Field<int>("DataOwner") equals own.Field<int>("doID")
                join dsa2 in ds.Tables["tblDsas"].AsEnumerable() on dsa.Field<int>("DsaID") equals dsa2.Field<int>("AmendmentOf")
                select new DsaBasicsViewModel
                {
                    DataOwner = own.Field<string>("DataOwnerName"),
                    StartDate = dsa.Field<DateTime?>("StartDate"),
                    ExpiryDate = dsa.Field<DateTime?>("ExpiryDate"),
                    DsaName = dsa.Field<string>("DsaName"),
                    FilePath = dsa.Field<string>("DsaFileLoc"),
                    AmendmentOf = dsa2.Field<string>("DsaName"),
                    DSPT = dsa.Field<bool>("DSPT"),
                    ISO270001 = dsa.Field<bool>("ISO270001")
                };
            dgv_AmendmentOf.DataSource = dsaQuery.ToList();

            // Data owners list, first removing old rebranded names to avoid continued use of multiple names
            List<int> rebrands = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => t.Field<int?>("RebrandOf") != null)
                .Select(t => new List<int> { t.Field<int?>("RebrandOf").GetValueOrDefault() })
                .Distinct().SelectMany(x => x).ToList();
            List<string> dataOwners = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => !rebrands.Contains(t.Field<int>("doID")))
                .OrderBy(p => p.Field<string>("ProjectNumber"))
                .Select(p => p.Field<string>("ProjectNumber"))
                .ToList();
            dataOwners.Insert(0, "");
            cb_ExistingDataOwner.DataSource = dataOwners;
        }

        public void CollectInputs()
        {
            // Put control selections into data model objects ready for passing to DB put method
            throw new NotImplementedException();
        }
    }
}
