using Newtonsoft.Json;

namespace CarbideCreate.Core.Models.ToolPath
{
    public class Speeds
    {
        [JsonProperty("feedrate")]
        public double Feedrate { get; set; }
        [JsonProperty("plungerate")]
        public double Plungerate { get; set; }
        [JsonProperty("rpm")]
        public double Rpm { get; set; }
    }
}