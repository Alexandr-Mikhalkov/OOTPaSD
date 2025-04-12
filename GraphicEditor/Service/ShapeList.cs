using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace GraphicEditor
{
    public class ShapeList
    {
        private List<Shape> _shapes = new List<Shape>();
        private Bitmap _loadedImage;

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape.Clone());
        }

        public void RemoveShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        public void Clear()
        {
            _shapes.Clear();
        }

        public void SetImage(Bitmap image)
        {
            _loadedImage = image;
        }

        public void Draw(Graphics graphics)
        {
            if (_loadedImage != null)
            {
                graphics.DrawImage(_loadedImage, 0, 0);
            }

            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }
    }
}