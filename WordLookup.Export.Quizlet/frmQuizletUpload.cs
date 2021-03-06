﻿using System;
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
        private List<VocabWord> VocabList;
        private QuizletUser _user;
        private QuizletConnection Connection;
        private int CountOfTermsUploaded = 0;

        public frmQuizletUpload(List<VocabWord> vocabWordList)
        {
            InitializeComponent();
            VocabList = vocabWordList;
            
        }
        
        private void frmQuizletUpload_Load(object sender, EventArgs e)
        {
            Connection = new QuizletConnection();
            Connection.TermUploaded += Connection_TermUploaded;
            _user = Connection.QuizletUser;
            DisplayVocabList();
            DisplayAvailableSets();           
        }

        private void Connection_TermUploaded(object sender, QuizletTermUploadedEventArgs e)
        {
            string result = e.TermUploaded;
            
            lbUploadedTerms.Items.Add(result);
            CountOfTermsUploaded += 1;
            if(CountOfTermsUploaded == VocabList.Count)
            {
                MessageBox.Show("Upload Complete!");
                CountOfTermsUploaded = 0;
                lbUploadedTerms.Items.Clear();
            }
        }

        private void DisplayAvailableSets()
        {
            try
            {
//ToDo - Determine filter for valid sets
                IEnumerable<Set> availableSets = from set in _user.sets
                                                where set.title.Contains("Noah") || set.title.Contains("Test Study Set") || set.title.Length == 8
                                                orderby set.title
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
                
                var result = MessageBox.Show("Do you want to continue uploading the vocabulary list to the following Study Set? -  " + 
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
