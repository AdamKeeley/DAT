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

            SQL_Stuff conString = new SQL_Stuff();
            using (SqlConnection connection = new SqlConnection(conString.getString()))
            {
                GetDB.GetDataTable(connection, ds_io, "tblDataIORequests",
                    "SELECT RequestID, Project, ChangeDate, ChangeType, RequestedBy, ChangedBy FROM dbo.tblDataIORequests ORDER BY ChangeDate DESC");
                GetDB.GetDataTable(connection, ds_io, "tblAssetsRegister",
                    "SELECT AssetID, AssetName, AssetSha256sum, VreFilePath FROM dbo.tblAssetsRegister");
                GetDB.GetDataTable(connection, ds_io, "tblAssetsChangeLog",
                    "SELECT ChangeID, RequestID, AssetID, ChangeAccepted, RejectionNotes FROM dbo.tblAssetsChangeLog");
                GetDB.GetDataTable(connection, ds_io, "tlkAssetChangeTypes",
                    "SELECT ChangeTypeID, ChangeTypeLabel FROM dbo.tlkAssetChangeTypes");
                GetDB.GetDataTable(connection, ds_io, "tblProject",
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
