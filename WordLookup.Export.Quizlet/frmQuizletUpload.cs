using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordLookup
{
    public partial class frmQuizletUpload : Form
    {
        public List<VocabWord> VocabList;

        public frmQuizletUpload()
        {
            InitializeComponent();
        }


        private void frmQuizletUpload_Load(object sender, EventArgs e)
        {
            cboUploadType.SelectedIndex = 1;

            foreach (var word in VocabList)
            {
                lbVocabList.Items.Add(word);
            }

            ConnectToQuizlet();
        }

        private void ConnectToQuizlet()
        {
// Read user info from configuration
// If not valid connection info - Load Autorization form & save config
// Load Available sets
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cboUploadType.SelectedIndex == 0)
            {

            }
        }

        private void cboUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ToDo - Refactor to make more flexible and comprehensible
            lblSets.Visible = Convert.ToBoolean(cboUploadType.SelectedIndex);
            lbSets.Visible = Convert.ToBoolean(cboUploadType.SelectedIndex);

            txtNewSet.Visible = !Convert.ToBoolean(cboUploadType.SelectedIndex);
            lblNewSet.Visible = !Convert.ToBoolean(cboUploadType.SelectedIndex);
        }
    }
}
