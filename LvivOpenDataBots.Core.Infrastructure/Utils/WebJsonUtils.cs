using System.Collections.Generic;
using System.Net;
using LvivOpenDataBots.Core.Data.DataPacks;
using LvivOpenDataBots.Core.Data.Entities;
using Newtonsoft.Json.Linq;

namespace LvivOpenDataBots.Core.Infrastructure.Utils
{
    public static class WebJsonUtils
    {
        public static string DownloadJson<T>() where T : BaseEntity
        {
            var client = new WebClient();
            switch (typeof(T).Name)
            {
                case "KinderGarten":
                    return client.DownloadString(address: EducationDataPacksApiUrls.KinderGartens);
                case "University":
                    return client.DownloadString(address: EducationDataPacksApiUrls.Universities);
                case "School":
                    return client.DownloadString(address: EducationDataPacksApiUrls.Schools);
                case "PreSchool":
                    return client.DownloadString(address: EducationDataPacksApiUrls.PreSchools);
                case "TechLyceum":
                    return client.DownloadString(address: EducationDataPacksApiUrls.TechLyceums);
                case "Gymnasium":
                    return client.DownloadString(address: EducationDataPacksApiUrls.Gymnasiums);
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
    }
}
