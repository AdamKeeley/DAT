using DataControlsLib;
using DataControlsLib.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.RIDM
{
    class Kristal
    {
        /// <summary>
        /// Method to return a DataSet (ds_prj) with content of SQL table dbo.tblProjects, dbo.tblProjectNotes, 
        /// dbo.tblUsers and other related lookup tables. 
        /// Creates DataRelations so that dimension tables can be linked to values in the measures table.
        /// </summary>
        /// <returns>
        /// Full DataSet containing tables of all currently valid project records and asociated user/lookup tables.
        /// </returns>
        public DataSet getKristalDataSet()
        {
            DataSet ds_krs = new DataSet("Kristal");

            try
            {
                //use the central connection string from the SQL_Stuff class
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tblKristal",
                        $"select * from [dbo].[tblKristal] " +
                        $"where [ValidTo] is null " +
                        $"order by [KristalRef], [KristalID]");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tlkGrantStage",
                        $"select * from [dbo].[tlkGrantStage] order by StageNumber asc");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tblProjectKristal",
                        $"select * from [dbo].[tblProjectKristal] " +
                        $"where [ValidTo] is null " +
                        $"order by [KristalRef], [ProjectNumber]");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "vw_AllProjects",
                        $"select * from [dbo].[vw_AllProjects]" +
                        $"order by [ProjectNumber]");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tblKristalNotes",
                        $"select * from [dbo].[tblKristalNotes]");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tblUser",
                        $"select *, [LastName] + ', ' + [FirstName] as FullName " +
                        $"from [dbo].[tblUser] " +
                        $"where [ValidTo] is null " +
                        $"order by [LastName], [FirstName], [UserID]");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tlkLocation",
                        $"select * " +
                        $"from [dbo].[tlkLocation] " +
                        $"where [ValidTo] is null");
                    SQL_Stuff.getDataTable(conn, null, ds_krs, "tlkFaculty",
                        $"select * " +
                        $"from [dbo].[tlkFaculty] " +
                        $"where [ValidTo] is null");

                    ds_krs.Relations.Add("Kristal_GrantStage"
                        , ds_krs.Tables["tlkGrantStage"].Columns["GrantStageID"]                    //parent
                        , ds_krs.Tables["tblKristal"].Columns["GrantStageID"], false);              //child
                    ds_krs.Relations.Add("Kristal_Project"
                        , ds_krs.Tables["vw_AllProjects"].Columns["ProjectNumber"]
                        , ds_krs.Tables["tblProjectKristal"].Columns["ProjectNumber"], false);
                    ds_krs.Relations.Add("Grant_PI"
                        , ds_krs.Tables["tblUser"].Columns["UserNumber"]
                        , ds_krs.Tables["tblKristal"].Columns["PI"], false);
                    ds_krs.Relations.Add("Kristal_Location"
                        , ds_krs.Tables["tlkLocation"].Columns["locationID"]
                        , ds_krs.Tables["tblKristal"].Columns["Location"], false);
                    ds_krs.Relations.Add("Kristal_Faculty"
                    , ds_krs.Tables["tlkFaculty"].Columns["facultyID"]
                    , ds_krs.Tables["tblKristal"].Columns["Faculty"], false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate ds_krs DataSet" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return ds_krs;
        }

        /// <summary>
        /// Logically delete a record from [dbo].[tblKristal] based on primary key
        /// </summary>
        /// <param name="KristalID"></param>
        /// <returns>TRUE on successful deletion, FALSE on a fail</returns>
        public bool deleteKristal(int KristalID)
        {
            try
            {
                //update ValidTo field of current record (perform 'logical' delete)
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryRemoveKristal = new SqlCommand();
                    qryRemoveKristal.Connection = conn;
                    qryRemoveKristal.CommandText = $"update [dbo].[tblKristal] " +
                        $"set[ValidTo] = getdate() " +
                        $"where[ValidTo] is null " +
                        $"and [KristalID] = @KristalID";
                    qryRemoveKristal.Parameters.Add("@KristalID", SqlDbType.Int).Value = KristalID;
                    conn.Open();
                    qryRemoveKristal.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex);
                return false;
            }
        }

        /// <summary>
        /// Logically delete a record from [dbo].[tblProjectKristal] based on primary key
        /// </summary>
        /// <param name="ProjectKristalRefID"></param>
        /// <returns>TRUE on successful deletion, FALSE on a fail</returns>
        public bool deleteProjectKristal(int ProjectKristalID)
        {
            try
            {
                //update ValidTo field of current record (perform 'logical' delete)
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryRemoveProjectKristal = new SqlCommand();
                    qryRemoveProjectKristal.Connection = conn;
                    qryRemoveProjectKristal.CommandText = $"update [dbo].[tblProjectKristal] " +
                        $"set[ValidTo] = getdate() " +
                        $"where[ValidTo] is null " +
                        $"and [ProjectKristalID] = @ProjectKristalID";
                    qryRemoveProjectKristal.Parameters.Add("@ProjectKristalID", SqlDbType.Int).Value = ProjectKristalID;
                    conn.Open();
                    qryRemoveProjectKristal.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex);
                return false;
            }
        }

        /// <summary>
        /// On successful insert of ProjectKristal record, inserts new Kristal record if required
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="insKristal"></param>
        /// <returns>TRUE on successful insert of a tblProjectKrystal record, FALSE on a fail</returns>
        public bool insertProjectKristalReference(string pNumber, mdl_Kristal insKristal)
        {
            if (insertProjectKristal(pNumber, insKristal.KristalRef))
            {
                insertKristal(insKristal);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Takes a Kristal reference and queries [dbo].[tblKristal] for current values.
        /// </summary>
        /// <param name="KristalRef"></param>
        /// <returns>Returns populated mdl_Kristal if preseant, empty if not</returns>
        public mdl_Kristal fetchCurrentKristal(int KristalID)
        {
            mdl_Kristal kristal = new mdl_Kristal();
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryCheckKristal = new SqlCommand();
                    qryCheckKristal.Connection = conn;
                    qryCheckKristal.CommandText = $"select * from [dbo].[tblKristal] where [KristalID] = @KristalID and ValidTo is null";
                    qryCheckKristal.Parameters.Add("@KristalID", SqlDbType.Int).Value = KristalID;
                    conn.Open();

                    SqlDataReader reader = qryCheckKristal.ExecuteReader();
                    while (reader.Read())
                    {
                        kristal.KristalID = Convert.ToInt32(reader["KristalID"].ToString());
                        kristal.KristalRef = Convert.ToInt32(reader["KristalRef"].ToString());
                        kristal.KristalName = reader["KristalName"].ToString();
                        kristal.GrantStageID = Convert.ToInt32(reader["GrantStageID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to query database for Kristal ID " + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return kristal;
        }

        /// <summary>
        /// Takes a Project Number & Kristal Reference and queries [dbo].[tblProjectKristal] to see if relationship is already present.
        /// </summary>
        /// <param name="KristalRef"></param>
        /// <returns>TRUE if present, FALSE if not</returns>
        public bool checkProjectKristalExists(string pNumber, int KristalRef)
        {
            int? ProjectKristalID = null;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryCheckProjectKristal = new SqlCommand();
                    qryCheckProjectKristal.Connection = conn;
                    qryCheckProjectKristal.CommandText = $"select max([ProjectKristalID]) from [dbo].[tblProjectKristal] where [ProjectNumber] = @projectNumber and " +
                        "[KristalRef] = @KristalRef and ValidTo is null";
                    qryCheckProjectKristal.Parameters.Add("@projectNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryCheckProjectKristal.Parameters.Add("@KristalRef", SqlDbType.Int).Value = KristalRef;
                    conn.Open();
                    ProjectKristalID = qryCheckProjectKristal.ExecuteScalar() as int?;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to query database for Kristal ref " + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            if (ProjectKristalID == null)
                return false;
            else
            {
                MessageBox.Show("Kristal Reference already on project record");
                return true;
            }
        }

        /// <summary>
        /// Inserts a new Kristal Reference to [dbo].[tblKristal] if not already present. 
        /// Logically deletes and inserts new record if already present.
        /// </summary>
        /// <param name="insKristal"></param>
        /// <returns>TRUE on insert, FALSE on no insert</returns>
        public int insertKristal(mdl_Kristal insKristal)
        {
            mdl_Kristal existingKristal = fetchCurrentKristal(insKristal.KristalRef);
            int newKristalID = 0;

            //if the kristal record already exists and there is no difference.
            if (existingKristal == insKristal)
                return newKristalID;

            //if the kristal reference exists with different attributes it needs updating
            //  logical delete before insert
            if (existingKristal.KristalRef == insKristal.KristalRef & existingKristal != insKristal)
                deleteKristal(existingKristal.KristalID);

            //insert a kristal reference if needs updating or if doesn't already exist
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryInsertKristal = new SqlCommand();
                    qryInsertKristal.Connection = conn;
                    qryInsertKristal.CommandText = $"insert into [dbo].[tblKristal] " +
                        "([KristalRef], [KristalName], [GrantStageID]) " +
                        "output inserted.KristalID values " +
                        "(@KristalRef, @KristalName, @GrantStageID)";
                    qryInsertKristal.Parameters.Add("@KristalRef", SqlDbType.Int).Value = insKristal.KristalRef;
                    qryInsertKristal.Parameters.Add("@KristalName", SqlDbType.VarChar,4000).Value = insKristal.KristalName;
                    qryInsertKristal.Parameters.Add("@GrantStageID", SqlDbType.Int).Value = insKristal.GrantStageID;
                    //open connection and execute insert
                    conn.Open();
                    newKristalID = (int)qryInsertKristal.ExecuteScalar();
                    //qryInsertKristal.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new Kristal Ref to database" + Environment.NewLine + ex.Message);
            }
            return newKristalID;
        }

        /// <summary>
        /// Creates a relationship between Kristal Reference and Project Number on [dbo].[tblProjectKristal] 
        /// if not already present
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="KristalRef"></param>
        /// <returns>TRUE on insert, FALSE on fail</returns>
        public bool insertProjectKristal(string pNumber, int KristalRef)
        {
            if (checkProjectKristalExists(pNumber, KristalRef) == false)
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = SQL_Stuff.conString;
                    conn.Credential = SQL_Stuff.credential;
                    using (conn)
                    {
                        //create parameterised SQL query to insert a new record to tblProjectNotes
                        SqlCommand qryInsertProjectKristalRef = new SqlCommand();
                        qryInsertProjectKristalRef.Connection = conn;
                        qryInsertProjectKristalRef.CommandText = $"insert into [dbo].[tblProjectKristal] " +
                            "([ProjectNumber], [KristalRef]) values (@pNumber, @KristalRef)";
                        qryInsertProjectKristalRef.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                        qryInsertProjectKristalRef.Parameters.Add("@KristalRef", SqlDbType.Int).Value = KristalRef;
                        //open connection and execute insert
                        conn.Open();
                        qryInsertProjectKristalRef.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add Kristal Ref to Project" + Environment.NewLine + ex.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Method to leave a kristal note.
        /// Takes parameter kristalRef to link to grant and kristalNote as the note value.
        /// Adds them both to the SQL query as parameters and executes an insert on dbo.tblKristalNotes.
        /// </summary>
        /// <param name="kristalRef"></param>
        /// <param name="kristalNote"></param>
        public void insertKristalNote(int kristalRef, string kristalNote)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryInsertKristalNote = new SqlCommand();
                    qryInsertKristalNote.Connection = conn;
                    qryInsertKristalNote.CommandText = "insert into [dbo].[tblKristalNotes] "
                        + "([KristalRef],[KristalNote]) values (@KristalRef, @KristalNote)";
                    qryInsertKristalNote.Parameters.Add("@KristalRef", SqlDbType.Int).Value = kristalRef;
                    qryInsertKristalNote.Parameters.Add("@KristalNote", SqlDbType.VarChar, 8000).Value = kristalNote;

                    //open connection and execute insert
                    conn.Open();
                    qryInsertKristalNote.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new note" + Environment.NewLine + ex.Message);
                throw;
            }
        }
    }
}
