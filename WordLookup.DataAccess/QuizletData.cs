using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;

namespace WordLookup
{
    public class QuizletData
    {
        public QuizletData()
        {
            
        }

        public string AuthCode { get; set; }

        public QuizletUserobject GetQuizletUser()
        {
            QuizletUserobject QuizletUser;

            string Endpoint = "https://api.quizlet.com/2.0/users";
            string Parameter = Authorization.user_id;
            string AccessToken = "?access_token=" + Authorization.access_token + "&whitespace=1";
            string Request = Endpoint + "/" + Parameter + "/" + AccessToken;
            //todo - put in "Using" block
            string Response = new WebClient().DownloadString(Request);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            QuizletUser = Serializer.Deserialize<QuizletUserobject>(Response);

            return QuizletUser;
        }

        public QuizletAuthResponse Authorization { get; set; }
    }

    public class QuizletUserobject
    {
        public string username { get; set; }
        public string account_type { get; set; }
        public int sign_up_date { get; set; }
        public string profile_image { get; set; }
        public Statistics statistics { get; set; }
        public Set[] sets { get; set; }
        public Favorite_Sets[] favorite_sets { get; set; }
        public Studied[] studied { get; set; }
        public Class1[] classes { get; set; }
    }

    public class Statistics
    {
        public int study_session_count { get; set; }
        public int total_answer_count { get; set; }
        public int public_sets_created { get; set; }
        public int public_terms_entered { get; set; }
        public int total_sets_created { get; set; }
        public int total_terms_entered { get; set; }
    }

    public class Set
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string created_by { get; set; }
        public int term_count { get; set; }
        public int created_date { get; set; }
        public int modified_date { get; set; }
        public bool has_images { get; set; }
        public object[] subjects { get; set; }
    }

    public class Favorite_Sets
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string created_by { get; set; }
        public int term_count { get; set; }
        public int created_date { get; set; }
        public int modified_date { get; set; }
        public bool has_images { get; set; }
        public object[] subjects { get; set; }
    }

    public class Studied
    {
        public string mode { get; set; }
        public int last_studied_date { get; set; }
        public int finished_date { get; set; }
        public int score { get; set; }
        public Set1 set { get; set; }
    }

    public class Set1
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string created_by { get; set; }
        public int term_count { get; set; }
        public int created_date { get; set; }
        public int modified_date { get; set; }
        public bool has_images { get; set; }
        public object[] subjects { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int set_count { get; set; }
        public int user_count { get; set; }
        public int created_date { get; set; }
        public bool is_public { get; set; }
    }

}
