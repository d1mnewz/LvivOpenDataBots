using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace LvivOpenDataBots.Core.Infrastructure
{
    public static class Utils
    {
        public static string DownloadJson(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        public static List<T> GetRecords<T>(string json) // works in simple consoleapp from scratch, but doesn't work here
        {
            JObject res = JObject.Parse(json);
            JArray jArray = (JArray)res["result"]["records"];
            var result = jArray.ToObject<List<T>>();
            return result;
        }
    }
}

