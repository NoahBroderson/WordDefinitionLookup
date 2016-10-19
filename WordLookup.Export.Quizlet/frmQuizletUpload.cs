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

        private void Connection_TermUploaded(object sender, QuizletTermUploadedEventArgs e)
        {
            string result = e.TermUploaded;
            
            lbUploadedTerms.Items.Add(result);
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
                lbSets.DataSource = availableSets.ToList();
                lbSets.Refresh();
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
                Set selectedSet = (Set)lbSets.SelectedItem;
                
                var result = MessageBox.Show("You are uploading the vocabulary list to the following Study Set: " + 
                    selectedSet.title,"Confirm Upload", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Connection.UploadListToSet(VocabList, (Set)lbSets.SelectedItem);
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
