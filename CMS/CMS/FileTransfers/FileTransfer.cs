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

namespace CMS.FileTransfers
{
    public class FileTransfer
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
                SQL_Stuff.getDataTable(conn, null, ds_io, "tblTransferRequests",
                    @"SELECT RequestID, Project, VreNumber, RequestType, RequestedBy, RequesterNotes, ReviewedBy, ReviewDate, ReviewNotes
                      FROM dbo.tblTransferRequests
                      ORDER BY ReviewDate DESC");
                SQL_Stuff.getDataTable(conn, null, ds_io, "tblAssetsChangeLog",
                    @"SELECT ChangeID, RequestID, FileID, TransferMethod, TransferFrom, TransferTo, DsaReviewed, ChangeAccepted, RejectionNotes 
                      FROM dbo.tblAssetsChangeLog");
                SQL_Stuff.getDataTable(conn, null, ds_io, "tlkTransferRequestTypes",
                    "SELECT RequestTypeID, RequestTypeLabel FROM dbo.tlkTransferRequestTypes");
                SQL_Stuff.getDataTable(conn, null, ds_io, "tlkFileTransferMethods",
                    "SELECT MethodID, MethodLabel FROM dbo.tlkFileTransferMethods");
                SQL_Stuff.getDataTable(conn, null, ds_io, "tblProject",
                    @"SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");
                SQL_Stuff.getDataTable(conn, null, ds_io, "tblProjectPlatformInfo",
                    @"SELECT * FROM dbo.tblProjectPlatformInfo WHERE ValidTo IS NULL");
                GetAssetGroups(ds_io, conn, null);
                GetAssetsRegister(ds_io, conn, null);
                GetDsasData(ds_io, conn, null);
                GetUsersData(ds_io, conn, null);
            }
            return ds_io;
        }

        public void GetAssetGroups(DataSet ds, SqlConnection cn, SqlTransaction tr)
        {
            SQL_Stuff.getDataTable(cn, tr, ds, "tblAssetGroups", "SELECT * FROM dbo.tblAssetGroups");
        }

        public void GetAssetsRegister(DataSet ds, SqlConnection cn, SqlTransaction tr)
        {
            SQL_Stuff.getDataTable(cn, tr, ds, "tblAssetsRegister",
                    @"SELECT FileID, Project, DataFileName, VreFilePath, DataRepoFilePath, AssetID 
                      FROM dbo.tblAssetsRegister");
        }

        public void GetDsasData(DataSet ds, SqlConnection cn, SqlTransaction tr)
        {
            SQL_Stuff.getDataTable(cn, tr, ds, "tblDsas",
                @"SELECT DsaID, DocumentID, DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                             DataDestructionDate, AgreementOwnerEmail, DSPT, ISO27001, RequiresEncryption,
                             NoRemoteAccess, ValidFrom, ValidTo, Deprecated
                      FROM dbo.tblDsas
                      WHERE ValidTo IS NULL
                      ORDER BY DocumentID");
            SQL_Stuff.getDataTable(cn, tr, ds, "tblDsasProjects", "SELECT * FROM dbo.tblDsasProjects WHERE ValidTo IS NULL");
            SQL_Stuff.getDataTable(cn, tr, ds, "tblDsaDataOwners", "SELECT doID, DataOwnerName FROM dbo.tblDsaDataOwners");
        }

        public void GetUsersData(DataSet ds, SqlConnection cn, SqlTransaction tr)
        {
            SQL_Stuff.getDataTable(cn, tr, ds, "tblUser", "SELECT * FROM dbo.tblUser WHERE ValidTo IS NULL");
            SQL_Stuff.getDataTable(cn, tr, ds, "tblUserProject", "SELECT * FROM dbo.tblUserProject WHERE ValidTo IS NULL");
        }

        public void RefreshDsasData(DataSet ds)
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = SQL_Stuff.conString,
                Credential = SQL_Stuff.credential
            };
            using (conn)
            {
                GetDsasData(ds, conn, null);
            }
        }

