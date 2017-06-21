using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class TechLyceum : BaseEntity
    {
        [JsonProperty("Назва")]
        public override string Name { get; set; }

        [JsonProperty("Поштова адреса")]
        public string PostAddress { get; set; }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/texhikymn-jiiuei-yhnjinwa/resource/236409fb-e511-43b0-9563-6a5537219a6e