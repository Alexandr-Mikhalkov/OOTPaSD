using System;
using System.Drawing;

namespace GraphicEditor
{
    public class Line : Shape
    {
        public Point endPos { get; set; }
        
        public Line(Color penColor, int penWidth, Point start) :base(penColor, penWidth)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.position = start;
        }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLine(pen, position, endPos); 
            }
        }

        public override void UpdateState(Point currentPos)
        {
            endPos = currentPos;
        }
    }
}
