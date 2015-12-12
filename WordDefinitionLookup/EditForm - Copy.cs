using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordDefinitionLookup
{
    public partial class frmEdit : Form
    {
        private CambridgeWord wordToEdit;
        private string wordProperty;

        public frmEdit()
        {
            InitializeComponent();
        }

        public frmEdit(CambridgeWord selectedWord, string propertyToEdit)
        {
            try
            {
                InitializeComponent();
                wordToEdit = selectedWord;
                wordProperty = propertyToEdit;

                if (wordProperty == "Word")
                {
                    txtEditField.Text = wordToEdit.Word;
                }
                else
                {
                    txtEditField.Text = wordToEdit.Definition;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        private void frmEditDefinition_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveDef_Click(object sender, EventArgs e)
        {
            if (wordProperty == "Word")
            {
                wordToEdit.Word = txtEditField.Text ;
            }
            else
            {
                txtEditField.Text = wordToEdit.Definition;
            }
            this.Close();
        }
    }
}
