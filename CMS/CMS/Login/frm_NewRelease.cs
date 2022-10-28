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

        /// <summary>
        /// Class variable to store URL.
        /// </summary>
        string releaseURL = null;

        /// <summary>
        /// Queries database for value in ReleaseURL field of versioning table where ValidFrom matches passed parameter.
        /// If value found, set's text to releaseURL if value found.
        /// </summary>
        /// <param name="latestRelease"></param>
        private void setReleaseUrl(DateTime latestRelease)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                SqlCommand qryGetReleaseUrl = new SqlCommand();
                qryGetReleaseUrl.Connection = conn;
                qryGetReleaseUrl.CommandText = $"select isnull(ReleaseURL, '') from [dbo].[versioning] where ValidFrom = '{latestRelease.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and ValidTo is null";

                conn.Open();
                releaseURL = (string)qryGetReleaseUrl.ExecuteScalar();
            }

            if (releaseURL.NullIfEmpty() != null)
                lnk_NewReleaseUrl.Text = releaseURL;
        }

        /// <summary>
        /// If class variable contains a value, navigate to URL it holds when link clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnk_NewReleaseUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (releaseURL.NullIfEmpty() != null)
            {
                lnk_NewReleaseUrl.LinkVisited = true;
                System.Diagnostics.Process.Start(releaseURL);
            }
        }

        private void btn_frm_NewReleaseClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //this.Close();
        }

    }
}
