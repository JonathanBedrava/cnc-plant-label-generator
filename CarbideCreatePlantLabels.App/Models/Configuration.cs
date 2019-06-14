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
        public double MinCommonFontY { get; set; }
        public double MinScientificFontY { get; set; }

        public double LabelMargin {get;set;}
        public int MinCharResizeThreshhold { get; set; }
        public double MinCharResizeRatio {get;set;}
        public double CommonNameHeightResizeRatio { get; set; }
    }
}