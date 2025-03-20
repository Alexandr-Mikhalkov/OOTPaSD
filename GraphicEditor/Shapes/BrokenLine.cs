using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    public class BrokenLine : Shape
    {
        private List<Point> points;

        public BrokenLine(Color penColor, int penWidth, Point startPoint) : base(penColor, penWidth)
        {
            points = new List<Point> { startPoint };
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

        public override void UpdateState(Point currentPos)
        {
            if (points.Count == 1)
            {
                points.Add(currentPos);
            }
            else
            {
                points[points.Count - 1] = currentPos;
            }
        }

        public void AddPoint(Point newPoint)
        {
            points.Add(newPoint);
        }
    }
}