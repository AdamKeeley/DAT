using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataControlsLib;

namespace CMS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /* TO DO
             * 
             * Search/All User
             * 
             * Documents 
             *     - incorporate some sort of 'timeline' of submitted documents?
             * Platform 
             *     - tabs for various platforms?
             *     - or all on one screen?
             *     
             * Combine everything into single form with sub forms or create navigation form?
             * 	    
             */

            //test connection to database
            SQL_Stuff testCon = new SQL_Stuff();
            testCon.testConnection();

            //initialise form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_HomePage());
        }
    }                                                 
}
