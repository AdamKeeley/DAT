using DataControlsLib;
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
        /// <param name="GrantStageID"></param>
        /// <param name="KristalRef"></param>
        /// <returns>TRUE on successful insert of a tblProjectKrystal record, FALSE on a fail</returns>
        public bool insertProjectKristalReference(string pNumber, int GrantStageID, int KristalRef)
        {
            if (insertProjectKristal(pNumber, KristalRef))
            {
                insertKristal(KristalRef, GrantStageID);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Takes a Kristal reference and queries [dbo].[tblKristal] to see if it is already present.
        /// </summary>
        /// <param name="KristalRef"></param>
        /// <returns>Returns the KristalID if preseant, null if not</returns>
        public int?[] checkKristalExists(int KristalRef)
        {
            int?[] Kristal = new int?[2];
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryCheckKristal = new SqlCommand();
                    qryCheckKristal.Connection = conn;
                    qryCheckKristal.CommandText = $"select top 1 [KristalID], [GrantStageID] from [dbo].[tblKristal] where [KristalRef] = @KristalRef and ValidTo is null";
                    qryCheckKristal.Parameters.Add("@KristalRef", SqlDbType.Int).Value = KristalRef;
                    conn.Open();

                    SqlDataReader reader = qryCheckKristal.ExecuteReader();
                    while (reader.Read())
                    {
                        Kristal[0] = Convert.ToInt32(reader["KristalID"].ToString());
                        Kristal[1] = Convert.ToInt32(reader["GrantStageID"].ToString());
                    }

                    //KristalID = qryCheckKristal.ExecuteScalar() as int?;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to query database for Kristal ref " + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return Kristal;
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
        /// Inserts a new Kristal Reference to [dbo].[tblKristal] if not already present
        /// </summary>
        /// <param name="KristalRef"></param>
        /// <param name="GrantStageID"></param>
        /// <returns>TRUE on insert, FALSE on no insert</returns>
        public bool insertKristal(int KristalRef, int selectedGrantStageID)
        {
            int?[] existingKristal = checkKristalExists(KristalRef);
            int? existingKristalID = existingKristal[0];
            int? existingKristalGrantStageID = existingKristal[1];

            //if the kristal reference already exists and has the same stage as is selected do nothing.
            if (existingKristalID != null & existingKristalGrantStageID == selectedGrantStageID)
                return false;

            //if the kristal reference exists with a different stage it needs updating
            //  logical delete before insert
            if (existingKristalID != null & existingKristalGrantStageID != selectedGrantStageID)
                deleteKristal((int)existingKristalID);

            //insert a kristal reference
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
                        "([KristalRef], GrantStageID) values (@KristalRef, @GrantStageID)";
                    qryInsertKristal.Parameters.Add("@KristalRef", SqlDbType.Int).Value = KristalRef;
                    qryInsertKristal.Parameters.Add("@GrantStageID", SqlDbType.Int).Value = selectedGrantStageID;
                    //open connection and execute insert
                    conn.Open();
                    qryInsertKristal.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new Kristal Ref to database" + Environment.NewLine + ex.Message);
                return false;
            }
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
    }
}
