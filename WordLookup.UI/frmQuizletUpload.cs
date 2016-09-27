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

        private void cboUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSets.Visible = Convert.ToBoolean(cboUploadType.SelectedIndex);
            lbSets.Visible = Convert.ToBoolean(cboUploadType.SelectedIndex);

            txtNewSet.Visible = !Convert.ToBoolean(cboUploadType.SelectedIndex);
            lblNewSet.Visible = !Convert.ToBoolean(cboUploadType.SelectedIndex);
        }

        private void frmQuizletUpload_Load(object sender, EventArgs e)
        {
            cboUploadType.SelectedIndex = 0;

            foreach (var word in VocabList)
            {
                lbVocabList.Items.Add(word);
            }

            ConnectToQuizlet();
        }

        private void ConnectToQuizlet()
        {
            throw new NotImplementedException();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cboUploadType.SelectedIndex == 0)
            {

            }
        }
    }
}
