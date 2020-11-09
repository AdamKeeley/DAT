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
using DataControlsLib.ViewModels;

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
                SQL_Stuff.getDataTable(conn, ds_io, "tblDataIORequests",
                    "SELECT RequestID, Project, ChangeDate, ChangeType, RequestedBy, ChangedBy FROM dbo.tblDataIORequests ORDER BY ChangeDate DESC");
                SQL_Stuff.getDataTable(conn, ds_io, "tblAssetsRegister",
                    "SELECT AssetID, AssetName, AssetSha256sum, VreFilePath FROM dbo.tblAssetsRegister");
                SQL_Stuff.getDataTable(conn, ds_io, "tblAssetsChangeLog",
                    "SELECT ChangeID, RequestID, AssetID, ChangeAccepted, RejectionNotes FROM dbo.tblAssetsChangeLog");
                SQL_Stuff.getDataTable(conn, ds_io, "tlkAssetChangeTypes",
                    "SELECT ChangeTypeID, ChangeTypeLabel FROM dbo.tlkAssetChangeTypes");
                SQL_Stuff.getDataTable(conn, ds_io, "tblProject",
                    "SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");
            }
            return ds_io;
        }

        public List<AssetHistoryViewModel> CreateAssetsHistoryView(DataSet ds, DateTime? dateFrom, DateTime? dateTo, string proj, string fPath, List<string> changeTypes, List<bool?> approvals)
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
                    && (changeTypes.Contains(ct.Field<string>("ChangeTypeLabel")))
                    && (approvals.Contains(cl.Field<bool?>("ChangeAccepted")))
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
    }
}
