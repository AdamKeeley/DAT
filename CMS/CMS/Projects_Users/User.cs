using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib;

namespace CMS
{
    class User
    {
        /// <summary>
        /// Constructor - used to instantiate each User type object.
        /// Contains methods to query and update database records relating to Users.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Method to return a DataSet (ds_usr) with content of SQL table dbo.tblUser, dbo.tblUserNotes 
        /// and other related lookup tables. 
        /// Creates DataRelations so that dimension tables can be linked to values in the measures table.
        /// </summary>
        /// <returns></returns>
        public DataSet getUsersDataSet()
        {
            DataSet ds_usr = new DataSet("Users");
            try
            {
                //use the central connection string from the SQL_Stuff class
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //use method from GetDB to create, fill and add DataTables to class DataSet
                    GetDB.GetDataTable(connection, ds_usr, "tblUser",
                        $"select *, [LastName] + ', ' + [FirstName] as FullName " +
                        $"from [dbo].[tblUser] " +
                        $"where [ValidTo] is null " +
                        $"order by [LastName], [FirstName], [UserID]");
                    GetDB.GetDataTable(connection, ds_usr, "tlkUserStatus",
                        $"select * from [dbo].[tlkUserStatus] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_usr, "tlkTitle",
                        $"select * from [dbo].[tlkTitle] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_usr, "tblUserNotes",
                        $"select * from [dbo].[tblUserNotes]");
                    GetDB.GetDataTable(connection, ds_usr, "tblUserProject",
                        $"select * from [dbo].[tblUserProject] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_usr, "tblProjects",
                        $"select * from [dbo].[tblProject] " +
                        $"where [ValidTo] is null " +
                        $"order by [ProjectNumber], [pID]");
                    //create a DataRelations to join dimensions to measures
                    ds_usr.Relations.Add("User_UserStatus"
                        , ds_usr.Tables["tlkUserStatus"].Columns["StatusID"]    //parent
                        , ds_usr.Tables["tblUser"].Columns["Status"]);          //child
                    ds_usr.Relations.Add("User_Title"
                        , ds_usr.Tables["tlkTitle"].Columns["TitleID"]
                        , ds_usr.Tables["tblUser"].Columns["Title"]);                                                            //datarelation
                    ds_usr.Relations.Add("UserProject_Project"
                        , ds_usr.Tables["tblProjects"].Columns["ProjectNumber"]     
                        , ds_usr.Tables["tblUserProject"].Columns["ProjectNumber"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to populate ds_usr DataSet" + Environment.NewLine + Environment.NewLine + e);
                //throw;
            }

            //return DataSet (ds_usr) as the output of this method
            return ds_usr;
        }

        public List<object> getUserToList(int UserNumber, DataSet ds_User)
        {
            int         UserID;
            int?        Status          = null;
            int?        Title           = null;
            string      FirstName;
            string      LastName;
            string      Email;
            string      Phone;
            string      UserName;
            string      Organisation;
            DateTime?   StartDate       = null;
            DateTime?   EndDate         = null;
            bool        Priviledged;
            DateTime?   IRCAgreement    = null;
            DateTime?   ISET            = null;
            DateTime?   ISAT            = null;
            DateTime?   SAFE            = null;
            long?       TokenSerial     = null;
            DateTime?   TokenIssued     = null;
            DateTime?   TokenReturned   = null;

            List<object> lst_User = new List<object>();

            //if no records found, try will fail at "DataRow uRow = uRows[i];" and go to catch
            try
            {
                DataRow[] uRows = ds_User.Tables["tblUser"].Select($"UserNumber = '{UserNumber}'");
                //there's always a small a chance a user might have multiple records where ValidTo is null
                //DataSet (ds_usr) is populated ordered by names and then UserID so largest (last added) UserID for each user is last
                //feed back to operator if more than one 'current' project record
                if (uRows.Count() > 1)
                {
                    MessageBox.Show("More than one current record found for this user, showing last only. Please contact a system administrator.");
                }

                //active row (uRow) filled with last row from uRows
                int i = uRows.Count() - 1;
                DataRow uRow = uRows[i];

                //populate DataRow to output with values from uRow
                UserID = (int)uRow["UserID"];
                if (uRow["Status"].ToString().Length > 0)
                    Status = (int?)uRow["Status"];
                if (uRow["Title"].ToString().Length > 0)
                    Title = (int?)uRow["Title"];
                FirstName = uRow["FirstName"].ToString();
                LastName = uRow["LastName"].ToString();
                Email = uRow["Email"].ToString();
                Phone = uRow["Phone"].ToString();
                UserName = uRow["UserName"].ToString();
                Organisation = uRow["Organisation"].ToString();
                if (uRow["StartDate"].ToString().Length > 0)
                    StartDate = (DateTime?)uRow["StartDate"];
                if (uRow["EndDate"].ToString().Length > 0)
                    EndDate = (DateTime?)uRow["EndDate"];
                Priviledged = (bool)uRow["Priviledged"];
                if (uRow["IRCAgreement"].ToString().Length > 0)
                    IRCAgreement = (DateTime?)uRow["IRCAgreement"];
                if (uRow["ISET"].ToString().Length > 0)
                    ISET = (DateTime?)uRow["ISET"];
                if (uRow["ISAT"].ToString().Length > 0)
                    ISAT = (DateTime?)uRow["ISAT"];
                if (uRow["SAFE"].ToString().Length > 0)
                    SAFE = (DateTime?)uRow["SAFE"];
                if (uRow["TokenSerial"].ToString().Length > 0)
                    TokenSerial = (long?)uRow["TokenSerial"];
                if (uRow["TokenIssued"].ToString().Length > 0)
                    TokenIssued = (DateTime?)uRow["TokenIssued"];
                if (uRow["TokenReturned"].ToString().Length > 0)
                    TokenReturned = (DateTime?)uRow["TokenReturned"];

                lst_User.Add(UserID);
                lst_User.Add(UserNumber);
                lst_User.Add(Status);
                lst_User.Add(Title);
                lst_User.Add(FirstName);
                lst_User.Add(LastName);
                lst_User.Add(Email);
                lst_User.Add(Phone);
                lst_User.Add(UserName);
                lst_User.Add(Organisation);
                lst_User.Add(StartDate);
                lst_User.Add(EndDate);
                lst_User.Add(Priviledged);
                lst_User.Add(IRCAgreement);
                lst_User.Add(ISET);
                lst_User.Add(ISAT);
                lst_User.Add(SAFE);
                lst_User.Add(TokenSerial);
                lst_User.Add(TokenIssued);
                lst_User.Add(TokenReturned);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user details" + Environment.NewLine + Environment.NewLine + ex);
                throw;
            }

            return lst_User;
        }

        public void insertUserNote(int UserNumber, string uNote)
        {
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create parameterised SQL query to insert a new record to tblUserNotes
                    SqlCommand qryInsertUserNote = new SqlCommand();
                    qryInsertUserNote.Connection = connection;
                    qryInsertUserNote.CommandText = "insert into [dbo].[tblUserNotes] "
                        + "([UserNumber],[uNote]) values (@UserNumber, @uNote)";
                    qryInsertUserNote.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                    qryInsertUserNote.Parameters.Add("@uNote", SqlDbType.VarChar, 8000).Value = uNote;

                    //open connection and execute insert
                    connection.Open();
                    qryInsertUserNote.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new note" + Environment.NewLine + ex);
                throw;
            }
        }

        /// <summary>
        /// Method to check whether the primary key of the record currently being read is the same as the primary 
        /// key of the latest record for that project.
        /// Takes parameter UserNumber and queries the database with it, returning the UserID for the latest record.
        /// Returns 'true' if returned UserID matches paramter current_UserID, 'false' if not.
        /// Defaults to false in case of error, better to not update if something's wrong.
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="current_UserID"></param>
        /// <returns></returns>
        public bool checkCurrentRecord(int UserNumber, int current_UserID)
        {
            int? UserID = null;
            bool recordCurrent = false;
            try
            {
                //update ValidUntil field of current record of project (perform 'logical' delete)
                SQL_Stuff conString = new SQL_Stuff();

                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    SqlCommand qryCheckLatestRecord = new SqlCommand();
                    qryCheckLatestRecord.Connection = connection;
                    qryCheckLatestRecord.CommandText = $"select max([UserID]) from [DAT_CMS].[dbo].[tblUser] where [UserNumber] = @UserNumber and ValidTo is null";
                    qryCheckLatestRecord.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                    connection.Open();
                    UserID = (int)qryCheckLatestRecord.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find current record" + Environment.NewLine + Environment.NewLine + ex);
            }

            if (current_UserID == UserID)
                recordCurrent = true;
            return recordCurrent;
        }

        /// <summary>
        /// Method to 'delete' user record from SQL Server database.
        /// Doesn't actually delete any records, takes the parameter UserID (primary key) and updates record with todays 
        /// date, performing a logical delete.
        /// </summary>
        /// <param name="UserID"></param>
        public void deleteUser(int UserID)
        {
            try
            {
                //update ValidUntil field of current record of user (perform 'logical' delete)
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    SqlCommand qryDeleteUser = new SqlCommand();
                    qryDeleteUser.Connection = connection;
                    qryDeleteUser.CommandText = "update [dbo].[tblUser] set [ValidTo] = getdate() where [UserID] = @UserID";
                    qryDeleteUser.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    connection.Open();
                    qryDeleteUser.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex);
            }
        }

