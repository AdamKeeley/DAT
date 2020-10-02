using System;
using System.Data.SqlClient;
using System.Security;
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
             * Create Login form
             * 
             * Update user list combobox datasource when adding new user from new project
             * Confirm New Project Details (a la New User)
             * AcceptDocument to perform logical delete and insert rather than update
             * Link Projects to VREs
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

            //initialise form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_Login());
            Application.Run(new frm_HomePage());

        }
    }                                                 
}
