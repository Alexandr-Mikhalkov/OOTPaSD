using System;
using System.Drawing;
using System.Reflection;

namespace Laba1
{
    public class Polygon : CommonArr
    {
        public Color BrushColor { get; set; }

        public Polygon(Color penColor, Color brushColor, int penWidth, Point[] points)
            : base(penColor, penWidth, points)
        {
            this.BrushColor = brushColor;
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(BrushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                g.FillPolygon(brush, Points);
                g.DrawPolygon(pen, Points);
            }
        }
    }
}
