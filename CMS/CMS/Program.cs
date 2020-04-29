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
             * Populates DataSet from SQL db when 
             *  - frm_Project initiated (frm_Project)
             *  - insert new project record (updateProject)
             *  - new project added (ProjectAdd_FormClosing)
             *  - refresh button clicked (btn_Refresh_Click)
             *  - project note added (addProjectNote)
             *  
             *  Can it be cut any more?
             */


            /* TO DO
             * 
             * Create Users form
             * Create Add User form
             * Create Documents form
             *     - incorporate some sort of 'timeline' of submitted documents?
             * Create Platform form
             *     - tabs for various platforms?
             *     - or all on one screen?
             * Combine all into single form with sub forms or create navigation form?
             * 	    
             */

            /* DONE
             * 
             * Normalised Users to seperate SQL table
             * Updated frm_ProjectAll, frm_Project and frm_ProjectAdd to handle normalised user table
             * 
             * Tightened up the date checking on project record inserts
             * 
             * Created Users Class
             *  - Method to fill User DataSet
             * 
             * Nulls are handled better, allowing updates with empty fields
             * 
             * Created All Projects form
             *  - select project from list
             *  - search for project
             * 
             */

            //test connection to database
            SQL_Stuff testCon = new SQL_Stuff();
            testCon.testConnection();

            //initialise form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_ProjectAll());
        }
    }                                                 
}
