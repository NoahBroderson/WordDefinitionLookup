﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public interface IWordDictionary
    {
        string Name { get;}

        VocabWord Lookup(VocabWord wordToLookup);
    }
}
