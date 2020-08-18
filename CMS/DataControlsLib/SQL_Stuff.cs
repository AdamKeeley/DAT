using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataControlsLib
{
    public class SQL_Stuff
    {
        //constructor
        public SQL_Stuff()
        {
            ////Adam's home
            //conString = "Data Source=GHOST\\SQLEXPRESS;Initial Catalog=DST_CMS;Integrated Security=True";

            ////azure
            //conString = "Data Source=lida.database.windows.net;Initial Catalog=DAT_CMS;Integrated Security=False; "
            //+ "Persist Security Info=False;User ID=uitake;Password=##############;";

            ////Adam's LIDA desktop
            //conString = "Data Source=IRC-PC010;Initial Catalog=DAT_CMS;Integrated Security=True";

            //Adam's laptop
            conString = "Data Source=LIDA-LT-040704\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";

            //// Sean's laptop
            //conString = "Data Source=SEAN-LAPTOP\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";
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
                }
            }
        }
    }
}

