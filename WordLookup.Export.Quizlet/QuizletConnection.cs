using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace WordLookup
{
    public class QuizletConnection
    {
        private QuizletConfigFile config = new QuizletConfigFile();
        private QuizletAuthResponse authorization;
        private QuizletUser user;

        public QuizletConnection()
        {
            authorization = config.ReadAuthResponseInfo();

            if (authorization == null)
            {
                authorization = GetAuthResponseFromWeb(config.ReadRequestInfo());
            }
        }

        public QuizletUser QuizletUser
        {
            get
            {
                if (user == null)
                {
                    return GetUserFromWeb();
                }
                else
                {
                    return user;
                }
            }
        }
        

        private QuizletUser GetUserFromWeb()
        {
            string Endpoint = "https://api.quizlet.com/2.0/users";
            string Parameter = authorization.user_id;
            string AccessToken = "?access_token=" + authorization.access_token + "&whitespace=1";
            string Request = Endpoint + "/" + Parameter + "/" + AccessToken;            
            string Response = new WebClient().DownloadString(Request);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();

            user = Serializer.Deserialize<QuizletUser>(Response);

            return user;
        }

        private QuizletAuthResponse GetAuthResponseFromWeb(QuizletAuthRequest quizletAuthRequest)
        {
            frmQuizletAuthorize authForm = new frmQuizletAuthorize(quizletAuthRequest);
            authForm.ShowDialog();
            QuizletAuthResponse response = authForm.AuthResponse;
            config.SaveResponseInfo(response);

            return response;
        }

        public void UploadListToSet(List<VocabWord> vocabList, Set selectedSet)
        {
            //ToDo - Add event to notify of each term uploaded
            foreach (var term in vocabList)
            {
            UploadTermToSet(term.ToString(), term.Definition, selectedSet.id.ToString());
            }
        }

        private void UploadTermToSet(string term, string definition, string setID)
        {
            Uri QuizletURI = new Uri("https://api.quizlet.com/2.0/sets/" + setID + "/terms/");

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + authorization.access_token;
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                client.Headers[HttpRequestHeader.Host] = "api.quizlet.com";
                client.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";

                string FormatedString = string.Format("term={0}&definition={1}",
                HttpUtility.HtmlEncode(term), HttpUtility.HtmlEncode(definition));
                client.UploadStringCompleted += ClientOnUploadStringCompleted;

                client.UploadStringAsync(QuizletURI, "POST", FormatedString);

                //Test on Quizlet API site: 
                //https://api.quizlet.com/2.0/sets/144790618/terms
                //    Request:
                //Request URL: https://api.quizlet.com/2.0/sets/144790618/terms
                //Request Method: POST
                //Request Headers
                //Authorization: Bearer xJnBRF5jwHyPiPxt6Xr0MV2FuDOR8ex4tpWDGOxo
                //Form Data
                //whitespace: true
                //term: test
                //definition: this is a test
                //Response:
                //{
                //    "id": 5162960983,
                //    "term": "test",
                //    "definition": "this is a test",
                //    "image": null,
                //    "rank": 20
                //}
            }
        }

        public event EventHandler<QuizletTermUploadedEventArgs> TermUploaded;

        private void ClientOnUploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            //Todo - Add error handling in case upload fails
            string term = GetTermFromUploadResponse(e);
            QuizletTermUploadedEventArgs termUploaded = new QuizletTermUploadedEventArgs() { TermUploaded = term };

            OnTermUploaded(termUploaded);            
        }

        private string GetTermFromUploadResponse(UploadStringCompletedEventArgs e)
        {
            var serializer = new JavaScriptSerializer();
            QuizletUploadResponse response = serializer.Deserialize<QuizletUploadResponse>(e.Result.ToString());
            string term = response.term;

            return term;
        }

        private void OnTermUploaded(QuizletTermUploadedEventArgs e)
        {
            EventHandler<QuizletTermUploadedEventArgs> handler = TermUploaded;
            if (handler != null)
            {                
                TermUploaded(this, e);
            }
        }

        
    }

   


}
