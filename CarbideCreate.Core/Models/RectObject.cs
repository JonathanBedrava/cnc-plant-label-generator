using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models
{
    public class RectObject : ObjectBase
    {

        [JsonProperty("corner_type")]
        public int CornerType {get;set;}

        [JsonProperty("rotation")]
        public double Rotation {get;set;}

        [JsonProperty("radius")]
        public double Radius {get;set;}


    }
}