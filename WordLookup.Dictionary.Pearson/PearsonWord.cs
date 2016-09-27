using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script;


//namespace WordLookup
//{
//    class PearsonWord : VocabWord
//    {
//        protected override List<string> Lookup(string word)
//        {
//            List<string> DefinitionList = new List<string>();

//            string RequestString = string.Format("https://api.pearson.com/v2/dictionaries/ldoce5/entries?headword.exact={0}&offset=0", word);
//            string JsonReply = new WebClient().DownloadString(RequestString);
//            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
//            PearsonJsonResponse ResponseObject = Serializer.Deserialize<PearsonJsonResponse>(JsonReply);
            
//            foreach (var item in ResponseObject.results)
//            {

//                foreach (var sense in item.senses)
//                {
//                    if (sense.definition != null)
//                    {
//                        foreach (var definition in sense.definition)
//                        {
//                            DefinitionList.Add(definition);
//                        }
//                    }
                    
//                }
//            }
            
//            return DefinitionList;
//        }

    
//    }
    
//}
