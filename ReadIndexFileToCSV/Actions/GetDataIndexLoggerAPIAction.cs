using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ReadIndexFileToCSV.Actions
{
    public class GetDataIndexLoggerAPIAction
    {
        public async Task<List<DataLoggerModel>> GetDataIndexLoggerAPI(string channel, DateTime start, DateTime end)
        {
            List<DataLoggerModel> list = new List<DataLoggerModel>();
            WriteLogAction writeLog = new WriteLogAction();

            try
            {
                string hostname = ConfigurationManager.AppSettings["hostname"];
                string username = ConfigurationManager.AppSettings["username"];
                string password = ConfigurationManager.AppSettings["password"];

                GetDataModel getDataModel = new GetDataModel();

                getDataModel.streamId = channel;
                getDataModel.start = (long)(start - new DateTime(1970, 1, 1)).TotalMilliseconds;
                getDataModel.end = (long)(end - new DateTime(1970, 1, 1)).TotalMilliseconds;

                var json = new JavaScriptSerializer().Serialize(getDataModel);

                string url = $"{hostname}GetIndexData?{json}";


                var credentialCache = new CredentialCache();
                credentialCache.Add(new Uri(hostname), "Digest", new NetworkCredential(username, password, "/"));

                using (var clientHander = new HttpClientHandler
                {
                    Credentials = credentialCache,
                    PreAuthenticate = true
                })
                using (var httpClient = new HttpClient(clientHander))
                {

                    try
                    {
                        var responseTask = httpClient.GetAsync(new Uri(url)).Result;

                        if (responseTask.StatusCode == HttpStatusCode.OK)
                        {
                            var dataObjects = responseTask.Content.ReadAsAsync<IEnumerable<DataLoggerResModel>>().Result;


                            foreach (var d in dataObjects)
                            {
                                DataLoggerModel el = new DataLoggerModel();

                                if (d != null)
                                {
                                    if (d.ts.HasValue)
                                    {
                                        el.TimeStamp = new DateTime(1970, 01, 01).AddMilliseconds(d.ts.Value);
                                        if (d.v.HasValue)
                                        {
                                            el.Value = Math.Round(d.v.Value, 2);
                                        }
                                        else
                                        {
                                            el.Value = null;
                                        }

                                        list.Add(el);
                                    }
                                }

                            }
                        }
                        else
                        {

                            await writeLog.WriteErrorLog(responseTask.ToString());
                        }
                    }
                    catch (TaskCanceledException ex)
                    {
                        await writeLog.WriteErrorLog(ex.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                await writeLog.WriteErrorLog(ex.ToString());
            }

            return list;
        }
    }
}
