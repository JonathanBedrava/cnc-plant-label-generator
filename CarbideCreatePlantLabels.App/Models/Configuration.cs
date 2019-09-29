using System.Collections.Generic;

namespace CarbideCreatePlantLabels.App.Models
{
    public class Configuration
    {
        public double LabelX { get; set; }

        public double LabelY { get; set; }
        public double LabelZ { get; set; }

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
        public double LineSpacing {get;set;} = 4;
        public int CommonCharLengthThreshhold { get; internal set; } = 11;
    }

    public class ResizeThreshhold{
        public int CharCount {get;set;}
        public double ResizeRatio {get;set;}
    }
}