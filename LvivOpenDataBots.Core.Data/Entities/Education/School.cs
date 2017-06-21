using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class School : BaseEntity
    {
        [JsonProperty("Адреса")]
        public string Address { get; set; }
        [JsonProperty("Назва")]
        public override string  Name { get; set; }
        [JsonProperty("тел.")]
        public string PhoneNumber { get; set; }
        [JsonProperty("Коордити(широта)")]
        public string Coordinates { get; set; }
        [JsonProperty("пошта")]
        public string Post { get; set; }
        [JsonProperty("індекс")]
        public string Index { get; set; }
        [JsonProperty("Коордити(довгота)")]
        public string CoordinatesLongtitude { get; set; }
        [JsonProperty("Коордити(широта)")]
        public string CoordinatesLatitude { get; set; }
        [JsonProperty("Відповідальний орган")]
        public string Holder { get; set; }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/school/resource/b4edd197-09e4-4a48-870c-917121014919