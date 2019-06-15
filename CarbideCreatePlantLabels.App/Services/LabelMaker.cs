using System;
using CarbideCreate.Core.Models;
using CarbideCreatePlantLabels.App.Models;
using CarbideCreate.Core.Extensions;
using System.Linq;

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
            
            commonNameText.Height = GetCommonWidthHeight(_config.MinCommonFontY, plantInfo.CommonName);
            commonNameText.Position = new Point(){
              Y = GetCommonNameYPositon(labelRect.Height, commonNameText.Height, _config.OffsetFromTop),
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

        private double GetCommonNameYPositon(double rectHeight, double textHeight, double offsetFromTop)
        {
            return rectHeight - textHeight*_config.MinCommonFontY/textHeight - offsetFromTop;
        }

        private double GetCommonWidthHeight(double baseHeight, string text)
        {
            var height = baseHeight;
            
            if(!HasDescenders(text))
            {
               height = baseHeight * _config.CommonNameHeightResizeRatio;
            }

            var resizeRatio = GetMaxCharResizeRatio(text);

            height *= resizeRatio;

            return height;
        }

        private double GetMaxCharResizeRatio(string text)
        {
            for(var i = 0; i < _config.MaxCharResizeThreshholds.Count(); i++)
            {
                var ratio = _config.MaxCharResizeThreshholds[i];
                if(text.Length >= ratio.CharCount && (
                    i == _config.MaxCharResizeThreshholds.Count-1
                    || text.Length < _config.MaxCharResizeThreshholds[i+1].CharCount                   
                    ))
                {
                    return ratio.ResizeRatio;
                }
            }

            return 1;
        }

        private bool HasDescenders(string text)
        {
            var descenders = "jgyqp";

            return text.Any(c => descenders.Any(d => d == c));
        }

        private double GetScientificNameWidth(double labelWidth, string text)
        {
            return labelWidth * GetMinCharResizeRatio(text) - _config.OffsetFromLeft*2;
        }

        private double GetMinCharResizeRatio(string text)
        {
            for(var i = 0; i < _config.MinCharResizeThreshholds.Count(); i++)
            {
                var ratio = _config.MinCharResizeThreshholds[i];
                if(text.Length <= ratio.CharCount && (
                    i == _config.MinCharResizeThreshholds.Count-1
                    || text.Length > _config.MinCharResizeThreshholds[i+1].CharCount                   
                    ))
                {
                    return ratio.ResizeRatio;
                }
            }

            return 1;
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