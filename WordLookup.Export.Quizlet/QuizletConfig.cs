using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WordLookup
{
    public class QuizletConfigFile
    {
        public QuizletAuthRequest ReadRequestInfo()
        {
            QuizletAuthRequest requestInfo = null;

            StreamReader reader = new StreamReader("QuizletRequest.json");
            using (reader)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                requestInfo = serializer.Deserialize<QuizletAuthRequest>(reader.ReadToEnd());
            }

            return requestInfo;
        }

        public void SaveRequestInfo(QuizletAuthRequest requestInfo)
        {
            StreamWriter writer = new StreamWriter("QuizletRequest.json");
            using (writer)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                writer.Write(serializer.Serialize(requestInfo));
            }
        }

        public QuizletAuthResponse ReadResponseInfo()
        {
            QuizletAuthResponse responseInfo = null;

            if (System.IO.File.Exists("QuizletResponse.json"))
            {
                try
                {
                    StreamReader reader = new StreamReader("QuizletResponse.json");
                    using (reader)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        responseInfo = serializer.Deserialize<QuizletAuthResponse>(reader.ReadToEnd());
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
                
            }                      

            return responseInfo;
        }

        public void SaveResponseInfo(QuizletAuthResponse responseInfo)
        {
            StreamWriter writer = new StreamWriter("QuizletResponse.json");
            using (writer)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                writer.Write(serializer.Serialize(responseInfo));
            }
        }


    }
}
