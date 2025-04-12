namespace GraphicEditor
{
    public static class ColorButtonCreator
    {
        private static Panel s_colorPanel;
        private static Button s_penColorButton;
        private static Button s_brushColorButton;
        private static Button s_activeColorButton;
        private static int currentColorIndex = 0;

        public static void CreateColorButtons(Panel panel)
        {
            s_colorPanel = panel;
            int padding = 5;
            int startX = 10;
            int startY = 10;

            s_penColorButton = CreateColorButton(startX, startY, Color.Black);
            s_penColorButton.Click += (sender, e) => s_activeColorButton = s_penColorButton;
            s_colorPanel.Controls.Add(s_penColorButton);

            s_brushColorButton = CreateColorButton(startX, startY + 35 + padding, Color.White);
            s_brushColorButton.Click += (sender, e) => s_activeColorButton = s_brushColorButton;
            s_colorPanel.Controls.Add(s_brushColorButton);

            CreateStandardColorButtons(startX, startY, padding);
        }

        private static Button CreateColorButton(int x, int y, Color color)
        {
            return new Button
            {
                Size = new Size(35, 35),
                Location = new Point(x, y),
                BackColor = color
            };
        }

        private static void CreateStandardColorButtons(int startX, int startY, int padding)
        {
            int btnSize = 22;
            int cols = 10;
            int x = startX + 35 + padding;
            int y = startY;

            List<Button> inactiveButtons = new List<Button>();

            for (int i = 0; i < 30; i++)
            {
                Button colorButton = new Button
                {
                    Size = new Size(btnSize, btnSize),
                    Location = new Point(x, y),
                    BackColor = ColorPalette.Colors[i],
                    Enabled = i < 20
                };

                colorButton.Click += (sender, e) =>
                {
                    if (s_activeColorButton != null)
                    {
                        s_activeColorButton.BackColor = colorButton.BackColor;
                    }
                };

                s_colorPanel.Controls.Add(colorButton);

                if (i >= 20) inactiveButtons.Add(colorButton);

                x += btnSize + padding;
                if ((i + 1) % cols == 0)
                {
                    x = startX + 35 + padding;
                    y += btnSize + padding;
                }
            }

            CreateCustomColorButton(startX + 22 * 14 + padding, startY + 15, inactiveButtons);
        }

        private static void CreateCustomColorButton(int x, int y, List<Button> inactiveButtons = null)
        {
            Button selectColorButton = new Button
            {
                Size = new Size(45, 45),
                Location = new Point(x, y),
                BackColor = Color.White,
                BackgroundImage = Image.FromFile(@"UI\Images\rgb.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };

            selectColorButton.Click += (sender, e) => SelectCustomColor(inactiveButtons);
            s_colorPanel.Controls.Add(selectColorButton);
        }

        private static void SelectCustomColor(List<Button> inactiveButtons)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (currentColorIndex >= inactiveButtons.Count)
                    {
                        currentColorIndex = 0;
                    }

                    Button targetButton = inactiveButtons[currentColorIndex];

                    targetButton.BackColor = colorDialog.Color;
                    targetButton.Enabled = true;

                    currentColorIndex++;
                }
            }
        }

        public static Button PenColorButton => s_penColorButton;
        public static Button BrushColorButton => s_brushColorButton;
    }
}