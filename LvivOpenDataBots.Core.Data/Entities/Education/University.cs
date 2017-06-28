using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class University : BaseEntity
    {
        [JsonProperty("Phone_number")]
        public override string PhoneNumber { get; set; }
        [JsonProperty("Name")]
        public override string Name { get; set; }
        [JsonProperty("address")]
        public override string Address { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }


        public override string ToString()
        {
            return
                $"{this?.Name}, {this?.Address}, {this?.PhoneNumber}, {this?.Email}"
                    .Replace(", , ", ", ");
        }
    }
}

// URL: http://opendata.city-adm.lviv.ua/dataset/yhibepcntetn-akademii-ihctntytn/resource/163538eb-dbcf-4b13-95dd-0e8679dab15c