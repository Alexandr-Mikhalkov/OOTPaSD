namespace Laba1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            drawButton = new Button();
            clearButton = new Button();
            menuStrip1 = new MenuStrip();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            lineToolStripMenuItem = new ToolStripMenuItem();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            ellipseToolStripMenuItem = new ToolStripMenuItem();
            polygonToolStripMenuItem = new ToolStripMenuItem();
            brokenLineToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Dock = DockStyle.Top;
            pictureBox.Location = new Point(0, 33);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(800, 269);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            // 
            // drawButton
            // 
            drawButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            drawButton.Location = new Point(137, 340);
            drawButton.Name = "drawButton";
            drawButton.Size = new Size(189, 71);
            drawButton.TabIndex = 1;
            drawButton.Text = "Draw";
            drawButton.UseVisualStyleBackColor = true;
            drawButton.Click += drawButton_Click;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            clearButton.Location = new Point(445, 340);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(187, 71);
            clearButton.TabIndex = 2;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lineToolStripMenuItem, rectangleToolStripMenuItem, ellipseToolStripMenuItem, polygonToolStripMenuItem, brokenLineToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(69, 29);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // lineToolStripMenuItem
            // 
            lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            lineToolStripMenuItem.Size = new Size(205, 34);
            lineToolStripMenuItem.Text = "Line";
            lineToolStripMenuItem.Click += lineToolStripMenuItem_Click;
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(205, 34);
            rectangleToolStripMenuItem.Text = "Rectangle";
            rectangleToolStripMenuItem.Click += rectangleToolStripMenuItem_Click;
            // 
            // ellipseToolStripMenuItem
            // 
            ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            ellipseToolStripMenuItem.Size = new Size(205, 34);
            ellipseToolStripMenuItem.Text = "Ellipse";
            ellipseToolStripMenuItem.Click += ellipseToolStripMenuItem_Click;
            // 
            // polygonToolStripMenuItem
            // 
            polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            polygonToolStripMenuItem.Size = new Size(205, 34);
            polygonToolStripMenuItem.Text = "Polygon";
            polygonToolStripMenuItem.Click += polygonToolStripMenuItem_Click;
            // 
            // brokenLineToolStripMenuItem
            // 
            brokenLineToolStripMenuItem.Name = "brokenLineToolStripMenuItem";
            brokenLineToolStripMenuItem.Size = new Size(205, 34);
            brokenLineToolStripMenuItem.Text = "Broken Line";
            brokenLineToolStripMenuItem.Click += brokenLineToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clearButton);
            Controls.Add(drawButton);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Graphic Editor";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button drawButton;
        private Button clearButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem ellipseToolStripMenuItem;
        private ToolStripMenuItem polygonToolStripMenuItem;
        private ToolStripMenuItem brokenLineToolStripMenuItem;
    }
}
