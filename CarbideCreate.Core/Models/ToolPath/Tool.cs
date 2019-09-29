using System;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models.ToolPath
{
    public class Tool
    {
        [JsonProperty("angle")]
        public int Angle { get; set; }
        [JsonProperty("corner_radius")]
        public double CornerRadius { get; set; }
        [JsonProperty("diameter")]
        public double Diameter { get; set; }
        [JsonProperty("display_mm")]
        public bool DisplayMillimeters { get; set; }
        [JsonProperty("flutes")]
        public int Flutes { get; set; }
        [JsonProperty("length")]
        public double Length { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("overall_length")]
        public double OverallLength { get; set; }
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
    }
}