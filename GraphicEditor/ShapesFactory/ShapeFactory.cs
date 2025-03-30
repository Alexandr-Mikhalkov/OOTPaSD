using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace GraphicEditor
{
    public class ShapeFactory
    {
        public Dictionary<string, Func<Point, Shape>> InitializeShapeFactory(Button penColorButton, Button brushColorButton, TrackBar widthTrackBar, TrackBar countTrackBar)
        {
            var shapeFactories = new Dictionary<string, Func<Point, Shape>>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var shapeClasses = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(Shape).IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();

            foreach (var shapeClassType in shapeClasses)
            {
                string className = shapeClassType.Name;

                Func<Point, Shape> shapeFactory = (startPos) =>
                {
                    ConstructorInfo constructor = shapeClassType.GetConstructors().First(); 
                    if (constructor == null)
                        throw new InvalidOperationException($"No constructor found for {shapeClassType.Name}");

                    ParameterInfo[] parameters = constructor.GetParameters();
                    object[] args = new object[parameters.Length];

                    foreach (var param in parameters)
                    {
                        if (param.ParameterType == typeof(Color))
                        {
                            if (args.Contains(penColorButton.BackColor))
                                args[param.Position] = brushColorButton.BackColor;
                            else
                                args[param.Position] = penColorButton.BackColor;
                        }
                        else if (param.ParameterType == typeof(int))
                        {
                            if (args.Contains(widthTrackBar.Value))
                                args[param.Position] = countTrackBar.Value;
                            else
                                args[param.Position] = widthTrackBar.Value;
                        }
                        else if (param.ParameterType == typeof(Point))
                        {
                            args[param.Position] = startPos;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Undefined parameter type: {param.ParameterType.Name} in {shapeClassType.Name}");
                        }
                    }

                    return (Shape)constructor.Invoke(args);
                };

                shapeFactories[className] = shapeFactory;
            }

            return shapeFactories;
        }
    }
}
