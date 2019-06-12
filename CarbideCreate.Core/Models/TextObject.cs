using Newtonsoft.Json;

namespace CarbideCreate.Core.Models
{
    public class TextObject : ObjectBase
    {
        [JsonProperty("flip_horiz")]
        public bool FlipHorizontal {get;set;}
        [JsonProperty("flip_vert")]
        public bool FlipVertical {get;set;}
        [JsonProperty("font")]
        public string Font {get;set;}
        [JsonProperty("rotation")]
        public double Rotation {get;set;}
        [JsonProperty("text")]
        public string Text {get;set;}
        
    }
}