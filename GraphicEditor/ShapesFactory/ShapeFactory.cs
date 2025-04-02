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
        public Dictionary<string, Func<Point, Shape>> InitializeShapeFactory(
            Button penColorButton,
            Button brushColorButton,
            TrackBar widthTrackBar,
            TrackBar countTrackBar)
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

                    var typeResolvers = new Dictionary<Type, Func<ParameterInfo, object>>
                    {
                        [typeof(Point)] = _ => startPos,
                        [typeof(Color)] = (p) =>
                        {
                            var colorParams = parameters.Where(x => x.ParameterType == typeof(Color)).ToList();
                            int colorIndex = colorParams.IndexOf(p);

                            return colorIndex switch
                            {
                                0 => penColorButton.BackColor,
                                1 => brushColorButton.BackColor,
                                _ => penColorButton.BackColor 
                            };
                        },
                        [typeof(int)] = (p) =>
                        {
                            var intParams = parameters.Where(x => x.ParameterType == typeof(int)).ToList();
                            int paramIndex = intParams.IndexOf(p);

                            return paramIndex switch
                            {
                                0 => widthTrackBar.Value,
                                1 => countTrackBar.Value,
                                _ => 0
                            };
                        }
                    };

                    object[] args = new object[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        if (typeResolvers.TryGetValue(param.ParameterType, out var resolver))
                        {
                            args[i] = resolver(param);
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                $"Undefined parameter type: {param.ParameterType.Name} in {shapeClassType.Name}");
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