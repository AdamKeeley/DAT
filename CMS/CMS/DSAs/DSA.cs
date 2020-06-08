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

namespace CMS.DSAs
{
    public class DSA
    {
        public DataSet GetDsaData()
        {
            DataSet ds = new DataSet("DSAs");

            SQL_Stuff conString = new SQL_Stuff();
            using (SqlConnection connection = new SqlConnection(conString.getString()))
            {
                GetDB.GetDataTable(connection, ds, "tblDsas",
                    @"SELECT DsaID, DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                             DSPT, ISO27001, RequiresEncryption, NoRemoteAccess, DateAdded, LastUpdated
                      FROM dbo.tblDsas");
                GetDB.GetDataTable(connection, ds, "tblDsaNotes",
                    @"SELECT dnID, Dsa, Note, Created, CreatedBy
                      FROM dbo.tblDsaNotes");
                GetDB.GetDataTable(connection, ds, "tblDsasProjects",
                    @"SELECT dpID, DsaID, Project, DateAdded
                      FROM dbo.tblDsasProjects");
                GetDB.GetDataTable(connection, ds, "tblDsaDataOwners",
                    @"SELECT doID, RebrandOf, DataOwnerName
                      FROM dbo.tblDsaDataOwners");
                GetDB.GetDataTable(connection, ds, "tblProject",
                    @"SELECT *
                      FROM dbo.tblProject
                      WHERE ValidTo IS NULL");
                // Add asset register stuff?
            }

            // Relations not needed due to LINQ joins, but at least they help enforce the schema
            ds.Relations.Add("AmendmentOf_DsaID_",
                    parentColumn: ds.Tables["tblDsas"].Columns["DsaID"],
                    childColumn: ds.Tables["tblDsas"].Columns["AmendmentOf"]);
            ds.Relations.Add("Dsas_DsaDataOwners",
                    parentColumn: ds.Tables["tblDsaDataOwners"].Columns["doID"],
                    childColumn: ds.Tables["tblDsas"].Columns["DataOwner"]);
            ds.Relations.Add("DsasProjects_Dsas",
                    parentColumn: ds.Tables["tblDsas"].Columns["DsaID"],
                    childColumn: ds.Tables["tblDsasProjects"].Columns["DsaID"]);
            ds.Relations.Add("RebrandOf_doID",
                    parentColumn: ds.Tables["tblDsaDataOwners"].Columns["doID"],
                    childColumn: ds.Tables["tblDsaDataOwners"].Columns["RebrandOf"]);

            return ds;
        }

        public bool PutDsaData(DsaModel inDsa, List<DsaNoteModel> inDsaNotes, List<DsasProjectsModel> inDsaProjects)
        {
            bool[] success = new bool[3];

            SQL_Stuff conString = new SQL_Stuff();

            string qryDsas = @"
                INSERT INTO dbo.tblDsas 
                    (DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, 
                     DSPT, ISO27001, RequiresEncryption, NoRemoteAccess, DateAdded)
                OUTPUT INSERTED.DsaID
                VALUES
                    (@DataOwner, @AmendmentOf, @DsaName, @DsaFileLoc, @StartDate, @ExpiryDate,
                     @DSPT, @ISO27001, @RequiresEncryption, @NoRemoteAccess, @DateAdded)
            ";

            using (SqlConnection conn = new SqlConnection(conString.getString()))
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
                    int notesRows = PutDB.InsertBulk(tblDsaNotes, "dbo.tblDsaNotes", conn, trans);
                    success[1] = notesRows == tblDsaNotes.Rows.Count;

                    // Add new DSA identity to tblDsasProjects insert, then bulk insert
                    foreach (DsasProjectsModel prj in inDsaProjects)
                    {
                        prj.DsaID = inDsa.DsaID;
                    }

                    DataTable tblDsasProjects = inDsaProjects.ToDataTable();
                    int prjRows = PutDB.InsertBulk(tblDsasProjects, "dbo.tblDsasProjects", conn, trans);
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

            SQL_Stuff conString = new SQL_Stuff();

            using (SqlConnection connection = new SqlConnection(conString.getString()))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = insertData.DateOwnerName;
                cmd.Parameters.Add("@OldNameID", SqlDbType.Int).Value = insertData.RebrandOf.HasValue ? insertData.RebrandOf : (object)DBNull.Value;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
