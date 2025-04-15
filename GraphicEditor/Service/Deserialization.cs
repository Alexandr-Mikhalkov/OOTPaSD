using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace GraphicEditor
{
    public class Deserialization
    {
        public void LoadShapes(ShapeFactory factory, ShapeList shapeList, PictureBox pictureBox, TrackBar widthTrackBar, TrackBar countTrackBar)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openDialog.Title = "Open file with shapes";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string pluginRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

                        var pluginDirs = Directory.GetDirectories(pluginRoot)
                            .Where(dir =>
                            {
                                var name = Path.GetFileName(dir);
                                return !name.StartsWith(".") && Directory.Exists(Path.Combine(dir, "bin"));
                            });

                        var pluginDlls = pluginDirs
                            .SelectMany(projectDir =>
                                Directory.GetDirectories(Path.Combine(projectDir, "bin"), "*", SearchOption.AllDirectories)
                                    .SelectMany(binDir => Directory.GetFiles(binDir, "*.dll", SearchOption.TopDirectoryOnly)))
                            .Distinct();

                        foreach (var dll in pluginDlls)
                        {
                            try
                            {
                                var asm = Assembly.LoadFrom(dll);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to load {dll}:\n{ex.Message}");
                            }
                        }

                        string json = File.ReadAllText(openDialog.FileName);

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
