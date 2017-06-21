using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities
{
    public class BaseEntity
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public virtual string Name { get; set; } // it may not work, to test properly
    }

}
