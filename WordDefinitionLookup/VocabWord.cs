using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDefinitionLookup
{
    public class VocabWord
    {
        public VocabWord(string word)
        {
            LookupWord = word;
            GetDefinitions();
        }

        protected string LookupWord;

        public string Word
        {
            get { return LookupWord; }
            set
            {
                LookupWord = value;
                GetDefinitions();
            }
        }

        public string Definition
        {
            get;
            set;
        }


        protected List<string> wordDefinitions;

        public List<string> Definitions
        {
            get { return wordDefinitions; }
        }

        public override String ToString()
        {
            return this.Word;
        }

        private void GetDefinitions()
        {
            wordDefinitions = Lookup(this.Word);

            if (wordDefinitions.Count > 0)
            {
                Definition = wordDefinitions[0];
            }
            else
            {
                Definition = "No definitions found!";
        }
        }

        protected virtual List<string> Lookup(string word)
        {
            wordDefinitions = new List<string>();

            return wordDefinitions;
        }
    }

}
