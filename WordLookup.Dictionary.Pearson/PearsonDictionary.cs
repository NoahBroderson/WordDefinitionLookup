using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WordLookup
{
    public class PearsonDictionary : IWordDictionary
    {

        public string Name
        {
            get
            {
                return "Pearson";
            }
        }

        public List<string> GetDefinitions(string word)
        {
            string RequestString = string.Format("https://api.pearson.com/v2/dictionaries/ldoce5/entries?headword.exact={0}&offset=0", word);
            string JsonReply = new WebClient().DownloadString(RequestString);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            PearsonJsonResponse ResponseObject = Serializer.Deserialize<PearsonJsonResponse>(JsonReply);

            List<string> DefinitionList = new List<string>();
            
            ////Todo - Use LINQ? Almost works but errors when there are nulls - ex. light
            //var definitions =
            //    from tmp in ResponseObject.results
            //    select tmp;
            //from result in ResponseObject.results
            //from sense in result.senses
            //from definition in sense.definition
            //where definition != null
            //select definition;

            //DefinitionList = definitions.ToList();

            //return DefinitionList;

            foreach (var item in ResponseObject.results)
            {
                if (item.senses != null)
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

            }

            return DefinitionList;
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
