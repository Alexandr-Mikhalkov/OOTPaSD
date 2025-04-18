using System.Collections.Generic;

namespace GraphicEditor
{
    public class ShapeManager
    {
        private Stack<Shape> _undoStack = new Stack<Shape>();
        private Stack<Shape> _redoStack = new Stack<Shape>();
        private ShapeList _shapeList;

        public ShapeManager(ShapeList shapeList)
        {
            _shapeList = shapeList;
        }

        public void AddShape(Shape shape)
        {
            _shapeList.AddShape(shape.Clone());
            _undoStack.Push(shape.Clone());
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;

            var lastShape = _undoStack.Pop();
            _shapeList.RemoveShape();
            _redoStack.Push(lastShape);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;

            var restoredShape = _redoStack.Pop();
            _shapeList.AddShape(restoredShape.Clone());
            _undoStack.Push(restoredShape.Clone());
        }

        public void InitializeUndoStack(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                _undoStack.Push(shapes[i].Clone());
            }
            _redoStack.Clear();
        }
    }
}