using Newtonsoft.Json;

namespace CarbideCreate.Core.Models
{
    public class DocumentValues
    {
        [JsonProperty("BACKGROUND_IMAGE")]
        public string BackgroundImage {get;set;} = "AAAAAA==";
        [JsonProperty("BACKGROUND_OPACITY")]
        public double BackgroundOpacity {get;set;} = 0.5;
        [JsonProperty("BACKGROUND_POSITION_X")]
        public double BackgroundPositionX {get;set;} = 0;
        [JsonProperty("BACKGROUND_POSITION_Y")]
        public double BackgroundPostionY {get;set;} = 0;
        [JsonProperty("BACKGROUND_ROTATION")]
        public double BackgroundRotation {get;set;} = 0;
        [JsonProperty("BACKGROUND_SCALE")]
        public double BackgroundScale {get;set;} = 1;
        [JsonProperty("BACKGROUND_VISIBLE")]
        public bool BackgroundVisible {get;set;}
        [JsonProperty("DISPLAYMM")]
        public bool DisplayMm {get;set;}
        [JsonProperty("HEIGHT")]
        public double Height {get;set;} = 203.2;
        [JsonProperty("MACHINE")]
        public string Machine {get;set;} = "Nomad 883";
        [JsonProperty("MATERIAL")]
        public string Material {get;set;} = "Hard";
        [JsonProperty("RETRACT")]
        public double Retract {get;set;} = 10;
        [JsonProperty("THICKNESS")]
        public double Thickness {get;set;} = 1.5875;
        [JsonProperty("WIDTH")]
        public double Width {get;set;} = 203.2;
        [JsonProperty("ZERO_X")]
        public double ZeroX {get;set;}
        [JsonProperty("ZERO_Y")]
        public double ZeroY {get;set;}
        [JsonProperty("ZERO_Z")]
        public double ZeroZ {get;set;}
        [JsonProperty("build_num")]
        public int BuildNumber {get;set;} = 316;
        [JsonProperty("grid_enabled")]
        public bool GridEnabled {get;set;} = true;
        [JsonProperty("grid_spacing")]
        public double GridSpacing {get;set;} = 5;
        [JsonProperty("version")]
        public int Version {get;set;} = 1;
    }
}