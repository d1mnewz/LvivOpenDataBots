using Newtonsoft.Json;

namespace LvivOpenDataBots.Core.Data.Entities
{
    public class BaseEntity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
