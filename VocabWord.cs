using System;

public class VocabWord      
{
	public VocabWord()
	{
	}
    
        private string lookupWord;

        public string Word
        {
            get { return lookupWord; }
            set
            {
                lookupWord = value;
                GetDefinitions();
            }

        }

        private string topDefinition;

        public string Definition
        {
            get { return topDefinition; }
            set { topDefinition = value; }
        }

        private List<string> wordDefinitions;

        public List<string> Definitions
        {
            get { return wordDefinitions; }
        }

        public VocabWord(string baseWord)
        {
            lookupWord = baseWord;

            GetDefinitions();
        }

        private void GetDefinitions()
        {
            wordDefinitions = this.Lookup();

            if (wordDefinitions.Count > 0)
            {
                topDefinition = wordDefinitions[0];
            }
            else
            {
                topDefinition = "No definitions found!";
            }
        }

        private List<string> Lookup()
        {
            wordDefinitions = new List<string>();
            string lookupHTML;

            try
            {
                lookupHTML = GetHTML(this.Word.ToLower());
                wordDefinitions = GetDefinitions(lookupHTML);

                return wordDefinitions;
            }
            catch (Exception error)
            {
                wordDefinitions.Clear();
                wordDefinitions.Add(string.Format("Error during lookup of definition. {0}", error.Message));
                return wordDefinitions;
            }
        }

        private string GetHTML(string lookupWord)
        {
            try
            {
                string pageSource = new WebClient().DownloadString("http://dictionary.cambridge.org/dictionary/english/" + lookupWord.ToLower().Replace(" ", "-"));

                return pageSource;
            }
            catch (Exception)
            {
                return "";
            }

        }

        private List<string> GetDefinitions(string lookupHTML)
        {
            int processingPoint = 0;
            //int nextGuideWord = lookupHTML.IndexOf("<span class=\"guideword\"", processingPoint);
            //int nextDefinition = lookupHTML.IndexOf("<span class=\"def\"", processingPoint);
            int nextGuideWord = lookupHTML.IndexOf("<span class=\"def-info\">", processingPoint);
            int nextDefinition = lookupHTML.IndexOf("<b class=\"def", processingPoint);
            string guideWord = "";
            string wordDefinition;
            List<string> defintions = new List<string>();

            try
            {
                do
                {
                    if (nextGuideWord < nextDefinition && nextGuideWord != -1)
                    {
                        processingPoint = nextGuideWord;
                        guideWord = StripHtmlRegX(lookupHTML, processingPoint);
                    }
                    else
                    {
                        processingPoint = nextDefinition;
                        wordDefinition = StripHtmlRegX(lookupHTML, processingPoint);
                        //defintions.Add(String.Format("{0} {1}", guideWord, wordDefinition));
                        wordDefinition = char.ToUpper(wordDefinition[0]) + wordDefinition.Substring(1);
                        defintions.Add(wordDefinition);
                    }

                    processingPoint += 1;
                    //nextGuideWord = lookupHTML.IndexOf("<span class=\"guideword\"", processingPoint);
                    //nextDefinition = lookupHTML.IndexOf("<span class=\"def\"", processingPoint);

                    nextGuideWord = lookupHTML.IndexOf("<span class=\"def-info\">", processingPoint);
                    nextDefinition = lookupHTML.IndexOf("<b class=\"def", processingPoint);

                } while (processingPoint < nextDefinition);
            }
            finally
            {
                if (defintions.Count == 0)
                {
                    defintions.Add("Error retrieving definition from HTML.");
                }
            }

            return defintions;
        }

        public static string StripHtmlRegX(string lookupHTML, int processingStartPoint)
        {
            int sectionLength = lookupHTML.IndexOf("</span>", processingStartPoint) - processingStartPoint;
            string section = lookupHTML.Substring(processingStartPoint, sectionLength);
            string sectionNoHtml = System.Text.RegularExpressions.Regex.Replace(section, "<.*?>", string.Empty);
            string sectionClean = System.Text.RegularExpressions.Regex.Replace(sectionNoHtml, "[^a-zA-Z0-9_. (),:-]+", string.Empty);

            return sectionClean;
        }
    }
