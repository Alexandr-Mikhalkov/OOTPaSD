using System;
using System.IO;
using System.Text.Json;

namespace GraphicEditor
{
    public class Serialization
    {
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true, // Форматируем JSON для удобства
            IncludeFields = true // Включаем приватные поля
        };

        public void SaveShapes(string filePath, Shape[] shapes)
        {
            try
            {
                string json = JsonSerializer.Serialize(shapes, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}
