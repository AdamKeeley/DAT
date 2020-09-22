using System;
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
             * Project Documents 
             *      - stop forms from closing!
             *      
             * Add additional field for Waywell's portfolio number or enable ability to change project number?
             *    
             * Compartmentalise getDataSet?
             *     
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
