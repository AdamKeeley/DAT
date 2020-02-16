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
    public class SQL_Stuff
    {
        //constructor
        public SQL_Stuff()
        {
            conString = "Data Source=GHOST\\SQLEXPRESS;Initial Catalog=DST_CMS;Integrated Security=True";
        }

        //members
        string conString { get; }
        public string getString()
        {
            return conString;
        }
        public void testConnection()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand qryTestConnection = new SqlCommand();
                qryTestConnection.Connection = connection;
                qryTestConnection.CommandText = "select 1";
                try
                {
                    connection.Open();
                    qryTestConnection.ExecuteScalar();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection to database could not be established");
                    throw;
                }
            }
        }
    }
}

