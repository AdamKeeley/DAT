using System.Data.SqlClient;

namespace DataControlsLib
{
    public static class SQL_Stuff
    {
        public static SqlCredential credential { get; set; }
        public static string conString { get; set; }
        public static void getString()
        {
            //Azure!
            SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = "lida-dat-cms.database.windows.net",
                ["Initial Catalog"] = "lida_dat_cms",
                ["Integrated Security"] = "False",
                ["Persist Security Info"] = "False",
                ["Encrypt"] = "True",
            };
            conString = conStringBuilder.ConnectionString;
            
            ////Adam's LIDA desktop
            //conString = "Data Source=IRC-PC010;Initial Catalog=DAT_CMS;Integrated Security=True";

            ////Adam's laptop
            //conString = "Data Source=LIDA-LT-040704\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";

            //// Sean's laptop
            //conString = "Data Source=SEAN-LAPTOP\\SQLEXPRESS;Initial Catalog=DAT_CMS;Integrated Security=True";
        }
    }
}

