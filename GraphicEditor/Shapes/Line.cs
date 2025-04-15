using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace GraphicEditor
{
    public class Line : CommonArr
    {
        public Point endPos { get; set; }

        public Line(Color penColor, int penWidth, Point start)
            : base(penColor, penWidth, start)
        {
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

        public override Shape Clone() => base.Clone();
    }
}
