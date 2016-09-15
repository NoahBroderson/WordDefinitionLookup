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
        public frmQuizlet()
        {
            InitializeComponent();
        }

        private void frmQuizlet_Load(object sender, EventArgs e)
        {
            LoadUserListbox();

        }

        private void LoadUserListbox()
        {
            QuizletData Quizlet = new QuizletData();
            QuizletUserobject User = Quizlet.GetUserInfo();
            List<string> UserSets = new List<string>();

            for (int i = 0; i < User.sets.Count(); i++)
            {
                UserSets.Add(User.sets[i].title);
            }

            txtInfo.Lines = UserSets.ToArray<string>();

        }

        private void testcall2()
        {
            // Initialize the WebRequest.
            string ClientID = "rxD98NcHqS";
            //string Secret = "3Cn2GWNX4aZXaCA62FJXRJ";
            //string MyURL = "http://english4finance.de";
            int Random = new Random().Next(10000);




            //string QuizletSample = "https://quizlet.com/authorize?response_type=code&client_id=" + ClientID + "&scope=read&state=" + Random.ToString();
            string Endpoint = "https://quizlet.com/authorize";
            string Parameters = "?response_type=code&client_id=" + ClientID + "&scope=read&state=" + Random.ToString() + "&redirect_uri=http://shop.english4finance.de/produkte.html";
            //Example URI: https://quizlet.com/authorize?response_type=code&client_id=MY_CLIENT_ID&scope=read&state=RANDOM_STRING
            string Request = Endpoint + "/" + Parameters;
            wbAuthorize.Navigated += OnNavigated;
            wbAuthorize.Url = new System.Uri(Request);
            //var myRequest = WebRequest.Create(Request);
            //myRequest.Method = "HEAD";


            // Return the response. 
            //var myResponse = myRequest.GetResponse();
            // Code to use the WebResponse goes here.
            //MessageBox.Show(myResponse.ResponseUri.ToString());
            //foreach (var item in myResponse.Headers)
            //{
            //    MessageBox.Show(item.ToString());
            //}
            //// Close the response to free resources.
            //myResponse.Close();

        }

        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //MessageBox.Show(e.Url.AbsoluteUri);
            txtURI.Text = e.Url.ToString();
        }

        private void testcall()
        {
           
                
                //https://quizlet.com/authorize?response_type=code&client_id=MY_CLIENT_ID&scope=read&state=RANDOM_STRING

                string ClientID = "rxD98NcHqS";
                //string Secret = "3Cn2GWNX4aZXaCA62FJXRJ";
                //string MyURL = "http://english4finance.de";
                int Random = new Random().Next(10000);




            //string QuizletSample = "https://quizlet.com/authorize?response_type=code&client_id=" + ClientID + "&scope=read&state=" + Random.ToString();
                string Endpoint = "https://api.quizlet.com/2.0/users";
                string Parameters = "?response_type=code&client_id=" + ClientID + "&scope=read&state=" + Random.ToString();                 
                string Request = Endpoint + "/"  + Parameters;
                //todo - put in "Using" block
                string Response = new WebClient().DownloadString(Request);


                txtInfo.Text = Response;
           
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            testcall2();

            //GetUserAuth();
            //GetAccessToken();
            //MakeAPICall();
        }


        private void GetUserAuth()
        {
            //string ClientID = "rxD98NcHqS";
            //string Secret = "3Cn2GWNX4aZXaCA62FJXRJ";
            //string MyURL = "http://english4finance.de";
            int Random = new Random().Next(10000);




            //string QuizletSample = "https://quizlet.com/authorize?response_type=code&client_id=MY_CLIENT_ID&scope=read&state=RANDOM_STRING";

            //using (var client = new WebClient())
            //{
            //    var response = client.
            //}


            ////http://stackoverflow.com/questions/15626641/proper-form-of-https-request - example code
            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.Authorization] = "Basic " + "MY_SECRET_CODE";
            //    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    client.Headers[HttpRequestHeader.Host] = "api.quizlet.com";
            //    client.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";
            //    //client.UploadStringCompleted += ClientOnUploadStringCompleted;
            //    string FormatedString = string.Format("grant_type={0}&code={1}&redirect_uri={2}",
            //HttpUtility.HtmlEncode("authorization_code"), HttpUtility.HtmlEncode(Secret), HttpUtility.HtmlEncode("http://someurl.com"))
            //    client.UploadStringAsync(tokenUrl, "POST", string.Format("grant_type={0}&code={1}",
            //                                           HttpUtility.HtmlEncode("authorization_code"), HttpUtility.HtmlEncode(code)));
            //}
        }

        private void MakeAPICall()
        {
            throw new NotImplementedException();
        }

        private void GetAccessToken()
        {
            throw new NotImplementedException();
        }

    }
}
