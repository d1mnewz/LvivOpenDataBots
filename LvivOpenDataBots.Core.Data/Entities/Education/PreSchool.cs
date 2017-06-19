using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class PreSchool : BaseEntity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("Post_code")]
        public string PostCode { get; set; }
        [JsonProperty("Street")]
        public string Street { get; set; }
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

        [JsonProperty("Fax_number")]
        public string FaxNumber { get; set; }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/dnz/resource/58ae558a-f701-486b-9dff-89a6a1c4bfa8