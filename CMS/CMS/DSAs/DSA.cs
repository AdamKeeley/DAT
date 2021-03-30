using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DataControlsLib;
using DataControlsLib.DataModels;
using DataControlsLib.ViewModels;

namespace CMS.DSAs
{
    public class DSA
    {
        public DataSet GetDsaData()
        {
            DataSet ds = new DataSet("DSAs");
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = SQL_Stuff.conString,
                Credential = SQL_Stuff.credential
            };
            using (conn)
            {
                SQL_Stuff.getDataTable(conn, null, ds, "tblDsas",
                    @"SELECT DsaID, DocumentID, DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                             DataDestructionDate, AgreementOwnerEmail, DSPT, ISO27001, RequiresEncryption,
                             NoRemoteAccess, ValidFrom, ValidTo, Deprecated
                      FROM dbo.tblDsas
                      WHERE ValidTo IS NULL
                      ORDER BY DocumentID");
                SQL_Stuff.getDataTable(conn, null, ds, "tblDsaNotes",
                    @"SELECT dnID, Dsa, Note, Created, CreatedBy FROM dbo.tblDsaNotes");
                SQL_Stuff.getDataTable(conn, null, ds, "tblDsasProjects",
                    @"SELECT dpID, DocumentID, Project, ValidFrom, ValidTo FROM dbo.tblDsasProjects WHERE ValidTo IS NULL");
                SQL_Stuff.getDataTable(conn, null, ds, "tblDsaDataOwners",
                    @"SELECT doID, DataOwnerName, RebrandOf, DataOwnerEmail FROM dbo.tblDsaDataOwners");
                SQL_Stuff.getDataTable(conn, null, ds, "tblProject",
                    @"SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");
            }

            return ds;
        }

        public mdl_Dsas GetDsaRecord(DataSet ds, int id)
        {
            mdl_Dsas dr = ds.Tables["tblDsas"].AsEnumerable()
                .Where(x => x.Field<int>("DocumentID") == id)
                .Select(x => new mdl_Dsas
                {
                    DsaID = x.Field<int>("DsaID"),
                    ID = x.Field<int>("DocumentID"),
                    DataOwner = x.Field<int>("DataOwner"),
                    AmendmentOf = x.Field<int?>("AmendmentOf"),
                    DsaName = x.Field<string>("DsaName"),
                    DsaFileLoc = x.Field<string>("DsaFileLoc"),
                    StartDate = x.Field<DateTime?>("StartDate"),
                    ExpiryDate = x.Field<DateTime?>("ExpiryDate"),
                    DataDestructionDate = x.Field<DateTime?>("DataDestructionDate"),
                    AgreementOwnerEmail = x.Field<string>("AgreementOwnerEmail"),
                    DSPT = x.Field<bool>("DSPT"),
                    ISO27001 = x.Field<bool>("ISO27001"),
                    RequiresEncryption = x.Field<bool>("RequiresEncryption"),
                    NoRemoteAccess = x.Field<bool>("NoRemoteAccess"),
                    ValidFrom = x.Field<DateTime?>("ValidFrom"),
                    ValidTo = x.Field<DateTime?>("ValidTo"),
                    Deprecated = x.Field<bool>("Deprecated")
                })
                .FirstOrDefault();
            return dr;
        }

        public List<string> GetDsaProjectsList(DataSet ds, int id)
        {
            List<string> prjs = ds.Tables["tblDsasProjects"].AsEnumerable()
                .Where(x => x.Field<int>("DocumentID") == id)
                .Select(x => x.Field<string>("Project")).ToList();
            return prjs;
        }

        public List<mdl_DsaNotes> GetDsaNotes(DataSet ds, int id)
        {
            List<mdl_DsaNotes> dns = ds.Tables["tblDsaNotes"].AsEnumerable()
                .Where(x => x.Field<int>("Dsa") == id)
                .Select(x => new mdl_DsaNotes
                {
                    dnID = x.Field<int>("dnID"),
                    Dsa = x.Field<int>("Dsa"),
                    Note = x.Field<string>("Note"),
                    Created = x.Field<DateTime?>("Created"),
                    CreatedBy = x.Field<string>("CreatedBy")
                }).ToList();
            return dns;
        }

