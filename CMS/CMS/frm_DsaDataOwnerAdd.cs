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
using DataControlsLib.ViewModels;

namespace CMS
{
    public partial class frm_DsaDataOwnerAdd : Form
    {
        public frm_DsaDataOwnerAdd()
        {
            InitializeComponent();
            PopulateDsaDataset();
            SetExistingDataOwnersList();
            FillDataOwnerGridView();
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

        public void SetExistingDataOwnersList()
        {
            List<string> dataOwners = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .OrderBy(p => p.Field<string>("DataOwnerName"))
                .Select(p => p.Field<string>("DataOwnerName"))
                .ToList();
            dataOwners.Insert(0, "");
            cb_RebrandingOfOldName.DataSource = dataOwners;
        }

        public void FillDataOwnerGridView()
        {
            string searchTxt = tb_Search.Text.ToLower().NullIfEmpty();
            
            List<DataOwnersViewModel> doList = (
                from do1 in ds.Tables["tblDsaDataOwners"].AsEnumerable()
                join do2 in ds.Tables["tblDsaDataOwners"].AsEnumerable() on do1.Field<int?>("RebrandOf") equals do2.Field<int>("doID") into do2tmp
                orderby do1.Field<string>("DataOwnerName")
                from do2 in do2tmp.DefaultIfEmpty()
                where 
                (
                    searchTxt == null
                        || ((do1 == null) ? false : do1.Field<string>("DataOwnerName").ToLower().Contains(searchTxt))
                        || ((do2 == null) ? false : do2.Field<string>("DataOwnerName").ToLower().Contains(searchTxt))
                )
                select new DataOwnersViewModel
                {
                    DataOwner = do1.Field<string>("DataOwnerName"),
                    RebrandingOf = (do2 == null) ? null : do2.Field<string>("DataOwnerName")
                })
                .ToList();

            dgv_DataOwners.DataSource = doList;
            dgv_DataOwners.Columns["DataOwner"].Width = 230;
            dgv_DataOwners.Columns["RebrandingOf"].Width = 230;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            FillDataOwnerGridView();
        }
    }
}
