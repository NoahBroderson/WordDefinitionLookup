using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WordLookup
{ 

    public class VocabWord
    {
        private string _lookupWord;
        const string NOT_DEFINED = "Not Defined";

        public VocabWord(string word)
        {
            _lookupWord = word;
            _definitions = new List<string>();
            
        }

        public string Word
        {
            get { return _lookupWord; }
            set {
                if (value.ToLower() != _lookupWord.ToLower())
                {
                    _definitions.Clear();
                    _definition = null;
                }
                _lookupWord = value; }
        }
        
        private string _definition;

        public string Definition
        {
            get
            {
                if (_definition == null)
                {
                    return NOT_DEFINED;
                }

                return _definition;
            }

            set { _definition = value; }
        }
        
        private List<string> _definitions;

        public ReadOnlyCollection<string> Definitions
        {
            get
            {
                ReadOnlyCollection<string> _readOnlyDefinitions = new ReadOnlyCollection<string>(_definitions);
                return _readOnlyDefinitions;
            }
            //set
            //{
            //    if (value.Count > 0)
            //    {
            //    _definitions = value;
            //    }
               
            //    _definition = _definitions[0];
            //}
        }

        public void AddDefinition(string definition)
        {
            if (string.IsNullOrEmpty(definition))
            {
                throw new ArgumentException("Definition cannot be null or empty");
            }

            if (_definition == null)
            {
                _definition = definition;
            }

            if (!_definitions.Contains(definition))
            {
            _definitions.Add(definition);
            }
        }

        public void UpdateDefinition(int definitionIndex, string newDefinition)
        {
            if (string.IsNullOrEmpty(newDefinition))
            {
                throw new ArgumentException("Definition cannot be null or empty");
            }

            _definitions[definitionIndex] = newDefinition;
        }

        public override String ToString()
        {
            return _lookupWord;
        }
               
    }

}