        public bool PutDsaData(mdl_Dsas inDsa, List<mdl_DsaNotes> inDsaNotes, List<mdl_DsasProjects> inDsaProjects,
                               mdl_Dsas rcrd)
        {
            if (rcrd.ID > 0 && rcrd == inDsa && inDsaNotes.Count == 0 && inDsaProjects.Count == 0)
            {
                MessageBox.Show("No changes to DSA record, nothing to update.\n", "DSA Not Updated", MessageBoxButtons.OK);
                return false;
            }
            
            bool[] success = new bool[3];

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // If DSA record already exists and new data is equal to old, do not perform insert
                    if (rcrd.ID > 0 && rcrd == inDsa)
                    {
                        success[0] = true;
                    }
                    else
                    {
                        // tblDsas insert
                        string qryDsas = @"
                            INSERT INTO dbo.tblDsas (DocumentID, DataOwner, AmendmentOf, DsaName, 
                                DsaFileLoc, StartDate, ExpiryDate, DataDestructionDate, AgreementOwnerEmail, 
                                DSPT, ISO27001, RequiresEncryption, NoRemoteAccess)
                            OUTPUT INSERTED.DsaID
                            VALUES (@DocumentID, @DataOwner, @AmendmentOf, @DsaName, @DsaFileLoc, @StartDate, 
                                @ExpiryDate, @DataDestructionDate, @AgreementOwnerEmail, @DSPT, @ISO27001, 
                                @RequiresEncryption, @NoRemoteAccess)";

                        using (SqlCommand cmd = new SqlCommand(cmdText: qryDsas, connection: conn, transaction: trans))
                        {
                            cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = inDsa.ID;
                            cmd.Parameters.Add("@DataOwner", SqlDbType.Int).Value = inDsa.DataOwner;
                            cmd.Parameters.Add("@AmendmentOf", SqlDbType.Int).Value = inDsa?.AmendmentOf ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@DsaName", SqlDbType.VarChar, 100).Value = inDsa.DsaName;
                            cmd.Parameters.Add("@DsaFileLoc", SqlDbType.VarChar, 200).Value = inDsa.DsaFileLoc;
                            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value =
                                inDsa.StartDate.HasValue ? inDsa.StartDate.Value.Date : (object)DBNull.Value;
                            cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value =
                                inDsa.ExpiryDate.HasValue ? inDsa.ExpiryDate.Value.Date : (object)DBNull.Value;
                            cmd.Parameters.Add("@DataDestructionDate", SqlDbType.DateTime).Value =
                                inDsa.DataDestructionDate.HasValue ? inDsa.DataDestructionDate.Value.Date : (object)DBNull.Value;
                            cmd.Parameters.Add("@AgreementOwnerEmail", SqlDbType.VarChar, 50).Value = inDsa.AgreementOwnerEmail;
                            cmd.Parameters.Add("@DSPT", SqlDbType.Bit).Value = inDsa.DSPT;
                            cmd.Parameters.Add("@ISO27001", SqlDbType.Bit).Value = inDsa.ISO27001;
                            cmd.Parameters.Add("@RequiresEncryption", SqlDbType.Bit).Value = inDsa.RequiresEncryption;
                            cmd.Parameters.Add("@NoRemoteAccess", SqlDbType.Bit).Value = inDsa.NoRemoteAccess;

                            inDsa.DsaID = (int)cmd.ExecuteScalar();
                        }
                        success[0] = inDsa.DsaID > 0;

                        // If new DSA record, update DocumentID to be new dsa ID --> inDsa.DsaID
                        if (inDsa.ID == 0 && rcrd.ID == 0)
                        {
                            string setDocID = @"UPDATE dbo.tblDsas SET DocumentID = @ID WHERE DsaID = @ID";
                            using (SqlCommand cmd = new SqlCommand(cmdText: setDocID, connection: conn, transaction: trans))
                            {
                                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = inDsa.DsaID;
                                cmd.ExecuteNonQuery();
                                inDsa.ID = inDsa.DsaID;
                            }
                        }
                        else if (inDsa.DsaID != rcrd.DsaID) // If this is a DSA update, logical delete previous record
                        {
                            string setValidTo = @"UPDATE dbo.tblDsas SET ValidTo = @NOW WHERE DsaID = @DsaID";
                            using (SqlCommand cmd = new SqlCommand(cmdText: setValidTo, connection: conn, transaction: trans))
                            {
                                DateTime timestamp = DateTime.Now;
                                cmd.Parameters.Add("@NOW", SqlDbType.DateTime).Value = timestamp;
                                cmd.Parameters.Add("@DsaID", SqlDbType.Int).Value = rcrd.DsaID;
                                cmd.ExecuteNonQuery();
                                rcrd.ValidTo = timestamp;
                            }
                        }
                    }

                    // Add new DSA identity to tblDsaNotes insert, then bulk insert
                    foreach (mdl_DsaNotes note in inDsaNotes)
                    {
                        note.Dsa = inDsa.ID;
                    }

                    DataTable tblDsaNotes = inDsaNotes.ToDataTable();
                    int notesRows = SQL_Stuff.insertBulk(tblDsaNotes, "dbo.tblDsaNotes", conn, trans);
                    success[1] = notesRows == tblDsaNotes.Rows.Count;

                    // Add new DSA identity to tblDsasProjects insert, then bulk insert
                    foreach (mdl_DsasProjects prj in inDsaProjects)
                    {
                        prj.DocumentID = inDsa.ID;
                    }

                    DataTable tblDsasProjects = inDsaProjects.ToDataTable();
                    int prjRows = SQL_Stuff.insertBulk(tblDsasProjects, "dbo.tblDsasProjects", conn, trans);
                    success[2] = prjRows == tblDsasProjects.Rows.Count;

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Failed to add new DSA record:" + ex.GetType() + "\n\n" +
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

        public void PutDataOwnerData(mdl_DsaDataOwners insertData)
        {
            string query = @"INSERT INTO dbo.tblDsaDataOwners (DataOwnerName, RebrandOf, DataOwnerEmail) 
                             VALUES (@Name, @OldNameID, @Email)";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = insertData.DateOwnerName;
                cmd.Parameters.Add("@OldNameID", SqlDbType.Int).Value = insertData.RebrandOf.HasValue ? insertData.RebrandOf : (object)DBNull.Value;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = insertData.DataOwnerEmail;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public object CollectDataOwnersList(DataSet ds, bool noOldDOs)
        {
            var dataOwners = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .OrderBy(p => p.Field<string>("DataOwnerName"))
                .Select(p => new
                {
                    doID = p.Field<int>("doID"),
                    DataOwnerName = p.Field<string>("DataOwnerName")
                })
                .ToList();

            if (noOldDOs)
            {
                List<int> rebrands = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                    .Where(t => t.Field<int?>("RebrandOf") != null)
                    .Select(t => new List<int> { t.Field<int?>("RebrandOf").GetValueOrDefault() })
                    .Distinct().SelectMany(x => x).ToList();

                dataOwners = dataOwners.Where(t => !rebrands.Contains(t.doID)).ToList();
            }

            dataOwners.Insert(0, new { doID = -1, DataOwnerName = "" });

            return dataOwners;
        }

        public List<DsaBasicsViewModel> CreateDsasBasicView(DataSet ds)
        {
            // Needs DSA table to left outer join with itself to get name of previous DSA versions.
            IEnumerable<DsaBasicsViewModel> dsaQuery =
                from dsa in ds.Tables["tblDsas"].AsEnumerable()
                join own in ds.Tables["tblDsaDataOwners"].AsEnumerable() on dsa.Field<int>("DataOwner") equals own.Field<int>("doID")
                join dsa2 in ds.Tables["tblDsas"].AsEnumerable() on dsa.Field<int?>("AmendmentOf") equals dsa2.Field<int>("DocumentID") into dsa2tmp
                from dsa2 in dsa2tmp.DefaultIfEmpty()
                select new DsaBasicsViewModel
                {
                    DocumentID = dsa.Field<int>("DocumentID"),
                    DataOwner = own.Field<string>("DataOwnerName"),
                    StartDate = dsa.Field<DateTime?>("StartDate"),
                    ExpiryDate = dsa.Field<DateTime?>("ExpiryDate"),
                    DataDestructionDate = dsa.Field<DateTime?>("DataDestructionDate"),
                    DsaName = dsa.Field<string>("DsaName"),
                    FilePath = dsa.Field<string>("DsaFileLoc"),
                    AmendmentOf = dsa2?.Field<string>("DsaName"),
                    DSPT = dsa.Field<bool>("DSPT"),
                    ISO27001 = dsa.Field<bool>("ISO27001"),
                    RequiresEncryption = dsa.Field<bool>("RequiresEncryption"),
                    NoRemoteAccess = dsa.Field<bool>("NoRemoteAccess")
                };

            return dsaQuery.ToList();
        }

        public object CreateDsasProjectsView(DataSet ds)
        {
            var prjs = from prj in ds.Tables["tblProject"].AsEnumerable()
                       orderby prj.Field<string>("ProjectNumber")
                       select new
                       {
                           Project = prj.Field<string>("ProjectNumber"),
                           Title = prj.Field<string>("ProjectName")
                       };

            return prjs.ToList();
        }

        public bool ValidateInputs(string fileName, string filePath, string dataOwner)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show(
                    text: "You haven't given a File Name for the DSA, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            if (String.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show(
                    text: "You haven't specified the File Path where the DSA file is stored, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            if (String.IsNullOrWhiteSpace(dataOwner))
            {
                MessageBox.Show(
                    text: "You haven't specified a data owner, which is required.\n",
                    caption: "Missing information",
                    buttons: MessageBoxButtons.OK
                );
                return false;
            }

            return true;
        }

        public mdl_Dsas CollectDsasForInsert(DataSet ds, int dataOwner, bool isAmendment, DataGridView dgvAmendment, string fileName, 
                                             string filePath, DateTime? startDate, DateTime? expiryDate, DateTime? destroyDate, 
                                             string ownerEmail, bool dspt, bool iso27001, bool encryption, bool remote)
        {
            int? amendmentOfID = null;
            if (isAmendment)
            {
                amendmentOfID = (int?)dgvAmendment.SelectedRows[0].Cells["DocumentID"].Value;
            }

            mdl_Dsas newDsa = new mdl_Dsas
            {
                DataOwner = dataOwner,
                AmendmentOf = amendmentOfID,
                DsaName = fileName,
                DsaFileLoc = filePath,
                StartDate = startDate,
                ExpiryDate = expiryDate,
                DataDestructionDate = destroyDate,
                AgreementOwnerEmail = ownerEmail,
                DSPT = dspt,
                ISO27001 = iso27001,
                RequiresEncryption = encryption,
                NoRemoteAccess = remote
            };

            return newDsa;
        }

        public List<mdl_DsaNotes> CollectDsaNotesForInsert(DataGridView dgvNotes, DataSet ds, mdl_Dsas rcrd)
        {
            List<mdl_DsaNotes> currentDsaNotes = GetDsaNotes(ds, rcrd.ID);
            List<string> existingNotes = currentDsaNotes.Select(x => x.Note).ToList();
            List<DateTime?> existingCreateds = currentDsaNotes.Select(x => x.Created).ToList();
            List<mdl_DsaNotes> newDsaNotes = new List<mdl_DsaNotes>();

            foreach (DataGridViewRow dr in dgvNotes.Rows)
            {
                string created = dr.Cells["Created"].Value.ToString().NullIfEmpty();
                DateTime? date = created == null ? (DateTime?)null : DateTime.Parse(created);
                string note = dr.Cells["Notes"].Value.ToString();
                mdl_DsaNotes noteRow = new mdl_DsaNotes { Note = note, Created = date };

                bool skip = false;
                foreach(mdl_DsaNotes n in currentDsaNotes)
                {
                    skip = noteRow == n;
                    if (skip) break;
                }

                if (!skip)
                {
                    newDsaNotes.Add(new mdl_DsaNotes { Note = note, Created = date });
                }
            }

            return newDsaNotes;
        }

        public List<mdl_DsasProjects> CollectDsaProjectsForInsert(DataSet ds, mdl_Dsas rcrd, IEnumerable<string> projects)
        {
            List<mdl_DsasProjects> newDsaProject = projects.Select(prj => new mdl_DsasProjects { Project = prj }).ToList();

            // If this is a DSA update, not DSA create, omit existing DSA-Project links from the insert
            if (rcrd != null && rcrd.ID > 0)
            {
                List<string> currentPrjLinks = GetDsaProjectsList(ds, rcrd.ID);
                newDsaProject = newDsaProject.Where(x => !currentPrjLinks.Contains(x.Project)).ToList();
            }

            return newDsaProject;
        }

        public List<DataOwnersViewModel> CreateDataOwnerGridView(DataSet ds, string searchTxt)
        {
            List<DataOwnersViewModel> dataOwners = (
                from do1 in ds.Tables["tblDsaDataOwners"].AsEnumerable()
                join do2 in ds.Tables["tblDsaDataOwners"].AsEnumerable() on do1.Field<int?>("RebrandOf") equals do2.Field<int>("doID") into do2tmp
                orderby do1.Field<string>("DataOwnerName")
                from do2 in do2tmp.DefaultIfEmpty()
                where searchTxt == null
                    || ((do1 == null) ? false : do1.Field<string>("DataOwnerName").ToLower().Contains(searchTxt))
                    || ((do2 == null) ? false : do2.Field<string>("DataOwnerName").ToLower().Contains(searchTxt))
                select new DataOwnersViewModel
                {
                    DataOwner = do1.Field<string>("DataOwnerName"),
                    RebrandingOf = do2?.Field<string>("DataOwnerName")
                }).ToList();

            return dataOwners;
        }
    }
}
