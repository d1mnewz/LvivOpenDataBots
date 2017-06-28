using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class School : BaseEntity
    {
        [JsonProperty("Name")]
        public override string Name { get; set; }
        [JsonProperty("Phone_number")]
        public override string PhoneNumber { get; set; }
        [JsonProperty("Post_code")]
        public string PostCode { get; set; }
        [JsonProperty("Street_name")]
        public string StreetName { get; set; }
        [JsonProperty("Building_number")]
        public string BuildingNumber { get; set; }

        public override string Address => $"{this.StreetName} {this.BuildingNumber}";

        [JsonProperty("Holder")]
        public string Holder { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Coordinates_(longitude)")]
        public string CoordinatesLongitude { get; set; }
        [JsonProperty("Coordinates_(latitude)")]
        public string CoordinatesLatitude { get; set; }

        public override string ToString()
        {
            return
                $"{this?.Name}, {this.Address}, {this?.PostCode}, {this?.PhoneNumber}, {this?.Email}, {this?.Holder}"
                    .Replace(", , ", ", ");
        }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/school/resource/b4edd197-09e4-4a48-870c-917121014919