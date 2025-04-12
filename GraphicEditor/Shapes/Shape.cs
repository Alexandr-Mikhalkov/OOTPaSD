using System;
using System.Drawing;

namespace GraphicEditor
{
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
        public abstract Shape Clone();
    }
}
