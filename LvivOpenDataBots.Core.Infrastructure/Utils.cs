using System.Net;
using Newtonsoft.Json.Linq;

namespace LvivOpenDataBots.Core.Infrastructure
{
    public class Utils
    {
        public static string DownloadJsonAsync(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        public static dynamic GetFirstMatch(string json) // to do
        {
            dynamic res = JObject.Parse(json);
            if (res.success == true && res.result.total > 0)
            {
                return res.result.records[0];
            }
            return null;
        }
    }
}

