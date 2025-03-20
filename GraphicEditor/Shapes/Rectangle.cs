using System;
using System.Drawing;

namespace GraphicEditor
{
    public class RectangleF : Shape
    {
        private int width = 0;
        private int height = 0;
        private Point startPos;

        public RectangleF(Color penColor, Color brushColor, int penWidth, Point startPos) :base(penColor, penWidth)
        {
            this.brushColor = brushColor;
            this.startPos = startPos; // для клика мышки
            this.position = startPos; // для рисования
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                Rectangle rect = new Rectangle(position.X, position.Y, width, height);
                g.FillRectangle(brush, rect); 
                g.DrawRectangle(pen, rect);
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
