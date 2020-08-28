using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;

namespace CMS
{
    class Project
    {
        /// <summary>
        /// Constructor - used to instantiate each Project type object.
        /// Contains methods to query and update database records relating to projects.
        /// </summary>
        public Project()
        {
        }

        /// <summary>
        /// Method to return a DataSet (ds_prj) with content of SQL table dbo.tblProjects, dbo.tblProjectNotes, 
        /// dbo.tblUsers and other related lookup tables. 
        /// Creates DataRelations so that dimension tables can be linked to values in the measures table.
        /// </summary>
        /// <returns></returns>
        public DataSet getProjectsDataSet()
        {
            DataSet ds_prj = new DataSet("Projects");
            try
            {
                //use the central connection string from the SQL_Stuff class
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    GetDB.GetDataTable(connection, ds_prj, "tblProjects",
                        $"select * from [dbo].[tblProject] " +
                        $"where [ValidTo] is null " +
                        $"order by [ProjectNumber], [pID]");
                    GetDB.GetDataTable(connection, ds_prj, "tlkStage",
                        $"select * from [dbo].[tlkStage] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_prj, "tlkClassification",
                        $"select * from [dbo].[tlkClassification] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_prj, "tlkRAG",
                        $"select * from [dbo].[tlkRAG] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_prj, "tlkFaculty",
                        $"select * from [dbo].[tlkFaculty] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_prj, "tblProjectNotes",
                        $"select * from [dbo].[tblProjectNotes] " +
                        $"order by [ProjectNumber], [Created] desc");
                    GetDB.GetDataTable(connection, ds_prj, "tblUserProject",
                        $"select * from [dbo].[tblUserProject] " +
                        $"where [ValidTo] is null");
                    GetDB.GetDataTable(connection, ds_prj, "tblUser",
                        $"select *, [LastName] + ', ' + [FirstName] as FullName " +
                        $"from [dbo].[tblUser] " +
                        $"where [ValidTo] is null " +
                        $"order by [LastName], [FirstName], [UserID]");
                    // Copies made of tblUser so that the can be referenced by LeadApplicant and 
                    // PI fields of tblProjects via DataRelations without additional SQL Server hits
                    DataTable leadApp = ds_prj.Tables["tblUser"].Copy();
                    leadApp.TableName = "tlkLeadApplicant";
                    ds_prj.Tables.Add(leadApp);
                    DataTable PI = ds_prj.Tables["tblUser"].Copy();
                    PI.TableName = "tlkPI";
                    ds_prj.Tables.Add(PI);

                    ds_prj.Relations.Add("Project_Stage"
                        , ds_prj.Tables["tlkStage"].Columns["StageID"]      //parent
                        , ds_prj.Tables["tblProjects"].Columns["Stage"]);   //child
                    ds_prj.Relations.Add("Project_Classification"
                        , ds_prj.Tables["tlkClassification"].Columns["classificationID"]
                        , ds_prj.Tables["tblProjects"].Columns["Classification"]);
                    ds_prj.Relations.Add("Project_DATRAG"
                        , ds_prj.Tables["tlkRAG"].Columns["ragID"]         
                        , ds_prj.Tables["tblProjects"].Columns["DATRAG"]);
                    ds_prj.Relations.Add("Project_Faculty"
                        , ds_prj.Tables["tlkFaculty"].Columns["facultyID"]
                        , ds_prj.Tables["tblProjects"].Columns["Faculty"]);
                    ds_prj.Relations.Add("Project_LeadApplicant"
                        , ds_prj.Tables["tlkLeadApplicant"].Columns["UserNumber"]
                        , ds_prj.Tables["tblProjects"].Columns["LeadApplicant"]);
                    ds_prj.Relations.Add("Project_PI"
                        , ds_prj.Tables["tlkPI"].Columns["UserNumber"]
                        , ds_prj.Tables["tblProjects"].Columns["PI"]);
                    ds_prj.Relations.Add("UserProject_User"
                        , ds_prj.Tables["tblUser"].Columns["UserNumber"]
                        , ds_prj.Tables["tblUserProject"].Columns["UserNumber"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate ds_prj DataSet" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
                //return DataSet (ds_prj) as the output of this method
                return ds_prj;
        }

        /// <summary>
        /// Method to populate ProjectModel with latest single record.
        /// Uses parameter pNumber to query Project DataSet (passed as parameter ds_Project), assigns 
        /// values to the returned ProjectModel class variables.
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="ds_Project"></param>
        /// <returns></returns>
        public ProjectModel getProject(string pNumber, DataSet ds_Project)
        {
            ProjectModel mdl_Project = new ProjectModel();
            
            //if no records found, try will fail at "DataRow pRow = pRows[i];" and go to catch
            try
            {
                DataRow[] pRows = ds_Project.Tables["tblProjects"].Select($"ProjectNumber = '{pNumber}'");

                //there's always a small a chance a project might have multiple records where ValidTo is null
                //DataSet (ds_prj) is populated ordered by pNumber and then pID so largest (last added) pID for each project is last
                //feed back to user if more than one 'current' project record
                if (pRows.Count() > 1)
                {
                    MessageBox.Show("More than one current record found for this project, showing last only. Please contact a system administrator.");
                }

                //active row (pRow) filled with last row from pRows
                int i = pRows.Count() - 1;
                DataRow pRow = pRows[i];

                //populate DataRow to output with values from pRow
                mdl_Project.pID         = (int)pRow["pID"];
                mdl_Project.ProjectNumber = pRow["ProjectNumber"].ToString();
                mdl_Project.ProjectName = pRow["ProjectName"].ToString();
                if (pRow["Stage"].ToString().Length > 0)
                    mdl_Project.Stage = (int?)pRow["Stage"];
                if (pRow["Classification"].ToString().Length > 0)
                    mdl_Project.Classification = (int?)pRow["Classification"];
                if (pRow["DATRAG"].ToString().Length > 0)
                    mdl_Project.DATRAG = (int?)pRow["DATRAG"];
                if (pRow["ProjectedStartDate"].ToString().Length > 0)
                    mdl_Project.ProjectedStartDate = (DateTime)pRow["ProjectedStartDate"];
                if (pRow["ProjectedEndDate"].ToString().Length > 0)
                    mdl_Project.ProjectedEndDate = (DateTime)pRow["ProjectedEndDate"];
                if (pRow["StartDate"].ToString().Length > 0)
                    mdl_Project.StartDate = (DateTime)pRow["StartDate"];
                if (pRow["EndDate"].ToString().Length > 0)
                    mdl_Project.EndDate = (DateTime)pRow["EndDate"];
                if (pRow["PI"].ToString().Length > 0)
                    mdl_Project.PI = (int?)pRow["PI"];
                if (pRow["LeadApplicant"].ToString().Length > 0)
                    mdl_Project.LeadApplicant = (int?)pRow["LeadApplicant"];
                if (pRow["Faculty"].ToString().Length > 0)
                    mdl_Project.Faculty = (int?)pRow["Faculty"];
                mdl_Project.DSPT = (bool)pRow["DSPT"];
                mdl_Project.ISO27001 = (bool)pRow["ISO27001"];
                mdl_Project.Azure = (bool)pRow["Azure"];
                mdl_Project.IRC = (bool)pRow["IRC"];
                mdl_Project.SEED = (bool)pRow["SEED"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load project details" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            return mdl_Project;
        }

        /// <summary>
        /// Method to check whether the primary key of the record currently being read is the same as the primary 
        /// key of the latest record for that project.
        /// Takes parameter pNumber and queries the database with it, returning the pID for the latest record.
        /// Returns 'true' if returned pID matches paramter pID, 'false' if not.
        /// Defaults to false in case of error, better to not update if something's wrong.
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="current_pID"></param>
        /// <returns></returns>
        public bool checkCurrentRecord(string pNumber, int current_pID)
        {
            int? pID = null;
            bool recordCurrent = false;
            try
            {
                SQL_Stuff conString = new SQL_Stuff();

                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    SqlCommand qryCheckLatestRecord = new SqlCommand();
                    qryCheckLatestRecord.Connection = connection;
                    qryCheckLatestRecord.CommandText = $"select max([pID]) from [DAT_CMS].[dbo].[tblProject] where [ProjectNumber] = @pNumber and ValidTo is null";
                    qryCheckLatestRecord.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    connection.Open();
                    pID = (int)qryCheckLatestRecord.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find current record" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            if (current_pID == pID)
                recordCurrent = true;
            return recordCurrent;
        }

        /// <summary>
        /// Method to 'delete' project record from SQL Server database.
        /// Doesn't actually delete any records, takes the parameter pID (primary key) and updates record with todays 
        /// date, performing a logical delete.
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="pID"></param>
        public void deleteProject(int pID)
        {
            try
            {
                //update ValidUntil field of current record of project (perform 'logical' delete)
                SQL_Stuff conString = new SQL_Stuff();
                    using (SqlConnection connection = new SqlConnection(conString.getString()))
                    {
                        SqlCommand qryDeleteProject = new SqlCommand();
                        qryDeleteProject.Connection = connection;
                        qryDeleteProject.CommandText = "update [dbo].[tblProject] set [ValidTo] = getdate() where [pID] = @pID";
                        qryDeleteProject.Parameters.Add("@pID", SqlDbType.Int).Value = pID;
                        connection.Open();
                        qryDeleteProject.ExecuteNonQuery();
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Method to insert a new project record into dbo.tblProject.
        /// Takes ProjectModel as parameter, adds class variables it contains to a SQL query string as 
        /// parameters then executes an insert.
        /// Returns a boolean true on success, defaults to false
        /// </summary>
        /// <param name="mdl_Project"></param>
        /// <returns></returns>
        public bool insertProject(ProjectModel mdl_Project)
        {
            bool success = false;

            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qryInsertProject = new SqlCommand();
                    qryInsertProject.Connection = connection;
                    qryInsertProject.CommandText = "insert into [dbo].[tblProject] "
                        + "(ProjectNumber, ProjectName, Stage, Classification, DATRAG, ProjectedStartDate, ProjectedEndDate "
                        + ", StartDate, EndDate, [PI], LeadApplicant, Faculty, DSPT, ISO27001, Azure, IRC, SEED) "
                        + "values "
                        + "(@ProjectNumber, @ProjectName, @Stage, @Classification, @DATRAG, @ProjectedStartDate "
                        + ", @ProjectedEndDate, @StartDate, @EndDate, @PI, @LeadApplicant, @Faculty, @DSPT "
                        + ", @ISO27001, @Azure, @IRC, @SEED) ";

                    //assign the parameter values
                    qryInsertProject.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 5).Value = mdl_Project.ProjectNumber;
                    qryInsertProject.Parameters.Add("@ProjectName", SqlDbType.VarChar, 100).Value = mdl_Project.ProjectName;
                    SqlParameter param_Stage = new SqlParameter("@Stage", mdl_Project.Stage == null ? (object)DBNull.Value : mdl_Project.Stage);
                    param_Stage.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_Stage);
                    SqlParameter param_Classification = new SqlParameter("@Classification", mdl_Project.Classification == null ? (object)DBNull.Value : mdl_Project.Classification);
                    param_Classification.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_Classification);
                    SqlParameter param_DATRAG = new SqlParameter("@DATRAG", mdl_Project.DATRAG == null ? (object)DBNull.Value : mdl_Project.DATRAG);
                    param_DATRAG.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_DATRAG);
                    SqlParameter param_ProjectedStartDate = new SqlParameter("@ProjectedStartDate", mdl_Project.ProjectedStartDate == null ? (object)DBNull.Value : mdl_Project.ProjectedStartDate);
                    param_ProjectedStartDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_ProjectedStartDate);
                    SqlParameter param_ProjectedEndDate = new SqlParameter("@ProjectedEndDate", mdl_Project.ProjectedEndDate == null ? (object)DBNull.Value : mdl_Project.ProjectedEndDate);
                    param_ProjectedEndDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_ProjectedEndDate);
                    SqlParameter param_StartDate = new SqlParameter("@StartDate", mdl_Project.StartDate == null ? (object)DBNull.Value : mdl_Project.StartDate);
                    param_StartDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_StartDate);
                    SqlParameter param_EndDate = new SqlParameter("@EndDate", mdl_Project.EndDate == null ? (object)DBNull.Value : mdl_Project.EndDate);
                    param_EndDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_EndDate);
                    SqlParameter param_LeadApplicant = new SqlParameter("@LeadApplicant", mdl_Project.LeadApplicant == null ? (object)DBNull.Value : mdl_Project.LeadApplicant);
                    param_LeadApplicant.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_LeadApplicant);
                    SqlParameter param_PI = new SqlParameter("@PI", mdl_Project.PI == null ? (object)DBNull.Value : mdl_Project.PI);
                    param_PI.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_PI);
                    SqlParameter param_Faculty = new SqlParameter("@Faculty", mdl_Project.Faculty == null ? (object)DBNull.Value : mdl_Project.Faculty);
                    param_Faculty.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_Faculty);
                    qryInsertProject.Parameters.Add("@DSPT", SqlDbType.Bit).Value = mdl_Project.DSPT;
                    qryInsertProject.Parameters.Add("@ISO27001", SqlDbType.Bit).Value = mdl_Project.ISO27001;
                    qryInsertProject.Parameters.Add("@Azure", SqlDbType.Bit).Value = mdl_Project.Azure;
                    qryInsertProject.Parameters.Add("@IRC", SqlDbType.Bit).Value = mdl_Project.IRC;
                    qryInsertProject.Parameters.Add("@SEED", SqlDbType.Bit).Value = mdl_Project.SEED;
                    
