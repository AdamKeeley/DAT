using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_DsaAdd : Form
    {
        public frm_DsaAdd()
        {
            InitializeComponent();
        }

        public void SetInitialControls()
        {
            // Get: projects list, data owners list, dsas list
            // Set: dates, projects list, data owners list, dsas list

            // Set initially displayed star/expiry dates to today, rather than some random date
            dtp_StartDate.Value = DateTime.Now.Date;
            dtp_ExpiryDate.Value = DateTime.Now.Date;


        }

        public void CollectInputs()
        {
            // Put control selections into data model objects ready for passing to DB put method
            throw new NotImplementedException();
        }
    }
}
