using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WordDefinitionLookup
{
    public partial class frmQuizletAuthorize : Form
    {
        QuizletData Quizlet;
        public List<VocabWord> VocabList;

        public frmQuizletAuthorize()
        {
            InitializeComponent();
            Quizlet = new QuizletData();
        }

        private void frmQuizletAuthorize_Load(object sender, EventArgs e)
        {
            //LoadUserListbox();
            LoadVocabList();
        }

        private void LoadVocabList()
        {
            try
            {
                foreach (var Word in VocabList)
                {
                    lbVocabList.Items.Add(Word);
                }
            }
            catch (Exception error)
            {

                throw new Exception("Error loading VocabList", error);
            }
        }

        private void LoadUserListbox()
        {
            QuizletUserobject User = Quizlet.GetUserInfo();
            List<string> UserSets = new List<string>();

            for (int i = 0; i < User.sets.Count(); i++)
            {
                UserSets.Add(User.sets[i].title);
            }
            //txtInfo.Lines = UserSets.ToArray<string>();
        }

        private void LoadAuthPage()
        {
            string ClientIDParam = Properties.Settings.Default.ClientID;
            //string ClientIDParam = "rxD98NcHqS";            
            int ReadStateParam = new Random().Next(10000);
            //string RedirectUriParam = "http://shop.english4finance.de/produkte.html";
            string RedirectUriParam = Properties.Settings.Default.RedirectURI;

            string Endpoint = "https://quizlet.com/authorize";
            string Parameters = "?response_type=code&client_id=" + ClientIDParam + "&scope=read&state=" + ReadStateParam.ToString() + "&redirect_uri=" + RedirectUriParam;
            string Request = Endpoint + "/" + Parameters;
            wbAuthorize.Navigated += OnNavigated;
            wbAuthorize.Url = new System.Uri(Request);         
        }

        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Quizlet.AuthCode = HttpUtility.ParseQueryString(e.Url.ToString()).Get("code");
            txtURI.Text = Quizlet.AuthCode;
            //txtURI.Text = e.Url.ToString();
            if (Quizlet.AuthCode != null)
            {
                wbAuthorize.Visible = false;
                GetAccessToken();
            }
        }
        
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            LoadAuthPage();

            //GetUserAuth();
            //GetAccessToken();
            //MakeAPICall();
        }

        private void GetAccessToken()
        {
            //string ClientID = "rxD98NcHqS";
            string AuthCode = Quizlet.AuthCode;
            //StaticAuthInfo is - client ID and secret (see the API dashboard). This is simply your client ID and password 
            //    separated by a colon(:) and base64-encoded.
            string StaticAuthInfo = "cnhEOThOY0hxUzozQ24yR1dOWDRhWlhhQ0E2MkZKWFJK";
            string RedirectUri = "http://shop.english4finance.de/produkte.html";
            //int Random = new Random().Next(10000);
            Uri QuizletURI = new Uri("https://api.quizlet.com/oauth/token");

            //string QuizletSample = "https://quizlet.com/authorize?response_type=code&client_id=MY_CLIENT_ID&scope=read&state=RANDOM_STRING";

            //using (var client = new WebClient())
            //{
            //    var response = client.
            //}

            ////http://stackoverflow.com/questions/15626641/proper-form-of-https-request - example code

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + StaticAuthInfo;
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                client.Headers[HttpRequestHeader.Host] = "api.quizlet.com";
                client.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";
                string FormatedString = string.Format("grant_type={0}&code={1}&redirect_uri={2}",
            HttpUtility.HtmlEncode("authorization_code"), HttpUtility.HtmlEncode(AuthCode), HttpUtility.HtmlEncode(RedirectUri));
                client.UploadStringCompleted += ClientOnUploadStringCompleted;

                client.UploadStringAsync(QuizletURI, "POST", FormatedString);
            }
        }

        private void ClientOnUploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                //This works!! Using Newtonsoft reference
                //Quizlet.Authorization = Newtonsoft.Json.JsonConvert.DeserializeObject<QuizletAuthResponse>(e.Result);
                //txtInfo.Text = Quizlet.Authorization.access_token;

                //This works!Using Microsofts System.Web.Extensions reference
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                Quizlet.Authorization = Serializer.Deserialize<QuizletAuthResponse>(e.Result);
                //txtInfo.Text = Quizlet.Authorization.access_token;
                MessageBox.Show(string.Format("Access Token: {0} \r\n Expires in: {1} days", Quizlet.Authorization.access_token, ((Quizlet.Authorization.expires_in/60)/60)/24));
                //This works too! Using Dictionary object instead of custom object
                //JavaScriptSerializer Serializer = new JavaScriptSerializer();
                //Dictionary<string,object> Dictionary = Serializer.Deserialize<Dictionary<string,object>>(e.Result);
                //txtInfo.Text = Dictionary["access_token"].ToString();

                LoadUserListbox();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
