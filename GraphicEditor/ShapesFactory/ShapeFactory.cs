using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphicEditor
{
    public static class ShapeFactory
    {
        public static Dictionary<string, Func<Point, Shape>> InitializeShapeFactory(Button penColorButton, Button brushColorButton, TrackBar widthTrackBar, TrackBar countTrackBar)
        {
            var shape = new Dictionary<string, Func<Point, Shape>>();

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
                    ConstructorInfo constructor = shapeClassType.GetConstructors().FirstOrDefault();
                    ParameterInfo[] parameters = constructor.GetParameters();

                    object[] args;

                    if (parameters.Length == 3)
                    {
                        args = new object[] { penColorButton.BackColor, widthTrackBar.Value, startPos };
                    }
                    else if (parameters.Length == 4)
                    {
                        args = new object[] { penColorButton.BackColor, brushColorButton.BackColor, widthTrackBar.Value, startPos };
                    }
                    else if (parameters.Length == 5)
                    {
                        args = new object[] { penColorButton.BackColor, brushColorButton.BackColor, widthTrackBar.Value, startPos, countTrackBar.Value };
                    }
                    else if (parameters.Length == 7)
                    {
                        args = new object[]
                        {
                            penColorButton.BackColor,
                            brushColorButton.BackColor,
                            widthTrackBar.Value,
                            startPos,
                            countTrackBar.Value, 
                            100,                 
                            50                
                        };
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unknown constructor: {shapeClassType.Name}");
                    }

                    return (Shape)constructor.Invoke(args);
                };

                shape[className] = shapeFactory;
            }

            return shape;
        }
    }
}
