using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GraphicEditor
{
    public class FileManager
    {
        public void SaveFile(PictureBox pictureBox, ShapeList shapeList, Shape currentShape)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save image";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.White);
                            shapeList.Draw(g);
                            currentShape?.Draw(g);
                        }
                        bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    }
                }
            }
        }

        public Bitmap? OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPEG Image|*.jpg|All Files|*.*";
                openFileDialog.Title = "Open image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new Bitmap(openFileDialog.FileName);
                }
            }
            return null;
        }
    }
}