using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class PreSchool : BaseEducationEntity
    {
        [JsonProperty("Name")]
        public override string Name { get; set; }
        [JsonProperty("Phone_number")]
        public override string PhoneNumber { get; set; }

        public override string Address => $"{this.Street} {this.BuildingNumber}";


        [JsonProperty("Post_code")]
        public string PostCode { get; set; }
        [JsonProperty("Street")]
        public string Street { get; set; }
        [JsonProperty("Building_number")]
        public string BuildingNumber { get; set; }
        [JsonProperty("Holder")]
        public string Holder { get; set; }
        [JsonProperty("E-mail")]
        public string Email { get; set; }
        [JsonProperty("Coordinates_(longitude)")]
        public string CoordinatesLongitude { get; set; }
        [JsonProperty("Coordinates_(latitude)")]
        public string CoordinatesLatitude { get; set; }
        [JsonProperty("Fax_number")]
        public string FaxNumber { get; set; }

        public override string ToString()
        {
            return
                $"{this?.Name}, {this.Address}, {this?.PostCode}, {this?.PhoneNumber}, {this?.Email}, Факс - {this?.FaxNumber}, {this?.Holder}"
                    .Replace(", , ", ", ");
        }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/dnz/resource/58ae558a-f701-486b-9dff-89a6a1c4bfa8