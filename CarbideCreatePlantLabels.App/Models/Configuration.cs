using System.Collections.Generic;
using CarbideCreate.Core.Models.ToolPath;

namespace CarbideCreatePlantLabels.App.Models
{
    public class Configuration
    {
        public double LabelX { get; set; }

        public double LabelY { get; set; }
        public double LabelZ { get; set; }
        public double TextMaxZ {get;set;}

        public double OffsetFromLeft {get;set;}
        public double OffsetFromTop {get;set;}

        public string CommonFontName { get; set; }
        public string ScientificFontName { get; set; }
        public double CommonFontY { get; set; }
        public double ScientificFontY { get; set; }

        public double LabelMargin {get;set;}
        public double CommonNameHeightResizeRatio { get; set; }
        
        public IList<ResizeThreshhold> MaxCharResizeThreshholds {get;set;}
        public IList<ResizeThreshhold> MinCharResizeThreshholds { get; set; }
        public bool CompensateForDescenders { get; set; } = false;
        public int ScientificCharLengthThreshhold { get; set; } = 14;
        public double CommonNameLineSpacing {get;set;} = 4;
        public double ScientificNameLineSpacing {get;set;} = 4;        
        public int CommonCharLengthThreshhold { get; set; } = 11;
        public Speeds CutoutSpeeds { get; set; }
        public double CutoutStepDown { get; set; }
        public double CutoutStepOver { get; set; }
        public Tool CutoutTool { get; set; }
        public Speeds TextSpeeds { get; set; }
        public double TextStepDown { get; set; }
        public double TextStepOver { get; set; }
        public Tool TextTool { get; set; }
        public double TextTolerance { get; set; }
        public double CutoutTolerance { get; set; }
    }

    public class ResizeThreshhold{
        public int CharCount {get;set;}
        public double ResizeRatio {get;set;}
    }
}