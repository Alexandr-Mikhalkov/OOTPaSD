using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using GraphicEditor;

namespace StarPlugin
{
    public class Star : CommonArr
    {
        private int _numPoints;
        private Point _center;
        private int _outerRadius;
        private int _innerRadius;

        public Star(Color penColor, Color brushColor, int penWidth, Point center, int numPoints, int outerRadius, int innerRadius)
            : base(penColor, penWidth, center)
        {
            this.brushColor = brushColor;
            this._numPoints = numPoints;
            this._center = center;
            this._outerRadius = outerRadius;
            this._innerRadius = innerRadius;
            points = GenerateStarPoints(center, outerRadius, innerRadius, numPoints);
        }

        private List<Point> GenerateStarPoints(Point center, int outerRadius, int innerRadius, int numPoints)
        {
            List<Point> starPoints = new List<Point>();
            double angleStep = Math.PI / numPoints;

            for (int i = 0; i < numPoints * 2; i++)
            {
                double angle = i * angleStep - Math.PI / 2;
                int radius = (i % 2 == 0) ? outerRadius : innerRadius;
                int x = center.X + (int)(Math.Cos(angle) * radius);
                int y = center.Y + (int)(Math.Sin(angle) * radius);
                starPoints.Add(new Point(x, y));
            }
            starPoints.Add(starPoints[0]);
            return starPoints;
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
            _outerRadius = Math.Abs(currentPos.X - _center.X);
            _innerRadius = _outerRadius / 2;
            points = GenerateStarPoints(_center, _outerRadius, _innerRadius, _numPoints);
        }

        public override Shape Clone() => base.Clone();
    }
}
