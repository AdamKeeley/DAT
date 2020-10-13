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
            setTabIndex();
            fillUserDataSet();
            setControlDataSource();
            fillDataGridView();
        }

        DataSet ds_User;
        bool textChanged = true;

        /// <summary>
        /// Creates a new class object from Project class and calls method getProjectsDataSet() to populate DataSet in this class (ds_Project).
        /// </summary>
        private void fillUserDataSet()
        {
            var Users = new User();
            ds_User = Users.getUsersDataSet();
        }

        private void setControlDataSource()
        {
            try
            {
                // Setting DataSource and SelectedIndex triggers the TextChanged event, which is set to run 
                // searchItemAdded method. This boolean flag prevents the method from running fillDataGridView 
                // multiple times
                textChanged = false;

                // set control values
                cb_UserStatus.DataSource = ds_User.Tables["tlkUserStatus"];
                cb_UserStatus.ValueMember = "StatusID";
                cb_UserStatus.DisplayMember = "StatusDescription";
                cb_UserStatus.SelectedIndex = -1;
                cb_UserTitle.DataSource = ds_User.Tables["tlkTitle"];
                cb_UserTitle.ValueMember = "TitleID";
                cb_UserTitle.DisplayMember = "TitleDescription";
                cb_UserTitle.SelectedIndex = -1;

                textChanged = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Method setControlDataSource of class frm_UserAll has failed" + Environment.NewLine + Environment.NewLine + e);
                //throw;
            }
        }

        private void fillDataGridView()
        {
            // Generate filter string fragments
            string filterAll            = "UserNumber like '%'";
            string filterStatus         = $"Status like '%{cb_UserStatus.Text}%'";
            string filterTitle          = $"Title like '%{cb_UserTitle.Text}%'";
            string filterFirstName      = $"FirstName like '%{tb_FirstName.Text}%'";
            string filterLastName       = $"LastName like '%{tb_LastName.Text}%'";
            string filterEmail          = $"Email like '%{tb_Email.Text}%'";
            string filterUserName       = $"UserName like '%{tb_UserName.Text}%'";
            string filterOrganisation   = $"Organisation like '%{tb_Organisation.Text}%'";

            // Build filter string
            if (cb_UserStatus.SelectedIndex > -1)
                filterAll += " AND " + filterStatus;
            if (cb_UserTitle.SelectedIndex > -1)
                filterAll += " AND " + filterTitle;
            if (tb_FirstName.Text != "")
                filterAll += " AND " + filterFirstName;
            if (tb_LastName.Text != "")
                filterAll += " AND " + filterLastName;
            if (tb_Email.Text != "")
                filterAll += " AND " + filterEmail;
            if (tb_UserName.Text != "")
                filterAll += " AND " + filterUserName;
            if (tb_Organisation.Text != "")
                filterAll += " AND " + filterOrganisation;

            //DataTable to fill with de-normalised text values of all users
            DataTable dt_UserList = new DataTable();
            dt_UserList.Columns.Add("UserNumber");
            dt_UserList.Columns.Add("Status");
            dt_UserList.Columns.Add("Title");
            dt_UserList.Columns.Add("FirstName");
            dt_UserList.Columns.Add("LastName");
            dt_UserList.Columns.Add("Email");
            dt_UserList.Columns.Add("UserName");
            dt_UserList.Columns.Add("Organisation");

            DataRow a_row;
            foreach (DataRow uRow in ds_User.Tables["tblUser"].Rows)
            {
                a_row = dt_UserList.NewRow();

                a_row["UserNumber"] = uRow["UserNumber"];
                foreach (DataRow sRow in uRow.GetParentRows("User_UserStatus"))
                {
                    a_row["Status"] = sRow["StatusDescription"];
                }
                foreach (DataRow tRow in uRow.GetParentRows("User_Title"))
                {
                    a_row["Title"] = tRow["TitleDescription"];
                }
                a_row["FirstName"] = uRow["FirstName"];
                a_row["LastName"] = uRow["LastName"];
                a_row["Email"] = uRow["Email"];
                a_row["UserName"] = uRow["UserName"];
                a_row["Organisation"] = uRow["Organisation"];

                dt_UserList.Rows.Add(a_row);
            }

            //DataTable to fill with filtered text values of all users
            DataTable dt_dgv_UserList = new DataTable();
            dt_dgv_UserList.Columns.Add("User Number");
            dt_dgv_UserList.Columns.Add("Status");
            dt_dgv_UserList.Columns.Add("Title");
            dt_dgv_UserList.Columns.Add("First Name");
            dt_dgv_UserList.Columns.Add("Last Name");
            dt_dgv_UserList.Columns.Add("Email");
            dt_dgv_UserList.Columns.Add("User Name");
            dt_dgv_UserList.Columns.Add("Organisation");

            DataRow f_row;
            foreach (DataRow uRow in dt_UserList.Select(filterAll))
            {
                f_row = dt_dgv_UserList.NewRow();
                
                f_row["User Number"] = uRow["UserNumber"];
                f_row["Status"] = uRow["Status"];
                f_row["Title"] = uRow["Title"];
                f_row["First Name"] = uRow["FirstName"];
                f_row["Last Name"] = uRow["LastName"];
                f_row["Email"] = uRow["Email"];
                f_row["User Name"] = uRow["UserName"];
                f_row["Organisation"] = uRow["Organisation"];
                
                dt_dgv_UserList.Rows.Add(f_row);
            }

            dgv_UserList.DataSource = dt_dgv_UserList;
            dgv_UserList.Sort(dgv_UserList.Columns["Last Name"], ListSortDirection.Descending);

            dgv_UserList.Columns["User Number"].Visible = false;
            dgv_UserList.Columns["Status"].Width = 50;
            dgv_UserList.Columns["Title"].Width = 50;
            dgv_UserList.Columns["First Name"].Width = 100;
            dgv_UserList.Columns["Last Name"].Width = 100;
            dgv_UserList.Columns["Email"].Width = 180;
            dgv_UserList.Columns["User Name"].Width = 70;
            dgv_UserList.Columns["Organisation"].Width = 200;

            lbl_recordCount.Text = dt_dgv_UserList.Rows.Count.ToString() + " records";
        }

        /// <summary>
        /// Each control on form assigned a tab index.
        /// If any controls are added/removed it's easier to change here than on actual form!
        /// </summary>
        private void setTabIndex()
        {
            int x = 999;
            foreach (Control c in this.Controls)
            {
                c.TabIndex = x;
            }

            x = 0;

            cb_UserStatus.TabIndex = ++x;
            cb_UserTitle.TabIndex = ++x;
            tb_FirstName.TabIndex = ++x;
            tb_LastName.TabIndex = ++x;
            tb_UserName.TabIndex = ++x;
            tb_Email.TabIndex = ++x;
            tb_Organisation.TabIndex = ++x;

            btn_Refresh.TabIndex = ++x;
            btn_ClearSearch.TabIndex = ++x;
            btn_NewUser.TabIndex = ++x;
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

        private void searchItemAdded(object sender, EventArgs e)
        {
            if (textChanged == true)
                fillDataGridView();
        }

        private void clearSearch(object sender, EventArgs e)
        {
            cb_UserStatus.SelectedIndex = -1;
            cb_UserTitle.SelectedIndex = -1;
            tb_FirstName.Clear();
            tb_LastName.Clear();
            tb_UserName.Clear();
            tb_Email.Clear();
            tb_Organisation.Clear();

            fillDataGridView();
        }

        private void open_frm_UserAdd(object sender, EventArgs e)
        {
            using (frm_UserAdd UserAdd = new frm_UserAdd())
            {
                UserAdd.ShowDialog();
                refreshPage(UserAdd, e);
            }
        }

        private void refreshPage(object sender, EventArgs e)
        {
            fillUserDataSet();
            setControlDataSource();
            fillDataGridView();
        }
    }
}
