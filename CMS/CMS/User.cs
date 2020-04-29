using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    //use a DataAdapter (da_User) to add a DataTable (tblUser) to a DataSet (ds_usr) 
                    //from a SQL Server query (qryGetUser)
                    SqlDataAdapter da_User = new SqlDataAdapter();
                    SqlCommand qryGetUser = new SqlCommand();
                    qryGetUser.CommandText = $"select * from [dbo].[tblUser] where [ValidTo] is null order by [LastName], [FirstName]";
                    qryGetUser.Connection = connection;
                    da_User.SelectCommand = qryGetUser;
                    da_User.Fill(ds_usr, "tblUser");

                    //add tlkUserStatus DataTable to DataSet (ds_usr)
                    SqlCommand qryGetUserStatus = new SqlCommand();
                    qryGetUserStatus.CommandText = $"select * from [dbo].[tlkUserStatus] where [ValidTo] is null";
                    qryGetUserStatus.Connection = connection;
                    da_User.SelectCommand = qryGetUserStatus;
                    da_User.Fill(ds_usr, "tlkUserStatus");
                    //create a DataRelation (User_UserStatus) to join tlkUserStatus to tblUser
                    ds_usr.Relations.Add("User_UserStatus"
                        , ds_usr.Tables["tlkUserStatus"].Columns["StatusID"]    //parent
                        , ds_usr.Tables["tblUser"].Columns["Status"]);          //child

                    //add tlkTitle DataTable to DataSet (ds_usr)
                    SqlCommand qryGetTitle = new SqlCommand();
                    qryGetTitle.CommandText = $"select * from [dbo].[tlkTitle] where [ValidTo] is null";
                    qryGetTitle.Connection = connection;
                    da_User.SelectCommand = qryGetTitle;
                    da_User.Fill(ds_usr, "tlkTitle");
                    //create a DataRelation (User_UserStatus) to join tlkUserStatus to tblUser
                    ds_usr.Relations.Add("User_Title"
                        , ds_usr.Tables["tlkTitle"].Columns["TitleID"]      //parent
                        , ds_usr.Tables["tblUser"].Columns["Title"]);       //child

                    //add tblUserNotes DataTable to DataSet (ds_usr)
                    //DataRelation not needed, can just query DataTable directly using same UserID parameter
                    SqlCommand qryGetUserNotes = new SqlCommand();
                    qryGetUserNotes.CommandText = $"select * from [dbo].[tblUserNotes] where [ValidTo] is null";
                    qryGetUserNotes.Connection = connection;
                    da_User.SelectCommand = qryGetUserNotes;
                    da_User.Fill(ds_usr, "tblUserNotes");

                    //add tblUserProject DataTable to DataSet (ds_usr)
                    //DataRelation not needed, can just query DataTable directly using same UserID parameter
                    SqlCommand qryGetUserProject = new SqlCommand();
                    qryGetUserProject.CommandText = $"select * from [dbo].[tblUserProject] where [ValidTo] is null";
                    qryGetUserProject.Connection = connection;
                    da_User.SelectCommand = qryGetUserProject;
                    da_User.Fill(ds_usr, "tblUserProject");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to populate ds_usr DataSet" + Environment.NewLine + Environment.NewLine + e);
                throw;
            }

            //return DataSet (ds_usr) as the output of this method
            return ds_usr;
        }



    }
}
