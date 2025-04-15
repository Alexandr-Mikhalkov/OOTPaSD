using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    public class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ShapeData);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var wrapper = (ShapeData)value;

            var obj = new JObject
            {
                ["ShapeType"] = wrapper.ShapeType,
                ["Shape"] = JObject.FromObject(wrapper.Shape, serializer)
            };

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var shapeTypeName = jsonObject["ShapeType"]?.ToString();

            if (string.IsNullOrEmpty(shapeTypeName))
                throw new JsonException("Error");

            var shapeType = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name == shapeTypeName && typeof(Shape).IsAssignableFrom(t));

            if (shapeType == null)
                throw new JsonException($"Unknown shape type: {shapeTypeName}");

            var shape = (Shape)jsonObject["Shape"].ToObject(shapeType, serializer);

            return new ShapeData
            {
                ShapeType = shapeTypeName,
                Shape = shape
            };
        }
    }
}
