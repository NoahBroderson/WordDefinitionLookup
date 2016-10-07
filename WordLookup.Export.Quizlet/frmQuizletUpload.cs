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
        public QuizletUser User;

        public frmQuizletUpload(List<VocabWord> vocabWordList)
        {
            InitializeComponent();
            VocabList = vocabWordList;
        }


        private void frmQuizletUpload_Load(object sender, EventArgs e)
        {
            cboUploadType.SelectedIndex = 1;
            DisplayVocabList();
            DisplayAvailableSets();           
        }

        private void DisplayAvailableSets()
        {
            QuizletConnection connection = new QuizletConnection();
            QuizletUser user = connection.GetQuizletUser();

            foreach (var item in user.sets)
            {
                lbSets.Items.Add(item.title);
            }
        }

        private void DisplayVocabList()
        {
            foreach (var word in VocabList)
            {
                lbVocabList.Items.Add(word);
            }
        }

        //private QuizletUser GetUser()
        //{
        //    // Todo - Read user info from configuration
        //    // ToDo - If not valid connection info - Load Autorization form & save config
        //    // ToDo - Load Available sets

        //    QuizletUser user = ReadUserFromConfig();

        //    //if (user == null)
        //    //{
        //    //    var AuthRequest = new QuizletAuthRequest();
        //    //    var AuthResponse = new QuizletAuthResponse(AuthRequest);
        //    //    var quizletSession = new QuizletConnection(AuthResponse);
        //    //    user = quizletSession.GetQuizletUser();
        //    //}

        //    return user;
        //}

        //private QuizletUser ReadUserFromConfig()
        //{
        //    QuizletConfig configFile = new QuizletConfig();

        //    QuizletUser user = QuizletConfig.GetUser();
        //    return user;
        //}

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cboUploadType.SelectedItem.ToString() == "Add to Existing")
            {
                //UploadList(lbSets.SelectedItem);

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
