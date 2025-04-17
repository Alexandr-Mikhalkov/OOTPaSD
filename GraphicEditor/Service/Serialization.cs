using Newtonsoft.Json;
using System;

namespace GraphicEditor
{
    public class Serialization
    {
        public void SaveShapes(ShapeList shapeList)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = Filters.jsonFilter;
                saveDialog.Title = "Save shapes";
                saveDialog.DefaultExt = "json";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var shapeDatas = shapeList.GetShapes()
                            .Select(shape => new ShapeData
                            {
                                ShapeType = shape.GetType().Name,
                                Shape = shape
                            })
                            .ToList();

                        var settings = new JsonSerializerSettings
                        {
                            Converters = new List<JsonConverter> { new ShapeConverter() },
                            Formatting = Formatting.Indented,
                        };

                        string json = JsonConvert.SerializeObject(shapeDatas, settings);
                        File.WriteAllText(saveDialog.FileName, json);
                        MessageBox.Show("Shapes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
