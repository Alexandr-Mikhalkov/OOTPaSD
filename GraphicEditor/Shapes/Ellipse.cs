using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace GraphicEditor
{
    public class Ellipse : CommonRec
    {
        public Ellipse(Color penColor, Color brushColor, int penWidth, Point startPos)
            : base(penColor, brushColor, penWidth, startPos)
        {
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                Rectangle rect = new Rectangle(position.X, position.Y, width, height);
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }
        }

        public override Shape Clone() => base.Clone();
    }
}
