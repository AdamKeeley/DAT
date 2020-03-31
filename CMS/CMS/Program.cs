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
             * Create All Projects form
             *  - select project from list
             *  - search for project
             * Create Users form
             * 	- Determine items that need to be recorded on User Log
             * 	- Normalise Users to seperate SQL table
             * 		- include DAT
             * 	Create Documents form
             * 	    - incorporate some sort of 'timeline' of submitted documents?
             * 	Create Platform form
             * 	    - tabs for various platforms?
             * 	    - or all on one screen?
             */

            string pNumber = "P0001";

            //test connection to database
            SQL_Stuff testCon = new SQL_Stuff();
            testCon.testConnection();

            //initialise form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Project(pNumber));
        }
    }                                                 
}
