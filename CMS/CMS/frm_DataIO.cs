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

namespace CMS
{
    public partial class frm_DataIO : Form
    {
        public frm_DataIO()
        {
            InitializeComponent();

            UpdateDataViewBinding();
            //SetEmptyControls();
            /*MessageBox.Show(
                $"Date from filter is: {dtp_DateFromFilter.Value}" +
                Environment.NewLine +
                $"Date to filter is: {dtp_DateToFilter.Value}" +
                Environment.NewLine +
                $"Project number filter is: {cb_ProjectFilter.Text}" +
                Environment.NewLine +
                $"Is project number null? {cb_ProjectFilter.Text == null}" +
                Environment.NewLine +
                $"File path filter is: {tb_FilePathFilter.Text}" +
                Environment.NewLine +
                $"Is file path null? {tb_FilePathFilter.Text == null}"
            );*/
        }

        //List<FullAssetsHistoryModel> searchData = new List<FullAssetsHistoryModel>();
        DataSet ds_io;

        public void UpdateDataViewBinding()
        {
            //SetEmptyControls();
            
            DataIO io = new DataIO();

            try
            {
                ds_io = io.GetAssetsHistory(
                    dtp_DateFromFilter.Value, dtp_DateToFilter.Value, cb_ProjectFilter.Text.NullIfEmpty(), tb_FilePathFilter.Text.NullIfEmpty()
                    //null, null, cb_ProjectFilter.Text.NullIfEmpty(), tb_FilePathFilter.Text.NullIfEmpty()
                    );

                dgv_DataIOHistory.DataSource = ds_io;
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Failed to fill assets history view." + 
                    Environment.NewLine + 
                    ex.Message +
                    Environment.NewLine +
                    ex.StackTrace
                );
            }
            
        }

        private void btn_RefreshAssetsHistoryView_Click(object sender, EventArgs e)
        {
            UpdateDataViewBinding();
        }
    }
}
