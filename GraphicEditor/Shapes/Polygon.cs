using System;
using System.Drawing;
using System.Reflection;

namespace GraphicEditor
{
    public class Polygon : Shape
    {
        private List<Point> points;
        private int numSides;
        private Point center;
        private int width = 0;
        private int height = 0;

        public Polygon(Color penColor, Color brushColor, int penWidth, Point center, int numSides) :base(penColor, penWidth)
        {
            this.brushColor = brushColor;
            this.numSides = numSides;
            this.center = center;
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
            width = Math.Abs(currentPos.X - center.X) * 2;
            height = Math.Abs(currentPos.Y - center.Y) * 2;
            points = GeneratePolygonPoints(center, width, height, numSides);
        }
    }
}