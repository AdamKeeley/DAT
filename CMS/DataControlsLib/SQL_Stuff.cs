using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace DataControlsLib
{
    /// <summary>
    /// Static class that contains variables that can be accessed throughout the solution. Contains a static variable 
    /// to store login credentials (SQL_Stuff.credential, captured from frm_login) and another to store connection 
    /// string (SQL_Stuff.conString, populated from member method called from frm_login).
    /// </summary>
    public static class SQL_Stuff
    {
        /// <summary>
        /// Define whether application connects to test or live database. 
        /// Aceptable values are "test" or "live".
        /// </summary>
        ///public static string env = "live";
        public static string env = "test";

        /// <summary>
        /// Static variable to store login credentials for CMS database. Used to populate Credential  
        /// property of a new SqlConnection. Using it directly risks garbage collection clearing it after SQL operation.
        /// </summary>
        public static SqlCredential credential { get; set; }

        /// <summary>
        /// Static variable to store connection string for CMS database. Used to populate ConnectionString 
        /// property of a new SqlConnection. Using it directly risks garbage collection clearing it after SQL operation.
        /// </summary>
        public static string conString { get; set; }
        
        /// <summary>
        /// Uses a SqlConnectionStringBuilder to construct the connection string and place it into a 
        /// static variable within this static class. 
        /// </summary>
        public static void setString()
        {
            if (env == "live")
            {
                //Azure LIVE!
                SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder
                {
                    ["Data Source"] = "lida-dat-cms.database.windows.net",
                    ["Initial Catalog"] = "lida_dat_cms",
                    ["Integrated Security"] = "False",
                    ["Persist Security Info"] = "False",
                    ["Encrypt"] = "True",
                };
                conString = conStringBuilder.ConnectionString;
            }

            if (env == "test")
            {
                //Azure TEST
                SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder
                {
                    ["Data Source"] = "lida-dat-cms-test.database.windows.net",
                    ["Initial Catalog"] = "lida_dat_cms_test",
                    ["Integrated Security"] = "False",
                    ["Persist Security Info"] = "False",
                    ["Encrypt"] = "True",
                };
                conString = conStringBuilder.ConnectionString;
            }

            ////Adam's LIDA desktop
            //conString = "Data Source=IRC-PC010;Initial Catalog=DAT_CMS;Integrated Security=True";

            ////Adam's laptop
            //conString = "Data Source=LIDA-LT-040704\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";

            //// Sean's laptop
            //conString = "Data Source=SEAN-LAPTOP\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";
        }

        public static void getDataTable(SqlConnection cnn, SqlTransaction tr, DataSet dsObj, string tblName, string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand qry = new SqlCommand();
            qry.CommandText = sql;
            qry.Connection = cnn;
            qry.Transaction = tr;
            da.SelectCommand = qry;
            da.Fill(dsObj, tblName);
        }

        public static int insertBulk(DataTable dt, string tbl, SqlConnection cn, SqlTransaction tr)
        {
            int nrows = 0;

            using (SqlBulkCopy blk = new SqlBulkCopy(cn, SqlBulkCopyOptions.Default, tr))
            {
                blk.DestinationTableName = tbl;
                blk.NotifyAfter = dt.Rows.Count;
                blk.SqlRowsCopied += (s, e) => nrows = (int)e.RowsCopied;
                blk.WriteToServer(dt);
            }

            return nrows;
        }

    }
}

