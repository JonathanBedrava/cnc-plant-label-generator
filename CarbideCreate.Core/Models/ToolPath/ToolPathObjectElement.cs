using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models.ToolPath
{
    public class ToolPathObjectElement
    {
        [JsonProperty("tab_index")]
        public IList<int> TabIndex { get; set; } = new List<int>();
        [JsonProperty("tab_u")]
        public IList<int> TabU { get; set; } = new List<int>();
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}