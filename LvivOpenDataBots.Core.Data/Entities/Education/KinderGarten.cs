using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class KinderGarten : BaseEntity
    {
        [JsonProperty("Name")]
        public override string Name { get; set; }

        [JsonProperty("Phone_number")]
        public override string PhoneNumber { get; set; }

        public override string Address => $"{this.StreetName} {this.BuildingNumber}";

        [JsonProperty("Post_code")]
        public string PostCode { get; set; }
        [JsonProperty("Street_name")]
        public string StreetName { get; set; }
        [JsonProperty("Building_number")]
        public string BuildingNumber { get; set; }
        [JsonProperty("Holder")]
        public string Holder { get; set; }

        // may need renaming after Bogdan change names in API
        [JsonProperty("E-mail")]
        public string Email { get; set; }

        [JsonProperty("Coordinates_(longitude)")]
        public string CoordinatesLongitude { get; set; }

        [JsonProperty("Coordinates_(latitude)")]
        public string CoordinatesLatitude { get; set; }

        [JsonProperty("Web-site")]
        public string Website { get; set; }

        public override string ToString()
        {
            return
                $"{this?.Name}, {this.Address}, {this?.PostCode}, тел. {this?.PhoneNumber}, {this?.Email}, {this?.Website}, {this?.Holder}"
                    .Replace(", , ", ", ");
        }
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