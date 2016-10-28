using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup.UnitTests
{
    class TestDictionary : IWordDictionary
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
            return new List<string> { "Definition1", "Definition2", "Definition3" };
        }

        public VocabWord Lookup(VocabWord wordToLookup)
        {
            foreach (string definition in GetDefinitions(wordToLookup.Word))
            {
                wordToLookup.AddDefinition(definition);
            }

            return wordToLookup;
        }
        
    }
}
