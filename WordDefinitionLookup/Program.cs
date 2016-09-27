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

            // DictionaryFactory.GetAvailableDictionaries()
            // Read config (reflection) for available dictionaries and pass to WordLookup form
            // Remove references to specific dictionary projects when DictionaryFactory complete
            List<IWordDictionary> availableDictionaries = WordLookup.WordDictionaryFactory.GetAvailableDictionaries();

            Application.Run(new frmWordLookup(availableDictionaries));
        }
    }
}
