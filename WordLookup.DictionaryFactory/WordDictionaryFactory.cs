﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class WordDictionaryFactory
    {
        public static List<IWordDictionary> GetAvailableDictionaries()
        {
            //Todo - Read config or Reflect to get available dictionaries
            List<IWordDictionary> availableDictionaries = new List<IWordDictionary>();
            availableDictionaries.Add(new WordLookup.CambridgeDictionary());
            availableDictionaries.Add(new PearsonDictionary());
            //availableDictionaries.Add(new TestDictionary());

            return availableDictionaries;
        }

        
    }
}
