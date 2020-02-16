using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CMS
{
    class Project
    {
        //constructor - used to instantiate each Project type object and populate DataTable member (dt_Project)
        public Project()
        {
            this.ds_Project = getProjectsDataSet();
        }

        //members
        //the DataSet to be filled at instantiation
        public DataSet ds_Project { get; set; }

        //method to return a DataSet with content of SQL table tblProjects
        public DataSet getProjectsDataSet()
        {
            DataSet ds_prj = new DataSet("Projects");
            try
            {
                //use the central connection string from the SQL_Stuff class
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //use a DataAdapter (da_Project) to add a DataTable (tblProjects) to a DataSet (ds_Project) 
                    //from a SQL Server query (qryGetProject)
                    SqlDataAdapter da_Project = new SqlDataAdapter();
                    SqlCommand qryGetProject = new SqlCommand();
                    qryGetProject.CommandText = $"select * from [dbo].[tblProject] where [ValidTo] is null order by [pNumber], [pID]";
                    qryGetProject.Connection = connection;
                    da_Project.SelectCommand = qryGetProject;
                    da_Project.Fill(ds_prj, "tblProjects");

                    //add tlkStage DataTable to DataSet (ds_prj)
                    SqlCommand qryGetStage = new SqlCommand();
                    qryGetStage.CommandText = $"select * from [dbo].[tlkStage] where [ValidTo] is null";
                    qryGetStage.Connection = connection;
                    da_Project.SelectCommand = qryGetStage;
                    da_Project.Fill(ds_prj, "tlkStage");
                    //create a DataRelation (rltnProjectStage) to join tlkStage to tblProjects
                    ds_prj.Relations.Add("Project_Stage"
                        , ds_prj.Tables["tlkStage"].Columns["StageID"]          //parent
                        , ds_prj.Tables["tblProjects"].Columns["pStage"]);      //child

                    //add tblProjectNotes DataTable to DataSet (ds_prj)
                    //DataRelation not needed, can just query DataTable directly using same pNumber parameter
                    SqlCommand qryGetNotes = new SqlCommand();
                    qryGetNotes.CommandText = $"select * from [dbo].[tblProjectNotes] order by [pNumber], [Created] desc";
                    qryGetNotes.Connection = connection;
                    da_Project.SelectCommand = qryGetNotes;
                    da_Project.Fill(ds_prj, "tblProjectNotes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to populate DataSet");
                Console.WriteLine(ex);
                throw;
            }
                //return DataSet (ds_prj) as the output of this method
                return ds_prj;
        }

        //method to return table in member DataSet (ds_Project.Tables["tblProjects"]) as a tab delimited (\t) string
        public string getProjectsToString()
        {
            string pNumber;
            string pName;
            string pStage = string.Empty;
            string pPI;
            string pStartDate;
            string pEndDate;

            //create a new string (pListProjects) using StringBuilder
            var pListProjects = new StringBuilder();
            //add tab delimited (\t) headers as first row
            pListProjects.AppendLine("Project Number\tProject Name\tStage\tPI\tStart Date\tEnd Date");
            //loop through each row in DataTable (dt_Project), assign each column value to a class property member 
            //and add a new row to the string (pListProjects)
            foreach (DataRow pRow in ds_Project.Tables["tblProjects"].Rows)
            {
                pNumber = pRow["pNumber"].ToString();
                pName = pRow["pName"].ToString();
                //use DataRelation (Project_Stage) to return string description of stage, not int stored value
                foreach (DataRow sRow in pRow.GetParentRows("Project_Stage"))
                {
                    pStage = sRow["pStageDescription"].ToString();
                }
                pPI = pRow["pPI"].ToString();
                pStartDate = pRow["pStartDate"].ToString();
                pEndDate = pRow["pEndDate"].ToString();
                pListProjects.AppendLine($"{pNumber}\t{pName}\t{pStage}\t{pPI}\t{pStartDate}\t{pEndDate}");
            }
            //output the complete string (pListProjects)
            return pListProjects.ToString();
        }

        //method to 'delete' project; doesn't actually delete any records, performs a logical delete
        public void deleteProject(string pNumber)
        {
            try
            {
                //query the DataTable for the row identifier (pID) of current record of project to update
                int pID;
                DataRow[] dr_ProjectToUpdate;
                dr_ProjectToUpdate = ds_Project.Tables["tblProjects"].Select($"pNumber = '{pNumber}' and ValidTo is null");
                pID = (int)dr_ProjectToUpdate[0]["pID"];

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
                Console.WriteLine("Failed to delete record");
                Console.WriteLine(ex);
                throw;
            }
        }
    
        //method to insert project record
        public void insertProject (string pNumber, string pName, int pStage, string pPI, DateTime? pStartDate, DateTime? pEndDate)
        {
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //generate the parameterised SQL query to insert new record
                    SqlCommand qryInsertProject = new SqlCommand();
                    qryInsertProject.Connection = connection;
                    qryInsertProject.CommandText = "insert into [dbo].[tblProject] ([pNumber],[pName],[pStage],[pPI],[pStartDate],[pEndDate]) values "
                        + "(@pNumber, @pName, @pStage, @pPI, @pStartDate, @pEndDate)";

                    //assign the parameter values
                    qryInsertProject.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryInsertProject.Parameters.Add("@pName", SqlDbType.VarChar, 100).Value = pName;
                    qryInsertProject.Parameters.Add("@pStage", SqlDbType.VarChar, 20).Value = pStage;
                    qryInsertProject.Parameters.Add("@pPI", SqlDbType.VarChar, 60).Value = pPI;
                    //dates are fuckey
                    //while i'm not fussed about empty strings i want to avoid 1900-01-01 and use NULL for missing values
                    SqlParameter param_pStartDate = new SqlParameter("@pStartDate", pStartDate == null ? (object)DBNull.Value : pStartDate);
                    param_pStartDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_pStartDate);
                    SqlParameter param_pEndDate = new SqlParameter("@pEndDate", pEndDate == null ? (object)DBNull.Value : pEndDate);
                    param_pEndDate.IsNullable = true;
                    qryInsertProject.Parameters.Add(param_pEndDate);
                    //open connection to database, run query and close connection
                    connection.Open();
                    qryInsertProject.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to insert new project record");
                Console.WriteLine(ex);
                throw;
            }
        }

        //method to return a single project in member DataSet (ds_Project.Tables["tblProjects"]) as a tab delimited (\t) string
        public string getProjectToString(string pNumber)
        {
            string pName;
            string pStage = string.Empty;
            string pPI;
            string pStartDate;
            string pEndDate;

            //if no records found, try will fail at "DataRow pRow = pRows[i];" and go to catch
            try
            {
                DataRow[] pRows = ds_Project.Tables["tblProjects"].Select($"pNumber = '{pNumber}'");

                //there's always a small a chance a project might have multiple records where ValidTo is null
                //DataSet (ds_prj) is populated ordered by pNumber and then pID so largest (last added) pID for each project is last
                //feed back to user if more than one 'current' project record
                if (pRows.Count() > 1)
                {
                    Console.WriteLine("More than one current record found for this project, showing last only");
                }

                //active row (pRow) filled with last row from pRows
                int i = pRows.Count() - 1;
                DataRow pRow = pRows[i];

                //populate variables with values from pRow
                pName = pRow["pName"].ToString();
                //use DataRelation (Project_Stage) to return string description of stage, not int stored value
                foreach (DataRow sRow in pRow.GetParentRows("Project_Stage"))
                {
                    pStage = sRow["pStageDescription"].ToString();
                }
                pPI = pRow["pPI"].ToString();
                pStartDate = pRow["pStartDate"].ToString();
                pEndDate = pRow["pEndDate"].ToString();

                //create a new string (pProjectDetails) using StringBuilder
                var pProjectDetails = new StringBuilder();
                //add tab delimited (\t) headers as first row
                pProjectDetails.AppendLine("Project Number\tProject Name\tStage\tPI\tStart Date\tEnd Date");
                //add tab delimited (\t) field values
                pProjectDetails.AppendLine($"{pNumber}\t{pName}\t{pStage}\t{pPI}\t{pStartDate}\t{pEndDate}");

                return pProjectDetails.ToString();
            }
            catch (Exception)
            {
                return "Project number not found";
                throw;
            }
        }

        //method to return project notes in member DataSet (ds_Project.Tables["tblProjectNotes"]) as a tab delimited (\t) string
        public string getProjectNotesToString(string pNumber)
        {
            string nCreatedDate;
            string nCreatedBy;
            string nNote;

            //query DataTable (tblProjectNotes) to return all records with pNumber of interest
            DataRow[] nRows = ds_Project.Tables["tblProjectNotes"].Select($"pNumber = '{pNumber}'");
            //if records found add each one to output, otherwise feed back that no records found
            if (nRows.Count() > 0)
            {
                //create a new string (pProjectNotes) using StringBuilder
                var pProjectNotes = new StringBuilder();
                //add tab delimited (\t) headers as first row
                pProjectNotes.AppendLine("Created\tCreatedBy\tNote");
                //cycle through records and add each one to output
                foreach (DataRow nRow in nRows)
                {
                    nCreatedDate = nRow["Created"].ToString();
                    nCreatedBy = nRow["CreatedBy"].ToString();
                    nNote = nRow["pNote"].ToString();
                    pProjectNotes.AppendLine($"{nCreatedDate}\t{nCreatedBy}\t{nNote}");
                }
                return pProjectNotes.ToString();
            }
            else
            {
                return "No notes found";
            }
        }

        //method to leave a project note
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
                        + "([pNumber],[pNote]) values (@pNumber, @pNote)";
                    qryInsertProjectNote.Parameters.Add("@pNumber", SqlDbType.VarChar, 5).Value = pNumber;
                    qryInsertProjectNote.Parameters.Add("@pNote", SqlDbType.VarChar, 8000).Value = pNote;

                    //open connection and execute insert
                    connection.Open();
                    qryInsertProjectNote.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new note" + Environment.NewLine + ex);
                throw;
            }
        }

        //method to generate new pNumber sequentially from current pNumbers
        public string getNewProjectNumber()
        {
            int pNumInt;
            string pNumZeroes = new string('0', 4); //repeated 0 four times
            string pNumber;
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create new SQL query
                    SqlCommand qryGetNewProjectNumber = new SqlCommand();
                    qryGetNewProjectNumber.Connection = connection;
                    //SQL query to select largest number used in current project numbers and add one
                    //could just replace(pNumber, 'P', '') or take right(pNumber,4) but wanted to future proof as best I could:
                    //https://stackoverflow.com/questions/18625548/select-query-to-remove-non-numeric-characters
                    qryGetNewProjectNumber.CommandText =
                        "SELECT max(cast(LEFT(SUBSTRING(pNumber, PATINDEX('%[0-9.-]%', pNumber), 8000) "
                        + ",PATINDEX('%[^0-9.-]%',	SUBSTRING(pNumber, PATINDEX('%[0-9.-]%', pNumber), 8000) + 'X') -1) as int)) "
                        + "+ 1 from [dbo].[tblProject]";
                    //open connection and execute query, returing result in variable pNumInt
                    connection.Open();
                    pNumInt = (int)qryGetNewProjectNumber.ExecuteScalar();
                }
                //construct pNumber from returned result
                //a 'P' and rightermost 4 characters from repeated zeroes with largest int from above query appended
                pNumber = pNumZeroes + pNumInt.ToString();
                pNumber = "P" + pNumber.Substring(pNumber.Length - 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate new Project Number" + Environment.NewLine + Environment.NewLine + ex);
                throw;
            }
            return pNumber;
        }

        //method to get largest pNumber from current pNumbers
        public string getLastProjectNumber()
        {
            int pNumInt;
            string pNumZeroes = new string('0', 4); //repeated 0 four times
            string pNumber;
            try
            {
                SQL_Stuff conString = new SQL_Stuff();
                using (SqlConnection connection = new SqlConnection(conString.getString()))
                {
                    //create new SQL query
                    SqlCommand qryGetNewProjectNumber = new SqlCommand();
                    qryGetNewProjectNumber.Connection = connection;
                    //SQL query to select largest number used in current project numbers and add one
                    //could just replace(pNumber, 'P', '') or take right(pNumber,4) but wanted to future proof as best I could:
                    //https://stackoverflow.com/questions/18625548/select-query-to-remove-non-numeric-characters
                    qryGetNewProjectNumber.CommandText =
                        "SELECT max(cast(LEFT(SUBSTRING(pNumber, PATINDEX('%[0-9.-]%', pNumber), 8000) "
                        + ",PATINDEX('%[^0-9.-]%',	SUBSTRING(pNumber, PATINDEX('%[0-9.-]%', pNumber), 8000) + 'X') -1) as int)) "
                        + "from [dbo].[tblProject]";
                    //open connection and execute query, returing result in variable pNumInt
                    connection.Open();
                    pNumInt = (int)qryGetNewProjectNumber.ExecuteScalar();
                }
                //construct pNumber from returned result
                //a 'P' and rightermost 4 characters from repeated zeroes with largest int from above query appended
                pNumber = pNumZeroes + pNumInt.ToString();
                pNumber = "P" + pNumber.Substring(pNumber.Length - 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to fetch new Project Number" + Environment.NewLine + Environment.NewLine + ex);
                throw;
            }
            return pNumber;
        }

        //method to populate list that feeds into frm_Project controls
        public List<string> getProjectToList(string pNumber)
        {
            string pName;
            string pStage = string.Empty;
            string pPI;
            string pStartDate;
            string pEndDate;
            List<string> lst_Project = new List<string>();

            //if no records found, try will fail at "DataRow pRow = pRows[i];" and go to catch
            try
            {
                DataRow[] pRows = ds_Project.Tables["tblProjects"].Select($"pNumber = '{pNumber}'");

                //there's always a small a chance a project might have multiple records where ValidTo is null
                //DataSet (ds_prj) is populated ordered by pNumber and then pID so largest (last added) pID for each project is last
                //feed back to user if more than one 'current' project record
                if (pRows.Count() > 1)
                {
                    MessageBox.Show("More than one current record found for this project, showing last only");
                }

                //active row (pRow) filled with last row from pRows
                int i = pRows.Count() - 1;
                DataRow pRow = pRows[i];
                
                //populate DataRow to output with values from pRow
                pName = pRow["pName"].ToString();
                //use DataRelation (Project_Stage) to return string description of stage, not int stored value
                foreach (DataRow sRow in pRow.GetParentRows("Project_Stage"))
                {
                    pStage = sRow["pStageDescription"].ToString();
                }
                pPI = pRow["pPI"].ToString();
                pStartDate = pRow["pStartDate"].ToString();
                pEndDate = pRow["pEndDate"].ToString();

                lst_Project.Add(pNumber);
                lst_Project.Add(pName);
                lst_Project.Add(pStage);
                lst_Project.Add(pPI);
                lst_Project.Add(pStartDate);
                lst_Project.Add(pEndDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load project details" + Environment.NewLine + ex);
                throw;
            }
            return lst_Project;
        }
    }
}        


