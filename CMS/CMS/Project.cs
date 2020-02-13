using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
            //use the central connection string from the SQL_Stuff class
            SQL_Stuff conString = new SQL_Stuff();
            using (SqlConnection connection = new SqlConnection(conString.getString()))
            {
                //use a DataAdapter (da_Project) to add a DataTable (tblProjects) to a DataSet (ds_Project) 
                //from a SQL Server query (qryGetProject)
                SqlCommand qryGetProject = new SqlCommand();
                SqlDataAdapter da_Project = new SqlDataAdapter();
                DataSet ds_prj = new DataSet("Projects");
                qryGetProject.CommandText = $"select * from [dbo].[tblProject] where [ValidTo] is null order by [pNumber]";
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

                //return DataSet (ds_prj) as the output of this method
                return ds_prj;
            }
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
                connection.Close();
            }
        }

        //method to insert new project
        public void insertProject (string pNumber, string pName, int pStage, string pPI, DateTime? pStartDate, DateTime? pEndDate)
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
                connection.Close();
            }
        }
    }        
}

