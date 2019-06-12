using System;
using CarbideCreate.Core.Models;
using CarbideCreatePlantLabels.App.Models;
using CarbideCreate.Core.Extensions;

namespace CarbideCreatePlantLabels.App.Services
{
    public class LabelMaker
    {
        private readonly Configuration _config;

        public LabelMaker(Configuration config)
        {
            _config = config;
        }

        public Label AddLabel(PlantInfo plantInfo)
        {
            var label = new Label(_config);

            var labelRect = CreateLabelRect();
            label.LabelRect = labelRect;

            var commonNameText = CreateTextObject(plantInfo.CommonName, _config.CommonFontName);
            
            commonNameText.Height = _config.MinCommonFontY;
            commonNameText.Position = new Point(){
              Y = labelRect.Height - commonNameText.Height - _config.OffsetFromTop,
              X = 0 + _config.OffsetFromLeft
            };
            label.TextObjects.Add(commonNameText);

            var scientificNameText = CreateTextObject(plantInfo.ScientificName, _config.ScientificFontName);
            scientificNameText.Width = GetScientificNameWidth(labelRect.Width, plantInfo.ScientificName);
            scientificNameText.Position = new Point(){
                Y = labelRect.Height/3,
                X = 0 + _config.OffsetFromLeft
            };
            label.TextObjects.Add(scientificNameText);
            
            return label;
        }

        private double GetScientificNameWidth(double labelWidth, string text)
        {
            return text.Length > _config.MinCharResizeThreshhold ?
                labelWidth - _config.OffsetFromLeft * 2
                : labelWidth * _config.MinCharResizeRatio - _config.OffsetFromLeft*2;
        }

        private TextObject CreateTextObject(string text, string font)
        {
            return new TextObject(){
                Font = font,
                Text = text,
            };
        }

        private RectObject CreateLabelRect()
        {
            return new RectObject()
            {
                Width = _config.LabelX,
                Height = _config.LabelY,
                Position = new Point()
                {
                    X = _config.LabelX/2d,
                    Y = _config.LabelY/2d
                },
                
            };
        }
    }
}