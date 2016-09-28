using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup
{
    public class ExportFactory 
    {
        public static List<IExport> GetAvailableExports()
        {
            List<IExport> availableExports = new List<IExport> { new ExportCSV() };

            return availableExports;
        }
    }
}
