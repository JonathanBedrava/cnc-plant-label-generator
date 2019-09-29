using System;
using System.Collections.Generic;
using System.IO;
using CarbideCreate.Core.Models;
using CarbideCreatePlantLabels.App.Models;
using CarbideCreatePlantLabels.App.Services;
using CarbideCreate.Core.Extensions;
using Newtonsoft.Json;

namespace CarbideCreatePlantLabels.App
{
    class Program
    {
        private static LabelMaker _labelMaker;
        private static ToolPathMaker _toolPathMaker;

        static void Main(string[] args)
        {
            var configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("appsettings.json"));

            var plantInfosPath =  args[0];

            var totalPlantInfos = GetTotalPlantInfos(JsonConvert.DeserializeObject<List<PlantInfo>>(File.ReadAllText(plantInfosPath)));

            _labelMaker = new LabelMaker(configuration);
            _toolPathMaker = new ToolPathMaker(configuration);

            var splitPlantInfos = totalPlantInfos.Partition<PlantInfo>(6);

            var i = 0;
            foreach(var plantInfos in splitPlantInfos)
            {
                var carbideDoc = new Document();
                carbideDoc.DocumentValues.Thickness = configuration.LabelZ;

                AddObjects(carbideDoc,plantInfos);
                carbideDoc = AddToolPaths(configuration, carbideDoc);

                var labelString = JsonConvert.SerializeObject(carbideDoc);

                File.WriteAllText($"plantLabels_{i}.c2d", labelString);
                i++;
            }
        }

        private static Document AddToolPaths(Configuration configuration, Document carbideDoc)
        {
            return _toolPathMaker.CreateLabelToolPaths(carbideDoc);
        }

        private static IList<PlantInfo> GetTotalPlantInfos(IList<PlantInfo> list)
        {
            var totalPlantInfos = new List<PlantInfo>();
            foreach(var plantInfo in list)
            {
                for(var i = 0; i < plantInfo.Quantity; i++)
                {
                    totalPlantInfos.Add(plantInfo);
                }
            }
            return totalPlantInfos;
        }

        private static void AddObjects(Document carbideDoc, IList<PlantInfo> plantInfos )
        {
            var row = 0;
            var col = 0;
            var i = 0;
            foreach(var plantInfo in plantInfos)
            {
                if (col > 1)
                {
                    col = 0;
                }
                if(i % 2 == 0)
                {
                    row ++;
                }

                var label = _labelMaker.AddLabel(plantInfo);

                label.SetPositionOffset(row, col);

                carbideDoc.RectObjects.Add(label.LabelRect);
                carbideDoc.TextObjects.AddRange(label.TextObjects);
                
                i++;
                col ++;
            }
        }

    }
}
