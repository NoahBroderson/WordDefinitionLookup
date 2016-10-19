using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{ 

    public class VocabWord
    {

        public VocabWord(string word)
        {
            _lookupWord = word;
            _definitions = new List<string>();
        }

        private string _lookupWord;

        public string Word
        {
            get { return _lookupWord; }
            set { _lookupWord = value; }
        }
        
        private string _definition;

        public string Definition
        {
            get
            {
                if (_definition == null)
                {
                    return "Not Defined";
                }
                else
                {
                    return _definition;
                }
            }

            set { _definition = value; }
        }

        private List<string> _definitions;

        public List<string> Definitions
        {
            get
            {
                return _definitions;
            }
            set
            {
                _definitions = value;
                _definition = _definitions[0];
            }
        }

        public override String ToString()
        {
            return _lookupWord;
        }
               
    }

}
