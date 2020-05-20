using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*
             * frm_Project designer creates form (don't fuck with code here)
             * SQL Server connection string and method to test connection present in SQL_Stuff.cs
             * methods to fetch project data from SQL Server present within Project.cs
             * methods to populate form with project data present in form.cs (right click form.cs --> view code)
             * call methods from form.cs constructor, after 'initialise form'
             */

            string pNumber = "P0001";

            //test connection to database
            SQL_Stuff testCon = new SQL_Stuff();
            testCon.testConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Project(pNumber));
            
        }
    }                                                        
}
