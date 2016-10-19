using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    //Response:
    //{
    //    "id": 5162960983,
    //    "term": "test",
    //    "definition": "this is a test",
    //    "image": null,
    //    "rank": 20
    //}
class QuizletUploadResponse
    {
        public long id { get; set; }
        public string term { get; set; }
        public string definition { get; set; }
        public object image { get; set; }
        public int rank { get; set; }
    }
}
