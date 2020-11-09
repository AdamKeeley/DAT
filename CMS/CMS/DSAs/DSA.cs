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
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                SQL_Stuff.getDataTable(conn, ds, "tblDsas",
                    @"SELECT DsaID, DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                             DSPT, ISO27001, RequiresEncryption, NoRemoteAccess, DateAdded, LastUpdated
                      FROM dbo.tblDsas");
                SQL_Stuff.getDataTable(conn, ds, "tblDsaNotes",
                    @"SELECT dnID, Dsa, Note, Created, CreatedBy
                      FROM dbo.tblDsaNotes");
                SQL_Stuff.getDataTable(conn, ds, "tblDsasProjects",
                    @"SELECT dpID, DsaID, Project, DateAdded
                      FROM dbo.tblDsasProjects");
                SQL_Stuff.getDataTable(conn, ds, "tblDsaDataOwners",
                    @"SELECT doID, RebrandOf, DataOwnerName
                      FROM dbo.tblDsaDataOwners");
                SQL_Stuff.getDataTable(conn, ds, "tblProject",
                    @"SELECT *
                      FROM dbo.tblProject
                      WHERE ValidTo IS NULL");
                // Add asset register stuff?
            }

            return ds;
        }

        public bool PutDsaData(DsaModel inDsa, List<DsaNoteModel> inDsaNotes, List<DsasProjectsModel> inDsaProjects)
        {
            bool[] success = new bool[3];

            string qryDsas = @"
                INSERT INTO dbo.tblDsas 
                    (DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                     DSPT, ISO27001, RequiresEncryption, NoRemoteAccess, DateAdded)
                OUTPUT INSERTED.DsaID
                VALUES
                    (@DataOwner, @AmendmentOf, @DsaName, @DsaFileLoc, @StartDate, @ExpiryDate,
                     @DSPT, @ISO27001, @RequiresEncryption, @NoRemoteAccess, @DateAdded)
            ";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // tblDsas insert
                    using (SqlCommand cmd = new SqlCommand(cmdText: qryDsas, connection: conn, transaction: trans))
                    {
                        cmd.Parameters.Add("@DataOwner", SqlDbType.Int).Value = inDsa.DataOwner;
                        cmd.Parameters.Add("@AmendmentOf", SqlDbType.Int).Value = inDsa?.AmendmentOf ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@DsaName", SqlDbType.VarChar, 100).Value = inDsa.DsaName;
                        cmd.Parameters.Add("@DsaFileLoc", SqlDbType.VarChar, 200).Value = inDsa.DsaFileLoc;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = 
                            inDsa.StartDate.HasValue ? inDsa.StartDate.Value.Date : (object)DBNull.Value;
                        cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = 
                            inDsa.ExpiryDate.HasValue ? inDsa.ExpiryDate.Value.Date : (object)DBNull.Value;
                        cmd.Parameters.Add("@DSPT", SqlDbType.Bit).Value = inDsa.DSPT;
                        cmd.Parameters.Add("@ISO27001", SqlDbType.Bit).Value = inDsa.ISO27001;
                        cmd.Parameters.Add("@RequiresEncryption", SqlDbType.Bit).Value = inDsa.RequiresEncryption;
                        cmd.Parameters.Add("@NoRemoteAccess", SqlDbType.Bit).Value = inDsa.NoRemoteAccess;
                        cmd.Parameters.Add("@DateAdded", SqlDbType.DateTime).Value = inDsa.DateAdded.Value;

                        inDsa.DsaID = (int)cmd.ExecuteScalar();
                    }
                    success[0] = inDsa.DsaID > 0;

                    // Add new DSA identity to tblDsaNotes insert, then bulk insert
                    foreach (DsaNoteModel note in inDsaNotes)
                    {
                        note.Dsa = inDsa.DsaID;
                    }

                    DataTable tblDsaNotes = inDsaNotes.ToDataTable();
                    int notesRows = SQL_Stuff.insertBulk(tblDsaNotes, "dbo.tblDsaNotes", conn, trans);
                    success[1] = notesRows == tblDsaNotes.Rows.Count;

                    // Add new DSA identity to tblDsasProjects insert, then bulk insert
                    foreach (DsasProjectsModel prj in inDsaProjects)
                    {
                        prj.DsaID = inDsa.DsaID;
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

        public void PutDataOwnerData(DsaDataOwnerModel insertData)
        {
            string query = "INSERT INTO dbo.tblDsaDataOwners (DataOwnerName, RebrandOf) VALUES (@Name, @OldNameID)";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SQL_Stuff.conString;
            conn.Credential = SQL_Stuff.credential;
            using (conn)
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = insertData.DateOwnerName;
                cmd.Parameters.Add("@OldNameID", SqlDbType.Int).Value = insertData.RebrandOf.HasValue ? insertData.RebrandOf : (object)DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> CollectDataOwnersList(DataSet ds)
        {
            List<int> rebrands = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => t.Field<int?>("RebrandOf") != null)
                .Select(t => new List<int> { t.Field<int?>("RebrandOf").GetValueOrDefault() })
                .Distinct().SelectMany(x => x).ToList();
            List<string> dataOwners = ds.Tables["tblDsaDataOwners"].AsEnumerable()
                .Where(t => !rebrands.Contains(t.Field<int>("doID")))
                .OrderBy(p => p.Field<string>("DataOwnerName"))
                .Select(p => p.Field<string>("DataOwnerName"))
                .ToList();
            dataOwners.Insert(0, "");

            return dataOwners;
        }

        public List<DsaBasicsViewModel> CreateDsasBasicView(DataSet ds)
        {
            // Needs DSA table to left outer join with itself to get name of previous DSA versions.
            IEnumerable<DsaBasicsViewModel> dsaQuery =
                from dsa in ds.Tables["tblDsas"].AsEnumerable()
                join own in ds.Tables["tblDsaDataOwners"].AsEnumerable() on dsa.Field<int>("DataOwner") equals own.Field<int>("doID")
                join dsa2 in ds.Tables["tblDsas"].AsEnumerable() on dsa.Field<int?>("AmendmentOf") equals dsa2.Field<int>("DsaID") into dsa2tmp
                from dsa2 in dsa2tmp.DefaultIfEmpty()
                select new DsaBasicsViewModel
                {
                    DsaID = dsa.Field<int>("DsaID"),
                    DataOwner = own.Field<string>("DataOwnerName"),
                    StartDate = dsa.Field<DateTime?>("StartDate"),
                    ExpiryDate = dsa.Field<DateTime?>("ExpiryDate"),
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

        public DsaModel CollectDsasForInsert(DataSet ds, string dataOwner, bool isAmendment, DataGridView dgvAmendment, string fileName, string filePath, DateTime? startDate, DateTime? expiryDate, bool dspt, bool iso27001, bool encryption, bool remote)
        {
            int dataOwnerIndex = (
                    from own in ds.Tables["tblDsaDataOwners"].AsEnumerable()
                    where own.Field<string>("DataOwnerName") == dataOwner
                    select own.Field<int>("doID")
                ).ToList().FirstOrDefault();

            int? amendmentOfID = null;
            if (isAmendment)
            {
                amendmentOfID = (int?)dgvAmendment.SelectedRows[0].Cells["DsaID"].Value;
            }

            DsaModel newDsa = new DsaModel();
            newDsa.DataOwner = dataOwnerIndex;
            newDsa.AmendmentOf = amendmentOfID;
            newDsa.DsaName = fileName;
            newDsa.DsaFileLoc = filePath;
            newDsa.StartDate = startDate;
            newDsa.ExpiryDate = expiryDate;
            newDsa.DSPT = dspt;
            newDsa.ISO27001 = iso27001;
            newDsa.RequiresEncryption = encryption;
            newDsa.NoRemoteAccess = remote;
            newDsa.DateAdded = DateTime.Now;
            newDsa.LastUpdated = null;

            return newDsa;
        }

        public List<DsaNoteModel> CollectDsaNotesForInsert(DataGridView dgvNotes)
        {
            List<DsaNoteModel> newDsaNotes = new List<DsaNoteModel>();
            foreach (DataGridViewRow dr in dgvNotes.Rows)
            {
                newDsaNotes.Add(new DsaNoteModel
                {
                    Note = dr.Cells["Notes"].Value.ToString()
                });
            }
            
            return newDsaNotes;
        }

        public List<DsasProjectsModel> CollectDsaProjectsForInsert(IEnumerable<string> projects)
        {
            List<DsasProjectsModel> newDsaProject = new List<DsasProjectsModel>();
            newDsaProject = projects
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .Select(prj => new DsasProjectsModel { Project = prj })
                .ToList();

            return newDsaProject;
        }
    }
}
