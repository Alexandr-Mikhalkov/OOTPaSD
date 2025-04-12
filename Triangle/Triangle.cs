using System;
using System.Drawing;
using System.Collections.Generic;
using GraphicEditor;

namespace TrianglePlugin
{
    public class Triangle : CommonArr
    {
        private int _lengthX = 0;
        private int _lengthY = 0;

        public Triangle(Color penColor, Color brushColor, int penWidth, Point startPoint)
            : base(penColor, penWidth, startPoint)
        {
            this.brushColor = brushColor;

            points = new List<Point>
            {
                startPoint,
                new Point(startPoint.X + _lengthX, startPoint.Y),
                new Point(startPoint.X + _lengthX / 2, startPoint.Y - _lengthY)
            };
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                g.FillPolygon(brush, points.ToArray()); 
                g.DrawPolygon(pen, points.ToArray());   
            }
        }

        public override void UpdateState(Point currentPos)
        {
            _lengthX = currentPos.X - points[0].X;
            _lengthY = points[0].Y - currentPos.Y;

            points[1] = new Point(points[0].X + _lengthX, points[0].Y);              
            points[2] = new Point(points[0].X + _lengthX / 2, points[0].Y - _lengthY); 
        }

        public override Shape Clone() => base.Clone();
    }
}
