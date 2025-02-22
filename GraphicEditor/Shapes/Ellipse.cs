using System;
using System.Drawing;

namespace Laba1
{
    public class Ellipse : CommonRec
    {
        public Ellipse(Color penColor, Color brushColor, int penWidth, Point position, int width, int height)
            : base(penColor, brushColor, penWidth, position, width, height) { }

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
    }
}
