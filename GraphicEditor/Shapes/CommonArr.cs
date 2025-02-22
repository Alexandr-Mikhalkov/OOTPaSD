using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public abstract class CommonArr : Shape
    {
        public Point[] Points { get; set; }

        public CommonArr(Color penColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.Points = points;
        }
    }
}
