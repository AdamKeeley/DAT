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
    public partial class frm_DataIO : Form
    {
        public frm_DataIO()
        {
            InitializeComponent();
            PopulateIODataset();
            SetFilterControls();
            UpdateDataViewBinding();
        }

        private DataSet ds;
        private List<string> changeTypesWanted;
        private List<bool?> approvalsWanted;

        public void PopulateIODataset()
        {
            try
            {
                DataIO io = new DataIO();
                ds = io.GetAssetsHistoryDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get assets history data from the database." + Environment.NewLine + 
                                ex.Message + Environment.NewLine + 
                                Environment.NewLine +
                                ex.StackTrace);
            }

         }

        public void SetFilterControls()
        {
            dtp_DateToFilter.Value = DateTime.Now.Date;

            List<string> projNumbers = ds.Tables["tblProject"].AsEnumerable()
                .OrderBy(p => p.Field<string>("ProjectNumber"))
                .Select(p => p.Field<string>("ProjectNumber"))
                .ToList();
            projNumbers.Insert(0, "");
            cb_ProjectFilter.DataSource = projNumbers;

            UpdateChangeTypesWanted();
            UpdateApprovalsWanted();
        }

        public void UpdateChangeTypesWanted()
        {
            changeTypesWanted = new List<string>();
            if (chkb_ChangeTypeImport.Checked) changeTypesWanted.Add(chkb_ChangeTypeImport.Text);
            if (chkb_ChangeTypeExport.Checked) changeTypesWanted.Add(chkb_ChangeTypeExport.Text);
            if (chkb_ChangeTypeDelete.Checked) changeTypesWanted.Add(chkb_ChangeTypeDelete.Text);
        }

        public void UpdateApprovalsWanted()
        {
            approvalsWanted = new List<bool?>();
            if (chkb_ChangeAccepted1.Checked) approvalsWanted.Add(true);
            if (chkb_ChangeAccepted0.Checked) approvalsWanted.Add(false);
        }

        public void UpdateDataViewBinding()
        {
            try
            {
                dgv_DataIOHistory.DataSource = CreateAssetsHistoryView(
                    dateFrom: dtp_DateFromFilter.Value.Date, 
                    dateTo: dtp_DateToFilter.Value.Date, 
                    proj: cb_ProjectFilter.Text.NullIfEmpty(), 
                    fPath: tb_FilePathFilter.Text.NullIfEmpty()
                );
                dgv_DataIOHistory.Columns["Project"].Width = 60;
                dgv_DataIOHistory.Columns["ChangeDate"].Width = 100;
                dgv_DataIOHistory.Columns["ChangeType"].Width = 95;
                dgv_DataIOHistory.Columns["AssetName"].Width = 200;
                dgv_DataIOHistory.Columns["FilePath"].Width = 100;
                dgv_DataIOHistory.Columns["Checksum"].Width = 100;
                dgv_DataIOHistory.Columns["ChangeAccepted"].Width = 120;
                dgv_DataIOHistory.Columns["RequestedBy"].Width = 115;
                dgv_DataIOHistory.Columns["ChangedBy"].Width = 115;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create assets history view." + Environment.NewLine + 
                                ex.Message + Environment.NewLine + 
                                Environment.NewLine +
                                ex.StackTrace);
            }
        }

        public List<AssetHistoryViewModel> CreateAssetsHistoryView(DateTime? dateFrom, DateTime? dateTo, string proj, string fPath)
        {
            IEnumerable<AssetHistoryViewModel> query = 
                from cl in ds.Tables["tblAssetsChangeLog"].AsEnumerable()
                join rq in ds.Tables["tblDataIORequests"].AsEnumerable() on cl.Field<int>("RequestID") equals rq.Field<int>("RequestID")
                join ar in ds.Tables["tblAssetsRegister"].AsEnumerable() on cl.Field<int>("AssetID") equals ar.Field<int>("AssetID")
                join ct in ds.Tables["tlkAssetChangeTypes"].AsEnumerable() on rq.Field<int>("ChangeType") equals ct.Field<int>("ChangeTypeID")
                where (dateFrom == null || (rq.Field<DateTime?>("ChangeDate").HasValue && dateFrom <= rq.Field<DateTime?>("ChangeDate").Value.Date)) 
                    && (dateTo == null || (rq.Field<DateTime?>("ChangeDate").HasValue && dateTo >= rq.Field<DateTime?>("ChangeDate").Value.Date))
                    && (proj == null || (proj == rq.Field<string>("Project").NullIfEmpty()))
                    && (fPath == null || ar.Field<string>("VreFilePath").NullIfEmpty().Contains(fPath))
                    && (changeTypesWanted.Contains(ct.Field<string>("ChangeTypeLabel")))
                    && (approvalsWanted.Contains(cl.Field<bool?>("ChangeAccepted")))
                select new AssetHistoryViewModel
                {
                    Project = rq.Field<string>("Project"),
                    ChangeDate = rq.Field<DateTime?>("ChangeDate"),
                    ChangeType = ct.Field<string>("ChangeTypeLabel"),
                    AssetName = ar.Field<string>("AssetName"),
                    FilePath = ar.Field<string>("VreFilePath"),
                    Checksum = ar.Field<string>("AssetSha256sum"),
                    ChangeAccepted = cl.Field<bool?>("ChangeAccepted"),
                    RequestedBy = rq.Field<string>("RequestedBy"),
                    ChangedBy = rq.Field<string>("ChangedBy")
                };

            return query.ToList();
        }

        private void btn_RefreshAssetsHistoryView_Click(object sender, EventArgs e)
        {
            UpdateChangeTypesWanted();
            UpdateApprovalsWanted();
            UpdateDataViewBinding();
        }
    }
}
