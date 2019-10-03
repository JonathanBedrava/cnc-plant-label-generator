using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models.ToolPath
{
    public class ToolPathGroupObject
    {
        [JsonProperty("TOOLPATH_OBJECTS")]
        public IList<ToolPathObject> ToolPathObjects { get; set; } = new List<ToolPathObject>();
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = $"{{{Guid.NewGuid()}}}";
    }
}