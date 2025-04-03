using GraphicEditor;
using System.Collections.Generic;

namespace GraphicEditor
{
    public class ShapeManager
    {
        private Stack<List<Shape>> undoStack = new Stack<List<Shape>>();
        private Stack<List<Shape>> redoStack = new Stack<List<Shape>>();

        public void PushToUndo(List<Shape> shapes)
        {
            undoStack.Push([.. shapes]);
            ClearRedo();
        }

        public List<Shape> Undo(List<Shape> currentShapes)
        {
            if (undoStack.Count == 0)
                return [.. currentShapes];

            redoStack.Push([.. currentShapes]);
            return undoStack.Pop();
        }

        public List<Shape> Redo(List<Shape> currentShapes)
        {
            if (redoStack.Count == 0)
                return [.. currentShapes];

            undoStack.Push([.. currentShapes]);
            return redoStack.Pop();
        }

        public void ClearRedo()
        {
            redoStack.Clear();
        }
    }
}