using System.Drawing;
using System.Collections.Generic;
using GraphicEditor;

namespace GraphicEditor
{
    public class ShapeList
    {
        private List<Shape> shapes = new List<Shape>();
        private Bitmap loadedImage;

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void Clear()
        {
            shapes.Clear();
        }

        public void Draw(Graphics graphics)
        {
            if (loadedImage != null)
            {
                graphics.DrawImage(loadedImage, 0, 0);
            }

            foreach (var shape in shapes)
            {
                shape.Draw(graphics);
            }
        }

        public Shape[] GetShapes()
        {
            return shapes.ToArray();
        }

        public void SetShapes(Shape[] newShapes)
        {
            shapes = new List<Shape>(newShapes);
        }

        public void SetImage(Bitmap image)
        {
            loadedImage = image;
        }
    }
}