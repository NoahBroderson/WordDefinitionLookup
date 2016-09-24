using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace WordDefinitionLookup
{
    class PearsonWord : VocabWord
    {
        public PearsonWord(string word) : base(word)
        {
                
        }

        protected override List<string> Lookup(string word)
        {
            List<string> DefinitionList = new List<string>();

            string RequestString = string.Format("https://api.pearson.com/v2/dictionaries/ldoce5/entries?headword.exact={0}&offset=0", word);
            string JsonReply = new WebClient().DownloadString(RequestString);

            PearsonJsonResponse ResponseObject = JsonConvert.DeserializeObject<PearsonJsonResponse>(JsonReply);
            
            foreach (var item in ResponseObject.results)
            {

                foreach (var sense in item.senses)
                {
                    if (sense.definition != null)
                    {
                        foreach (var definition in sense.definition)
                        {
                            DefinitionList.Add(definition);
                        }
                    }
                    
                }
            }
            
            return DefinitionList;
        }

    
    }
    
}