        public void RefreshUsersData(DataSet ds)
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = SQL_Stuff.conString,
                Credential = SQL_Stuff.credential
            };
            using (conn)
            {
                GetUsersData(ds, conn, null);
            }
        }

        public List<AssetHistoryViewModel> CreateAssetsHistoryView(DataSet ds, DateTime? dateFrom, DateTime? dateTo, string proj, 
                                                                   string owner, string dsa, List<string> transferMethods, string fPath,
                                                                   List<string> changeTypes, List<bool?> approvals)
        {
            IEnumerable<AssetHistoryViewModel> query =
                from cl in ds.Tables["tblAssetsChangeLog"].AsEnumerable()
                join rq in ds.Tables["tblTransferRequests"].AsEnumerable() on cl.Field<int?>("RequestID") equals rq.Field<int>("RequestID")
                join urq in ds.Tables["tblUser"].AsEnumerable() on rq.Field<int?>("RequestedBy") equals urq.Field<int>("UserNumber")
                join urv in ds.Tables["tblUser"].AsEnumerable() on rq.Field<int?>("ReviewedBy") equals urv.Field<int>("UserNumber")
                join ar in ds.Tables["tblAssetsRegister"].AsEnumerable() on cl.Field<int>("FileID") equals ar.Field<int>("FileID")
                join ag in ds.Tables["tblAssetGroups"].AsEnumerable() 
                    on ar.Field<int?>("AssetID") equals ag.Field<int>("AssetID")
                    into AssetsLeftJoin
                from ag2 in AssetsLeftJoin.DefaultIfEmpty()
                join ct in ds.Tables["tlkTransferRequestTypes"].AsEnumerable() on rq.Field<int>("RequestType") equals ct.Field<int>("RequestTypeID")
                join tm in ds.Tables["tlkFileTransferMethods"].AsEnumerable() on cl.Field<int?>("TransferMethod") equals tm.Field<int>("MethodID")
                join da in ds.Tables["tblDsas"].AsEnumerable() on cl.Field<int?>("DsaReviewed") equals da.Field<int>("DsaID")
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
                orderby rq.Field<DateTime?>("ReviewDate") descending
                select new AssetHistoryViewModel
                {
                    Project = rq.Field<string>("Project"),
                    VRE = rq.Field<string>("VreNumber"),
                    DataOwner = dp.Field<string>("DataOwnerName"),
                    ReviewDate = rq.Field<DateTime?>("ReviewDate"),
                    RequestType = ct.Field<string>("RequestTypeLabel"),
                    FileName = ar.Field<string>("DataFileName"),
                    AssetGroup = ag2?.Field<string>("AssetName"),
                    FilePath = ar.Field<string>("VreFilePath"),
                    RepoPath = ar.Field<string>("DataRepoFilePath"),
                    TransferMethod = tm.Field<string>("MethodLabel"),
                    TransferFrom = cl.Field<string>("TransferFrom"),
                    TransferTo= cl.Field<string>("TransferTo"),
                    RequestedBy = urq.Field<string>("FirstName")+" "+ urq.Field<string>("LastName")+" ("+ urq.Field<string>("UserName")+")",
                    DsaReviewed = da.Field<string>("DsaName"),
                    ReviewedBy = urv.Field<string>("FirstName")+" "+ urv.Field<string>("LastName")+" ("+ urv.Field<string>("UserName")+")",
                    ChangeAccepted = cl.Field<bool?>("ChangeAccepted")
                };

            return query.ToList();
        }

        public List<string> GetVreNumbers(DataSet ds, string prj)
        {
            IEnumerable<string> vres = from ppi in ds.Tables["tblProjectPlatformInfo"].AsEnumerable()
                                       where ppi.Field<int>("PlatformInfoID") == 1
                                        && (prj == null || prj == ppi.Field<string>("ProjectNumber"))
                                       select ppi.Field<string>("ProjectPlatformInfo");
            return vres.Distinct().ToList();
        }

        public List<mdl_TransferRequesters> GetRequesters(DataSet ds, string prj)
        {
            // Get users by project, filter to project if selected, then get full name
            // Left join UserProject on User, which is apparently not simple in LINQ...
            IEnumerable<mdl_TransferRequesters> requesters =
                from u in ds.Tables["tblUser"].AsEnumerable()
                join p in ds.Tables["tblUserProject"].AsEnumerable()
                    on u.Field<int>("UserNumber") equals p.Field<int>("UserNumber")
                    into UserPrjGrp
                from upg in UserPrjGrp.DefaultIfEmpty()
                where u.Field<int?>("Status") == 1
                    && u.Field<DateTime?>("ValidTo") == null
                    && (prj == null || prj == upg?.Field<string>("ProjectNumber"))
                orderby u.Field<string>("LastName")
                select new mdl_TransferRequesters
                {
                    UserNumber = u.Field<int>("UserNumber"),
                    FullName = u.Field<string>("LastName") + ", " + u.Field<string>("FirstName")
                };
            // Duplicates if user has multiple projects. Make user distinct
            requesters = requesters.GroupBy(r => r.FullName).Select(grp => grp.FirstOrDefault());
            return requesters.ToList();
        }

        public List<mdl_TransferDsas> GetDsas(DataSet ds, string prj, bool noOldDsas)
        {
            // Get DSA by project, filter to project if selected, then get DSA name
            // Left join DsasProjects on Dsas, which is apparently not simple in LINQ...
            IEnumerable<mdl_TransferDsas> dsas =
                from d in ds.Tables["tblDsas"].AsEnumerable()
                join p in ds.Tables["tblDsasProjects"].AsEnumerable()
                    on d.Field<int>("DocumentID") equals p.Field<int>("DocumentID")
                    into DsaPrjGrp
                from dpg in DsaPrjGrp.DefaultIfEmpty()
                where (prj == null || prj == dpg?.Field<string>("Project"))
                orderby d.Field<string>("DsaName")
                select new mdl_TransferDsas
                {
                    DocumentID = d.Field<int>("DocumentID"),
                    AmendmentOf = d.Field<int?>("AmendmentOf"),
                    DsaName = d.Field<string>("DsaName")
                };

            if (noOldDsas)
            {
                // Get list of DSA IDs which have been superseded by amendments
                List<int> amended = ds.Tables["tblDsas"].AsEnumerable()
                    .Where(t => t.Field<int?>("AmendmentOf") != null)
                    .Select(t => new List<int> { t.Field<int?>("AmendmentOf").GetValueOrDefault() })
                    .Distinct().SelectMany(x => x).ToList();
                // Filter DSAs which have been superseded by amendments
                dsas = dsas.Where(d => !amended.Contains(d.DocumentID));
            }

            // Duplicates if user has multiple projects. Make user distinct
            dsas = dsas.GroupBy(r => r.DsaName).Select(grp => grp.FirstOrDefault());
            return dsas.ToList();
        }

        public bool ValidateTransferInput(string prj, string vre, string rt, string rq, string rv, string dsa, string tm, int fc)
        {
            // Are any required variables missing or is files list empty
            bool missingInfo = String.IsNullOrWhiteSpace(prj) ||
                String.IsNullOrWhiteSpace(vre) ||
                String.IsNullOrWhiteSpace(rt) ||
                String.IsNullOrWhiteSpace(rq) ||
                String.IsNullOrWhiteSpace(rv) ||
                String.IsNullOrWhiteSpace(dsa) ||
                String.IsNullOrWhiteSpace(tm) ||
                fc == 0;

            if (missingInfo)
            {
                string missingMsg = "You are missing required information:\n\n";
                if (String.IsNullOrWhiteSpace(prj)) missingMsg += "Project number\n";
                if (String.IsNullOrWhiteSpace(vre)) missingMsg += "VRE number\n";
                if (String.IsNullOrWhiteSpace(rt)) missingMsg += "Requested transfer type\n";
                if (String.IsNullOrWhiteSpace(rq)) missingMsg += "Name of requester\n";
                if (String.IsNullOrWhiteSpace(rv)) missingMsg += "Name of reviewer\n";
                if (String.IsNullOrWhiteSpace(dsa)) missingMsg += "DSA title\n";
                if (String.IsNullOrWhiteSpace(tm)) missingMsg += "Transfer method used\n";
                if (fc == 0) missingMsg += "No files were added to the transfer record\n";
                MessageBox.Show(missingMsg, "Missing information", MessageBoxButtons.OK);

                return false;
            }

            return true;
        }

        public mdl_TransferRequests CollectTransferRequestInsert(DataSet ds, string prj, string vre, string rt, 
                                                                 string rq, string rv, DateTime rd)
        {
            int rtID = ds.Tables["tlkTransferRequestTypes"].AsEnumerable()
                .Where(x => x.Field<string>("RequestTypeLabel") == rt)
                .Select(x => x.Field<int>("RequestTypeID")).ToList().FirstOrDefault();

            int rqID = ds.Tables["tblUser"].AsEnumerable()
                .Where(x => rq == x.Field<string>("LastName")+", "+x.Field<string>("FirstName"))
                .Select(x => x.Field<int>("UserNumber")).ToList().Distinct().FirstOrDefault();

            int rvID = ds.Tables["tblUser"].AsEnumerable()
                .Where(x => rv == x.Field<string>("LastName") + ", " + x.Field<string>("FirstName"))
                .Select(x => x.Field<int>("UserNumber")).ToList().Distinct().FirstOrDefault();

            mdl_TransferRequests tr = new mdl_TransferRequests
            {
                Project = prj,
                VreNumber = vre,
                RequestType = rtID,
                RequestedBy = rqID,
                ReviewedBy = rvID,
                ReviewDate = rd
            };

            return tr;
        }

        // Returns empty obj if no assets assigned or no new assets assigned
        public List<mdl_AssetGroups> CollectAssetGroupsInsert(DataSet ds, string prj, DataGridView assets)
        {
            if (assets.RowCount == 0) return new List<mdl_AssetGroups>();
            
            List<string> uniqAssets = assets.Rows.OfType<DataGridViewRow>()
                .Select(r => r.Cells["AssetName"].Value.ToString())
                .Distinct().ToList();

            List<string> existingAssets = ds.Tables["tblAssetGroups"].AsEnumerable()
                .Where(p => p.Field<string>("Project") == prj)
                .Select(x => x.Field<string>("AssetName")).ToList();

            return uniqAssets.Where(x => !existingAssets.Contains(x))
                .Select(x => new mdl_AssetGroups { Project = prj, AssetName = x }).ToList();
        }

        public List<mdl_AssetsRegister> CollectAssetsRegisterInsert(string prj, DataGridView files, string vreDir, string repoDir)
        {
            List<mdl_AssetsRegister> newFiles = new List<mdl_AssetsRegister>();
            foreach (DataGridViewRow dr in files.Rows)
            {
                newFiles.Add(new mdl_AssetsRegister
                {
                    Project = prj,
                    DataFileName = dr.Cells["FileName"].Value.ToString(),
                    VreFilePath = vreDir,
                    DataRepoFilePath = repoDir
                });
            }

            return newFiles;
        }

        public List<mdl_AssetsChangeLog> CollectAssetsChangeLogInsert(DataSet ds, int req, DataGridView files, DataGridView rej,
                                                                      string tm, string tf, string tt, string dsa)
        {
            // Get dsa id
            int dsaID = ds.Tables["tblDsas"].AsEnumerable()
                .Where(x => dsa == x.Field<string>("DsaName"))
                .Select(x => x.Field<int>("DsaID")).ToList().Distinct().FirstOrDefault();
            // Get transfer method id
            int tmID = ds.Tables["tlkFileTransferMethods"].AsEnumerable()
                .Where(x => tm == x.Field<string>("MethodLabel"))
                .Select(x => x.Field<int>("MethodID")).ToList().FirstOrDefault();

            // Collect file IDs for files being added to change log
            var fileIDs = from fs in files.Rows.OfType<DataGridViewRow>()
                          join ar in ds.Tables["tblAssetsRegister"].AsEnumerable()
                            on fs.Cells["FileName"].Value.ToString() equals ar.Field<string>("DataFileName")
                          select new
                          {
                              FileID = ar.Field<int>("FileID"),
                              FileName = fs.Cells["FileName"].Value.ToString()
                          };

            var rjs = from rj in rej.Rows.OfType<DataGridViewRow>()
                      select new
                      {
                          FileName = rj.Cells["FileName"].Value.ToString(),
                          RejectionReason = rj.Cells["RejectionReason"].Value.ToString()
                      };

            // Left join rejections to file IDs list
            var clData = from fids in fileIDs
                         join rj in rjs on fids.FileName equals rj.FileName into fidsAndRejs
                         from fr in fidsAndRejs.DefaultIfEmpty()
                         select new
                         {
                             fids.FileName,
                             fids.FileID,
                             fr?.RejectionReason
                         };

            // foreach to put files in mdl list - see CollectAssetsRegisterInsert()
            List <mdl_AssetsChangeLog> cls = new List<mdl_AssetsChangeLog>();
            foreach (var cl in clData)
            {
                cls.Add(new mdl_AssetsChangeLog
                {
                    RequestID = req,
                    FileID = cl.FileID,
                    TransferMethod = tmID,
                    TransferFrom = tf,
                    TransferTo = tt,
                    DsaReviewed = dsaID,
                    ChangeAccepted = cl.RejectionReason.NullIfEmpty() == null,
                    RejectionNotes = cl.RejectionReason
                });
            }

            return cls;
        }

        public bool PutTransferRecords(DataSet ds, string prj, string vre, string rt, string rq, string rv, DateTime rd, 
                                       DataGridView assets, DataGridView files, string vreDir, string repoDir, 
                                       string tm, string tf, string tt, string dsa, DataGridView rej)
        {
            bool[] success = new bool[4];

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // tblTransferRequests insert
                    mdl_TransferRequests tr = CollectTransferRequestInsert(ds, prj, vre, rt, rq, rv, rd);
                    string trQry = @"
                        INSERT INTO dbo.tblTransferRequests (Project, VreNumber, RequestType, RequestedBy, ReviewedBy, ReviewDate)
                        OUTPUT INSERTED.RequestID
                        VALUES (@Project, @VreNumber, @RequestType, @RequestedBy, @ReviewedBy, @ReviewDate)";
                    using (SqlCommand cmd = new SqlCommand(cmdText: trQry, connection: conn, transaction: trans))
                    {
                        cmd.Parameters.Add("@Project", SqlDbType.VarChar, 5).Value = tr.Project;
                        cmd.Parameters.Add("@VreNumber", SqlDbType.VarChar, 5).Value = tr.VreNumber;
                        cmd.Parameters.Add("@RequestType", SqlDbType.Int).Value = tr.RequestType;
                        cmd.Parameters.Add("@RequestedBy", SqlDbType.Int).Value = tr.RequestedBy;
                        cmd.Parameters.Add("@ReviewedBy", SqlDbType.Int).Value = tr.ReviewedBy;
                        cmd.Parameters.Add("@ReviewDate", SqlDbType.DateTime).Value =
                            tr.ReviewDate.HasValue ? tr.ReviewDate.Value.Date : (object)DBNull.Value;
                        // Execute insert and get the newly created ID
                        tr.RequestID = (int)cmd.ExecuteScalar();
                    }
                    success[0] = tr.RequestID > 0;

                    // tblAssetGroups insert
                    List<mdl_AssetGroups> ag = CollectAssetGroupsInsert(ds, prj, assets);
                    if (ag.Any())
                    {
                        int agRows = SQL_Stuff.insertBulk(ag.ToDataTable(), "dbo.tblAssetGroups", conn, trans);
                        success[1] = agRows == ag.Count();
                        // Query tblAssetGroups again to get all new IDs for use in further inserts
                        GetAssetGroups(ds, conn, trans);
                    }
                    else
                    {
                        success[1] = true;
                    }

                    // tblAssetsRegister insert
                    List<mdl_AssetsRegister> ar = CollectAssetsRegisterInsert(prj, files, vreDir, repoDir);
                    // If there are any assets, join asset ID to ar before doing bulk insert
                    if (ag.Any())
                    {
                        // Join asset IDs to the assets DGV
                        var assetsWithID = from a1 in assets.Rows.OfType<DataGridViewRow>()
                                           join a2 in ds.Tables["tblAssetGroups"].AsEnumerable()
                                               on a1.Cells["AssetName"].Value.ToString() equals a2.Field<string>("AssetName")
                                           select new
                                           {
                                               FileName = a1.Cells["FileName"].Value.ToString(),
                                               AssetName = a1.Cells["AssetName"].Value.ToString(),
                                               AssetID = a2.Field<int>("AssetID")
                                           };
                        // Join assets data to the new assets register records
                        IEnumerable<mdl_AssetsRegister> arTmp =
                            from a1 in ar
                            join a2 in assetsWithID on a1.DataFileName equals a2.FileName into FilesWithAssetInfo
                            from a3 in FilesWithAssetInfo.DefaultIfEmpty()
                            select new mdl_AssetsRegister
                            {
                                Project = a1.Project,
                                DataFileName = a1.DataFileName,
                                VreFilePath = a1.VreFilePath,
                                DataRepoFilePath = a1.DataRepoFilePath,
                                AssetID = a3?.AssetID
                            };
                        //ar = arTmp.GroupBy(x => x.DataFileName, (key, grp) => grp.First()).ToList();
                        ar = arTmp.ToList();
                    }

                    int arRows = SQL_Stuff.insertBulk(ar.ToDataTable(), "dbo.tblAssetsRegister", conn, trans);
                    success[2] = arRows == ar.Count();
                    // Get new FileIDs by re-querying the tbl
                    GetAssetsRegister(ds, conn, trans);

                    // tblAssetsChangeLog insert
                    List<mdl_AssetsChangeLog> cl = CollectAssetsChangeLogInsert(ds, tr.RequestID, files, rej, tm, tf, tt, dsa);
                    int clRows = SQL_Stuff.insertBulk(cl.ToDataTable(), "dbo.tblAssetsChangeLog", conn, trans);
                    success[3] = clRows == cl.Count();

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Failed to add new file transfer record(s):" + ex.GetType() + "\n\n" +
                        ex.Message + "\n\n" +
                        ex.StackTrace
                    );
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(
                            "Failed to roll back transaction:" + ex2.GetType() + "\n\n" +
                            ex2.Message + "\n\n" +
                            ex2.StackTrace
                        );
                    }
                }
            }

            return !success.Contains(false);
        }
    }
}
