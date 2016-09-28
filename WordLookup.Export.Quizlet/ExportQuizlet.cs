using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class ExportQuizlet : IExport
    {
        public string Name
        {
            get
            {
                return "Quizlet";
            }
        }

        public void Export(List<VocabWord> vocabWordList)
        {
            System.Windows.Forms.Form ExportForm = new frmQuizletUpload(vocabWordList);
            ExportForm.Visible = true;
            ExportForm.Show();
        }
        
    }
}
