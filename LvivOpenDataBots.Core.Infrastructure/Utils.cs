using System.Collections.Generic;
using System.Linq;
using System.Net;
using com.valgut.libs.bots.Wit;
using LvivOpenDataBots.Core.Data.Entities;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using static LvivOpenDataBots.Core.Data.DataPacks.EducationDataPacksApiUrls;

namespace LvivOpenDataBots.Core.Infrastructure
{
    public static class Utils
    {
        public static string DownloadJson<T>() where T : BaseEntity
        {
            var client = new WebClient();
            switch (typeof(T).Name)
            {
                case "KinderGarten":
                    return client.DownloadString(address: KinderGartens);
                case "University":
                    return client.DownloadString(address: Universities);
                case "School":
                    return client.DownloadString(address: Schools);
                case "PreSchool":
                    return client.DownloadString(address: PreSchools);
                case "TechLyceum":
                    return client.DownloadString(address: TechLyceums);
                case "Gymnasium":
                    return client.DownloadString(address: Gymnasiums);
                default:
                    break;
            }
            return null;
        }

        public static List<T> GetRecords<T>(string json) where T : BaseEntity
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

