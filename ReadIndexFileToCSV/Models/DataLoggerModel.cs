using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Models
{
    public class DataLoggerModel
    {
        public Nullable<DateTime> TimeStamp { get; set; }   
        public Nullable<double> Value { get; set; }
    }
}
