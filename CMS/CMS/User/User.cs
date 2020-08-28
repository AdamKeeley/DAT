using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;

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

        /// <summary>
        /// Method to populate UserModel with latest single record.
        /// Uses parameter UserNumber to query User DataSet (passed as parameter ds_User), assigns 
        /// values to the returned UserModel class variables.
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="ds_User"></param>
        /// <returns></returns>
        public UserModel getUser(int UserNumber, DataSet ds_User)
        {
            UserModel mdl_User = new UserModel();

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
                mdl_User.UserID = (int)uRow["UserID"];
                mdl_User.UserNumber = (int)uRow["UserNumber"];
                if (uRow["Status"].ToString().Length > 0)
                    mdl_User.Status = (int?)uRow["Status"];
                if (uRow["Title"].ToString().Length > 0)
                    mdl_User.Title = (int?)uRow["Title"];
                mdl_User.FirstName = uRow["FirstName"].ToString();
                mdl_User.LastName = uRow["LastName"].ToString();
                mdl_User.Email = uRow["Email"].ToString();
                mdl_User.Phone = uRow["Phone"].ToString();
                mdl_User.UserName = uRow["UserName"].ToString();
                mdl_User.Organisation = uRow["Organisation"].ToString();
                if (uRow["StartDate"].ToString().Length > 0)
                    mdl_User.StartDate = (DateTime?)uRow["StartDate"];
                if (uRow["EndDate"].ToString().Length > 0)
                    mdl_User.EndDate = (DateTime?)uRow["EndDate"];
                mdl_User.Priviledged = (bool)uRow["Priviledged"];
                if (uRow["IRCAgreement"].ToString().Length > 0)
                    mdl_User.IRCAgreement = (DateTime?)uRow["IRCAgreement"];
                if (uRow["ISET"].ToString().Length > 0)
                    mdl_User.ISET = (DateTime?)uRow["ISET"];
                if (uRow["ISAT"].ToString().Length > 0)
                    mdl_User.ISAT = (DateTime?)uRow["ISAT"];
                if (uRow["SAFE"].ToString().Length > 0)
                    mdl_User.SAFE = (DateTime?)uRow["SAFE"];
                if (uRow["TokenSerial"].ToString().Length > 0)
                    mdl_User.TokenSerial = (long?)uRow["TokenSerial"];
                if (uRow["TokenIssued"].ToString().Length > 0)
                    mdl_User.TokenIssued = (DateTime?)uRow["TokenIssued"];
                if (uRow["TokenReturned"].ToString().Length > 0)
                    mdl_User.TokenReturned = (DateTime?)uRow["TokenReturned"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user details" + Environment.NewLine + Environment.NewLine + ex);
                throw;
            }

            return mdl_User;
        }

        /// <summary>
        /// Method to leave a user note.
        /// Takes parameter UserNumber to link to project and uNote as the note content.
        /// Adds them both to the SQL query as parameters and executes an insert on dbo.tblUserNotes.
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="uNote"></param>
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
        /// Returns 'true' if returned UserID matches parameter current_UserID, 'false' if not.
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
        /// Method to insert a new user record into dbo.tblUser.
        /// Takes UserModel class as parameter, adds class member variables to a SQL query string 
        /// as parameters then executes an insert.
        /// Returns a boolean true on success, defaults to false
        /// </summary>
        /// <param name="mdl_User"></param>
        /// <returns></returns>
        public bool insertUser(UserModel mdl_User)
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
                    qryInsertUser.Parameters.Add("@UserNumber", SqlDbType.Int).Value = mdl_User.UserNumber;
                    SqlParameter param_Status = new SqlParameter("@Status", mdl_User.Status == null ? (object)DBNull.Value : mdl_User.Status);
                    param_Status.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_Status);
                    SqlParameter param_Title = new SqlParameter("@Title", mdl_User.Title == null ? (object)DBNull.Value : mdl_User.Title);
                    param_Title.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_Title);
                    qryInsertUser.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = mdl_User.FirstName;
                    qryInsertUser.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = mdl_User.LastName;
                    qryInsertUser.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = mdl_User.Email;
                    qryInsertUser.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = mdl_User.Phone;
                    qryInsertUser.Parameters.Add("@UserName", SqlDbType.VarChar, 12).Value = mdl_User.UserName;
                    qryInsertUser.Parameters.Add("@Organisation", SqlDbType.VarChar, 255).Value = mdl_User.Organisation;
                    SqlParameter param_StartDate = new SqlParameter("@StartDate", mdl_User.StartDate == null ? (object)DBNull.Value : mdl_User.StartDate);
                    param_StartDate.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_StartDate);
                    SqlParameter param_EndDate = new SqlParameter("@EndDate", mdl_User.EndDate == null ? (object)DBNull.Value : mdl_User.EndDate);
                    param_EndDate.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_EndDate);
                    SqlParameter param_IRCAgreement = new SqlParameter("@IRCAgreement", mdl_User.IRCAgreement == null ? (object)DBNull.Value : mdl_User.IRCAgreement);
                    param_IRCAgreement.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_IRCAgreement);
                    SqlParameter param_ISET = new SqlParameter("@ISET", mdl_User.ISET == null ? (object)DBNull.Value : mdl_User.ISET);
                    param_ISET.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_ISET);
                    SqlParameter param_ISAT = new SqlParameter("@ISAT", mdl_User.ISAT == null ? (object)DBNull.Value : mdl_User.ISAT);
                    param_ISAT.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_ISAT);
                    SqlParameter param_SAFE = new SqlParameter("@SAFE", mdl_User.SAFE == null ? (object)DBNull.Value : mdl_User.SAFE);
                    param_SAFE.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_SAFE);
                    SqlParameter param_TokenSerial = new SqlParameter("@TokenSerial", mdl_User.TokenSerial == null ? (object)DBNull.Value : mdl_User.TokenSerial);
                    param_TokenSerial.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenSerial);
                    SqlParameter param_TokenIssued = new SqlParameter("@TokenIssued", mdl_User.TokenIssued == null ? (object)DBNull.Value : mdl_User.TokenIssued);
                    param_TokenIssued.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenIssued);
                    SqlParameter param_TokenReturned = new SqlParameter("@TokenReturned", mdl_User.TokenReturned == null ? (object)DBNull.Value : mdl_User.TokenReturned);
                    param_TokenReturned.IsNullable = true;
                    qryInsertUser.Parameters.Add(param_TokenReturned);

                    //open connection to database, run query and close connection
                    connection.Open();
                    qryInsertUser.ExecuteNonQuery();

                    MessageBox.Show($"User details updated for {mdl_User.LastName}, {mdl_User.FirstName}");

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

        /// <summary>
        /// Checks if a valid record containing UserNumber and ProjectNumber already exists. 
        /// Returns true if parametised values can be added.
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="ProjectNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Inserts a new record into tblUserProject, thereby creating a relationship between a user 
        /// and a project. 
        /// </summary>
        /// <param name="UserNumber"></param>
        /// <param name="ProjectNumber"></param>
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

        /// <summary>
        /// Queries SQL database tblUser table for largest UserNumber value. 
        /// </summary>
        /// <returns></returns>
        public int getLastUserNumber()
        {
            int UserNumber;

            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create new SQL query
                    SqlCommand qryGetNewProjectNumber = new SqlCommand();
                    qryGetNewProjectNumber.Connection = connection;
                    qryGetNewProjectNumber.CommandText =
                        $"select max([UserNumber]) " +
                        $"from [dbo].[tblUser]";
                    //open connection and execute query, returing result in variable pNumInt
                    connection.Open();
                    UserNumber = (int)qryGetNewProjectNumber.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                //if no project numbers start at zero.
                UserNumber = 0;
                MessageBox.Show("Failed to fetch largest User Number, starting from zero" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return UserNumber;
        }

        public bool requiredFields(UserModel mdl_User)
        {
            bool requiredFields = true;

            //Check required fields have an entry
            if (requiredFields == true & string.IsNullOrWhiteSpace(mdl_User.FirstName))
            {
                MessageBox.Show("Please enter a First Name.");
                requiredFields = false;
            }
            if (requiredFields == true & string.IsNullOrWhiteSpace(mdl_User.LastName))
            {
                MessageBox.Show("Please enter a Last Name.");
                requiredFields = false;
            }
            if (requiredFields == true & string.IsNullOrWhiteSpace(mdl_User.Email))
            {
                MessageBox.Show("Please enter a Email Address.");
                requiredFields = false;
            }

            return requiredFields;
        }

        /// <summary>
        /// Checks first & last name against ds_User to see if it already exists. 
        /// Presents dialog asking to confirm if duplicate, returns true on yes false on no.
        /// </summary>
        /// <param name="mdl_User"></param>
        /// <param name="tbl_User"></param>
        /// <returns></returns>
        public bool userExists(UserModel mdl_User, DataTable tbl_User)
        {
            bool userExists = false;

            var existingUser = from row in tbl_User.AsEnumerable()
                               where row.Field<string>("FirstName").ToLower() == mdl_User.FirstName.ToLower()
                                       && row.Field<string>("LastName").ToLower() == mdl_User.LastName.ToLower()
                               select row;

            if (existingUser.Count() > 0)
            {
                string existingMessage = $"Is this a duplicate of an existing user?" + Environment.NewLine + Environment.NewLine;
                foreach (DataRow user in existingUser)
                {
                    existingMessage += $"{user.Field<string>("FirstName")} " +
                        $"{user.Field<string>("LastName")}, " +
                        $"{user.Field<string>("Email")}" + Environment.NewLine;
                }

                DialogResult confirm = MessageBox.Show(
                    text: existingMessage
                    , caption: "Existing user?"
                    , buttons: MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    userExists = true;
                }
            }

            return userExists;
        }

    }
}
