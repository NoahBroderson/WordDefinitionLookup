using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace WordLookup
{
    public partial class frmWordLookup : Form
    {
        private List<VocabWord> _vocabList = new List<VocabWord>();
        private const string TOP_DEFINITIONS_DISPLAY_MEMBER = "Definition";
        private const string WORD_LIST_DISPLAY_MEMBER = "Word";

        public frmWordLookup(List<IWordDictionary> availableDictionaries, List<IExport> availableExports)
        {
            InitializeComponent();
            
            FillAvailableDictionaryOptions(availableDictionaries);
            FillAvailableExports(availableExports);
            
        }

        private void FillAvailableExports(List<IExport> availableExports)
        {
            cboExportTo.DataSource = availableExports;
            cboExportTo.DisplayMember = "Name";
            cboExportTo.SelectedIndex = 0;
        }

        private void FillAvailableDictionaryOptions(List<IWordDictionary> availableDictionaries)
        {
            foreach (var dictionary in availableDictionaries)
            {
                checkedLBDictionaries.Items.Add(dictionary,true);
            }
            
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
                    RefreshAltDefinitions();
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
                RefreshListbox(lbTopDefinitions, TOP_DEFINITIONS_DISPLAY_MEMBER);
            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message);
            }
        }
                
        private void RefreshListbox(ListBox listboxToRefresh, string displayMember = "")
        {
            try
            {
                listboxToRefresh.DataSource = null;
                listboxToRefresh.Items.Clear();
                listboxToRefresh.DataSource = _vocabList;
                listboxToRefresh.DisplayMember = displayMember;
                listboxToRefresh.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void RefreshAltDefinitions()
        {
            if (lbTopDefinitions.SelectedIndex != -1)
            {
            VocabWord selectedWord = (VocabWord)lbTopDefinitions.SelectedItem;
            lbAltDefinitions.DataSource = null;
            lbAltDefinitions.Items.Clear();
            lbAltDefinitions.DataSource = selectedWord.Definitions;
            lbAltDefinitions.Refresh();
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
                RefreshListbox(lbTopDefinitions, TOP_DEFINITIONS_DISPLAY_MEMBER);
                
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
                RefreshListbox(lbWordList,WORD_LIST_DISPLAY_MEMBER);

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
           
                btnLookup.Enabled = false;
                ClearForm();

                foreach (var word in _vocabList)
                {
                    RunLookup(word);
                }

            

                RefreshListbox(lbWordList,WORD_LIST_DISPLAY_MEMBER);
           
                RefreshListbox(lbTopDefinitions,TOP_DEFINITIONS_DISPLAY_MEMBER);
                RefreshAltDefinitions();
                btnLookup.Enabled = true;
            
        }

        private void lbWordList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbWordList.DataSource != null)
                {
                    VocabWord selectedWord = GetSelectedWord(sender);

                    if (Edit(selectedWord))
                    {
                        RunLookup(selectedWord);
                    }
                                        
                    RefreshListbox(lbWordList, WORD_LIST_DISPLAY_MEMBER);
                    RefreshListbox(lbTopDefinitions, TOP_DEFINITIONS_DISPLAY_MEMBER);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void RunLookup(VocabWord selectedWord)
        {
            //var _selectedDictionaries = from dictionary in checkedLBDictionaries.Items 
            //                            where dictionary == true
            //                            select dictionary;
            List<IWordDictionary> _selectedDictionaries = new List<IWordDictionary>();

            foreach (var item in checkedLBDictionaries.CheckedItems)
            {
                IWordDictionary dictionary = (IWordDictionary)item;
                dictionary.Lookup(selectedWord);
            }

            foreach (var dictionary in _selectedDictionaries)
            {
                
            }
        }

        private static bool Edit(VocabWord selectedWord)
        {
            frmEdit editForm = new frmEdit(selectedWord, EditType.Word);
            editForm.ShowDialog();

            return editForm.VocabWordModified;
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
                        RefreshListbox(lbTopDefinitions, TOP_DEFINITIONS_DISPLAY_MEMBER);
                        RefreshListbox(lbWordList, WORD_LIST_DISPLAY_MEMBER);
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


        //private void cboDictionary_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selectedDictionary = (IWordDictionary)cboDictionary.SelectedItem;

        //    if (lbWordList.Items.Count > 0)
        //    {
        //        VocabWord word;
        //        foreach (var item in lbWordList.Items)
        //        {
        //            word = (VocabWord)item;
        //            _selectedDictionary.Lookup(word);
        //        }
        //    }

        //}

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
