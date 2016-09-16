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
using System.Windows.Forms;

namespace WordDefinitionLookup
{
    public partial class frmQuizlet : Form
    {
        QuizletData Quizlet;

        public frmQuizlet()
        {
            InitializeComponent();
            Quizlet = new QuizletData();
        }

        private void frmQuizlet_Load(object sender, EventArgs e)
        {
            //LoadUserListbox();
        }

        private void LoadUserListbox()
        {
            QuizletUserobject User = Quizlet.GetUserInfo();
            List<string> UserSets = new List<string>();

            for (int i = 0; i < User.sets.Count(); i++)
            {
                UserSets.Add(User.sets[i].title);
            }
            txtInfo.Lines = UserSets.ToArray<string>();
        }

        private void LoadAuthPage()
        {
            
            string ClientIDParam = "rxD98NcHqS";            
            int ReadStateParam = new Random().Next(10000);
            string RedirectUriParam = "http://shop.english4finance.de/produkte.html";

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
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + "cnhEOThOY0hxUzozQ24yR1dOWDRhWlhhQ0E2MkZKWFJK";
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
            MessageBox.Show(e.Result);
        }

        private void MakeAPICall()
        {
            throw new NotImplementedException();
        }

        

    }
}
