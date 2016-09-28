using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public interface IExport
    {

        string Name { get; }

        void Export(List<VocabWord> vocabWordList);
    }
}
