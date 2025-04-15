using System;
using System.Drawing;
using System.Reflection;

namespace GraphicEditor
{
    public abstract class Shape
    {
        public Color penColor { get; set; }
        public Color brushColor { get; set; }
        public int penWidth { get; set; }
        public Point position { get; set; }

        public Shape(Color penColor, int penWidth)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
        }

        public abstract void Draw(Graphics g);
        public abstract void UpdateState(Point currentPos);
        public abstract Shape Clone();

        public virtual void PasteProperties(Shape restoredShape)
        {
            if (restoredShape == null || restoredShape.GetType() != this.GetType())
                return;

            var fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                var value = field.GetValue(restoredShape);
                field.SetValue(this, value);
            }

            var props = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    var value = prop.GetValue(restoredShape);
                    prop.SetValue(this, value);
                }
            }
        }
    }
}
