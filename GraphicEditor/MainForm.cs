using System.Windows.Forms;

namespace Laba1
{
    public partial class MainForm : Form
    {

        private Shape[] shapes = new Shape[0];

        public MainForm()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shapes = new Shape[0];
            pictureBox.Invalidate();
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Ellipse(Color.Blue, Color.LightBlue, 5, new Point(50, 50), 300, 200);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Line(Color.Black, 5, new Point(50, 50), new Point(100, 100));
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new RectangleF(Color.Red, Color.Orange, 5, new Point(50, 50), 150, 100);
        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);

            Point[] points = new Point[]
            {
                new Point(50, 50),
                new Point(150, 50),
                new Point(200, 150),
                new Point(100, 200),
                new Point(50, 150)
            };

            shapes[^1] = new Polygon(Color.Black, Color.Red, 5, points);
        }

        private void brokenLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);

            Point[] points = new Point[]
            {
                new Point(50, 50),
                new Point(100, 50),
                new Point(200, 30),
                new Point(300, 150)
            };

            shapes[^1] = new BrokenLine(Color.Red, 5, points);
        }
    }
}
