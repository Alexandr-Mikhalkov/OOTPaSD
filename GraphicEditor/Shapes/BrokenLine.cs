using System;
using System.Drawing;

namespace Laba1
{
    public class BrokenLine : CommonArr
    {
        public BrokenLine(Color penColor, int penWidth, Point[] points)
           : base(penColor, penWidth, points) { }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLines(pen, Points);
            }
        }
    }
}
