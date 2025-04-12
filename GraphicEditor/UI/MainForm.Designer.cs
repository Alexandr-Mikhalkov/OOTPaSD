namespace GraphicEditor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox = new PictureBox();
            clearButton = new Button();
            mainPanel = new Panel();
            angleCountLabel = new Label();
            pluginLabel = new Label();
            pluginPanel = new FlowLayoutPanel();
            countTrackBar = new TrackBar();
            colorPanel = new Panel();
            colorLabel = new Label();
            panel1 = new Panel();
            shapeLabel = new Label();
            shapeFlowPanel = new FlowLayoutPanel();
            lineButton = new Button();
            rectangleButton = new Button();
            ellipseButton = new Button();
            polygonButton = new Button();
            brokenLineButton = new Button();
            menuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            serializeToolStripMenuItem = new ToolStripMenuItem();
            deserializeToolStripMenuItem = new ToolStripMenuItem();
            pluginsToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            widthTrackBar = new TrackBar();
            contextMenuStrip = new ContextMenuStrip(components);
            trackToolTip = new ToolTip(components);
            countToolTip = new ToolTip(components);
            widthLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)countTrackBar).BeginInit();
            colorPanel.SuspendLayout();
            panel1.SuspendLayout();
            shapeFlowPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)widthTrackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.White;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Location = new Point(115, 196);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(955, 554);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += PictureBoxPaint;
            pictureBox.MouseDoubleClick += PictureBoxMouseDoubleClick;
            pictureBox.MouseDown += PictureBoxMouseDown;
            pictureBox.MouseMove += PictureBoxMouseMove;
            pictureBox.MouseUp += PictureBoxMouseUp;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            clearButton.Location = new Point(1080, 418);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(96, 71);
            clearButton.TabIndex = 2;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButtonClick;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.DarkGray;
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(angleCountLabel);
            mainPanel.Controls.Add(pluginLabel);
            mainPanel.Controls.Add(pluginPanel);
            mainPanel.Controls.Add(countTrackBar);
            mainPanel.Controls.Add(colorPanel);
            mainPanel.Controls.Add(panel1);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 33);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1184, 135);
            mainPanel.TabIndex = 4;
            // 
            // angleCountLabel
            // 
            angleCountLabel.AutoSize = true;
            angleCountLabel.Location = new Point(61, 99);
            angleCountLabel.Name = "angleCountLabel";
            angleCountLabel.Size = new Size(111, 25);
            angleCountLabel.TabIndex = 8;
            angleCountLabel.Text = "Angle Count";
            // 
            // pluginLabel
            // 
            pluginLabel.AutoSize = true;
            pluginLabel.Location = new Point(1018, 99);
            pluginLabel.Name = "pluginLabel";
            pluginLabel.Size = new Size(69, 25);
            pluginLabel.TabIndex = 3;
            pluginLabel.Text = "Plugins";
            pluginLabel.Visible = false;
            // 
            // pluginPanel
            // 
            pluginPanel.Location = new Point(922, 5);
            pluginPanel.Name = "pluginPanel";
            pluginPanel.Size = new Size(253, 85);
            pluginPanel.TabIndex = 7;
            // 
            // countTrackBar
            // 
            countTrackBar.Location = new Point(25, 41);
            countTrackBar.Maximum = 25;
            countTrackBar.Minimum = 5;
            countTrackBar.Name = "countTrackBar";
            countTrackBar.Size = new Size(183, 69);
            countTrackBar.TabIndex = 6;
            countTrackBar.TickStyle = TickStyle.None;
            countTrackBar.Value = 5;
            countTrackBar.ValueChanged += CountTrackBarValueChanged;
            // 
            // colorPanel
            // 
            colorPanel.BorderStyle = BorderStyle.FixedSingle;
            colorPanel.Controls.Add(colorLabel);
            colorPanel.Location = new Point(537, -1);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(379, 135);
            colorPanel.TabIndex = 2;
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.BackColor = Color.DarkGray;
            colorLabel.Location = new Point(154, 99);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(63, 25);
            colorLabel.TabIndex = 2;
            colorLabel.Text = "Colors";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(shapeLabel);
            panel1.Controls.Add(shapeFlowPanel);
            panel1.Location = new Point(257, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 135);
            panel1.TabIndex = 1;
            // 
            // shapeLabel
            // 
            shapeLabel.AutoSize = true;
            shapeLabel.BackColor = Color.DarkGray;
            shapeLabel.Location = new Point(98, 99);
            shapeLabel.Name = "shapeLabel";
            shapeLabel.Size = new Size(69, 25);
            shapeLabel.TabIndex = 1;
            shapeLabel.Text = "Shapes";
            // 
            // shapeFlowPanel
            // 
            shapeFlowPanel.BorderStyle = BorderStyle.FixedSingle;
            shapeFlowPanel.Controls.Add(lineButton);
            shapeFlowPanel.Controls.Add(rectangleButton);
            shapeFlowPanel.Controls.Add(ellipseButton);
            shapeFlowPanel.Controls.Add(polygonButton);
            shapeFlowPanel.Controls.Add(brokenLineButton);
            shapeFlowPanel.Location = new Point(8, 5);
            shapeFlowPanel.Name = "shapeFlowPanel";
            shapeFlowPanel.Size = new Size(265, 85);
            shapeFlowPanel.TabIndex = 0;
            // 
            // lineButton
            // 
            lineButton.BackColor = Color.WhiteSmoke;
            lineButton.BackgroundImageLayout = ImageLayout.Stretch;
            lineButton.FlatStyle = FlatStyle.Flat;
            lineButton.Image = (Image)resources.GetObject("lineButton.Image");
            lineButton.Location = new Point(3, 3);
            lineButton.Name = "lineButton";
            lineButton.Padding = new Padding(0, 0, 0, 1);
            lineButton.Size = new Size(30, 30);
            lineButton.TabIndex = 0;
            lineButton.TextImageRelation = TextImageRelation.ImageAboveText;
            lineButton.UseVisualStyleBackColor = false;
            lineButton.Click += LineButtonClick;
            // 
            // rectangleButton
            // 
            rectangleButton.BackColor = Color.WhiteSmoke;
            rectangleButton.BackgroundImageLayout = ImageLayout.Stretch;
            rectangleButton.FlatStyle = FlatStyle.Flat;
            rectangleButton.Image = (Image)resources.GetObject("rectangleButton.Image");
            rectangleButton.Location = new Point(39, 3);
            rectangleButton.Name = "rectangleButton";
            rectangleButton.Padding = new Padding(0, 0, 1, 1);
            rectangleButton.Size = new Size(30, 30);
            rectangleButton.TabIndex = 1;
            rectangleButton.TextImageRelation = TextImageRelation.ImageAboveText;
            rectangleButton.UseVisualStyleBackColor = false;
            rectangleButton.Click += RectangleButtonClick;
            // 
            // ellipseButton
            // 
            ellipseButton.BackColor = Color.WhiteSmoke;
            ellipseButton.BackgroundImageLayout = ImageLayout.Stretch;
            ellipseButton.FlatStyle = FlatStyle.Flat;
            ellipseButton.Image = (Image)resources.GetObject("ellipseButton.Image");
            ellipseButton.Location = new Point(75, 3);
            ellipseButton.Name = "ellipseButton";
            ellipseButton.Padding = new Padding(0, 0, 1, 1);
            ellipseButton.Size = new Size(30, 30);
            ellipseButton.TabIndex = 2;
            ellipseButton.TextImageRelation = TextImageRelation.ImageAboveText;
            ellipseButton.UseVisualStyleBackColor = false;
            ellipseButton.Click += EllipseButtonClick;
            // 
            // polygonButton
            // 
            polygonButton.BackColor = Color.WhiteSmoke;
            polygonButton.BackgroundImageLayout = ImageLayout.Stretch;
            polygonButton.FlatStyle = FlatStyle.Flat;
            polygonButton.Image = (Image)resources.GetObject("polygonButton.Image");
            polygonButton.Location = new Point(111, 3);
            polygonButton.Name = "polygonButton";
            polygonButton.Padding = new Padding(0, 0, 1, 1);
            polygonButton.Size = new Size(30, 30);
            polygonButton.TabIndex = 3;
            polygonButton.TextImageRelation = TextImageRelation.ImageAboveText;
            polygonButton.UseVisualStyleBackColor = false;
            polygonButton.Click += PolygonButtonClick;
            // 
            // brokenLineButton
            // 
            brokenLineButton.BackColor = Color.WhiteSmoke;
            brokenLineButton.BackgroundImageLayout = ImageLayout.Stretch;
            brokenLineButton.FlatStyle = FlatStyle.Flat;
            brokenLineButton.Image = (Image)resources.GetObject("brokenLineButton.Image");
            brokenLineButton.Location = new Point(147, 3);
            brokenLineButton.Name = "brokenLineButton";
            brokenLineButton.Size = new Size(30, 30);
            brokenLineButton.TabIndex = 4;
            brokenLineButton.TextImageRelation = TextImageRelation.ImageAboveText;
            brokenLineButton.UseVisualStyleBackColor = false;
            brokenLineButton.Click += BrokenLineButtonClick;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, pluginsToolStripMenuItem, undoToolStripMenuItem, redoToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1184, 33);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator1, saveToolStripMenuItem, serializeToolStripMenuItem, deserializeToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(54, 29);
            файлToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(256, 34);
            newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(256, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenFile;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(253, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(256, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveFile;
            // 
            // serializeToolStripMenuItem
            // 
            serializeToolStripMenuItem.Image = (Image)resources.GetObject("serializeToolStripMenuItem.Image");
            serializeToolStripMenuItem.Name = "serializeToolStripMenuItem";
            serializeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            serializeToolStripMenuItem.Size = new Size(256, 34);
            serializeToolStripMenuItem.Text = "Serialize";
            serializeToolStripMenuItem.Click += SerializeToolStripMenuItemClick;
            // 
            // deserializeToolStripMenuItem
            // 
            deserializeToolStripMenuItem.Image = (Image)resources.GetObject("deserializeToolStripMenuItem.Image");
            deserializeToolStripMenuItem.Name = "deserializeToolStripMenuItem";
            deserializeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            deserializeToolStripMenuItem.Size = new Size(256, 34);
            deserializeToolStripMenuItem.Text = "Deserialize";
            deserializeToolStripMenuItem.Click += DeserializeToolStripMenuItemClick;
            // 
            // pluginsToolStripMenuItem
            // 
            pluginsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem });
            pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            pluginsToolStripMenuItem.Size = new Size(85, 29);
            pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Image = (Image)resources.GetObject("loadToolStripMenuItem.Image");
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(212, 34);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadToolStripMenuItemClick;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Image = (Image)resources.GetObject("undoToolStripMenuItem.Image");
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(40, 29);
            undoToolStripMenuItem.Click += UndoToolStripMenuItemClick;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Image = (Image)resources.GetObject("redoToolStripMenuItem.Image");
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(40, 29);
            redoToolStripMenuItem.Click += RedoToolStripMenuItemClick;
            // 
            // widthTrackBar
            // 
            widthTrackBar.Location = new Point(39, 213);
            widthTrackBar.Maximum = 25;
            widthTrackBar.Minimum = 1;
            widthTrackBar.Name = "widthTrackBar";
            widthTrackBar.Orientation = Orientation.Vertical;
            widthTrackBar.Size = new Size(69, 481);
            widthTrackBar.TabIndex = 5;
            widthTrackBar.TickStyle = TickStyle.None;
            widthTrackBar.Value = 1;
            widthTrackBar.ValueChanged += WidthTrackBarValueChanged;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(24, 24);
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(61, 4);
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            widthLabel.Location = new Point(26, 697);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(60, 25);
            widthLabel.TabIndex = 6;
            widthLabel.Text = "Width";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1184, 792);
            Controls.Add(widthLabel);
            Controls.Add(widthTrackBar);
            Controls.Add(mainPanel);
            Controls.Add(clearButton);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Graphic Editor";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)countTrackBar).EndInit();
            colorPanel.ResumeLayout(false);
            colorPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            shapeFlowPanel.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)widthTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button clearButton;
        private Panel mainPanel;
        private FlowLayoutPanel shapeFlowPanel;
        private Button lineButton;
        private Button rectangleButton;
        private Button ellipseButton;
        private Button polygonButton;
        private Button brokenLineButton;
        private MenuStrip menuStrip;
        private Panel panel1;
        private Label shapeLabel;
        private Panel colorPanel;
        private Label colorLabel;
        private TrackBar widthTrackBar;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem serializeToolStripMenuItem;
        private ToolStripMenuItem deserializeToolStripMenuItem;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private TrackBar countTrackBar;
        private ContextMenuStrip contextMenuStrip;
        private ToolTip trackToolTip;
        private ToolTip countToolTip;
        private FlowLayoutPanel pluginPanel;
        private Label pluginLabel;
        private Label angleCountLabel;
        private Label widthLabel;
    }
}
