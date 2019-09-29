using System;
using CarbideCreate.Core.Models;
using CarbideCreate.Core.Models.ToolPath;
using CarbideCreatePlantLabels.App.Models;

namespace CarbideCreatePlantLabels.App.Services
{
    public class ToolPathMaker
    {
        private readonly Configuration _configuration;

        public ToolPathMaker(Configuration configuration)
        {
            _configuration = configuration;
        }

        public Document CreateLabelToolPaths(Document document)
        {
            var group = new ToolPathGroupObject()
            {
                Name = "PlantLabels",
                Uuid = $"{{{Guid.NewGuid()}}}",
                Enabled = true
            };
    
            group.ToolPathObjects.Add(CreateRectToolPath(document));
            group.ToolPathObjects.Add(CreateTextToolPaths(document));
            
            document.ToolPathGroupObjects.Add(group);
            
            return document;
        }

        private ToolPathObject CreateTextToolPaths(Document document)
        {
            var group = new ToolPathGroupObject();
           
            var textPath = new ToolPathObject()
            {
                Name = "Text",
                Enabled = true,
                OffsetDir = 3,
                StartDepth = 0,
                EndDepth = -_configuration.LabelZ,
                Speeds = _configuration.TextSpeeds,
                StepDown = _configuration.TextStepDown,
                StepOver = _configuration.TextStepOver,
                TabHeight = 3,
                TabWidth = 12,
                Tool = _configuration.TextTool,
                Tolerance = _configuration.TextTolerance

            };
            foreach(var text in document.TextObjects)
            {
                textPath.Elements.Add(new ToolPathObjectElement()
                {
                    Uuid = text.Id
                });
            }

            return textPath;
        }

        private ToolPathObject CreateRectToolPath(Document document)
        {
            var group = new ToolPathGroupObject();
           
            var rectPath = new ToolPathObject()
            {
                Name = "Cutouts",
                Enabled = true,
                OffsetDir = 1,
                StartDepth = 0,
                EndDepth = -_configuration.LabelZ,
                Speeds = _configuration.CutoutSpeeds,
                StepDown = _configuration.CutoutStepDown,
                StepOver = _configuration.CutoutStepOver,
                TabHeight = 3,
                TabWidth = 12,
                Tool = _configuration.CutoutTool,
                Tolerance = _configuration.CutoutTolerance
            };
            foreach(var rect in document.RectObjects)
            {
                rectPath.Elements.Add(new ToolPathObjectElement()
                {
                    Uuid = rect.Id
                });
            }

            return rectPath;
        }
    }
}