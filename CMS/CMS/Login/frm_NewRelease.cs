using DataControlsLib;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CMS.Login
{
    public partial class frm_NewRelease : Form
    {
        public frm_NewRelease(DateTime latestRelease)
        {
            InitializeComponent();
            setReleaseUrl(latestRelease);
        }

        string releaseURL = null;

        private void setReleaseUrl(DateTime latestRelease)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                SqlCommand qryGetReleaseUrl = new SqlCommand();
                qryGetReleaseUrl.Connection = conn;
                qryGetReleaseUrl.CommandText = $"select ReleaseURL from [dbo].[versioning] where ValidFrom = '{latestRelease.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and ValidTo is null";

                conn.Open();
                releaseURL = (string)qryGetReleaseUrl.ExecuteScalar();
            }

            if (releaseURL != null)
                lnk_NewReleaseUrl.Text = releaseURL;
        }

        private void btn_frm_NewReleaseClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnk_NewReleaseUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (releaseURL != null)
            {
                lnk_NewReleaseUrl.LinkVisited = true;
                System.Diagnostics.Process.Start(releaseURL);
            }
        }
    }
}
