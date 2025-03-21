using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace GraphicEditor
{
    public class BrokenLine : CommonArr
    {
        public BrokenLine(Color penColor, int penWidth, Point startPoint)
            : base(penColor, penWidth, startPoint)
        {
        }

        public override void Draw(Graphics g)
        {
            if (points.Count > 1)
            {
                using (Pen pen = new Pen(penColor, penWidth))
                {
                    g.DrawLines(pen, points.ToArray());
                }
            }
        }
    }
}
