using DataControlsLib.DataModels;
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
    public partial class frm_ProjectDocAdd : Form
    {
        public frm_ProjectDocAdd(string pNumber, DataSet ds_prj, int docType)
        {
            InitializeComponent();
            setProjectDocAdd(pNumber, ds_prj, docType);
            fillProjectDocModel();
        }

        bool docTypeChanged = false;
        DataSet ds_Projects;
        int documentType;
        ProjectDocModel mdl_ProjectDoc = new ProjectDocModel();

        private void setProjectDocAdd(string pNumber, DataSet ds_prj, int docType)
        {
            docTypeChanged = false;

            //set member variables
            mdl_ProjectDoc.ProjectNumber = pNumber;
            ds_Projects = ds_prj;
            documentType = docType;

            //set controls values
            cb_DocType.DataSource = ds_Projects.Tables["tlkDocuments"];
            cb_DocType.ValueMember = "DocumentID";
            cb_DocType.DisplayMember = "DocumentDescription";
            cb_DocType.SelectedIndex = -1;

            if (documentType != 0)
            {
                docTypeChanged = true;
                cb_DocType.SelectedValue = documentType;
            }
            docTypeChanged = true;
            mtb_DocSubmitted.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private bool fillProjectDocModel()
        {
            if (cb_DocType.SelectedIndex > -1)
                mdl_ProjectDoc.DocumentType = int.Parse(cb_DocType.SelectedValue.ToString());
            mdl_ProjectDoc.VersionNumber = nud_DocVersion.Value;
            //dates are fuckey
            bool dateCheck = true;
            if (dateCheck == true & mtb_DocSubmitted.Text != "" & mtb_DocSubmitted.Text != "  /  /")
            {
                try
                {
                    mdl_ProjectDoc.Submitted = Convert.ToDateTime(mtb_DocSubmitted.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Submitted Date");
                    dateCheck = false;
                }
            }
            if (dateCheck == true & mtb_DocAccepted.Text != "" & mtb_DocAccepted.Text != "  /  /")
            {
                try
                {
                    mdl_ProjectDoc.Accepted = Convert.ToDateTime(mtb_DocAccepted.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Accepted Date");
                    dateCheck = false;
                }
            }
            return dateCheck;
        }

        private void setNextVersion()
        {
            if (cb_DocType.SelectedIndex > -1)
                mdl_ProjectDoc.DocumentType = int.Parse(cb_DocType.SelectedValue.ToString());

            Project Projects = new Project(); 
            nud_DocVersion.Value = decimal.Parse(Projects.getNextDocVersion(mdl_ProjectDoc).ToString());
        }

        private void insertNewProjectDoc()
        {
            //Check required fields have an entry
            Project Projects = new Project();
            if (Projects.requiredDocFields(mdl_ProjectDoc) == false)
            {
                return;
            }

            if (fillProjectDocModel() == true)
            {
                if (Projects.insertNewDoc(mdl_ProjectDoc) == true)
                    this.Close();
            }
            
        }

        /// <summary>
        /// Prevent the cursor from being positioned in the middle of a masked textbox when 
        /// the user clicks in it. Needs to be called by the OnClick event of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter_TextBox(object sender, EventArgs e)
        {
            MaskedTextBox textBox = sender as MaskedTextBox;
            if (textBox.Text == "  /  /")
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    textBox.Select(0, 0);
                });
            }
        }

        private void cb_DocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (docTypeChanged == true)
                setNextVersion();
        }

        private void btn_DocAddCreate_click(object sender, EventArgs e)
        {

            insertNewProjectDoc();
        }

        private void btn_DocAddCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
