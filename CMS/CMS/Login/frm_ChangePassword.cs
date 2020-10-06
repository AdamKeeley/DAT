using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Login
{
    public partial class frm_ChangePassword : Form
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
        }



        private void btn_ChangePasswordCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChangePasswordOK_Click(object sender, EventArgs e)
        {

        }
    }
}
