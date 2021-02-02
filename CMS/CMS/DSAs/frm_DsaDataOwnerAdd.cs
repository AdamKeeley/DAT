using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;
using DataControlsLib.ViewModels;

namespace CMS.DSAs
{
    public partial class frm_DsaDataOwnerAdd : Form
    {
        public frm_DsaDataOwnerAdd()
        {
            InitializeComponent();
            UpdateDataOwnerControls();
        }

        DSA dsa = new DSA();
        private DataSet ds;

        private void UpdateDataOwnerControls()
        {
            PopulateDsaDataset();
            SetExistingDataOwnersList();

            tb_Search.Text = "";
            FillDataOwnerGridView();
        }

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
            
            List<DataOwnersViewModel> doList = dsa.CreateDataOwnerGridView(ds, searchTxt);

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
            bool valid = ValidateDataOwnerInputs();

            if (!valid)
            {
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "You're about to create a new data owner record in the database with the name:\n\n" +
                $"{tb_NewDataOwnerName.Text}\n" +
                $"{(cb_RebrandingOfOldName.SelectedItem.ToString().NullIfEmpty() == null ? null : $"a rebrand of {cb_RebrandingOfOldName.SelectedItem}\n")}\n" +
                "Are you sure?",
                caption: "New data owner confirmation",
                buttons: MessageBoxButtons.OKCancel
            );

            if (confirmation == DialogResult.Cancel)
            {
                return;
            }

            int? rebrandedIndex = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                    .Where(tbl => tbl.Field<string>("DataOwnerName") == cb_RebrandingOfOldName.SelectedItem.ToString())
                    .Select(tbl => tbl?.Field<int>("doID"))
                    .ToList()
                    .FirstOrDefault();

            mdl_DsaDataOwners doInput = new mdl_DsaDataOwners
            {
                DateOwnerName = tb_NewDataOwnerName.Text,
                RebrandOf = rebrandedIndex
            };

            try
            {
                DSA dsa = new DSA();
                dsa.PutDataOwnerData(doInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new data owner record to the database." + Environment.NewLine +
                                ex.Message + Environment.NewLine +
                                Environment.NewLine +
                                ex.StackTrace);
            }

            UpdateDataOwnerControls();
        }

        private bool ValidateDataOwnerInputs()
        {
            if (String.IsNullOrWhiteSpace(tb_NewDataOwnerName.Text))
            {
                return false;
            }

            List<string> existingNames = ds.Tables["tblDsaDataOwners"].AsEnumerable().Select(x => x.Field<string>("DataOwnerName")).ToList();

            if (existingNames.Contains(tb_NewDataOwnerName.Text))
            {
                string resp = $"{tb_NewDataOwnerName.Text} already exists in the record of data owners. Please use the existing record instead.\n";

                string rebrandedName = (
                        from do1 in ds.Tables["tblDsaDataOwners"].AsEnumerable()
                        join do2 in ds.Tables["tblDsaDataOwners"].AsEnumerable() on do1.Field<int?>("RebrandOf") equals do2.Field<int>("doID") into do2tmp
                        from do2 in do2tmp.DefaultIfEmpty()
                        where do2?.Field<string>("DataOwnerName") == tb_NewDataOwnerName.Text
                        select do1.Field<string>("DataOwnerName")
                    ).FirstOrDefault();

                resp += (rebrandedName == null) ? null : $"However, this data owner was rebranded to {rebrandedName}. Consider using the newer name instead.\n";

                MessageBox.Show(text: resp, caption: "Duplicate of existing name", buttons: MessageBoxButtons.OK);

                return false;
            }

            if (tb_NewDataOwnerName.Text.Length > 50)
            {
                MessageBox.Show(
                    text:   $"Data owner name can be a maximum of 50 characters.\n" + 
                            $"{tb_NewDataOwnerName.Text} is {tb_NewDataOwnerName.Text.Length} characters.\n", 
                    caption: "Name too long", buttons: MessageBoxButtons.OK
                );
                return false;
            }

            return true;
        }
    }
}