        /// <summary>
        /// Method to insert a new project record into dbo.tblProject.
        /// Takes all field values as parameters, adds them to a SQL query string as parameters then executes an insert.
        /// Returns a boolean true on success, defaults to false
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Name"></param>
        /// <param name="Stage"></param>
        /// <param name="Classification"></param>
        /// <param name="DATRAG"></param>
        /// <param name="ProjectedStartDate"></param>
        /// <param name="ProjectedEndDate"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="PI"></param>
        /// <param name="LeadApplicant"></param>
        /// <param name="Faculty"></param>
        /// <param name="DSPT"></param>
        /// <param name="ISO"></param>
        /// <param name="Azure"></param>
        /// <param name="IRC"></param>
        /// <param name="SEED"></param>
        public bool insertUser(int UserNumber, int? Status, int? Title, string FirstName, string LastName, string Email
            , string Phone, string UserName, string Organisation, DateTime? StartDate, DateTime? EndDate, DateTime? IRCAgreement
            , DateTime? ISET, DateTime? ISAT, DateTime? SAFE, long? TokenSerial, DateTime? TokenIssued, DateTime? TokenReturned)
        {
            bool success = false;

            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qryInsertUser = new SqlCommand();
                    qryInsertUser.Connection = connection;
                    qryInsertUser.CommandText = "insert into [dbo].[tblUser] "
                        + "([UserNumber], [Status], [Title], [FirstName], [LastName], [Email], [Phone], [UserName]"
                        + ", [Organisation], [StartDate], [EndDate], [IRCAgreement], [ISET], [ISAT]"
                        + ", [SAFE], [TokenSerial], [TokenIssued], [TokenReturned]) "
                        + "values "
                        + "(@UserNumber, @Status, @Title, @FirstName, @LastName, @Email, @Phone, @UserName"
                        + ", @Organisation, @StartDate, @EndDate, @IRCAgreement, @ISET, @ISAT, @SAFE"
                        + ", @TokenSerial, @TokenIssued, @TokenReturned)";

                    //assign the parameter values
                    qryInsertUser.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                    SqlParameter param_Status = new SqlParameter("@Status", Status == null ? (object)DBNull.Value : Status);
                    param_Status.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_Status);
                    SqlParameter param_Title = new SqlParameter("@Title", Title == null ? (object)DBNull.Value : Title);
                    param_Title.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_Title);
                    qryInsertUser.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
                    qryInsertUser.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
                    qryInsertUser.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = Email;
                    qryInsertUser.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = Phone;
                    qryInsertUser.Parameters.Add("@UserName", SqlDbType.VarChar, 12).Value = UserName;
                    qryInsertUser.Parameters.Add("@Organisation", SqlDbType.VarChar, 255).Value = Organisation;
                    SqlParameter param_StartDate = new SqlParameter("@StartDate", StartDate == null ? (object)DBNull.Value : StartDate);
                    param_StartDate.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_StartDate);
                    SqlParameter param_EndDate = new SqlParameter("@EndDate", EndDate == null ? (object)DBNull.Value : EndDate);
                    param_EndDate.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_EndDate);
                    SqlParameter param_IRCAgreement = new SqlParameter("@IRCAgreement", IRCAgreement == null ? (object)DBNull.Value : IRCAgreement);
                    param_IRCAgreement.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_IRCAgreement);
                    SqlParameter param_ISET = new SqlParameter("@ISET", ISET == null ? (object)DBNull.Value : ISET);
                    param_ISET.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_ISET);
                    SqlParameter param_ISAT = new SqlParameter("@ISAT", ISAT == null ? (object)DBNull.Value : ISAT);
                    param_ISAT.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_ISAT);
                    SqlParameter param_SAFE = new SqlParameter("@SAFE", SAFE == null ? (object)DBNull.Value : SAFE);
                    param_SAFE.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_SAFE);
                    SqlParameter param_TokenSerial = new SqlParameter("@TokenSerial", TokenSerial == null ? (object)DBNull.Value : TokenSerial);
                    param_TokenSerial.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenSerial);
                    SqlParameter param_TokenIssued = new SqlParameter("@TokenIssued", TokenIssued == null ? (object)DBNull.Value : TokenIssued);
                    param_TokenIssued.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenIssued);
                    SqlParameter param_TokenReturned = new SqlParameter("@TokenReturned", TokenReturned == null ? (object)DBNull.Value : TokenReturned);
                    param_TokenReturned.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenReturned);

                    //open connection to database, run query and close connection
                    connection.Open();
                    qryInsertUser.ExecuteNonQuery();

                    MessageBox.Show($"Project details updated for {LastName}, {FirstName}");

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert new project record" + Environment.NewLine + Environment.NewLine + ex);
            }
            return success;
        }

        /// <summary>
        /// Performs a logical delete on the tblUserProject table, removing an active association between user and project.
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="ProjectNumber"></param>
        public void deleteUserProject(int UserNumber, string ProjectNumber)
        {
            try
            {
                //update ValidUntil field of current record of UserProject (perform 'logical' delete)
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    SqlCommand qryRemoveUserProject = new SqlCommand();
                    qryRemoveUserProject.Connection = connection;
                    qryRemoveUserProject.CommandText = "update [dbo].[tblUserProject] set [ValidTo] = getdate() where [UserNumber] = @UserNumber and [ProjectNumber] = @ProjectNumber";
                    qryRemoveUserProject.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                    qryRemoveUserProject.Parameters.Add("@ProjectNumber", SqlDbType.VarChar,5).Value = ProjectNumber;
                    connection.Open();
                    qryRemoveUserProject.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex);
            }
        }

        public bool checkUserProject(int UserNumber, string ProjectNumber)
        {
            bool PK_NotPresent = true;

            SQL_Stuff conString = new SQL_Stuff();
            using (SqlConnection connection = new SqlConnection(conString.getString()))
            {
                SqlCommand qryUserProjectExists = new SqlCommand();
                qryUserProjectExists.Connection = connection;
                qryUserProjectExists.CommandText = "select count(*) from [dbo].[tblUserProject] "
                    + "where [UserNumber] = @UserNumber and [ProjectNumber] = @ProjectNumber "
                    + "and [ValidTo] is null";
                qryUserProjectExists.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                qryUserProjectExists.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 5).Value = ProjectNumber;
                connection.Open();
                int i = (int)qryUserProjectExists.ExecuteScalar();

                if (i > 0)
                {
                    PK_NotPresent = false;
                    MessageBox.Show("User already present on project.");
                }
            }

            return PK_NotPresent;
        }


        public void insertUserProject(int UserNumber, string ProjectNumber)
        {
            try
            {
                //update ValidUntil field of current record of UserProject (perform 'logical' delete)
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    SqlCommand qryInsertUserProject = new SqlCommand();
                    qryInsertUserProject.Connection = connection;
                    qryInsertUserProject.CommandText = "insert into [dbo].[tblUserProject] ([UserNumber], [ProjectNumber]) values (@UserNumber, @ProjectNumber)";
                    qryInsertUserProject.Parameters.Add("@UserNumber", SqlDbType.Int).Value = UserNumber;
                    qryInsertUserProject.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 5).Value = ProjectNumber;
                    connection.Open();
                    qryInsertUserProject.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add record" + Environment.NewLine + Environment.NewLine + ex);
            }
        }

    }
}
