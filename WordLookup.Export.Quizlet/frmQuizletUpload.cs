using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordLookup
{
    public partial class frmQuizletUpload : Form
    {
        public List<VocabWord> VocabList;
        public QuizletUser User;
        public QuizletConnection Connection;

        public frmQuizletUpload(List<VocabWord> vocabWordList)
        {
            InitializeComponent();
            VocabList = vocabWordList;
            
        }
        
        private void frmQuizletUpload_Load(object sender, EventArgs e)
        {
            Connection = new QuizletConnection();
            Connection.TermUploaded += Connection_TermUploaded;
            User = Connection.QuizletUser;
            DisplayVocabList();
            DisplayAvailableSets();           
        }

        private void Connection_TermUploaded(object sender, UploadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            
            lbUploadedTerms.Items.Add(e.Result.ToString());
        }

        private void DisplayAvailableSets()
        {
            try
            {
                
                IEnumerable<Set> availableSets = from set in User.sets
                                                where set.title.Contains("Noah") || set.title.Contains("Test Study Set")
                                                select set;
                
                lbSets.DisplayMember = "title";
                lbSets.ValueMember = "id";

                foreach (var set in availableSets)
                {
                    lbSets.Items.Add(set);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }
            
        }

        private void DisplayVocabList()
        {
            foreach (var word in VocabList)
            {
                lbVocabList.Items.Add(word);
            }

        }

        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (lbSets.SelectedItem != null)
            {
                var result = MessageBox.Show("You are uploading the vocabulary list to the following Study Set: " + lbSets.SelectedItem,"Confirm Upload", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                Connection.AddListToSet(VocabList, (Set)lbSets.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Upload to Quizlet cancelled.");
                }
            }
            else
            {
                MessageBox.Show("You must select a Study Set to upload the vocabulary list.");
            }

        }
                
        private void lbSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set selectedSet = (Set)lbSets.SelectedItem;           
        }
    }
}
