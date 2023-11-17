using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Actions
{
    public class WriteSaveFileAction
    {
        private string loggerid;
        private string path;
        private string pathFileCsv;

        public WriteSaveFileAction(string loggerid)
        {
            this.loggerid = loggerid;
            path = @"./Save/" + this.loggerid + ".txt";
            pathFileCsv = @"./Data/" + this.loggerid + ".csv";

        }

        public bool CheckExistsFile()
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckFileCSVExists()
        {
            if (File.Exists(pathFileCsv))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateFile()
        {
            File.Create(path);
        }

        public void CreateFileCSV()
        {
            File.Create(pathFileCsv);
        }

        public void WriteSaveFile(DataSaveFileTextModel data)
        {
            if (CheckExistsFile() == false)
            {
                CreateFile();
            }

            try
            {
                using (StreamWriter file = new StreamWriter(path, false))
                {
                    string stringToWrite = $"{data.loggerid}_{data.timestamp}_{data.index}_{data.timestampIndex}";

                    file.WriteAsync(stringToWrite).Wait();

                    file.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void WriteCSVFile(List<DataLoggerModel> list)
        {
            if(CheckFileCSVExists() == false)
            {
                CreateFileCSV();
            }

            try
            {

                using(var w = new StreamWriter(pathFileCsv, true))
                {
                    foreach (DataLoggerModel item in list)
                    {
                        string timeStamp = item.TimeStamp != null ? item.TimeStamp.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";
                        string value = item.Value.ToString();

                        string newLine = string.Format("{0},{1}{2}", timeStamp, value, Environment.NewLine);

                        w.Write(newLine);
                        w.Flush();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
