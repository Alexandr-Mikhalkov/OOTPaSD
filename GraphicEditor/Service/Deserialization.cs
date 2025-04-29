using GraphicEditor.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Windows.Forms;

namespace GraphicEditor
{
    public class Deserialization
    {
        private List<string> _currShapeTypes;

        public Deserialization()
        {
            _currShapeTypes = new List<string>();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(Shape).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    _currShapeTypes.Add(type.Name);
                }
            }
        }

        public void LoadShapes(ShapeFactory factory, ShapeList shapeList, PictureBox pictureBox, TrackBar widthTrackBar, TrackBar countTrackBar, Panel pluginPanel, Action<string> shapeClickHandler)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = Filters.jsonFilter;
                openDialog.Title = "Open file with shapes";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(openDialog.FileName);

                        var requiredTypes = JArray.Parse(json).Select(j => j["ShapeType"]?.ToString()).Distinct().Where(t => !string.IsNullOrEmpty(t))
                            .ToList();

                        var pluginTypes = requiredTypes.Where(t => !_currShapeTypes.Contains(t))
                            .ToList();

                        var pluginPaths = Settings.Default.PluginPaths??= new StringCollection();
                        var pluginLoader = new PluginLoader();
                        pluginLoader.ShapeButtonClicked += shapeClickHandler;

                        foreach (var typeName in pluginTypes)
                        {
                            var pluginPath = pluginPaths.Cast<string>()
                                .FirstOrDefault(p => Path.GetFileName(p).IndexOf(typeName, StringComparison.OrdinalIgnoreCase) >= 0);

                            if (pluginPath != null && File.Exists(pluginPath))
                            {
                                pluginLoader.LoadPluginFromFile(pluginPath, pluginPanel);
                            }
                            else
                            {
                                throw new FileNotFoundException($"Plugin for '{typeName}' not found");
                            }
                        }

                        var settings = new JsonSerializerSettings
                        {
                            Converters = new List<JsonConverter> { new ShapeConverter() }
                        };

                        var shapeDatas = JsonConvert.DeserializeObject<List<ShapeData>>(json, settings);

                        var shapeFactory = factory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
                        var restoredShapes = new List<Shape>();
                       
                        foreach (var shapeD in shapeDatas)
                        {
                            if (shapeFactory.TryGetValue(shapeD.ShapeType, out var constructor))
                            {
                                var newShape = constructor(shapeD.Shape.position);
                                newShape.PasteProperties(shapeD.Shape);
                                restoredShapes.Add(newShape);
                            }
                        }

                        shapeList.SetShapes(restoredShapes);
                        pictureBox.Invalidate();
                        MessageBox.Show("Shapes loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
