using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LvivOpenDataBots.Core.Data.Entities.Education;
using Newtonsoft.Json.Linq;

namespace TestingJsonParsing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var res = GetResult<KinderGarten>(GetJsonStream(
                    "http://opendata.city-adm.lviv.ua/api/action/datastore_search?resource_id=92ac88b2-f4cf-46ac-a8b8-64600c1ec23a")
                .Result);
            Console.WriteLine(res.Count);
        }

        public static List<T> GetResult<T>(string json)
        {
            JObject res = JObject.Parse(json);
            JArray jArray = (JArray)res["result"]["records"];
            return jArray.ToObject<List<T>>();
        }


        public static async Task<string> GetJsonStream(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
