using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public abstract class CommonRec : Shape
    {
        public int width { get; set; }
        public int height { get; set; }

        public CommonRec(Color penColor, Color brushColor, int penWidth, Point position, int width, int height)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.penWidth = penWidth;
            this.position = position;
            this.width = width;
            this.height = height;
        }
    }
}
