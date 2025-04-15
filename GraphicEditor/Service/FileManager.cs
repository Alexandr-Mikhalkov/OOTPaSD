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
                    try
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
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        var bitmap = new Bitmap(openFileDialog.FileName);
                        MessageBox.Show("Image loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            return null;
        }
    }
}