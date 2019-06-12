using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models
{
    public abstract class ObjectBase
    {
        [JsonProperty("id")]
        public string Id = GetNewId();

        
        [JsonProperty("group_id")]
        public IList<string> GroupIds {get;set;}

        
        [JsonProperty("height")]
        public double Height {get;set;}
        [JsonProperty("width")]
        public double Width {get;set;}

        [JsonProperty("position")]
        public double[] PositionArray {get {return new double[] {Position.X, Position.Y};}}

        [JsonIgnore]
        public Point Position {get;set;}

        private static string GetNewId()
        {
            var guid = Guid.NewGuid();
            return $"{{{guid}}}";
        }
    }
}