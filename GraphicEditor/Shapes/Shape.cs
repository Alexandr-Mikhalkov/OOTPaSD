using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace GraphicEditor
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")] // Указываем, что класс полиморфный
    [JsonDerivedType(typeof(Line), "Line")]
    [JsonDerivedType(typeof(RectangleF), "Rectangle")]
    [JsonDerivedType(typeof(Ellipse), "Ellipse")]
    [JsonDerivedType(typeof(Polygon), "Polygon")]
    [JsonDerivedType(typeof(BrokenLine), "BrokenLine")]

    public abstract class Shape
    {
        protected Color penColor { get; set; }
        protected Color brushColor { get; set; }
        protected int penWidth { get; set; }
        protected Point position { get; set; }

        public Shape(Color penColor, int penWidth)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
        }

        public abstract void Draw(Graphics g);
        public abstract void UpdateState(Point currentPos);
    }
}
