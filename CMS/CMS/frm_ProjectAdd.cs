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
    public partial class frm_ProjectAdd : Form
    {
        public frm_ProjectAdd()
        {
            InitializeComponent();
            set_frmProjectAdd();
        }

        private void set_frmProjectAdd()
        {
            //instantiate new Project type object that contains project methods
            var Projects = new Project();
            
            //generate new pNumber and put it into a variable
            string pNumber = Projects.getNewProjectNumber();
            
            //bind a datasource to Stage combobox
            this.cb_pStage.DataSource = Projects.ds_Project.Tables["tlkStage"];
            this.cb_pStage.ValueMember = "StageID";
            this.cb_pStage.DisplayMember = "pStageDescription";

            //populate pNumber
            lbl_NewProjectNumber.Text = pNumber;
        }

        private void insertNewProject()
        {
            bool dateCheck = true;
            //instantiate new Project type object that contains project methods
            var Projects = new Project();

            string pNumber = this.lbl_NewProjectNumber.Text;
            string pName = this.tb_pNameValue.Text;
            string pPI = this.tb_pPIValue.Text;
            int pStage = int.Parse(this.cb_pStage.SelectedValue.ToString());
            //dates are fuckey
            DateTime? pStartDate = null;
            DateTime? pEndDate = null;
            if (mtb_pStartDateValue.Text != "" & mtb_pStartDateValue.Text != "  /  /")
                try
                {
                    pStartDate = Convert.ToDateTime(mtb_pStartDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Start Date");
                    dateCheck = false;
                }
            if (mtb_pEndDateValue.Text != "" & mtb_pEndDateValue.Text != "  /  /")
                try
                {
                    pStartDate = Convert.ToDateTime(mtb_pEndDateValue.Text);
                    dateCheck = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid End Date");
                    dateCheck = false;
                }

            if (dateCheck == true)
            {
                Projects.insertProject(pNumber, pName, pStage, pPI, pStartDate, pEndDate, false, false);
                MessageBox.Show($"New project added to registry, project number = {pNumber}");
                this.Close();
            }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            insertNewProject();
        }
    }
}
