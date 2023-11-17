using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Actions
{
    public class GetLoggerIdAction
    {
        public List<string> GetLoggerId(string path)
        {
            List<string> list = new List<string>();
            WriteLogAction writeLogAction = new WriteLogAction();

            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo d = new DirectoryInfo(path);

                    FileInfo[] files = d.GetFiles("*.lgr");

                    foreach (FileInfo file in files)
                    {
                        string[] fileSplit = file.Name.Split(new char[] { '.' }, StringSplitOptions.None);

                        list.Add(fileSplit[0]);

                    }
                }
            }
            catch (Exception ex)
            {
                writeLogAction.WriteErrorLog(ex.Message).Wait();
            }

            return list;
        }
    }
}
