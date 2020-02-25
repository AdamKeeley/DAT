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
             * converted to winform
             * single project details read done
             * need to read all projects to new form
             * drill down into single project 
             * 
             * normalise PI?
             * add users? if i add users then deffo normalise PI. 
             *     create new Users class
             * final needs pNumber to be read only
             * allow changes to pName? yes
             * refresh DataSet before every display change
             */
            
            /*
             * frm_Project designer creates form (don't fuck with code here)
             * SQL Server connection string and method to test connection present in SQL_Stuff.cs
             * methods to fetch project data from SQL Server present within Project.cs
             * methods to populate form with project data present in form.cs (right click form.cs --> view code)
             * call methods from form.cs constructor, after 'initialise form'
             */

            string pNumber = "P0001";
            //string pName = "Third project with auto generated pNumber";
            //int pStage = 3;
            //string pPI = "Baron Remove Non-Numeric";
            //DateTime? pStartDate = Convert.ToDateTime("03/08/2020");
            //DateTime? pEndDate = DateTime.Now;
            //string pNote = $"This is another note for project {pNumber}";

            //test connection to database
            SQL_Stuff testCon = new SQL_Stuff();
            testCon.testConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Project(pNumber));
            
        }
    }                                                        
}
