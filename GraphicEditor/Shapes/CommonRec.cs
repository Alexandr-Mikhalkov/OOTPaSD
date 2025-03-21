using System;
using System.Drawing;

namespace GraphicEditor
{
    public abstract class CommonRec : Shape
    {
        protected int width = 0;
        protected int height = 0;
        protected Point startPos;

        public CommonRec(Color penColor, Color brushColor, int penWidth, Point startPos)
            : base(penColor, penWidth)
        {
            this.brushColor = brushColor;
            this.startPos = startPos;
            this.position = startPos;
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

        public abstract override void Draw(Graphics g);
    }
}
