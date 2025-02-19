using System;
using System.Drawing;

namespace Laba1
{
    public class RectangleF : CommonRec
    {
        public RectangleF(Color penColor, Color brushColor, int penWidth, Point position, int width, int height)
           : base(penColor, brushColor, penWidth, position, width, height) { }

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
