using System;
using CarbideCreate.Core.Models;
using CarbideCreatePlantLabels.App.Models;
using CarbideCreate.Core.Extensions;
using System.Linq;
using System.Collections.Generic;

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

            var commonNameTexts = GetCommonNameTexts(plantInfo, labelRect);
            label.TextObjects.AddRange(commonNameTexts);

            var scientificNameTexts = GetScientificNameTexts(plantInfo, labelRect);
            label.TextObjects.AddRange(scientificNameTexts);
            
            return label;
        }

        private IEnumerable<TextObject> GetCommonNameTexts(PlantInfo plantInfo, RectObject labelRect)
        {
            var yPos = GetCommonNameYPositon(labelRect.Height, _config.CommonFontY, _config.OffsetFromTop);
            if(plantInfo.CommonName.Length < _config.CommonCharLengthThreshhold)
            {
                return new [] { CreateTextObject(plantInfo.CommonName, labelRect, _config.OffsetFromLeft, yPos, _config.CommonFontY, _config.CommonFontName)};
            }

            if(plantInfo.CommonName.Contains(" "))
            {
                var segs = plantInfo.CommonName.Split(' ');
                var firstLine = segs[0];
                var secondLine = segs.Skip(1).Aggregate((i,j) => i+" "+j);

                return new []{
                    CreateTextObject(firstLine,
                        labelRect,
                        _config.OffsetFromLeft,
                         yPos,
                        _config.CommonFontY,
                        _config.CommonFontName),
                    CreateTextObject(secondLine,
                    labelRect,
                    _config.OffsetFromLeft,
                    yPos-_config.CommonFontY-_config.CommonNameLineSpacing,
                    _config.CommonFontY,
                    _config.CommonFontName),
                };
            }

            return new [] { CreateTextObject(plantInfo.CommonName, labelRect, _config.OffsetFromLeft, yPos, _config.CommonFontY*.9, _config.CommonFontName) };
        }

        private IEnumerable<TextObject> GetScientificNameTexts(PlantInfo plantInfo, RectObject labelRect)
        {
            if(plantInfo.ScientificName.Length < _config.ScientificCharLengthThreshhold)
            {
                var scientificNameText = CreateTextObject(plantInfo.ScientificName, labelRect, _config.OffsetFromLeft, labelRect.Height/3.5, _config.ScientificFontY, _config.ScientificFontName);
                return new [] { scientificNameText};
            }

            var segs = plantInfo.ScientificName.Split(' ');
            var firstLine = segs[0];
            var secondLine = segs.Skip(1).Aggregate((i,j) => i+" "+j);

            return new []{
                CreateTextObject(firstLine, labelRect, _config.OffsetFromLeft, labelRect.Height/3.5, _config.ScientificFontY,  _config.ScientificFontName),
                CreateTextObject(secondLine, labelRect, _config.OffsetFromLeft, labelRect.Height/3.5-_config.ScientificFontY-_config.ScientificNameLineSpacing, _config.ScientificFontY, _config.ScientificFontName),
            };
        }

        private TextObject CreateTextObject(string text, RectObject labelRect, double x, double y, double fontHeight, string font)
        {

                var textObj = new TextObject(){
                    Font = font,
                    Text = text,
                };
                textObj.FontHeight = fontHeight;
                textObj.Position = new Point(){
                    Y = y,
                    X = x
                };
                return textObj;
        }

        private double GetCommonNameYPositon(double rectHeight, double textHeight, double offsetFromTop)
        {
            return rectHeight - textHeight*_config.CommonFontY/textHeight - offsetFromTop;
        }

        private double GetCommonNameHeight(double baseHeight, string text)
        {
            var height = baseHeight;
            
            if(_config.CompensateForDescenders && !HasDescenders(text))
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

        private double GetScientificNameFontHeight(double labelHeight, string text)
        {
            return labelHeight * GetMaxCharResizeRatio(text);
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