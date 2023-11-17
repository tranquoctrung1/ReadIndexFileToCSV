using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Actions
{
    public class LoadTextFileAction
    {
        public DataSaveFileTextModel LoadTextFile(string loggerid)
        {
            DataSaveFileTextModel el = new DataSaveFileTextModel();
            try
            {
                string path = @"./Save/" + loggerid + ".txt";

                if (File.Exists(path))
                {
                    using (StreamReader file = new StreamReader(path))
                    {
                        string line = file.ReadLine();

                        if (line != "" && line != null)
                        {
                            string[] lineSplit = line.Split(new char[] { '_' }, StringSplitOptions.None);

                            el.loggerid = lineSplit[0];
                            el.timestamp = lineSplit[1];
                            el.index = lineSplit[2];
                            el.timestampIndex = lineSplit[3];
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return el;
        }
    }
}
