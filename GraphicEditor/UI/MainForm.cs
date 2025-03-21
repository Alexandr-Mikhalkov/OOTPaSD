using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class MainForm : Form
    {
        private Shape[] shapes = new Shape[0];
        private bool isDrawing = false;
        private bool isBrokenDrawing = false;
        private Point startPos;
        private string currentShapeType = "Line";
        private Shape currentShape = null;
        private Stack<Shape[]> undoStack = new Stack<Shape[]>();
        private Stack<Shape[]> redoStack = new Stack<Shape[]>();
        private Bitmap loadedImage = null;
        private Dictionary<string, Func<Point, Shape>> shape;

        public MainForm()
        {
            InitializeComponent();
            ColorButtonCreator.CreateColorButtons(colorPanel);
            shape = ShapeFactory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (loadedImage != null)
            {
                e.Graphics.DrawImage(loadedImage, 0, 0);
            }

            // delete nado bydet
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }

            if (currentShape != null)
            {
                currentShape.Draw(e.Graphics);
            }

            if (currentShapeType != "Polygon")
            {
                countTrackBar.Visible = false;
            }
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            shapes = new Shape[0];
            pictureBox.Invalidate();
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                isDrawing = true;
                startPos = e.Location;
                CreateShape(startPos);
                AddToUndoStack();
            }
            else
            {
                if (currentShapeType == "BrokenLine" && currentShape is BrokenLine brokenLine)
                {
                    brokenLine.AddPoint(e.Location);
                }
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null)
            {
                currentShape.UpdateState(e.Location);
                pictureBox.Invalidate();
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null && !isBrokenDrawing)
            {
                currentShape.UpdateState(e.Location);
                shapes = shapes.Append(currentShape).ToArray();
                currentShape = null;
                isDrawing = false;
            }
            pictureBox.Invalidate();
        }

        private void CreateShape(Point clickLocation)
        {
            currentShape = shape[currentShapeType](clickLocation);
        }

        private void AddToUndoStack()
        {
            undoStack.Push((Shape[])shapes.Clone());
        }

        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push((Shape[])shapes.Clone());

                shapes = undoStack.Pop();
                pictureBox.Invalidate();
            }
        }

        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push((Shape[])shapes.Clone());

                shapes = redoStack.Pop();
                pictureBox.Invalidate();
            }
        }

        private void LineButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "Line";
        }

        private void RectangleButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "RectangleF";
        }

        private void EllipseButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "Ellipse";
        }

        private void PolygonButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "Polygon";
            countTrackBar.Visible = true;
        }

        private void BrokenLineButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "BrokenLine";
            isBrokenDrawing = true;
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            Undo();
        }

        private void RedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            Redo();
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg",
                Title = "Save Image"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                int width = pictureBox.Width;
                int height = pictureBox.Height;

                using (Bitmap bmp = new Bitmap(width, height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);

                        foreach (Shape shape in shapes)
                        {
                            shape.Draw(g);
                        }

                        if (currentShape != null)
                        {
                            currentShape.Draw(g);
                        }
                    }

                    bmp.Save(filePath, ImageFormat.Jpeg);
                }
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JPEG Image|*.jpg|All Files|*.*",
                Title = "Open Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loadedImage = new Bitmap(openFileDialog.FileName);
                    pictureBox.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void WidthTrackBarValueChanged(object sender, EventArgs e)
        {
            trackToolTip.SetToolTip(widthTrackBar, $"Width: {widthTrackBar.Value}");
        }

        private void CountTrackBarValueChanged(object sender, EventArgs e)
        {
            countToolTip.SetToolTip(countTrackBar, $"Count: {countTrackBar.Value}");
        }

        private void PictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawing && currentShape is BrokenLine)
            {
                isBrokenDrawing = false;
            }
        }
    }
}