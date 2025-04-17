using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class MainForm : Form
    {
        private ShapeList _shapeList = new ShapeList();
        private ShapeManager _shapeManager;
        private Serialization _serialization = new Serialization();
        private Deserialization _deserialization = new Deserialization();
        private FileManager _fileManager = new FileManager();
        private bool _isDrawing = false;
        private bool _isBrokenDrawing = false;
        private Point _startPos;
        private string _currentShapeType = "Line";
        private Shape? _currentShape = null;
        private Bitmap _loadedImage;
        private Dictionary<string, Func<Point, Shape>> _shape;
        private ShapeFactory _factory = new ShapeFactory();  
        
        public MainForm()
        {
            InitializeComponent();
            ColorButtonCreator.CreateColorButtons(colorPanel);
            _shapeManager = new ShapeManager(_shapeList);
            _shape = _factory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            _shapeList.Draw(e.Graphics);
            _currentShape?.Draw(e.Graphics);
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            _shapeList.Clear();
            pictureBox.Invalidate();
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (!_isDrawing)
            {
                _isDrawing = true;
                _startPos = e.Location;
                CreateShape(_startPos);
            }
            else if (_currentShapeType == "BrokenLine" && _currentShape is BrokenLine brokenLine)
            {
                brokenLine.AddPoint(e.Location);
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentShape != null)
            {
                _currentShape.UpdateState(e.Location);
                pictureBox.Invalidate();
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentShape != null && !_isBrokenDrawing)
            {
                _currentShape.UpdateState(e.Location);
                _shapeManager.AddShape(_currentShape.Clone());
                _currentShape = null;
                _isDrawing = false;
            }
            pictureBox.Invalidate();
        }

        private void CreateShape(Point clickLocation)
        {
            _currentShape = _shape[_currentShapeType](clickLocation);
        }

        private void LineButtonClick(object sender, EventArgs e)
        {
            _currentShapeType = "Line";
        }

        private void RectangleButtonClick(object sender, EventArgs e)
        {
            _currentShapeType = "RectangleF";
        }

        private void EllipseButtonClick(object sender, EventArgs e)
        {
            _currentShapeType = "Ellipse";
        }

        private void PolygonButtonClick(object sender, EventArgs e)
        {
            _currentShapeType = "Polygon";
        }

        private void BrokenLineButtonClick(object sender, EventArgs e)
        {
            _currentShapeType = "BrokenLine";
            _isBrokenDrawing = true;
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            _shapeManager.Undo();
            pictureBox.Invalidate();
        }

        private void RedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            _shapeManager.Redo();
            pictureBox.Invalidate();
        }

        private void SaveFile(object sender, EventArgs e)
        {
            try
            {
                _fileManager.SaveFile(pictureBox, _shapeList, _currentShape);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                _loadedImage = _fileManager.OpenFile();
                if (_loadedImage != null)
                {
                    _shapeList.SetImage(_loadedImage);
                    pictureBox.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.Button == MouseButtons.Left && _isDrawing && _currentShape is BrokenLine)
            {
                _isBrokenDrawing = false;
            }
        }

        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files|*.dll",
                Title = "Load plugin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pluginFile = openFileDialog.FileName;

                PluginLoader pluginLoader = new PluginLoader();
                pluginLoader.ShapeButtonClicked += OnShapeButtonClicked;
                pluginLoader.LoadPluginFromFile(pluginFile, pluginPanel);
            }
        }

        private void OnShapeButtonClicked(string shapeType)
        {
            _currentShapeType = shapeType;
            _shape = _factory.InitializeShapeFactory(ColorButtonCreator.PenColorButton, ColorButtonCreator.BrushColorButton, widthTrackBar, countTrackBar);
        }

        private void SerializeToolStripMenuItemClick(object sender, EventArgs e)
        {
            _serialization.SaveShapes(_shapeList);
        }

        private void DeserializeToolStripMenuItemClick(object sender, EventArgs e)
        {
            _deserialization.LoadShapes(_factory, _shapeList, pictureBox, widthTrackBar, countTrackBar);
            _shapeManager.UndoClear();
            _shapeManager.RedoClear();
        }
    }
}