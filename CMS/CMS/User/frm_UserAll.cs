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
    public partial class frm_UserAll : Form
    {
        public frm_UserAll()
        {
            InitializeComponent();
            fillUsersDataSet();
            fillDataGridView();
        }

        DataSet ds_User;
        bool textChanged = true;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillUsersDataSet()
        {
            var Users = new User();
            ds_User = Users.getUsersDataSet();
        }

        private void fillDataGridView()
        {
            //DataTable to fill with de-normalised text values of all users
            DataTable dt_UserList = new DataTable();
            dt_UserList.Columns.Add("User Number");
            dt_UserList.Columns.Add("First Name");
            dt_UserList.Columns.Add("Last Name");
            dt_UserList.Columns.Add("Email");
            dt_UserList.Columns.Add("User Name");
            dt_UserList.Columns.Add("Organisation");

            DataRow a_row;
            foreach (DataRow uRow in ds_User.Tables["tblUser"].Rows)
            {
                a_row = dt_UserList.NewRow();

                a_row["User Number"] = uRow["UserNumber"];
                a_row["First Name"] = uRow["FirstName"];
                a_row["Last Name"] = uRow["LastName"];
                a_row["Email"] = uRow["Email"];
                a_row["User Name"] = uRow["UserName"];
                a_row["Organisation"] = uRow["Organisation"];

                dt_UserList.Rows.Add(a_row);
            }

            dgv_UserList.DataSource = dt_UserList;
            dgv_UserList.Sort(dgv_UserList.Columns["Last Name"], ListSortDirection.Descending);

            dgv_UserList.Columns["User Number"].Visible = false;
            dgv_UserList.Columns["First Name"].Width = 100;
            dgv_UserList.Columns["Last Name"].Width = 100;
            dgv_UserList.Columns["Email"].Width = 180;
            dgv_UserList.Columns["User Name"].Width = 70;
            dgv_UserList.Columns["Organisation"].Width = 200;
        }

        private void dgv_UserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            if (r > -1)
            {
                try
                {
                    int uNumber = int.Parse(dgv_UserList.Rows[r].Cells["User Number"].Value.ToString());
                    frm_User User = new frm_User(uNumber);
                    User.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please double click on a data row to see user details.");
                }
            }
        }
    }
}
