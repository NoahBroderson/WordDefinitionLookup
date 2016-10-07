using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WordLookup
{
    public class QuizletConnection
    {
        private QuizletConfigFile config = new QuizletConfigFile();

        public QuizletUser GetQuizletUser()
        {
            QuizletAuthResponse Authorization = config.ReadResponseInfo();
            if (Authorization == null)
            {
                Authorization = GetAuthResponseFromWeb(config.ReadRequestInfo());
            }


            //ToDo - Try to get AuthResponse from Config file first
            string Endpoint = "https://api.quizlet.com/2.0/users";
            string Parameter = Authorization.user_id;
            string AccessToken = "?access_token=" + Authorization.access_token + "&whitespace=1";
            string Request = Endpoint + "/" + Parameter + "/" + AccessToken;
            //todo - put in "Using" block
            string Response = new WebClient().DownloadString(Request);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();

            QuizletUser QuizletUser;
            QuizletUser = Serializer.Deserialize<QuizletUser>(Response);

            return QuizletUser;
        }

        private QuizletAuthResponse GetAuthResponseFromWeb(QuizletAuthRequest quizletAuthRequest)
        {
            frmQuizletAuthorize authForm = new frmQuizletAuthorize(quizletAuthRequest);
            authForm.ShowDialog();
            QuizletAuthResponse response = authForm.AuthResponse;
            config.SaveResponseInfo(response);

            return response;
        }
    }
}
