using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WordLookup
{
    public partial class frmQuizletAuthorize : Form
    {
        QuizletAuthRequest AuthRequest;
        public QuizletAuthResponse AuthResponse;

        public frmQuizletAuthorize(QuizletAuthRequest AuthorizationInfo = null)
        {
            InitializeComponent();
            if (AuthorizationInfo != null)
            {
                AuthRequest = AuthorizationInfo;
            }
        }

        private void frmQuizletAuthorize_Load(object sender, EventArgs e)
        {
            LoadRequestInfo();            
        }

        private void LoadRequestInfo()
        {
            txtClientID.Text = AuthRequest.ClientID;
            txtSecretKey.Text = AuthRequest.SecretKey;
            txtRedirectURI.Text = AuthRequest.RedirectUri;
        }
               

        private void LoadQuizletAuthPageInBrowser()
        {
            string ClientIDParam = AuthRequest.ClientID;
            string RedirectUriParam = AuthRequest.RedirectUri;
            int ReadStateParam = new Random().Next(10000);
            //string RedirectUriParam = Properties.Settings.Default.RedirectURI;

            string Endpoint = "https://quizlet.com/authorize";
            string Parameters = "?response_type=code&client_id=" + ClientIDParam + "&scope=read&state=" + ReadStateParam.ToString() + "&redirect_uri=" + RedirectUriParam;
            string Request = Endpoint + "/" + Parameters;
            wbAuthorize.Navigated += OnNavigated;
            wbAuthorize.Url = new System.Uri(Request);
        }

        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                string url = e.Url.ToString();
                System.Collections.Specialized.NameValueCollection parameters = HttpUtility.ParseQueryString(url);
                AuthRequest.AuthCode = parameters.Get("code");
                txtAuthCode.Text = AuthRequest.AuthCode;

                if (AuthRequest.AuthCode != null)
                {
                    GetAccessToken();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (AuthRequest.ClientID == "")
            {
                //ToDo - Update AuthRequest with user supplied info
                //AuthRequest.ClientID = txtClientID.Text;//"rxD98NcHqS";
                //AuthRequest.RedirectUri = txtRedirectURI.Text; //"http://shop.english4finance.de/produkte.html";
            }

            LoadQuizletAuthPageInBrowser();

            //GetUserAuth();
            //GetAccessToken();
            //MakeAPICall();
        }

        private void GetAccessToken()
        {
            string ClientID = AuthRequest.ClientID;
            string AuthCode = AuthRequest.AuthCode;
            //StaticAuthInfo is - client ID and secret (see the API dashboard). This is simply your client ID and secret key 
            //    separated by a colon(:) and base64-encoded.
            string StaticAuthInfo = AuthRequest.AuthenticationInfo;
            //string StaticAuthInfo = "cnhEOThOY0hxUzozQ24yR1dOWDRhWlhhQ0E2MkZKWFJK"; 
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
                this.AuthResponse = Serializer.Deserialize<QuizletAuthResponse>(e.Result);

                QuizletConfigFile config = new QuizletConfigFile();
                config.SaveResponseInfo(this.AuthResponse);
                
                txtAccessToken.Text = this.AuthResponse.access_token;
                this.Hide();
                //MessageBox.Show(string.Format("Access Token: {0} \r\n Expires in: {1} days", AuthRequest.Response.access_token, ((AuthRequest.Response.expires_in / 60) / 60) / 24));

                //This works too! Using Dictionary object instead of custom object
                //JavaScriptSerializer Serializer = new JavaScriptSerializer();
                //Dictionary<string,object> Dictionary = Serializer.Deserialize<Dictionary<string,object>>(e.Result);
                //txtInfo.Text = Dictionary["access_token"].ToString();
                              
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
