using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;


namespace WordDefinitionLookup
{
    public partial class frmWordLookup : Form
    {
        List<CambridgeWord> wordList = new List<CambridgeWord>();

        public frmWordLookup()
        {
            InitializeComponent();            
        }

        private void frmWordLookup_Load(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            lbTopDefinitions.DataSource = null;
            lbTopDefinitions.Items.Clear(); 
            lbAltDefinitions.DataSource = null;
            lbAltDefinitions.Items.Clear();
            
            wordList.Clear();
        }

        private void lbTopDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTopDefinitions.DataSource != null)
            {
                var selectedWord = lbTopDefinitions.SelectedItem as CambridgeWord;
                lbAltDefinitions.DataSource = selectedWord.Definitions;
                lbAltDefinitions.Refresh();
            }
                
        }

        private void lbAltDefinitions_DoubleClick(object sender, EventArgs e)
        {
            var selectedWord = lbTopDefinitions.SelectedItem as CambridgeWord;
            
            selectedWord.Definition = lbAltDefinitions.SelectedItem.ToString();
            

            RefreshTopDefinitionsList();
        }

        private void RefreshTopDefinitionsList()
        {
            lbTopDefinitions.DataSource = null; 
            lbTopDefinitions.DataSource = wordList;
            lbTopDefinitions.DisplayMember = "Definition";
            lbTopDefinitions.ValueMember = "Word";
            lbTopDefinitions.Refresh();
        }

        private void RefreshWordList()
        {
           
            
            lbWordList.DataSource = null;
            lbWordList.Items.Clear();
            lbWordList.DataSource = wordList;
            lbWordList.DisplayMember = "Word";
            lbWordList.ValueMember = "Word";
            lbWordList.Refresh();
        }
       
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCSV(wordList);
        }

        private void ExportToCSV(List<CambridgeWord> wordList)
        {
            var windowsDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string currentTime = string.Format("text-{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);
            string fileName = System.IO.Path.Combine(windowsDesktop, string.Format("VocabWordsExport_{0}.csv",currentTime));

            try
            {
                string fullExport = "";

                foreach (CambridgeWord vocabWord in wordList)
                {
                    fullExport += string.Format("{0};{1}{2}", vocabWord.Word, vocabWord.Definition, Environment.NewLine);
                }

                System.IO.File.WriteAllText(fileName, fullExport);

                System.Diagnostics.Process.Start(fileName);

            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Error saving export file {0}. Error message: {1}", fileName, error.Message));
            }
        }

        private void lbTopDefinitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lb = (ListBox)sender;
            var editForm = new frmEdit((CambridgeWord)lb.SelectedItem, "Definition");
            editForm.ShowDialog();
            RefreshTopDefinitionsList();
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
                    lbWordList.Items.Add(item);

                }

                btnLookup.Enabled = true;
            }
            catch (Exception Error)
            {

                MessageBox.Show(string.Format("Error pasting from clipboard. Error message: {0}", Error.Message));

            }
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();

                foreach (string word in lbWordList.Items)
                {
                    var vocabWord = new CambridgeWord(word.ToLower());

                    if (word.Length > 0)
                    {
                        wordList.Add(vocabWord);
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
            if (lbWordList.DataSource != null)            
            {
                var lb = (ListBox)sender;
                CambridgeWord selectedWord = (CambridgeWord)lb.SelectedItem;
                frmEdit editForm = new frmEdit(selectedWord, "Word");
                editForm.ShowDialog();
                RefreshWordList();
                RefreshTopDefinitionsList();
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
                if (lbWordList.DataSource != null)
                {
                    this.wordList.Remove((CambridgeWord)lbWordList.SelectedItem);
                    RefreshTopDefinitionsList();
                    RefreshWordList();
                }
                else
                {
                    lbWordList.Items.Remove(lbWordList.SelectedItem);
                }
            }
        }

        
    }
}
