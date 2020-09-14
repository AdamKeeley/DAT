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
             *     - incorporate some sort of 'timeline' of submitted documents?
             *      x add new ProjectDocuments SQL tables to Project dataset
             *      - create document history form (single document type)
             *      - create all docs form (current/latest only)
             *          - both should include facililty to add new document
             *          - create add document form
             *      - change colour of buttons on parent form dependant on submitted/accepted status?
             *      
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
