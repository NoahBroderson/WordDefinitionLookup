using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class TestDictionary : WordLookup.IWordDictionary
    {
        public string Name
        {
            get
            {
                return "Test Dictionary";
            }
        }

        public List<string> GetDefinitions(string word)
        {
            return new List<string> { "This is a test dictionary" };
        }
    }
}
