using GraphicEditor;
using System.Collections.Generic;

namespace GraphicEditor
{
    public class ShapeManager
    {
        private Stack<Shape[]> undoStack = new Stack<Shape[]>();
        private Stack<Shape[]> redoStack = new Stack<Shape[]>();

        public void PushToUndo(Shape[] shapes)
        {
            undoStack.Push(shapes);
            redoStack.Clear();
        }

        public Shape[] Undo(Shape[] currentShapes)
        {
            if (undoStack.Count == 0)
                return currentShapes;

            redoStack.Push(currentShapes);
            return undoStack.Pop();
        }

        public Shape[] Redo(Shape[] currentShapes)
        {
            if (redoStack.Count == 0)
                return currentShapes;

            undoStack.Push(currentShapes);
            return redoStack.Pop();
        }

        public void ClearRedo()
        {
            redoStack.Clear();
        }
    }
}