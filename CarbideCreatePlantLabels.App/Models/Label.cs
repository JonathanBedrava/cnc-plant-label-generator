using System;
using System.Collections.Generic;
using CarbideCreate.Core.Models;

namespace CarbideCreatePlantLabels.App.Models
{
    public class Label
    {
        private readonly Configuration _config;
        public Label(Configuration config)
        {
            _config = config;
        }

        public RectObject LabelRect {get;set;}
        public List<TextObject> TextObjects {get;set;} = new List<TextObject>();

        public void SetPositionOffset(int row, int col)
        {
            SetPosition(LabelRect, row, col);
            foreach(var textObj in TextObjects)
            {
                SetPosition(textObj, row, col);
            }
        }

        private void SetPosition(ObjectBase obj, int row, int col)
        {
            obj.Position.X += col * (LabelRect.Width + _config.LabelMargin);
            
            obj.Position.Y += (row-1) * (LabelRect.Height + _config.LabelMargin);
            
        }
    }
}