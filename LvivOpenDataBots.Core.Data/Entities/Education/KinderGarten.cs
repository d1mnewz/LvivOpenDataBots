// ReSharper disable InconsistentNaming
using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class KinderGarten : BaseEntity
    {
        [JsonProperty("_id")]
        public int _id { get; set; }
        [JsonProperty("Phone_number")]
        public string Phone_number { get; set; }
        [JsonProperty("Post_code")]
        public string Post_code { get; set; }
        [JsonProperty("Street_name")]
        public string Street_name { get; set; }
        [JsonProperty("Building_number")]
        public string Building_number { get; set; }
        [JsonProperty("Holder")]
        public string Holder { get; set; }

        // may need renaming after Bogdan change names in API
        [JsonProperty("E-mail")]
        public string Email { get; set; }

        [JsonProperty("Coordinates_(longitude)")]
        public string Coordinates_longitude { get; set; }

        [JsonProperty("Coordinates_(latitude)")]
        public string Coordinates_latitude { get; set; }

        [JsonProperty("Web-site")]
        public string Website { get; set; }
    }

}




//URL: http://opendata.city-adm.lviv.ua/dataset/shkola-sadol/resource/92ac88b2-f4cf-46ac-a8b8-64600c1ec23a

//Структура набору даних:
//    'Name' - назва школи-садку;
//    'Street_name' - назва вулиці;
//    'Building_number' - номер будинку;
//    'Post_code' - поштовий індекс;
//    'Phone_number' - номер телефону;
//    'E-mail' - електронна пошта;
//    'Web-site' - веб-сайт;
//    'Holder' - кому підпорядковується;
//    'Coordinates_(longitude)' - координати(довгота);
//    'Coordinates_(latitude)' - координати(широта).