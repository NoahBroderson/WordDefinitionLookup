using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordLookup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            List<VocabWord> vocabWordList = new List<VocabWord> { new VocabWord("test") };
            Application.Run(new frmQuizletUpload(vocabWordList));
            //Application.Run(new frmQuizletAuthorize());
            
        }
    }
}
