using System;
using System.Windows.Forms;

namespace CMS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //initialise form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_HomePage());
        }
    }                                                 
}