                    //open connection to database, run query and close connection
                    connection.Open();
                    qryInsertProject.ExecuteNonQuery();
                    MessageBox.Show($"Project details updated for {mdl_Project.ProjectNumber}");

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert new project record" + Environment.NewLine + ex.Message);
                //throw;
            }
            return success;
        }

        /// <summary>
        /// Method to leave a project note.
        /// Takes parameter pNumber to link to project and pNote as the note value.
        /// Adds them both to the SQL query as parameters and executes an insert on dbo.tblProjectNotes.
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="pNote"></param>
        public void insertProjectNote(string pNumber, string pNote)
        {
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryInsertProjectNote = new SqlCommand();
                    qryInsertProjectNote.Connection = connection;
                    qryInsertProjectNote.CommandText = "insert into [dbo].[tblProjectNotes] "
                        + "([ProjectNumber],[pNote]) values (@pNumber, @pNote)";
                    qryInsertProjectNote.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryInsertProjectNote.Parameters.Add("@pNote", SqlDbType.VarChar, 8000).Value = pNote;

                    //open connection and execute insert
                    connection.Open();
                    qryInsertProjectNote.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new note" + Environment.NewLine + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to get largest pNumber from current pNumbers.
        /// Runs a SQL query to select largest number used in current project numbers and return it as an int type.
        /// Could just replace(pNumber, 'P', '') or take right(pNumber,4) but wanted to future proof as best I could:
        /// https://stackoverflow.com/questions/18625548/select-query-to-remove-non-numeric-characters
        /// </summary>
        /// <returns></returns>
        public int getLastProjectNumber()
        {
            int pNumInt;
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create new SQL query
                    SqlCommand qryGetNewProjectNumber = new SqlCommand();
                    qryGetNewProjectNumber.Connection = connection;
                    qryGetNewProjectNumber.CommandText =
                        "SELECT max(cast(LEFT(SUBSTRING(ProjectNumber, PATINDEX('%[0-9.-]%', ProjectNumber), 8000) "
                        + ",PATINDEX('%[^0-9.-]%',	SUBSTRING(ProjectNumber, PATINDEX('%[0-9.-]%', ProjectNumber), 8000) + 'X') -1) as int)) "
                        + "from [dbo].[tblProject]";
                    //open connection and execute query, returing result in variable pNumInt
                    connection.Open();
                    pNumInt = (int)qryGetNewProjectNumber.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                //if no project numbers start at zero.
                pNumInt = 0;
                MessageBox.Show("Failed to fetch largest Project Number, starting from zero" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            return pNumInt;
        }

        /// <summary>
        /// Method to add a "P" and leading zeroes to an integer.
        /// Used to generate new project numbers.
        /// </summary>
        /// <param name="pNumInt"></param>
        /// <returns></returns>
        public string getNewProjectNumber(int pNumInt)
        {
            string pNumZeroes = new string('0', 4); //repeated 0 four times
            string pNumber;
            pNumber = pNumZeroes + pNumInt.ToString();
            pNumber = "P" + pNumber.Substring(pNumber.Length - 4);

            return pNumber;
        }

        public bool requiredFields(ProjectModel mdl_Project)
        {
            bool requiredFields = true;

            if (string.IsNullOrWhiteSpace(mdl_Project.ProjectName))
            {
                MessageBox.Show("Please enter a Project Title.");
                requiredFields = false;
            }
            if (mdl_Project.LeadApplicant < 0)
            {
                MessageBox.Show("Please select a Lead Applicant.");
                requiredFields = false;
            }

            return requiredFields;
        }

    }
}        
