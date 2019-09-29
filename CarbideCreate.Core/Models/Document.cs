using System;
using System.Collections.Generic;
using CarbideCreate.Core.Models.ToolPath;
using Newtonsoft.Json;

namespace CarbideCreate.Core.Models
{
    public class Document
    {
        [JsonProperty("CIRCLE_OBJECTS")]
        public List<CircleObject> CircleObjects {get;set;} = new List<CircleObject>();
        [JsonProperty("CURVE_OBJECTS")]
        public List<CurveObject> CurveObjects {get;set;} = new List<CurveObject>();

        [JsonProperty("DOCUMENT_VALUES")]
        public DocumentValues DocumentValues {get;set;} = new DocumentValues();

        [JsonProperty("RECT_OBJECTS")]
        public List<RectObject> RectObjects {get;set;} = new List<RectObject>();

        public object CreateTextObject(string commonName)
        {
            throw new NotImplementedException();
        }

        [JsonProperty("TEXT_OBJECTS")]
        public List<TextObject> TextObjects {get;set;} = new List<TextObject>();

        [JsonProperty("TOOLPATH_GROUP_OBJECTS")]
        public List<ToolPathGroupObject> ToolPathGroupObjects{get;set;} = new List<ToolPathGroupObject>();
        
    }
}