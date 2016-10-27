using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WordLookup
{
    public partial class frmWordLookup : Form
    {
        private List<VocabWord> _vocabList = new List<VocabWord>();
        private IWordDictionary _selectedDictionary;

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
                RefreshTopDefinitionsListbox();
            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message);
            }
        }


        private void RefreshTopDefinitionsListbox()
        {
            try
            {
                lbTopDefinitions.DataSource = null;
                lbTopDefinitions.Items.Clear();
                lbTopDefinitions.DataSource = _vocabList;
                lbTopDefinitions.DisplayMember = "Definition";
                lbTopDefinitions.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void RefreshWordListbox()
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
            IExport Export = (IExport)cboExportTo.SelectedItem;
            Export.Export(_vocabList);
        }

        private void lbTopDefinitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox)sender;
                var editForm = new frmEdit((VocabWord)lb.SelectedItem, EditType.Definition);
                editForm.ShowDialog();
                RefreshTopDefinitionsListbox();
                
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
                ClearListBoxes();
                _vocabList.Clear();
                UpdateVocabListFromClipboard();
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

        private void UpdateVocabListFromClipboard()
        {
            string clipBoardText = Clipboard.GetText();
            string[] wordList = clipBoardText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            VocabWord _newVocabWord;
            foreach (string item in wordList)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    _newVocabWord = new VocabWord(item.Replace("- ", ""));
                    _vocabList.Add(_newVocabWord);
                }
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
            try
            {
                ClearForm();

                foreach (var word in _vocabList)
                {
                    _selectedDictionary.Lookup(word);
                }
                RefreshWordListbox();
                RefreshTopDefinitionsListbox();

                btnLookup.Enabled = false;
            }
            catch (Exception Error)
            {
                MessageBox.Show(string.Format("Error running lookup. Error message {0}", Error.Message));
            }
        }

        //private RunLookup(VocabWord word)
        //{
        //    word.Definitions = _sectedDictionary.GetDefinitions(word.ToString().ToLower());
        //}


        private void lbWordList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbWordList.DataSource != null)
                {
                    VocabWord selectedWord = GetSelectedWord(sender);
                    Edit(selectedWord);
                    _selectedDictionary.Lookup(selectedWord);
                    RefreshWordListbox();
                    RefreshTopDefinitionsListbox();
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private static void Edit(VocabWord selectedWord)
        {
            frmEdit editForm = new frmEdit(selectedWord, EditType.Word);
            editForm.ShowDialog();
        }

        private static VocabWord GetSelectedWord(object sender)
        {
            var lb = (ListBox)sender;
            VocabWord selectedWord = (VocabWord)lb.SelectedItem;
            return selectedWord;
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
                        RefreshTopDefinitionsListbox();
                        RefreshWordListbox();
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
            _selectedDictionary = (IWordDictionary)cboDictionary.SelectedItem;

            if (lbWordList.Items.Count > 0)
            {
                VocabWord word;
                foreach (var item in lbWordList.Items)
                {
                    word = (VocabWord)item;
                    _selectedDictionary.Lookup(word);
                }
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

    public enum EditType
    {
        Definition,
            Word
    }
}
