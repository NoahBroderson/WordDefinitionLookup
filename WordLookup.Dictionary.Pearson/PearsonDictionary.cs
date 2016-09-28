﻿using System;
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
            List<string> DefinitionList = new List<string>();

            string RequestString = string.Format("https://api.pearson.com/v2/dictionaries/ldoce5/entries?headword.exact={0}&offset=0", word);
            string JsonReply = new WebClient().DownloadString(RequestString);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            PearsonJsonResponse ResponseObject = Serializer.Deserialize<PearsonJsonResponse>(JsonReply);

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