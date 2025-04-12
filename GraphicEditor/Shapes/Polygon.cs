using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text.Json.Serialization;

namespace GraphicEditor
{
    public class Polygon : CommonArr
    {
        private int _numSides;
        private Point _center;
        private int _width = 0;
        private int _height = 0;

        public Polygon(Color penColor, Color brushColor, int penWidth, Point center, int numSides)
            : base(penColor, penWidth, center)
        {
            this.brushColor = brushColor;
            this._numSides = numSides;
            this._center = center;
        }

        private List<Point> GeneratePolygonPoints(Point center, int width, int height, int numSides)
        {
            List<Point> polygonPoints = new List<Point>();
            double angleStep = 2 * Math.PI / numSides;
            double initialAngle = -Math.PI / 2;

            for (int i = 0; i < numSides; i++)
            {
                double angle = initialAngle + i * angleStep;
                int x = center.X + (int)(Math.Cos(angle) * width / 2);
                int y = center.Y + (int)(Math.Sin(angle) * height / 2);
                polygonPoints.Add(new Point(x, y));
            }
            return polygonPoints;
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
            _width = Math.Abs(currentPos.X - _center.X) * 2;
            _height = Math.Abs(currentPos.Y - _center.Y) * 2;
            points = GeneratePolygonPoints(_center, _width, _height, _numSides);
        }

        public override Shape Clone() => base.Clone();
    }
}
