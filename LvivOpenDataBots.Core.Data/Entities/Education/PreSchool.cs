using System.Text;
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
            var sb = new StringBuilder();
            sb.Append($"{this.Name}, {this.Address}");
            if (!string.IsNullOrWhiteSpace(PostCode))
                sb.Append($", {this.PostCode}");
            if (!string.IsNullOrWhiteSpace(PhoneNumber))
                sb.Append($", тел.{this.PhoneNumber}");
            if (!string.IsNullOrWhiteSpace(Email))
                sb.Append($", {this.Email}");
            if (!string.IsNullOrWhiteSpace(FaxNumber))
                sb.Append($", Факс - {this.FaxNumber}");
            if (!string.IsNullOrWhiteSpace(Holder))
                sb.Append($", {this.Holder}");
            sb.Append(".");

            return sb.ToString();
        }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/dnz/resource/58ae558a-f701-486b-9dff-89a6a1c4bfa8