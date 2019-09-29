using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models.ToolPath
{
    public class ToolPathObject
    {
        [JsonProperty("automatic_parameters")]
        public bool AutomaticParameters { get; set; }
        [JsonProperty("elements")]
        public IList<ToolPathObjectElement> Elements { get; set; } = new List<ToolPathObjectElement>();
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("end_depth")]
        public double EndDepth { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("ofset_dir")]
        public int OffsetDir {get; set; }
        [JsonProperty("speeds")]
        public Speeds Speeds { get; set; }
        [JsonProperty("start_depth")]
        public double StartDepth { get; set; }
        [JsonProperty("stepdown")]
        public double StepDown { get; set; }
        [JsonProperty("stepover")]
        public double StepOver { get; set; }
        [JsonProperty("tab_height")]
        public double TabHeight { get; set; }
        [JsonProperty("tab_width")]
        public double TabWidth { get; set; }
        [JsonProperty("tolerance")]
        public double Tolerance { get; set; }
        [JsonProperty("tool")]
        public Tool Tool { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = $"{{{Guid.NewGuid()}}}";
    }
}