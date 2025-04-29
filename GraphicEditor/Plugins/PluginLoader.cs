using GraphicEditor.Properties;
using System.Reflection;

namespace GraphicEditor
{
    public class PluginLoader
    {
        public event Action<string> ShapeButtonClicked;

        public void LoadPluginFromFile(string pluginFile, Panel shapePanel)
        {
            try
            {
                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
                
                var shapeClasses = pluginAssembly.GetTypes()
                    .Where(t => typeof(Shape).IsAssignableFrom(t) && !t.IsAbstract)
                    .ToList();

                foreach (var shapeClassType in shapeClasses)    
                {
                    Button shapeButton = new Button
                    {
                        Size = new Size(35, 35),
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImage = Image.FromFile(@"UI\Images\Plugin.png"),
                    };

                    shapeButton.Click += (sender, args) => OnShapeButtonClick(shapeClassType.Name);

                    Label shapeLabel = new Label
                    {
                        Text = shapeClassType.Name,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        AutoSize = true
                    };

                    shapePanel.Controls.Add(shapeButton);
                    shapePanel.Controls.Add(shapeLabel);
                }

                if (!Settings.Default.PluginPaths.Contains(pluginFile))
                {
                    Settings.Default.PluginPaths.Add(pluginFile);
                    Settings.Default.Save(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when uploading {pluginFile}: {ex.Message}");
            }
        }

        private void OnShapeButtonClick(string shapeType)
        {
            ShapeButtonClicked?.Invoke(shapeType);
        }
    }
}
