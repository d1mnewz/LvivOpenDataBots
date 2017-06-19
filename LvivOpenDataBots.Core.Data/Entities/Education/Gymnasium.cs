﻿using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class Gymnasium : BaseEntity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Phone_number")]
        public string PhoneNumber { get; set; }
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
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/himnazii/resource/0163f851-2cd3-43d0-ad6d-ce6a90d23614