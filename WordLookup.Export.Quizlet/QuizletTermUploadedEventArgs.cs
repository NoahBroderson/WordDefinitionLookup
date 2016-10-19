using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup

{
    public class QuizletTermUploadedEventArgs : EventArgs
    {
        public string TermUploaded { get; set; }
    }
}
