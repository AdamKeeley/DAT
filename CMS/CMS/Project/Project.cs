using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;
using System.Linq.Expressions;

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
        /// <returns>
        /// Full DataSet containing tables of all currently valid project records and asociated user/lookup tables.
        /// </returns>
        public DataSet getProjectsDataSet()
        {
            DataSet ds_prj = new DataSet("Projects");
            try
            {
                //use the central connection string from the SQL_Stuff class
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjects",
                        $"select * from [dbo].[tblProject] " +
                        $"where [ValidTo] is null " +
                        $"order by [ProjectNumber], [pID]");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkStage",
                        $"select * from [dbo].[tlkStage] order by StageNumber asc");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkClassification",
                        $"select * from [dbo].[tlkClassification] ");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkRAG",
                        $"select * from [dbo].[tlkRAG] ");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkFaculty",
                        $"select * from [dbo].[tlkFaculty] ");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjectNotes",
                        $"select * from [dbo].[tblProjectNotes] " +
                        $"order by [ProjectNumber], [Created] desc");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjectPlatformInfo",
                        $"Select * from [dbo].[tblProjectPlatformInfo] " +
                        $"where [ValidTo] is null");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkPlatformInfo",
                        $"select * from [dbo].[tlkPlatformInfo]");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblUserProject",
                        $"select * from [dbo].[tblUserProject] " +
                        $"where [ValidTo] is null");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjectDocument",
                        $"select * from [dbo].[tblProjectDocument]" +
                        $"where [ValidTo] is null");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkDocuments",
                        $"select * from [dbo].[tlkDocuments]");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblDocsAccepted",
                        $"select tbl.ProjectNumber " +
                        $"  , tlk.DocumentID " +
                        $"  , tlk.DocumentDescription " +
                        $"  , max(tbl.Accepted) as maxAccepted " +
                        $"from[dbo].[tlkDocuments] tlk " +
                        $"  left join[dbo].[tblProjectDocument] tbl " +
                        $"      on tlk.DocumentID = tbl.DocumentType " +
                        $"where tlk.ValidTo is null and tbl.ValidTo is null " +
                        $"  and tbl.ProjectNumber is not null " +
                        $"group by tbl.ProjectNumber " +
                        $"  , tlk.DocumentID " +
                        $"  , tlk.DocumentDescription " +
                        $"order by tbl.ProjectNumber, tlk.DocumentID");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblDatHours",
                        $"select ProjectNumber " +
                        $"  , sum(case when datediff(m, Created, getdate()) = 0 " +
                        $"      then[DatHours] else 0 end) as ThisMonth " +
                        $"  , sum(case when datediff(m, Created, getdate()) between 1 and 6 " +
                        $"      then[DatHours] else 0 end) as Last6Month " +
                        $"  , sum(case when datediff(m, Created, getdate()) between 1 and 12 " +
                        $"      then[DatHours] else 0 end) as Last12Month " +
                        $"  , sum([DatHours]) as AllTime " +
                        $"from [dbo].[tblProjectDatTime] " +
                        $"group by ProjectNumber ");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjectKristal",
                        $"select k.[KristalID] " +
                        $"    , k.[KristalRef] " +
                        $"    , k.[KristalName] " +
                        $"    , k.[GrantStageID] " +
                        $"    , pk.[ProjectKristalID] " +
                        $"    , pk.[ProjectNumber] " +
                        $"from[dbo].[tblKristal] k " +
                        $"    inner join[dbo].[tblProjectKristal] pk " +
                        $"        on k.[KristalRef] = pk.[KristalRef] " +
                        $"where k.[ValidTo] is null and pk.[ValidTo] is null ");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tlkGrantStage",
                        $"select * from [dbo].[tlkGrantStage]");
                    SQL_Stuff.getDataTable(conn, null, ds_prj, "tblProjectDatAllocation",
                        $"select * from [dbo].[tblProjectDatAllocation] " +
                        $"where ValidTo is null " +
                        $"order by [ProjectNumber], [FromDate] desc");

                    // get the user tables needed to link to project details and merge with project dataset
                    DataSet ds_prj_usr = getUserDataSet();
                    ds_prj.Merge(ds_prj_usr);
                }

                ds_prj.Relations.Add("Project_Stage"
                    , ds_prj.Tables["tlkStage"].Columns["StageID"]      //parent
                    , ds_prj.Tables["tblProjects"].Columns["Stage"], false);   //child
                ds_prj.Relations.Add("Project_Classification"
                    , ds_prj.Tables["tlkClassification"].Columns["classificationID"]
                    , ds_prj.Tables["tblProjects"].Columns["Classification"], false);
                ds_prj.Relations.Add("Project_DATRAG"
                    , ds_prj.Tables["tlkRAG"].Columns["ragID"]
                    , ds_prj.Tables["tblProjects"].Columns["DATRAG"], false);
                ds_prj.Relations.Add("Project_Faculty"
                    , ds_prj.Tables["tlkFaculty"].Columns["facultyID"]
                    , ds_prj.Tables["tblProjects"].Columns["Faculty"], false);
                ds_prj.Relations.Add("ProjectPlatformInfo_PlatformInfo"
                    , ds_prj.Tables["tlkPlatformInfo"].Columns["PlatformInfoID"]
                    , ds_prj.Tables["tblProjectPlatformInfo"].Columns["PlatformInfoID"], false);
                ds_prj.Relations.Add("ProjectDocument_Document"
                    , ds_prj.Tables["tlkDocuments"].Columns["DocumentID"]
                    , ds_prj.Tables["tblProjectDocument"].Columns["DocumentType"], false);
                ds_prj.Relations.Add("ProjectKristal_GrantStage"
                    , ds_prj.Tables["tlkGrantStage"].Columns["GrantStageID"]
                    , ds_prj.Tables["tblProjectKristal"].Columns["GrantStageID"], false);

                ds_prj = addProjectUserDataRelations(ds_prj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate ds_prj DataSet" + Environment.NewLine + Environment.NewLine + ex);
            }

            //return DataSet (ds_prj) as the output of this method
            return ds_prj;
        }

        /// <summary>
        /// Takes a Project DataSet and removes user related DataTables
        /// </summary>
        /// <param name="ds_prj"></param>
        /// <returns>Project DataSet without user tables</returns>
        public DataSet dropProjectUserTablesFromProjectDataSet(DataSet ds_prj)
        {
            if (ds_prj.Tables.Contains("tblUser"))
            {
                if (ds_prj.Relations.Contains("UserProject_User"))
                {
                    ds_prj.Relations.Remove("UserProject_User");
                    ds_prj.Tables["tblUserProject"].Constraints.Remove("UserProject_User");
                }
                ds_prj.Tables.Remove("tblUser");
            }

            if (ds_prj.Tables.Contains("tlkLeadApplicant"))
            {
                if (ds_prj.Relations.Contains("Project_LeadApplicant"))
                {
                    ds_prj.Relations.Remove("Project_LeadApplicant");
                    ds_prj.Tables["tblProjects"].Constraints.Remove("Project_LeadApplicant");
                }
                ds_prj.Tables.Remove("tlkLeadApplicant");
            }

            if (ds_prj.Tables.Contains("tlkPI"))
            {
                if (ds_prj.Relations.Contains("Project_PI"))
                {
                    ds_prj.Relations.Remove("Project_PI");
                    ds_prj.Tables["tblProjects"].Constraints.Remove("Project_PI");
                }
                ds_prj.Tables.Remove("tlkPI");
            }

            return ds_prj;
        }

        /// <summary>
        /// Gets user tables for project DataSet, can be used with ds.dt.Merge() to add to existing DataSet
        /// </summary>
        /// <returns>DataSet containing just project related User tables</returns>
        public DataSet getUserDataSet()
        {
            DataSet ds_prj_usr = new DataSet("Users");
            try
            {
                //use the central connection string from the SQL_Stuff class
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SQL_Stuff.getDataTable(conn, null, ds_prj_usr, "tblUser",
                        $"select *, [LastName] + ', ' + [FirstName] as FullName " +
                        $"from [dbo].[tblUser] " +
                        $"where [ValidTo] is null " +
                        $"order by [LastName], [FirstName], [UserID]");
                    // Copies made of tblUser so that the can be referenced by LeadApplicant and 
                    // PI fields of tblProjects via DataRelations without additional SQL Server hits
                    DataTable leadApp = ds_prj_usr.Tables["tblUser"].Copy();
                    leadApp.TableName = "tlkLeadApplicant";
                    ds_prj_usr.Tables.Add(leadApp);
                    DataTable PI = ds_prj_usr.Tables["tblUser"].Copy();
                    PI.TableName = "tlkPI";
                    ds_prj_usr.Tables.Add(PI);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate ds_prj_usr DataSet" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            return ds_prj_usr;
        }

        /// <summary>
        /// Takes a project DataSet and adds DataRelations for project user DataTables
        /// </summary>
        /// <param name="ds_prj"></param>
        /// <returns>Project DataSet with DataRelations to project related user tables</returns>
        public DataSet addProjectUserDataRelations(DataSet ds_prj)
        {
            if (ds_prj.Tables.Contains("tlkLeadApplicant") && ds_prj.Tables.Contains("tblProjects"))
            {
                if (ds_prj.Relations.Contains("Project_LeadApplicant") == false)
                {
                    ds_prj.Relations.Add("Project_LeadApplicant"
                        , ds_prj.Tables["tlkLeadApplicant"].Columns["UserNumber"]
                        , ds_prj.Tables["tblProjects"].Columns["LeadApplicant"], false);
                }
            }
            if (ds_prj.Tables.Contains("tlkPI") && ds_prj.Tables.Contains("tblProjects"))
            {
                if (ds_prj.Relations.Contains("Project_PI") == false)
                {
                    ds_prj.Relations.Add("Project_PI"
                        , ds_prj.Tables["tlkPI"].Columns["UserNumber"]
                        , ds_prj.Tables["tblProjects"].Columns["PI"], false);
                }
            }
            if (ds_prj.Tables.Contains("tblUser") && ds_prj.Tables.Contains("tblUserProject"))
            {
                if (ds_prj.Relations.Contains("UserProject_User") == false)
                {
                    ds_prj.Relations.Add("UserProject_User"
                        , ds_prj.Tables["tblUser"].Columns["UserNumber"]
                        , ds_prj.Tables["tblUserProject"].Columns["UserNumber"], false);
                }
            }

            return ds_prj;
        }

        /// <summary>
        /// Performs three operations on a Project DataSet, 
        ///     1 drops user tables if present;
        ///     2 re-adds new user tables to project DataSet from sql db;
        ///     3 re-adds DataRelations;
        /// </summary>
        /// <param name="ds_prj"></param>
        /// <returns>Project dataset with original data and refresh user tables</returns>
        public DataSet refreshProjectUserTables(DataSet ds_prj)
        {
            // First drop project_user tables from project dataset
            ds_prj = dropProjectUserTablesFromProjectDataSet(ds_prj);
            // Then re-add refreshed project_user tables to project dataset
            ds_prj.Merge(getUserDataSet());
            // Then re-add datarelations
            ds_prj = addProjectUserDataRelations(ds_prj);

            return ds_prj;
        }

        /// <summary>
        /// Method to populate ProjectModel with latest single record.
        /// Uses parameter pNumber to query Project DataSet (passed as parameter ds_Project), assigns 
        /// values to the returned ProjectModel class variables.
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="ds_Project"></param>
        /// <returns>
        /// Populated ProjectModel 
        /// </returns>
        public mdl_Project getProject(string pNumber, DataSet ds_Project)
        {
            mdl_Project mdl_Project = new mdl_Project();

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
                mdl_Project.pID = (int)pRow["pID"];
                mdl_Project.ProjectNumber = pRow["ProjectNumber"].ToString();
                mdl_Project.ProjectName = pRow["ProjectName"].ToString();
                if (pRow["PortfolioNumber"].ToString().Length > 0)
                    mdl_Project.PortfolioNumber = pRow["PortfolioNumber"].ToString();
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
                mdl_Project.LIDA = (bool)pRow["LIDA"];
                mdl_Project.Internship = (bool)pRow["Internship"];
                mdl_Project.DSPT = (bool)pRow["DSPT"];
                mdl_Project.ISO27001 = (bool)pRow["ISO27001"];
                mdl_Project.LASER = (bool)pRow["LASER"];
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
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="current_pID"></param>
        /// <returns>
        /// 'true' if returned pID matches parameter pID, 'false' and messagebox if not.
        /// Defaults to false in case of error, better to not update if something's wrong.
        /// </returns>
        public bool checkCurrentRecord(string pNumber, int current_pID)
        {
            int? pID = null;
            bool recordCurrent = false;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryCheckLatestRecord = new SqlCommand();
                    qryCheckLatestRecord.Connection = conn;
                    qryCheckLatestRecord.CommandText = $"select max([pID]) from [dbo].[tblProject] where [ProjectNumber] = @pNumber and ValidTo is null";
                    qryCheckLatestRecord.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    conn.Open();
                    pID = (int)qryCheckLatestRecord.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find current record" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            if (current_pID != pID)
                MessageBox.Show("Project previously updated, please refresh & try again.");

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
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryDeleteProject = new SqlCommand();
                    qryDeleteProject.Connection = conn;
                    qryDeleteProject.CommandText = "update [dbo].[tblProject] set [ValidTo] = getdate() where [pID] = @pID";
                    qryDeleteProject.Parameters.Add("@pID", SqlDbType.Int).Value = pID;
                    conn.Open();
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
        /// </summary>
        /// <param name="mdl_Project"></param>
        /// <returns>
        /// true on success, defaults to false
        /// </returns>
        public bool insertProject(mdl_Project mdl_Project)
        {
            bool success = false;

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qryInsertProject = new SqlCommand();
                    qryInsertProject.Connection = conn;
                    qryInsertProject.CommandText = "insert into [dbo].[tblProject] "
                        + "(ProjectNumber, ProjectName, PortfolioNumber, Stage, Classification, DATRAG, ProjectedStartDate" +
                        ", ProjectedEndDate, StartDate, EndDate, [PI], LeadApplicant, Faculty, DSPT " +
                        ", ISO27001, LIDA, Internship, LASER, IRC, SEED) "
                        + "values "
                        + "(@ProjectNumber, @ProjectName, @PortfolioNumber, @Stage, @Classification, @DATRAG, @ProjectedStartDate "
                        + ", @ProjectedEndDate, @StartDate, @EndDate, @PI, @LeadApplicant, @Faculty, @DSPT "
                        + ", @ISO27001, @LIDA, @Internship, @LASER, @IRC, @SEED) ";

                    //assign the parameter values
                    qryInsertProject.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 5).Value = mdl_Project.ProjectNumber;
                    qryInsertProject.Parameters.Add("@ProjectName", SqlDbType.VarChar, 100).Value = mdl_Project.ProjectName;
                    SqlParameter param_PortfolioNumber = new SqlParameter("@PortfolioNumber", mdl_Project.PortfolioNumber == null ? (object)DBNull.Value : mdl_Project.PortfolioNumber);
                    param_PortfolioNumber.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_PortfolioNumber);
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
                    qryInsertProject.Parameters.Add("@LIDA", SqlDbType.Bit).Value = mdl_Project.LIDA;
                    qryInsertProject.Parameters.Add("@Internship", SqlDbType.Bit).Value = mdl_Project.Internship;
                    qryInsertProject.Parameters.Add("@LASER", SqlDbType.Bit).Value = mdl_Project.LASER;
                    qryInsertProject.Parameters.Add("@IRC", SqlDbType.Bit).Value = mdl_Project.IRC;
                    qryInsertProject.Parameters.Add("@SEED", SqlDbType.Bit).Value = mdl_Project.SEED;

                    //open connection to database, run query and close connection
                    conn.Open();
                    qryInsertProject.ExecuteNonQuery();

                    //Add new PI and Lead Applicant to project research team
                    insertResearchTeam(mdl_Project);

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
        /// Uses methods in User.cs to add Lead Applicant and PI to project research team if they're not already present.
        /// </summary>
        /// <param name="mdl_Project"></param>
        private void insertResearchTeam(mdl_Project mdl_Project)
        {
            int? PI_UserNumber = mdl_Project.PI;
            int? LA_UserNumber = mdl_Project.LeadApplicant;
            string ProjectNumber = mdl_Project.ProjectNumber;

            try
            {
                User Users = new User();
                if (PI_UserNumber != null)
                {
                    if (Users.checkUserProject((int)PI_UserNumber, ProjectNumber) == true)
                    {
                        Users.insertUserProject((int)PI_UserNumber, ProjectNumber);
                    }
                }
                if (LA_UserNumber != null)
                {
                    if (Users.checkUserProject((int)LA_UserNumber, ProjectNumber) == true)
                    {
                        Users.insertUserProject((int)LA_UserNumber, ProjectNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert Principal Investigator or Lead Applicant to project research team." + Environment.NewLine + ex.Message);
                //throw;
            }
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
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryInsertProjectNote = new SqlCommand();
                    qryInsertProjectNote.Connection = conn;
                    qryInsertProjectNote.CommandText = "insert into [dbo].[tblProjectNotes] "
                        + "([ProjectNumber],[pNote]) values (@pNumber, @pNote)";
                    qryInsertProjectNote.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryInsertProjectNote.Parameters.Add("@pNote", SqlDbType.VarChar, 8000).Value = pNote;

                    //open connection and execute insert
                    conn.Open();
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
        /// Takes the project number and document type and queries the database for the next whole version number.
        /// </summary>
        /// <param name="ProjectNumber"></param>
        /// <param name="DocumentType"></param>
        /// <returns></returns>
        public int? getNextDocVersion(mdl_ProjectDoc mdl_ProjectDoc)
        {
            int? version = null;

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qry_getNextDocVersion = new SqlCommand();
                    qry_getNextDocVersion.Connection = conn;
                    qry_getNextDocVersion.CommandText = $"select isnull(max(floor([VersionNumber])) + 1, 1) " +
                        $"from[dbo].[tblProjectDocument] " +
                        $"where[ValidTo] is null " +
                        $"and [ProjectNumber] = @ProjectNumber " +
                        $"and[DocumentType] = @DocumentType ";
                    qry_getNextDocVersion.Parameters.Add("@ProjectNumber", SqlDbType.VarChar).Value = mdl_ProjectDoc.ProjectNumber;
                    qry_getNextDocVersion.Parameters.Add("@DocumentType", SqlDbType.Int).Value = mdl_ProjectDoc.DocumentType;

                    conn.Open();
                    object result = qry_getNextDocVersion.ExecuteScalar();
                    result = (result == DBNull.Value) ? null : result;
                    version = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate next document version number." + Environment.NewLine + ex.Message);
            }

            return version;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectPlatformInfoID"></param>
        /// <returns></returns>
        public bool deleteProjectPlatformInfo(int ProjectPlatformInfoID)
        {
            try
            {
                //update ValidUntil field of current record (perform 'logical' delete)
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryRemoveProjectPlatformInfo = new SqlCommand();
                    qryRemoveProjectPlatformInfo.Connection = conn;
                    qryRemoveProjectPlatformInfo.CommandText = $"update [dbo].[tblProjectPlatformInfo] " +
                        $"set[ValidTo] = getdate() " +
                        $"where[ValidTo] is null " +
                        $"and [ProjectPlatformInfoID] = @ProjectPlatformInfoID";
                    qryRemoveProjectPlatformInfo.Parameters.Add("@ProjectPlatformInfoID", SqlDbType.Int).Value = ProjectPlatformInfoID;
                    conn.Open();
                    qryRemoveProjectPlatformInfo.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record" + Environment.NewLine + Environment.NewLine + ex);
                return false;
            }
        }

        public bool insertProjectPlatformInfo(string pNumber, int ProjectPlatformInfoID, string PlatformInfoDescription)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryInsertProjectPlatformInfo = new SqlCommand();
                    qryInsertProjectPlatformInfo.Connection = conn;
                    qryInsertProjectPlatformInfo.CommandText = $"insert into [dbo].[tblProjectPlatformInfo] " +
                        "([ProjectNumber], [PlatformInfoID], [ProjectPlatformInfo]) values (@pNumber, @PlatformInfoID, @ProjectPlatformInfo)";
                    qryInsertProjectPlatformInfo.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryInsertProjectPlatformInfo.Parameters.Add("@PlatformInfoID", SqlDbType.Int).Value = ProjectPlatformInfoID;
                    qryInsertProjectPlatformInfo.Parameters.Add("@ProjectPlatformInfo", SqlDbType.VarChar, 255).Value = PlatformInfoDescription;

                    //open connection and execute insert
                    conn.Open();
                    qryInsertProjectPlatformInfo.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new platform information" + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public bool insertNewDoc(mdl_ProjectDoc mdl_ProjectDoc)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qry_insertNewDoc = new SqlCommand();
                    qry_insertNewDoc.Connection = conn;
                    qry_insertNewDoc.CommandText = $"insert into [dbo].[tblProjectDocument] " +
                        $"([ProjectNumber], [DocumentType], [VersionNumber], [Submitted], [Accepted]) " +
                        $"values " +
                        $"(@ProjectNumber, @DocumentType, @VersionNumber, @Submitted, @Accepted) ";
                    qry_insertNewDoc.Parameters.Add("@ProjectNumber", SqlDbType.VarChar).Value = mdl_ProjectDoc.ProjectNumber;
                    qry_insertNewDoc.Parameters.Add("@DocumentType", SqlDbType.Int).Value = mdl_ProjectDoc.DocumentType;
                    qry_insertNewDoc.Parameters.Add("@VersionNumber", SqlDbType.Decimal).Value = mdl_ProjectDoc.VersionNumber;
                    qry_insertNewDoc.Parameters.Add("@Submitted", SqlDbType.DateTime).Value = mdl_ProjectDoc.Submitted;
                    SqlParameter param_Accepted = new SqlParameter("@Accepted", mdl_ProjectDoc.Accepted == null ? (object)DBNull.Value : mdl_ProjectDoc.Accepted);
                    qry_insertNewDoc.Parameters.Add(param_Accepted);
                    param_Accepted.IsNullable = true;

                    conn.Open();
                    qry_insertNewDoc.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert new document." + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public bool deleteProjectDocument(int pdID)
        {
            bool success = false;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryUpdateProjectDoc = new SqlCommand();
                    qryUpdateProjectDoc.Connection = conn;
                    qryUpdateProjectDoc.CommandText = $"update [dbo].[tblProjectDocument] " +
                        $"set [ValidTo] = getdate() " +
                        $"where [pdID] = @pdID";
                    qryUpdateProjectDoc.Parameters.Add("@pdID", SqlDbType.Int).Value = pdID;

                    //open connection and execute insert
                    conn.Open();
                    qryUpdateProjectDoc.ExecuteNonQuery();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete project document." + Environment.NewLine + ex.Message);
                //throw;
            }

            return success;
        }

        public bool insertDatTime(string pNumber, decimal DatHours)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryInsertDatTime = new SqlCommand();
                    qryInsertDatTime.Connection = conn;
                    qryInsertDatTime.CommandText = $"insert into[dbo].[tblProjectDatTime] (ProjectNumber, DatHours) " +
                        $"values (@ProjectNumber, @DatHours)";
                    qryInsertDatTime.Parameters.Add("@ProjectNumber", SqlDbType.VarChar).Value = pNumber;
                    qryInsertDatTime.Parameters.Add("@DatHours", SqlDbType.Decimal).Value = DatHours;

                    conn.Open();
                    qryInsertDatTime.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add worked hours to project." + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public bool insertDatAllocation(mdl_ProjectDatAllocation mdl_ProjectDatAllocation)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    SqlCommand qryInsertDatAllocation = new SqlCommand();
                    qryInsertDatAllocation.Connection = conn;
                    qryInsertDatAllocation.CommandText = $"insert into[dbo].[tblProjectDatAllocation] ([ProjectNumber], [FromDate], [ToDate], [FTE]) " +
                        $"values (@ProjectNumber, @FromDate, @ToDate, @FTE)";
                    
                    qryInsertDatAllocation.Parameters.Add("@ProjectNumber", SqlDbType.VarChar).Value = mdl_ProjectDatAllocation.ProjectNumber;
                    
                    SqlParameter param_FromDate = new SqlParameter("@FromDate", mdl_ProjectDatAllocation.FromDate == null ? (object)DBNull.Value : mdl_ProjectDatAllocation.FromDate);
                    qryInsertDatAllocation.Parameters.Add(param_FromDate);
                    param_FromDate.IsNullable = true;
                    
                    SqlParameter param_ToDate = new SqlParameter("@ToDate", mdl_ProjectDatAllocation.ToDate == null ? (object)DBNull.Value : mdl_ProjectDatAllocation.ToDate);
                    qryInsertDatAllocation.Parameters.Add(param_ToDate);
                    param_ToDate.IsNullable = true;

                    qryInsertDatAllocation.Parameters.Add("@FTE", SqlDbType.Decimal).Value = mdl_ProjectDatAllocation.FTE;

                    conn.Open();
                    qryInsertDatAllocation.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add DAT Allocation to project." + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public bool deleteDatAllocation(int current_PDAId)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create parameterised SQL query to insert a new record to tblProjectNotes
                    SqlCommand qryUpdateProjectDoc = new SqlCommand();
                    qryUpdateProjectDoc.Connection = conn;
                    qryUpdateProjectDoc.CommandText = $"update [dbo].[tblProjectDatAllocation] " +
                        $"set [ValidTo] = getdate() " +
                        $"where [ProjectDatAllocationId] = @PDAId";
                    qryUpdateProjectDoc.Parameters.Add("@PDAId", SqlDbType.Int).Value = current_PDAId;

                    //open connection and execute insert
                    conn.Open();
                    qryUpdateProjectDoc.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete DAT Allocation from project." + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to get largest pNumber from current pNumbers.
        /// Runs a SQL query to select largest number used in current project numbers and return it as an int type.
        /// Could just replace(pNumber, 'P', '') or take right(pNumber,4) but wanted to future proof as best I could:
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/18625548/select-query-to-remove-non-numeric-characters
        /// </remarks>
        public int getLastProjectNumber()
        {
            int pNumInt;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SQL_Stuff.conString;
                conn.Credential = SQL_Stuff.credential;
                using (conn)
                {
                    //create new SQL query
                    SqlCommand qryGetNewProjectNumber = new SqlCommand();
                    qryGetNewProjectNumber.Connection = conn;
                    qryGetNewProjectNumber.CommandText =
                        "SELECT max(cast(LEFT(SUBSTRING(ProjectNumber, PATINDEX('%[0-9.-]%', ProjectNumber), 8000) "
                        + ",PATINDEX('%[^0-9.-]%',	SUBSTRING(ProjectNumber, PATINDEX('%[0-9.-]%', ProjectNumber), 8000) + 'X') -1) as int)) "
                        + "from [dbo].[tblProject]";
                    //open connection and execute query, returing result in variable pNumInt
                    conn.Open();
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
        /// <returns>
        /// New project number in the style "P0000"
        /// </returns>
        public string getNewProjectNumber(int pNumInt)
        {
            string pNumZeroes = new string('0', 4); //repeated 0 four times
            string pNumber;
            pNumber = pNumZeroes + pNumInt.ToString();
            pNumber = "P" + pNumber.Substring(pNumber.Length - 4);

            return pNumber;
        }

        /// <summary>
        /// Checks if mandatory fields have an entry.
        /// </summary>
        /// <param name="mdl_Project"></param>
        /// <returns> 
        /// 'true' if all fields are populated, 'false' and mesaagebox feedback if any are missing.
        /// </returns>
        public bool requiredFields(mdl_Project mdl_Project)
        {
            bool requiredFields = true;

            if (string.IsNullOrWhiteSpace(mdl_Project.ProjectName))
            {
                MessageBox.Show("Please enter a Project Title.");
                requiredFields = false;
            }
            if (mdl_Project.LeadApplicant == null || mdl_Project.LeadApplicant < 0)
            {
                MessageBox.Show("Please select a Lead Applicant.");
                requiredFields = false;
            }

            return requiredFields;
        }

        /// <summary>
        /// Checks if mandatory fields have an entry.
        /// </summary>
        /// <param name="mdl_Project"></param>
        /// <returns> 
        /// 'true' if all fields are populated, 'false' and mesaagebox feedback if any are missing.
        /// </returns>
        public bool requiredDocFields(mdl_ProjectDoc mdl_ProjectDoc)
        {
            if (mdl_ProjectDoc.DocumentType < 1 || mdl_ProjectDoc.DocumentType == null)
            {
                MessageBox.Show("Please choose a Document Type.");
                return false;
            }
            if (mdl_ProjectDoc.Submitted == null)
            {
                MessageBox.Show("Please enter a Submitted Date.");
                return false;
            }

            return true;
        }
    }
}
