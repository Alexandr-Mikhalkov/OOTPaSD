using System;
using System.Drawing;

namespace GraphicEditor
{
    public class Ellipse : Shape
    {
        private int width = 0;
        private int height = 0;
        private Point startPos;

        public Ellipse(Color penColor, Color brushColor, int penWidth, Point startPos) :base(penColor, penWidth)
        {
            this.brushColor = brushColor;
            this.startPos = startPos;
            this.position = startPos;
        }

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

        public override void UpdateState(Point currentPos)
        {
            position = new Point(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y)
            );

            width = Math.Abs(currentPos.X - startPos.X);
            height = Math.Abs(currentPos.Y - startPos.Y);
        }
    }
}
