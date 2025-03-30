using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace GraphicEditor
{
    public class RectangleF : CommonRec
    {
        public RectangleF(Color penColor, Color brushColor, int penWidth, Point startPos)
            : base(penColor, brushColor, penWidth, startPos)
        {
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                Rectangle rect = new Rectangle(position.X, position.Y, width, height);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
