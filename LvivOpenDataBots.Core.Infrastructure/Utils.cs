using System.Collections.Generic;
using System.Linq;
using System.Net;
using com.valgut.libs.bots.Wit;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;

namespace LvivOpenDataBots.Core.Infrastructure
{
    public static class Utils
    {
        public static string DownloadJson(string url)
        {
            var client = new WebClient();
            return client.DownloadString(url);
        }

        public static List<T> GetRecords<T>(string json)
        {
            var res = JObject.Parse(json);
            var jArray = (JArray)res["result"]["records"];
            var result = jArray.ToObject<List<T>>();
            return result;
        }

        public static List<string> GetIntentsList(Activity activity)
        {
            var wit = new WitClient("OOGBVIKDZXDHVA7FX7SDSH4GBRB2HOBJ");
            var msg = wit.Converse(activity.From.Id, activity.Text);

            try
            {

                return msg?.entities["intent"].Select(x => x.value.ToString()).ToList();
            }
            catch (KeyNotFoundException)
            {
                return new List<string>();
            }
        }
    }

}

