using System.Collections.Generic;
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
        [JsonProperty("font_height")]
        public double FontHeight {get;set;}
        
        [JsonIgnore]
        public new double Height {get;set;}
        
        [JsonIgnore]
        public new double Width {get;set;}

        public IList<int> Transform = new []
        {
                1,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                1
        };
    }
}