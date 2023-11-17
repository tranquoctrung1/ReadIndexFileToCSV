using ReadIndexFileToCSV.Actions;
using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Contollers
{
    public class MainController
    {
        public void run()
        {
            try
            {
                PMACController pMACController = new PMACController();

                List<DataSaveFileTextModel> listDataGlobal = new List<DataSaveFileTextModel>();
                LoadTextFileAction loadTextFileAction = new LoadTextFileAction();

                string pathToFileIndex = ConfigurationManager.AppSettings["index"];

                if(listDataGlobal.Count <= 0)
                {
                    string pathToLoggerFile = ConfigurationManager.AppSettings["logger"];

                    GetLoggerIdAction getLoggerIdAction = new GetLoggerIdAction();

                    LoadLoggerToListGlobalAction loadLoggerToListGlobalAction = new LoadLoggerToListGlobalAction();

                    List<string> loggerids = getLoggerIdAction.GetLoggerId(pathToLoggerFile);

                    if(loggerids.Count > 0)
                    {
                        listDataGlobal = loadLoggerToListGlobalAction.LoadLoggerToList(loggerids);
                    }
                }

                // make sure 100% list data global has data

                foreach(DataSaveFileTextModel item in listDataGlobal)
                {
                    if(item.loggerid != "")
                    {
                        WriteSaveFileAction writeSaveFileAction = new WriteSaveFileAction(item.loggerid);

                        if (writeSaveFileAction.CheckFileCSVExists() == false)
                        {
                            writeSaveFileAction.CreateFileCSV();
                        }
                        if (writeSaveFileAction.CheckExistsFile() == false)
                        {
                            writeSaveFileAction.CreateFile();
                        }

                        DateTime timestampIndex;

                        string channelFlow = $"{item.loggerid}_02";

                        if(item.timestampIndex == "" || item.timestampIndex == "0")
                        {
                            DataSaveFileTextModel temp = loadTextFileAction.LoadTextFile(item.loggerid);

                            
                            if (item.timestampIndex != "")
                            {
                                timestampIndex = new DateTime(1970, 01, 01).AddSeconds(int.Parse(item.timestampIndex));
                            }
                            else
                            {
                                if (temp.timestampIndex != null)
                                {
                                    timestampIndex = new DateTime(1970, 01, 01).AddSeconds(int.Parse(temp.timestampIndex));
                                    item.timestampIndex = temp.timestampIndex;
                                }
                                else
                                {
                                    timestampIndex = new DateTime(1970, 01, 01);
                                }
                            }
                        }
                        else
                        {
                            timestampIndex = new DateTime(1970, 01, 01).AddSeconds(int.Parse(item.timestampIndex));
                        }

                        /// compare datetime to get data
                        // index file
                        if (File.Exists(Path.Combine(pathToFileIndex, $"{channelFlow}.iif")))
                        {
                            List<DataLoggerModel> list = new List<DataLoggerModel>();

                            DateTime? firstTime = pMACController.FTimeIndex(channelFlow);

                            if (timestampIndex != null)
                            {
                                firstTime = timestampIndex.AddSeconds(1);
                            }

                            DateTime? lastTime = pMACController.LTimeIndex(channelFlow);

                            if (firstTime != null && lastTime != null)
                            {
                                while (firstTime != null && lastTime != null && (DateTime.Compare(firstTime.Value, lastTime.Value) <= 0))
                                {
                                    double? index = pMACController.GetIndex(channelFlow, firstTime.Value);

                                    if (index != null)
                                    {
                                        DataLoggerModel el = new DataLoggerModel();

                                        el.TimeStamp = firstTime.Value;
                                        el.Value = index;

                                        list.Add(el);
                                    }


                                    firstTime = pMACController.NextTimeIndex(channelFlow, firstTime.Value);
                                }
                            }

                            if (list.Count > 0)
                            {

                                writeSaveFileAction.WriteCSVFile(list);

                                DataSaveFileTextModel data = new DataSaveFileTextModel();
                                data.timestamp = "0";
                                data.loggerid = item.loggerid;
                                data.index = list[list.Count - 1] != null ? list[list.Count - 1].Value.Value.ToString() : "";
                                data.timestampIndex = list[list.Count - 1].TimeStamp != null ? list[list.Count - 1].TimeStamp.Value.Subtract(new DateTime(1970, 01, 01, 0, 0, 0)).TotalSeconds.ToString() : "0";

                                writeSaveFileAction.WriteSaveFile(data);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLogAction writeLogAction = new WriteLogAction();

                writeLogAction.WriteErrorLog(ex.Message.ToString()).Wait();
            }
        }
    }
}
