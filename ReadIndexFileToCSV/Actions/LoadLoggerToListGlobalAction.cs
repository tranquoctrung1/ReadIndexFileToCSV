using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Actions
{
    public class LoadLoggerToListGlobalAction
    {
        public List<DataSaveFileTextModel> LoadLoggerToList(List<string> data)
        {
            List<DataSaveFileTextModel> list = new List<DataSaveFileTextModel>();


            foreach (string item in data)
            {
                DataSaveFileTextModel el = new DataSaveFileTextModel();
                el.loggerid = item;
                el.timestamp = "";
                el.index = "";
                el.timestampIndex = "";

                list.Add(el);
            }

            return list;
        }
    }
}
