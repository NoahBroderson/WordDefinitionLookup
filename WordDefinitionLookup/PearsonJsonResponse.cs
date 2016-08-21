using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDefinitionLookup
{
    public class PearsonJsonResponse
    {
        public int status { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public string url { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string[] datasets { get; set; }
        public string headword { get; set; }
        public int homnum { get; set; }
        public string id { get; set; }
        public string part_of_speech { get; set; }
        public Pronunciation[] pronunciations { get; set; }
        public Sens[] senses { get; set; }
        public string url { get; set; }
    }

    public class Pronunciation
    {
        public Audio[] audio { get; set; }
        public string ipa { get; set; }
    }

    public class Audio
    {
        public string lang { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Sens
    {
        public Gramatical_Info gramatical_info { get; set; }
        public string signpost { get; set; }
        public string[] definition { get; set; }
        public Gramatical_Examples[] gramatical_examples { get; set; }
    }

    public class Gramatical_Info
    {
        public string type { get; set; }
    }

    public class Gramatical_Examples
    {
        public Example[] examples { get; set; }
        public string pattern { get; set; }
    }

    public class Example
    {
        public Audio1[] audio { get; set; }
        public string text { get; set; }
    }

    public class Audio1
    {
        public string type { get; set; }
        public string url { get; set; }
    }

}
