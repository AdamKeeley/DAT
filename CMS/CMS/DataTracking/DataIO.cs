using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataControlsLib;
using DataControlsLib.DataModels;

namespace CMS.DataTracking
{
    public class DataIO
    {
        public DataSet GetAssetsHistoryDataSet()
        {
            DataSet ds_io = new DataSet("AssetsHistory");

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                GetDB.GetDataTable(conn, ds_io, "tblDataIORequests",
                    "SELECT RequestID, Project, ChangeDate, ChangeType, RequestedBy, ChangedBy FROM dbo.tblDataIORequests ORDER BY ChangeDate DESC");
                GetDB.GetDataTable(conn, ds_io, "tblAssetsRegister",
                    "SELECT AssetID, AssetName, AssetSha256sum, VreFilePath FROM dbo.tblAssetsRegister");
                GetDB.GetDataTable(conn, ds_io, "tblAssetsChangeLog",
                    "SELECT ChangeID, RequestID, AssetID, ChangeAccepted, RejectionNotes FROM dbo.tblAssetsChangeLog");
                GetDB.GetDataTable(conn, ds_io, "tlkAssetChangeTypes",
                    "SELECT ChangeTypeID, ChangeTypeLabel FROM dbo.tlkAssetChangeTypes");
                GetDB.GetDataTable(conn, ds_io, "tblProject",
                    "SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");

                // Relations not needed due to LINQ joins, but at least they help enforce the schema
                ds_io.Relations.Add("DataIORequests_AssetChangeTypes",
                    parentColumn: ds_io.Tables["tlkAssetChangeTypes"].Columns["ChangeTypeID"],
                    childColumn: ds_io.Tables["tblDataIORequests"].Columns["ChangeType"]);
                ds_io.Relations.Add("AssetsChangeLog_DataIORequests",
                    parentColumn: ds_io.Tables["tblDataIORequests"].Columns["RequestID"],
                    childColumn: ds_io.Tables["tblAssetsChangeLog"].Columns["RequestID"]);
                ds_io.Relations.Add("AssetsChangeLog_AssetsRegister",
                    parentColumn: ds_io.Tables["tblAssetsRegister"].Columns["AssetID"],
                    childColumn: ds_io.Tables["tblAssetsChangeLog"].Columns["AssetID"]);
            }
            return ds_io;
        }
    }
}
