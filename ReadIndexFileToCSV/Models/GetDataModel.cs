using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Models
{
    public class GetDataModel
    {
        public string streamId { get; set; }
        public long start { get; set; }
        public long end { get; set; }
    }
}
