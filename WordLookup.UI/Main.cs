using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;


namespace WordDefinitionLookup
{
    public partial class frmWordLookup : Form
    {
        List<VocabWord> VocabList;


        public frmWordLookup()
        {
            InitializeComponent(); 
                       
        }

        private void frmWordLookup_Load(object sender, EventArgs e)
        {
                cboDictionary.SelectedIndex = 1;
                VocabList = new List<VocabWord>();
        }

        private void lbTopDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbTopDefinitions.DataSource != null)
                {
                    var selectedWord = lbTopDefinitions.SelectedItem as VocabWord;
                    lbAltDefinitions.DataSource = selectedWord.Definitions;
                    lbAltDefinitions.Refresh();
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);

            }        }


        private void lbAltDefinitions_DoubleClick(object sender, EventArgs e)
        {
            var selectedWord = lbTopDefinitions.SelectedItem as VocabWord;

            try
            {
                selectedWord.Definition = lbAltDefinitions.SelectedItem.ToString();
                RefreshTopDefinitionsList();
            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message);
            }
        }


        private void RefreshTopDefinitionsList()
        {
            try
            {
                lbTopDefinitions.DataSource = null;
                lbTopDefinitions.DataSource = VocabList;
                lbTopDefinitions.DisplayMember = "Definition";
                lbTopDefinitions.ValueMember = "Word";
                lbTopDefinitions.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
                throw;
            }
        }


        private void RefreshWordList()
        {
            try
            {
                lbWordList.DataSource = null;
                lbWordList.Items.Clear();
                lbWordList.DataSource = VocabList;
                lbWordList.DisplayMember = "Word";
                lbWordList.ValueMember = "Word";
                lbWordList.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show("Error: {0}", Error.Message);
            }
        }
       

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCSV(VocabList);
        }

        private void ExportToCSV(List<VocabWord> wordList)
        {
            string FileName ="";        
            try
            {
                var windowsDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string currentTime = string.Format("text-{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);
                FileName = System.IO.Path.Combine(windowsDesktop, string.Format("VocabWordsExport_{0}.csv", currentTime));

                string fullExport = "";

                foreach (VocabWord vocabWord in wordList)
                {
                    fullExport += string.Format("{0};{1}{2}", vocabWord.Word, vocabWord.Definition, Environment.NewLine);
                }

                System.IO.File.WriteAllText(FileName, fullExport);
                System.Diagnostics.Process.Start(FileName);

            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Error saving export file {0}. Error message: {1}", FileName, error.Message));
            }
        }

        private void lbTopDefinitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox)sender;
                var editForm = new frmEdit((VocabWord)lb.SelectedItem, "Definition");
                editForm.ShowDialog();
                RefreshTopDefinitionsList();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
                throw;
            }
        }

        private void btnPasteList_Click(object sender, EventArgs e)
        {
            PasteWordList();
        }

        private void PasteWordList()
        {
            try
            {
                string clipBoardText = Clipboard.GetText();
                string[] wordList = clipBoardText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                lbWordList.DataSource = null;
                lbWordList.Items.Clear();
                lbTopDefinitions.DataSource = null;
                lbTopDefinitions.Items.Clear();
                lbAltDefinitions.DataSource = null;
                lbAltDefinitions.Items.Clear();

                foreach (string item in wordList)
                {
                    lbWordList.Items.Add(item.Replace("- ",""));
                }

                btnLookup.Enabled = true;
                btnLookup.Focus();
            }
            catch (Exception Error)
            {
                MessageBox.Show(string.Format("Error pasting from clipboard. Error message: {0}", Error.Message));
            }
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            RunLookup();
        }

        private void RunLookup()
        {
            try
            {
                VocabWord vocabWord;
                ClearForm();
                VocabList.Clear();

                foreach (object word in lbWordList.Items)
                {
                    if (cboDictionary.Text == "Cambridge")
                    {
                        vocabWord = new CambridgeWord(word.ToString().ToLower());
                    }
                    else
                    {
                        vocabWord = new PearsonWord(word.ToString().ToLower());
                    }

                    if (word.ToString().Length > 0)
                    {
                        VocabList.Add(vocabWord);
                    }
                }

                RefreshTopDefinitionsList();
                RefreshWordList();
                btnLookup.Enabled = false;
            }
            catch (Exception Error)
            {
                MessageBox.Show(string.Format("Error running lookup. Error message {0}", Error.Message));
            }
        }


        private void lbWordList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbWordList.DataSource != null)
                {
                    var lb = (ListBox)sender;
                    VocabWord selectedWord = (VocabWord)lb.SelectedItem;
                    frmEdit editForm = new frmEdit(selectedWord, "Word");
                    editForm.ShowDialog();
                    RefreshWordList();
                    RefreshTopDefinitionsList();
                }
            }
            catch ( Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        
        private void frmWordLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteWordList();
            }
        }
        

        private void lbWordList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (lbWordList.DataSource != null)
                    {
                        this.VocabList.Remove((CambridgeWord)lbWordList.SelectedItem);
                        RefreshTopDefinitionsList();
                        RefreshWordList();
                    }
                    else
                    {
                        lbWordList.Items.Remove(lbWordList.SelectedItem);
                    }
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message);
                }
            }
        }


        private void cboDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbWordList.Items.Count > 0)
            {
                RunLookup();
            }

        }


        private void ClearForm()
        {
            try
            {
                lbAltDefinitions.DataSource = null;
                lbAltDefinitions.Items.Clear();
                lbAltDefinitions.Refresh();
                lbTopDefinitions.DataSource = null;
                lbTopDefinitions.Items.Clear();
                lbTopDefinitions.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void btnExportToQuizlet_Click(object sender, EventArgs e)
        {
            frmQuizletUpload QuizletForm = new frmQuizletUpload();
            QuizletForm.VocabList = VocabList;
            QuizletForm.ShowDialog();

        }
    }
}
