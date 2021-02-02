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

            SqlConnection conn = new SqlConnection
            {
                ConnectionString = SQL_Stuff.conString,
                Credential = SQL_Stuff.credential
            };
            using (conn)
            {
                SQL_Stuff.getDataTable(conn, ds_io, "tblTransferRequests",
                    @"SELECT RequestID, Project, RequestType, RequestedBy, RequesterNotes, ReviewedBy, ReviewDate, ReviewNotes
                      FROM dbo.tblTransferRequests
                      ORDER BY ReviewDate DESC");
                SQL_Stuff.getDataTable(conn, ds_io, "tblAssetsRegister",
                    "SELECT FileID, Project, DataFileName, Sha256sum, VreFilePath, DataRepoFilePath, AssetID FROM dbo.tblAssetsRegister");
                SQL_Stuff.getDataTable(conn, ds_io, "tblAssetsChangeLog",
                    @"SELECT ChangeID, RequestID, FileID, TransferMethod, TransferFrom, TransferTo, DsaReviewed, ChangeAccepted, RejectionNotes 
                      FROM dbo.tblAssetsChangeLog");
                SQL_Stuff.getDataTable(conn, ds_io, "tblAssetGroups",
                    @"SELECT AssetID, Project, AssetName FROM dbo.tblAssetGroups");
                SQL_Stuff.getDataTable(conn, ds_io, "tblDsas",
                    "SELECT DsaID, DataOwner, DsaName FROM dbo.tblDsas");
                SQL_Stuff.getDataTable(conn, ds_io, "tblDsaDataOwners",
                    "SELECT doID, DataOwnerName FROM dbo.tblDsaDataOwners");
                SQL_Stuff.getDataTable(conn, ds_io, "tlkTransferRequestTypes",
                    "SELECT RequestTypeID, RequestTypeLabel FROM dbo.tlkTransferRequestTypes");
                SQL_Stuff.getDataTable(conn, ds_io, "tlkFileTransferMethods",
                    "SELECT MethodID, MethodLabel FROM dbo.tlkFileTransferMethods");
                SQL_Stuff.getDataTable(conn, ds_io, "tblProject",
                    @"SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");
            }
            return ds_io;
        }

        public List<AssetHistoryViewModel> CreateAssetsHistoryView(DataSet ds, DateTime? dateFrom, DateTime? dateTo, string proj, 
                                                                   string owner, string dsa, List<string> transferMethods, string fPath,
                                                                   List<string> changeTypes, List<bool?> approvals)
        {
            IEnumerable<AssetHistoryViewModel> query =
                from cl in ds.Tables["tblAssetsChangeLog"].AsEnumerable()
                join rq in ds.Tables["tblTransferRequests"].AsEnumerable() on cl.Field<int>("RequestID") equals rq.Field<int>("RequestID")
                join ar in ds.Tables["tblAssetsRegister"].AsEnumerable() on cl.Field<int>("FileID") equals ar.Field<int>("FileID")
                join ag in ds.Tables["tblAssetGroups"].AsEnumerable() on ar.Field<int>("AssetID") equals ag.Field<int>("AssetID")
                join ct in ds.Tables["tlkTransferRequestTypes"].AsEnumerable() on rq.Field<int>("RequestType") equals ct.Field<int>("RequestTypeID")
                join tm in ds.Tables["tlkFileTransferMethods"].AsEnumerable() on cl.Field<int>("TransferMethod") equals tm.Field<int>("MethodID")
                join da in ds.Tables["tblDsas"].AsEnumerable() on cl.Field<int>("DsaReviewed") equals da.Field<int>("DsaID")
                join dp in ds.Tables["tblDsaDataOwners"].AsEnumerable() on da.Field<int>("DataOwner") equals dp.Field<int>("doID")
                where (dateFrom == null || (rq.Field<DateTime?>("ReviewDate").HasValue && (dateFrom <= rq.Field<DateTime?>("ReviewDate").Value.Date)))
                    && (dateTo == null || (rq.Field<DateTime?>("ReviewDate").HasValue && (dateTo >= rq.Field<DateTime?>("ReviewDate").Value.Date)))
                    && (proj == null || (proj == rq.Field<string>("Project").NullIfEmpty()))
                    && (owner == null || (owner == dp.Field<string>("DataOwnerName")))
                    && (dsa == null || (dsa == da.Field<string>("DsaName").NullIfEmpty()))
                    && (transferMethods.Contains(tm.Field<string>("MethodLabel")))
                    && (fPath == null || ar.Field<string>("VreFilePath").NullIfEmpty().Contains(fPath))
                    && (changeTypes.Contains(ct.Field<string>("RequestTypeLabel")))
                    && (approvals.Contains(cl.Field<bool?>("ChangeAccepted")))
                select new AssetHistoryViewModel
                {
                    Project = rq.Field<string>("Project"),
                    DataOwner = dp.Field<string>("DataOwnerName"),
                    ReviewDate = rq.Field<DateTime?>("ReviewDate"),
                    RequestType = ct.Field<string>("RequestTypeLabel"),
                    FileName = ar.Field<string>("DataFileName"),
                    AssetGroup = ag.Field<string>("AssetName"),
                    FilePath = ar.Field<string>("VreFilePath"),
                    RepoPath = ar.Field<string>("DataRepoFilePath"),
                    Checksum = ar.Field<string>("Sha256sum"),
                    TransferMethod = tm.Field<string>("MethodLabel"),
                    TransferFrom = cl.Field<string>("TransferFrom"),
                    TransferTo= cl.Field<string>("TransferTo"),
                    RequestedBy = rq.Field<string>("RequestedBy"),
                    DsaReviewed = da.Field<string>("DsaName"),
                    ReviewedBy = rq.Field<string>("ReviewedBy"),
                    ChangeAccepted = cl.Field<bool?>("ChangeAccepted")
                };

            return query.ToList();
        }
    }
}
