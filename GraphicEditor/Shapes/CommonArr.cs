using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    public abstract class CommonArr : Shape
    {
        protected List<Point> points;

        public CommonArr(Color penColor, int penWidth, Point startPoint) : base(penColor, penWidth)
        {
            points = new List<Point> { startPoint, startPoint };
        }

        public override void UpdateState(Point currentPos)
        {
            points[points.Count - 1] = currentPos;
        }


        public void AddPoint(Point newPoint)
        {
            points.Add(newPoint);
        }

        public abstract override void Draw(Graphics g);
    }
}
