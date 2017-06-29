using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class TechLyceum : BaseEducationEntity
    {
        [JsonProperty("Name")]
        public override string Name { get; set; }

        [JsonProperty("Address")]
        public override string Address { get; set; }

        [JsonProperty("Phone")]
        public override string PhoneNumber { get; set; }

        public override string ToString()
        {
            return
                $"{this?.Name}, {this?.Address}, {this?.PhoneNumber}"
                    .Replace(", , ", ", "); // in case of nulls
        }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/texhikymn-jiiuei-yhnjinwa/resource/236409fb-e511-43b0-9563-6a5537219a6e