using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class QuizletAuthRequest
    {
        public string AuthCode { get; set; }
        public string ClientID
        {
            get
            {
                //ToDo -Read from encrypted config file
                return "rxD98NcHqS";
            }
             
        }

        public string SecretKey {
            get
            {
                //ToDo -Read from encrypted config file
                return "3Cn2GWNX4aZXaCA62FJXRJ";
            }
        } 
        public string RedirectUri
        {
            get
            {
                //ToDo - Read from encrypted config file
                return "http://shop.english4finance.de/produkte.html";
            }
        }

        public string AuthenticationInfo
        {
            get
            {
                return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(this.ClientID + ":" + this.SecretKey));
            }
        }
    }
}
