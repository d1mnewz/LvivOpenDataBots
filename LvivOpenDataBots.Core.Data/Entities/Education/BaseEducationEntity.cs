using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities.Education
{
    public class BaseEducationEntity
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Address { get; set; }

    }

}
