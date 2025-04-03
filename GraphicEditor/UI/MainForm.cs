using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class MainForm : Form
    {
        private ShapeList shapeList = new ShapeList();
        private ShapeManager shapeManager = new ShapeManager();
        private bool isDrawing = false;
        private bool isBrokenDrawing = false;
        private Point startPos;
        private string currentShapeType = "Line";
        private Shape? currentShape = null;
        private Bitmap loadedImage;
        private Dictionary<string, Func<Point, Shape>> shape;
        private ShapeFactory factory = new ShapeFactory();  
      
        public MainForm()
        {
            InitializeComponent();
            ColorButtonCreator.CreateColorButtons(colorPanel);
            shape = factory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            shapeList.Draw(e.Graphics);
            currentShape?.Draw(e.Graphics);
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            shapeList.Clear();
            pictureBox.Invalidate();
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                isDrawing = true;
                startPos = e.Location;
                CreateShape(startPos);
                shapeManager.PushToUndo(new List<Shape>(shapeList.GetShapes()));
            }
            else if (currentShapeType == "BrokenLine" && currentShape is BrokenLine brokenLine)
            {
                brokenLine.AddPoint(e.Location);
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
                shapeList.AddShape(currentShape);
                currentShape = null;
                isDrawing = false;
            }
            pictureBox.Invalidate();
        }

        private void CreateShape(Point clickLocation)
        {
            currentShape = shape[currentShapeType](clickLocation);
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
        }

        private void BrokenLineButtonClick(object sender, EventArgs e)
        {
            currentShapeType = "BrokenLine";
            isBrokenDrawing = true;
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            shapeList.SetShapes(shapeManager.Undo(shapeList.GetShapes()));
            pictureBox.Invalidate();
        }

        private void RedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            shapeList.SetShapes(shapeManager.Redo(shapeList.GetShapes()));
            pictureBox.Invalidate();
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

                        foreach (Shape shape in shapeList.GetShapes())
                        {
                            shape.Draw(g);
                        }

                        currentShape?.Draw(g);
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
                    shapeList.SetImage(loadedImage);
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

        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files|*.dll",
                Title = "Выберите плагин"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pluginFile = openFileDialog.FileName;

                PluginLoader pluginLoader = new PluginLoader();
                pluginLoader.ShapeButtonClicked += OnShapeButtonClicked;
                pluginLoader.LoadPluginFromFile(pluginFile, pluginPanel);
                pluginLabel.Visible = true;
                pluginPanel.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void OnShapeButtonClicked(string shapeType)
        {
            currentShapeType = shapeType;
            shape = factory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
        }

        private void SerializeToolStripMenuItemClick(object sender, EventArgs e)
        {
            
        }

        private void DeserializeToolStripMenuItemClick(object sender, EventArgs e)
        {
           
        }
    }
}