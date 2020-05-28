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
                    RebrandingOf = do2?.Field<string>("DataOwnerName")
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

        private void btn_NewDataOwner_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_NewDataOwnerName.Text))
            {
                // DB schema enforces data owner names to be unique. But not sure yet how that will behave
                // might need method to catch duplications and throw a meaningful error. TBC
                //ValidateDataOwnerInputs();

                DialogResult confirmation = MessageBox.Show(
                    "You're about to create a new data owner record in the database with the name:\n\n" + 
                    $"{tb_NewDataOwnerName.Text}\n" + 
                    $"{(cb_RebrandingOfOldName.SelectedItem.ToString().NullIfEmpty() == null ? null : $"a rebrand of {cb_RebrandingOfOldName.SelectedItem}\n")}\n" + 
                    "Are you sure?",    
                    caption: "New data owner confirmation",
                    buttons: MessageBoxButtons.OKCancel
                );

                if (confirmation == DialogResult.OK)
                {
                    int? rebrandedIndex = null;
                    if (!String.IsNullOrWhiteSpace(cb_RebrandingOfOldName.SelectedItem.ToString()))
                    {
                        rebrandedIndex = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                            .Where(tbl => tbl.Field<string>("DataOwnerName") == cb_RebrandingOfOldName.SelectedItem.ToString())
                            .Select(tbl => tbl?.Field<int>("doID"))
                            .ToList()
                            .First();
                    }

                    DsaDataOwnerModel doInput = new DsaDataOwnerModel
                    {
                        DateOwnerName = tb_NewDataOwnerName.Text,
                        RebrandOf = rebrandedIndex
                    };

                    try
                    {
                        DSA dsa = new DSA();
                        ds = dsa.PutDataOwnerData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to add new data owner record to the database." + Environment.NewLine +
                                        ex.Message + Environment.NewLine +
                                        Environment.NewLine +
                                        ex.StackTrace);
                    }
                }
            }
        }

        private void ValidateDataOwnerInputs()
        {
            throw new NotImplementedException();
        }
    }
}
