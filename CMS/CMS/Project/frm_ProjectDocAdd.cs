using DataControlsLib;
using DataControlsLib.DataModels;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class frm_ProjectDocAdd : Form
    {
        public frm_ProjectDocAdd(string pNumber, DataSet ds_prj, int docType)
        {
            InitializeComponent();
            setTabIndex();
            setProjectDocAdd(pNumber, ds_prj, docType);
            fillProjectDocModel();
        }

        bool docTypeChanged = false;
        DataSet ds_Projects;
        int documentType;
        mdl_ProjectDoc mdl_ProjectDoc = new mdl_ProjectDoc();

        private void setProjectDocAdd(string pNumber, DataSet ds_prj, int docType)
        {
            docTypeChanged = false;

            //set member variables
            mdl_ProjectDoc.ProjectNumber = pNumber;
            ds_Projects = ds_prj;
            documentType = docType;

            //set controls values
            DataView documentItems = new DataView(ds_Projects.Tables["tlkDocuments"]);
            documentItems.RowFilter = "[ValidTo] is null";
            cb_DocType.DataSource = documentItems;
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
            if (cb_DocType.Text != "")
                mdl_ProjectDoc.DocumentType = int.Parse(cb_DocType.SelectedValue.ToString());
            else mdl_ProjectDoc.DocumentType = null;

            mdl_ProjectDoc.VersionNumber = nud_DocVersion.Value;
            
            //dates are fuckey
            if (mtb_DocSubmitted.Text != "" & mtb_DocSubmitted.Text != "  /  /")
            {
                try
                {
                    mdl_ProjectDoc.Submitted = Convert.ToDateTime(mtb_DocSubmitted.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Submitted Date");
                    return false;
                }
            }
            if (mtb_DocAccepted.Text != "" & mtb_DocAccepted.Text != "  /  /")
            {
                try
                {
                    mdl_ProjectDoc.Accepted = Convert.ToDateTime(mtb_DocAccepted.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid Accepted Date");
                    return false;
                }
            }
            return true;
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
            Project Projects = new Project();

            //Check fields have valid entries and fill project document model
            if (fillProjectDocModel() == true)
            {
                //Check required fields have an entry
                if (Projects.requiredDocFields(mdl_ProjectDoc) == true)
                {
                    //Add record to SQL db, close form on success
                    if (Projects.insertNewDoc(mdl_ProjectDoc) == true)
                    { 
                        this.Close(); 
                    }
                }
            }
            
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

            cb_DocType.TabIndex = ++x;
            nud_DocVersion.TabIndex = ++x;
            mtb_DocSubmitted.TabIndex = ++x;
            mtb_DocAccepted.TabIndex = ++x;

            btn_DocAddCreate.TabIndex = ++x;
            btn_DocAddCancel.TabIndex = ++x;
        }

        /// <summary>
        /// Prevent the cursor from being positioned in the middle of an empty masked textbox when 
        /// the user clicks in it. Get's a reference to target control and passes it through to method in 
        /// static helper class.
        /// To be called by the OnClick event of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter_MaskedTextBox(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                MaskedTextBox maskedtextBox_Target = (MaskedTextBox)Controls.Find(((Control)sender).Name, true).First();
                Static_Helper.enter_MaskedTextBox(maskedtextBox_Target);
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
