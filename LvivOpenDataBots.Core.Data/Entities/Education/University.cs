using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class University : BaseEntity
    {
        [JsonProperty("Телефон")]
        public string Phone { get; set; }
        [JsonProperty("Назва")]
        public string Name { get; set; }
        [JsonProperty("Електронна адреса")]
        public string Email { get; set; }
        [JsonProperty("Поштова адреса")]
        public string PostAddress { get; set; }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/yhibepcntetn-akademii-ihctntytn/resource/163538eb-dbcf-4b13-95dd-0e8679dab15c