using System;
using System.Windows.Forms;
using System.Collections.Generic;
using WordLookup;

namespace WordLookup
{
    public partial class frmWordLookup : Form
    {
        List<VocabWord> _vocabList = new List<VocabWord>();
        IWordDictionary _sectedDictionary;

        public frmWordLookup(List<IWordDictionary> availableDictionaries, List<IExport> availableExports)
        {
            InitializeComponent();
            cboDictionary.DataSource = availableDictionaries;
            cboDictionary.DisplayMember = "Name";
            cboDictionary.SelectedIndex = 0;

            cboExportTo.DataSource = availableExports;
            cboExportTo.DisplayMember = "Name";
            cboExportTo.SelectedIndex = 0;
        }

        private void frmWordLookup_Load(object sender, EventArgs e)
        {
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
            }
        }


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
                lbTopDefinitions.Items.Clear();
                lbTopDefinitions.DataSource = _vocabList;
                lbTopDefinitions.DisplayMember = "Definition";
                //lbTopDefinitions.ValueMember = "Word";
                lbTopDefinitions.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void RefreshWordList()
        {
            try
            {
                lbWordList.DataSource = null;
                lbWordList.Items.Clear();
                lbWordList.DataSource = _vocabList;                
                lbWordList.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show("Error: {0}", Error.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            //IExport Export = new ExportCSV();
            IExport Export = new ExportQuizlet();

            Export.Export(_vocabList);
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
            _vocabList.Clear();
            PasteWordList();
        }

        private void PasteWordList()
        {
            try
            {
                string clipBoardText = Clipboard.GetText();
                string[] wordList = clipBoardText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                ClearListBoxes();

                VocabWord _newVocabWord;
                foreach (string item in wordList)
                {
                    _newVocabWord = new VocabWord(item.Replace("- ", ""));
                    _vocabList.Add(_newVocabWord);
                }
                lbWordList.DataSource = _vocabList;
                lbWordList.Refresh();

                btnLookup.Enabled = true;
                btnLookup.Focus();
            }
            catch (Exception Error)
            {
                MessageBox.Show(string.Format("Error pasting from clipboard. Error message: {0}", Error.Message));
            }
        }

        private void ClearListBoxes()
        {
            lbWordList.DataSource = null;
            lbWordList.Items.Clear();
            lbTopDefinitions.DataSource = null;
            lbTopDefinitions.Items.Clear();
            lbAltDefinitions.DataSource = null;
            lbAltDefinitions.Items.Clear();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            RunLookup();
        }

        private void RunLookup()
        {
            try
            {
                ClearForm();
                
                foreach (var word in _vocabList)
                {
                    word.Definitions = _sectedDictionary.GetDefinitions(word.ToString().ToLower());
                }
                RefreshWordList();
                RefreshTopDefinitionsList();
                
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
            catch (Exception Error)
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
                        this._vocabList.Remove((VocabWord)lbWordList.SelectedItem);
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
            _sectedDictionary = (IWordDictionary)cboDictionary.SelectedItem;

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
            //frmQuizletUpload QuizletForm = new frmQuizletUpload();
            //QuizletForm.VocabList = _vocabList;
            //QuizletForm.ShowDialog();

        }
    }
}
