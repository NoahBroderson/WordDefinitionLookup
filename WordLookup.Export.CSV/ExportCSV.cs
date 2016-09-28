using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class ExportCSV : IExport
    {
        public string Name
        {
            get
            {
                return "CSV";
            }
        }

        public void Export(List<VocabWord> wordList)
        {
            string FileName = "";
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
                throw new Exception(string.Format("Error saving export file {0}. Error message: {1}", FileName, error.Message),error);
            }
        }
    }
}
