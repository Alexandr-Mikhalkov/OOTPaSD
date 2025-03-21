using GraphicEditor.Utils;

public static class ColorButtonCreator
{
    private static Panel colorPanel;
    private static Button penColorButton;
    private static Button brushColorButton;
    private static Button activeColorButton;
    private static int currentColorIndex = 0;

    public static void CreateColorButtons(Panel panel)
    {
        colorPanel = panel;
        int padding = 5;
        int startX = 10;
        int startY = 10;

        penColorButton = CreateColorButton(startX, startY, Color.Black);
        penColorButton.Click += (sender, e) => activeColorButton = penColorButton;
        colorPanel.Controls.Add(penColorButton);

        brushColorButton = CreateColorButton(startX, startY + 35 + padding, Color.White);
        brushColorButton.Click += (sender, e) => activeColorButton = brushColorButton;
        colorPanel.Controls.Add(brushColorButton);

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
                if (activeColorButton != null)
                {
                    activeColorButton.BackColor = colorButton.BackColor;
                }
            };

            colorPanel.Controls.Add(colorButton);

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
        colorPanel.Controls.Add(selectColorButton);
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

    public static Button PenColorButton => penColorButton;
    public static Button BrushColorButton => brushColorButton;
}
